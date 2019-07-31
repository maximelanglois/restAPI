using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly leadContext _context;

        public LeadsController(leadContext context) => _context = context;

        //GET:          api/commands
        [HttpGet]
        public ActionResult<IEnumerable<lead>> GetCommands()
        {
            return _context.leads;
        }
    
    }

}