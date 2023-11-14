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

            int totalCount = _context.ClawMachineToys.Count();


            Random random = new Random();
            int randomIndex = random.Next(0, totalCount);


            var randomItem = _context.ClawMachineToys
                .Skip(randomIndex)
                .FirstOrDefault();


            if (randomItem != null)
            {
                var winProbability = _context.Toys.FirstOrDefault(p => p.ToyId == randomItem.ToyId).WinProbability;
                double winPercent = random.NextDouble();
                if (winPercent >= winProbability)
                {
                    model.PrizeResult = randomItem.Toys.Name;
                    model.TriesLeft = model.TriesLeft - 1;
                    model.Score = randomItem.Toys.Points;
                }
                else
                {
                    model.PrizeResult = "Please Try Again.";
                    model.TriesLeft = model.TriesLeft - 1;
                }
            }
            TempData["PrizeResult"] = model.PrizeResult;
            TempData["TriesLeft"] = model.TriesLeft;
           //TempData["Score"] = model.Score;
            return RedirectToAction("Play", "Home");
        }
    }
}
