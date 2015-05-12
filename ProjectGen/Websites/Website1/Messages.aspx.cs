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
using ProjectGenNHibernate.EN.Project;

public partial class Messages : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ProjectGenNHibernate.CEN.Project.MessagesCEN m = new ProjectGenNHibernate.CEN.Project.MessagesCEN();       
        IList<String> dr = m.GetUserReceive((string)Session["NAME"]);
        IList<MessagesEN> dr2 = m.GetSend((string)Session["NAME"]);
        
        //recievelist.Items.Clear();
        
        if (!IsPostBack)
        {
            foreach(string s in dr)
            {
                recievelist.Items.Add(s);
            }

            foreach (MessagesEN mes in dr2)
            {               
                sendlist.Items.Add(mes.Userreceive.Nickname);                
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
        
        string selected = sendlist.SelectedItem.Text;
       
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

    protected void GridViewTimeline_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}