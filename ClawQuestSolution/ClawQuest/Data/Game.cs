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
    }
}
