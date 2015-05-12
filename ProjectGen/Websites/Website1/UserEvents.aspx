<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="UserEvents.aspx.cs" Inherits="UserEvents" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<h2 style="margin-left:30%">
Create an event
</h2>

<div>
<p>&nbsp; Name&nbsp; <asp:TextBox ID="reciever" ReadOnly="true" Height="30%" Width="50%" BorderColor="Black" runat="server">
</asp:TextBox>
</div>
<div>
&nbsp; Estado &nbsp; <asp:TextBox ID="estado" ReadOnly="true" Height="30%" Width="25%" BorderColor="Black" runat="server">
</asp:TextBox> (Privado o Publico)
<p style="float:right; margin-right:30%">

</p>
<p style="float:right;"></p>

<p>
Description
</p>

</div>
<div style=" float:left; height:15%; width:50%";>

<asp:TextBox ID="description" runat="server" BorderColor="Black" Height="100%" Width="100%"></asp:TextBox>
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
<asp:Label ID="Inicio" runat="server" Text="Fecha Inicio" Visible="true"></asp:Label>
<asp:Label style="margin-left: 15%" ID="Fin" runat="server" Text="Fecha Fin" Visible="true"></asp:Label>
</div>
<div>
<asp:TextBox ID="iniciotext" runat="server"></asp:TextBox>
<asp:TextBox style="margin-left: 4%" ID="fintext" runat="server"></asp:TextBox>
</div>

<p style="float: right; margin-right: 20%";>
                          <asp:Label id="Label1" runat="server"></asp:Label>

<asp:Button ID="Button" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="Create Event" OnClick="Button_Create"
                          />
</p>

</div>
<div>
<table id="cabeceraTimeline" style="width: 100%; background-color:#A55129; color:white; font-weight: bold; border-color: #DEBA84; border-style:none; border-width: 1px; text-align:center">
                    <tr>
                        <td style ="width:20%;">Name</td>
                        <td style ="width:50%;">Description</td>
                        <td style ="width:20%;">Hobbies</td>
                    </tr>
                </table>

<asp:GridView ID="GridViewTimeline" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" Width="100%" Height="100%" ShowHeader="False" OnSelectedIndexChanged="GridViewTimeline_SelectedIndexChanged" >
                    <Columns>
                    <asp:TemplateField ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:LinkButton ID="nicknameLinkButton" runat="server" OnClick="NicknameLinkButton_Click" CommandName="nickname"
                                    CommandArgument='<%# Eval("nickname") %>'  Text='<%# Eval("nickname") %>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" ItemStyle-Width="50%" />
                        <asp:BoundField DataField="hobbies" HeaderText="hobbies" SortExpression="hobbies" ItemStyle-Width="20%" />
                       
                        
                    </Columns>

                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>

</div>


</asp:Content>

