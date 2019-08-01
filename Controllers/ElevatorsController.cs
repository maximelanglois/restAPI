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

        [HttpGet("{id}/status")]
        public ActionResult<string> GetElevatorsStatus(int id)
        {
           var elevatorStatus = _context.elevators.Find(id).status;
           if (elevatorStatus == null)
           {
               return NotFound();
           }
           return elevatorStatus;
        }


//-------------------------------------------- TEST --------------------------------------------------
        [HttpGet("inactive")]
        public ActionResult<IEnumerable<elevator>> GetsInactiveElevator()
        {
           var elevators = _context.elevators;
           if (elevators == null)
           {
               return NotFound();
           }
           return elevators;
        }
        
    }

}