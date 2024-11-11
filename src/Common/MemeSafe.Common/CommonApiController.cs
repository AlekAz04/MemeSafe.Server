using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemeSafe.Common;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CommonApiController : ControllerBase
{
}
