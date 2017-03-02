using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using TrempsService;

public partial class RegularRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string originalName="";
        string fileExtension="";
        Users user = new Users(name.Text, email.Text, password.Text, genderRadioList.SelectedIndex, phone.Text);
        int userIdentity;

        if (Page.IsValid)
        {
            if (!user.IsUserEmailExist(user.GetEmail()))//does user already exists
            {
                try
                {
                    userIdentity = user.InsertUserWithoutPicture();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                

                Boolean fileOK = false;
                if (pictureUpload.HasFile)
                {
                    fileExtension = System.IO.Path.GetExtension(pictureUpload.FileName).ToLower();
                    String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                    //}

                    originalName = Path.GetFileNameWithoutExtension(pictureUpload.PostedFile.FileName);
                    string fileName = pictureUpload.FileName;
                    fileExtension = Path.GetExtension(pictureUpload.FileName).ToLower();

                    if (fileOK)
                    {
                        try
                        {
                            pictureUpload.PostedFile.SaveAs(Server.MapPath("~") + "/images/" + originalName + userIdentity + fileExtension);
                        }
                        catch
                        {
                            pictureLabel.Text = "לא היה ניתן להעלות את התמונה. אנא נסה שוב.";
                        }
                    }
                    else
                    {
                        pictureLabel.Text = "לא ניתן להעלות קובץ מפורמט זה";
                    }


                    try
                    {
                        user.UpdatePictureIdentityInUser(userIdentity, (originalName + userIdentity + fileExtension));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    user.UpdatePictureIdentityInUser(userIdentity, "default-user.png");
                }

                Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('נרשמת בהצלחה!');</script>"));
                Response.Redirect("Login.aspx");
            }
            else
            {
                Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('האימייל כבר קיים במערכת');</script>"));
            }
        }
    }

    public void ValidatePassword(Object sender, ServerValidateEventArgs args)
    {
        //TrempsService.TrempsServiceSoapClient TrempsService = new TrempsService.TrempsServiceSoapClient();
        //args.IsValid = TrempsService.ValidatePassword(password.Text);
        args.IsValid = true;
        //this has been commented out because TrempsService is a service which is activated locally. In order to use it some changes in code are needed.
    }
}