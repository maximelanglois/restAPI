using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;


namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;
        public CommandsController(CommandContext context) => _context = context;

        //GET:          api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems;
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