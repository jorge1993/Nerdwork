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
    private UsuarioEN user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
           Response.Redirect("First.aspx");
        }
        
        UsuarioCEN u = new  UsuarioCEN();
        user = new UsuarioEN();
        user = u.Searchbynick((String)Session["Name"]);

        avatar.ImageUrl = user.Avatar;
        avatar.Width = 100;
        avatar.Height = 100;
        linkNickname.Text = user.Nickname;
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Busqueda.aspx?Hobby=" +
            TextBox1.Text +"&Show=All");
    }

    protected void LinkButtonLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/First.aspx", true);
    }
}
