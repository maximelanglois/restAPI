using System.Reflection.Metadata;
using System.Linq.Expressions;
using System;
namespace restapi.Models
{
    public class battery
    {
        public int id {get; set;}
        public string baterry_type {get; set;}
        public string status {get; set;}
        public DateTime commissionning {get; set;}
        public DateTime last_inspection {get; set;}
        //public blob certificate {get; set;}
        public string informations {get; set;}
        public string notes {get; set;}
        public int building_id {get; set;}
        public int column_id {get; set;}
        public int employee_id {get; set;}
    }
}