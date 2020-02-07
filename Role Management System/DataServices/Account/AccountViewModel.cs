using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Role_Management_System.DataServices.Account
{
    public class AccountViewModel
    {
        public  List<SelectListItem> GetRoles(int RoleId)
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Auth"].ConnectionString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("RoleManagement",conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("RoleId", RoleId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        SelectListItem item = new SelectListItem();
                        item.Value = reader["RoleName"].ToString();
                        item.Text = reader["RoleName"].ToString();
                        roles.Add(item);
                    }
                }
            }
            return roles;
        }
    }
}