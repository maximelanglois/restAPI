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

        [HttpGet("inactive")]

        public ActionResult<IEnumerable<building>> GetBuildingWithInactive()
        {
            var buildWithinactive = new List<building>();

            var buildingIdList = new List<int>();
            var inactiveBatteries =_context.batteries.Where(b => b.status != "active");
            var inactiveColumns =_context.columns.Where(c => c.status != "active");
            // var inactiveColumnsIds = inactiveColumns.Select(c => c.id).ToArray();
            // var inactiveElevators =_context.elevators.Where(e => e.status != "active" && !inactiveColumnsIds.Contains(e.column_id));
            
            var inactiveElevators =_context.elevators.Where(e => e.status != "active");
    
            // Get Building Id from inactive batteries

            foreach (var b in inactiveBatteries)
            {
                var build_id = b.building_id;
                buildingIdList.Add(build_id);
            }   
            
            // Get Building Id from inactive columns

            var temp_col_build_id =  from battery in _context.batteries
                                     join c in inactiveColumns on battery.id equals c.battery_id into gj
                                     from subCol in gj
                                     select battery.building_id;

            var col_build_id_list = temp_col_build_id.ToList();

            buildingIdList.AddRange(col_build_id_list);

            // Get Building Id from inactive elevators

            var temp_elev_bat_id =  from column in _context.columns
                                    join e in inactiveElevators on column.id equals e.column_id into gj
                                    from subElev in gj
                                    select column.battery_id;

                        //var elev_bat_id = temp_elev_bat_id.ToList();

            
            var temp_elev_build_id = from battery in _context.batteries
                                     join c in inactiveColumns on battery.id equals c.battery_id into gj
                                     from subCol in gj
                                     select battery.building_id;




            var elev_build_id_list = temp_elev_build_id.ToList();

            buildingIdList.AddRange(elev_build_id_list);              
            


            // Get Inactive building list from bulding ids

            foreach (var id in buildingIdList)
            {
                var tempBuild = _context.buildings.Find(id);
                buildWithinactive.Add(tempBuild);
                
            }


            // var inactiveColumns =_context.columns.Where(c => (c.status != "active"));
            // var inactiveElevators =_context.elevators.Where(c => (c.status != "active"));



            return buildWithinactive;

        }

        

      

    }

}