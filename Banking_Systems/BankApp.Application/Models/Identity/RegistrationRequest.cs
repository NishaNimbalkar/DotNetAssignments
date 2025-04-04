using System.ComponentModel.DataAnnotations;

namespace BankApp.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName {  get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Location {  get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName {  get; set; }
        [Required]

        public string Password { get; set; } = string.Empty;

    }
}
