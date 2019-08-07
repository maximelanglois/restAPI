using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;
using System.Linq;


namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly mySQLContext _context;

        public InterventionsController(mySQLContext context) => _context = context;

        //Get:              api/interventions
        [HttpGet]
        public IEnumerable<intervention> GetInterventions()
        {
            return _context.interventions;
        }

        
        [HttpGet("pending")]  //GET: Retourne tous les interventions SANS date de début et STATUS “Pending”

         public ActionResult<IEnumerable<intervention>> GetInterventionsPending()
        {
             
            var interventionsPending = _context.interventions.Where(i => (i.intervention_status == "pending") && (i.intervention_start_date == null)).ToList();   

                      
            if (interventionsPending == null)
            {
                return NotFound();
            }
            return interventionsPending;
        }

        
        [HttpGet("{id}")]
        public ActionResult<intervention> GetInterventionsId(int id)
        {
            var intervention = _context.interventions.Find(id);
            
            if (intervention == null)
            {
                return NotFound();
            }
            return intervention;
        }

        [HttpGet("{id}/status")]
        public ActionResult<string> GetInterventionStatus(int id)
        {
           var interventionStatus = _context.interventions.Find(id).intervention_status;
           if (interventionStatus == null)
           {
               return NotFound();
           }
           return "Status is : '" + interventionStatus + "' on elevator ID : " + id ;
        }


        //PUT: Changer le statut de la demande d’intervention à “InProgress” et ajouter une date et heure de début (Timestamp)
        [HttpPut("{id}/inprogress")]
        
        public string PutStatusInprogress(int id,[FromBody] string inprogress)
        {       
            var timestamp = DateTime.Now;     
            var intervention = _context.interventions.Find(id);
            intervention.intervention_status = inprogress;
            intervention.intervention_start_date = timestamp;
            _context.SaveChanges();
            return "Status changed to : '" + inprogress + "' on intervention ID : '" + id + "' Timestamp : " + timestamp ;
        } 

        //PUT: Changer le statut de la demande d’intervention à “Completed” et ajouter une date et heure de fin (Timestamp)
        [HttpPut("{id}/completed")]
        
        public string PutStatusCompleted(int id,[FromBody] string completed)
        {            
            var timestamp = DateTime.Now;
            var intervention = _context.interventions.Find(id);
            intervention.intervention_status = completed;
            intervention.intervention_end_date = timestamp;
            _context.SaveChanges();
            return "Status changed to : '" + completed + "' on intervention ID : '" + id + "' Timestamp : " + timestamp ;
        } 

    }
}

