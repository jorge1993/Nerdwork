using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using System.Configuration;
using ProjectGenNHibernate.EN.Project;
using System.Data;
using ProjectGenNHibernate.Enumerated.Project;

public partial class CreateEvents : System.Web.UI.Page
{
  

    protected void Page_Load(object sender, EventArgs e)
    {
        IList<HobbyEN> hobbydr = new List<HobbyEN>();

        if (!IsPostBack)
        {
            HobbyCEN ho = new HobbyCEN();
            hobbydr = ho.GetHobbyAssign((string)Session["NAME"]);

            foreach (HobbyEN s in hobbydr)
                ListUserHobbies.Items.Add(s.Name);

        }
    }


    protected void ButtonToRight_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListUserHobbies.Items.Count; i++)
        {
            ListItem item = ListUserHobbies.Items[i];
            if (item.Selected == true)
            {
                ListUserHobbies.Items.Remove(item);
                ListEventHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListEventHobbies.ClearSelection();
            }
        }
    }

    protected void ButtonToLeft_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListEventHobbies.Items.Count; i++)
        {
            ListItem item = ListEventHobbies.Items[i];
            if (item.Selected == true)
            {
                ListEventHobbies.Items.Remove(item);
                ListUserHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListEventHobbies.ClearSelection();
            }
        }
    }



        protected void Button_Create(object sender, EventArgs e)
        {
            String name = TBname.Text;
            String des = description.Text;
            String state = estado.SelectedValue;
            String usuario = Session["Name"].ToString();
           

            EstadoEnum x;
            if (name == "")
            {
                Label1.Text = "Name is required";
                Label1.Visible = true;
            }
            else if (state == "")
            {
                Label1.Text = "State is required";
                Label1.Visible = true;
            }
            else if (des == "")
            {
                Label1.Text = "Description is required";
                Label1.Visible = true;
            }
        
            else if (ListEventHobbies.Items.Count==0)
            {
                Label1.Text = "Group's Hobbies are required";
                Label1.Visible = true;
            }
            else
            {

                if (state == "Private" || state == "Public")
                {
                    if (state == "Private")
                        x = EstadoEnum.Private;
                    else
                        x = EstadoEnum.Public;

                    IList<String> usuarios = new List<string>();
                    usuarios.Add(usuario);

                    IList<String> event_hobbies = new List<string>();

                    GroupsCEN eve = new GroupsCEN();
                    
                    int id = eve.New_(name, des, x, usuarios);

                    int i;
                    for (i = 0; i < ListEventHobbies.Items.Count; i++)
                    {
                        ListItem item = ListEventHobbies.Items[i];
                        string itemText = item.Text;
                        event_hobbies.Add(itemText);
                    }

                    //int id = eve.GetAll().Count
                    eve.AddHobbies((Int32) id, event_hobbies);

                    Label1.Text = "Group Created";
                    Label1.Visible = true;
                    TBname.Text = "";
                    description.Text = "";
                    estado.Text = "";
                    ListUserHobbies.DataBind();
                    ListEventHobbies.Items.Clear();
                }

                else
                {
                    Label1.Text = "State must be: 'Private' or 'Public'";
                    Label1.Visible = true;
                }
            }
           

        }
    
}