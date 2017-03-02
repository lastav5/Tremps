using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class UserProfile : System.Web.UI.Page
{
    public DataSet ds;
    Users user = new Users();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            ds = user.GetDetails(Convert.ToInt32(Session["userId"]));
        }

        if (!IsPostBack)
        {           
            if (Session["userId"] != null)
            {              
                //dataset gets everything but userID and isAdmin
                name.Text = ds.Tables[0].Rows[0]["name"].ToString();
                email.Text = ds.Tables[0].Rows[0]["email"].ToString();
                password.Text = ds.Tables[0].Rows[0]["password"].ToString();
                password.ReadOnly = true;
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["gender"]) == 0)
                    genderMale.Visible = true;
                else
                    genderFemale.Visible = true;

                if (ds.Tables[0].Rows[0]["phone"] != null)
                {
                    phone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                }
                picture.ImageUrl = "~/images/" + ds.Tables[0].Rows[0]["picture"].ToString();

            }
            else
            {
                Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('נא התחבר שוב');</script>"));
                Response.Redirect("Login.aspx");
            }
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            if (Page.IsValid)
            {
                string serverPath = Server.MapPath("~/images/");
                string originalName = Path.GetFileNameWithoutExtension(pictureUpload.PostedFile.FileName);
                string fileName = pictureUpload.FileName;
                string fileExtension = Path.GetExtension(pictureUpload.FileName).ToLower();
                string StrPicture = originalName + Session["userId"].ToString() + fileExtension;

                try
                {
                    if (pictureUpload.HasFile == true)
                    {
                        File.Delete(Server.MapPath("~/images/" + ds.Tables[0].Rows[0]["picture"].ToString()));
                        pictureUpload.PostedFile.SaveAs(serverPath + StrPicture);
                    }
                    else
                    {
                        StrPicture = ds.Tables[0].Rows[0]["picture"].ToString();
                    }
                    Users user = new Users(Convert.ToInt32(Session["userId"]), name.Text, email.Text, password.Text, StrPicture, phone.Text);
                    try
                    {
                        user.UpdateUserDetails();
                    }
                    catch
                    {
                        Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript' language='javascript'>alert('הייתה שגיאה במהלך השמירה')</script>"));
                    }
                    Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript' language='javascript'>DetailsSaved();</script>"));
                    picture.ImageUrl = "~/images/" + StrPicture;
                }
                catch
                {
                    PictureValidator.ErrorMessage = "לא היה ניתן להעלות את התמונה. אנא נסה שוב";
                    PictureValidator.IsValid = false;
                }
            }
        }
        else
        {
            Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript' language='javascript'>alert('נותקת מהאתר. אנא התחבר שוב')</script>"));
        }
    }

    public void ValidatePicture(object source, ServerValidateEventArgs args)
    {
        string fileExtension;
        PictureValidator.IsValid = false;
        PictureValidator.ErrorMessage = "לא ניתן להעלות תמונה מפורמט זה";
        if (pictureUpload.HasFile)
        {
            fileExtension = System.IO.Path.GetExtension(pictureUpload.FileName).ToLower();
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    PictureValidator.IsValid = true;                    
                }
            }
        }
        else
        {
            PictureValidator.IsValid = true;
        }
    
    }
}