<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="PerfilPrivate.aspx.cs" Inherits="PerfilPrivate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="divGlobal">
        <div id="divCreatePost" style="height: 50%; margin-left: 2%; margin-right: 2%">
            <p>
                Write a post:
            </p>
            <p>
                <asp:TextBox ID="TextBoxPost" runat="server" TextMode="MultiLine" Width="100%" Height="80px"></asp:TextBox>
            </p>
            <p>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:ListBox ID="ListUserHobbies" runat="server" SelectionMode="Multiple" Width="80">
                                <asp:ListItem Text="Apple" />
                            </asp:ListBox>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text=">>" />
                            <asp:Button ID="Button2" runat="server" Text="<<" />
                        </td>
                        <td>
                            <asp:ListBox ID="ListPostHobbies" runat="server" SelectionMode="Multiple" Width="80">
                            </asp:ListBox>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="ButtonPost" runat="server" OnClick="ButtonPost_Click" Text="Post" />
            </p>
        </div>

        <div id="divTimeline" style="height: 50%; margin-left: 2%; margin-right: 2%">
            <asp:GridView ID="GridViewTimeline" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewTimeline_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="nickname" HeaderText="Nickname" ReadOnly="True" SortExpression="name" />
                    <asp:ImageField DataAlternateTextField="avatar" HeaderText="Avatar" ReadOnly="True" SortExpression="avatar"/>
                    <asp:BoundField DataField="post" HeaderText="post" SortExpression="post" />
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

</asp:Content>

