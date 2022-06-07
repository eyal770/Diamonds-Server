using Microsoft.EntityFrameworkCore;

namespace DiamondsAPI.Models
{
    public class DiamondContext : DbContext
    {
        public DiamondContext(DbContextOptions<DiamondContext> options)
            : base(options)
        {
        }

        public DbSet<Diamond> Diamonds { get; set; }
    }
}