using System.ComponentModel.DataAnnotations;

namespace Senai_CodeEvent_WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Senha não corresponde aos requisitos")]
        public string Senha { get; set; }
    }
}
