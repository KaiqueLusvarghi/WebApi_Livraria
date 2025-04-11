using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Dtos.Livro
{
    public class EditLivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public AutorModel Autor { get; set; }
    }
}
