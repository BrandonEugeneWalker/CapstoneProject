using System.Data;
using System.Data.SqlClient;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.Database.employee
{
    /// <summary>Handles SQL commands for inserting employees.</summary>
    public static class InsertEmployeeSQLCommands
    {
        public static bool InsertEmployee(Employee employeeToInsert, string password)
        {
            var query =
                "insert into Employee(employeeId, password, isManager, name) values(@employeeId, ENCRYPT(@password, 'whatever'), @isManager, @name)";

            using (var insertMemberConnection =
                new MySqlConnection(CapstoneSQLConnection.SqlConnection))
            {
                insertMemberConnection.Open();

                using (var insertMemberCommand = new MySqlCommand(query, insertMemberConnection))
                {
                    insertMemberCommand.Parameters.Add("@employeeId", MySqlDbType.Int32);
                    insertMemberCommand.Parameters.Add("@password", MySqlDbType.VarChar);
                    insertMemberCommand.Parameters.Add("@isManager", MySqlDbType.Bit);
                    insertMemberCommand.Parameters.Add("@name", MySqlDbType.VarChar);

                    insertMemberCommand.Parameters["@employeeId"].Value = employeeToInsert.EmployeeId;
                    insertMemberCommand.Parameters["@password"].Value = password;
                    insertMemberCommand.Parameters["@isManager"].Value = employeeToInsert.IsManager;
                    insertMemberCommand.Parameters["@name"].Value = employeeToInsert.EmployeeName;

                    var result = insertMemberCommand.ExecuteNonQuery();

                    return (result == 1);
                }
            }
        }
    }
}