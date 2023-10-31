using System.ComponentModel.DataAnnotations;

namespace ClawQuest.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public int Money { get; set; }
}