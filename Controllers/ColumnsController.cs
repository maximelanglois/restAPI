using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;
using System.Linq;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly mySQLContext _context;

        public ColumnsController(mySQLContext context) => _context = context;

        //Get:              api/columns
        [HttpGet]
        public ActionResult<IEnumerable<column>> GetColumns()
        {
            // return _context.columns;
            var everyColumns = _context.columns;
            return everyColumns;
        }

        [HttpGet("{id}")]
        public ActionResult<column> GetColumns(int id)
        {
            var column = _context.columns.Find(id);
            
            if (column == null)
            {
                return NotFound();
            }
            
            return column;
        }

        [HttpGet("inactive")]
        public ActionResult<IEnumerable<column>> GetInactiveColumns()
        {
            var inactiveColumns = _context.columns.Where(c => (c.status != "active")).ToList();
     
            if (inactiveColumns == null)
            {
                return NotFound();
            }
            
            return inactiveColumns;
        }

        [HttpGet("{id}/status")]
        public ActionResult<string> GetColumnStatus(int id)
        {
            var columnStatus = _context.columns.Find(id).status;       
            if (columnStatus == null)
            {
                return NotFound();
            }           
            return "Status is : '" + columnStatus + "' on column ID : " + id ;
        }

        [HttpPut("{id}/status")]
        public string PutStatus(int id,[FromBody] string status)
        {            
            var column = _context.columns.Find(id);
            column.status = status;
            _context.SaveChanges();
            return "Status changed to : '" + status + "' on column ID : " + id ;
        }        
    }
}