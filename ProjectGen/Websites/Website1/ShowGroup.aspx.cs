using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String Grupo = Request.QueryString["name"];

        
        PostCEN p = new PostCEN();
        IList<PostEN> posts = new List<PostEN>();
        //Aquí tiene que recoger todos los posts de ese grupo)
        //posts = p.
       // posts = p.GetUserPosts(publicUser);
        GroupsCEN g = new GroupsCEN();

        IList<GroupsEN> gen = new List<GroupsEN>();
        gen = g.SearchByName(Grupo);
        TBname.Text = gen[0].Name;
        description.Text = gen[0].Description;
        estado.SelectedIndex = (int)gen[0].State;

        GroupsCEN g2 = new GroupsCEN();
        posts = g2.GetAllPost(gen[0].Id);
     
        
        DataTable dt = new DataTable();
        dt.Columns.Add("avatar", typeof(string));
        dt.Columns.Add("nickname", typeof(string));
        dt.Columns.Add("description", typeof(string));
      

        foreach (PostEN post in posts)
        {
            DataRow Row1;
            string listaHobbies = "";
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
            
            listhobby=g2.GetAllHobbies(gen[0].Id);
          
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
}