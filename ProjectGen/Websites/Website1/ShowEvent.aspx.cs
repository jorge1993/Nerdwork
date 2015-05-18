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
        String evento = Request.QueryString["name"];


        IList<EventosEN> eventen = new List<EventosEN>();
        EventosCEN eve = new EventosCEN();
        String hobbies = "";
        eventen = eve.SearchByName(evento);

        foreach (EventosEN en in eventen)
        {
            int sizeHo = en.Hobby.Count;
            int contador  =1;
            foreach (HobbyEN hobby in en.Hobby)
            {
                hobbies += hobby.Name;
                if (sizeHo != contador)
                    hobbies += " - ";
                contador++;
            }
            if (en.Name.Length == evento.Length)
            {
                eventname.Text = evento;
                description.Text = en.Description;
                ListHobby.Text = hobbies;
                TextBox1.Text = en.DateStart;
                TextBox2.Text = en.DateEnd;
                bool aux = false;

                foreach (UsuarioEN us in en.Usuario)
                {
                    if (us.Name == Session["Name"])
                        aux = true; break;
                }

                if (en.State == EstadoEnum.Private && aux!=true)
                {
                    estadoTB.Text = "Private";
                    TextBox1.Visible = false;
                    TextBox2.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                }
                else
                {
                    if (aux == true)
                        estadoTB.Text = "Private";
                    else
                        estadoTB.Text = "Public";

                    //direccion.Text = en.Place;
                    string auxinit = en.DateStart;
                    string auxned = en.DateEnd;

                    //TextBox1.Visible = false;
                    //TextBox2.Visible = false;
                }
            }
        }
    }

 
}