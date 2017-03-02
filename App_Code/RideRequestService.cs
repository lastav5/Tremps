using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for RideRequestService
/// </summary>
public class RideRequestService
{
	public RideRequestService()
	{
		
	}

    public DataSet GetAllRidesFilter(string rideType, string origin, string destination, DateTime rideDate, int minute, int hour, int genderPref)
    {
        DataSet ds = new DataSet();
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");

        try
        {
            var param = new System.Data.SqlClient.SqlParameter[7];

            param[0] = new System.Data.SqlClient.SqlParameter("rideType", SqlDbType.NVarChar);
            param[0].Value = rideType;
            param[1] = new System.Data.SqlClient.SqlParameter("origin", SqlDbType.NVarChar);
            param[1].Value = origin;
            param[2] = new System.Data.SqlClient.SqlParameter("destination", SqlDbType.NVarChar);
            param[2].Value = destination;
            param[3] = new System.Data.SqlClient.SqlParameter("rideDate", SqlDbType.DateTime);
            param[3].Value = rideDate;
            param[4] = new System.Data.SqlClient.SqlParameter("minute", SqlDbType.Int);
            param[4].Value = minute;
            param[5] = new System.Data.SqlClient.SqlParameter("hour", SqlDbType.Int);
            param[5].Value = hour;
            param[6] = new System.Data.SqlClient.SqlParameter("genderPref", SqlDbType.Int);
            param[6].Value = genderPref;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetAllRidesFilter", param);

            return ds;

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

    

    public void DeleteRideRequest(int rideId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {

            var param = new System.Data.SqlClient.SqlParameter[1];


            param[0] = new System.Data.SqlClient.SqlParameter("rideId", SqlDbType.Int);
            param[0].Value = rideId;

            SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "DeleteRideRequest", param);
            
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


    public int InsertRideRequest(RideRequest rideRequest)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
           
            var param = new System.Data.SqlClient.SqlParameter[15];


            param[0] = new System.Data.SqlClient.SqlParameter("userId", SqlDbType.Int);
            param[0].Value = rideRequest.GetUserId();

            param[1] = new System.Data.SqlClient.SqlParameter("rideDate", SqlDbType.DateTime);
            param[1].Value = rideRequest.GetRideDate();

            param[2] = new System.Data.SqlClient.SqlParameter("minute", SqlDbType.Int);
            param[2].Value = rideRequest.GetMinute();

            param[3] = new System.Data.SqlClient.SqlParameter("hour", SqlDbType.Int);
            param[3].Value = rideRequest.GetHour();

            param[4] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[4].Value = rideRequest.GetEmail();

            param[5] = new System.Data.SqlClient.SqlParameter("phone", SqlDbType.NVarChar);
            param[5].Value = rideRequest.GetPhone();

            param[6] = new System.Data.SqlClient.SqlParameter("notes", SqlDbType.NVarChar);
            param[6].Value = rideRequest.GetNotes();

            param[7] = new System.Data.SqlClient.SqlParameter("price", SqlDbType.Int);
            param[7].Value = rideRequest.GetPrice();

            param[8] = new System.Data.SqlClient.SqlParameter("genderPref", SqlDbType.Int);
            param[8].Value = rideRequest.GetgenderPref();

            param[9] = new System.Data.SqlClient.SqlParameter("originName", SqlDbType.NVarChar);
            param[9].Value = rideRequest.GetOriginName();

            param[10] = new System.Data.SqlClient.SqlParameter("destinationName", SqlDbType.NVarChar);
            param[10].Value = rideRequest.GetDestinationName();

            param[11] = new System.Data.SqlClient.SqlParameter("originX", SqlDbType.Real);
            param[11].Value = rideRequest.GetOriginX();

            param[12] = new System.Data.SqlClient.SqlParameter("originY", SqlDbType.Real);
            param[12].Value = rideRequest.GetOriginY();

            param[13] = new System.Data.SqlClient.SqlParameter("destinationX", SqlDbType.Real);
            param[13].Value = rideRequest.GetDestinationX();

            param[14] = new System.Data.SqlClient.SqlParameter("destinationY", SqlDbType.Real);
            param[14].Value = rideRequest.GetDestinationY();


            return Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "SaveRideRequest", param).ToString());
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


    public DataSet getAllRideRequests()
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            DataSet ds = new DataSet();
            var param = new System.Data.SqlClient.SqlParameter[0];
            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetAllRideRequests", param);

            return ds;
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

    public DataSet getUserRideRequests(int UserId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            DataSet ds = new DataSet();
            var param = new System.Data.SqlClient.SqlParameter[1];
            param[0] = new System.Data.SqlClient.SqlParameter("UserId", SqlDbType.Int);
            param[0].Value = UserId;
            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetUserRideRequests", param);

            return ds;
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
    public DataTable getMatchRideRequest(int rideRequestId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            DataSet ds = new DataSet();
            var param = new System.Data.SqlClient.SqlParameter[1];

            param[0] = new System.Data.SqlClient.SqlParameter("rideRequestId", SqlDbType.Int);
            param[0].Value = rideRequestId;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetMatchRideRequest", param);

            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            return null;
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }
}