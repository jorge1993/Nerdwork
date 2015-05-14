<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="CreateEvent.aspx.cs" Inherits="CreateEvents" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<h2 style="margin-left:30%">
Create an event
</h2>

<div>
<p>&nbsp; Name&nbsp; <asp:TextBox ID="TBname" Height="30%" Width="50%" BorderColor="Black" runat="server">
</asp:TextBox>
</div>
<div>
&nbsp; State &nbsp; <asp:TextBox ID="estado" Height="30%" Width="25%" BorderColor="Black" runat="server">
</asp:TextBox> (Private or Public)
<p style="float:right; margin-right:30%">

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

<div style=" float:right;";>
<table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="LabelUserHobbies" runat="server" Text="User hobbies:"></asp:Label>
                        </td>
                        <td></td>
                        <td>
                            <asp:Label ID="LabelEventHobbies" runat="server" Text="Event hobbies:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="ListUserHobbies" runat="server" Width="150px" >
                            </asp:ListBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonToRight" runat="server" Text=">>" OnClick="ButtonToRight_Click" CausesValidation="False" ValidateRequestMode="Disabled" />
                            <asp:Button ID="ButtonToLeft" runat="server" Text="<<" OnClick="ButtonToLeft_Click" />
                        </td>
                        <td>
                            <asp:ListBox ID="ListEventHobbies" runat="server"  Width="150">
                            </asp:ListBox>
                        </td>
                    </tr>
                </table>
</div>

<div>
<div style="margin-top: 13%;">
<asp:Label ID="Inicio" runat="server" Text="Start DateTime" Visible="true"></asp:Label>
<asp:Label style="margin-left: 15%" ID="Fin" runat="server" Text="End DateTime" Visible="true"></asp:Label>
</div>
<div>
<asp:TextBox ID="iniciotext" runat="server"></asp:TextBox>
<asp:TextBox style="margin-left: 4%" ID="fintext" runat="server"></asp:TextBox>
</div>

<p>
&nbsp; Place &nbsp;
<asp:TextBox ID="Lugar" Height="30%" Width="50%" BorderColor="Black" runat="server">
</asp:TextBox>
</p>
<p style="float: right; margin-right: 20%";>
                          <asp:Label id="Label1" runat="server"></asp:Label>

<asp:Button ID="Button" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="Create Event" OnClick="Button_Create"
                          />
</p>

</div>


</asp:Content>

