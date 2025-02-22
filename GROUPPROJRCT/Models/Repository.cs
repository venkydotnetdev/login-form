using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace GROUPPROJRCT.Models
{
    public class Repository
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
        public void AddUser(ModelClass obj)
        {
            SqlConnection com = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("proc_add", com);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", obj.username);
            cmd.Parameters.AddWithValue("@password", obj.password);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public List<ModelClass> GetAllUsers()
        {
            SqlConnection com = new SqlConnection(constr);
            List<ModelClass> obj = new List<ModelClass>();
            SqlCommand cmd = new SqlCommand("proc_view", com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            com.Open();
            da.Fill(dt);
            com.Close();

            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new ModelClass()
                {
                    username = Convert.ToString(dr["username"]),
                    password = Convert.ToString(dr["password"])
                    
                });
            }
            return obj;
        }

    
        public void Registration(RegistrationModel obj)
        {
            SqlConnection com = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("proc_insert", com);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            cmd.Parameters.AddWithValue("@Role", obj.Role);
            cmd.Parameters.AddWithValue("@Deparmemnt", obj.Deparmemnt);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@Cource", obj.Cource);
            cmd.Parameters.AddWithValue("@Job", obj.Job);
            cmd.Parameters.AddWithValue("@Designation", obj.Designation);
            cmd.Parameters.AddWithValue("@City", obj.City);
            com.Open();
            cmd.ExecuteNonQuery();
            com.Close();
        }

        public List<RegistrationModel> GetAllUserRequests()
        {
            SqlConnection com = new SqlConnection(constr);
            List<RegistrationModel> obj = new List<RegistrationModel>();
            SqlCommand cmd = new SqlCommand("proc_view", com);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            com.Open();
            da.Fill(dt);
            com.Close();

            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new RegistrationModel()
                {
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    Email = Convert.ToString(dr["Email"]),
                    PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                    Role = Convert.ToString(dr["Role"]),
                    Deparmemnt = Convert.ToString(dr["Deparmemnt"]),
                    Password = Convert.ToString(dr["Password"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    Cource = Convert.ToString(dr["Cource"]),
                    Job = Convert.ToString(dr["Job"]),
                    Designation = Convert.ToString(dr["Designation"]),
                   City = Convert.ToString(dr["City"])
                });
            }
            return obj;
        }

    }
}