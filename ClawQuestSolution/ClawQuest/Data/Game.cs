using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClawQuest.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public int PlaysRemaining { get; set; }
    }
}
