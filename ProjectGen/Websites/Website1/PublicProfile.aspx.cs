using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String publicUser = Request.QueryString["nickname"];

        PostCEN p = new PostCEN();
        IList<PostEN> posts = new List<PostEN>();
        posts = p.GetUserPosts(publicUser);

        DataTable dt = new DataTable();
        dt.Columns.Add("description", typeof(string));
        dt.Columns.Add("hobbies", typeof(string));

        foreach (PostEN post in posts) 
        {
            DataRow Row1;
            string listaHobbies = "";
            Row1 = dt.NewRow();

            Row1[0] = post.Description;

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

            Row1[1] = listaHobbies;

            dt.Rows.Add(Row1);
            GridViewTimeline.DataSource = dt;
            GridViewTimeline.DataBind();
        }

        UsuarioCEN u = new UsuarioCEN();
        UsuarioEN user = new UsuarioEN();
        user = u.Searchbynick(publicUser);

        avatarPublic.ImageUrl = user.Avatar;
        avatarPublic.Width = 100;
        avatarPublic.Height = 100;
        nicknamePublic.Text = publicUser;
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Send.aspx?Nickname=" + nicknamePublic.Text);
    }
}