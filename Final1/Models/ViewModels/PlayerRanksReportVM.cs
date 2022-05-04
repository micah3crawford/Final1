using System.ComponentModel;

namespace Final1.Models.ViewModels
{
    public class PlayerRanksReportVM
    {

        [DisplayName("Player")]
        public string? PlayerName { get; set; }
        [DisplayName("Team")]
        public string? TeamFullCode { get; set; }
        [DisplayName("Rank")]
        public string? Rank { get; set; }
    }
}
