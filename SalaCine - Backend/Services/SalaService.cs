using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaCine___Backend.DTOs;
using SalaCine___Backend.Model;
using SalaCine___Backend.Repository;

namespace SalaCine___Backend.Services
{

    public class SalaService : ControllerBase
    {
        public SalaRepository _salaRepository;
        public SalaService(SalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }
        public async Task<ActionResult<IEnumerable<SalaCineDTO>>> Getsalas()
        {
            var salas = await _salaRepository.GetSalas();

            if (salas.Value == null)
            {
                return NotFound();
            }

            return Ok(
            salas.Value.Select(s => new
            {
                s.Id_Sala,
                s.Nombre,
                s.Estado
            })
            );
        }

        //Buscar Sala por id
        public async Task<ActionResult<IEnumerable<SalaCineDTO>>> SearchPelicula(int id)
        {
            var sala = await _salaRepository.SearchSala(id);

            if (sala == null || !sala.Any())
            {
                return NotFound("No se encontró la película.");
            }
            return Ok(sala);
        }


        //Crear Sala

        public async Task<ActionResult<SalaCineDTO>> PostSala(SalaCine sala)
        {
            var salas = await _salaRepository.PostSala(sala);

            if (salas == null || salas.Value == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear la película.");
            }

            var respons = new
            {
                mensaje = "Sala creada correctamente",
                sala = salas.Value
            };

            return CreatedAtAction(nameof(PostSala), new { nombre = salas.Value.Nombre }, respons);
        }


        //Eliminar Sala
        public async Task<ActionResult<SalaCineDTO>> DeleteSala(int id)
        {
            var sala = await _salaRepository.DeleteSala(id);
            if (sala == null)
            {
                return NotFound("No se pudo eliminar");
            }
            return Ok(new { mensaje = "Sala eliminada correctamente" });
        }


        //Editar Sala

        public async Task<ActionResult<SalaCineDTO>> PutSala(SalaCine sala)
        {
            var salas = await _salaRepository.PutSala(sala);

            if (salas == null)
            {
                return NotFound("No se pudo actualizar");
            }
            return Ok(new { mensaje = "Sala editada correctamente" });
        }

    }
}
