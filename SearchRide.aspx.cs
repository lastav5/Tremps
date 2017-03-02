using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SearchRide : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
    protected void submit_Click(object sender, EventArgs e)
    {
        if (originTB.Text != "" && destinationTB.Text != "" && calendarTB.Text != "")
        {
            DataSet ds = new DataSet();
            try
            {
                RideRequest rr = new RideRequest();
                ds = rr.GetAllRidesFilter(rideTypeDDL.SelectedValue.ToString(), originTB.Text, destinationTB.Text, (Convert.ToDateTime(calendarTB.Text)), Convert.ToInt32(minuteDDL.SelectedValue), Convert.ToInt32(hourDDL.SelectedValue), Convert.ToInt32(genderPrefDDL.SelectedValue));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (ds != null)
            {
                ridesRepeater.DataSource = ds.Tables[0];
                ridesRepeater.DataBind();
            }
            else
            {
                Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('לא נמצאו טרמפים מתאימים. נסה מאוחר יותר!');</script>"));

            }
        }
        else
        {
            Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('אנא הזן מוצא ויעד');</script>"));

        }
    }
}