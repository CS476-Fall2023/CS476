using System.Collections.Generic;
using ClawQuest.Models;


namespace ClawQuest.Service
{
    public class ClawItemService
    {
        public static List<ClawItem> GetAvailableClawItems()
        {
            var availableItems = new List<ClawItem>
        {
            new ClawItem { Name = "Teddy Bear", WinPercentage = 0.5, Cost = 100 },
            new ClawItem { Name = "Robot Toy", WinPercentage = 0.4, Cost = 140 },
            new ClawItem { Name = "Mega Plushie", WinPercentage = 0.35, Cost = 185 },
            new ClawItem { Name = "Squid Plushie", WinPercentage = 0.3, Cost = 200 },
            new ClawItem { Name = "Actio Figure", WinPercentage = 0.28, Cost = 230 },
            new ClawItem { Name = "Board Game", WinPercentage = 0.24, Cost = 250 },
            new ClawItem { Name = "Lego Set", WinPercentage = 0.2, Cost = 300 },
            new ClawItem { Name = "Puzzle", WinPercentage = 0.18, Cost = 310 },
            new ClawItem { Name = "Basketball", WinPercentage = 0.16, Cost = 330 },
            new ClawItem { Name = "Art Supplies", WinPercentage = 0.14, Cost = 350 },
            new ClawItem { Name = "Toy Kitchen Set", WinPercentage = 0.12, Cost = 400 },
            new ClawItem { Name = "Doll", WinPercentage = 0.1, Cost = 500 },
            new ClawItem { Name = "Doll House", WinPercentage = 0.08, Cost = 520 },
            new ClawItem { Name = "Science Kit", WinPercentage = 0.05, Cost = 550 },
            new ClawItem { Name = "Grand Prize", WinPercentage = 0.04, Cost = 1000 }
        };

            return availableItems;
        }
    }
}
