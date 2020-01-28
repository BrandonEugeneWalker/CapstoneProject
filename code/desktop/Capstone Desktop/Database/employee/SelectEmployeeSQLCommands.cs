using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.Database.employee
{
    /// <summary>Class for selecting employees with SQL.</summary>
    public static class SelectEmployeeSQLCommands
    {

        public static Employee GetEmployeeByIdPassword(int employeeId, string password)
        {
            var query =
                "select * from Employee where employeeId = @employeeId and password = ENCRYPT(@password, 'whatever')";

            using (var getEmployeeConnection = new MySqlConnection(CapstoneSQLConnection.SqlConnection))
            {
                getEmployeeConnection.Open();

                using (var getEmployeeCommand = new MySqlCommand(query, getEmployeeConnection))
                {
                    getEmployeeCommand.Parameters.Add("@employeeId", MySqlDbType.Int32);
                    getEmployeeCommand.Parameters.Add("@password", MySqlDbType.VarChar);

                    getEmployeeCommand.Parameters["@employeeId"].Value = employeeId;
                    getEmployeeCommand.Parameters["@password"].Value = password;

                    var results = getEmployeeCommand.ExecuteReader();

                    var returnId = 0;
                    var returnName = "";
                    var returnIsManager = false;


                    while (results.Read())
                    {
                        returnId = results.GetInt32(0);
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
