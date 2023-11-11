using Microsoft.AspNetCore.Mvc;

namespace ClawQuest.Models;

public class Player
{
    public int Id { get; set; }
    public int Money { get; set; }
    public int Score { get; set; }
}