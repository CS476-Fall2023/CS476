using Microsoft.AspNetCore.Mvc;

namespace ClawQuest.Models;

public class Upgrade
{
    public int UpgradeId { get; set; }
    public int UserId { get; set; }
    public int Type { get; set; }
}