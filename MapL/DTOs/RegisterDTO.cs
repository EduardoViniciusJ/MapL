using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "É necessário colocar um nome para registrar.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "É necessário colocar uma senha para registrar.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "É necessário colocar o e-mail para registrar.")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
