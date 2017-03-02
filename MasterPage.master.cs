using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    Users user = new Users();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            logoutLink.Visible = true;
            DataSet ds = user.GetDetails(Convert.ToInt32(Session["userId"]));
            Int64 facebookId = 0;
            string pictureUrl = ds.Tables[0].Rows[0]["picture"].ToString();

            userNameLabel.Text ="שלום "+ ds.Tables[0].Rows[0]["name"].ToString();
            if (ds.Tables[0].Rows[0]["facebookId"] != null && ds.Tables[0].Rows[0]["facebookId"].ToString() != "")
            {
                facebookId = Convert.ToInt64(ds.Tables[0].Rows[0]["facebookId"]);
            }

            if ((pictureUrl != "" && pictureUrl!= null) && (facebookId == null || facebookId==0))
            {
                picturePanel.ImageUrl = "~/images/" + pictureUrl;
            }
            else
            {
                picturePanel.ImageUrl = "~/images/default-user.png";
            }

            if ((string)Session["isAdmin"] == "true")
            {
                AdminPageLink.Visible = true;
                myTrempsLink.Visible = true;
                profileLink.Visible = true;
            }
            else
            {
                profileLink.Visible = true;
                myTrempsLink.Visible = true;
                AdminPageLink.Visible = false;
            }
        }
        else
        {
            AdminPageLink.Visible = false;
            LoginLink.Visible = true;
            int userId;
            if (userIdHidden.Text != "")
            {
                try
                {
                    userId = Convert.ToInt32(user.IsUserExistsByFacebookId(Convert.ToInt64(userIdHidden.Text)));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                int genderfacebook;

                if (userGenderHidden.Text == "male")
                {
                    genderfacebook = 0;
                }
                else
                {
                    genderfacebook = 1;
                }

                Users newUser = new Users(Int64.Parse(userIdHidden.Text), userNameHidden.Text, userPictureHidden.Text, userEmailHidden.Text, genderfacebook, userPhoneHidden.Text);

                if (userId > 0)
                {
                    newUser.UpdateFacebookUser();
                }
                else
                {
                    userId = newUser.InsertFacebookUser();
                }

                Session["userId"] = userId;
            }
            else
            {
                picturePanel.ImageUrl = "~/images/default-user.png";
            }
        }
    }
}
