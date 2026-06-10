using System.ComponentModel.DataAnnotations;

namespace BarraBonitaTurismo.Models
{
    public class GuideItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // Hospedagem, Gastronomia, Atividades

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Website { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public int Rating { get; set; } // 1-5
    }
}
