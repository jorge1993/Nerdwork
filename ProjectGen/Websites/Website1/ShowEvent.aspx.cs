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

        IList<HobbyEN> hobbydr = new List<HobbyEN>();
        IList<UsuarioEN> user_list = new List<UsuarioEN>();

        

        String evento = Request.QueryString["Name"];

        if (!IsPostBack)
        {

            UsuarioCEN user_cen = new UsuarioCEN();
            user_list = user_cen.GetAllUsers();

            EventosCEN ere = new EventosCEN();
            IList<EventosEN> tremor = ere.SearchByName(evento);



            foreach (UsuarioEN u in user_list)
            {
                if (u.Nickname.Equals((string)Session["NAME"]) == false)
                {
                    Boolean retro = false;
                    foreach (UsuarioEN u2 in tremor[0].Usuario)
                    {
                        if (u2.Nickname.Equals(u.Nickname) == true)
                            retro = true;

                    }
                    if (retro == false)
                        ListBoxUsers.Items.Add(u.Nickname);
                }

            }

            EventosCEN ere2 = new EventosCEN();
            IList<EventosEN> tremor2 = ere2.SearchByName(evento);

            foreach (UsuarioEN u3 in tremor2[0].Usuario)
            {
                if (Session["Name"].Equals(u3.Nickname))
                    Join1.Text = "Leave";
                else
                {
                    if (estadoTB.SelectedValue == "Public")
                        Join1.Text = "Join";
                    else
                        Join1.Visible = false;
                }
            }


            IList<EventosEN> eventen = new List<EventosEN>();
            EventosCEN eve = new EventosCEN();

            owner.Visible = false;
            ButtonModify.Enabled = false;

            eventen = eve.SearchByName(evento);

            IList<UsuarioEN> e_users = new List<UsuarioEN>();

            EventosCEN eve2 = new EventosCEN();
            e_users = eve2.GetAllUser(eventen[0].Id);

            if (Session["Name"].Equals(e_users[0].Nickname))
            {
                ButtonModify.Enabled = true;
            }

            String hobbies = "";


            foreach (EventosEN en in eventen)
            {
                int sizeHo = en.Hobby.Count;
                int contador = 1;
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
                        if (us.Nickname.Equals(Session["Name"]))
                            aux = true; break;
                    }

                    if (en.Usuario[0].Nickname.Equals(Session["Name"]))
                        owner.Visible = true;

                    if (en.State == EstadoEnum.Private && aux != true)
                    {
                        estadoTB.SelectedValue = "Private";
                        estadoTB.Enabled = false;
                        TextBox1.Visible = false;
                        TextBox2.Visible = false;
                        Label1.Visible = false;
                        Label2.Visible = false;
                        ButtonModify.Visible = false;
                        Delete.Visible = false;
                    }
                    else
                    {
                        if (aux == true && en.State == EstadoEnum.Private)
                        {
                            estadoTB.SelectedValue = "Private"; estadoTB.Enabled = false;


                        }
                        else if (aux == true && en.State == EstadoEnum.Public)
                        {
                            estadoTB.SelectedValue = "Public"; estadoTB.Enabled = false;
                        }
                        else
                        {
                            estadoTB.SelectedValue = "Public"; estadoTB.Enabled = false;
                            tableInvitation.Visible = false;
                            ButtonModify.Visible = false;
                            Delete.Visible = false;
                        }

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
        us.AddGroup(Session["Name"].ToString(), newgroup);
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

        us.DeleteGroup(Session["Name"].ToString(), deletegroup);
        Response.Redirect("ShowGroup.aspx?name=" + Request.QueryString["name"]);
    }

    protected void ButtonModify_Click(object sender, EventArgs e)
    {
        if (ButtonModify.Text == "Save")
        {
            IList<EventosEN> gen = new List<EventosEN>();
            EventosCEN g = new EventosCEN();
            gen = g.SearchByName(Request.QueryString["name"]);

            EventosCEN g2 = new EventosCEN();
            String state = estadoTB.SelectedValue;
            EstadoEnum x;
            if (state == "Private")
                x = EstadoEnum.Private;
            else
                x = EstadoEnum.Public;

            g2.Modify(gen[0].Id, Request.QueryString["name"], description.Text, x, TextBox1.Text, TextBox2.Text);

            Response.Redirect("ShowEvent.aspx?name=" + Request.QueryString["name"]);
        }
        else
        {
            estadoTB.Enabled = true;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            description.ReadOnly = false;
            ButtonModify.Text = "Save";
        }
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        IList<EventosEN> gen = new List<EventosEN>();
        EventosCEN g = new EventosCEN();
        gen = g.SearchByName(Request.QueryString["name"]);

        EventosCEN g2 = new EventosCEN();
        IList<String> listaHobbies = g2.GetAllHobbies(gen[0].Id).Select(aux => aux.Name).ToList(); ;

        EventosCEN g3 = new EventosCEN();
        g3.DeleteHobbies(gen[0].Id, listaHobbies);

        g.Destroy(gen[0].Id);
        Response.Redirect("UserEvents.aspx");
    }

    

    protected void ButtonToRightUsers_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListBoxUsers.Items.Count; i++)
        {
            ListItem item = ListBoxUsers.Items[i];
            if (item.Selected == true)
            {
                ListBoxUsers.Items.Remove(item);
                ListBoxGroupUsers.Items.Add(item);

                ListBoxUsers.ClearSelection();
                ListBoxGroupUsers.ClearSelection();
            }
        }
    }

    protected void ButtonToLeftUsers_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListBoxGroupUsers.Items.Count; i++)
        {
            ListItem item = ListBoxGroupUsers.Items[i];
            if (item.Selected == true)
            {
                ListBoxGroupUsers.Items.Remove(item);
                ListBoxUsers.Items.Add(item);

                ListBoxUsers.ClearSelection();
                ListBoxGroupUsers.ClearSelection();
            }
        }
    }

 
}