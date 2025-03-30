using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.Model;
using System.Globalization;

namespace SalaCine___Backend.Repository
{
    public class salaSalaCineRepository(DbCineContext context) : ControllerBase
    {
        public readonly DbCineContext _context = context;

        public async Task<IEnumerable<PeliculaSalacine>> SearchsalaFecha(DateOnly fechapublicacion)
        {
            //DateOnly fecha = DateOnly.FromDateTime(fechapublicacion);
            return await _context.PeliculaSalacines.FromSqlRaw("EXEC sp_buscarpeliculafecha @fechapublicacion = {0}", fechapublicacion).ToListAsync();
        }

        public async Task<IEnumerable<PeliculaSalacine>> SearchMovieTheaterWithCondition(string nombre)
        {
            var searchMovieTheater = await _context.PeliculaSalacines.FromSqlRaw("EXEC sp_buscarsalacine @nombresala = {0}", nombre).ToListAsync();
            return searchMovieTheater;
        }
    }
}
