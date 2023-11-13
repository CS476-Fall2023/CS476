using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClawQuest.Models;

namespace ClawQuest.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public int PlaysRemaining { get; set; }

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
    }
}
