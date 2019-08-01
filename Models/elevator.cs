using System.Reflection.Metadata;
using System.Linq.Expressions;
using System;
namespace restapi.Models
{
    public class elevator
    {
        public int id {get; set;}
        public string serial_number{get; set;}
        public string model {get; set;}
        public string elevator_type {get; set;}
        public string status {get; set;}
        public DateTime commissionning {get; set;}
        public DateTime last_inspection {get; set;}
        //public Blob certificate{get; set;}
        public string infos {get; set;}
        public string notes {get; set;}
        public int column_id {get; set;}
        public int customer_id {get; set;}
    }
}