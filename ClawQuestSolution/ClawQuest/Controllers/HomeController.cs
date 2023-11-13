using Microsoft.AspNetCore.Mvc;
using ClawQuest.Data;
using ClawQuest.Models;
using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ClawQuest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Owner()
        {
            var availableItems = await _context.Toys.ToListAsync();

            // Create the view model with the names and IDs of the toys
            var viewModel = new InputModel()
            {
                // This will create an array of zeros with a length equal to the number of toys
                Inputs = new int[availableItems.Count],
                ItemNames = availableItems.Select(t => t.Name).ToList(),
                ItemIds = availableItems.Select(t => t.ToyId).ToList() // Assuming you have a ToyId property in your Toy model
            };
            return View(viewModel);

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Play()
        {
            return View();
        }

        public IActionResult Leaderboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
        /* [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // This action displays the main page of the web app

            var toys = _context.Toys.ToList();
            var player = _context.Users.FirstOrDefault();
            //ViewBag.Toys = toys;
            //ViewBag.Player = player;
            return View();
        }
        [HttpPost]
         public IActionResult Play(int column)
         {
             // This action handles the user's request to play the claw game
            if (ModelState.IsValid)
             {
                 if (column < 1 || column > 3)
                 {
                     return Json(new { error = "Invalid column number. Please enter 1, 2, or 3." });
                 }

                 // Get the player and the toys from the database
                 var player = _context.Users;
                 var toys = _context.Toys.ToList();

                 // Check if the player has enough money to play
                 if (player.Money <= 0)
                 {
                     return Json(new { error = "You don't have enough money to play. Please insert more money." });
                 }

                 // Check if there are enough toys in the claw machine
                 if (toys.Count < 8)
                 {
                     return Json(new { error = "There are not enough toys in the claw machine. Please wait for the owner to refill it." });
                 }

                 // Simulate the claw game logic
                 var random = new Random();
                 var selectedToy = toys[random.Next(toys.Count)];
                 var result = new { name = selectedToy.Name, Price = selectedToy.Price };

                 if (random.NextDouble() < selectedToy.WinProbability)
                 {
                     // The player wins the toy
                     player.Money += selectedToy.Price;
                     return Json(new { success = true, message = $"Congratulations! You won a {selectedToy.Name}!", result = result });
                 }
                 else
                 {
                     // The player misses the toy
                     return Json(new { success = false, message = "Sorry, you missed this time.", result = result });
                 }

                 // Deduct the toy Price from the player's money
                 player.Money -= selectedToy.Price;

                 _context.SaveChanges();
             }
             else
             {
                 return Json(new { error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
             }
         }
     }
 }
 */