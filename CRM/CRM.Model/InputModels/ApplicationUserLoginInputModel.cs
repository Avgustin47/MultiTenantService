using System.ComponentModel.DataAnnotations;

namespace CRM.Model.InputModels
{
    public class ApplicationUserLoginInputModel
    {
        [Required]
        
        public required string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public required string Password { get; set; }


    }
}
