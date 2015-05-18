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

        dr = eve.GetAllEventos();
        int size = dr.Count;

        DataTable dt = new DataTable();
        dt.Columns.Add("name", typeof(string));
        dt.Columns.Add("description", typeof(string));
        dt.Columns.Add("hobbies", typeof(string));

        UsuarioCEN u = new UsuarioCEN();
        UsuarioEN user = new UsuarioEN();
        user = u.Searchbynick((String)Session["NAME"]);

        foreach (EventosEN even in dr){
            DataRow Row1;
            Row1 = dt.NewRow();
            IList<EventosEN> use = new List<EventosEN>();

            EventosCEN eve3 = new EventosCEN();
            if (eve3.GetAllUser(even.Id).Contains(user))
            {
                Row1[0] = even.Name;
                Row1[1] = even.Description;

                string listaHobbies = "";
                IList<HobbyEN> listaHobby = new List<HobbyEN>();
                EventosCEN groupcen = new EventosCEN();
                listaHobby = groupcen.GetAllHobbies(even.Id);
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

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Busqueda.aspx?Hobby=" +
            TextbosSearch.Text + "&Show=All");
    }

    protected void EventLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton pressed = sender as LinkButton;
        String newUrl = "ShowEvent.aspx?name=" + pressed.Text;
        Response.Redirect(newUrl);
    }
}