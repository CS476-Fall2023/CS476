using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClawQuest.Models;
using ClawQuest.Service;

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
        public ClawItem[,] ToyGrid { get; set; }

        public Game()
        {
            ToyGrid = new ClawItem[3, 8];

        }

        public void PopulateToyGrid(int[] inputs)
        {
            List<ClawItem> availableItems = ClawItemService.GetAvailableClawItems();

            int inputIndex = 0;
            for (int row = 0; row < ToyGrid.GetLength(0); row++)
            {
                for (int col = 0; col < ToyGrid.GetLength(1); col++)
                {
                    if (inputIndex < inputs.Length && inputs[inputIndex] > 0)
                    {
                        ToyGrid[row, col] = availableItems[inputIndex];
                        inputs[inputIndex]--;
                    }
                    else
                    {
                        inputIndex++;
                        if (inputIndex >= inputs.Length)
                        {
                            break; // Exit if all inputs are processed
                        }
                        col--; // Repeat the same cell with the next item
                    }
                }
            }
        }
    }
}
