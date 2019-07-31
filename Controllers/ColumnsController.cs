using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly columnContext _context;

        public ColumnsController(columnContext context) => _context = context;

        //Get:              api/columns
        [HttpGet]
        public ActionResult<IEnumerable<column>> GetColumns()
        {
            return _context.columns;
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
    }

}