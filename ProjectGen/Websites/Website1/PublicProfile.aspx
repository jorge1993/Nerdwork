<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="PublicProfile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="profileglobal" style="width:100%;height:100%;">
        <div id="divUser" style="height: 20%; margin-left: 2%; margin-right: 2%">
            <table style="width: 100%; text-align: center;">
                <tr>
                    <td>
                        <asp:Image ID="avatarPublic" runat="server" />
                    </td>
                    <td>
                        <h1>
                            <asp:Label ID="nicknamePublic" runat="server" Text="Public Nickname"></asp:Label>
                        </h1>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divTimeline" style="height: 80%; margin-left: 2%; margin-right: 2%; margin-bottom: 2%; margin-top: 2%;">
            <div id="cabecera" style="height:40px; width:100%;">
                <table id="cabeceraTimeline" style="width: 100%; height:100%; background-color:#A55129; color:white; font-weight: bold; border-color: #DEBA84; border-style:none; border-width: 1px; text-align:center">
                    <tr>
                        <td style ="width:70%;">Post</td>
                        <td style ="width:30%;">Hobby</td>
                    </tr>
                </table>
            </div>
            <div id="grid" style="height:330px; width:100%; overflow:scroll;">
                <asp:GridView ID="GridViewTimeline" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" Width="100%" Height="100%" ShowHeader="False" >
                    <Columns>
                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" ItemStyle-Width="60%" />
                        <asp:BoundField DataField="hobbies" HeaderText="hobbies" SortExpression="hobbies" ItemStyle-Width="40%" />
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
        </div>
    </div>
</asp:Content>

