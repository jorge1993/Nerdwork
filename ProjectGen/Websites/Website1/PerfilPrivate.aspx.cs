﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGenNHibernate.CEN.Project;
using System.Configuration;

public partial class PerfilPrivate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonPost_Click(object sender, EventArgs e)
    {
        String postDesc = TextBoxPost.Text;

        if (postDesc.Equals("") == false && ListPostHobbies.Items.Count > 0)
        {
            // Para controlar el ID de los Posts lo que se me ha ocurrido es consultar el número de filas
            // que tiene la tabla Post y aumentarlo en 1.
            // Pero cuando hagamos lo de borrar posts vamos a tener problemas. Lo que se podría hacer al
            // eliminarlos es modificar todos los ID de los mensajes posteriores.
            int postID = CountRows_PostTable();
            String postUser = Session["Name"].ToString();

            PostCEN post = new PostCEN();
            post.Create(postID, postDesc, postUser);
            
            int i;
            for (i = 0; i < ListPostHobbies.Items.Count; i++)
            {
                ListItem item = ListPostHobbies.Items[i];
                String itemText = item.Text;
                Insert_HobbyPost(postID, itemText);
            }
            
            LabelPosted.Text = "Posted correctly.";
            LabelPosted.Visible = true;
            TextBoxPost.Text = "";
            GridViewTimeline.DataBind();
            ListUserHobbies.DataBind();
            ListPostHobbies.Items.Clear();
        }

        else
        {
            LabelPosted.Text = "Post must have text and at least one hobby.";
            LabelPosted.Visible = true;
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
                ListPostHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListPostHobbies.ClearSelection();
            }
        }
    }

    protected void ButtonToLeft_Click(object sender, EventArgs e)
    {
        int i;
        for (i = 0; i < ListPostHobbies.Items.Count; i++)
        {
            ListItem item = ListPostHobbies.Items[i];
            if (item.Selected == true)
            {
                ListPostHobbies.Items.Remove(item);
                ListUserHobbies.Items.Add(item);

                ListUserHobbies.ClearSelection();
                ListPostHobbies.ClearSelection();
            }
        }
    }


    public int CountRows_PostTable()
    {
        String stmt = "SELECT COUNT(*) FROM Post";
        int count = 0;

        String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();

        SqlConnection thisConnection = new SqlConnection(con);
        SqlCommand cmdCount = new SqlCommand(stmt, thisConnection);
        
        thisConnection.Open();
        count = (int)cmdCount.ExecuteScalar();
        thisConnection.Close();

        return count;
    }

    public void Insert_HobbyPost(int postID, String hobbyText)
    {
        String stmt = "INSERT INTO hobby_post (FK_id_idPost,FK_name_idHobby) VALUES (@postID, @hobbyText)";
        
        String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();
        
        SqlConnection thisConnection = new SqlConnection(con);
        SqlCommand cmdInsert = new SqlCommand(stmt, thisConnection);
        cmdInsert.Parameters.AddWithValue("postID", postID);
        cmdInsert.Parameters.AddWithValue("hobbyText", hobbyText);

        thisConnection.Open();
        cmdInsert.ExecuteNonQuery();
        thisConnection.Close();
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
}