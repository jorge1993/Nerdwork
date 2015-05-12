using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.EN.Project;
using ProjectGenNHibernate.CEN.Project;

public partial class UserEvents : System.Web.UI.Page
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

    protected void NicknameLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "PublicProfile.aspx?nickname=" + pressed.Text;
        Response.Redirect(newUrl);
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

        protected void GridViewTimeline_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

        protected void Button_Create(object sender, EventArgs e)
        {


        }
}