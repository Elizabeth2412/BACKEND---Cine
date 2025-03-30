using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<SalaCine>>> Listarsalas()
        {
            var salas = await _salaService.Getsalas();

            if (salas.Value == null)
            {
                return NotFound();
            }

            return Ok(
            salas.Value.Select(s => new
            {
                s.IdSala,
                s.Nombre,
                s.Estado
            })
            );
        }
    }
}
