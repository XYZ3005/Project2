using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class BuisnessLogicLayer
    {
        DataAccessLayer dal = new DataAccessLayer();
        public int InsertAgent(Agents agent)
        {
            return dal.InsertAgent(agent);
        }
        public int UpdateAgent(Agents agent)
        {
            return dal.UpdateAgent(agent);
        }
        public int InsertTenant(Tenants tenant)
        {
            return dal.InsertTenant(tenant);
        }
        public int UpdateTenant(Tenants tenant)
        {
            return dal.UpdateTenant(tenant);
        }
        public int DeleteTenant(Tenants tenant)
        {
            return dal.DeleteTenat(tenant);
        }
        public int DeleteAgent(Agents agent)
        {
            return dal.DeleteAgent(agent);
        }
        public DataTable TenantDisplay(Tenants tenant)
        {
            return dal.TenantDisplay();
        }
        public DataTable AgentDisplay(Agents agent)
        {
            return dal.AgentDisplay();
        }
        public DataTable AgencyType()
        {
            return dal.AgencylType();
        }
    }
}
