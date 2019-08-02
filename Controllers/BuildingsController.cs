using System;
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
        private readonly mySQLContext _context;

        public BuildingsController(mySQLContext context) => _context = context;

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

        [HttpGet("intervention")]

        public ActionResult<IEnumerable<building>> GetBuildingWithInactive()
        {
            var buildWithinactive = new List<building>();
            var rawBuildingIdList = new List<int>();

            var inactiveBatteries =_context.batteries.Where(b => b.status == "intervention");
            var inactiveColumns =_context.columns.Where(c => c.status == "intervention");
            var inactiveElevators =_context.elevators.Where(e => e.status == "intervention");
    
            // Get Building Id from inactive batteries

            foreach (var b in inactiveBatteries)
            {
                var build_id = b.building_id;
                rawBuildingIdList.Add(build_id);
            }   
            
            // Get Building Id from inactive columns

            var temp_col_build_id =  from battery in _context.batteries
                                     join c in inactiveColumns on battery.id equals c.battery_id into gj
                                     from subCol in gj
                                     select battery.building_id;

            var col_build_id_list = temp_col_build_id.ToList();

            rawBuildingIdList.AddRange(col_build_id_list);

            // Get Building Id from inactive elevators

            var temp_elev_bat_id =  from column in _context.columns
                                    join e in inactiveElevators on column.id equals e.column_id into gj
                                    from subElev in gj
                                    select column.battery_id;

            var batFromInactiveElevators = new List<battery>();

            foreach (var id in temp_elev_bat_id)
            {
                var tempBatteriesList = _context.batteries.Find(id);
                batFromInactiveElevators.Add(tempBatteriesList);
                
            }
            foreach (var b in batFromInactiveElevators)
            {
                var build_id = b.building_id;
                rawBuildingIdList.Add(build_id);
            } 
        
            
            var buildingIdList = rawBuildingIdList.Distinct().ToList();
            buildingIdList.Sort();



            // Get Inactive building list from bulding ids
            foreach (var id in buildingIdList)
            {
                var tempBuild = _context.buildings.Find(id);
                buildWithinactive.Add(tempBuild);
                
            }
            return buildWithinactive;

        }

        

      

    }

}