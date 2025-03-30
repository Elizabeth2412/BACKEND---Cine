using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.Model;

namespace SalaCine___Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CineController : ControllerBase
    {
        private readonly DbCineContext _context;

        public CineController(DbCineContext context)
        {
            _context = context;
        }


    }


}
