using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;
using System.Data;


public partial class UserGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        reloadTimeLine();
    }

    private void reloadTimeLine()
    {

        IList<GroupsEN> dr = new List<GroupsEN>();
        GroupsCEN eve = new GroupsCEN();

        dr = eve.GetAllGroups();
        int size = eve.GetAllGroups().Count;

        DataTable dt = new DataTable();
        dt.Columns.Add("name", typeof(string));
        dt.Columns.Add("description", typeof(string));
        dt.Columns.Add("hobbies", typeof(string));


        for (int j = 0; j < size; j++)
        {

            DataRow Row1;
            string listaHobbies = "";
            Row1 = dt.NewRow();
            IList<GroupsEN> use = new List<GroupsEN>();

            String nametolookfor = dr[j].Name;
            use = eve.SearchByName(dr[j].Name);
          

            Row1[0] = use[0].Name;
            Row1[1] = use[0].Description;
            

            IList<HobbyEN> listaHobby = new List<HobbyEN>();
            HobbyCEN hobbycen = new HobbyCEN();
            listaHobby = hobbycen.GetHobbybyID(dr[j].Id);
            int aux = listaHobby.Count;
            int contador = 1;

            foreach (HobbyEN hobby in listaHobby)
            {
                listaHobbies += hobby.Name;
                if (aux != contador)
                    listaHobbies += " - ";
                contador++;
            }

            Row1[2] = listaHobbies;

            dt.Rows.Add(Row1);
            GridViewTimeline.DataSource = dt;
            GridViewTimeline.DataBind();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////Aqui se muestra los grupos del usuario /////////////////////////////////////////////////////////////////////////////
       /* IList<GroupsEN> dr2 = new List<GroupsEN>();
        GroupsCEN eve2 = new GroupsCEN();
        UsuarioCEN u = new UsuarioCEN();
        UsuarioEN user = new UsuarioEN();
        user = u.Searchbynick((string)Session["NAME"]);
        u.

        dr2 = eve2.GetAllGroups();

        int size2 = eve.GetAllGroups().Count;
        
        DataTable dt2 = new DataTable();
        dt2.Columns.Add("name", typeof(string));
        dt2.Columns.Add("description", typeof(string));
        dt2.Columns.Add("hobbies", typeof(string));


        for (int j = 0; j < size; j++)
        {

            DataRow Row2;
            string listaHobbies = "";
            Row2 = dt.NewRow();
            IList<GroupsEN> use = new List<GroupsEN>();

            String nametolookfor = dr[j].Name;
            use = eve.SearchByName(dr[j].Name);


            Row2[0] = use[0].Name;
            Row2[1] = use[0].Description;


            IList<HobbyEN> listaHobby = new List<HobbyEN>();
            HobbyCEN hobbycen = new HobbyCEN();
            listaHobby = hobbycen.GetHobbybyID(dr[j].Id);
            int aux = listaHobby.Count;
            int contador = 1;

            foreach (HobbyEN hobby in listaHobby)
            {
                listaHobbies += hobby.Name;
                if (aux != contador)
                    listaHobbies += " - ";
                contador++;
            }

            Row2[2] = listaHobbies;

            dt.Rows.Add(Row2);
            GridView1.DataSource = dt2;
            GridView1.DataBind();
        }*/
    }

    protected void NicknameLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "ShowGroup.aspx?name=" + pressed.Text;
        Response.Redirect(newUrl);
    }

    protected void GridViewTimeline_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/CreateGroup.aspx");
    }
}