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
                sendlist.Items.Remove(item);
                break;
            }
        }
    }

    protected void Button_Send(object sender, EventArgs e)
    {
        int ID;
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

            String stmt1 = "SELECT MAX(ID) from Messages";
            String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();

            SqlConnection thisConnection = new SqlConnection(con);
            SqlCommand cmdSelect = new SqlCommand(stmt1, thisConnection);

            thisConnection.Open();

            SqlDataReader dr = cmdSelect.ExecuteReader();

            if (dr.HasRows)
            {
                try
                {
                    dr.Read();
                    ID = (int)dr[0] + 1;
                }
                catch (Exception ex)
                {
                    ID = 0;
                }
            }
            else
            {
                ID = 0;
            }

            String stmt2 = "SELECT ID from Messages where ID = " + ID.ToString();

            mes.Create(s, d, r, n);

            SqlCommand cmdSelect2 = new SqlCommand(stmt2, thisConnection);

            dr.Close();

            SqlDataReader dr2 = cmdSelect.ExecuteReader();

            if (dr2.HasRows)
            {
                Label1.Text = "Message has been sent.";
                Label1.Visible = true;
            }
            else
            {
                Label1.Text = "Message has not been sent.";
                Label1.Visible = true;
            }

            dr.Close();
        }

    }
}