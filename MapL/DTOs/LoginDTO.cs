using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "É necessário colocar o nome de acesso.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "É necessário colocar a senha de acesso.")]
        public string Password { get; set; }
    }
}
