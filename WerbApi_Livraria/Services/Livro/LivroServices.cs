using Microsoft.EntityFrameworkCore;
using WerbApi_Livraria.Data;
using WerbApi_Livraria.Dtos.Autor;
using WerbApi_Livraria.Dtos.Livro;
using WerbApi_Livraria.Models;

namespace WerbApi_Livraria.Services.Livro
{
    public class LivroServices : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroServices(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<ResponseModel<List<LivroModel>>> GetAllLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Todos Livros foram coletados !";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> GetLivroId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>(); //Variavél de resposta
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = $"Nenhum Livro com o id = {idLivro} encontrado";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro Localizado com Sucesso !";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> GetLivroByIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
               var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado !";
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livros localizados";
                return resposta;

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> CreateLivro(CreateLivroDto createLivroDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
              var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id  == createLivroDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de Autor localizado !!";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = createLivroDto.Titulo,
                    Autor = autor,
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                return resposta;
                

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }
       
        public async Task<ResponseModel<List<LivroModel>>> EditLivro(EditLivroDto editLivroDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
               var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == editLivroDto.Id);

                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == editLivroDto.Autor.Id);
                
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de Autor localizado !!";
                    return resposta;
                }

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro de Livro localizado !!";
                    return resposta;
                }

                livro.Titulo = editLivroDto.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();

                return resposta;

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<LivroModel>>> DeleteLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum Livro encontrado";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync(); //Exibindo todos os Livros, menos oque foi excluido
                resposta.Mensagem = "Livro removido com sucesso !";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


    }
}
