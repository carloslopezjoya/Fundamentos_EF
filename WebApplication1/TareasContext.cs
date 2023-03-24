using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class TareasContext:DbContext
    {
        public DbSet <Categoria> Categorias { get; set; }   
        public DbSet <Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p=>p.Nombre).HasColumnType("varchar").IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).HasColumnType("varchar");
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(b => b.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.HasAlternateKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).HasColumnType("varchar").IsRequired().HasMaxLength(200);
                tarea.Property(p => p.FechaCreacion).HasColumnType("Date");
                tarea.Ignore(p => p.Resumen);
                tarea.Property(p => p.Prioridad);
                //tarea.Property(p => p.Prioridad).HasColumnType("varchar").HasMaxLength(15).HasConversion(                        
                //p => p.ToString(),
                //v => (Prioridad)Enum.Parse(typeof(Prioridad), v));

            });
        }
            
    }
}
