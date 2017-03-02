using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Users user = new Users();
            DataSet isExist = user.IsUserExistByEmailPass(email.Text, password.Text);//gets dataset with user details from database
            int userId = Convert.ToInt32(isExist.Tables[0].Rows[0]["UserId"]);
            int isAdmin = Convert.ToInt32(isExist.Tables[0].Rows[0]["IsAdmin"]);
            if (userId > 0)
            {
                Session["userId"] = userId;

                if (isAdmin == 1)
                    Session["isAdmin"] = "true";
                else
                    Session["isAdmin"] = null;
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Session["userId"] = null;
                Page.Header.Controls.Add(new LiteralControl("<script type='text/javascript'>alert('שם משתמש או סיסמא שגויים')</script>"));
            }
        }

    }
}