using Microsoft.AspNetCore.Mvc;

namespace ClawQuest.Models;

public class Game
{
    public int GameId { get; set; }
    public int UserId { get; set; }
    public int Score { get; set; }
    public int PlaysRemaining { get; set; }
    
    public void UpdateScore(int newScore)
    {
        this.Score = newScore;
    }
    
}