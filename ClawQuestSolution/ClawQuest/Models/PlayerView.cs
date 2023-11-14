namespace ClawQuest.Models
{
    public class PlayerView
    {
        public double Score { get; set; } = 0;
        public int TriesLeft { get; set; } = 5;
        public int SelectedColumn { get; set; } = 0;
        public string PrizeResult { get; set; }
    }
}
