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

            Row1[3] = listaHobbies;

            dt.Rows.Add(Row1);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }
}