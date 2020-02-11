using System;
using System.Transactions;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.Database.rental
{
    /// <summary>This class handles any sql commands related to updating rental's on the database.</summary>
    public static class UpdateRentalSqlCommands
    {

        /// <summary>Updates the rental status SQL command.</summary>
        /// <param name="id">The rental identifier.</param>
        /// <param name="status">The status of the rental.</param>
        /// <returns>Returns true if it successfully edited the single item, False if not.</returns>
        public static bool UpdateRentalStatusSqlCommand(int id, string status)
        {
            var query = "UPDATE `ItemRental` SET `status` = @status WHERE `rentalId` = @rentalId";

            using (MySqlConnection updateRentalConnection = new MySqlConnection(CapstoneSqlConnection.SqlConnection))
            {
                using (MySqlCommand updateRentalCommand = new MySqlCommand(query, updateRentalConnection))
                {
                    updateRentalCommand.Parameters.Add("@status", MySqlDbType.VarChar);
                    updateRentalCommand.Parameters.Add("@rentalId", MySqlDbType.Int32);

                    updateRentalCommand.Parameters["@status"].Value = status;
                    updateRentalCommand.Parameters["@rentalId"].Value = id;

                    using (var transactionScope = new TransactionScope())
                    {
                        var results = updateRentalCommand.ExecuteNonQuery();
                        if (results == 1)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}