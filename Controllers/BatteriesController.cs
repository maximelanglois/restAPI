using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteriesController : ControllerBase
    {
        private readonly batteryContext _context;
        public BatteriesController(batteryContext context) => _context = context;

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
    }

}