using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for RideOfferCoordinates
/// </summary>
public class RideOfferCoordinates
{
    int rideOfferId;
    double coordinateX;
    double coordinateY;

	public RideOfferCoordinates(int rideOfferId, double coordinateX, double coordinateY)
	{
        this.rideOfferId = rideOfferId;
        this.coordinateX = coordinateX;
        this.coordinateY = coordinateY;
	}

    public RideOfferCoordinates()
    {
        
    }

    public int GetRideOfferId()
    {
        return rideOfferId;
    }

    public double GetCoordinateX()
    {
        return coordinateX;
    }

    public double GetCoordinateY()
    {
        return coordinateY;
    }

    public void SetRideOfferId(int rideOfferId)
    {
        this.rideOfferId = rideOfferId;
    }

    public void SetCoordinateX(double coordinateX)
    {
        this.coordinateX = coordinateX;
    }

    public void SetCoordinateY(double coordinateY)
    {
        this.coordinateY = coordinateY;
    }

    public void SaveRideOfferCoordinate(int rideOfferId,string xml)
    {
        RideOfferCoordinatesService rocs = new RideOfferCoordinatesService();
        rocs.SaveRideOfferCoordinate(rideOfferId,xml);
    }
}