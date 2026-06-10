using System.ComponentModel.DataAnnotations;

namespace BarraBonitaTurismo.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public bool IsFeatured { get; set; }

        [StringLength(50)]
        public string EventType { get; set; } // Cultural, Esportivo, Gastronômico, Religioso
    }
}
