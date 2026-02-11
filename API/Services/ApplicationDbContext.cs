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
        
        public DbSet<Client>Clients { get; set; }
    }
}
