using System.ComponentModel.DataAnnotations;

namespace FootballTeamSystem.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}