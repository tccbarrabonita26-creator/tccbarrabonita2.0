using System.ComponentModel.DataAnnotations;

namespace BarraBonitaTurismo.Models
{
    public class Attraction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } // Náutica, Cultura, Lazer, Natureza

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Schedule { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [StringLength(500)]
        public string FunFact { get; set; }
    }
}
