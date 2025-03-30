using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        

        public async Task<ActionResult<IEnumerable<SalaCine>>> GetSalas()
        {
            return await _context.SalaCines.FromSqlRaw("EXEC sp_listarsala").ToListAsync();
        }

    }
}

