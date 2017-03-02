using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RideRequest
/// </summary>
public class RideRequest : Ride
{
    double originX;
    double originY;
    double destinationX;
    double destinationY;

    RideRequestService rrs = new RideRequestService();
    public RideRequest()
    {

    }

    public RideRequest(int rideId, int userId,DateTime rideDate, int minute, int hour, string email,string phone,string notes,int price, DateTime creationDate,int genderPref,string originName,string destinationName, double originX, double originY, double destinationX, double destinationY) : base(rideId, userId, rideDate, minute, hour,  email,  phone,  notes,  price,  creationDate,  genderPref,  originName,  destinationName)
	{
        this.originX = originX;
        this.originY = originY;
        this.destinationX = destinationX;
        this.destinationY = destinationY;
	}

    public RideRequest(int userId, DateTime rideDate, int minute, int hour, string email, string phone, string notes, int price,int genderPref, string originName, string destinationName)
        : base(userId, rideDate, minute, hour, email, phone, notes, price, genderPref, originName, destinationName)
    {
        
    }

    public RideRequest(int userId,DateTime rideDate, int minute, int hour, string email, string phone, string notes, int price, int genderPref, string originName, string destinationName, double originX, double originY, double destinationX, double destinationY)
        : base(userId, rideDate, minute, hour, email, phone, notes, price, genderPref, originName, destinationName)
    {
        this.originX = originX;
        this.originY = originY;
        this.destinationX = destinationX;
        this.destinationY = destinationY;
    }

    public double GetOriginX()
    {
        return originX;
    }
    public double GetOriginY()
    {
        return originY;
    }
    public double GetDestinationX()
    {
        return destinationX;
    }
    public double GetDestinationY()
    {
        return destinationY;
    }
    public void SetOriginX(double originX)
    {
        this.originX = originX;
    }
    public void SetOriginY(double originY)
    {
        this.originY = originY;
    }
    public void SetDestinationX(double destinationX)
    {
        this.destinationX = destinationX;
    }
    public void SetDestinationY(double destinationY)
    {
        this.destinationY = destinationY;
    }

    public DataSet GetAllRideRequests()
    {
        RideRequestService rrs = new RideRequestService();
        DataSet ds = rrs.getAllRideRequests();
        return ds;
    }

    public DataSet GetUserRideRequests(int UserId)
    {
        RideRequestService rrs = new RideRequestService();
        DataSet ds = rrs.getUserRideRequests(UserId);
        return ds;
    }

    public DataSet GetAllRidesFilter(string rideType, string origin, string destination, DateTime rideDate, int minute, int hour, int genderPref)
    {
        try
        {
            return (rrs.GetAllRidesFilter(rideType, origin, destination, rideDate, minute, hour, genderPref));
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public void DeleteRideRequest(int rideId)
    {
        try
        {
             rrs.DeleteRideRequest(rideId);
        }
        catch (Exception ex)
        {
        }
    }

    public int InsertRideRequest()
    {
        try
        {
            int tmp = rrs.InsertRideRequest(this);
            return tmp;
        }
        catch
        {
            return -1;
        }
    }
    public DataTable getMatchRideRequest(int rideRequestId)
    {
        try
        {
            return rrs.getMatchRideRequest(rideRequestId);
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
    }
}