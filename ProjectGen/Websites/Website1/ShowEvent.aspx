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
    <asp:DropDownList ID="estadoTB" runat="server" Height="16px" Width="117px">
        <asp:ListItem>Public</asp:ListItem>
        <asp:ListItem>Private</asp:ListItem>
    </asp:DropDownList>
&nbsp;<p style="float:right; margin-right:30%">

</p>
</div>


<div style=" float:left; height:15%; width:50%";>
<p>
Description
</p>

<asp:TextBox ID="description" runat="server" BorderColor="Black" Readonly="true" Height="100%" 
        Width="100%" TextMode="MultiLine"></asp:TextBox>
</div>

<div style="float:left; margin-left:5%;">
<p>
&nbsp; Hobbies &nbsp;
<asp:TextBox ID="ListHobby" Height="3%" Width="140%" BorderColor="Black" Readonly="true" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Start"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" Height="3%" Width="60%" BorderColor="Black" Readonly="true" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="End"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" Height="3%" Width="70%" BorderColor="Black" Readonly="true" runat="server"></asp:TextBox>
</p>

</div>

<div style="float:left; margin-top:20%">

<asp:Button ID="ButtonModify" runat="server" Text="Modify" OnClick="ButtonSearch_Click" />
</div>
</asp:Content>

