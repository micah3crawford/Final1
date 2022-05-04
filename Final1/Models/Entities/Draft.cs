using System.ComponentModel.DataAnnotations;

namespace Final1.Models.Entities
{
    public class Draft
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; } = String.Empty;

        public string PlayerNumber { get; set; } = String.Empty;
        public Player? Player { get; set; }
    }
}
