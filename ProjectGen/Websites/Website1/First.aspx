<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="First.aspx.cs" Inherits="_Default" %>

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
            width: 283px;
        }
        .auto-style5
        {
            height: 44px;
            width: 199px;
        }
        .auto-style6
        {
            width: 19px;
            height: 44px;
        }
        .auto-style7
        {
            width: 283px;
            height: 44px;
        }
        .auto-style8
        {
            width: 199px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="index"; style="height: 646px">
        <div id="login"; style="float: right; width: 500px; margin-right: 300px; margin-top: 120px;">
            <table style="width: 250px; height: 180px; margin-left: 0px; background-color: #FFFFFF;" align="center" class="bordertables">
                <tr>
                    <td colspan="3" valign="middle" align="center" class="auto-style3">
                        <h1>
                            Log IN
                        </h1>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style4">
                        <asp:Label ID="Label7" runat="server" Text="Nickname:" style="font-weight: 700"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="css-input"></asp:TextBox>
                    </td>
                    <td align="left" class="style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ValidationGroup="Login" runat="server" ErrorMessage="*Nick is required" ControlToValidate ="TextBox2"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style4">
                        <asp:Label ID="Label8" runat="server" Text="Password:" style="font-weight: 700"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="TextBox7" runat="server" TextMode="Password" CssClass="css-input"></asp:TextBox>
                    </td>
                    <td align="left" class="style3">          
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Login" ForeColor="Red" ErrorMessage="*Password is required" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
             
                <tr>
                    <td align="center" class="style2" colspan="3">
                        <asp:Label ID="Label10" runat="server" Text="Label" Visible="false"></asp:Label><br />
                        <asp:Button ID="Button1" runat="server" BorderColor="#999999" BorderStyle="Solid" Text="Log in" OnClick="Button1_Click" ValidationGroup ="Login" CssClass="btn"/>
                    </td>
                </tr>
            </table>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Forget.aspx" Width="100%" Font-Strikeout="False" Font-Underline="True" CssClass="myLink">Forgot your password?</asp:HyperLink>
            <br />
            <br />
            <table style="width: 500px; height: 250px; margin-left: 0px; background-color: #FFFFFF; margin-right: 30px;" align="center" class="bordertables">
                <tr>
                    <td colspan="3" valign="middle" align="center" class="auto-style3">
                        <h1>
                            Register Now
                        </h1>
                    </td>   
                </tr>
                <tr>
                    <td align="right" class="auto-style8">
                        <asp:Label ID="Label1" runat="server" Text="Email:" style="font-weight: 700"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="css-input"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style4">     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ControlToValidate="TextBox5"  ValidationGroup="Register" ErrorMessage="*Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
                     
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                             ControlToValidate="TextBox5"  ValidationGroup="Register" ErrorMessage="*Valid mail is required" 
                             ForeColor="Red" 
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style8">
                        <asp:Label ID="Label2" runat="server" Text="Nickname:" style="font-weight: 700"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="css-input"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                             ControlToValidate="TextBox3"  ValidationGroup="Register" ErrorMessage="*Nickname is required" 
                             ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
               
                <tr>
                    <td align="center" class="style2" colspan="3">
                        <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
                        <br />
                        <asp:Button ID="Button2" runat="server" BorderColor="#999999" 
                             BorderStyle="Solid" Text="Register" OnClick="Button2_Click"
                              ValidationGroup="Register" CssClass="btn" />
                    </td>
                </tr>
            </table> 
        </div>

        <div id="description"; style="float: left; width: 400px;margin-left: 150px; margin-top: 150px">            
            <h2 style="color: rgb(52, 50, 50)">
                Met people like you with unusual hobbies. 
                <br />
                <br />
                Post your thinkings about a specific topic or topics. 
                <br />
                <br />
                And create groups and events around a topic.
            </h2> 
            <h3>
	            <a href="AboutUS.aspx">About US</a>  
	        </h3>    
        </div>
    </div>       
</asp:Content>
