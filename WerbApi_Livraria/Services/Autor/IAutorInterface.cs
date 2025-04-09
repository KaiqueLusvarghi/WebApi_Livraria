using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> GetAllAutores(); //Listando todos os autores
        Task<ResponseModel<AutorModel>> GetAutorId(int idAutor); //Listando autor por Id
        Task<ResponseModel<AutorModel>> GetLivroId (int idLivroId); //Buscando Autores pelo id do Livro
    }
}
