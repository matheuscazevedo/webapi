using Shared.Models;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Cliente>Clientes { get; set; }
    }
}
