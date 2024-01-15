using System.ComponentModel.DataAnnotations;

namespace Practica_Prioridades.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Descripción { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int DiasCompromiso { get; set; }
    }
}
