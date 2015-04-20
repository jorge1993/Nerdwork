<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ModifyProfile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 162px;
        }
        .auto-style2 {
            width: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="modifyglobal" style="width:100%;height:100%;">
    
          
        
           
        
            <table style="width:99%; height: 320px; text-align: center;">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td><asp:Image ID="Image1" runat="server" Height="100px" Width="100px" /></td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">
                        <strong>List of Hobbies</strong><br />
                        <asp:ListBox ID="ListAllHobbies" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name"></asp:ListBox>
                       
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGenNHibernateConnectionString %>" SelectCommand="SELECT name FROM Hobby WHERE (name NOT IN (SELECT FK_name_idHobby FROM hobby_user  WHERE (FK_nickname_idUser = @name)))">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="" Name="name" SessionField="Name" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                       
                    </td>
                    <td> <asp:Button ID="Toleft" runat="server" Text="&gt;" OnClick="Toleft_Click" style="width: 22px" /><br>
                        <asp:Button ID="ToRight" runat="server" Text="&lt;" OnClick="ToRight_Click" />

                    </td>
                    <td>
                        <strong>My Hobbies</strong><br />
                        <asp:ListBox ID="ListUserHobbies" runat="server" DataSourceID="SqlDataSource2" DataTextField="FK_name_idHobby" DataValueField="FK_name_idHobby"></asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGenNHibernateConnectionString %>" SelectCommand="SELECT [FK_name_idHobby] FROM [hobby_user] WHERE ([FK_nickname_idUser] = @FK_nickname_idUser)">
                            <SelectParameters>
                                <asp:SessionParameter Name="FK_nickname_idUser" SessionField="Name" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>Upload your photo<br />
                        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Save" runat="server" Text="Save changes" OnClick="Save_Click" />
                        <br />
                        <asp:Label ID="SavedText" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
        </table>
           
        
            
           
       
   
        </div>
</asp:Content>

