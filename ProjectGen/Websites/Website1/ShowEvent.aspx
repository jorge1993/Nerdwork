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

    <br />
    <asp:Button ID="Join1" runat="server" OnClick="Join1_Click" Text="" />
</div>


<div style=" float:left; height:15%; width:50%";>
<p>
Description
</p>

<asp:TextBox ID="description" runat="server" BorderColor="Black" Readonly="true" Height="100%" 
        Width="100%" TextMode="MultiLine" CssClass="css-input"></asp:TextBox>
</div>

<div style="float:left; margin-left:5%;">
<p>
&nbsp; Hobbies &nbsp;
<asp:TextBox ID="ListHobby" Height="3%" Width="140%" BorderColor="Black" Readonly="true" runat="server" CssClass="css-input"></asp:TextBox>
</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Start"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" Height="3%" Width="60%" BorderColor="Black" Readonly="true" runat="server" CssClass="css-input"></asp:TextBox>
</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="End"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" Height="3%" Width="70%" BorderColor="Black" Readonly="true" runat="server" CssClass="css-input"></asp:TextBox>
</p>

</div>

<div style="float:left; margin-top:20%">
<asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Delete" Visible="false"/>
<asp:Button ID="ButtonModify" runat="server" Text="Modify" OnClick="ButtonModify_Click" />
</div>


<div>
<asp:Table runat="server" ID="tableInvitation" border="0" cellpadding="0" cellspacing="0" Visible="false">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="LabelUsers" runat="server" Text="Users:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell> 
                            <asp:Label ID="aux" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelGroupUsers" runat="server" Text="New Event users:"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:ListBox ID="ListBoxUsers" runat="server" Width="150px" >
                            </asp:ListBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button ID="Button1" runat="server" Text=">>" OnClick="ButtonToRightUsers_Click" CausesValidation="False" ValidateRequestMode="Disabled" />
                            <asp:Button ID="Button2" runat="server" Text="<<" OnClick="ButtonToLeftUsers_Click" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:ListBox ID="ListBoxGroupUsers" runat="server"  Width="150">
                            </asp:ListBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
</div>
<div> <asp:Label id="owner" runat="server" Text="You're the owner of this event"></asp:Label></div>

</asp:Content>

