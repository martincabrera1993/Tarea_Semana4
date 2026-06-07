using System.ComponentModel.DataAnnotations;

namespace Tarea_Semana4.Models
{
    public class EstudianteModel
    {
        [Key]
        [Required(ErrorMessage = "El Id es obligatorio")]
        public int EstudianteId { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Email es obligatorio")]
        public int Email { get; set; }
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        [MaxLength(10, ErrorMessage = "El Telefono no puede tener más de 10 dígitos")]
        public int Telefono { get; set; }
       
       

    }
}
