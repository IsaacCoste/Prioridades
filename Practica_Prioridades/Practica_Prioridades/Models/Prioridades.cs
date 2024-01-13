using System.ComponentModel.DataAnnotations;

namespace Practica_Prioridades.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "Debe Completar")]
        public string? Descripción { get; set; }
        [Range(1, 31, ErrorMessage = "Solo Dias del 1 hasta 31")]
        public int DiasCompromiso { get; set; }
    }
}
