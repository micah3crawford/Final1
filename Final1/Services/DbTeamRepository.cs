using Final1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final1.Services
{
    public class DbTeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _db;

        public DbTeamRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Team? Read(int id)
        {
            return _db.Teams
                .Include(p => p.PlayerRanks)
                    .ThenInclude(ptr => ptr.Player)
                .FirstOrDefault(t => t.Id == id);
        }
        public ICollection<Team> ReadAll()
        {
            return _db.Teams
                 .Include(p => p.PlayerRanks)
                    .ThenInclude(ptr => ptr.Player)
                .ToList();
        }
    }
}
