using System.ComponentModel;

namespace Final1.Models.ViewModels
{
    public class PlayerTeamRanksVM
    {
        [DisplayName("Number")]
        public string Number { get; set; } = String.Empty;
        [DisplayName("Full Name")]
        public string FullName { get; set; } = String.Empty;
        [DisplayName("Team and Ranks")]
        public List<string> TeamAndRanks { get; set; }
            = new List<string>();
    }
}
