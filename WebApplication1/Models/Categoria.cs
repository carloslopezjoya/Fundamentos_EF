using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Categoria
    {
        //[Key]
        public Guid CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Peso { get; set; }
        [JsonIgnore] // al llamar los datos no nos tra la colección de tareas
        public virtual ICollection<Tarea> Tareas { get; set; }  /// todas las tareas relacionadas a una categoria
    }
}
