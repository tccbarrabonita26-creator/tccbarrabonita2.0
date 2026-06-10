using System.ComponentModel.DataAnnotations;

namespace BarraBonitaTurismo.Models
{
    public class FAQ
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public int Order { get; set; }
    }
}
