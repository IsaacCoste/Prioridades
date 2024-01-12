using System.ComponentModel.DataAnnotations;

namespace Practica_Prioridades.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "Debe Completar")]
        public string? Descripción { get; set; }
        public int DiasCompromiso { get; set; }
    }
}
