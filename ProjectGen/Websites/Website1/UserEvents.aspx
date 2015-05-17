<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="UserEvents.aspx.cs" Inherits="UserEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

<div>
<div style="float: left; margin-top:2%; margin-left:10%;">
<asp:Button ID="Button" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="Create an Event" OnClick="Button_Create"
                          />

                          </div>
<div id="search"; style="float: right; width: 300px; height: 50px; margin-top: 10px; margin-bottom: 0px; margin-right: 30px; text-align: right;">
                    <asp:TextBox ID="TextbosSearch" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="ButtonSearch" runat="server" Text="Search Events" OnClick="ButtonSearch_Click" />
                </div>

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

