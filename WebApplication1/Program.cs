using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication1;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<TareasContext>(opt => opt.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareasSecret"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory()+ " Base de datos en server: " +dbContext.Database.IsSqlServer());
        


    });

app.MapGet("api/tareas", async ([FromServices] TareasContext dbContext) =>
 {
     return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria).Where(p=>p.Prioridad==Prioridad.Baja && p.Categoria.Peso==50));
 });


app.MapPost("api/categoria", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria ) =>
{
    categoria.CategoriaId = Guid.NewGuid();
    categoria.Nombre = "Mejorando";
    categoria.Descripcion = "Prueba";
    categoria.Peso = 30;
    await dbContext.AddAsync(categoria);
    //await dbContext.Categorias.AddAsync(categoria);
    await dbContext.SaveChangesAsync();

    return Results.Ok();

});

app.MapPut("api/categoria/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria, [FromRoute] Guid id) =>
{
    var categoriaActual= dbContext.Categorias.Find(id);
    if (categoriaActual != null)
    {
        categoria.Nombre = "Editado";
        categoria.Descripcion = "Editado";
        categoria.Peso = 50;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
  
    
    //await dbContext.Categorias.AddAsync(categoria);
   

    return Results.NotFound();

});

app.MapDelete("api/categoria/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) => {

    var categoriaActual = dbContext.Categorias.Find(id); // buscar registro actual


    if (categoriaActual != null)
    {
        dbContext.Remove(categoriaActual);

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
