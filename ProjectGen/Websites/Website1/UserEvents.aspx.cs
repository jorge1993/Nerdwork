using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;
using System.Data;

public partial class UserEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        reloadTimeLine();
    }

    private void reloadTimeLine()
    {
        
            IList<EventosEN> dr = new List<EventosEN>();
            EventosCEN eve = new EventosCEN();

            dr = eve.GetAll();
            int size = dr.Count;

            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("place", typeof(string));
            dt.Columns.Add("hobbies", typeof(string));


            for (int j = 0; j < size; j++)
            {

                DataRow Row1;
                string listaHobbies = "";
                Row1 = dt.NewRow();
                IList<EventosEN> use = new List<EventosEN>();

                use = eve.SearchByName(dr[j].Name);

                Row1[0] = use[0].Name;
                Row1[1] = use[0].Description;
                Row1[2] = use[0].Place;

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
                GridViewTimeline.DataSource = dt;
                GridViewTimeline.DataBind();
            }
          
    }


    protected void NicknameLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "PublicProfile.aspx?nickname=" + pressed.Text;
        Response.Redirect(newUrl);
    }

    protected void GridViewTimeline_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button_Create(object sender, EventArgs e)
    {
        Response.Redirect("~/CreateEvent.aspx");
    }
}