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
                if(u.Nickname.Equals((string)Session["NAME"]) == false) {
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
            String usuario = Session["Name"].ToString();
           

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
        
            else if (ListEventHobbies.Items.Count==0)
            {
                Label1.Text = "Group's Hobbies are required";
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
                    usuarios.Add(usuario);

                    IList<String> event_hobbies = new List<string>();

                    GroupsCEN eve = new GroupsCEN();
                    
                    int id = eve.New_(name, des, x, usuarios);

                    int i;
                    for (i = 0; i < ListEventHobbies.Items.Count; i++)
                    {
                        ListItem item = ListEventHobbies.Items[i];
                        string itemText = item.Text;
                        event_hobbies.Add(itemText);
                    }

                    //int id = eve.GetAll().Count
                    eve.AddHobbies((Int32) id, event_hobbies);


                    for (i = 0; i < ListBoxGroupUsers.Items.Count; i++)
                    {
                        ListItem item = ListBoxGroupUsers.Items[i];
                        string itemText = item.Text;

                        UsuarioCEN user_cen = new UsuarioCEN();
                        UsuarioEN user_en = new UsuarioEN();
                        user_en = user_cen.Searchbynick(itemText);

                        IList<int> groupID_array = new List<int>();
                        groupID_array.Add(id);
                        user_cen.AddGroup(itemText, groupID_array);
                    }


                    Label1.Text = "Group Created";
                    Label1.Visible = true;
                    TBname.Text = "";
                    description.Text = "";
                    estado.Text = "";
                    ListUserHobbies.DataBind();
                    ListEventHobbies.Items.Clear();

                    Response.Redirect("~/UserGroups.aspx");
                }

                else
                {
                    Label1.Text = "State must be: 'Private' or 'Public'";
                    Label1.Visible = true;
                }
            }
           

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