using Final1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerTeamAPIController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly ITeamRepository _teamRepo;
        private readonly IPlayerTeamRepository _playerTeamRepo;

        public PlayerTeamAPIController(IPlayerRepository playerRepo, ITeamRepository teamRepo, IPlayerTeamRepository playerTeamRepo)
        {
            _playerRepo = playerRepo;
            _teamRepo = teamRepo;
            _playerTeamRepo = playerTeamRepo;
        }

        [HttpPost("create")]
        public IActionResult Post([FromForm] string Number, [FromForm] int teamId)
        {
            var playerTeamRank = _playerTeamRepo.Create(Number, teamId);
            // Remove the circular reference for the JSON
            playerTeamRank?.Player?.TeamRanks.Clear();
            playerTeamRank?.Team?.PlayerRanks.Clear();
            return CreatedAtAction("Get",
                new { id = playerTeamRank?.Id }, playerTeamRank);
        }

        [HttpPut("assignrank")]
        public IActionResult Put(
            [FromForm] string Number,
            [FromForm] int playerTeamId,
            [FromForm] string Rank)
        {
            _playerTeamRepo.UpdatePlayerRank(playerTeamId, Rank);
            return NoContent(); // 204 as per HTTP specification
        }

        [HttpDelete("remove")]
        public IActionResult Delete(
            [FromForm] string Number,
            [FromForm] int playerTeamId)
        {
            _playerTeamRepo.Remove(Number, playerTeamId);
            return NoContent(); // 204 as per HTTP specification
        }

        [HttpGet("playerrankreport")]
        public IActionResult Get()
        {
            var players = _playerRepo.ReadAll();
            var playerTeamRanks =
                _playerTeamRepo.ReadAll();
            var model = from p in players
                        join ptr in playerTeamRanks
                            on p.Number equals ptr.PlayerNumber
                        orderby p.LastName, p.FirstName
                        select new
                        {
                            PlayerName = p.FirstName + " " + p.LastName,
                            TeamFullCode = ptr.Team!.Code,
                            ptr.Rank
                        };

            return Ok(model);
        }
    }
}
