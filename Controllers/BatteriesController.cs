using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
        
        [HttpGet("{id}")]
        public ActionResult<battery> GetBatteries(int id)
        {
            var battery = _context.batteries.Find(id);
            
            if (battery == null)
            {
                return NotFound();
            }
            return battery;
        }

        [HttpGet("{id}/status")]
        public ActionResult<string> GetBatteryStatus(int id)
        {
           var batteryStatus = _context.batteries.Find(id).status;
           if (batteryStatus == null)
           {
               return NotFound();
           }
           return batteryStatus;
        }


        [HttpPut("{id}/status")]
        public string Put1(int id,[FromBody] string status)
        {            
            var battery = _context.batteries.Find(id);
            battery.status = status;
            _context.SaveChanges();
            return "Status changed to : '" + status + "' on battery ID : " + id ;
        }

    }

}