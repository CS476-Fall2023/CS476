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
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
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
            var viewModel = new PlayerView
            {
                Score = 0,    // Set initial score
                TriesLeft = 5, // Set initial number of tries
            };

            return View(viewModel);
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