using Microsoft.AspNetCore.Mvc;

namespace ClawQuest.Models;

public class ClawItem
{
    public string Name { get; set; }
    public double WinPercentage { get; set; }
    public int Cost { get; set; }
}