using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for RideOfferService
/// </summary>
public class RideOfferService
{
	public RideOfferService()
	{
		
	}

    public int SaveRideOffer(RideOffer rideOffer)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[11];

            param[0] = new System.Data.SqlClient.SqlParameter("userId", SqlDbType.Int);
            param[0].Value = rideOffer.GetUserId();

            param[1] = new System.Data.SqlClient.SqlParameter("rideDate", SqlDbType.DateTime);
            param[1].Value = rideOffer.GetRideDate();

            param[2] = new System.Data.SqlClient.SqlParameter("minute", SqlDbType.Int);
            param[2].Value = rideOffer.GetMinute();

            param[3] = new System.Data.SqlClient.SqlParameter("hour", SqlDbType.Int);
            param[3].Value = rideOffer.GetHour();

            param[4] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[4].Value = rideOffer.GetEmail();

            param[5] = new System.Data.SqlClient.SqlParameter("phone", SqlDbType.NVarChar);
            param[5].Value = rideOffer.GetPhone();

            param[6] = new System.Data.SqlClient.SqlParameter("notes", SqlDbType.NVarChar);
            param[6].Value = rideOffer.GetNotes();

            param[7] = new System.Data.SqlClient.SqlParameter("price", SqlDbType.Int);
            param[7].Value = rideOffer.GetPrice();

            param[8] = new System.Data.SqlClient.SqlParameter("genderPref", SqlDbType.Int);
            param[8].Value = rideOffer.GetgenderPref();

            param[9] = new System.Data.SqlClient.SqlParameter("originName", SqlDbType.NVarChar);
            param[9].Value = rideOffer.GetOriginName();

            param[10] = new System.Data.SqlClient.SqlParameter("destinationName", SqlDbType.NVarChar);
            param[10].Value = rideOffer.GetDestinationName();


            return Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "SaveRideOffer", param).ToString());

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

    public DataSet getAllRideOffers()
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            DataSet ds = new DataSet();
            var param = new System.Data.SqlClient.SqlParameter[1];
         
            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetAllRideOffers", param);

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

    public DataSet getUserRideOffers(int UserId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            DataSet ds = new DataSet();
            var param = new System.Data.SqlClient.SqlParameter[1];
            param[0] = new System.Data.SqlClient.SqlParameter("UserId", SqlDbType.Int);
            param[0].Value = UserId;
            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetUserRideOffers", param);

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
    public void DeleteRideOffer(int rideId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[1];

            param[0] = new System.Data.SqlClient.SqlParameter("rideId", SqlDbType.Int);
            param[0].Value = rideId;

            SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "DeleteRideOffer", param);

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

    public DataTable getMatchRideOffer(int rideOfferId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            DataSet ds = new DataSet();
            var param = new System.Data.SqlClient.SqlParameter[1];

            param[0] = new System.Data.SqlClient.SqlParameter("rideOfferId", SqlDbType.Int);
            param[0].Value = rideOfferId;

            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetMatchRideOffer", param);

            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
        finally
        {
            conn.Close();
        }
    }
}