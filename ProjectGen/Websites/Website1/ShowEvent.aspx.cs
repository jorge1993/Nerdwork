using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.EN.Project;
using ProjectGenNHibernate.Enumerated.Project;

public partial class ShowEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String evento = Request.QueryString["nickname"];

        EventsCEN eve = new EventsCEN();
        IList<EventsEN> eventen = new List<EventsEN>();
        eventen = eve.SearchByName(evento);

        foreach (EventsEN en in eventen)
        {
            if (en.Name.Length == evento.Length)
            {
                eventname.Text = evento;
                description.Text = en.Description;
                ListHobby.Text = "Hobbies";

                if (en.State == EstadoEnum.Private)
                {
                    estadoTB.Text = "Private";
                    place.Visible = false;
                    direccion.Visible = false;
                    TextBox1.Visible = false;
                    TextBox2.Visible = false;
                    TextBox3.Visible = false;
                    TextBox4.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                }
                else
                {
                    estadoTB.Text = "Public";
                    direccion.Text = en.Place;
                    TimeSpan auxinit = en.DateStart;
                    TimeSpan auxned = en.DateEnd;
                    DateTime aux = en.DateStart;
                    auxinit.D
                    TextBox1.Visible = false;
                    TextBox2.Visible = false;

                    TextBox3.Visible = false;
                    TextBox4.Visible = false;
                }
            }
        }
    }
}