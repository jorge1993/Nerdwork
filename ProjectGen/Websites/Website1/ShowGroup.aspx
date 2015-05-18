<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ShowGroup.aspx.cs" Inherits="ShowEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <h2>
<asp:Label ID="eventname" runat="server" Text="groupname"></asp:Label>
</h2>
<div>
<p style="height: 55px">&nbsp; Name&nbsp; 
    <asp:TextBox ID="TBname" Height="30%" Width="50%" BorderColor="Black" runat="server" Enabled="false"></asp:TextBox>
    <br />
    Owner&nbsp;
    <asp:Label ID="OwnerLabel" runat="server" Text="owner name"></asp:Label>


    <br />
    <asp:Button ID="Join1" runat="server" OnClick="Join1_Click" Text="Join the group" />
    <asp:Button ID="Leave" runat="server" OnClick="Leave_Click" Text="Leave the group" />
    <asp:Label ID="Label2" runat="server" Text="You are part of this group!"></asp:Label>
    <p style="height: 55px">&nbsp;
        <asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Delete" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Modify" />
        <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Save changes" Visible="False" />

</div>
<div>
&nbsp; State &nbsp; 
    <asp:DropDownList ID="estado" runat="server" Height="16px" Width="117px" Enabled="False">
        <asp:ListItem>Public</asp:ListItem>
        <asp:ListItem>Private</asp:ListItem>
    </asp:DropDownList>
&nbsp;<p style="float:right; margin-right:30%">

</p>
<p style="float:right;"></p>

<p>
Description
</p>

</div>
<div style=" float:left; height:15%; width:50%";>
    
<asp:TextBox ID="description" runat="server" BorderColor="Black" Height="100%" 
        Width="100%" TextMode="MultiLine" Enabled="false"></asp:TextBox>
</div>

<div>
<p>
    &nbsp;&nbsp;
</p>
<p style="float: right; margin-right: 20%";>
                          <asp:Label id="Label1" runat="server"></asp:Label>

</p>

</div>
    <br />
    <br />
    <br />
    <br />

    <div>
        <asp:Table runat="server" ID="tableInvitation" border="0" cellpadding="0" cellspacing="0">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="LabelUsers" runat="server" Text="Users:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell> 
                            <asp:Label ID="aux" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelGroupUsers" runat="server" Text="Group users:"></asp:Label>
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
    <br />
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
                            &nbsp;</td>
                        <td></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ButtonPost" runat="server" OnClick="ButtonPost_Click" Text="Post" />
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
                        <td>Post</td>
                    </tr>
                </table>
            </div>

        
      <div id="grid" style="height:175px; width:100%; overflow:scroll; text-align: center;">
                <asp:GridView ID="GridViewTimeline" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" Width="100%" Height="100%" ShowHeader="False" >
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Image ID="avatarUser" runat="server" Height="50px" Width="50px" CommandName="avatar" ImageAlign="Middle"
                                        CommandArgument='<%# Eval("avatar") %>'  ImageUrl='<%# Eval("avatar") %>' >
                                </asp:Image>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                        <asp:TemplateField ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:LinkButton ID="nicknameLinkButton" runat="server" OnClick="NicknameLinkButton_Click" CommandName="nickname" 
                                        CommandArgument='<%# Eval("nickname") %>'  Text='<%# Eval("nickname") %>' ></asp:LinkButton>
                            </ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
                        </asp:TemplateField>

                            <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" ItemStyle-Width="70%" >
<ItemStyle Width="80%"></ItemStyle>
                        </asp:BoundField>
                        
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

