using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WerbApi_Livraria.Data;
using WerbApi_Livraria.Dtos.Autor;
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

        public async Task<ResponseModel<AutorModel>> GetAutorByIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try 
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if(livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado !";
                    return resposta;
                }
                resposta.Dados = livro?.Autor;
                resposta.Mensagem = "Autor localizado";
                return resposta;
                
            }catch(Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
           
        }

        public async Task<ResponseModel<List<AutorModel>>> CreateAutor(CreateAutorDto createAutorDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try {
                var autor = new AutorModel() //entrando no Dto para apenas preencher os campos nome e sobrenome 
                {
                    Nome = createAutorDto.Nome,
                    Sobrenome = createAutorDto.Sobrenome,
                };
                _context.Add(autor); //Entrando no banco e add um autor 
                await _context.SaveChangesAsync(); //salvando informações no banco

                resposta.Dados = await _context.Autores.ToListAsync(); //retornando a lista de autores com o novo autor criado]
                resposta.Mensagem = "Autor criado com Sucesso !!";
                return resposta;
                
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditAutor(EditAutorDto editAutorDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == editAutorDto.Id); //entrando no Dto para apenas preencher os campos id, nome e sobrenome 
               
                    if (autor == null)
                    {
                    resposta.Mensagem = "Nenhum Autor encontrado";
                    return resposta;
                    }
                    autor.Nome = editAutorDto.Nome;
                    autor.Sobrenome = editAutorDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync(); //salvando informações no banco

                resposta.Dados = await _context.Autores.ToListAsync(); //retornando a lista de autores com o autor editado
                resposta.Mensagem = "Autor editado com Sucesso !";
                return resposta;

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }

        }

        public async Task<ResponseModel<List<AutorModel>>> DeleteAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum Autor encontrado";
                    return resposta;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync(); 

                resposta.Dados = await _context.Autores.ToListAsync(); //Exibindo todos os autores, menos oque foi excluido
                resposta.Mensagem = "Autor removido com sucesso !";
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
