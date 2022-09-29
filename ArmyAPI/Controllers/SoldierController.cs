using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SoldierController : ControllerBase
{
    private readonly ILogger<SoldierController> _logger;
    private readonly ArmyDBContext _armyDBContext;

    public SoldierController(
        ILogger<SoldierController> logger,
        ArmyDBContext armyDBContext
        )
    {
        _logger = logger;
        _armyDBContext = armyDBContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Soldier> soldiers = await _armyDBContext.Soldiers.ToListAsync();
        soldiers.ForEach(async soldier =>
        {
            var rank = _armyDBContext.SoldierRanks.First(x => x.Id == soldier.SoldierRankId);

            soldier.SoldierRank = new SoldierRank
            {
                Id = rank.Id,
                Name = rank.Name
            };

            soldier.SoldierExpertises = await _armyDBContext.SoldierExpertises.Where(x => x.Soldiers.Contains(soldier)).ToListAsync();
        });
        return Ok(soldiers);
    }

    [HttpGet("{soldierId:int}")]
    public async Task<IActionResult> Get([FromRoute] int soldierId)
    {
        Soldier? soldier = await _armyDBContext.Soldiers.FindAsync(soldierId);
        if (soldier is null) return NotFound();

        var rank = _armyDBContext.SoldierRanks.First(x => x.Id == soldier.SoldierRankId);

        soldier.SoldierRank = new SoldierRank
        {
            Id = rank.Id,
            Name = rank.Name
        };

        soldier.SoldierExpertises = await _armyDBContext.SoldierExpertises.Where(x => x.Soldiers.Contains(soldier)).ToListAsync();

        return Ok(soldier);
    }

    [HttpPut("{soldierId:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int soldierId,
        [FromBody] CreateSoldierViewModel updateSoldierViewModel
        )
    {
        Soldier? soldier = await _armyDBContext.Soldiers.FindAsync(soldierId);
        if (soldier is null) return NotFound();

        soldier.Address = updateSoldierViewModel.Address;
        soldier.ChestWidth = updateSoldierViewModel.ChestWidth;
        soldier.DateOfBirth = updateSoldierViewModel.DateOfBirth;
        soldier.FirstName = updateSoldierViewModel.FirstName;
        soldier.Height = updateSoldierViewModel.Height;
        soldier.IsSpecialForces = updateSoldierViewModel.IsSpecialForce;
        soldier.LastName = updateSoldierViewModel.LastName;
        soldier.SoldierRankId = updateSoldierViewModel.Rank;
        soldier.Weight = updateSoldierViewModel.Weight;

        await _armyDBContext.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("expertise")]
    public async Task<IActionResult> Expertise()
    {
        List<SoldierExpertise> soldierExpertises = await _armyDBContext.SoldierExpertises.ToListAsync();
        return Ok(soldierExpertises);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSoldierViewModel createSoldierViewModel)
    {
        var soldier = new Soldier
        {
            FirstName = createSoldierViewModel.FirstName,
            LastName = createSoldierViewModel.LastName,
            Address = createSoldierViewModel.Address,
            IsSpecialForces = createSoldierViewModel.IsSpecialForce,
            SoldierRankId = createSoldierViewModel.Rank,
            Height = createSoldierViewModel.Height,
            ChestWidth = createSoldierViewModel.ChestWidth,
            Weight = createSoldierViewModel.Weight,
            DateOfBirth = createSoldierViewModel.DateOfBirth,
            RecruitedOn = DateTime.Today,
            SoldierExpertises = await _armyDBContext.SoldierExpertises.Where(x => createSoldierViewModel.Expertises.Contains(x.Id)).ToListAsync()
        };

        await _armyDBContext.Soldiers.AddAsync(soldier);
        await _armyDBContext.SaveChangesAsync();

        return Created("soldier", new { id = soldier.Id });
    }


    [HttpDelete("{soldierId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int soldierId)
    {
        var soldierToRemove = await _armyDBContext.Soldiers.FindAsync(soldierId);

        if (soldierToRemove is null) return NotFound();

        _armyDBContext.Soldiers.Remove(soldierToRemove);
        await _armyDBContext.SaveChangesAsync();
        return Ok();
    }
}
