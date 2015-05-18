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

        g2.Modify(gen[0].Id, TBname.Text, description.Text, x);

        Response.Redirect("ShowGroup.aspx?name=" + TBname.Text);
    }
}