using System.ComponentModel.DataAnnotations;

namespace BarraBonitaTurismo.Models
{
    public class ContactMessage
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Assunto é obrigatório")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mensagem é obrigatória")]
        [StringLength(1000)]
        public string Message { get; set; }
    }
}