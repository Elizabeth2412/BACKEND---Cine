using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<SalaCine>>> Getsalas()
        {
            return await _salaRepository.GetSalas();

        }


    }
}
