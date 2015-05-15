<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ShowEvent.aspx.cs" Inherits="ShowEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <br />
<h2 style=" margin-left:40%;">
<asp:Label ID="eventname" runat="server" Text="eventname"></asp:Label>
</h2>
<div>
&nbsp; State &nbsp; 
    <asp:TextBox ID="estadoTB" Height="30%" Width="15%" Readonly="true" BorderColor="Black" runat="server"></asp:TextBox>
&nbsp;<p style="float:right; margin-right:30%">

</p>
</div>


<div style=" float:left; height:15%; width:50%";>
<p>
Description
</p>

<asp:TextBox ID="description" runat="server" BorderColor="Black" Readonly="true" Height="100%" 
        Width="100%"></asp:TextBox>
</div>

<div style="float:left; margin-left:5%;">
<p>
&nbsp; Hobbies &nbsp;
<asp:TextBox ID="ListHobby" Height="30%" Width="140%" BorderColor="Black" Readonly="true" runat="server">
</asp:TextBox>
</p>

</div>

<div style="float:left; margin-top:5%;">
<p>
<asp:Label ID="place" Text="Place" runat="server"></asp:Label>
<asp:TextBox ID="direccion" Height="30%" Width="150%" BorderColor="Black" Readonly="true" runat="server">
</asp:TextBox>
</p>

</div>

<div style="float:right;">
<p>
<asp:Label ID="Label1" Text="Start" runat="server"></asp:Label>
<asp:TextBox ID="TextBox1" Height="30%" Width="20%" BorderColor="Black" Readonly="true" runat="server">
</asp:TextBox>
<asp:TextBox ID="TextBox2" Height="30%" Width="20%" BorderColor="Black" Readonly="true" runat="server">
</asp:TextBox>
</p>
<p>
<asp:Label ID="Label2" Text="End" runat="server"></asp:Label>
<asp:TextBox ID="TextBox3" Height="30%" Width="20%" BorderColor="Black" Readonly="true" runat="server">
</asp:TextBox>
<asp:TextBox ID="TextBox4" Height="30%" Width="20%" BorderColor="Black" Readonly="true" runat="server">
</asp:TextBox>
</p>

</div>
</asp:Content>

