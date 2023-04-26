using Microsoft.AspNetCore.Mvc;
using PartitionLabels.WebAPI.Models;

namespace PartitionLabels.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : ControllerBase {
    private readonly ILogger<MainController> _logger;

    public MainController(ILogger<MainController> logger) {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post(RequestModel model) {
        try {
            return Ok(PartitionLabels.Solution(model.Input));
        }
        catch (ArgumentOutOfRangeException e) {
            return BadRequest(e.Message);
        }
        catch (ArgumentException e) {
            return BadRequest(e.Message);
        }
    }
}