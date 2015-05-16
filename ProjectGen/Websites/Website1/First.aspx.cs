using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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
        IList<HobbyEN> lista;
        int RowCount = 0;

        UsuarioCEN user = new UsuarioCEN();
        if (user.Searchbynick(nick) != null)
        {
            UsuarioEN en = user.Searchbynick(nick);

            if (en.Password == user.Encrypt(pass))
            {
                Session["Name"] = nick;

                if (!user.HasHobbies(nick))
                {
                    Response.Redirect("ModifyProfile.aspx");
                }
                else
                {
                    Response.Redirect("PerfilPrivate.aspx");
                }
            }
        }

        Label10.Text = "Invalid nickname/password";
        Label10.Visible = true;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        String email = TextBox5.Text;
        String nick = TextBox3.Text;
        Random passw = new Random(2000);
        String pass = ((int)(passw.Next() + 4000)).ToString();

        //Collection<HobbyEN> p_hobby;
        IList<HobbyEN> p_hobby = null;

        UsuarioCEN user = new UsuarioCEN();
        UsuarioEN useren = user.Searchbynick(nick);


        try
        {
            if (useren == null)
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("nerdworksocial@gmail.com", "vvV-7Pa-vGL-vCM");

                MailMessage mm = new MailMessage("nerdworksocial@gmail.com", TextBox5.Text, "Login for our awesome page", "This is your new password " + pass);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);


                user.Create(nick, email, user.Encrypt(pass), "", "", "", "~/images/default_avatar.png", null);
                Label5.Text = "Register successfully";
                Label5.Visible = true;
            }
            else
            {
                Label5.Text = "User or email already in use";
                Label5.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Label5.Text = "User or email already in use";
            Label5.Visible = true;
        }

        
        
    }

}