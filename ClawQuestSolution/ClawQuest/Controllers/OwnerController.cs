using ClawQuest.Models;
using Microsoft.AspNetCore.Mvc;
using ClawQuest.Data;
using Microsoft.EntityFrameworkCore;

namespace ClawQuest.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OwnerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> PopulateToyGrid(InputModel model)
        {
            var game = new Game();
            if(model.Quantities.Sum() > 24)
            {
                return RedirectToAction("Owner", "Home");
            }

            if (model.ItemIds.Count != model.Quantities.Count)
            {
                // Handle the error appropriately, such as adding a model error or logging.
                ModelState.AddModelError("Quantities", "The number of quantities does not match the number of item IDs.");
                // Repopulate the ItemNames for the view to use.
                model.ItemNames = await _context.Toys.Select(t => t.Name).ToListAsync();
                return RedirectToAction("Owner", "Home");
            }

            var availableToys = await _context.Toys
                                              .Where(t => model.ItemIds.Contains(t.ToyId))
                                              .ToListAsync();

            for (int i = 0; i < model.ItemIds.Count; i++)
            {
                int toyId = model.ItemIds[i];
                int quantity = model.Quantities[i];

                game.AddToys(availableToys, toyId, quantity);
            }

            for (int row = 0; row < game.ToyGrid.GetLength(0); row++)
            {
                for (int col = 0; col < game.ToyGrid.GetLength(1); col++)
                {
                    if (game.ToyGrid[row, col] != null)
                    {
                        Console.WriteLine($"ToyGrid[{row}, {col}] = {game.ToyGrid[row, col].Name}");
                    }
                    else
                    {
                        Console.WriteLine($"ToyGrid[{row}, {col}] = null");
                    }
                }
            }

            return RedirectToAction("Owner", "Home");
        }
    }
}
