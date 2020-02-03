using System.Data;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.Database.employee
{
    /// <summary>This class contains all SQL commands related to deleting an employee.</summary>
    public static class DeleteEmployeeSqlCommands
    {

        public static int DeleteEmployeeById(int id)
        {
            var query = "delete from Employee where employeeId = @employeeId";

            using (MySqlConnection deleteConnection = new MySqlConnection(CapstoneSqlConnection.SqlConnection))
            {
                deleteConnection.Open();

                using (MySqlCommand deleteCommand = new MySqlCommand(query, deleteConnection))
                {
                    deleteCommand.Parameters.Add("@employeeId", MySqlDbType.Int32);
                    deleteCommand.Parameters["@employeeId"].Value = id;
                    var results = deleteCommand.ExecuteNonQuery();
                    return results;
                }
            }
        }
    }
}