using Final1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final1.Controllers
{
    public class TeamController : Controller
    {
        private IPlayerRepository _playerRepo;
        private readonly ITeamRepository _teamRepo;

        public TeamController(IPlayerRepository playerRepo, ITeamRepository teamRepo)
        {
            _playerRepo = playerRepo;
            _teamRepo = teamRepo;
        }

        public IActionResult Assigned([Bind(Prefix = "id")] string playerId)
        {
            var player = _playerRepo.Read(playerId);
            if (player == null)
            {
                return RedirectToAction("Index", "Player");
            }
            var allTeams = _teamRepo.ReadAll();
            var teamsAssigned = player.TeamRanks
                .Select(ptd => ptd.Team).ToList();
            var teamsNotAssigned = allTeams.Except(teamsAssigned);
            ViewData["Player"] = player;
            return View(teamsNotAssigned);
        }
    }
}
