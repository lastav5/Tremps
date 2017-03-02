using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Xml.Linq;

/// <summary>
/// Summary description for RideOfferCoordinatesService
/// </summary>
public class RideOfferCoordinatesService
{
	public RideOfferCoordinatesService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void DeleteRideOfferCoordinates(int rideId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[1];

            param[0] = new System.Data.SqlClient.SqlParameter("rideOfferId", SqlDbType.Int);
            param[0].Value = rideId;

            SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "DeleteRideOfferCoordinates", param);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }

    public void SaveRideOfferCoordinate(int rideOfferId,string xml)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[2];

            param[0] = new System.Data.SqlClient.SqlParameter("rideOfferId", SqlDbType.Int);
            param[0].Value = rideOfferId;

            param[1] = new System.Data.SqlClient.SqlParameter("coordinatesXml", SqlDbType.NText);
            param[1].Value = xml;

            SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "SaveRideOfferCoordinates", param);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }
}