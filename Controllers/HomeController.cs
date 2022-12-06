using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost("process")]
    public new IActionResult User(User newUser)
    {
        if(ModelState.IsValid)
        {
            System.Console.WriteLine($"Name: {newUser.Name}");
            System.Console.WriteLine($"Email: {newUser.Email}");
            System.Console.WriteLine($"Birthday: {newUser.Birthday}");
            System.Console.WriteLine($"Password: {newUser.Password}");
            System.Console.WriteLine($"Fav odd number: {newUser.OddNum}");
            return RedirectToAction("Results", newUser);
        }
        else{
            return View("Index");
        }
    }

    [HttpGet("Results")]
    public IActionResult Results(User newUser)
    {

        return View(newUser);
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
