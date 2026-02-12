using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class ClientDto
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string PrimeiroNome { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sobrenome { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Phone]
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }   
        [Required]
        public string Status { get; set; } = "";
    }
}
