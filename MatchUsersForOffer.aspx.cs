using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MatchUsersForOffer : System.Web.UI.Page
{
    public string originPoint;
    public string destinationPoint;
    public int rideOfferId;

    protected void Page_Load(object sender, EventArgs e)
    {

        rideOfferId = Convert.ToInt32(Request.QueryString["rideId"]);

        RideOffer rideOffer = new RideOffer();
        DataTable requestsTable = new DataTable();
        try
        {
             requestsTable = rideOffer.getMatchforRideOffer(rideOfferId);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        for (int i = 0; i < requestsTable.Rows.Count; i++)
        {
            if (Convert.ToInt32(requestsTable.Rows[i]["price"]) == -1)
            {
                requestsTable.Rows[i]["price"] = 0;
            }
            string date = requestsTable.Rows[i]["rideDate"].ToString();
            string[] arr = date.Split(' ');
            requestsTable.Rows[i]["rideDate"] = arr[0];
        }

        matchUsersRepeater.DataSource = requestsTable;
        matchUsersRepeater.DataBind();
    }
}