using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MatchesUsersForRequest : System.Web.UI.Page
{
    public string originPoint;
    public string destinationPoint;

    protected void Page_Load(object sender, EventArgs e)
    {
        originPoint = Request.QueryString["origin"];
        destinationPoint = Request.QueryString["destination"];

    }

    protected void InsertRideRequest_Click(object sender, EventArgs e)
    {
        RideRequest rr = new RideRequest();

        //var DateTime = new DateTime(Convert.ToDateTime(Request.QueryString["datetime"]).Year, Convert.ToDateTime(Request.QueryString["datetime"]).Month, Convert.ToDateTime(Request.QueryString["datetime"]).Day, int.Parse(Request.QueryString["hour"]), int.Parse(Request.QueryString["minute"]), 0);

        RideRequest rideRequest = new RideRequest((int)Session["userId"], (Convert.ToDateTime(Request.QueryString["rideDate"])), Convert.ToInt32(Request.QueryString["minute"]), Convert.ToInt32(Request.QueryString["hour"]), Request.QueryString["email"], Request.QueryString["phone"], Request.QueryString["notes"], Convert.ToInt32(Request.QueryString["price"]), Convert.ToInt32(Request.QueryString["gender"]), Request.QueryString["origin"], Request.QueryString["destination"], Convert.ToDouble(originLng.Text), Convert.ToDouble(originLat.Text), Convert.ToDouble(destinationLng.Text), Convert.ToDouble(destinationLat.Text));
        int rideRequestId = 0;
        
        DataTable dt = new DataTable();
        try
        {
            rideRequestId = rideRequest.InsertRideRequest();
            dt = rr.getMatchRideRequest(rideRequestId);
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

        InsertRideRequest.Visible = false;
        Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('הטרמפ נשמר במערכת בהצלחה!');</script>"));
    }
}