using Microsoft.AspNetCore.Mvc;
using ClawQuest.Data;
using ClawQuest.Models;
using System;
using System.Linq;

namespace ClawQuest.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // This action displays the main page of the web app

            var toys = _context.Toys.ToList();
            var player = _context.Players.FirstOrDefault();
            if (player == null)
            {
                // If there is no player in the database, create a new one
                player = new Player { Money = 2000, Score = 0 };
                _context.Players.Add(player);
                _context.SaveChanges();
            }
            ViewBag.Toys = toys;
            ViewBag.Player = player;
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
                var player = _context.Players.FirstOrDefault();
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
                var result = new { name = selectedToy.Name, cost = selectedToy.Cost };

                if (random.NextDouble() < selectedToy.WinPercentage)
                {
                    // The player wins the toy
                    player.Score += selectedToy.Cost;
                    return Json(new { success = true, message = $"Congratulations! You won a {selectedToy.Name}!", result = result });
                }
                else
                {
                    // The player misses the toy
                    return Json(new { success = false, message = "Sorry, you missed this time.", result = result });
                }

                // Deduct the toy cost from the player's money
                player.Money -= selectedToy.Cost;

                _context.SaveChanges();
            }
            else
            {
                return Json(new { error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }
        }
    }
}
