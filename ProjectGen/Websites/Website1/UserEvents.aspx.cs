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


            foreach (EventosEN even in dr)
            {
                DataRow Row1;
                string listaHobbies = "";
                Row1 = dt.NewRow();
                IList<UsuarioEN> lista = eve.GetAllUser(even.Id);
                foreach (UsuarioEN u in lista)
                {
                    if (u.Nickname.Equals(Session["Name"]))
                    {
                        Row1[0] = even.Name;
                        Row1[1] = even.Description;
                    }
                }
                string list = "";

                EventosCEN evento = new EventosCEN();
                IList<HobbyEN> listaeve =  new List<HobbyEN>();
                listaeve = evento.GetAllHobbies(even.Id);
                foreach (HobbyEN ho in listaeve)
                { 
                    list += ho.Name + " - ";
                }
                Row1[2] = list;
                dt.Rows.Add(Row1);
            }
        GridViewTimeline.DataSource = dt;
        GridViewTimeline.DataBind();
          
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
        String newUrl = "ShowEvent.aspx?Name" + pressed.Text;
        Response.Redirect(newUrl);
    }
}