using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    [Index("Email", IsUnique = true)]
    public class Cliente
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; } = "";
        public string Sobrenome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Endereco { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime DataCriacao { get; set; }
    }
}
