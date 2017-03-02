using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class MyTremps : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null)
        {
            Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('אנא התחבר על מנת לראות את הטרמפים שלך');</script>"));

            Response.Redirect("Login.aspx");
        } 
    }


    protected void myOffersBtn_Click(object sender, EventArgs e)
    {
        rideType.Text = "rideOffer";
        myOffersBtn.BorderStyle = BorderStyle.Solid;
        myOffersBtn.BorderColor = Color.Black;
        
        TrempsRepeater.DataSource = GetAllRideOffers().Tables[0];
        TrempsRepeater.DataBind();

    }
    protected void myRequestsBtn_Click(object sender, EventArgs e)
    {
        rideType.Text = "rideRequest";
        
        TrempsRepeater.DataSource = GetAllRideRequests().Tables[0];
        TrempsRepeater.DataBind();
    }


    protected void trempsRepeater_ItemDataBound(object sender, CommandEventArgs e)
    {
        if (e.CommandName== "delete")
        {
            if (rideType.Text =="rideRequest")
            {
                DeleteRideRequest(Convert.ToInt32(e.CommandArgument));
            }
            else
            {
                DeleteRideOffer(Convert.ToInt32(e.CommandArgument));

            }
        }
        if (e.CommandName == "showMatching")
        {
            if (rideType.Text == "rideRequest")
            { 
                Response.Redirect("ShowMatchesForRequest.aspx?rideId="+e.CommandArgument);
            }
            
            else
            {
                Response.Redirect("MatchUsersForOffer.aspx?rideId="+e.CommandArgument);
            }
        }
    }

    protected void DeleteRideRequest(int rideId)
    {
        RideRequest rideRequest = new RideRequest();
        try
        {
            rideRequest.DeleteRideRequest(Convert.ToInt32(rideId));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        DataTable dt = new DataTable();
        try
        {
            dt = GetAllRideRequests().Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
        TrempsRepeater.DataSource = dt;
        TrempsRepeater.DataBind();
    }

    protected void DeleteRideOffer(int rideId)
    {
        RideOffer rideOffer = new RideOffer();
        try
        {
            rideOffer.DeleteRideOffer(Convert.ToInt32(rideId));
        }
        catch (Exception ex)
        {
            throw ex;
        }


        DataTable dt = new DataTable();
        try
        {
            dt = GetAllRideOffers().Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
        TrempsRepeater.DataSource = dt;
        TrempsRepeater.DataBind();
    }

    protected DataSet GetAllRideOffers()
    {
        RideOffer rideOffer = new RideOffer();
        DataSet ds = new DataSet();
        try
        {
            ds = rideOffer.GetUserRideOffers((int)Session["userId"]);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[i]["price"]) == -1)
            {
                ds.Tables[0].Rows[i]["price"] = 0;
            }
            string date =  ds.Tables[0].Rows[i]["rideDate"].ToString();
            string[] arr = date.Split('-');
            
            ds.Tables[0].Rows[i]["rideDate"] = arr[2]+"/"+arr[1]+"/"+arr[0];
         
        }
        return ds;
    }

    protected DataSet GetAllRideRequests()
    {
        RideRequest rideRequest = new RideRequest();
        DataSet ds = new DataSet();
        try
        {
            ds = rideRequest.GetUserRideRequests((int)Session["userId"]);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[i]["price"]) == -1)
            {
                ds.Tables[0].Rows[i]["price"] = 0;
            }
            string date = ds.Tables[0].Rows[i]["rideDate"].ToString();
            string[] arr = date.Split('-');

            ds.Tables[0].Rows[i]["rideDate"] = arr[2] + "/" + arr[1] + "/" + arr[0];
        }
        return ds;
    }
}