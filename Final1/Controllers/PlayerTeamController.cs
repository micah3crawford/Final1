using Final1.Models.ViewModels;
using Final1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final1.Controllers
{
    public class PlayerTeamController : Controller
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly ITeamRepository _teamRepo;
        private readonly IPlayerTeamRepository _playerTeamRepo;

        public PlayerTeamController(IPlayerRepository playerRepo, ITeamRepository teamRepo, IPlayerTeamRepository playerTeamRepo)
        {
            _playerRepo = playerRepo;
            _teamRepo = teamRepo;
            _playerTeamRepo = playerTeamRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create([Bind(Prefix = "id")] string Number, int teamId)
        {
            var player = _playerRepo.Read(Number);
            if (player == null)
            {
                return RedirectToAction("Index", "Player");
            }
            var team = _teamRepo.Read(teamId);
            if (team == null)
            {
                return RedirectToAction("Details", "Player", new { id = Number });
            }
            var playerTeam = player.TeamRanks
                .SingleOrDefault(ptr => ptr.TeamId == teamId);
            if (playerTeam != null)
            {
                return RedirectToAction("Details", "Player", new { id = Number });
            }
            var playerTeamVM = new PlayerTeamVM
            {
                Player = player,
                Team = team
            };
            return View(playerTeamVM);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
        public IActionResult CreateConfirmed(string Number, int teamId)
        {
            _playerTeamRepo.Create(Number, teamId);
            return RedirectToAction("Details", "Player", new { id = Number });
        }

        public IActionResult AssignRank([Bind(Prefix = "id")] string Number, int teamId)
        {
            var player = _playerRepo.Read(Number);
            if (player == null)
            {
                return RedirectToAction("Index", "Player");
            }
            var playerTeam = player.TeamRanks
                .FirstOrDefault(ptr => ptr.TeamId == teamId);
            if (playerTeam == null)
            {
                return RedirectToAction("Details", "Player", new { id = Number });
            }
            return View(playerTeam);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("AssignRank")]
        public IActionResult AssignRankConfirmed(
            string Number, int playerTeamId, string Rank)
        {
            _playerTeamRepo.UpdatePlayerRank(playerTeamId, Rank);
            return RedirectToAction("Details", "Player", new { id = Number });
        }

        public IActionResult Remove([Bind(Prefix = "id")] string Number, int teamId)
        {
            var player = _playerRepo.Read(Number);
            if (player == null)
            {
                return RedirectToAction("Index", "Player");
            }
            var playerTeam = player.TeamRanks
                .FirstOrDefault(ptr => ptr.TeamId == teamId);
            if (playerTeam == null)
            {
                return RedirectToAction("Details", "Player", new { id = Number });
            }
            return View(playerTeam);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Remove")]
        public IActionResult RemoveConfirmed(
            string Number, int playerTeamId)
        {
            _playerTeamRepo.Remove(Number, playerTeamId);
            return RedirectToAction("Details", "Player", new { id = Number });
        }
        public IActionResult PlayerRanksReport()
        {
            ViewData["Message"] = "Player Ranks Report";
            var players = _playerRepo.ReadAll();
            var playerTeamRanks =
               _playerTeamRepo.ReadAll();
            var model = from p in players
                        join prt in playerTeamRanks
                            on p.Number equals prt.PlayerNumber
                        orderby p.LastName, p.FirstName
                        select new PlayerRanksReportVM
                        {
                            PlayerName = p.FirstName + " " + p.LastName,
                            TeamFullCode = prt.Team!.Code,
                            Rank = prt.Rank
                        };
            return View(model);
        }
    }
}
