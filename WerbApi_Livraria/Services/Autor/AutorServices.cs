using Microsoft.EntityFrameworkCore;
using WerbApi_Livraria.Data;
using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Services.Autor
{
    public class AutorServices : IAutorInterface //AutorService implementam os metodos da Interface 
    {
        private readonly AppDbContext _context;

        public AutorServices(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<ResponseModel<List<AutorModel>>> GetAllAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Todos autores foram coletados !";
                return resposta;


            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> GetAutorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if(autor == null)
                {
                    resposta.Mensagem = $"Nenhum autor com o id = {idAutor} encontrado";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor Localizado com Sucesso !";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<AutorModel>> GetLivroId(int idLivroId)
        {
            throw new NotImplementedException();
        }
    }
}
