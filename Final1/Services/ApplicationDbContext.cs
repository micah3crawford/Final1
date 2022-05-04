using Final1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final1.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players => Set<Player>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<PlayerTeamRank> PlayerTeamRanks => Set<PlayerTeamRank>();

        public DbSet<Draft> Drafts => Set<Draft>();

    }
}
