using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace MyBotApplicationDemo.Helper
{
    public static class DBHelper
    {

        public static List<Entities.Location> ConnectToDatabase()
        {
            List<Entities.Location> locationData = new List<Entities.Location>();
            try
            {

                
                using (SqlConnection conn = new SqlConnection("data source=bondugula;initial catalog = Northwind; integrated security = SSPI; persist security info = False;Trusted_Connection = Yes"))
                {
                    conn.ConnectionString = "Data Source=MININT-1476GTU;Initial Catalog=BookingDatabase;integrated security = SSPI; persist security info = False;Trusted_Connection = Yes";
                    //conn.ConnectionString = "Server=[MININT-1476GTU];Database=[BookingDatabase];Trusted_Connection=true";
                    conn.Open();

                    // using the code here...

                    SqlCommand command = new SqlCommand("select * from [BookingDatabase].dbo.location", conn);
                    command.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    var dataSet = new DataSet();
                    try {
                        adapter.Fill(dataSet);
                    }
                    catch (Exception ex ) {
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                        while (reader.Read())
                        {
                            locationData.Add(new Entities.Location((int)reader["LocationId"],(string)reader["Name"]));
                            //Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                               // reader[0], reader[1], reader[2], reader[3]));
                        }
                    }

                    conn.Close();
                }

                return locationData;
 
            }

            catch(Exception ex)
            {
                return locationData;

            }
        }
    }
}
