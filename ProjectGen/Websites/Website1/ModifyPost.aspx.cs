using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;

public partial class _ModifyPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {
            String postIDstring = Request.QueryString["ID"];
            int postIDint = int.Parse(postIDstring);

            PostCEN cen = new PostCEN();
            PostEN buscado = cen.GetByID(postIDint);

            if (buscado.User.Nickname.Equals((string)Session["NAME"]))
            {
                // La descripción es la misma que hay en la BD.
                TextBoxPost.Text = buscado.Description;

                // Se eliminan los hobbies del post para que el usuario los meta de nuevo.
                HobbyCEN hobby_cen = new HobbyCEN();
                IList<HobbyEN> listHobbyEN = new List<HobbyEN>();
                listHobbyEN = hobby_cen.GetHobbybyID(postIDint);

                List<String> listHobbyString = new List<String>();
                listHobbyString = listHobbyEN.Select(aux => aux.Name).ToList();

                cen.DeleteHobbies(postIDint, listHobbyString);
                
                // Se cargan los hobbies del usuario.
                IList<HobbyEN> hobbydr = new List<HobbyEN>();
                HobbyCEN ho = new HobbyCEN();
                hobbydr = ho.GetHobbyAssign((string)Session["NAME"]);

                foreach (HobbyEN s in hobbydr)
                {
                    ListUserHobbies.Items.Add(s.Name);
                }
            }

            else
            {

            }
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
                ListPostHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListPostHobbies.ClearSelection();
            }
        }
    }

    protected void ButtonToLeft_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListPostHobbies.Items.Count; i++)
        {
            ListItem item = ListPostHobbies.Items[i];
            if (item.Selected == true)
            {
                ListPostHobbies.Items.Remove(item);
                ListUserHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListPostHobbies.ClearSelection();
            }
        }
    }
    


    
    ////////////////////////////////////////////////////////////////////
    /******************************************************************
     * 
     * 
     * 
     * 
     * 
     * 
     * ****************************************************************/
    // Falta hacer esto
    protected void ButtonPost_Click(object sender, EventArgs e)
    {
        String postDesc = TextBoxPost.Text;

        if (postDesc.Equals("") == false && ListPostHobbies.Items.Count > 0)
        {

            String postUser = Session["Name"].ToString();

            PostCEN post = new PostCEN();
            int postID = post.Create(postDesc, postUser);

            List<String> post_hobbies = new List<string>();

            int i;
            for (i = 0; i < ListPostHobbies.Items.Count; i++)
            {
                ListItem item = ListPostHobbies.Items[i];
                String itemText = item.Text;
                post_hobbies.Add(itemText);
            }

            post.AddHobbies(postID, post_hobbies);

            LabelPosted.Text = "Posted correctly.";
            LabelPosted.Visible = true;
            TextBoxPost.Text = "";
            //reloadTimeLine(); // databind del timeline
            ListUserHobbies.DataBind();
            ListPostHobbies.Items.Clear();
        }

        else
        {
            LabelPosted.Text = "Post must have text and at least one hobby.";
            LabelPosted.Visible = true;
        }
        ListUserHobbies.Items.Clear();

        HobbyCEN ho = new HobbyCEN();
        IList<HobbyEN> hobbydr = new List<HobbyEN>();

        hobbydr = ho.GetHobbyAssign((string)Session["NAME"]);

        foreach (HobbyEN s in hobbydr)
            ListUserHobbies.Items.Add(s.Name);
    }
}