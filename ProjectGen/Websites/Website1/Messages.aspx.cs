using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
        
        UserCEN user = new UserCEN();
        UserEN u = new UserEN();
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
        String s = subject.Text;
        String d = writebox.Text;
        String r = reciever.Text;
        String n = Session["NAME"].ToString();

        //MessagesCEN mes = new MessagesCEN(1, subject, description, recieve, send);

    }
}