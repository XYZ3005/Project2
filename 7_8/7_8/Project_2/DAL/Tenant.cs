using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Tenants
    {
        public int TenatID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
       

        public Tenants(string name, string surname, string email, string password,string phone,string status,int tenantID)
        {
           Name = name;
           SurName = surname;
           Email = email;  
           Password = password;
           Phone = phone;
           Status = status;
           TenatID = tenantID;
            

        }
    }
}

