using Microsoft.AspNetCore.Mvc;

namespace ArmyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("SeedMasterData")]
    public async Task<IActionResult> SeedMasterDataAsync(
        [FromServices] ArmyDBContext armyDBContext
    )
    {
        var armyDBSeeder = new ArmyDBSeeder(armyDBContext);
        await armyDBSeeder.SeedMasterDataAsync();

        return NoContent();
    }

    [HttpGet("Seed")]
    public async Task<IActionResult> SeedAsync(
        [FromServices] ArmyDBContext armyDBContext
    )
    {
        var armyDBSeeder = new ArmyDBSeeder(armyDBContext);
        await armyDBSeeder.Seed();

        return NoContent();
    }
}
