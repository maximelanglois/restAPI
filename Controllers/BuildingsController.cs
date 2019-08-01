using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;
using System.Linq;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly buildingContext _context;

        public BuildingsController(buildingContext context) => _context = context;

        //Get:              api/buildings
        [HttpGet]
        public ActionResult<IEnumerable<building>> GetBuildings()
        {
            // return _context.buildings;
            var everyBuildings = _context.buildings;
            return everyBuildings;
        }

        [HttpGet("{id}")]
        public ActionResult<building> GetBuildings(int id)
        {
            var building = _context.buildings.Find(id);
            
            if (building == null)
            {
                return NotFound();
            }
            
            return building;
        }

        [HttpGet("inactive")]

        public ActionResult<IEnumerable<building>> GetBuildingWithInactive()
        {
            // var buildWithinactive = new List<building>();
            var buildWithinactive =_context.buildings;
    
            // var inactiveColumns = RedirectToAction ("GetInactiveColumns", "ColumnsController");
            // System.Diagnostics.Debug.WriteLine(inactiveColumns);




            return buildWithinactive;

        }

        

      

    }

}