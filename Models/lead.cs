using System;
using System.Reflection.Metadata;
using System.Data.SqlTypes;
namespace restapi.Models
{
    public class lead
    {
        public int id {get; set;}
        public string full_name {get; set;}
        public string company_name {get; set;}
        public string email {get; set;}
        public string phone {get; set;}
        public string project_name {get; set;}
        public string project_description {get; set;}
        public string department {get; set;}
        public string message {get; set;}
        // public Blob attachment_file {get; set;}
        public DateTime creation_date {get; set;}


    }
}