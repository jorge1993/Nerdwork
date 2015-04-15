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
                        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                       
                    </td>
                    <td> <asp:Button ID="Button1" runat="server" Text="Button" /><br>
                        <asp:Button ID="Button2" runat="server" Text="Button" Width="56px" />

                    </td>
                    <td>
                        <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
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
                        <asp:Button ID="Button3" runat="server" Text="Button" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
        </table>
           
        
            
           
       
   
        </div>
</asp:Content>

