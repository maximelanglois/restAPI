using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly mySQLContext _context;

        public ElevatorsController(mySQLContext context) => _context = context;

        //Get:              api/elevators
        [HttpGet]
        public ActionResult<IEnumerable<elevator>> GetElevators()
        {
            return _context.elevators;
        }

        [HttpGet("{id}")]
        public ActionResult<elevator> GetElevators(int id)
        {
            var elevator = _context.elevators.Find(id);
            
            if (elevator == null)
            {
                return NotFound();
            }
            return elevator;
        }
    }

}