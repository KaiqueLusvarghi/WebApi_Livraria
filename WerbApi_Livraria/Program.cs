using Microsoft.EntityFrameworkCore;
using WerbApi_Livraria.Data;
using WerbApi_Livraria.Services.Autor;
using WerbApi_Livraria.Services.Livro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAutorInterface, AutorServices>(); //Dizendo que a os metodos da IAutorService estão sendo imlementados por AutorServices
builder.Services.AddScoped<ILivroInterface, LivroServices>(); //Dizendo que a os metodos da ILivroService estão sendo imlementados por LivroServices


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
