using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShowMatchesForRequest : System.Web.UI.Page
{
    public string originPoint;
    public string destinationPoint;

    protected void Page_Load(object sender, EventArgs e)
    {
        RideRequest rr = new RideRequest();
        DataTable dt = new DataTable();
        //
        try
        {
            dt = rr.getMatchRideRequest(Convert.ToInt32(Request.QueryString["rideId"]));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i]["price"]) == -1)
            {
                dt.Rows[i]["price"] = 0;
            }
            string date = dt.Rows[i]["rideDate"].ToString();
            string[] arr = date.Split(' ');
            dt.Rows[i]["rideDate"] = arr[0];
        }

        matchUsersRepeater.DataSource = dt;
        matchUsersRepeater.DataBind();
    }
}