using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Agents

    {
        public int AgentID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public int AgencyID { get; set; }
        public Agents(string name, string surname, string email, string password, string phone, string status, int agencyID, int agentID)
        {
            Name = name;
            SurName = surname;
            Email = email;
            Password = password;
            Phone = phone;
            Status = status;
            AgencyID = agencyID;
            AgentID = agentID;
        }
    }
}

