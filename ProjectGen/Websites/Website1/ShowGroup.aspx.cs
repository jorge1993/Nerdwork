using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.Enumerated.Project;
public partial class ShowEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String Grupo = Request.QueryString["name"];

            tableInvitation.Visible = false;

            PostCEN p = new PostCEN();
            IList<PostEN> posts = new List<PostEN>();
            GroupsCEN g = new GroupsCEN();

            IList<GroupsEN> gen = new List<GroupsEN>();
            gen = g.SearchByName(Grupo);
            eventname.Text = gen[0].Name;
            TBname.Text = gen[0].Name;
            description.Text = gen[0].Description;

            if (gen[0].State.ToString().Equals("Public"))
            {
                estado.SelectedValue = "Public";
            }
            else
            {
                estado.SelectedValue = "Private";
            }

            GroupsCEN g_cen = new GroupsCEN();
            IList<UsuarioEN> g_users = new List<UsuarioEN>();

            g_users = g_cen.GetAllUsers(gen[0].Id);
            UsuarioEN propietario = g_users[0];

            OwnerLabel.Text = propietario.Nickname;

            if (propietario.Nickname.Equals((String)Session["Name"]))
            {
                Join1.Visible = false;
                Leave.Visible = false;
                Label2.Text = "You are the owner of this group";
                Label2.Visible = true;
                Delete.Visible = true;
                Button3.Visible = true;
            }
            else
            {
                UsuarioCEN user_cen = new UsuarioCEN();
                UsuarioEN user_en = new UsuarioEN();
                user_en = user_cen.Searchbynick((String)Session["Name"]);

                if (g_users.Contains(user_en))
                {
                    Join1.Visible = false;
                    Leave.Visible = true;
                    Label2.Text = "You are a member of this group";
                    Label2.Visible = true;
                    Delete.Visible = false;
                    Button3.Visible = false;
                }
                else
                {
                    if (gen[0].State.ToString().Equals("Public"))
                    {
                        Join1.Visible = true;
                        Leave.Visible = false;
                        Label2.Text = "You are not a member of this group";
                        Label2.Visible = true;
                        Delete.Visible = false;
                        Button3.Visible = false;
                        ButtonPost.Visible = false;
                        GridViewTimeline.Visible = false;
                    }
                    else
                    {
                        Join1.Visible = false;
                        Leave.Visible = false;
                        Label2.Text = "This is a private group";
                        Label2.Visible = true;
                        Delete.Visible = false;
                        Button3.Visible = false;
                        ButtonPost.Visible = false;
                        GridViewTimeline.Visible = false;
                    }
                }
            }

            GroupsCEN g2 = new GroupsCEN();
            posts = g2.GetAllPost(gen[0].Id);

            DataTable dt = new DataTable();
            dt.Columns.Add("avatar", typeof(string));
            dt.Columns.Add("nickname", typeof(string));
            dt.Columns.Add("description", typeof(string));

            foreach (PostEN post in posts)
            {
                DataRow Row1;
                Row1 = dt.NewRow();

                UsuarioCEN us = new UsuarioCEN();
                UsuarioEN use = new UsuarioEN();

                use = us.Searchbynick(post.User.Nickname);

                Row1[0] = use.Avatar;
                Row1[1] = use.Nickname;
                Row1[2] = post.Description;

                dt.Rows.Add(Row1);
                GridViewTimeline.DataSource = dt;
                GridViewTimeline.DataBind();
            }


            IList<UsuarioEN> allUsers_list = new List<UsuarioEN>();
            UsuarioCEN user_cen2 = new UsuarioCEN();
            allUsers_list = user_cen2.GetAllUsers();

            IList<UsuarioEN> groupUsers_list = new List<UsuarioEN>();
            GroupsCEN group = new GroupsCEN();
            groupUsers_list = group.GetAllUsers(gen[0].Id);

            IList<UsuarioEN> result_list = new List<UsuarioEN>();
            result_list = allUsers_list.Except(groupUsers_list).ToList();

            foreach (UsuarioEN u in result_list)
            {
                ListBoxUsers.Items.Add(u.Nickname);
            }

            foreach (UsuarioEN u in groupUsers_list)
            {
                ListBoxGroupUsers.Items.Add(u.Nickname);
            }
        }
    }

    protected void ButtonPost_Click(object sender, EventArgs e) 
    {
        String postDesc = TextBoxPost.Text;

        if (!postDesc.Equals(""))
        {

            String postUser = Session["Name"].ToString();

            PostCEN post = new PostCEN();
            
            post.Create(postDesc, postUser);
            

            List<String> post_hobbies = new List<string>();
            IList<HobbyEN> listhobby = new List<HobbyEN>();

            IList<GroupsEN> gen = new List<GroupsEN>();
            GroupsCEN g = new GroupsCEN();
            gen = g.SearchByName(Request.QueryString["name"]);

            GroupsCEN g2 = new GroupsCEN();
            listhobby = g2.GetAllHobbies(gen[0].Id);
            
          
            int i;
            for (i = 0; i < listhobby.Count; i++)
            {
                
                post_hobbies.Add(listhobby[i].Name);
            }
            int postID = post.GetAllPost().Count;

            post.AddHobbies(postID, post_hobbies);
            post.AddGroup(postID, gen[0].Id);
            LabelPosted.Text = "Posted correctly.";
            LabelPosted.Visible = true;
            TextBoxPost.Text = "";
            Response.Redirect("ShowGroup.aspx?name=" + Request.QueryString["name"]);
        }

        else
        {
            LabelPosted.Text = "Post must have text and at least one hobby.";
            LabelPosted.Visible = true;
        }
       /* ListUserHobbies.Items.Clear();

        HobbyCEN ho = new HobbyCEN();
        IList<HobbyEN> hobbydr = new List<HobbyEN>();

        hobbydr = ho.GetHobbyAssign((string)Session["NAME"]);

        foreach (HobbyEN s in hobbydr)
            ListUserHobbies.Items.Add(s.Name);*/
    }


    protected void NicknameLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "PublicProfile.aspx?nickname=" + pressed.Text;
        Response.Redirect(newUrl);
    }

    protected void Join1_Click(object sender, EventArgs e)
    {

         IList<GroupsEN> gen = new List<GroupsEN>();
            GroupsCEN g = new GroupsCEN();
            gen = g.SearchByName(Request.QueryString["name"]);

            GroupsCEN g2 = new GroupsCEN();
            
            g2.GetAllHobbies(gen[0].Id);
         UsuarioCEN us = new UsuarioCEN();
            UsuarioEN use = new UsuarioEN();
            //Descomentar cuando esté arreglado el metodo
            IList<int> newgroup = new List<int>();
            newgroup.Add(gen[0].Id);
           us.AddGroup(Session["Name"].ToString(),newgroup);
           Response.Redirect("ShowGroup.aspx?name=" + Request.QueryString["name"]);
    }

    protected void Leave_Click(object sender, EventArgs e)
    {
        IList<GroupsEN> gen = new List<GroupsEN>();
        GroupsCEN g = new GroupsCEN();
        gen = g.SearchByName(Request.QueryString["name"]);

        GroupsCEN g2 = new GroupsCEN();

        g2.GetAllHobbies(gen[0].Id);
        UsuarioCEN us = new UsuarioCEN();
        UsuarioEN use = new UsuarioEN();
        //Descomentar cuando esté arreglado el metodo
        IList<int> deletegroup = new List<int>();
        deletegroup.Add(gen[0].Id);
        
        us.DeleteGroup(Session["Name"].ToString(),deletegroup);
        Response.Redirect("ShowGroup.aspx?name=" + Request.QueryString["name"]);
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        IList<GroupsEN> gen = new List<GroupsEN>();
        GroupsCEN g = new GroupsCEN();
        gen = g.SearchByName(Request.QueryString["name"]);

        GroupsCEN g2 = new GroupsCEN();
        IList<String> listaHobbies = g2.GetAllHobbies(gen[0].Id).Select(aux => aux.Name).ToList();;

        GroupsCEN g3 = new GroupsCEN();
        g3.DeleteHobbies(gen[0].Id, listaHobbies);

        g.Destroy(gen[0].Id);
        Response.Redirect("UserGroups.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        TBname.Enabled = true;
        estado.Enabled = true;
        description.Enabled = true;
        Button3.Visible = false;
        Save.Visible = true;
        ButtonPost.Visible = false;
        tableInvitation.Visible = true;
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        IList<GroupsEN> gen = new List<GroupsEN>();
        GroupsCEN g = new GroupsCEN();
        gen = g.SearchByName(Request.QueryString["name"]);

        GroupsCEN g2 = new GroupsCEN();
        String state = estado.SelectedValue;
        EstadoEnum x;
        if (state == "Private")
            x = EstadoEnum.Private;
        else
            x = EstadoEnum.Public;

        IList<UsuarioEN> groupUsers_list = new List<UsuarioEN>();
        GroupsCEN group = new GroupsCEN();
        groupUsers_list = group.GetAllUsers(gen[0].Id);

        g2.Modify(gen[0].Id, TBname.Text, description.Text, x);

        int i = 0;
        for (i = 0; i < ListBoxGroupUsers.Items.Count; i++)
        {
            ListItem item = ListBoxGroupUsers.Items[i];
            string itemText = item.Text;

            UsuarioCEN user_cen = new UsuarioCEN();
            UsuarioEN user_en = new UsuarioEN();
            user_en = user_cen.Searchbynick(itemText);


            if (groupUsers_list.Contains(user_en) == false)
            {
                IList<int> groupID_array = new List<int>();
                groupID_array.Add(gen[0].Id);
                user_cen.AddGroup(itemText, groupID_array);
            }
        }

        Response.Redirect("ShowGroup.aspx?name=" + TBname.Text);
    }

    protected void ButtonToRightUsers_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListBoxUsers.Items.Count; i++)
        {
            ListItem item = ListBoxUsers.Items[i];
            if (item.Selected == true)
            {
                ListBoxUsers.Items.Remove(item);
                ListBoxGroupUsers.Items.Add(item);

                ListBoxUsers.ClearSelection();
                ListBoxGroupUsers.ClearSelection();
            }
        }
    }

    protected void ButtonToLeftUsers_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListBoxGroupUsers.Items.Count; i++)
        {
            ListItem item = ListBoxGroupUsers.Items[i];
            if (item.Selected == true)
            {
                ListBoxGroupUsers.Items.Remove(item);
                ListBoxUsers.Items.Add(item);

                ListBoxUsers.ClearSelection();
                ListBoxGroupUsers.ClearSelection();
            }
        }
    }
}