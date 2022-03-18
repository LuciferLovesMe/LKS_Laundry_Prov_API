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
    public class NotifController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        SqlCommand command;

        [HttpPost]
        public DataTable getData(Utils u)
        {
            command = new SqlCommand("select * from header_transaction join detail_transaction on header_transaction.id_header_transaction = detail_transaction.id_header_Transaction join package on detail_transaction.id_package = package.id_package where header_transaction.id_customer = " + u.id, connection);
            return Utils.getdata(command);
        }
    }
}
