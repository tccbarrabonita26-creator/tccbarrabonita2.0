using System.ComponentModel.DataAnnotations;

namespace BarraBonitaTurismo.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Assunto é obrigatório")]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mensagem é obrigatória")]
        [StringLength(1000)]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
