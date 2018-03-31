using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Restaurant_booking
{
    public class DBMethods
    {
        int carId;
        string carLocation;
        string carMake;
        double carPricePerMile;
        string bookingButton;

        public int CarId
        {
            get { return carId; }
            set { carId = value; }
        }

        public string CarLocation
        {
            get { return carLocation; }
            set { carLocation = value; }
        }

        public string CarMake
        {
            get { return carMake; }
            set { carMake = value; }
        }

        public double CarPricePerMile
        {
            get { return carPricePerMile; }
            set { carPricePerMile = value; }
        }

        public string BookingButton
        {
            get { return bookingButton; }
            set { bookingButton = value; }
        }

        public DBMethods(int i, string l, string m, double p, string b)
        {
            carId = i;
            carLocation = l;
            carMake = m;
            carPricePerMile = p;
            bookingButton = b;
        }

        public static String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static List<Guestbook> GetAllReviews()
        {
            List<Guestbook> Returnable = new List<Guestbook>();

            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                string getQuery = "SELECT * FROM Review";
                SqlCommand cmd = new SqlCommand(getQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Returnable.Add(new Guestbook(int.Parse(rdr[0].ToString()), int.Parse(rdr[1].ToString()), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString()));
                    //Returnable += rdr[0].ToString() + " " + rdr[1].ToString() + " " +
                    //  rdr[2].ToString() + " " + rdr[3].ToString() + "\n";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Returnable.Add(null);
                //Returnable = "Error! - " + ex.ToString();
            }
            return Returnable;
        }

        public static String ExecuteBooking(String Id, int carID, DateTime BookingFromDate, DateTime BookingToDate, DateTime BookingCreatedDate)
        {
            String Returnable = "";
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                string insertQuery = "insert into Booking" +
                    "(Id, CarID, BookingFromDate, BookingToDate, BookingCreatedDate) " +
                    "values " +
                    "(@Id, @CarID, @BookingFromDate, @BookingToDate, @BookingCreatedDate)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@CarID", carID);
                cmd.Parameters.AddWithValue("@BookingFromDate", BookingFromDate.ToString());
                cmd.Parameters.AddWithValue("@BookingToDate", BookingToDate.ToString());
                cmd.Parameters.AddWithValue("@BookingCreatedDate", BookingCreatedDate.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
                Returnable = "Success!";
            }
            catch (Exception ex)
            {
                Returnable = "Error! - " + ex.ToString();
            }
            return Returnable;
        }

        internal static string AddReview(int BookingId, string Id, string ReviewTitle, string ReviewText)
        {
               String Returnable = "";
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                string insertQuery = "insert into Review" +
                    "(BookingId, Id, ReviewTitle, ReviewText) " +
                    "values " +
                    "(@BookingId, @Id, @ReviewTitle, @ReviewText)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@BookingId", BookingId);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@ReviewTitle", ReviewTitle);
                cmd.Parameters.AddWithValue("@ReviewText", ReviewText);
                cmd.ExecuteNonQuery();

                conn.Close();
                Returnable = "Your enquiry has been recorded.\n";
            }
            catch (Exception ex)
            {
                Returnable = "Error! - " + ex.ToString();
            }
            return Returnable;
        }

        public static String AddEnquiry(String Id, String EnquiryTitle, String EnquiryText)
        {
            String Returnable = "";
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                string insertQuery = "insert into Enquiry" +
                    "(Id, EnquiryTitle, EnquiryText) " +
                    "values " +
                    "(@Id, @EnquiryTitle, @EnquiryText)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@EnquiryTitle", EnquiryTitle);
                cmd.Parameters.AddWithValue("@EnquiryText", EnquiryText);
                cmd.ExecuteNonQuery();

                conn.Close();
                Returnable = "Your enquiry has been recorded.\nOne of our colleagues will contact you shortly.";
            }
            catch (Exception ex)
            {
                Returnable = "Error! - " + ex.ToString();
            }
            return Returnable;
        }

        public static List<DBMethods> GetAvailableCars(DateTime x, DateTime y)
        {
            List<DBMethods> Returnable = new List<DBMethods>();

            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                string getQuery = "SELECT * FROM GetAvailableCars ('" + x + "', '" + y + "')";
                SqlCommand cmd = new SqlCommand(getQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Returnable.Add(new DBMethods(int.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), double.Parse(rdr[3].ToString()), ""));
                    //Returnable += rdr[0].ToString() + " " + rdr[1].ToString() + " " +
                    //  rdr[2].ToString() + " " + rdr[3].ToString() + "\n";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Returnable.Add(new DBMethods(0, "Exception: ", ex.ToString(), 0.0, ""));
                //Returnable = "Error! - " + ex.ToString();
            }
            return Returnable;
        }

        public static int GetBookingNumber(DateTime selectedDate, String UID)
        {
            int Returnable = 0;
            String x = DateToSqlStringConverter(selectedDate);
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                string getQuery = "SELECT BookingID FROM Booking WHERE Id = '" + UID +
                    "' AND BookingFromDate = '" + x + "'";
                SqlCommand cmd = new SqlCommand(getQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Returnable = int.Parse(rdr[0].ToString());
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Returnable = -1;
            }
            return Returnable;
        }

        public static List<String> GetAllDatesForGuestBook(String UID)
        {

            List<String> Returnable = new List<String>();

            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                string getQuery = "SELECT BookingFromDate FROM Booking WHERE Id = '" + UID + "' AND FORMAT(getdate(), 'yyyy-dd-MM') NOT BETWEEN BookingFromDate AND BookingToDate";
                SqlCommand cmd = new SqlCommand(getQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Returnable.Add(DateTime.Parse(rdr[0].ToString()).ToShortDateString());
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Returnable.Add(DateTime.MinValue.ToString());
            }
            return Returnable;
        }

        public static List<DBMethods> GetCarDetails(int CarID)
        {
            List<DBMethods> Returnable = new List<DBMethods>();

            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                string getQuery = "SELECT CarId, CarLocation, CarMake, CarPricePerDay FROM Car WHERE CarID = " + CarID;
                SqlCommand cmd = new SqlCommand(getQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Returnable.Add(new DBMethods(int.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), double.Parse(rdr[3].ToString()), ""));
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Returnable.Add(new DBMethods(0, "Exception: ", ex.ToString(), 0.0, ""));
                //Returnable = "Error! - " + ex.ToString();
            }
            return Returnable;
        }

        public static String DateToSqlStringConverter(DateTime x)
        {
            return x.Year + "-" + x.Month + "-" + x.Day + " 00:00:00.000";
        }
    }
}