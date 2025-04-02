using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaCine___Backend.DTOs;
using SalaCine___Backend.Model;
using SalaCine___Backend.Services;

namespace SalaCine___Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        public readonly SalaService _salaService;
        public SalaController(SalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaCineDTO>>> Listarsalas()
        {
            return await _salaService.Getsalas();
        }

        [HttpPost]
        public async Task<ActionResult<SalaCineDTO>> CrearSala([FromBody] SalaCine sala)
        {
            return await _salaService.PostSala(sala);
        }

        [HttpPut]
        public async Task<ActionResult<SalaCineDTO>> ActualizarSala([FromBody] SalaCine sala)
        {
            return await _salaService.PutSala(sala);
        }

        [HttpGet("buscar/id/{id}")]
        public async Task<ActionResult<IEnumerable<SalaCineDTO>>> BuscarSala(int id)
        {
            return await _salaService.SearchPelicula(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SalaCineDTO>> BorrarPelicula(int id)
        {
            return await _salaService.DeleteSala(id);
        }
    }
}
