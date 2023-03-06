using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }  /// todas las tareas relacionadas a una categoria
    }
}
