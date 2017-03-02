using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Session["isAdmin"] == null)
        {
            Response.Redirect("NoAccess.aspx");
        }

        Users user = new Users();
        DataSet ds = new DataSet();
        try
        {
            ds = user.Admin_GetAllUsers();
        }
        catch(Exception ex)
        {
            throw ex;
        }
        DataTable dt = ds.Tables[0];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["picture"] = "~/images/" + dt.Rows[i]["picture"].ToString();
            dt.Rows[i]["creationDate"] = Convert.ToDateTime(dt.Rows[i]["creationDate"]).ToShortDateString();
        }

        UsersGridView.DataSource = dt;
        UsersGridView.DataBind();
    }

    protected void DeleteUser(object sender, GridViewDeleteEventArgs e)
    {
        Users user = new Users();
        try
        {
            user.DeleteUser(Convert.ToInt32(e.Keys["userId"]));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void UsersGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = UsersGridView.SelectedIndex;
        Response.Redirect("EditUserDetailsByAdmin.aspx?userId=" + UsersGridView.Rows[index].Cells[0].Text);
    }
}