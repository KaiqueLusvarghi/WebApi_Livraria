using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}