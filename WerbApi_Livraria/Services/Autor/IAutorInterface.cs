using System.Globalization;
using WerbApi_Livraria.Dtos.Autor;
using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> GetAllAutores(); //Listando todos os autores
        Task<ResponseModel<AutorModel>> GetAutorId(int idAutor); //Listando autor por Id
        Task<ResponseModel<AutorModel>> GetAutorByIdLivro(int idLivro); //Buscando Autores pelo id do Livro
        Task<ResponseModel<List<AutorModel>>> CreateAutor(CreateAutorDto autorDto); //Criando um novo Autor
        Task<ResponseModel<List<AutorModel>>> EditAutor(EditAutorDto editAutorDto); //Editando um autor Existente
        Task<ResponseModel<List<AutorModel>>> DeleteAutor(int idAutor); //Excluindo um Autor pelo id
    }
}

