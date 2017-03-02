using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Ride
/// </summary>
public abstract class Ride
{
    int rideId;
    int userId;
    DateTime rideDate;
    int minute;
    int hour;
    string email;
    string phone;
    string notes;
    int price;
    DateTime creationDate;
    int genderPref;
    string originName;
    string destinationName;

    public Ride()
    {
    }

	public Ride(int rideId, int userId,DateTime rideDate , int minute, int hour, string email,string phone,string notes,int price,DateTime creationDate,int genderPref,string originName,string destinationName)
	{
        this.rideId = (int)rideId;
        this.userId = userId;
        this.rideDate = rideDate;
        this.minute = minute;
        this.hour = hour;
        this.email = email;
        this.phone = phone;
        this.notes = notes;
        this.price = price;
        this.creationDate = (DateTime)creationDate;
        this.genderPref = genderPref;
        this.originName = originName;
        this.destinationName = destinationName;
	}

    public Ride(int userId,DateTime rideDate, int minute, int hour, string email, string phone, string notes, int price, int genderPref, string originName, string destinationName)
    {
        this.userId = userId;
        this.rideDate = rideDate;
        this.minute = minute;
        this.hour = hour;
        this.email = email;
        this.phone = phone;
        this.notes = notes;
        this.price = price;
        this.genderPref = genderPref;
        this.originName = originName;
        this.destinationName = destinationName;
    }

    public DateTime GetRideDate()
    {
        return rideDate;
    }

    public void SetRideDate(DateTime rideDate)
    {
        this.rideDate = rideDate;
    }

    public int GetRideId()
    {
        return rideId;
    }
    public int GetUserId()
    {
        return userId;
    }
    public int GetMinute()
    {
        return minute;
    }
    public int GetHour()
    {
        return hour;
    }
    public string GetEmail()
    {
        return email;
    }
    public string GetPhone()
    {
        return phone;
    }
    public string GetNotes()
    {
        return notes;
    }
    public int GetPrice()
    {
        return price;
    }
    public DateTime GetCreationDate()
    {
        return creationDate;
    }
    public int GetgenderPref()
    {
        return genderPref;
    }
    public string GetOriginName()
    {
        return originName;
    }
    public string GetDestinationName()
    {
        return destinationName;
    }

    public void SetRideId(int rideOfferId)
    {
        this.rideId = rideOfferId;
    }
    public void SetUserId(int userId)
    {
        this.userId = userId;
    }
    public void SetMinute(int minute)
    {
        this.minute = minute;
    }
    public void SetHour(int hour)
    {
        this.hour = hour;
    }
    public void SetEmail(string email)
    {
        this.email = email;
    }
    public void SetPhone(string phone)
    {
        this.phone = phone;
    }
    public void SetNotes(string notes)
    {
        this.notes = notes;
    }
    public void SetPrice(int price)
    {
        this.price = price;
    }
    public void SetCreationDate(DateTime creationDate)
    {
        this.creationDate = creationDate;
    }
    public void SetGenderPref(int genderPref)
    {
        this.genderPref = genderPref;
    }
    public void SetOriginName(string originName)
    {
        this.originName = originName;
    }
    public void SetDestinationName(string destinationName)
    {
        this.destinationName = destinationName;
    }
}