using Final1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final1.Services
{
    public class DbPlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _db;

        public DbPlayerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Player? Read(string number)
        {
            return _db.Players
               .Include(p => p.TeamRanks)
                  .ThenInclude(ptr => ptr.Team)
                .Include(p => p.Draft)
               .FirstOrDefault(p => p.Number == number);
        }

        public ICollection<Player> ReadAll()
        {
            return _db.Players
                .Include(p => p.TeamRanks)
                  .ThenInclude(ptr => ptr.Team)
                .Include(p => p.Draft)
               .ToList();
        }
    }
}
