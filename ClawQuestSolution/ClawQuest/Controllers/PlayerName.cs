using Microsoft.AspNetCore.Mvc;

namespace ClawQuest.Controllers;

public class PlayerName : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult SubmitName(String playerName)
    {
        return RedirectToAction("Index", "HomeController");
    }
}