using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WerbApi_Livraria.Dtos.Autor;
using WerbApi_Livraria.Models;
using WerbApi_Livraria.Services.Autor;

namespace WerbApi_Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("GetAllAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> GetAllAutores()
        {
            var autores = await _autorInterface.GetAllAutores();
            return Ok(autores);

        }

        [HttpGet("GetAutorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> GetAutorId(int idAutor)
        {
            var autor = await _autorInterface.GetAutorId(idAutor);
            return Ok(autor);

        }


        [HttpGet("GetAutorByIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> GetAutorByIdLivro(int idLivro)
        {
            var autor = await _autorInterface.GetAutorByIdLivro(idLivro);
            return Ok(autor);

        }

        [HttpPost("CreatNewAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CreatNewAutor(CreateAutorDto createAutorDto)
        {
            var autores = await _autorInterface.CreateAutor(createAutorDto);
            return Ok(autores);
        }
        
        
        [HttpPut("EditAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditAutor(EditAutorDto editAutorDto)
        {
            var autores = await _autorInterface.EditAutor(editAutorDto);
            return Ok(autores);
        }

        [HttpDelete("DeleteAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> DeleteAutor(int idAutor)
        {
            var autores = await _autorInterface.DeleteAutor(idAutor);
            return Ok(autores);
        }




    }

    
}