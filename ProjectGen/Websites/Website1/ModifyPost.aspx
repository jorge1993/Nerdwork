<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ModifyPost.aspx.cs" Inherits="_ModifyPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="divGlobal">
        <div id="divCreatePost" style="height: 50%; margin-left: 2%; margin-right: 2%">
            <p>
                Modify the post:
            </p>
            <p>
                <asp:TextBox ID="TextBoxPost" runat="server" TextMode="MultiLine" Width="100%" Height="80px"></asp:TextBox>
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
                            <asp:Button ID="ButtonPost" runat="server" OnClick="ButtonPost_Click" Text="Modify post" />
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
    </div>
</asp:Content>

