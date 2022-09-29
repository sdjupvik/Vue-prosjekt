using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MissionController : ControllerBase
{
    private readonly ILogger<MissionController> _logger;
    private readonly ArmyDBContext _armyDBContext;

    public MissionController(
        ILogger<MissionController> logger,
        ArmyDBContext armyDBContext
        )
    {
        this._logger = logger;
        this._armyDBContext = armyDBContext;
    }

    [HttpGet("{missionId:int}")]
    public async Task<IActionResult> Get([FromRoute] int missionId)
    {
        Mission? mission = await _armyDBContext.Missions.FindAsync(missionId);
        if (mission is null) return NotFound();
        mission.Soldiers = await _armyDBContext.Soldiers.Where(x => x.Missions.Contains(mission)).ToListAsync();
        return Ok(mission);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Mission> missions = await _armyDBContext.Missions.Include(x => x.MissionStatus).ToListAsync();
        missions.ForEach(mission =>
        {
            mission.Vehicles = _armyDBContext.Vehicles.Where(x => x.Missions.Contains(mission)).ToList();
            mission.Soldiers = _armyDBContext.Soldiers.Where(x => x.Missions.Contains(mission)).ToList();
            mission.Weapons = _armyDBContext.Weapons.Where(x => x.Missions.Contains(mission)).ToList();
        });
        return Ok(missions);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateMissionViewModel createMissionViewModel)
    {
        var mission = new Mission
        {
            Name = createMissionViewModel.Name,
            Description = createMissionViewModel.Description,
            MissionStatusId = (int)EMissionStatus.Planning,
            PlanningStartedOn = DateTime.Today,
            Soldiers = await _armyDBContext.Soldiers
                            .Where(x => createMissionViewModel.Soldiers.Contains(x.Id))
                            .ToListAsync(),
        };
        await _armyDBContext.Missions.AddAsync(mission);
        await _armyDBContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{missionId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int missionId)
    {
        var missionToRemove = await _armyDBContext.Missions.FindAsync(missionId);

        if (missionToRemove is null) return NotFound();

        _armyDBContext.Missions.Remove(missionToRemove);
        await _armyDBContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{missionId:int}/start")]
    public async Task<IActionResult> Start([FromRoute] int missionId)
    {
        Mission? mission = await _armyDBContext.Missions.FindAsync(missionId);
        if (mission is null) return NotFound();

        mission.MissionStartedOn = DateTime.Today;
        mission.MissionStatusId = (int)EMissionStatus.InProgress;

        await _armyDBContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{missionId:int}")]
    public async Task<IActionResult> Update([FromRoute] int missionId, [FromBody] UpdateMissionViewModel updateMissionViewModel)
    {
        Mission? mission = await _armyDBContext.Missions.Include(x => x.Soldiers).Where(x => x.Id == missionId).FirstAsync();
        if (mission is null) return NotFound();

        mission.Name = updateMissionViewModel.Name;
        mission.Description = updateMissionViewModel.Description;
        mission.MissionStatusId = updateMissionViewModel.Status;
        mission.EquipmentRepairCost = updateMissionViewModel.Damage;
        mission.Soldiers = await _armyDBContext.Soldiers.Where(x => updateMissionViewModel.Soldiers.Contains(x.Id)).ToListAsync();
        if (updateMissionViewModel.Status == (int)EMissionStatus.InProgress)
            mission.MissionStartedOn = DateTime.Today;
        if (updateMissionViewModel.Status == (int)EMissionStatus.Failed || updateMissionViewModel.Status == (int)EMissionStatus.Successful)
            mission.MissionCompletedOn = DateTime.Today;

        await _armyDBContext.SaveChangesAsync();
        return Ok();
    }
}
