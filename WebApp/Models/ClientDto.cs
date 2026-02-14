namespace WebApp.Models
{
    public class ClientDto
    {
        public string PrimeiroNome { get; set; } = "";
        public string Sobrenome { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string Status { get; set; } = "";
        public long StatusId { get; set; }

    }
}
