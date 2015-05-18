using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;

public partial class _Default : System.Web.UI.Page
{
    String p_show;
    String p_hobby;

    private void post() 
    {
        IList<PostEN> dr = new List<PostEN>();
        PostCEN p = new PostCEN();

        dr = p.SearchByHobbies(p_hobby);
        //int size = p.SearchByHobbies(p_hobby).Count;

        DataTable dt = new DataTable();
        dt.Columns.Add("avatar", typeof(string));
        dt.Columns.Add("nickname", typeof(string));
        dt.Columns.Add("description", typeof(string));
        dt.Columns.Add("hobbies", typeof(string));

        foreach (PostEN post in dr)
        {
            if (post.Groups == null)
            {
                DataRow Row1;
                string listaHobbies = "";
                Row1 = dt.NewRow();
                UsuarioCEN us = new UsuarioCEN();
                UsuarioEN use = new UsuarioEN();

                use = us.Searchbynick(post.User.Nickname);

                Row1[0] = use.Avatar;
                Row1[1] = use.Nickname;
                Row1[2] = post.Description;

                IList<HobbyEN> listaHobby = new List<HobbyEN>();
                HobbyCEN hobbycen = new HobbyCEN();
                listaHobby = hobbycen.GetHobbybyID(post.Id);
                int aux = listaHobby.Count;
                int contador = 1;

                foreach (HobbyEN hobby in listaHobby)
                {
                    listaHobbies += hobby.Name;
                    if (aux != contador)
                        listaHobbies += " - ";
                    contador++;
                }

                Row1[3] = listaHobbies;

                dt.Rows.Add(Row1);
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
    }

    private void groups()
    {
        IList<GroupsEN> dr = new List<GroupsEN>();
        GroupsCEN pos = new GroupsCEN();

        dr = pos.SearchByHobbies(p_hobby);

        DataTable dt = new DataTable();
        dt.Columns.Add("name", typeof(string));
        dt.Columns.Add("description", typeof(string));
        dt.Columns.Add("hobbies", typeof(string));

        foreach (GroupsEN group in dr)
        {
            /*
            if (group.State.ToString() == "Public")
            {
             */
                DataRow Row1;
                string listaHobbies = "";
                Row1 = dt.NewRow();

                Row1[0] = group.Name;
                Row1[1] = group.Description;

                IList<HobbyEN> listaHobby = new List<HobbyEN>();
                HobbyCEN hobbycen = new HobbyCEN();
                listaHobby = hobbycen.GetHobbybyID(group.Id);
                int aux = listaHobby.Count;
                int contador = 1;

                foreach (HobbyEN hobby in listaHobby)
                {
                    listaHobbies += hobby.Name;
                    if (aux != contador)
                        listaHobbies += " - ";
                    contador++;
                }

                Row1[2] = listaHobbies;

                dt.Rows.Add(Row1);
                GridView3.DataSource = dt;
                GridView3.DataBind();
            /*}*/
        }
    }

    private void events()
    {
        IList<EventosEN> dr = new List<EventosEN>();
        EventosCEN eve = new EventosCEN();

        dr = eve.SearchByHobbie(p_hobby);

        DataTable dt = new DataTable();
        dt.Columns.Add("name", typeof(string));
        dt.Columns.Add("description", typeof(string));
        dt.Columns.Add("hobbies", typeof(string));

        foreach (EventosEN even in dr)
        {
            DataRow Row1;
            string listaHobbies = "";
            Row1 = dt.NewRow();

            Row1[0] = even.Name;
            Row1[1] = even.Description;

            IList<HobbyEN> listaHobby = new List<HobbyEN>();
            HobbyCEN hobbycen = new HobbyCEN();
            listaHobby = hobbycen.GetHobbybyID(even.Id);
            int aux = listaHobby.Count;
            int contador = 1;

            foreach (HobbyEN hobby in listaHobby)
            {
                listaHobbies += hobby.Name;
                if (aux != contador)
                    listaHobbies += " - ";
                contador++;
            }

            Row1[2] = listaHobbies;

            dt.Rows.Add(Row1);
            GridView4.DataSource = dt;
            GridView4.DataBind();
        }
    }

    private void people()
    {
        IList<UsuarioEN> dr = new List<UsuarioEN>();
        UsuarioCEN user = new UsuarioCEN();

        dr = user.SearchByHobbies(p_hobby);

        DataTable dt = new DataTable();
        dt.Columns.Add("avatar", typeof(string));
        dt.Columns.Add("nickname", typeof(string));

        foreach (UsuarioEN u in dr)
        {
            DataRow Row1;
            Row1 = dt.NewRow();

            Row1[0] = u.Avatar;
            Row1[1] = u.Nickname;

            dt.Rows.Add(Row1);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       /* Post.Visible = false;
        Eventos.Visible = false;
        People.Visible = false;*/

        p_hobby = Request.QueryString["Hobby"];
        p_show = Request.QueryString["Show"];

        if (p_show == "All")
        {
            people();
            events();
            groups();
            post();
        }
        else if (p_show == "People")
        {
            people();
        }
        else if (p_show == "Posts")
        {
            post();
        }
        else if (p_show == "Groups")
        {
            groups(); 
        }
        else if (p_show == "Events")
        {
            events();
        }

        PeopleLink.NavigateUrl= "Busqueda.aspx?Hobby=" +
            p_hobby +"&Show=People";
        GroupsLink.NavigateUrl = "Busqueda.aspx?Hobby=" +
            p_hobby + "&Show=Groups";
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

    protected void GroupLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "ShowGroup.aspx?name=" + pressed.Text;
        Response.Redirect(newUrl);
    }

    protected void EventLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "ShowEvent.aspx?name=" + pressed.Text;
        Response.Redirect(newUrl);
    }
}