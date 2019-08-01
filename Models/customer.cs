using System;
namespace restapi.Models
{
    public class customer
    {
        public int id {get; set;}
        public DateTime creation_date {get; set;}
        public string business_name {get; set;}
        public string contact_name {get; set;}
        public string contact_phone {get; set;}
        public string email_contact {get; set;}
        public string business_description {get; set;}
        public string name_service_contact {get; set;}
        public string phone_service_contact {get; set;}
        public string email_service_contact {get; set;}
        public int user_id {get; set;}
        public int address_id {get; set;}


    }
}

