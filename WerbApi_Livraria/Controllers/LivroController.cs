using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WerbApi_Livraria.Dtos.Autor;
using WerbApi_Livraria.Dtos.Livro;
using WerbApi_Livraria.Models;
using WerbApi_Livraria.Services.Autor;
using WerbApi_Livraria.Services.Livro;

namespace WerbApi_Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("GetAllLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> GetAllLivros()
        {
            var livros = await _livroInterface.GetAllLivros();
            return Ok(livros);

        }

        [HttpGet("GetLivroId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> GetlivroId(int idLivro)
        {
            var livro = await _livroInterface.GetLivroId(idLivro);
            return Ok(livro);

        }


        [HttpGet("GetAutorByIdLivro/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> GetLivroByIdAutor(int idAutor)
        {
            var livro = await _livroInterface.GetLivroByIdAutor(idAutor);
            return Ok(livro);

        }

        [HttpPost("CreateLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CreateLivro(CreateLivroDto createLivroDto)
        {
            var livros = await _livroInterface.CreateLivro(createLivroDto);
            return Ok(livros);
        }

        [HttpPut("EditLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditLivro(EditLivroDto editLivroDto)
        {
            var livros = await _livroInterface.EditLivro(editLivroDto);
            return Ok(livros);
        }

        [HttpDelete("DeleteLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> DeleteLivro(int idLivro)
        {
            var livros = await _livroInterface.DeleteLivro(idLivro);
            return Ok(livros);
        }
    }
}
