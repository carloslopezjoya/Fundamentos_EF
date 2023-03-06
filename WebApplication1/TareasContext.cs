using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class TareasContext:DbContext
    {
        public DbSet <Categoria> Categorias { get; set; }   
        public DbSet <Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options):base(options) { }
            
    }
}
