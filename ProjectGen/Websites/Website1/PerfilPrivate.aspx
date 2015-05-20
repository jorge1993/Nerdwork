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
                <asp:TextBox ID="TextBoxPost" runat="server" TextMode="MultiLine" Width="100%" Height="80px" CssClass="css-input"></asp:TextBox>
            </p>
            <p>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="LabelUserHobbies" runat="server" Text="User hobbies:"></asp:Label>
                        </td>
                        <td></td>
                        <td>
                            <asp:Label ID="LabelPostHobbies" runat="server" Text="Post hobbies:"></asp:Label>
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
                            <asp:ListBox ID="ListPostHobbies" runat="server"  Width="150">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ButtonPost" runat="server" OnClick="ButtonPost_Click" Text="Post" CssClass="btn" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="LabelPosted" runat="server" Text="LabelPosted" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
            </p>
        </div>

        <div id="divTimeline" style="height: 50%; margin-left: 2%; margin-right: 2%">
            <div id="cabecera" style="height:25px; width:100%;">
                <table id="cabeceraTimeline" style="width: 100%; background-color:#A55129; color:white; font-weight: bold; border-color: #DEBA84; border-style:none; border-width: 1px; text-align:center">
                    <tr>
                        <td style ="width:10%;">Avatar</td>
                        <td style ="width:20%;">Nickname</td>
                        <td style ="width:50%;">Post</td>
                        <td style ="width:20%;">Hobby</td>
                    </tr>
                </table>
            </div>
            <div id="grid" style="height:175px; width:100%; overflow:scroll;">
                <asp:GridView ID="GridViewTimeline" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" Width="100%" Height="100%" ShowHeader="False" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="avatarUser" runat="server" Height="50px" Width="50px" CommandName="avatar"
                                        CommandArgument='<%# Eval("avatar") %>'  ImageUrl='<%# Eval("avatar") %>' >
                                </asp:Image>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
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
        </div>
    </div>

</asp:Content>

