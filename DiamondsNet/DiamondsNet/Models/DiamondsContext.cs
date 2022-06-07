using Microsoft.EntityFrameworkCore;

namespace DiamondsAPI.Models
{
    public class DiamondsContext : DbContext
    {
        public DiamondsContext(DbContextOptions<DiamondsContext> options)
            : base(options)
        {
        }

        public DbSet<Diamond> Diamonds { get; set; } = null!;
    }
}