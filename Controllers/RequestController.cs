using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LKS_Laundry_Prov_API.Models;

namespace LKS_Laundry_Prov_API.Controllers
{
    public class RequestController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        SqlCommand command;
        SqlDataReader reader;
        int idTrans, price;

        [HttpPost]
        public string[] post(Model m)
        {
            command = new SqlCommand("insert into header_Transaction values(" + m.idEmp + ", " + m.idCust + ", getdate(), null", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            command = new SqlCommand("select top(1) id_header_Transaction from header_transaction order by id_header_Transaction desc", connection);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            idTrans = reader.GetInt32(0);
            connection.Close();

            command = new SqlCommand("select top(1) price_package from package order by id_package desc", connection);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            price = reader.GetInt32(0) * m.totalUnit;
            connection.Close();

            command = new SqlCommand("insert into detail_transaction values(null, " + idTrans + ", " + m.idPackage + ", " + price + ", " + m.totalUnit + ", null", connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
                return new string[] { "Success" };
            }
            catch (Exception ex)
            {
                return new string[] { ex.Message };
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
