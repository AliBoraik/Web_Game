using Game.Models.GameModels;
using Microsoft.EntityFrameworkCore;

namespace GameDataBase.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Monster> Monsters { get; set; }
    }
}