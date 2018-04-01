using System;
using Oracle.ManagedDataAccess.Client;

namespace Restaurant_booking
{
    public class DBMethods
    {
        public static OracleConnection GetConnection()
        {
            string conString = "User Id=ak7993g; password=ak7993g;" +
            "Data Source=obiwan.cms.gre.ac.uk/obiwan:1521; Pooling=false;";


            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            return con;
            
           
        }

        public static String ReadData()
        {
            string returnable = "";

            OracleConnection con = GetConnection();
            con.Open();

            //Create a command within the context of the connection
            //Use the command to display employee names and salary from Employees table
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select \"ActivityBookingID\" from \"ActivityBookings\"";
            //cmd.ExecuteNonQuery();
            //Execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                returnable += reader.GetDecimal(0);
            }
            if (returnable != "")
            {
                return "Success!";
            }
            else { return returnable; }
        }

        public static String WriteData(String commandString)
        {
            string returnable = "";

            try
            {
                OracleConnection con = GetConnection();
                con.Open();

                //Create a command within the context of the connection
                //Use the command to display employee names and salary from Employees table
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = commandString;
                cmd.ExecuteNonQuery();
                //Execute the command and use datareader to display the data
            }
            catch (OracleException ex) // catches only Oracle errors
            {
                switch (ex.Number)
                {
                    case 1:
                        returnable = "Error attempting to insert duplicate data.";
                        break;
                    case 12545:
                        returnable = "The database is unavailable.";
                        break;
                    default:
                        returnable = "Database error: " + ex.Message.ToString();
                        break;
                }
            }
            catch (Exception ex) // catches any error not previously caught
            {
                returnable = ex.Message.ToString();
            }

            return "Success!";

        }

        public static String AddActivityBooking(string uid, string guests, string date, string time)
        {
            //Format = 01-Apr-18 13:37:55
            string dateAndTime = date + " " + time;
            String commandString = "INSERT INTO \"AK7993G\".\"ActivityBookings\" (\"ActivityBookingID\",\"ActivityID\",\"BookingID\",\"ActivityBookedSlots\",\"ActivityBookingFromTime\") VALUES ((SELECT MAX(\"ActivityBookingID\")+1 FROM \"ActivityBookings\"),13," + uid + "," + guests+ ",'" + dateAndTime + "')";
            return WriteData(commandString);
        }
    }
}