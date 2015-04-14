<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            width: 19px;
        }
        .auto-style3
        {
            height: 20px;
        }
        .auto-style4
        {
            width: 171px;
        }
        .auto-style5
        {
            width: 146px;
        }
        .auto-style6
        {
            width: 76px;
        }
        .auto-style7
        {
            width: 117px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server" >
    <div id="index"; style="height: 646px">

       <div id="description"; style="float: left; width: 300px;margin-left: 150px; margin-top: 150px">            
            <h2>Connect with your friends — and other fascinating people. <br />
            Get in-the-moment updates on the things that interest you. <br />
            And watch events unfold, in real time, from every angle.</h2>
            
       </div>
        <div id="login"; style="float: right; width: 500px; margin-right: 300px; margin-top: 120px;">
        
               <table style="width: 370px; height: 200px; margin-left: 0px;" align="center" 
                   border="1">
             <tr>
                 <td colspan="3" valign="middle" align="center" class="auto-style3">
                     <h1>Log In</h1></td>
                 
             </tr>
             <tr>
                 <td align="right" class="auto-style6">
                     <asp:Label ID="Label7" runat="server" Text="Nickname:"></asp:Label>
                 </td>
                 <td align="left" class="auto-style7">
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                 </td>
                 <td align="left" class="auto-style5">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ValidationGroup="Login" runat="server" ErrorMessage="*Nick is required" ControlToValidate ="TextBox2"></asp:RequiredFieldValidator>
                     <br />
                 </td>
             </tr>
                 <tr>
                 <td align="right" class="auto-style6">
                     <asp:Label ID="Label8" runat="server" Text="Password:"></asp:Label>
                     </td>
                 <td align="left" class="auto-style7">
                     <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
                     <td align="left" class="auto-style5">
                          
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Login" ForeColor="Red" ErrorMessage="*Password is required" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
                          
                      <br />
                     </td>
             </tr>
             
             <tr>
                 <td align="center" class="style2" colspan="3">
                     <asp:Label ID="Label9" runat="server" Text="Label" Visible="false"></asp:Label>
                     <br />
                     <asp:Button ID="Button1" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="Log in" OnClick="Button1_Click" 
                          ValidationGroup ="Login"/>
                 </td>
             </tr>
         </table>
         <br />
            <table style="width: 500px; height: 250px; margin-left: 0px; background-color: #ffd800" align="center" border="1">
             <tr>
                 <td colspan="3" valign="middle" align="center" class="auto-style3">
                     <h1>Register Now</h1></td>
                 
             </tr>
             <tr>
                 <td align="right" class="style4">
                     <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
                 </td>
                 <td align="left" class="auto-style1">
                     <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                 </td>
                 <td align="left" class="auto-style4">
                     
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="TextBox5"  ValidationGroup="Register" ErrorMessage="*Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
                     <br />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                         ControlToValidate="TextBox5"  ValidationGroup="Register" ErrorMessage="*Valid mail is required" 
                         ForeColor="Red" 
                         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     
                 </td>
             </tr>
             <tr>
                 <td align="right" class="style4">
                     <asp:Label ID="Label2" runat="server" Text="Nickname:"></asp:Label>
                 </td>
                 <td align="left" class="auto-style1">
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                 </td>
                 <td align="left" class="auto-style4">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                         ControlToValidate="TextBox3"  ValidationGroup="Register" ErrorMessage="*Nickname is required" 
                         ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
             </tr>
                 <tr>
                 <td align="right" class="style4">
                     <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
                     </td>
                 <td align="left" class="auto-style1">
                     <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
                     <td align="left" class="auto-style4">
                          
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                             ControlToValidate="TextBox3" ValidationGroup="Register" ErrorMessage="*Password is required" 
                             ForeColor="Red"></asp:RequiredFieldValidator>
                     </td>
             </tr>
                 <tr>
                 <td align="right" class="style4">
                     <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
                     </td>
                 <td align="left" class="auto-style1">
                     <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
                     <td align="left" class="auto-style4">
                         <asp:CompareValidator ID="CompareValidator1" runat="server" 
                             ControlToCompare="TextBox4"  ValidationGroup="Register" ControlToValidate="TextBox6" 
                             ErrorMessage="*Password doesn't match" ForeColor="Red"></asp:CompareValidator>
                     </td>
             </tr>
             <tr>
                 <td align="center" class="style2" colspan="3">
                     <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label><br />
                     <asp:Button ID="Button2" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="Register" OnClick="Button2_Click"
                          ValidationGroup="Register" />
                 </td>
             </tr>
         </table>
         
       </div>

       </div>
        
</asp:Content>
