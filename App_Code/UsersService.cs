using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for UsersService
/// </summary>
public class UsersService
{
    public UsersService()
    {

    }

    public void DeleteUser(int userId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {

            var param = new System.Data.SqlClient.SqlParameter[1];

            param[0] = new System.Data.SqlClient.SqlParameter("userId", SqlDbType.Int);
            param[0].Value = userId;

            SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "DeleteUser", param);

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

    public DataSet Admin_GetAllUsers()
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[0];

            DataSet dt = new DataSet();
            dt = (SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "Admin_GetAllUsers", param));
            return dt;
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

    public void UpdateUserDetails(Users user)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {

            var param = new System.Data.SqlClient.SqlParameter[7];

            param[0] = new System.Data.SqlClient.SqlParameter("userId", SqlDbType.Int);
            param[0].Value = user.GetUserId();

            param[1] = new System.Data.SqlClient.SqlParameter("facebookId", SqlDbType.BigInt);
            param[1].Value = user.GetFacebookId();

            param[2] = new System.Data.SqlClient.SqlParameter("name", SqlDbType.NVarChar);
            param[2].Value = user.GetName();

            param[3] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[3].Value = user.GetEmail();

            param[4] = new System.Data.SqlClient.SqlParameter("password", SqlDbType.NVarChar);
            param[4].Value = user.GetUserPassword();

            param[5] = new System.Data.SqlClient.SqlParameter("picture", SqlDbType.NVarChar);
            param[5].Value = user.GetPicture();

            param[6] = new System.Data.SqlClient.SqlParameter("phone", SqlDbType.NVarChar);
            param[6].Value = user.GetPhone();

            SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "UpdateUserDetails", param);


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

    public void UpdateFacebookUserDetails(Users user)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {

            var param = new System.Data.SqlClient.SqlParameter[5];

            param[0] = new System.Data.SqlClient.SqlParameter("facebookId", SqlDbType.BigInt);
            param[0].Value = user.GetFacebookId();

            param[1] = new System.Data.SqlClient.SqlParameter("name", SqlDbType.NVarChar);
            param[1].Value = user.GetName();

            param[2] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[2].Value = user.GetEmail();

            param[3] = new System.Data.SqlClient.SqlParameter("picture", SqlDbType.NVarChar);
            param[3].Value = user.GetPicture();

            param[4] = new System.Data.SqlClient.SqlParameter("phone", SqlDbType.NVarChar);
            param[4].Value = user.GetPhone();

            SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "UpdateFacebookUser", param);


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


    public bool IsUserEmailExist(string email)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {

            var param = new System.Data.SqlClient.SqlParameter[1];

            param[0] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[0].Value = email;

            int tmp = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "IsUserEmailExist", param));
            if (tmp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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


    public int IsUserExistsByFacebookId(Int64 facebookId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[1];

            param[0] = new System.Data.SqlClient.SqlParameter("facebookId", SqlDbType.BigInt);
            param[0].Value = facebookId;

            DataSet ds = (SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "IsUserExistByFacebookId", param));
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
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

    public DataSet IsUserExistByEmailPass(string email, string password)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[2];

            param[0] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[0].Value = email;

            param[1] = new System.Data.SqlClient.SqlParameter("password", SqlDbType.NVarChar);
            param[1].Value = password;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure, "IsUserExistByEmailPass", param);

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
    public DataSet GetDetails(int userId)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[1];

            param[0] = new System.Data.SqlClient.SqlParameter("userId", SqlDbType.Int);
            param[0].Value = userId;

            DataSet ds = new DataSet();
            ds = (SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "GetUserDetails", param));

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
    

    public int InsertFacebookUser(Users user)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[6];

            param[0] = new System.Data.SqlClient.SqlParameter("name", SqlDbType.NVarChar);
            param[0].Value = user.GetName();

            param[1] = new System.Data.SqlClient.SqlParameter("facebookId", SqlDbType.BigInt);
            param[1].Value = user.GetFacebookId();

            param[2] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[2].Value = user.GetEmail();

            param[3] = new System.Data.SqlClient.SqlParameter("gender", SqlDbType.Int);
            param[3].Value = user.GetGender();

            param[4] = new System.Data.SqlClient.SqlParameter("picture", SqlDbType.NVarChar);
            param[4].Value = user.GetPicture();

            param[5] = new System.Data.SqlClient.SqlParameter("phone", SqlDbType.NVarChar);
            param[5].Value = user.GetPhone();

            return Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "InsertFacebookUser", param).ToString());

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

    public int InsertUser(Users user)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {

            var param = new System.Data.SqlClient.SqlParameter[6];

            param[0] = new System.Data.SqlClient.SqlParameter("name", SqlDbType.NVarChar);
            param[0].Value = user.GetName();

            param[1] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[1].Value = user.GetEmail();

            param[2] = new System.Data.SqlClient.SqlParameter("userPassword", SqlDbType.NVarChar);
            param[2].Value = user.GetUserPassword();

            param[3] = new System.Data.SqlClient.SqlParameter("gender", SqlDbType.Int);
            param[3].Value = user.GetGender();

            param[4] = new System.Data.SqlClient.SqlParameter("picture", SqlDbType.NVarChar);
            param[4].Value = user.GetPicture();

            param[5] = new System.Data.SqlClient.SqlParameter("phone", SqlDbType.NVarChar);
            param[5].Value = user.GetPhone();

            return Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "InsertUser", param).ToString());

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

    public int InsertUserWithoutPicture(Users user)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[5];

            param[0] = new System.Data.SqlClient.SqlParameter("name", SqlDbType.NVarChar);
            param[0].Value = user.GetName();

            param[1] = new System.Data.SqlClient.SqlParameter("email", SqlDbType.NVarChar);
            param[1].Value = user.GetEmail();

            param[2] = new System.Data.SqlClient.SqlParameter("userPassword", SqlDbType.NVarChar);
            param[2].Value = user.GetUserPassword();

            param[3] = new System.Data.SqlClient.SqlParameter("gender", SqlDbType.Int);
            param[3].Value = user.GetGender();

            param[4] = new System.Data.SqlClient.SqlParameter("phone", SqlDbType.NVarChar);
            param[4].Value = user.GetPhone();

            return Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "InsertUserWithoutPicture", param).ToString());

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
    public void UpdatePictureIdentityInUser(string picture, int userIdentity)
    {
        var conn = MyAdoHelper.ConnectToDb("Database.mdf");
        try
        {
            var param = new System.Data.SqlClient.SqlParameter[2];

            param[0] = new System.Data.SqlClient.SqlParameter("userId", SqlDbType.Int);
            param[0].Value = userIdentity;

            param[1] = new System.Data.SqlClient.SqlParameter("picture", SqlDbType.NVarChar);
            param[1].Value = picture;

            SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "UpdatePictureInUser", param);

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


