using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RideRequestForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null)
        {
            Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('אנא התחבר על מנת לפרסם טרמפ');</script>"));
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            if (calendarTB.Text == "")
            {
                calendarTB.Text = DateTime.Now.Date.ToShortDateString();
                //calendar.SelectedDate = DateTime.Now.Date;
            }

            InitHourDDL();
        }
    }

    private void InitHourDDL()
    {
        for (int i = 0; i < 24; i++)
        {
            ListItem li = new ListItem();
            if (i < 10)
                li.Text = "0" + i.ToString();
            else
                li.Text = i.ToString();
            hourDDL.Items.Add(li);
        }
    }
    protected void SubmitRideRequest_Click(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {

            int Price;
            if (price.Text == "" || price == null)
                Price = -1;
            else
                Price = Convert.ToInt32(price.Text);

            //var DateTime = new DateTime(calendar.SelectedDate.Value.Year, calendar.SelectedDate.Value.Month, calendar.SelectedDate.Value.Day, int.Parse(hourDDL.SelectedItem.Text), int.Parse(minuteDDL.SelectedItem.Text), 0);


            Response.Redirect("~/MatchesUsersForRequest.aspx?userId=" + Session["userId"].ToString() + "&rideDate=" + calendarTB.Text + "&minute=" + minuteDDL.SelectedItem.Text + "&hour=" + hourDDL.SelectedItem.Text + "&email=" + emailTb.Text + "&phone=" + phoneTb.Text + "&notes=" + notes.Text + "&price=" + Price + "&gender=" + gender.SelectedIndex + "&origin=" + originTB.Text + "&destination=" + destinationTB.Text);
        }
        else
        {
            Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('אנא התחבר שוב');</script>"));

        }
    }
}