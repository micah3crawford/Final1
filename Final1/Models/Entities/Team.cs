using System.ComponentModel.DataAnnotations;

namespace Final1.Models.Entities
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(1)]
        public string Code { get; set; } = String.Empty;
        public int ScheduledGames { get; set; }
        public ICollection<PlayerTeamRank> PlayerRanks { get; set; }
           = new List<PlayerTeamRank>();
    }
}
