namespace ClawQuest.Models
{
    public class InputModel
    {
        public int[] Inputs { get; set; } = new int[15];
        public List<string> ItemNames { get; set; } = new List<string>(15);
        public List<int> ItemIds { get; set; } = new List<int>(15);
        public List<int> Quantities { get; set; } = new List<int>(15);

        public InputModel() {
            for (int i = 0; i < 15; i++)
            {
                ItemNames.Add("");
            }
            for (int i = 0; i < 15; i++)
            {
                ItemIds.Add(0);
            }
            for (int i = 0; i < 15; i++)
            {
                Quantities.Add(0);
            }
        }
    }
}
