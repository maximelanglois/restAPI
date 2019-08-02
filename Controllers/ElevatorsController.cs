using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;
using System.Linq;


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


        [HttpGet("inactive")]
        public ActionResult<IEnumerable<elevator>> GetInactiveElevators()
        {
            var inactiveElevators = _context.elevators.Where(e => (e.status != "active")).ToList();
            if (inactiveElevators == null)
            {
                return NotFound();
            }           
            return inactiveElevators;
        }
        
        [HttpGet("{id}/status")]
        public ActionResult<string> GetElevatorsStatus(int id)
        {
           var elevatorStatus = _context.elevators.Find(id).status;
           if (elevatorStatus == null)
           {
               return NotFound();
           }
           return "Status is : '" + elevatorStatus + "' on elevator ID : " + id ;
        }
      
        [HttpPut("{id}/status")]
        public string PutStatus(int id,[FromBody] string status)
        {            
            var elevator = _context.elevators.Find(id);
            elevator.status = status;
            _context.SaveChanges();
            return "Status changed to : '" + status + "' on elevator ID : " + id ;
        }    
    }
}