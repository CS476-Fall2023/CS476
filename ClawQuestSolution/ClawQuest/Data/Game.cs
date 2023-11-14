using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClawQuest.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ClawQuest.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; } = 0;
        public int PlaysRemaining { get; set; } = 3;

        [NotMapped]
        public Toy[,] ToyGrid { get; set; }

        public Game()
        {
            ToyGrid = new Toy[3, 8];

        }

        public void AddToys(List<Toy> availableToys, int toyId, int quantity)
        {

            // Find the toy in the availableToys list.
            var toyToAdd = availableToys.FirstOrDefault(t => t.ToyId == toyId);
            if (toyToAdd != null)
            {
                // Iterate over the ToyGrid and add the toy instances based on the quantity.
                for (int i = 0; i < quantity; i++)
                {
                    bool added = AddToyToGrid(toyToAdd);
                    if (!added)
                    {
                        throw new InvalidOperationException("Unable to add more toys to the grid as it's full.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Toy with ID {toyId} not found.");
                throw new ArgumentException($"No toy found with ID: {toyId}");
                
            }
        }
        private bool AddToyToGrid(Toy toy)
        {
            for (int row = 0; row < ToyGrid.GetLength(0); row++)
            {
                for (int col = 0; col < ToyGrid.GetLength(1); col++)
                {
                    if (ToyGrid[row, col] == null)
                    {
                        ToyGrid[row, col] = toy;

                        return true;
                    }
                }
            }
            return false;
        }
        public string ChoosePrize(int column)
        {
            if (column >= 0 && column < ToyGrid.GetLength(1)) // Ensure the chosen column is within bounds
            {

                Toy prize = ToyGrid[0, column];

                ToyGrid[0, column].Name = " ";
                ToyGrid[0, column].Points = 0;
                ToyGrid[0, column].WinProbability = 0;

                PlaysRemaining--;
                return prize.Name;
            }
            else if (ToyGrid[0, column].Name == " ")
            {
                Toy prize = ToyGrid[1, column];

                ToyGrid[1, column].Name = " ";
                ToyGrid[1, column].Points = 0;
                ToyGrid[1, column].WinProbability = 0;
                PlaysRemaining--;
                return prize.Name;

            }
            else if (ToyGrid[1, column].Name == " ")
            {
                Toy prize = ToyGrid[2, column];
                ToyGrid[2, column].Name = " ";
                ToyGrid[2, column].Points = 0;
                ToyGrid[2, column].WinProbability = 0;
                PlaysRemaining--;
                return prize.Name;

            }
            else if (ToyGrid[2, column].Name == " ")
            {
                return "Nothing is here!";
            }
            else
            {
                // Handle invalid column choice, e.g., return an error view or redirect
                return "invalid";
            }
        }

        public int AddScore(int column)
        {
            string prizeName = ChoosePrize(column);

            if (prizeName == "invalid" || prizeName == "Nothing is here!")
            {
                return 0;
            }

            Dictionary<string, int> prizePointsMap = new Dictionary<string, int>
                {
                    { "Mega Plushie", 200 },
                    { "Teddy Bear", 160 },
                    { "Squid Plushie", 120},
                    { "Action Figure", 100 },
                    { "Remote Control Car",250 },
                    { "Board Game",190 },
                    { "Doll House", 300},
                    { "LEGO Set",250},
                    { "Puzzle", 150 },
                    { "Robot Kit", 230 },
                    { "Super Soaker Water Gun", 180 },
                    { "Science Kit", 220 },
                    { "Basketball", 130},
                    { "Toy Kitchen Set", 280 },
                    { "Art Supplies",170 }
                };
            if (prizePointsMap.ContainsKey(prizeName))
            {
                int prizePoints = prizePointsMap[prizeName];
                Score += prizePoints; // Add the prize points to the player's score
            }
            return Score;
        }
    }
}
