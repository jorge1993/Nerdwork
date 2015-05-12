using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate;
using ProjectGenNHibernate.CAD.Project;
using System.Collections.Generic;

public partial class Send : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProjectGenNHibernate.CEN.Project.UsuarioCEN m2 = new ProjectGenNHibernate.CEN.Project.UsuarioCEN();
        IList<ProjectGenNHibernate.EN.Project.UsuarioEN> dr2 = m2.GetAllUsers();

        //recievelist.Items.Clear();

        if (!IsPostBack)
        {
            foreach (ProjectGenNHibernate.EN.Project.UsuarioEN user in dr2)
            {
                if (user.Nickname != (string)Session["Name"])
                    sendlist.Items.Add(user.Nickname);
            }
        }

    }


    protected void Button_SelectSend(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < sendlist.Items.Count; i++)
        {
            ListItem item = sendlist.Items[i];
            if (item.Selected == true)
            {
                reciever.Text = item.Text;
                break;
            }
        }
    }

    protected void Button_Send(object sender, EventArgs e)
    {
        String s = subject.Text;
        String d = writebox.Text;
        String r = reciever.Text;
        String n = Session["NAME"].ToString();

        if (subject.Text == "" || subject.Text == null)
        {
            Label1.Text = "Subject is needed";
            Label1.Visible = true;
        }
        else if (writebox.Text == "" || writebox.Text == null)
        {
            Label1.Text = "A message is needed";
            Label1.Visible = true;
        }

        else if (reciever.Text == "" || reciever.Text == null)
        {
            Label1.Text = "A receiver is needed";
            Label1.Visible = true;
        }
        else
        {
            MessagesCEN mes = new MessagesCEN();

            try
            {
                mes.Create(s, d, r, n);

            }catch(Exception ex){
                
                Label1.Text = "Message has not been sent.";
                Label1.Visible = true;
            }

                Label1.Text = "Message has been sent.";
                Label1.Visible = true;

        }

    }
}