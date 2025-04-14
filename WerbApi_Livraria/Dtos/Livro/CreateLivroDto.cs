using WerbApi_Livraria.Dtos.Vinculo;
using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Dtos.Livro
{
    public class CreateLivroDto
    {
        public string Titulo { get; set; }

        public AutorVinculoDto Autor { get; set; }
    }
}
