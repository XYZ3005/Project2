using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.ConstrainedExecution;


namespace DAL
{
    public class DataAccessLayer
    {
        static string connString = "Data Source = localhost; Initial Catalog = Project2DB; Integrated Security=true;";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        public int InsertTenant(Tenants t)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_addTenant", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbComm.Parameters.AddWithValue("@Name",t.Name);
            dbComm.Parameters.AddWithValue("@Surname", t.SurName);
            dbComm.Parameters.AddWithValue("@Email", t.Email);
            dbComm.Parameters.AddWithValue("@password", t.Password);
            dbComm.Parameters.AddWithValue("@phone", t.Phone);
            dbComm.Parameters.AddWithValue("@Status", t.Status);
            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }
        public int InsertAgent(Agents a)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_addAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbComm.Parameters.AddWithValue("@Name", a.Name);
            dbComm.Parameters.AddWithValue("@Surname", a.SurName);
            dbComm.Parameters.AddWithValue("@Email", a.Email);
            dbComm.Parameters.AddWithValue("@Password", a.Password);
            dbComm.Parameters.AddWithValue("@Phone", a.Phone);
            dbComm.Parameters.AddWithValue("@Status", a.Status);
            dbComm.Parameters.AddWithValue("@AgencyID", a.AgencyID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }
        public int UpdateTenant(Tenants t)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                {
                    dbConn.Open();
                }
            }
            catch (SystemException)
            {

            }
            dbComm = new SqlCommand("sp_updateTenant", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbComm.Parameters.AddWithValue("@Surname", t.Email);
            dbComm.Parameters.AddWithValue("@Phone", t.Phone);
            dbComm.Parameters.AddWithValue("@Status", t.Status);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }

        public int UpdateAgent(Agents a)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                {
                    dbConn.Open();
                }
            }
            catch (SystemException)
            {

            }
            dbComm = new SqlCommand("sp_updateAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbComm.Parameters.AddWithValue("@Surname", a.Email);
            dbComm.Parameters.AddWithValue("@Phone", a.Phone);
            dbComm.Parameters.AddWithValue("@Status", a.Status);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteAgent(Agents a)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_DeleteAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TenatID", a.AgentID);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteTenat(Tenants t)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_DeleteTenat", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgentID", t.TenatID);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable TenantDisplay()
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_TenantDisplay", dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            dbConn.Close();
            return dt;
        }
        public DataTable AgentDisplay()
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_AgentDisplay", dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            dbConn.Close();
            return dt;
        }
        public DataTable AgencylType()
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_AgencyType", dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            dbConn.Close();
            return dt;
        }
    }
}
