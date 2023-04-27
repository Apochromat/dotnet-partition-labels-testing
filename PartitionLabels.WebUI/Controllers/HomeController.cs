using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PartitionLabels.WebUI.Models;

namespace PartitionLabels.WebUI.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(MainModel model) {
        string? result;
        var newModel = new MainModel() {
            input = model.input
        };
        
        try {
            result = string.Join(", ", PartitionLabels.Solution(model.input));
            newModel.result = result;
        }
        catch (ArgumentException e) {
            newModel.result = e.Message;
        }
        catch (Exception e) {
            newModel.result = "";
        }
        
        return View(newModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}