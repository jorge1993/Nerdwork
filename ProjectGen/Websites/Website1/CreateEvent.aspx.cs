﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using System.Configuration;
using ProjectGenNHibernate.EN.Project;
using System.Data;
using ProjectGenNHibernate.Enumerated.Project;

public partial class CreateEvents : System.Web.UI.Page
{
    private DateTime timeInit;
    private DateTime timeEnd;

    protected void Page_Load(object sender, EventArgs e)
    {
        IList<HobbyEN> hobbydr = new List<HobbyEN>();
        IList<UsuarioEN> user_list = new List<UsuarioEN>();

        if (!IsPostBack)
        {
            HobbyCEN ho = new HobbyCEN();
            hobbydr = ho.GetHobbyAssign((string)Session["NAME"]);

            foreach (HobbyEN s in hobbydr)
                ListUserHobbies.Items.Add(s.Name);


            UsuarioCEN user_cen = new UsuarioCEN();
            user_list = user_cen.GetAllUsers();

            foreach (UsuarioEN u in user_list)
            {
                if (u.Nickname.Equals((string)Session["NAME"]) == false)
                {
                    ListBoxUsers.Items.Add(u.Nickname);
                }
            }

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


        protected void Button_Create(object sender, EventArgs e)
        {
            String name = TBname.Text;
            String des = description.Text;
            String state = estado.SelectedValue;
            String inicio = iniciotext.Text + " " + DropDownList1.SelectedValue + ":" + DropDownList2.SelectedValue;
            String final = fintext.Text + " " + DropDownList3.SelectedValue + ":" + DropDownList4.SelectedValue;
            String usuario = Session["Name"].ToString();


            EstadoEnum x;
            if (name == "")
            {
                Label1.Text = "Name is required";
                Label1.Visible = true;
            }
            else if (Calendar1.SelectedDate.AddHours(Convert.ToInt32(DropDownList1.SelectedValue)).AddMinutes(Convert.ToInt32(DropDownList2.SelectedValue)) > Calendar2.SelectedDate.AddHours(Convert.ToInt32(DropDownList3.SelectedValue)).AddMinutes(Convert.ToInt32(DropDownList4.SelectedValue)))
            {
                Label1.Text = "Invalid date: the init date shouldn't be greater then the end one";
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
            else if (ListEventHobbies.Items.Count==0)
            {
                Label1.Text = "Event's Hobbies are required";
                Label1.Visible = true;
            }
            else
            {

                if (state == "Private" || state == "Public")
                {
                    if (state == "Private")
                        x = EstadoEnum.Private;
                    else
                        x = EstadoEnum.Public;
                    IList<String> usuarios = new List<string>();
                    IList<String> hobbyevent = new List<string>();
                    EventosCEN evento = new EventosCEN();
                    
                    usuarios.Add(usuario);
                    foreach (ListItem s in ListBoxGroupUsers.Items)
                        usuarios.Add(s.Text);

                    int i;
                    for (i = 0; i < ListEventHobbies.Items.Count; i++)
                    {
                        ListItem item = ListEventHobbies.Items[i];
                        string itemText = item.Text;
                        hobbyevent.Add(itemText);
                    }

                    int id = evento.New_(name, des, x, inicio, final, usuarios);

                    evento.AddHobbies((Int32) id, hobbyevent);

                    Response.Redirect("~/UserEvents.aspx");
                }

                else
                {
                    Label1.Text = "State must be: 'Private' or 'Public'";
                    Label1.Visible = true;
                }
            }
           

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            timeInit = Calendar1.SelectedDate.Date;
            iniciotext.Text = Calendar1.SelectedDate.Date.Day + "/" + Calendar1.SelectedDate.Date.Month + "/" + Calendar1.SelectedDate.Date.Year;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeInit.AddMinutes(DropDownList1.SelectedIndex);
            iniciotext.Text = timeInit.Date.ToString();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeInit.AddSeconds(DropDownList2.SelectedIndex);
            iniciotext.Text = timeInit.Date.ToString();
        }
    // //
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            timeEnd = Calendar2.SelectedDate.Date;
            fintext.Text = Calendar2.SelectedDate.Date.Day + "/" + Calendar1.SelectedDate.Date.Month + "/" + Calendar1.SelectedDate.Date.Year;
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeEnd.AddMinutes(DropDownList3.SelectedIndex);
            fintext.Text = timeInit.Date.ToString();
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeEnd.AddSeconds(DropDownList4.SelectedIndex);
            fintext.Text = timeInit.Date.ToString();
        
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