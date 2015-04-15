using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;

public partial class Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("First.aspx");
        }
        
        UserCEN user = new UserCEN();
        UserEN u = new UserEN();
        u = user.Searchbynick((String)Session["Name"]);
            userslist.Items.Add("NONE");
            sendlist.Items.Add("NONE");


    }

    protected void Button_Click(object sender, EventArgs e)
    {
        
    }
}