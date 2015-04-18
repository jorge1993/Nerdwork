using System;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

public partial class Messages : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

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
        String selected = "";

        for (i = 0; i < recievelist.Items.Count; i++)
        {
            ListItem item = recievelist.Items[i];
            if (item.Selected == true)
            {
                selected = item.Text;
                break;
            }
        }

        String stmt = "SELECT * from Messages";
        String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();

        SqlConnection thisConnection = new SqlConnection(con);
        SqlCommand cmdSelect = new SqlCommand(stmt, thisConnection);

        thisConnection.Open();

        SqlDataReader dr = cmdSelect.ExecuteReader();

        if (dr.HasRows)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("nickname", typeof(string));
            dt.Columns.Add("subject", typeof(string));
            dt.Columns.Add("description", typeof(String));
            
            while (dr.Read())
            {
                if (dr["FK_nickname_idUser"].Equals((String)Session["NAME"]) && dr["FK_nickname_idUser_0"].Equals(selected))
                {
                    
                    DataRow Row1;
                    Row1 = dt.NewRow();
                    Row1["nickname"] = dr["FK_nickname_idUser_0"];
                    Row1["subject"] = dr["subject"];
                    Row1["description"] = dr["description"];

                    dt.Rows.Add(Row1);
                    GridViewTimeline.DataSource = dt;
                    GridViewTimeline.DataBind();

                }

            }
        }

        thisConnection.Close();

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

        MessagesCEN mes = new MessagesCEN();
        
        String stmt1 = "SELECT MAX(ID) from Messages";
        String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();

        SqlConnection thisConnection = new SqlConnection(con);
        SqlCommand cmdSelect = new SqlCommand(stmt1, thisConnection);
        
        thisConnection.Open();

        SqlDataReader dr = cmdSelect.ExecuteReader();

        if (dr.HasRows)
        {
            dr.Read();
            ID = (int)dr[0]+1;
        }
        else
        {
            ID = 0;
        }       

        String stmt2 = "SELECT ID from Messages where ID = " + ID.ToString();

        mes.Create(ID, s, d, r, n);

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

    protected void GridViewTimeline_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}