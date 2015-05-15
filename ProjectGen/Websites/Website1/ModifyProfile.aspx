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
                    <td class="auto-style2">&nbsp;</td>
                    <td>Name:<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>Surname:<asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>E-mail:<asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
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
                    <td class="auto-style2">&nbsp;</td>
                    <td>Phone:<asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>New Password:<asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" OnTextChanged="TextBoxPassword_TextChanged" ></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">          
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>Confirm New Password:<asp:TextBox ID="TextBoxConfirm" runat="server" TextMode="Password" ClientIDMode="Predictable" Enabled="False"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                 ControlToCompare="TextBoxPassword"  ValidationGroup="Modify" ControlToValidate="TextBoxConfirm" 
                                 ErrorMessage="*Password doesn't match" ForeColor="Red"></asp:CompareValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
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
                        <asp:Button ID="Save" runat="server" Text="Save hobbies" OnClick="Save_Click" Validationgroup="Modify"/>
                        <br />
                        <asp:Label ID="SavedText" runat="server" Visible="false" style="font-weight: 700" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
        </table>
           
        
            
           
       
   
        </div>
</asp:Content>

