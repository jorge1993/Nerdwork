using System;
using System.Collections.Generic;
using System.Linq;
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        String email = TextBox5.Text;
        String nick = TextBox3.Text;
        Random passw = new Random(5000);
        String pass = ((int)(passw.Next() + 4030)).ToString();

        //Collection<HobbyEN> p_hobby;
        try
        {
            UsuarioCEN user = new UsuarioCEN();
            UsuarioEN useren = user.Searchbynick(nick);

            if (useren != null)
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("nerdworksocial@gmail.com", "vvV-7Pa-vGL-vCM");

                MailMessage mm = new MailMessage("nerdworksocial@gmail.com", TextBox5.Text, "Forget your Password?", "This is your new password " + pass);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);

                user.Modify(useren.Nickname, useren.Email, pass, useren.Name, useren.Surname, useren.Phone, useren.Avatar);
                //user.Create(nick, email, pass, "", "", "", "~/images/default_avatar.png", null);
                Label5.Text = "We send you an email with the new password";
            }
            else
            {
                Label5.Text = "The user didn't exist";
            }
                Label5.Visible = true;
        }
        catch (Exception ex)
        {
            Label5.Text = "User or email already in use";
            Label5.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("First.aspx");
    }
}