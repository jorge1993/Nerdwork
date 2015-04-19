﻿using System;
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


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String nick = TextBox2.Text;
        String pass = TextBox7.Text;
        IList<HobbyEN> lista;
        int RowCount = 0;

        UsuarioCEN user = new UsuarioCEN();
        if (user.Searchbynick(nick) != null)
        {
            UsuarioEN en = user.Searchbynick(nick);

            if (en.Password == pass)
            {
                Session["Name"] = nick;

                String con = ConfigurationManager.ConnectionStrings["ProjectGenNHibernateConnectionString"].ToString();
                SqlConnection sqlConnection1 = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM  hobby_user WHERE (FK_nickname_idUser = '" + nick + "')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.

                while (reader.HasRows && reader.Read())
                {
                    RowCount++;
                }
                sqlConnection1.Close();



                if (RowCount == 0)
                {
                    Response.Redirect("ModifyProfile.aspx");
                }
                else
                {
                    Response.Redirect("PerfilPrivate.aspx");
                }
            }
        }

        Label10.Text = "Invalid nickname/password";
        Label10.Visible = true;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        String email = TextBox5.Text;
        String nick = TextBox3.Text;
        String pass = TextBox4.Text;

        //Collection<HobbyEN> p_hobby;
        IList<HobbyEN> p_hobby = null;



        if (pass.Length >= 4 && pass.Length <= 16)
        {
            try
            {
                UsuarioCEN user = new UsuarioCEN();
                user.Create(nick, email, pass, "", "", "", "~/images/default_avatar.png", null);
                Label5.Text = "Register successfully";
                Label5.Visible = true;
            }
            catch (Exception ex)
            {
                Label5.Text = "Error: user already exists";
                Label5.Visible = true;
            }
        }
        else
        {
            Label5.Text = "Invalid Password: Length(4-16)";
            Label5.Visible = true;
        }

    }

}