using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Controllers;

// [ApiController]
// [NonController]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("")]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() {
        return Redirect("~/swagger");
    }
}