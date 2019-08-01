using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteriesController : ControllerBase
    {
        private readonly mySQLContext _context;
        public BatteriesController(mySQLContext context) => _context = context;

        //GET:          api/commands
        [HttpGet]
        public ActionResult<IEnumerable<battery>> GetCommands()
        {
            return _context.batteries;
        }
        
        /*              TEST
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetString()
        {
            return new string[] {"This", "is", "a", "nice", "API"};
        }
        */
    }

}