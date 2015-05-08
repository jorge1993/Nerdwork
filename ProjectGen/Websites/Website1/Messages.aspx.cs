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

public partial class Messages : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ProjectGenNHibernate.CEN.Project.MessagesCEN m = new ProjectGenNHibernate.CEN.Project.MessagesCEN();
        ProjectGenNHibernate.CEN.Project.UsuarioCEN m2 = new ProjectGenNHibernate.CEN.Project.UsuarioCEN();
        IList<String> dr = m.GetUserReceive((string)Session["NAME"]);
        IList<ProjectGenNHibernate.EN.Project.UsuarioEN> dr2 = m2.GetAllUsers();

        //recievelist.Items.Clear();
        
        if (!IsPostBack)
        {
            foreach (string s in dr)
            {
                recievelist.Items.Add(s);
            }

            foreach (ProjectGenNHibernate.EN.Project.UsuarioEN user in dr2)
            {
                if (user.Nickname != (string)Session["Name"])
                    sendlist.Items.Add(user.Nickname);
            }
        }
    }

    protected void NicknameLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "PublicProfile.aspx?nickname=" + pressed.Text;
        Response.Redirect(newUrl);
    }

    protected void Button_SelectSee(object sender, EventArgs e)
    {
        int i;
        
        string selected = recievelist.SelectedItem.Text;
       
        ProjectGenNHibernate.CEN.Project.MessagesCEN m = new ProjectGenNHibernate.CEN.Project.MessagesCEN();
        
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> dr;

        dr = m.GetReceive(selected, (string)Session["NAME"]);
         
        DataTable dt = new DataTable();
        dt.Columns.Add("nickname", typeof(string));
        dt.Columns.Add("subject", typeof(string));
        dt.Columns.Add("description", typeof(String));

        for (int j = 0; j < dr.Count; j++) {

            DataRow Row1;
            Row1 = dt.NewRow();
            Row1["nickname"] = selected;
            Row1["subject"] = dr[j].Subject;
            Row1["description"] = dr[j].Description;

            dt.Rows.Add(Row1);
            GridViewTimeline.DataSource = dt;
            GridViewTimeline.DataBind();
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

            if (mes.Create (s, d, r, n)!= -1)
            {
                Label1.Text = "Message has been sent.";
                Label1.Visible = true;
            }
            else
            {
                Label1.Text = "Message has not been sent.";
                Label1.Visible = true;
            }
        }

    }

    protected void GridViewTimeline_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}