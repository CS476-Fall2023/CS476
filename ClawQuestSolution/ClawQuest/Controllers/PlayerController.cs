using ClawQuest.Models;
using Microsoft.AspNetCore.Mvc;
using ClawQuest.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ClawQuest.Controllers
{
    public class PlayerController : Controller
    {
        private readonly Game _game; // Assuming you have a reference to the Game object

        public PlayerController(Game game)
        {
            _game = game;
        }

        public string ChoosePrize(int column)
        {
            if (column >= 0 && column < _game.ToyGrid.GetLength(1)) // Ensure the chosen column is within bounds
            {
                
                Toy prize = _game.ToyGrid[0, column]; 

                _game.ToyGrid[0, column].Name = " ";
                _game.ToyGrid[0, column].Points = 0;
                _game.ToyGrid[0, column].WinProbability = 0;

                _game.PlaysRemaining--;
                return prize.Name;
            }
            else if (_game.ToyGrid[0, column].Name == " ")
            {
                Toy prize = _game.ToyGrid[1, column];

                _game.ToyGrid[1, column].Name = " ";
                _game.ToyGrid[1, column].Points = 0;
                _game.ToyGrid[1, column].WinProbability = 0;
                _game.PlaysRemaining--;
                return prize.Name;

            }
            else if (_game.ToyGrid[1, column].Name == " ")
            {
                Toy prize = _game.ToyGrid[2, column];
                _game.ToyGrid[2, column].Name = " ";
                _game.ToyGrid[2, column].Points = 0;
                _game.ToyGrid[2, column].WinProbability = 0;
                _game.PlaysRemaining--;
                return prize.Name;

            }
            else if (_game.ToyGrid[2, column].Name == " ")
            {
                return "Nothing is here!";
            }
            else
            {
                // Handle invalid column choice, e.g., return an error view or redirect
                return "invalid";
            }
        }

        public int AddPrize(int column)
        {
            string prizeName = ChoosePrize(column);

            if(prizeName == "invalid" || prizeName == "Nothing is here!")
            {
                return 0;
            }

            Dictionary<string, int> prizePointsMap = new Dictionary<string, int>
    {
        { "Mega Plushie", 200 },
        { "Teddy Bear", 160 },
                { }
    };
        }


    }
}
