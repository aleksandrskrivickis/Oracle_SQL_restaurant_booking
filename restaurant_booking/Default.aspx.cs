using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant_booking
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = DBMethods.ReadData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime x = Calendar1.SelectedDate;
            string date = x.ToLongDateString().Substring(0, 2) + "-" + x.ToLongDateString().Substring(3, 3) + "-" + x.Year.ToString().Substring(2);
            string time = TextBox3.Text + ":" + TextBox4.Text + ":00";
            Label1.Text = DBMethods.AddActivityBooking(TextBox1.Text, TextBox2.Text, date, time);
        }
    }
}