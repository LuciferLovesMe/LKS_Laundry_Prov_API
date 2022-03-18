using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LKS_Laundry_Prov_API.Models;

namespace LKS_Laundry_Prov_API.Controllers
{
    public class EmployeeController : ApiController
    {
        LKS_Laundry_ProvEntities row = new LKS_Laundry_ProvEntities();

        [HttpPost]
        public IHttpActionResult result(Utils u)
        {
            string query = "select * from employee where email_employee '" + u.username + "' and password_employee = '" + u.password + "'";
            var user = row.Employees.SqlQuery(query).FirstOrDefault();
            if(user != null)
            {
                u.id = user.id;
                u.name = user.name_employee;
                u.username = user.email_employee;
                return Ok(u);
            }

            return null;
        }
    }
}
