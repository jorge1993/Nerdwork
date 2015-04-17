using System;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;

public partial class Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("First.aspx");
        }
        
        UsuarioCEN user = new UsuarioCEN();
        UsuarioEN u = new UsuarioEN();
        u = user.Searchbynick((String)Session["Name"]);
            userslist.Items.Add("NONE");
            sendlist.Items.Add("NONE");


    }

    protected void Button_Select(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < sendlist.Items.Count; i++)
        {
            ListItem item = sendlist.Items[i];
            if (item.Selected == true)
            {
                reciever.Text = item.Text;
            }
        }
        
    }

    protected void Button_Send(object sender, EventArgs e)
    {
        int ID = 0;
        String s = subject.Text;
        String d = writebox.Text;
        String r = reciever.Text;
        String n = Session["NAME"].ToString();

        MessagesCEN mes = new MessagesCEN();

        mes.Create(ID, s, d, r, n);

        bool creado = false;

        if (creado == true)
        {
            Label1.Text = "Message has been sent.";
            Label1.Visible = true;
        }

        else
        {
            Label1.Text = "Message has not been sent.";
            Label1.Visible = true;
        }
        //MessagesCEN mes = new MessagesCEN(1, subject, description, recieve, send);

    }
}