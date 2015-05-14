﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.EN.Project;
using ProjectGenNHibernate.CEN.Project;
using ProjectGenNHibernate.Enumerated.Project;

public partial class CreateEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IList<HobbyEN> hobbydr = new List<HobbyEN>();

        if (!IsPostBack)
        {
            HobbyCEN ho = new HobbyCEN();
            hobbydr = ho.GetHobbyAssign((string)Session["NAME"]);

            foreach (HobbyEN s in hobbydr)
                ListUserHobbies.Items.Add(s.Name);

        }
    }


    protected void ButtonToRight_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListUserHobbies.Items.Count; i++)
        {
            ListItem item = ListUserHobbies.Items[i];
            if (item.Selected == true)
            {
                ListUserHobbies.Items.Remove(item);
                ListEventHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListEventHobbies.ClearSelection();
            }
        }
    }

    protected void ButtonToLeft_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListEventHobbies.Items.Count; i++)
        {
            ListItem item = ListEventHobbies.Items[i];
            if (item.Selected == true)
            {
                ListEventHobbies.Items.Remove(item);
                ListUserHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListEventHobbies.ClearSelection();
            }
        }
    }


        private void reloadTimeLine() 
        {/*
        
            IList<PostEN> dr = new List<PostEN>();
            PostCEN p = new PostCEN();

            dr = p.GetAllPost();
            int size = p.GetAllPost().Count;

            DataTable dt = new DataTable();
            dt.Columns.Add("avatar", typeof(string));
            dt.Columns.Add("nickname", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("hobbies", typeof(string));


            for (int j = 0; j < size; j++)
            {

                DataRow Row1;
                string listaHobbies = "";
                Row1 = dt.NewRow();
                UsuarioCEN us = new UsuarioCEN();
                UsuarioEN use = new UsuarioEN();

                use = us.Searchbynick(dr[j].User.Nickname);

                Row1[0] = use.Avatar;
                Row1[1] = use.Nickname;
                Row1[2] = dr[j].Description;

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
          */
        }

        protected void Button_Create(object sender, EventArgs e)
        {
            String name = TBname.Text;
            String des = description.Text;
            String state = estado.Text.ToLower();
            String inicio = iniciotext.Text;
            String lugar = Lugar.Text;
            String final = fintext.Text;
            String usuario = Session["Name"].ToString();
            TimeSpan init = new TimeSpan();
            TimeSpan end = new TimeSpan();

            EstadoEnum x;
            if (name == "")
            {
                Label1.Text = "Name is required";
                Label1.Visible = true;
            }
            else if (state == "")
            {
                Label1.Text = "State is required";
                Label1.Visible = true;
            }
            else if (des == "")
            {
                Label1.Text = "Description is required";
                Label1.Visible = true;
            }
            else if (inicio == "")
            {
                Label1.Text = "Start DateTime is required";
                Label1.Visible = true;
            }
            else if (final == "")
            {
                Label1.Text = "End DateTime is required";
                Label1.Visible = true;
            }
            else if (lugar == "")
            {
                Label1.Text = "Place is required";
                Label1.Visible = true;
            }
            else if (ListEventHobbies.Items.Count==0)
            {
                Label1.Text = "Event's Hobbies are required";
                Label1.Visible = true;
            }
            else
            {

                if (state == "private" || state == "public")
                {
                    if (state == "private")
                        x = EstadoEnum.Private;
                    else
                        x = EstadoEnum.Public;

                    IList<String> usuarios = new List<string>();
                    usuarios.Add(usuario);

                    IList<String> event_hobbies = new List<string>();

                    EventsCEN eve = new EventsCEN();
                    eve.New_(name, des, x, init, end, lugar, usuarios);

                    int i;
                    for (i = 0; i < ListEventHobbies.Items.Count; i++)
                    {
                        ListItem item = ListEventHobbies.Items[i];
                        string itemText = item.Text;
                        event_hobbies.Add(itemText);
                    }

                    int id = eve.GetAll().Count;
                    eve.AddHobbies(id, event_hobbies);

                    Label1.Text = "Event Created";
                    Label1.Visible = true;
                    TBname.Text = "";
                    description.Text = "";
                    estado.Text = "";
                    iniciotext.Text = "";
                    fintext.Text = "";
                    reloadTimeLine(); // databind del timeline
                    ListUserHobbies.DataBind();
                    ListEventHobbies.Items.Clear();
                }

                else
                {
                    Label1.Text = "State must be: 'Private' or 'Public'";
                    Label1.Visible = true;
                }
            }
           

        }
}