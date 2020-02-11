using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Capstone_Database
{
    public class Class1
    {
        //private MySqlConnection con = new MySqlConnection("server = 160.10.25.16; port=3306;uid=cs4982s20d;pwd=PAoWBgKC42A3m45V;database=cs4982s20d");
        public static bool Connected;

        public static string GetRemoteConnectionString()
        {
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder()
            {
                DataSource = "160.10.25.16,3306",
                InitialCatalog = "cs4982s20d",
                IntegratedSecurity = false,
                MultipleActiveResultSets = true,
                UserID = "cs4982s20d",
                Password = "PAoWBgKC42A3m45V"
            };
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder()
            {
                Server = "160.10.25.16,3306",
                Database = "cs4982s20d",
                IntegratedSecurity = false,
                UserID = "cs4982s20d",
                Password = "PAoWBgKC42A3m45V",
                Pooling = false
            };
            return connString.ToString();
        }

        public Class1()
        {
            //bool connected = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(GetRemoteConnectionString()))
                {
                    con.Open();
                }
                Connected = true;
            }
            catch (Exception)
            {
                Connected = false;
            }

            //var isConnected = connected;

            /*            this.con.Open();
                        MySqlCommand cmd = new MySqlCommand("select * from Product", con);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);*/
        }



    }
}
