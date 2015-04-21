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

        String stmt2 = "SELECT FK_name_idHobby FROM hobby_user WHERE FK_nickname_idUser=@nombredeusuario";
        String con2 = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();
        SqlConnection thisConnection2 = new SqlConnection(con2);
        SqlCommand cmdInsert2 = new SqlCommand(stmt2, thisConnection2);
        cmdInsert2.Parameters.AddWithValue("nombredeusuario", Session["Name"].ToString());

        thisConnection2.Open();

        SqlDataReader reader = cmdInsert2.ExecuteReader();
        List<String> user_OldHobbies = new List<String>();

        while (reader.Read())
        {
            String hobby_name = reader["FK_name_idHobby"].ToString();
            user_OldHobbies.Add(hobby_name);
        }

        thisConnection2.Close();

        usuario.DeleteHobbies(Session["Name"].ToString(), user_OldHobbies);

        List<String> user_hobbies = new List<string>();

        int i;
        for (i = 0; i < ListUserHobbies.Items.Count; i++)
        {
            String hobbyinsert = ListUserHobbies.Items[i].Text;
            user_hobbies.Add(hobbyinsert);
        }

        usuario.AddHobbies(Session["Name"].ToString(), user_hobbies);

        SavedText.Text = "Changes Saved";
        SavedPhotoLabel.Visible = true;
        Response.Redirect("~/ModifyProfile.aspx");
    }

    protected void Save_Avatar_Click(object sender, EventArgs e)
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
        SavedPhotoLabel.Text = "Changes Saved";
        SavedPhotoLabel.Visible = true;
        Response.Redirect("~/ModifyProfile.aspx");
    }
}