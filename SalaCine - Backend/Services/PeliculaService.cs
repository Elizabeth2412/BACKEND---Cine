using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaCine___Backend.DTOs;
using SalaCine___Backend.Model;
using SalaCine___Backend.Repository;

namespace SalaCine___Backend.Services
{
    public class PeliculaService : ControllerBase
    {
        public PeliculaRepository _peliculaRepository;

        public PeliculaService(PeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }


        //Listar Peliculas
        public async Task<ActionResult<IEnumerable<PeliculaDTO>>> GetPeliculas()
        {
            var peliculas = await _peliculaRepository.GetPeliculas();

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

        //Buscar Pelicula por nombre
        public async Task<ActionResult<IEnumerable<PeliculaDTO>>> SearchPelicula(string nombre)
        {
            var pelicula =  await _peliculaRepository.SearchPelicula(nombre);

            if (pelicula == null || !pelicula.Any())
            {
                return NotFound("No se encontró la película.");
            }
            return Ok(pelicula);
        }


        //Crear Pelicula

        public async Task<ActionResult<PeliculaDTO>> PostPelicula(Pelicula pelicula)
        {
            var peliculas = await _peliculaRepository.PostPelicula(pelicula);

            if (peliculas == null || peliculas.Value == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear la película.");
            }

            var respons = new
            {
                mensaje = "Película creada correctamente",
                pelicula = peliculas.Value
            };

             return CreatedAtAction(nameof(PostPelicula), new { nombre = peliculas.Value.Nombre }, respons);
        }


        //Eliminar Pelicula
        public async Task<ActionResult<PeliculaDTO>> DeletePelicula(int id)
        {
            var pelicula = await _peliculaRepository.DeletePelicula(id);
            if (pelicula == null)
            {
                return NotFound("No se pudo eliminar");
            }
            return Ok(new { mensaje = "Película eliminada correctamente" });
        }


        //Editar Pelicula

        public async Task<ActionResult<PeliculaDTO>> PutPelicula(Pelicula pelicula)
        {
            var peliculas = await _peliculaRepository.PutPelicula(pelicula);

            if (peliculas == null)
            {
                return NotFound("No se pudo actualizar");
            }
            return Ok(new { mensaje = "Película editada correctamente" });
        }



        
    }
}
