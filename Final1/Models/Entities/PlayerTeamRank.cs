using System.ComponentModel.DataAnnotations;

namespace Final1.Models.Entities
{
    public class PlayerTeamRank
    {
        public int Id { get; set; }
        [StringLength(2, MinimumLength = 1)]
        public string Rank { get; set; } = String.Empty;

        public string PlayerNumber { get; set; } = String.Empty;
        public Player? Player { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }

}
