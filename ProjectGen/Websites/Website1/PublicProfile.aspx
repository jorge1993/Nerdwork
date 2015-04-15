<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="PublicProfile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div id="profileglobal" style="width:100%;height:100%;">
         <table style="width: 100%; height: 359px; text-align: center;">
             <tr>
                 <td>
                     <asp:Image ID="Image1" runat="server" />
                 </td>
                 <td>
                     <asp:Label ID="Label1" runat="server" Text="Myname"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td>
                     <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
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
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
         </table>

</asp:Content>

