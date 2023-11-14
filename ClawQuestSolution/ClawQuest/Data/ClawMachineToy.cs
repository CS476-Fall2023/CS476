using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClawQuest.Data
{
    public class ClawMachineToy
    {
        [Key]
        public int ClawMachineToyId { get; set; }

        public int ToyId { get; set; }

        [ForeignKey("ToyId")]
        public Toy Toys { get; set; }
    }
}
