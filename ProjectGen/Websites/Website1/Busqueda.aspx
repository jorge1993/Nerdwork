<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Busqueda.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="right" style=" float: right; width: 30%; margin-left:5px ; margin-top:5px;">

        <asp:Table ID="Table1" runat="server" Width="100%" GridLines="Horizontal">
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID ="AllLink" runat="server">All</asp:HyperLink>
                 
</asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID="PeopleLink" runat="server">People</asp:HyperLink>
                 
</asp:TableCell>
            </asp:TableRow>
             <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID="PostsLink" runat="server">Posts</asp:HyperLink>

</asp:TableCell>
            </asp:TableRow>
             <asp:TableRow ID="TableRow4" runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID="GroupsLink" runat="server">Groups</asp:HyperLink>
                 
</asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
            </asp:TableRow>
             <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID="EventsLink" runat="server">Events</asp:HyperLink>
                 
</asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </div>
    <div id="left" style=" float: left; margin-left: 5px">
        <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="60%" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <Columns>
                    <asp:TemplateField HeaderText="Avatar" ItemStyle-Width="20%">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("avatar") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" ImageUrl='<%# Eval("avatar") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nick" SortExpression="nickname" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server"  OnClick="NicknameLinkButton_Click" Text='<%# Eval("nickname") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
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
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="nickname">
            <Columns>
                <asp:TemplateField HeaderText="Avatar" ItemStyle-Width="20%">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("avatar") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" ImageUrl='<%# Eval("avatar") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Nick">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server"  OnClick="NicknameLinkButton_Click" NavigateUrl="" Text='<%# Eval("nickname") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
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
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="100%" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:LinkButton ID="nicknameLinkButton0" runat="server" CommandArgument='<%# Eval("name") %>' CommandName="name" OnClick="GroupLinkButton_Click" Text='<%# Eval("name") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="50%" SortExpression="description">
                <ItemStyle Width="50%" />
                </asp:BoundField>
                <asp:BoundField DataField="hobbies" HeaderText="Hobbies" ItemStyle-Width="20%" SortExpression="hobbies">
                <ItemStyle Width="20%" />
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
        <br />
        <asp:GridView ID="GridView4" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" Width="100%" Height="100%" >
                    <Columns>
                    <asp:TemplateField ItemStyle-Width="20%" HeaderText="Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="nicknameLinkButton" runat="server" OnClick="EventLinkButton_Click" CommandName="nickname"
                                    CommandArgument='<%# Eval("name") %>'  Text='<%# Eval("name") %>' ></asp:LinkButton>
                        </ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
                    </asp:TemplateField>

                        <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" ItemStyle-Width="50%" >
<ItemStyle Width="50%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="hobbies" HeaderText="Hobbies" SortExpression="hobbies" ItemStyle-Width="20%" >
                       
                        
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
</asp:Content>
