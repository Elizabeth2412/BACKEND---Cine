using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.DTOs;
using SalaCine___Backend.Model;

namespace SalaCine___Backend.Repository
{
    public class SalaRepository : ControllerBase
    {
        public DbCineContext _context;

        public SalaRepository(DbCineContext context)
        {
            _context = context;
        }
        

        public async Task<ActionResult<IEnumerable<SalaCineDTO>>> GetSalas()
        {
            return await _context.Database.SqlQueryRaw<SalaCineDTO>("EXEC sp_listarsala").ToListAsync();
        }

        //Buscar Sala por id
        public async Task<IEnumerable<SalaCineDTO>> SearchSala(int id)
        {
            return await _context.Database.SqlQueryRaw<SalaCineDTO>("EXEC sp_buscarsala @id_sala = {0}", id).ToListAsync();

        }

        //Crear Sala
        public async Task<ActionResult<SalaCineDTO>> PostSala(SalaCine sala)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_crearsala @nombre = {0}, @estado = {1}", sala.Nombre, sala.Estado);

            if (result > 0)
            {
                return CreatedAtAction(nameof(PostSala), new { nombre = sala.Nombre }, sala);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear la sala.");
            }
        }

        //Editar Sala
        public async Task<ActionResult<SalaCineDTO>> PutSala(SalaCine sala)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_editarsala @id_sala = {0}, @nombre = {1}, @estado = {2}", sala.Id_Sala, sala.Nombre, sala.Estado);
            if (result > 0)
            {
                return Ok("Actualizado correctamente");
            }
            else
            {
                return NotFound("No se pudo actualizar la sala");
            }

        }

        //Eliminar Sala

        public async Task<ActionResult<SalaCineDTO>> DeleteSala(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_eliminarsala @id_sala = {0}", id);

            if (result > 0)
            {
                return Ok("Eliminado correctamente");
            }
            else
            {
                return NotFound("No se pudo eliminar la sala");
            }
        }

    }
}

