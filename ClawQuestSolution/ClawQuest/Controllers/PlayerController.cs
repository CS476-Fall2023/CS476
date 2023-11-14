using ClawQuest.Models;
using Microsoft.AspNetCore.Mvc;
using ClawQuest.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ClawQuest.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult OperateClaw(PlayerView model)
        {
            var game = new Game();
            // Implement your game logic here to determine the prize result, tries left, and user score
            string prizeResult = game.ChoosePrize(model.SelectedColumn); // Replace with your game logic
            int triesLeft = game.PlaysRemaining; // Replace with your game logic
            int userScore = game.AddScore(model.TriesLeft); // Replace with your game logic

            // Create an anonymous object to hold the response data
                model.PrizeResult = prizeResult;
                model.TriesLeft = triesLeft;
                model.Score = userScore;

            return View(model);
        }


    }
}
