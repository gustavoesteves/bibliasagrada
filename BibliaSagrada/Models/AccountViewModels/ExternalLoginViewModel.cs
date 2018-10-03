using System.ComponentModel.DataAnnotations;

namespace BibliaSagrada.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}