using ClawQuest.Models;
using Microsoft.AspNetCore.Mvc;
using ClawQuest.Data;

namespace ClawQuest.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {
            return View(new InputModel());
        }

        [HttpPost]
        public IActionResult CreateGame(InputModel inputModel)
        {
            var game = new Game();
            game.PopulateToyGrid(inputModel.Inputs);

            //add more logic here
            return View("GameCreated", game);
        }
    }
}
