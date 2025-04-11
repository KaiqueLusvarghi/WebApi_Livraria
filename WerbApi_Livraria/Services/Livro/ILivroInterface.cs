using WerbApi_Livraria.Dtos.Livro;
using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> GetAllLivros(); //Listando todos os Livros
        Task<ResponseModel<LivroModel>> GetLivroId(int idAutor); //Listando Livro por Id
        Task<ResponseModel<List<LivroModel>>> GetLivroByIdAutor(int idAutor); //Buscando Livros pelo id do Autor
        Task<ResponseModel<List<LivroModel>>> CreateLivro(CreateLivroDto livroDto); //Criando um novo Livro
        Task<ResponseModel<List<LivroModel>>> EditLivro(EditLivroDto editLivroDto); //Editando um Livro Existente
        Task<ResponseModel<List<LivroModel>>> DeleteLivro(int idLivro); //Excluindo um Livro pelo id
    }
}
