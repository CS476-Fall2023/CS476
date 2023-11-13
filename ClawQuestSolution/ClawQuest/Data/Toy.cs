using System.ComponentModel.DataAnnotations;

namespace ClawQuest.Data
{
    public class Toy
    {
        [Key]
        public int ToyId { get; set; }
        public string Name { get; set; }
        public double Points { get; set; }
        public double WinProbability { get; set; }
    }
}
