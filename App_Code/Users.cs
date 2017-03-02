using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
    int userId;
    Int64 facebookId;
    string name;
    string email;
    string userPassword;
    int gender;
    DateTime creationDate;
    string picture;
    string phone;
    string isAdmin = "false";

	public Users(int userId, string name, string email, string userPassword, int gender, DateTime creationDate, string picture, string phone)
	{
        this.userId = userId;
        this.name = name;
        this.email = email;
        this.userPassword = userPassword;
        this.gender = gender;
        this.creationDate = creationDate;
        this.picture = picture;
        this.phone = phone;
	}

    public Users(string name, string email, string userPassword, int gender, string phone)
    {
        this.name = name;
        this.email = email;
        this.userPassword = userPassword;
        this.gender = gender;
        this.phone = phone;
    }

    public Users(Int64 facebookId, string name, string picture, string email, int gender, string phone)
    {
        this.facebookId = facebookId;
        this.name = name;
        this.picture = picture;
        this.email = email;
        this.gender = gender;
        this.phone = phone;
    }
    public Users(int userId, string name, string email, string userPassword, string picture, string phone)
    {
        this.userId = userId;
        this.name = name;
        this.email = email;
        this.userPassword = userPassword;
        this.picture = picture;
        this.phone = phone;
    }

    public Users()
    {

    }

    public void DeleteUser(int userId)
    {
        UsersService us = new UsersService();
        us.DeleteUser(userId);
    }

    public DataSet Admin_GetAllUsers()
    {
        UsersService us = new UsersService();
        return (us.Admin_GetAllUsers());
    }

    public void UpdateUserDetails()
    {
        UsersService us = new UsersService();
        us.UpdateUserDetails(this);
    }

    public void UpdateFaceBookUserDetails()
    {
        UsersService us = new UsersService();
        us.UpdateFacebookUserDetails(this);
    }

    public DataSet GetDetails(int userId)
    {
        UsersService us = new UsersService();
        return (us.GetDetails(userId));
    }

    public bool IsUserEmailExist(string email)
    {
        UsersService us = new UsersService();
        return (us.IsUserEmailExist(email));
    }

    public int IsUserExistsByFacebookId(Int64 facebookId)
    {
        UsersService us = new UsersService();
        return (us.IsUserExistsByFacebookId(facebookId));
    }
    public DataSet IsUserExistByEmailPass(string email,string password)
    {
        UsersService us = new UsersService();
        return (us.IsUserExistByEmailPass(email, password));
        //returns userId and isAdmin
    }

    public int InsertUser()
    {
        UsersService us = new UsersService();
        int tmp = us.InsertUser(this);
        return tmp;
    }

    public int InsertUserWithoutPicture()
    {
        UsersService us = new UsersService();
        int tmp = us.InsertUserWithoutPicture(this);
        return tmp;
    }

    public int InsertFacebookUser()
    {
        UsersService us = new UsersService();
        return us.InsertFacebookUser(this);
    }

    public void UpdateFacebookUser()
    {
        UsersService us = new UsersService();
        us.UpdateFacebookUserDetails(this);
    }

    public void UpdatePictureIdentityInUser(int userIdentity, string picture)
    {
        UsersService us = new UsersService();
        us.UpdatePictureIdentityInUser(picture, userIdentity);
    }

    public string GetPhone()
    {
        return phone;
    }

    public void SetPhone(string phone)
    {
        this.phone = phone;
    }

    public int GetUserId()
    {
        return userId;
    }

    public Int64 GetFacebookId()
    {
        return facebookId;
    }
    public string GetName()
    {
        return name;
    }
    public string GetEmail()
    {
        return email;
    }
    public string GetUserPassword()
    {
        return userPassword;
    }
    public int GetGender()
    {
        return gender;
    }
    public DateTime GetCreationDate()
    {
        return creationDate;
    }
    public string GetPicture()
    {
        return picture;
    }

    public void SetUserId(int userId)
    {
        this.userId = userId;
    }
    public void SetName(string name)
    {
        this.name = name;
    }
    public void SetEmail(string email)
    {
        this.email = email;
    }
    public void SetUserPassword(string userPassword)
    {
        this.userPassword = userPassword;
    }
    public void SetGender(int gender)
    {
        this.gender = gender;
    }
    public void SetCreationDate(DateTime creationDate)
    {
        this.creationDate = creationDate;
    }
    public void SetPicture(string picture)
    {
        this.picture = picture;
    }
    
}