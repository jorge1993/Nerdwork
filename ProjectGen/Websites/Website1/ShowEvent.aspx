<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ShowEvent.aspx.cs" Inherits="ShowEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<h2>
<asp:Label ID="eventname" runat="server" Text="eventname"></asp:Label>
</h2>
<div>
<p style="height: 55px">&nbsp; Name&nbsp; <asp:TextBox ID="TBname" Height="30%" Width="50%" BorderColor="Black" runat="server">
</asp:TextBox>
</div>
<div>
&nbsp; State &nbsp; 
    <asp:DropDownList ID="estado" runat="server" Height="16px" Width="117px">
        <asp:ListItem>Public</asp:ListItem>
        <asp:ListItem>Private</asp:ListItem>
    </asp:DropDownList>
&nbsp;<p style="float:right; margin-right:30%">

</p>
<p style="float:right;"></p>

<p>
Description
</p>

</div>
<div style=" float:left; height:15%; width:50%";>

<asp:TextBox ID="description" runat="server" BorderColor="Black" Height="100%" 
        Width="100%" TextMode="MultiLine"></asp:TextBox>
</div>

<div>
<p>
&nbsp; Place &nbsp;
<asp:TextBox ID="Lugar" Height="30%" Width="50%" BorderColor="Black" runat="server">
</asp:TextBox>
</p>
<p style="float: right; margin-right: 20%";>
                          <asp:Label id="Label1" runat="server"></asp:Label>

</p>

</div>
</asp:Content>

