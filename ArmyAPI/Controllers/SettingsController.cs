using Microsoft.AspNetCore.Mvc;

namespace ArmyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
    private readonly ILogger<SettingsController> _logger;

    public SettingsController(ILogger<SettingsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("profile-picture")]
    public string Get([FromServices] ArmyDBContext armyDBContext)
    => $"/{armyDBContext.ProfileImages.OrderByDescending(x => x.Id).FirstOrDefault()?.Name}";

    [HttpPost("profile-picture")]
    public async Task<IActionResult> ProfilePicture(
        [FromForm] IFormFile file,
        [FromServices] IWebHostEnvironment whe,
        [FromServices] ArmyDBContext armyDBContext
    )
    {
        string absolutePath = $"{whe.WebRootPath}/profile-pictures/{file.FileName}";
        using var fs = new FileStream(absolutePath, FileMode.Create);
        await file.CopyToAsync(fs);
        await armyDBContext.ProfileImages.AddAsync(new ProfileImage
        {
            Name = file.FileName
        });
        await armyDBContext.SaveChangesAsync();

        return Ok();
    }

}
