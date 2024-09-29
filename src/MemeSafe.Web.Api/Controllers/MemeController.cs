using MemeSafe.Data.Entity;
using MemeSafe.MemeServices;
using Microsoft.AspNetCore.Mvc;

namespace MemeSafe.Web.Api;

[ApiController]
public class MemeController : ControllerBase
{
    private readonly MemeService _service;

    public MemeController(MemeService service)
    {
        _service = service;
    }

    [HttpPost("api/memes")]
    public async Task<IActionResult> AddMeme([FromBody] MemeCreateDto addMeme, CancellationToken cancellationToken)
    {
        await _service.AddMeme(addMeme, cancellationToken);
        return Ok();
    }

    [HttpGet("api/memes/{id:guid}")]
    public async Task<IActionResult> GetMeme([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var meme = await _service.GetMemeById(id, cancellationToken);
        return Ok(meme);
    }
}
