using System.ComponentModel.DataAnnotations;

namespace Practica_Prioridades.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [StringLength(30, ErrorMessage = "No Puede Exceder los 30 Caracteres")]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string? Nombre { get; set; }
        [StringLength(10, ErrorMessage = "No Puede Exceder los 10 Caracteres")]
        [Required(ErrorMessage = "El campo Telefono es requerido")]
        public string? Telefono { get; set; }
        [StringLength(10, ErrorMessage = "No Puede Exceder los 10 Caracteres")]
        [Required(ErrorMessage = "El campo Celular es requerido")]
        public string? Celular { get; set; }
        [StringLength(11, ErrorMessage = "No Puede Exceder los 11 Caracteres")]
        [Required(ErrorMessage = "El campo Rnc es requerido")]
        public string? Rnc { get; set; }
        [EmailAddress(ErrorMessage = "El email no es valido")]
        [Required(ErrorMessage = "El campo Email es requerido")]
        public string? Email { get; set; }
        [StringLength(60, ErrorMessage = "No Puede Exceder los 60 Caracteres")]
        [Required(ErrorMessage = "El campo Direccion es requerido")]
        public string? Direccion { get; set; }
    }
}
