using System;
using System.Collections.Generic;
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

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String nick = TextBox2.Text;
        String pass = TextBox7.Text;

        UserCEN user = new UserCEN();
        UserEN en = user.Searchbynick(nick);
        if (en != null)
        {  
            if (en.Password == pass)
            {
                Session["Name"] = nick;
                Response.Redirect("Default4.aspx");
            }
        }
        
        Label9.Text = "Invalid nickname/password";       
        Label9.Visible = true;
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        String email = TextBox5.Text;
        String nick = TextBox3.Text;
        String pass = TextBox4.Text;
        String conf = TextBox6.Text;
        Boolean ok = false;
        System.Collections.Generic.IList<string> p_hobby = null;

        UserCEN user = new UserCEN();
        user.Create(nick, email, pass, "", "", "", "", p_hobby);
        Label5.Text = "Register successfully";
        Label5.Visible = true;

    }

}