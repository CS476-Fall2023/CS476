using Microsoft.AspNetCore.Mvc;

namespace ClawQuest.Models;

public class ClawItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double WinPercentage { get; set; }
    public int Cost { get; set; }
}