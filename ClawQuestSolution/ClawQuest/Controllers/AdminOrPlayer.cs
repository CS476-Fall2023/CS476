using Microsoft.AspNetCore.Mvc;

namespace ClawQuest.Controllers;

public class AdminOrPlayer : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult CheckRole(String role)
    {
        if (role == "Admin")
        {
            return View("AdminLogin"); // If Admin is Selected then redirect to Admin Login Page(Yet to be created)
        }
        else if (role == "Player")
        {
            return RedirectToAction("Index", "HomeController");
        }

        }
}