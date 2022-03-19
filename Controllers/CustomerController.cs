using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LKS_Laundry_Prov_API.Models;

namespace LKS_Laundry_Prov_API.Controllers
{
    public class CustomerController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        SqlCommand command;
        SqlDataReader reader;

        [HttpPost]
        public DataTable result(Utils u)
        {
            command = new SqlCommand("select top(1) * from customer where phone_number_customer like '%' + @params + '%'", connection);
            command.Parameters.AddWithValue("@params", u.phone);
            return Utils.getdata(command);
        }
    }
}
