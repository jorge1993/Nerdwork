using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;
using System.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Name"] != null) {
            UsuarioCEN usuario = new UsuarioCEN();

            UsuarioEN usuario2 = new UsuarioEN();
            usuario2 = usuario.Searchbynick((String)Session["Name"]);

            Image1.ImageUrl = usuario2.Avatar;
            SavedText.Text = "";
        }
    }

    protected void Toleft_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListAllHobbies.Items.Count; i++)
        {
            ListItem item = ListAllHobbies.Items[i];
            if (item.Selected == true)
            {
                ListAllHobbies.Items.Remove(item);
                ListUserHobbies.Items.Add(item);

                ListAllHobbies.ClearSelection();
                ListUserHobbies.ClearSelection();
            }
        }
    }
    protected void ToRight_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListUserHobbies.Items.Count; i++)
        {
            ListItem item = ListUserHobbies.Items[i];
            if (item.Selected == true)
            {
                ListUserHobbies.Items.Remove(item);
                ListAllHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListAllHobbies.ClearSelection();
            }
        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        UsuarioCEN usuario = new UsuarioCEN();

        UsuarioEN usuario2 = new UsuarioEN();
        usuario2 = usuario.Searchbynick((String)Session["Name"]);
        String nombredeusuario = usuario2.Name;
        String nombredefoto = Image1.ImageUrl;
        if (FileUpload1.FileName != "")
        {
            nombredefoto = "~/images/" + usuario2.Name + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(nombredefoto));
        }

        usuario.Modify(usuario2.Nickname, usuario2.Email, usuario2.Password, usuario2.Nickname, usuario2.Surname, usuario2.Phone, nombredefoto);

        String stmt2 = "Delete from hobby_user where FK_nickname_idUser=@nombredeusuario";

        String con2 = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();

        SqlConnection thisConnection2 = new SqlConnection(con2);
        SqlCommand cmdInsert2 = new SqlCommand(stmt2, thisConnection2);
        cmdInsert2.Parameters.AddWithValue("nombredeusuario", nombredeusuario);


        thisConnection2.Open();
        cmdInsert2.ExecuteNonQuery();
        thisConnection2.Close();

       int i;
       for (i = 0; i < ListUserHobbies.Items.Count; i++)
       {
            String hobbyinsert = ListUserHobbies.Items[i].Text;
            String stmt = "INSERT INTO hobby_user (FK_nickname_idUser,FK_name_idHobby) VALUES (@nombredeusuario, @hobbyinsert)";

            String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();

            SqlConnection thisConnection = new SqlConnection(con);
            SqlCommand cmdInsert = new SqlCommand(stmt, thisConnection);
            cmdInsert.Parameters.AddWithValue("nombredeusuario", nombredeusuario);
            cmdInsert.Parameters.AddWithValue("hobbyinsert", hobbyinsert);

            thisConnection.Open();
            try
            {
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Hago esto porque no entiendo el error que da al pulsar el botón Save sólo 
                // si es la primera vez que entro y sólo al guardar los hobbies.
                Save_Click(sender, e);
            }
            thisConnection.Close();
      }
       SavedText.Text = "Changes Saved";
       Response.Redirect("~/ModifyProfile.aspx");

    }
}