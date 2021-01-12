using System.ComponentModel.DataAnnotations;

namespace TournamentPlanner.Data
{
    public class Player
    {
        public int ID { get; set; }

        [MaxLength(300)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string? PhoneNumber { get; set; }
    }
}
