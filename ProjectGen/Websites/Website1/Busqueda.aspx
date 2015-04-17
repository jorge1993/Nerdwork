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
             <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID="EventsLink" runat="server">Events</asp:HyperLink>
                 </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </div>
    <div id="left" style=" float: left;">
        <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="70%" DataKeyNames="nickname" DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <Columns>
                    <asp:TemplateField HeaderText="Avatar">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("avatar") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("avatar") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nick" SortExpression="nickname">
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGenNHibernateConnectionString %>" SelectCommand="SELECT Usuario.nickname, Usuario.avatar, hobby_user.FK_name_idHobby FROM hobby_user INNER JOIN Usuario ON hobby_user.FK_nickname_idUser = Usuario.nickname WHERE (hobby_user.FK_name_idHobby LIKE '%' + @name + '%')">
            <SelectParameters>
                <asp:QueryStringParameter Name="name" QueryStringField="Hobby" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="nickname" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:ImageField DataImageUrlField="avatar" HeaderText="Avatar">
                    <ItemStyle Height="20px" Width="20px" />
                </asp:ImageField>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGenNHibernateConnectionString %>" SelectCommand="SELECT Usuario.nickname, Post.description, hobby_post.FK_name_idHobby, Usuario.avatar FROM hobby_post INNER JOIN Post ON hobby_post.FK_id_idPost = Post.id INNER JOIN Usuario ON Post.FK_nickname_idUser = Usuario.nickname WHERE (hobby_post.FK_name_idHobby LIKE N'%' + @name + N'%')">
            <SelectParameters>
                <asp:QueryStringParameter Name="name" QueryStringField="Hobby" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
