using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    private UserEN user;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count == 0)
        {
            Response.Redirect("First.aspx");
        }


        UserCEN u = new  UserCEN();
        user = new UserEN();
        user = u.Searchbynick((String)Session["Name"]);

        avatar.ImageUrl = user.Avatar;
        linkNickname.Text = user.Nickname;
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Busqueda.aspx?Hobby=" +
            TextBox1.Text);
    }
}
