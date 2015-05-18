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
        if (!IsPostBack)
        {
            if (Session["Name"] != null)
            {
                UsuarioCEN usuario = new UsuarioCEN();

                UsuarioEN usuario2 = new UsuarioEN();
                usuario2 = usuario.Searchbynick((String)Session["Name"]);

                Image1.ImageUrl = usuario2.Avatar;
                TextBoxName.Text = usuario2.Name;
                TextBoxSurname.Text = usuario2.Surname;
                TextBoxPhone.Text = usuario2.Phone;
                TextBoxEmail.Text = usuario2.Email;

            }
            HobbyCEN allhobby = new HobbyCEN();
            IList<HobbyEN> listaHobbies = new List<HobbyEN>();
            listaHobbies = allhobby.GetHobbyNotAssign((String)Session["Name"]);

            //ListAllHobbies.Items.Clear();
            for (int i = 0; i < listaHobbies.Count; i++)
            {
                ListAllHobbies.Items.Add(listaHobbies[i].Name);
            }

            HobbyCEN allhobbyuser = new HobbyCEN();
            IList<HobbyEN> listaHobbiesuser = new List<HobbyEN>();
            listaHobbiesuser = allhobbyuser.GetHobbyAssign((String)Session["Name"]);

            //ListUserHobbies.Items.Clear();
            for (int i = 0; i < listaHobbiesuser.Count; i++)
            {
                ListUserHobbies.Items.Add(listaHobbiesuser[i].Name);
            }
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
        UsuarioCEN us = new UsuarioCEN();
        UsuarioEN useren = new UsuarioEN();
        String password;
        useren = us.Searchbynick((String)Session["Name"]);
        String nombredefoto = useren.Avatar;

        if (TextBoxPassword.Text != "" && (TextBoxPassword.Text.Length >= 4))
            password = us.Encrypt( TextBoxPassword.Text);
        else password = useren.Password;

        if (FileUpload1.HasFile)
        {
            nombredefoto = "~/images/" + useren.Name + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(nombredefoto));
        }

        us.Modify(useren.Nickname, TextBoxEmail.Text, password, TextBoxName.Text, TextBoxSurname.Text, TextBoxPhone.Text, nombredefoto);
        
        HobbyCEN allhobbyuser = new HobbyCEN();
        IList<HobbyEN> listaHobbiesUser = allhobbyuser.GetHobbyAssign((String)Session["Name"]);
        IList<String> listaHobbieNew = new List<String>();
        IList<String> listaHobbieOld = new List<String>();

        for (int i = 0; i < listaHobbiesUser.Count; i++ )
            listaHobbieOld.Add(listaHobbiesUser[i].Name);

        for (int i = 0; i < ListUserHobbies.Items.Count; i++ )
            listaHobbieNew.Add(ListUserHobbies.Items[i].Text);

        UsuarioCEN user = new UsuarioCEN();
        user.DeleteHobbies(useren.Nickname, listaHobbieOld);
        user.AddHobbies(useren.Nickname, listaHobbieNew);

        Response.Redirect("PerfilPrivate.aspx");

    }
    protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {

    }
}