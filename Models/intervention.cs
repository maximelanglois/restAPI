using System.Reflection.Metadata;
using System.Linq.Expressions;
using System;
namespace restapi.Models
{
    public class intervention
    {
        public int id {get; set;}
        public DateTime? intervention_start_date {get; set;}
        public DateTime? intervention_end_date {get; set;}
        public string intervention_result {get; set;}
        public string intervention_report {get; set;}
        public string intervention_status {get; set;}
        public int employee_id {get; set;}
        public int building_id {get; set;}
        public int? battery_id {get; set;}
        public int? column_id {get; set;} 
        public int? elevator_id {get; set;} 
        public int? author {get; set;}
        public int customer_id {get; set;}
    }
}