<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="UserGroups.aspx.cs" Inherits="UserGroups" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div style="margin-left: 40px">
        <div style="float: left; margin-top:2%; margin-left:10%;">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create a group" />

        </div>

        
        <br />
        <br />
        <br />

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
                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="nickname">
                        <ItemTemplate>
                            <asp:LinkButton ID="nicknameLinkButton" runat="server" OnClick="NicknameLinkButton_Click" CommandName="name"
                                    CommandArgument='<%# Eval("name") %>'  Text='<%# Eval("name") %>' ></asp:LinkButton>
                        </ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
                    </asp:TemplateField>

                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" ItemStyle-Width="50%" >
<ItemStyle Width="50%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="hobbies" HeaderText="hobbies" SortExpression="hobbies" ItemStyle-Width="20%" >
                       
                        
<ItemStyle Width="20%"></ItemStyle>
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

