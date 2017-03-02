using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RideOffer
/// </summary>
public class RideOffer : Ride
{
    RideOfferService rideOfferService = new RideOfferService();
    public RideOffer(int rideId, int userId, DateTime rideDate, int minute, int hour, string email, string phone, string notes, int price, DateTime creationDate, int genderPref, string originName, string destinationName) : base(rideId, userId,rideDate, minute, hour,  email, phone, notes, price, creationDate, genderPref, originName,destinationName)
	{
        
	}

    public RideOffer(int userId, DateTime rideDate, int minute, int hour, string email, string phone, string notes, int price, int genderPref, string originName, string destinationName)
        : base(userId, rideDate, minute, hour, email, phone, notes, price, genderPref, originName, destinationName)
    {
        
    }

    public RideOffer()
    {
    }

    public int SaveRideOffer()
    {
        RideOfferService ros = new RideOfferService();
        int tmp = ros.SaveRideOffer(this);
        return tmp;
    }

    public DataSet GetAllRideOffers()
    {
        RideOfferService ros = new RideOfferService();
        DataSet ds = ros.getAllRideOffers();
        return ds;
    }

    public DataSet GetUserRideOffers(int UserId)
    {
        RideOfferService ros = new RideOfferService();
        DataSet ds = ros.getUserRideOffers(UserId);
        return ds;
    }
    public void DeleteRideOffer(int rideId)
    {
        RideOfferService ros = new RideOfferService();
        ros.DeleteRideOffer(rideId);
    }

    public DataTable getMatchforRideOffer(int rideOfferId) //enter offerId get matching requests
    {
        RideOfferService ros = new RideOfferService();
        DataTable dt = new DataTable();
        dt = ros.getMatchRideOffer(rideOfferId);
        return dt;
    }
}