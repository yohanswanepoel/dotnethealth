using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;

namespace app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPatientService _patientService;

    public HomeController(ILogger<HomeController> logger, IPatientService patientService)
    {
        _logger = logger;
        _patientService = patientService;
    }

    public IActionResult Index()
    {
        var patients = _patientService.GetPatients();
        return View(patients);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
