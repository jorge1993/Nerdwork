<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

<div style="height: 261px">

    <br />
&nbsp;

<asp:TextBox ID="userslist" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="165px"></asp:TextBox>
   
&nbsp;&nbsp;&nbsp;
   
<asp:TextBOx ID="message" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="184px" Width="584px"></asp:TextBOx>
</div>

<div style="height: 252px">
Hola
</div>
</asp:Content>

