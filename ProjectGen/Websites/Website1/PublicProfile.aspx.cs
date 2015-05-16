using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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

        if (publicUser.Equals((String)Session["Name"]))
        {
            ButtonMessage.Visible = false;
        }
        else
        {
            GridViewTimeline.Columns[2].Visible = false;
            GridViewTimeline.Columns[3].Visible = false;
            cabeceraTimeline.Rows[0].Cells[2].Visible = false;
        }
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Send.aspx?Nickname=" + nicknamePublic.Text);
    }

    protected void GridViewTimeline_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "modifyClick")
        {
            // Retrieve the row index stored in the CommandArgument property.
            int index = Convert.ToInt32(e.CommandArgument);
            // Retrieve the row that contains the button from the Rows collection.
            GridViewRow row = GridViewTimeline.Rows[index];

            // Code to modify the post.

            Response.Redirect("~/Send.aspx?Nickname=" + nicknamePublic.Text);
        }

        else if (e.CommandName == "deleteClick")
        {
            // Retrieve the row index stored in the CommandArgument property.
            int index = Convert.ToInt32(e.CommandArgument);
            // Retrieve the row that contains the button from the Rows collection.
            GridViewRow row = GridViewTimeline.Rows[index];

            // Code to delete the post.
            deletePost(row);
            Response.Redirect("~/PublicProfile.aspx?nickname=" + nicknamePublic.Text);
        }
    }

    protected void GridViewTimeline_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Redirect("~/Send.aspx?Nickname=" + nicknamePublic.Text);
    }


    public Boolean deletePost(GridViewRow row)
    {
        Boolean eliminado = false;

        // Para eliminar un post necesito su ID. Por lo que tengo que encontrarlo.
        String publicUser = (String)Session["Name"];
        PostCEN p = new PostCEN();
        IList<PostEN> posts = new List<PostEN>();
        posts = p.GetUserPosts(publicUser);

        foreach (PostEN post in posts)
        {
            String db_postText = post.Description;
            String selected_postText = HttpUtility.HtmlDecode(row.Cells[0].Text);

            if (selected_postText.Equals(db_postText))
            {
                // Ya he encontrado un post con la misma descripción.
                // Ahora tengo que comprobar que sus hobbies sean los mismos.
                // Por si hay algún post igual pero con otros hobbies.
                IList<HobbyEN> listaHobby = new List<HobbyEN>();
                HobbyCEN hobbycen = new HobbyCEN();
                listaHobby = hobbycen.GetHobbybyID(post.Id);

                // Tengo que separar todos los hobbies de la fila del gridView, compararlos con 
                // los del post que he encontrado en la BD y ver si coinciden todos.
                String listaHobbies = row.Cells[1].Text;
                String[] arrayHobbies = Regex.Split(listaHobbies, " - ");
                List<String> listaArrayHobbies = arrayHobbies.ToList();

                if (listaHobby.Count == listaArrayHobbies.Count)
                {
                    Boolean todosCorrectos = true;

                    foreach (HobbyEN hobby in listaHobby)
                    {
                        Boolean actualCorrecto = false;

                        foreach (String selected_HobbyName in listaArrayHobbies)
                        {
                            if (selected_HobbyName.Equals(hobby.Name))
                            {
                                actualCorrecto = true;
                                break;
                            }
                        }

                        if (actualCorrecto == false)
                        {
                            todosCorrectos = false;
                            break;
                        }
                    }

                    if (todosCorrectos)
                    {
                        PostCEN post_toDelete = new PostCEN();
                        int id_toDelete = post.Id;
                        post_toDelete.DeleteHobbies(id_toDelete, listaArrayHobbies);
                        post_toDelete.Delete(id_toDelete);
                        eliminado = true;
                        return eliminado;
                    }
                    else
                    {
                        // todosCorrectos == false;
                        eliminado = false;
                    }
                }
            }

            if (eliminado)
            {
                break;
            }
            
        }
        return eliminado;
    }
}