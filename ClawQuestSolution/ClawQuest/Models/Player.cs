using Microsoft.AspNetCore.Mvc;

namespace ClawQuest.Models;

public class Player
{
    public int Id { get; set; }
    public double Money { get; set; }
    public int Score { get; set; }
}