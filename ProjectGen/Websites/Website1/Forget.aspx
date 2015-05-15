<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Forget.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style3
        {
            height: 20px;
        }
        .auto-style8
        {
            width: 199px;
        }
        .auto-style1
        {
            width: 19px;
        }
        .auto-style4
        {
            width: 283px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
           <div id="index"; style="height: 646px">
               <div id="login"; style="float: right; width: 500px; margin-right: 300px; margin-top: 120px;">
            <br />
            <table style="width: 500px; height: 250px; margin-left: 0px; background-color: #ffd800; margin-right: 30px;" align="center" border="1">
                <tr>
                    <td colspan="3" valign="middle" align="center" class="auto-style3">
                        <h1>
                            Forgot your password?</h1>
                    </td>   
                </tr>
                <tr>
                    <td align="right" class="auto-style8">
                        <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
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
                    <td align="center" class="style2" colspan="3">
                        <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
                        <br />
                        <asp:Button ID="Button2" runat="server" BorderColor="#999999" 
                             BorderStyle="Solid" Text="Send" OnClick="Button2_Click"
                              ValidationGroup="Register" />
                        &nbsp;
                        <asp:Button ID="Button1" runat="server" BorderColor="#999999" 
                             BorderStyle="Solid" Text="Back" OnClick="Button1_Click"/>
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

