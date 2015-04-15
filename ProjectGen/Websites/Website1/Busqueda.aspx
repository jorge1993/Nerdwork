<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Busqueda.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="left" style=" float: left; width: 30%; margin-left:5px ; margin-top:5px;">

        <asp:Table ID="Table1" runat="server" Width="100%" GridLines="Horizontal">
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:HyperLink runat="server">All</asp:HyperLink>
                 </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID="HyperLink1" runat="server">People</asp:HyperLink>
                 </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID="HyperLink2" runat="server">Posts</asp:HyperLink>
                 </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell>
                    <asp:HyperLink ID="HyperLink3" runat="server">Events</asp:HyperLink>
                 </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="nickname" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                <asp:BoundField DataField="nickname" HeaderText="nickname" ReadOnly="True" SortExpression="nickname" />
                <asp:BoundField DataField="avatar" HeaderText="avatar" SortExpression="avatar" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGenNHibernateConnectionString %>" SelectCommand="SELECT Post.description, [User].nickname, [User].avatar FROM Post INNER JOIN hobby_post ON Post.id = hobby_post.FK_id_idPost INNER JOIN Hobby ON hobby_post.FK_name_idHobby = Hobby.name INNER JOIN [User] ON Post.FK_nickname_idUser = [User].nickname WHERE (Hobby.name LIKE '%' + @name + '%')">
            <SelectParameters>
                <asp:QueryStringParameter Name="name" QueryStringField="Hobby" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
