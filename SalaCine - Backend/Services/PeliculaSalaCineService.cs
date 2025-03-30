using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaCine___Backend.Model;
using SalaCine___Backend.Repository;

namespace SalaCine___Backend.Services
{
    public class salaSalaCineService(salaSalaCineRepository salasalacineRepository) : ControllerBase
    {
        //Buscar sala por fecha
        public salaSalaCineRepository _salasalacineRepository = salasalacineRepository;

        public async Task<IEnumerable<PeliculaSalacine>> SearchsalaFecha(DateOnly fechapublicacion)
        {
            return await _salasalacineRepository.SearchsalaFecha(fechapublicacion);
        }

        // Buscar sala por nombre de sala de cine
        public async Task<IEnumerable<PeliculaSalacine>> SearchMovieTheaterWithCondition(string nombre)
        {
            return (IEnumerable<PeliculaSalacine>)await _salasalacineRepository.SearchMovieTheaterWithCondition(nombre);
        }
    }
}
