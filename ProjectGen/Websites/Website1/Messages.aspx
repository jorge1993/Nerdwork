<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

<div style="float: left; margin-left: 5%";>
INBOX
<p>
<asp:ListBox ID="recievelist" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="30%" Width="100%">
            </asp:ListBox>
    </p>
    <p>
    <asp:Button ID="select" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="SELECT" OnClick="Button_SelectSee"
                          />
  </p>
   
</div>
<div style="float: right; margin-right: 5%; height:50%; width:75% ";>

<table id="cabeceraTimeline" style="width: 100%; background-color:#A55129; color:white; font-weight: bold; border-color: #DEBA84; border-style:none; border-width: 1px; text-align:center">
                    <tr>
                        <td style ="width:10%;">Nickname</td>
                        <td style ="width:20%;">Subject</td>
                        <td style ="width:50%;">Description</td>
                    </tr>
                </table>
<asp:GridView ID="GridView1" runat="server"></asp:GridView>
<asp:GridView ID="GridViewTimeline" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" Width="100%" Height="100%" ShowHeader="False" OnSelectedIndexChanged="GridViewTimeline_SelectedIndexChanged" >
                    <Columns>
                    <asp:TemplateField ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:LinkButton ID="nicknameLinkButton" runat="server" OnClick="NicknameLinkButton_Click" CommandName="nickname"
                                    CommandArgument='<%# Eval("nickname") %>'  Text='<%# Eval("nickname") %>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:BoundField DataField="subject" HeaderText="subject" SortExpression="subject" ItemStyle-Width="20%" />
                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" ItemStyle-Width="50%" />
                        
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

<div style="float: left; margin-left:5%; width:20%">
<p>
<asp:Label id="destino" runat="server">ADDRESSEE</asp:Label>
</p>
<p>
<asp:TextBox ID="reciever" ReadOnly="true" Height="30%" Width="50%" BorderColor="Black" runat="server">
</asp:TextBox>
</p>
<p>
<asp:ListBox ID="sendlist" runat="server" BorderColor="Black" ReadOnly="true" 
        Height="20%" Width="45%" DataSourceID="SqlDataSourceMessages" DataTextField="nickname" DataValueField="nickname">
            </asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGenNHibernateConnectionString %>" SelectCommand="SELECT nickname FROM Usuario WHERE (nickname != @nickname) ORDER BY nickname">
                <SelectParameters>
                    <asp:SessionParameter Name="nickname" SessionField="Name" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
    
  </p>
  <p>
  <asp:Button ID="select1" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="SELECT" OnClick="Button_SelectSend"
                          />
  </p>
   
</div>

<div style="float: right; margin-right: 5%; height:50%; width:70% ";>
SUBJECT <asp:TextBox ID="subject" runat="server" BorderColor="Black" Height="8%" Width="80%"></asp:TextBox>

<p style="float: right; margin-right: 5%; height:50%; width:100% ";>

<asp:TextBox ID="writebox" runat="server" BorderColor="Black" Height="100%" Width="100%" TextMode="MultiLine"></asp:TextBox>
</p>
 

<p style="float: right; margin-right: 15%";>
                          <asp:Label id="Label1" runat="server"></asp:Label>

<asp:Button ID="Button" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="SEND" OnClick="Button_Send"
                          />
</p>
</div>
 
</asp:Content>

