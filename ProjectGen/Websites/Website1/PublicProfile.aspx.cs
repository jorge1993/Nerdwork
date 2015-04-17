using System;
using System.Collections.Generic;
using System.Configuration;
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

        UsuarioCEN u = new UsuarioCEN();
        UsuarioEN user = new UsuarioEN();
        user = u.Searchbynick(publicUser);

        avatarPublic.ImageUrl = user.Avatar;
        avatarPublic.Width = 100;
        avatarPublic.Height = 100;
        nicknamePublic.Text = publicUser;

        String stmt = "SELECT Post.description, hobby_post.FK_name_idHobby FROM Post INNER JOIN hobby_post ON Post.id = hobby_post.FK_id_idPost WHERE Post.FK_nickname_idUser = @nicknamePublic";
        String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();

        SqlConnection thisConnection = new SqlConnection(con);
        SqlCommand cmdSelect = new SqlCommand(stmt, thisConnection);
        cmdSelect.Parameters.AddWithValue("nicknamePublic", publicUser);

        thisConnection.Open();
        SqlDataReader dr = cmdSelect.ExecuteReader();
        GridViewTimeline.DataSource = dr;
        GridViewTimeline.DataBind();

        thisConnection.Close();
    }
}