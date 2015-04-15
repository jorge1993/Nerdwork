using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        PostCEN post = new PostCEN();
        //post.Create(0,TextBox2.Text, (String) Session["Name"]);
        post.Create(  ,TextBox2.Text, (String)Session["Name"]);

    }
}