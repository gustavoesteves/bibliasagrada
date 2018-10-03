using System.ComponentModel.DataAnnotations;

namespace BibliaSagrada.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}