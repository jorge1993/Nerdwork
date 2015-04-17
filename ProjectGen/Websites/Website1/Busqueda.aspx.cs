using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    String p_show;
    String p_hobby;

    protected void Page_Load(object sender, EventArgs e)
    {
       /* Post.Visible = false;
        Eventos.Visible = false;
        People.Visible = false;*/

        p_hobby = Request.QueryString["Hobby"];
        p_show = Request.QueryString["Show"];

        if (p_show == "All")
        {
            //Post.Visible = true;
            //Eventos.Visible = true;
            //People.Visible = true;
        }
        else if (p_show == "People")
        {
            GridView2.Visible = false;
            //People.Visible = true;
        }
        else if (p_show == "Posts")
        {
            GridView1.Visible = false;
        }
       /* else if (p_show == "Posts")
        {
            Post.Visible = true;
        }
        else if (p_show == "Events")
        {
            Eventos.Visible = true;
        }*/

        PeopleLink.NavigateUrl= "Busqueda.aspx?Hobby=" +
            p_hobby +"&Show=People";
        PostsLink.NavigateUrl = "Busqueda.aspx?Hobby=" +
            p_hobby +"&Show=Posts";
        EventsLink.NavigateUrl= "Busqueda.aspx?Hobby=" +
            p_hobby +"&Show=Events";
        AllLink.NavigateUrl= "Busqueda.aspx?Hobby=" +
            p_hobby +"&Show=All";

    }

    protected void  NicknameLinkButton_Click (object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "PublicProfile.aspx?nickname=" + pressed.Text;
        Response.Redirect(newUrl);
    }
}