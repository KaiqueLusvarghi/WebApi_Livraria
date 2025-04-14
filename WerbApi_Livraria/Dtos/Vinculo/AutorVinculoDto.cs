using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Dtos.Vinculo
{
    public class AutorVinculoDto //Criado para quando formos criar um livro ou editar, ele não entre em AutorModel que dentro dele esta um coleção de livros,
                                 //e ai quando fizemos a reaquisição, ele não de o erro de que não estamos preenchendo a coleção de livros
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
