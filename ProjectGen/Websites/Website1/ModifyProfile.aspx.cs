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
        UsuarioEN usuario2 = new UsuarioEN();
        usuario2 = usuario.Searchbynick((String)Session["Name"]);
        if (FileUpload1.HasFile)
        {
            usuario.Modify(usuario2.Nickname, TextBoxEmail.Text, TextBoxPassword.Text, TextBoxName.Text, TextBoxSurname.Text, TextBoxPhone.Text, FileUpload1.FileName);
        }
        else
        {
            usuario.Modify(usuario2.Nickname, TextBoxEmail.Text, TextBoxPassword.Text, TextBoxName.Text, TextBoxSurname.Text, TextBoxPhone.Text, usuario2.Avatar);
        }
    }


}