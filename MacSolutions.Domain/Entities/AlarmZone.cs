using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacSolutions.Domain.Entities
{
    [Table("Mac_AlarmZone")]
    public class AlarmZone
    {
        public int Id { get; set; }

        [Required]
        public required float alarmRate { get; set; }

        [Required]
        public required float percentageOutsideTarget { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}