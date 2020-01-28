using System;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.Database.employee
{
    /// <summary>Handles SQL commands for inserting employees.</summary>
    public static class InsertEmployeeSqlCommands
    {
        #region Methods

        public static bool InsertEmployee(Employee employeeToInsert, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), "The employee's password cannot be null or empty.");
            }

            var query =
                "insert into Employee(employeeId, password, isManager, name) values(@employeeId, ENCRYPT(@password, 'whatever'), @isManager, @name)";

            using (var insertMemberConnection =
                new MySqlConnection(CapstoneSqlConnection.SqlConnection))
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

                    return result == 1;
                }
            }
        }

        #endregion
    }
}