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
                <%--<tr>--%>
                    
                    <td class="auto-style2">&nbsp;</td>
                    <td><asp:Image ID="Image1" runat="server" Height="100px" Width="100px" /></td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">
                        <strong>List of Hobbies</strong><br />
                        <asp:ListBox ID="ListAllHobbies" runat="server"></asp:ListBox>
                       
                    </td>
                    <td> <asp:Button ID="Toleft" runat="server" Text="&gt;" OnClick="Toleft_Click" style="width: 22px" /><br>
                        <asp:Button ID="ToRight" runat="server" Text="&lt;" OnClick="ToRight_Click" />

                    </td>
                    <td>
                        <strong>My Hobbies</strong><br />
                        <asp:ListBox ID="ListUserHobbies" runat="server"></asp:ListBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2" style="text-align: right">Name:</td>
                    <td><asp:TextBox ID="TextBoxName" runat="server" CssClass="css-input"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2" style="text-align: right">Surname:</td>
                    <td><asp:TextBox ID="TextBoxSurname" runat="server" CssClass="css-input"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2" style="text-align: right">Email:</td>
                    <td><asp:TextBox ID="TextBoxEmail" runat="server" ReadOnly="true" CssClass="css-input"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ControlToValidate="TextBoxEmail"  ValidationGroup="Modify" ErrorMessage="*Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
                     
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                             ControlToValidate="TextBoxEmail"  ValidationGroup="Modify" ErrorMessage="*Valid mail is required" 
                             ForeColor="Red" 
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2" style="text-align: right">Phone:</td>
                    <td><asp:TextBox ID="TextBoxPhone" runat="server" CssClass="css-input"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2" style="text-align: right">New Password:</td>
                    <td><asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" OnTextChanged="TextBoxPassword_TextChanged" CssClass="css-input" ></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">          
                        <asp:Label ID="Label1" runat="server" Text="Password length > 4"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td>
                    </td>
                    <td></td>
                    <td class="auto-style1">
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>Upload your photo<br />
                        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Save" runat="server" Text="Save profile" OnClick="Save_Click" Validationgroup="Modify" CssClass="btn"/>
                        <br />
                        <asp:Label ID="SavedText" runat="server" Visible="false" style="font-weight: 700" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
        </table>
           
        
            
           
       
   
        </div>
</asp:Content>

