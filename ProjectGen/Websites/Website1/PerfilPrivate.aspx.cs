using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using System.Configuration;
using ProjectGenNHibernate.EN.Project;
using System.Data;

public partial class PerfilPrivate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IList<PostEN> dr = new List<PostEN>();
        PostCEN p = new PostCEN();
        int size = p.GetMax();
        //dr = p.GetMax();

        DataTable dt = new DataTable();
        dt.Columns.Add("avatar", typeof(string));
        dt.Columns.Add("nickname", typeof(string));
        dt.Columns.Add("descripton", typeof(string));
        dt.Columns.Add("hobbies", typeof(string));

        for (int j = 0; j < size; j++)
        {

            DataRow Row1;
            string listaHobbies = "";
            Row1 = dt.NewRow();
            UsuarioCEN us = new UsuarioCEN();
            UsuarioEN use = new UsuarioEN();
            //use = dr[j].User;
            use = us.Searchbynick(dr[j].User.Nickname);
           
            Row1[0] = use.Avatar ;
            Row1[1] = dr[j].User.Nickname;
            Row1[2] = dr[j].Description;

            IList<HobbyEN> listaHobby = dr[j].Hobby;
            
            int tam = 1;

            for (int i = 0; i < tam; i++)
            {
                HobbyCEN hobb = new HobbyCEN();
                HobbyEN hob = new HobbyEN();

                HobbyEN ho = listaHobby[i];

                listaHobbies += ho.Post + " ";
            }
            Row1[3] = listaHobbies;

            dt.Rows.Add(Row1);
            GridViewTimeline.DataSource = dt;
            GridViewTimeline.DataBind();
        }

        //posts = p.ReadAll(0,p.GetMax());

        //GridViewTimeline.DataSource = 
    }

    protected void ButtonPost_Click(object sender, EventArgs e)
    {
        String postDesc = TextBoxPost.Text;

        if (postDesc.Equals("") == false && ListPostHobbies.Items.Count > 0)
        {
            // Para controlar el ID de los Posts lo que se me ha ocurrido es consultar el número de filas
            // que tiene la tabla Post y aumentarlo en 1.
            // Pero cuando hagamos lo de borrar posts vamos a tener problemas. Lo que se podría hacer al
            // eliminarlos es modificar todos los ID de los mensajes posteriores.
            int postID = CountRows_PostTable();
            String postUser = Session["Name"].ToString();

            PostCEN post = new PostCEN();
            post.Create(postDesc, postUser);

            List<String> post_hobbies = new List<string>();

            int i;
            for (i = 0; i < ListPostHobbies.Items.Count; i++)
            {
                ListItem item = ListPostHobbies.Items[i];
                String itemText = item.Text;
                post_hobbies.Add(itemText);
            }

            post.AddHobbies(postID, post_hobbies);
            
            LabelPosted.Text = "Posted correctly.";
            LabelPosted.Visible = true;
            TextBoxPost.Text = "";
            GridViewTimeline.DataBind();
            ListUserHobbies.DataBind();
            ListPostHobbies.Items.Clear();
        }

        else
        {
            LabelPosted.Text = "Post must have text and at least one hobby.";
            LabelPosted.Visible = true;
        }
    }

    protected void ButtonToRight_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListUserHobbies.Items.Count; i++)
        {
            ListItem item = ListUserHobbies.Items[i];
            if (item.Selected == true)
            {
                ListUserHobbies.Items.Remove(item);
                ListPostHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListPostHobbies.ClearSelection();
            }
        }
    }

    protected void ButtonToLeft_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListPostHobbies.Items.Count; i++)
        {
            ListItem item = ListPostHobbies.Items[i];
            if (item.Selected == true)
            {
                ListPostHobbies.Items.Remove(item);
                ListUserHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListPostHobbies.ClearSelection();
            }
        }
    }


    public int CountRows_PostTable()
    {
        String stmt = "SELECT COUNT(*) FROM Post";
        int count = 0;

        String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();

        SqlConnection thisConnection = new SqlConnection(con);
        SqlCommand cmdCount = new SqlCommand(stmt, thisConnection);
        
        thisConnection.Open();
        count = (int)cmdCount.ExecuteScalar();
        thisConnection.Close();

        return count;
    }

    protected void NicknameLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "PublicProfile.aspx?nickname=" + pressed.Text;
        Response.Redirect(newUrl);
    }
}