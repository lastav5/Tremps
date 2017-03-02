using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RideOfferForm : System.Web.UI.Page
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
    protected void SubmitRideOffer_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int Price;
            if (price.Text == "")
                Price = -1;
            else
                Price = Convert.ToInt32(price.Text);


            if (Session["userId"] != null)
            {
                Response.Redirect("~/RideOfferPath.aspx?userId=" + Session["userId"] + "&rideDate=" + calendarTB.Text + "&minute=" + minuteDDL.SelectedItem.Text + "&hour=" + hourDDL.SelectedItem.Text + "&email=" + emailTb.Text + "&phone=" + phoneTb.Text + "&notes=" + notes.Text + "&price=" + Price.ToString() + "&gender=" + gender.SelectedIndex + "&origin=" + originTB.Text + "&destination=" + destinationTB.Text);
            }
            else
            {
                Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('אנא התחבר שוב');</script>"));

            }
        }
        else
        {
            Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('חלק מהשדות לא תקינים');</script>"));

        }
    }
}