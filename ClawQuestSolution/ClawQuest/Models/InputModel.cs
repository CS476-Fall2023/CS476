namespace ClawQuest.Models
{
    public class InputModel
    {
        public int[] Inputs { get; set; } = new int[15];
        public List<string> ItemNames { get; set; }
        public List<int> ItemIds { get; set; }
        public List<int> Quantities { get; set; }
    }
}
