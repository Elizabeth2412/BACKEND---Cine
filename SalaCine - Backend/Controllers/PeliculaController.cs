using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.Model;
using SalaCine___Backend.Services;

namespace SalaCine___Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PeliculaController : ControllerBase
    {
        public readonly PeliculaService _peliculaService;
        public PeliculaController(PeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> ListarPeliculas()
        {
            var peliculas = await _peliculaService.GetPeliculas();

            if (peliculas.Value == null)
            {
                return NotFound("No se encontraron películas");
            }

            return Ok(
            peliculas.Value.Select(p => new
            {
                p.Id_Pelicula,
                p.Nombre,
                p.Duracion
            })
            );
            
        }

        [HttpPost]
        public async Task<ActionResult<Pelicula>> CrearPelicula([FromBody] Pelicula pelicula)
        {
            await _peliculaService.PostPelicula(pelicula);

            return StatusCode(StatusCodes.Status201Created, pelicula);
        }

        [HttpPut]
        public async Task<ActionResult<Pelicula>> ActualizarPelicula([FromBody] Pelicula pelicula)
        {
            var peliculatualiza = await _peliculaService.PutPelicula(pelicula);

            if (peliculatualiza == null)
            {
                return NotFound("No se pudo actualizar");
            }
            return NoContent();
        }

        [HttpGet("buscar/nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Pelicula>>> BuscarPeliculas(string nombre)
        {
            var pelicula = await _peliculaService.SearchPelicula(nombre);

            if (pelicula == null)
            {
                return NotFound("No se encontró la película");
            }
            return StatusCode(StatusCodes.Status200OK, pelicula);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pelicula>> BorrarPelicula(int id)
        {
            var pelicula = await _peliculaService.DeletePelicula(id);
            if (pelicula == null)
            {
                return NotFound("No se pudo eliminar");
            }
            return NoContent();
        }

    }
}
