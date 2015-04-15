<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

<div style="float: left; margin-left: 5%";>
&nbsp;

<asp:ListBox ID="userslist" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="20%" Width="100%">
    </asp:ListBox>
  
   
</div>
<div style="float: right; margin-right: 5%; height:50%; width:75% ";>
<asp:TextBox ID="message" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="80%" Width="100%"></asp:TextBox>

</div>

<div style="float: left";>
</div>

<div style="float: left; margin-left: 5%; margin-top: 30%";>
&nbsp;

<asp:ListBox ID="sendlist" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="20%" Width="100%">
    </asp:ListBox>
  
   
</div>
<div style="float: right; margin-right: 5%; height:50%; width:75% ";>
<asp:TextBox ID="writebox" runat="server" BorderColor="Black" 
        Height="60%" Width="100%"></asp:TextBox>

<div style="float: right; margin-right: 15%; margin-top:5%";><asp:Button ID="Button" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="SEND" OnClick="Button_Click"
                          />
</div>

</div>

</asp:Content>

