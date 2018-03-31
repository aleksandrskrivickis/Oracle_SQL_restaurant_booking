using System;
using Oracle.ManagedDataAccess.Client;

namespace Restaurant_booking
{
    public class DBMethods
    {
        public static String GetConnection()
        {
            string conString = "User Id=ak7993g; password=ak7993g;" +

            //EZ Connect Format is [hostname]:[port]/[service_name]
            //Examine working TNSNAMES.ORA entries to find these values
            "Data Source=obiwan.cms.gre.ac.uk/obiwan:1521; Pooling=false;";

            //Create a connection to Oracle

            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;

            con.Open();

            //Create a command within the context of the connection
            //Use the command to display employee names and salary from Employees table
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select first_name from employees where department_id = 60";

            //Execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //MessageBox.Show("Employee Name: " + reader.GetString(0));
            }
            return "Success!";
        }

  
    }
}