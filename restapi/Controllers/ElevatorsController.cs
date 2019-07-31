using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly elevatorContext _context;

        public ElevatorsController(elevatorContext context) => _context = context;

        //Get:              api/elevators
        [HttpGet]
        public ActionResult<IEnumerable<elevator>> GetElevators()
        {
            return _context.elevators;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> GetString()
        // {
            // return new string[] {"this", "is", "hard", "coded"};
        // }
    }

}