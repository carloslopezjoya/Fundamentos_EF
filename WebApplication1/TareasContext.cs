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
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria { CategoriaId= Guid.Parse("060146b9-dce0-4649-a194-b07b9f691862"),
            Nombre="Actividades pendientes",Peso=20
            });
            categoriasInit.Add(new Categoria
            {
                CategoriaId = Guid.Parse("060146b9-dce0-4649-a194-b07b9f691865"),
                Nombre = "Actividades personales",
                Peso = 50
            });


            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p=>p.Nombre).HasColumnType("varchar").IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).HasColumnType("varchar").HasMaxLength(150).IsRequired(false);
                categoria.Property(p => p.Peso).HasColumnType("int");

                categoria.HasData(categoriasInit);// agregar datoss
            });

            List<Tarea> tareasInit = new List<Tarea>();

            tareasInit.Add(new Tarea { TareaId = Guid.Parse("060146b9-dce0-4649-a194-b07b9f691815"),
            CategoriaId= Guid.Parse("060146b9-dce0-4649-a194-b07b9f691862"),
            Prioridad = Prioridad.Baja,
            Titulo="Terminar de ver series",
            FechaCreacion=DateTime.Now
            });

            tareasInit.Add(new Tarea
            {
                TareaId = Guid.Parse("060146b9-dce0-4649-a194-b07b9f691857"),
                CategoriaId = Guid.Parse("060146b9-dce0-4649-a194-b07b9f691865"),
                Prioridad = Prioridad.Media,
                Titulo = "Pago de servicios publicos",
                FechaCreacion = DateTime.Now
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
                tarea.Property(p => p.Pendiente).HasColumnType("varchar").IsRequired(false).HasMaxLength(300);
                //tarea.Property(p => p.Prioridad).HasColumnType("varchar").HasMaxLength(15).HasConversion(                        
                //p => p.ToString(),
                //v => (Prioridad)Enum.Parse(typeof(Prioridad), v));
                tarea.HasData(tareasInit);

            });
        }
            
    }
}
