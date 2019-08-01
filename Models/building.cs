namespace restapi.Models
{
    public class building
    {
        public int id {get; set;}
        public string admin_name {get; set;}
        public string admin_email{get; set;}
        public string admin_phone {get; set;}
        public string name_service_contact {get; set;}
        public string email_service_contact {get; set;}
        public string phone_service_contact {get; set;}
        public int address_id {get; set;}
        public int customer_id {get; set;}
        public int battery_id {get; set;}

    }
    }