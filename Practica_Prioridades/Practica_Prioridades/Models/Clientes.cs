using System.ComponentModel.DataAnnotations;

namespace Practica_Prioridades.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string? Nombre { get; set; }
        
        [Required(ErrorMessage = "El campo Telefono es requerido")]
        public int Telefono { get; set; }
        
        [Required(ErrorMessage = "El campo Celular es requerido")]
        public int Celular { get; set; }
        
        [Required(ErrorMessage = "El campo Rnc es requerido")]
        public int Rnc { get; set; }
        
        [Required(ErrorMessage = "El campo Email es requerido")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "El campo Direccion es requerido")]
        public string? Dirección { get; set; }
    }
}
