using Microsoft.EntityFrameworkCore;
using CuadradoAPI.Models;

namespace CuadradoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Numero> Numeros { get; set; }
    }
}