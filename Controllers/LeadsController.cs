using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;
using System.Linq;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly mySQLContext _context;

        public LeadsController(mySQLContext context) => _context = context;

        //GET:          api/commands
        [HttpGet]
        public ActionResult<IEnumerable<lead>> GetCommands()
        {
            return _context.leads;
        }
        [HttpGet("{id}")]
        public ActionResult<lead> GetLeads(int id)
        {
            var lead = _context.leads.Find(id);
            
            if (lead == null)
            {
                return NotFound();
            }
            return lead;
        }

        [HttpGet("30days")]
        public ActionResult<IEnumerable<lead>> CheckLeadsCustomers(int id)
        {
            var leadsNotCustomers = new List<lead>();
            DateTime nowMinus30Days = DateTime.Now.AddDays(-30);
            var recentLeads =_context.leads.Where(l => l.creation_date > nowMinus30Days);

            var leadIsNotCustomers =
                            from l in recentLeads
                            where !(from c in _context.customers
                            select c.email_contact)
                            .Contains(l.email)
                            select l;
                
            

            if (leadIsNotCustomers == null)
            {
                return NotFound();
            }
            return leadIsNotCustomers.ToList();
        }
    
    }

}