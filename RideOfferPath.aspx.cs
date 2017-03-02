using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class RideOfferPath : System.Web.UI.Page
{
    public string originPoint;
    public string destinationPoint;
    protected void Page_Load(object sender, EventArgs e)
    {
        originPoint = Request.QueryString["origin"];
        destinationPoint = Request.QueryString["destination"];
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RideOfferForm.aspx");
    }
    protected void RideOfferPathBtn_Click(object sender, EventArgs e)
    {
        RideOfferCoordinates rideOfferCoordinates = new RideOfferCoordinates();
        string[] coordinateX;
        string[] coordinateY;
        string xmlStr="";
        coordinateX = coordinateXArray.Text.Split(','); //from js
        coordinateY = coordinateYArray.Text.Split(',');
        int coordinateXLength = coordinateX.Length;
         
        xmlStr+="<Coordinates>";
        for (int i = 0; i < coordinateXLength; i++)
        {
            xmlStr += "<row";
            xmlStr += " X=\"" + coordinateX[i] + "\"";
            xmlStr += " Y=\"" + coordinateY[i] + "\"";
            xmlStr += " ordinal=\"" + i + "\"";
            xmlStr += "/>";
        }
        xmlStr += "</Coordinates>";
       
        
        RideOffer rideOffer = new RideOffer(Convert.ToInt32(Request.QueryString["userId"]), (Convert.ToDateTime(Request.QueryString["rideDate"])), Convert.ToInt32(Request.QueryString["minute"]), Convert.ToInt32(Request.QueryString["hour"]), Request.QueryString["email"], Request.QueryString["phone"], Request.QueryString["notes"], Convert.ToInt32(Request.QueryString["price"]), Convert.ToInt32(Request.QueryString["gender"]), Request.QueryString["origin"], Request.QueryString["destination"]);
        int rideOfferId;
        try
        {
            rideOfferId=rideOffer.SaveRideOffer();
            rideOfferCoordinates.SaveRideOfferCoordinate(rideOfferId, xmlStr);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
        Response.Redirect("MatchUsersForOffer.aspx?rideOfferId="+rideOfferId);

        //Response.Redirect("~/MatchUsersForOffer.aspx?rideOfferId=" + Request.QueryString["rideOfferId"] + "&originPoint=" + Request.QueryString["OriginPoint"] + "&destinationPoint=" + Request.QueryString["DestinationPoint"]);
        
    }
}