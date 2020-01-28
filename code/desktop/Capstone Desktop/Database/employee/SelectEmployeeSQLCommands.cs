using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Database.employee
{
    /// <summary>Class for selecting employees with SQL.</summary>
    public static class SelectEmployeeSQLCommands
    {

        public static Employee GetEmployeeByIdPassword(int employeeId, string password)
        {
            var query =
                "select * from Employee where employeeId = @employeeId and password = ENCRYPT(@password, 'whatever')";

            using (var getEmployeeConnection = new SqlConnection(Properties.Settings.Capstone_DatabaseConnectionString))
            {
                getEmployeeConnection.Open();

                using (var getEmployeeCommand = new SqlCommand(query, getEmployeeConnection))
                {
                    getEmployeeCommand.Parameters.Add("@employeeId", SqlDbType.Int);
                    getEmployeeCommand.Parameters.Add("@password", SqlDbType.VarChar);

                    getEmployeeCommand.Parameters["@employeeId"].Value = employeeId;
                    getEmployeeCommand.Parameters["@password"].Value = password;

                    var results = getEmployeeCommand.ExecuteReader();

                    var returnId = 0;
                    var returnPassword = "";
                    var returnName = "";
                    var returnIsManager = false;


                    while (results.Read())
                    {
                        returnId = results.GetInt32(0);
                        returnPassword = results.GetString(1);
                        returnIsManager = results.GetBoolean(2);
                        returnName = results.GetString(3);
                    }

                    var returnEmployee = new Employee(returnId, returnName, returnIsManager);
                    return returnEmployee;
                }
            }
        }
    }
}
