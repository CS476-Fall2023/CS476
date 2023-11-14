namespace ClawQuest.Models
{
    public class PlayerView
    {
        public int Score { get; set; }
        public int TriesLeft { get; set; }
        public int SelectedColumn { get; set; } = 0;
        public string PrizeResult { get; set; }
    }
}
