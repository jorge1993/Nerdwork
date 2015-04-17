<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

<div style="float: left; margin-left: 5%";>
&nbsp;

<p>
<asp:ListBox ID="recievelist" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="30%" Width="100%" DataSourceID="SqlDataSourceMail" DataTextField="FK_nickname_idUser_0" DataValueField="FK_nickname_idUser_0">
            </asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSourceMail" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGenNHibernateConnectionString %>" SelectCommand="SELECT FK_nickname_idUser_0 FROM Messages WHERE (FK_nickname_idUser = @nickname) ORDER BY ID">
                <SelectParameters>
                    <asp:SessionParameter Name="nickname" SessionField="Name" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
    </p>
    <p>
    <asp:Button ID="select" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="SELECT" OnClick="Button_SelectSee"
                          />
  </p>
   
</div>
<div style="float: right; margin-right: 5%; height:50%; width:75% ";>
<asp:TextBox ID="message" runat="server" BorderColor="Black" ReadOnly="false" 
        Height="80%" Width="100%"></asp:TextBox>

</div>

<div style="float: left; margin-left:5%; width:20%">
<p>
<asp:Label id="destino" runat="server">ADDRESSEE</asp:Label>
</p>
<p>
<asp:TextBox ID="reciever" ReadOnly="true" Height="30%" Width="50%" BorderColor="Black" runat="server">
</asp:TextBox>
</p>
<p>
<asp:ListBox ID="sendlist" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="20%" Width="45%" DataSourceID="SqlDataSourceMessages" DataTextField="nickname" DataValueField="nickname">
            </asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGenNHibernateConnectionString %>" SelectCommand="SELECT nickname FROM Usuario WHERE (nickname != @nickname) ORDER BY nickname">
                <SelectParameters>
                    <asp:SessionParameter Name="nickname" SessionField="Name" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
    
  </p>
  <p>
  <asp:Button ID="select1" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="SELECT" OnClick="Button_SelectSend"
                          />
  </p>
   
</div>

<div style="float: right; margin-right: 5%; height:50%; width:70% ";>
SUBJECT <asp:TextBox ID="subject" runat="server" BorderColor="Black" Height="8%" Width="80%"></asp:TextBox>

<p style="float: right; margin-right: 5%; height:50%; width:100% ";>

<asp:TextBox ID="writebox" runat="server" BorderColor="Black" 
Height="100%" Width="100%"></asp:TextBox>
</p>
 

<p style="float: right; margin-right: 15%";>
                          <asp:Label id="Label1" runat="server"></asp:Label>

<asp:Button ID="Button" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="SEND" OnClick="Button_Send"
                          />
</p>
</div>
 
</asp:Content>

