using System.ComponentModel.DataAnnotations;

namespace Practica_Prioridades.Models
{
    public class Sistemas
    {
        [Key]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int SistemasId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [RegularExpression(@"^[A-Za-z0-9\s]*$", ErrorMessage = "El nombre del sistema solo puede contener letras, números y espacios")]
        public string? SistemaNombre { get; set; }
    }
}
