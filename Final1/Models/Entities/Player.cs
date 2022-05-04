using System.ComponentModel.DataAnnotations;

namespace Final1.Models.Entities
{
    public class Player
    {
        [Key, StringLength(1)]
        public string Number { get; set; } = String.Empty;
        [StringLength(32)]
        public string FirstName { get; set; } = String.Empty;
        [StringLength(32)]
        public string LastName { get; set; } = String.Empty;
        public ICollection<PlayerTeamRank> TeamRanks { get; set; } = new List<PlayerTeamRank>();

        public Draft? Draft { get; set; }

    }
}
