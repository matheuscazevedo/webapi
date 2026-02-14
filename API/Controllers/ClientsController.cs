using Shared.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClientsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Cliente> GetClients()
        {
            return context.Clientes
                          .OrderByDescending(c => c.Id)
                          .ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = context.Clientes.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public IActionResult CreateClient(ClientDto clientDto)
        {
            var otherClient = context.Clientes
                                     .FirstOrDefault(c => c.Email == clientDto.Email);

            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "Este email já está em uso");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = new Cliente
            {
                PrimeiroNome = clientDto.PrimeiroNome,
                Sobrenome = clientDto.Sobrenome,
                Email = clientDto.Email,
                Telefone = clientDto.Telefone ?? "",
                Endereco = clientDto.Endereco ?? "",
                Status = clientDto.Status,
                DataCriacao = DateTime.Now
            };

            context.Clientes.Add(client);
            context.SaveChanges();

            return Ok(client);
        }

        [HttpPut("{id}")]
        public IActionResult EditClient(int id, ClientDto clientDto)
        {
            var otherClient = context.Clientes
                                     .FirstOrDefault(c => c.Id != id && c.Email == clientDto.Email);

            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "Este email já está em uso por outro usuário");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = context.Clientes.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            client.PrimeiroNome = clientDto.PrimeiroNome;
            client.Sobrenome = clientDto.Sobrenome;
            client.Email = clientDto.Email;
            client.Telefone = clientDto.Telefone ?? "";
            client.Endereco = clientDto.Endereco ?? "";
            client.Status = clientDto.Status;

            context.SaveChanges();

            return Ok(client);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = context.Clientes.Find(id);

            if (client == null)
            {
                return NotFound(); 
            }

            context.Clientes.Remove(client);
            context.SaveChanges();

            return Ok();
        }
    }
}
