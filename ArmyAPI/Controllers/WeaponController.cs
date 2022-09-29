using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeaponController : ControllerBase
{
    private readonly ILogger<WeaponController> _logger;
    private readonly ArmyDBContext _armyDBContext;

    public WeaponController(
        ILogger<WeaponController> logger,
        ArmyDBContext armyDBContext
        )
    {
        _logger = logger;
        _armyDBContext = armyDBContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Weapon> weapons = await _armyDBContext.Weapons.Include(x => x.WeaponType).ToListAsync();

        return Ok(weapons);
    }

    [HttpGet("{weaponId:int}")]
    public async Task<IActionResult> Get([FromRoute] int weaponId)
    {
        var weapon = await _armyDBContext.Weapons.FindAsync(weaponId);

        if (weapon is null) return NotFound();
        weapon.WeaponType = await _armyDBContext.WeaponTypes.FirstAsync(x => x.Id == weapon.WeaponTypeId);

        return Ok(weapon);
    }

    [HttpPut("{weaponId:int}")]
    public async Task<IActionResult> Put([FromRoute] int weaponId, [FromBody] CreateWeaponViewModel updateWeaponViewModel)
    {
        var weapon = await _armyDBContext.Weapons.FindAsync(weaponId);

        if (weapon is null) return NotFound();
        weapon.Description = updateWeaponViewModel.Description;
        weapon.Name = updateWeaponViewModel.Name;
        weapon.WeaponTypeId = updateWeaponViewModel.Type;
        weapon.IsNuclear = updateWeaponViewModel.IsNuclear;
        weapon.Mass = updateWeaponViewModel.Mass;
        weapon.Length = updateWeaponViewModel.Length;
        weapon.Range = updateWeaponViewModel.Range;

        await _armyDBContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateWeaponViewModel createWeaponViewModel)
    {
        var weapon = new Weapon
        {
            Description = createWeaponViewModel.Description,
            IsNuclear = createWeaponViewModel.IsNuclear,
            Length = createWeaponViewModel.Length,
            Mass = createWeaponViewModel.Mass,
            Range = createWeaponViewModel.Range,
            Name = createWeaponViewModel.Name,
            WeaponTypeId = createWeaponViewModel.Type
        };

        await _armyDBContext.Weapons.AddAsync(weapon);
        await _armyDBContext.SaveChangesAsync();

        return Created("weapon", new { id = weapon.Id });
    }


    [HttpDelete("{weaponId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int weaponId)
    {
        var weaponToRemove = await _armyDBContext.Weapons.FindAsync(weaponId);

        if (weaponToRemove is null) return NotFound();

        _armyDBContext.Weapons.Remove(weaponToRemove);
        await _armyDBContext.SaveChangesAsync();
        return Ok();
    }
}
