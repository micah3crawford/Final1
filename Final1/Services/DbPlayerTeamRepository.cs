using Final1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final1.Services
{
    public class DbPlayerTeamRepository : IPlayerTeamRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IPlayerRepository _playerRepo;
        private readonly ITeamRepository _teamRepo;

        public DbPlayerTeamRepository(
        ApplicationDbContext db,
        IPlayerRepository playerRepo, ITeamRepository teamRepo)
        {
            _db = db;
            _playerRepo = playerRepo;
            _teamRepo = teamRepo;
        }

        public PlayerTeamRank? Read(int id)
        {
            return _db.PlayerTeamRanks
               .Include(ptr => ptr.Player)
                    .ThenInclude(p => p!.Draft)
               .Include(ptr => ptr.Team)
               .FirstOrDefault(ptr => ptr.Id == id);
        }

        public ICollection<PlayerTeamRank> ReadAll()
        {
            return _db.PlayerTeamRanks
                .Include(ptr => ptr.Player)
                    .ThenInclude(p => p!.Draft)
               .Include(ptr => ptr.Team)
               .ToList();
        }


        public PlayerTeamRank? Create(string number, int teamId)
        {
            var player = _playerRepo.Read(number);
            if (player == null)
            {
                // The student was not found
                return null;
            }
            var teamRank = player.TeamRanks
                .FirstOrDefault(ptr => ptr.TeamId == teamId);
            if (teamRank != null)
            {
                // The student already has a course grade for this course
                return null;
            }
            var team = _teamRepo.Read(teamId);
            if (team == null)
            {
                // The course was not found
                return null;
            }
            var playerTeamRank = new PlayerTeamRank
            {
                Player = player,
                Team = team
            };
            player.TeamRanks.Add(playerTeamRank);
            team.PlayerRanks.Add(playerTeamRank);
            _db.SaveChanges();
            return playerTeamRank;
        }
        public void UpdatePlayerRank(int playerTeamId, string Rank)
        {
            var playerTeam = Read(playerTeamId);
            if (playerTeam != null)
            {
                playerTeam.Rank = Rank;
                _db.SaveChanges();
            }
        }
        public void Remove(string number, int playerTeamId)
        {
            var player = _playerRepo.Read(number);
            var playerTeam = player!.TeamRanks
                .FirstOrDefault(ptr => ptr.Id == playerTeamId);
            var team = playerTeam!.Team;
            player!.TeamRanks.Remove(playerTeam);
            team!.PlayerRanks.Remove(playerTeam);
            _db.SaveChanges();
        }
    }
}
