using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.DTOs;
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
        public async Task<ActionResult<IEnumerable<PeliculaDTO>>> ListarPeliculas()
        {
            return await _peliculaService.GetPeliculas();
        }

        [HttpPost]
        public async Task<ActionResult<PeliculaDTO>> CrearPelicula([FromBody] Pelicula pelicula)
        {
            return await _peliculaService.PostPelicula(pelicula);
        }

        [HttpPut]
        public async Task<ActionResult<PeliculaDTO>> ActualizarPelicula([FromBody] Pelicula pelicula)
        {
            return await _peliculaService.PutPelicula(pelicula); 
        }

        [HttpGet("buscar/nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<PeliculaDTO>>> BuscarPeliculas(string nombre)
        {
            return await _peliculaService.SearchPelicula(nombre);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PeliculaDTO>> BorrarPelicula(int id)
        {
            return await _peliculaService.DeletePelicula(id);           
        }

    }
}
