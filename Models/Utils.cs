using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LKS_Laundry_Prov_API.Models
{
    public class Utils
    {
        public static string conn = @"Data Source=asmodeus;Initial Catalog=LKS_Laundry_Prov;Integrated Security=True";

        public static DataTable getdata(SqlCommand command)
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            return data;
        }

        public int id { set; get; }
        public string name { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string phone { set; get; }
    }

    public class Model
    {
        public int idEmp { set; get; }
        public int idCust { set; get; }
        public int idPackage { set; get; }
        public int totalUnit { set; get; }
    }
}