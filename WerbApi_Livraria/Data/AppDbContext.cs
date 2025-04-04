using Microsoft.EntityFrameworkCore;
using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        //Dizendo quais tabelas e modelos que as tabelas serão criadas
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }

    }
}
