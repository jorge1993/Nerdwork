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

        DataTable dt = new DataTable();
        dt.Columns.Add("description", typeof(string));
        dt.Columns.Add("hobbies", typeof(string));

        foreach (PostEN post in posts)
        {
            DataRow Row1;
            string listaHobbies = "";
            Row1 = dt.NewRow();

            Row1[0] = post.Description;

            IList<HobbyEN> listaHobby = new List<HobbyEN>();
            HobbyCEN hobbycen = new HobbyCEN();
            listaHobby = hobbycen.GetHobbybyID(post.Id);
            int aux = listaHobby.Count;
            int contador = 1;

            foreach (HobbyEN hobby in listaHobby)
            {
                listaHobbies += hobby.Name;
                if (aux != contador)
                    listaHobbies += " - ";
                contador++;
            }

            Row1[1] = listaHobbies;

            dt.Rows.Add(Row1);
            GridViewTimeline.DataSource = dt;
            GridViewTimeline.DataBind();
        }

        GroupsCEN g = new GroupsCEN();
        
        IList<GroupsEN> gen = new List<GroupsEN>();
        gen = g.SearchByName(Grupo);
        TBname.Text = gen[0].Name;
        description.Text = gen[0].Description;
        estado.SelectedIndex = (int)gen[0].State;

        UsuarioCEN u = new UsuarioCEN();
        UsuarioEN user = new UsuarioEN();

    }

    protected void ButtonPost_Click(object sender, EventArgs e) 
    {
        String postDesc = TextBoxPost.Text;

        if (postDesc.Equals(""))
        {

            String postUser = Session["Name"].ToString();

            PostCEN post = new PostCEN();
            post.Create(postDesc, postUser);

            List<String> post_hobbies = new List<string>();
            GroupsCEN g = new GroupsCEN();

            IList<GroupsEN> gen = new List<GroupsEN>();
            gen = g.SearchByName(Request.QueryString["name"]);
            IList<HobbyEN> listhobby = new List<HobbyEN>();
            listhobby=g.GetAllHobbies(gen[0].Id);
            int i;
            for (i = 0; i < listhobby.Count; i++)
            {
                
                post_hobbies.Add(listhobby[i].Name);
            }
           /* int postID = post.GetAllPost().Count;

            post.AddHobbies(postID, post_hobbies);

            LabelPosted.Text = "Posted correctly.";
            LabelPosted.Visible = true;
            TextBoxPost.Text = "";
            reloadTimeLine(); // databind del timeline
            ListUserHobbies.DataBind();
            ListPostHobbies.Items.Clear();*/
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