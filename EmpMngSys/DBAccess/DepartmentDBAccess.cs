using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpMngSys.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using EmpMngSys.DBAccess;

namespace EmpMngSys.DBAccess
{
    public class DepartmentDBAccess
    {
        //sql object declaration

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataSet ds;
        public DepartmentDBAccess()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        //Add Department 
        public int AddDepartment(DepartModel department)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@department", department.Department);
            cmd.Parameters.AddWithValue("@contact", department.Contact);
            cmd.Parameters.AddWithValue("@manager", department.Manager);
            cmd.Parameters.AddWithValue("@checktype", 2);
            int result = cmd.ExecuteNonQuery();
            return result;


        }
    }
}