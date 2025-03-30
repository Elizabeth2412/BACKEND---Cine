using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaCine___Backend.Model;
using SalaCine___Backend.Services;
using System.Linq;

namespace SalaCine___Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class salaSalaCineController : ControllerBase
    {

        public readonly salaSalaCineService _salasalacineService;
        public salaSalaCineController(salaSalaCineService salasalacineService)
        {
            _salasalacineService = salasalacineService;
        }

        [HttpGet("buscar/fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<PeliculaSalacine>>> BuscarsalaFecha(string fecha)
        {

            if (!DateOnly.TryParse(fecha, out DateOnly fechaConvertida))
            {
                return BadRequest($"El formato de fecha '{fecha}' no es válido. Use 'YYYY-MM-DD'.");
            }

            var sala = await _salasalacineService.SearchsalaFecha(fechaConvertida);

            if (sala == null)
            {
                return NotFound("No se encontró la sala");
            }

            return StatusCode(StatusCodes.Status200OK, sala);

        }

        [HttpGet("buscar/sala/{nombre}")]
        public async Task<ActionResult<IEnumerable<PeliculaSalacine>>> BuscarsalaSala(string nombre)
        {
            var sala = await _salasalacineService.SearchMovieTheaterWithCondition(nombre);
            int resul = sala.Count();

            string mensaje;

            if (resul < 3)
            {
                mensaje = "Sala Disponible";
            }
            else if (resul >= 3 && resul <= 5)
            {
                mensaje = "salas Asignadas";
            }
            else
            {
                mensaje = "Sala No Disponible";
            }
            //Console.WriteLine(mensaje);

            return Ok( new 
            {
                Mensaje = mensaje,
                TotalSalas = resul,
                Salas = sala
            });

            //return StatusCode(StatusCodes.Status200OK, sala);
        }
    }
}
