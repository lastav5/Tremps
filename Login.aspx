<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function ValidateEmail(source, arguments) {
        var emailstr = document.getElementById('<%=email.ClientID %>').value;
        if (emailstr.indexOf('@') == '-1' || emailstr.indexOf('@') != emailstr.lastIndexOf('@')) {
            arguments.isValid= false;
        }
        if ((emailstr.indexOf('@') == emailstr.indexOf('.') + 1) || (emailstr.indexOf('@') + 1 == emailstr.indexOf('.'))) {
            arguments.isValid = false;
            
        }
        arguments.isValid = true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="ValidationSummary" runat="server" DisplayMode="List" Font-Bold="false" ForeColor="Red" />
<table id="loginTable">
    <tr>
        <td>אימייל</td>
        <td>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </td>
        <td> 
            
        </td>
    </tr>
    <tr>
        <td>סיסמא</td>
        <td>
            <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
        </td>
        <td>
            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="loginBtn" runat="server" Text="התחבר" onclick="loginBtn_Click" /></td>
        <td></td>
        <td></td>
    </tr>
</table>
<p style="color:Red">
פרטי מנהל: אימייל - lastav5@gmail.com. סיסמא - 123456.
</p> 
<p style="color:Red">
משתמש רגיל:
 אימייל - omerush6@gmail.com
 .סיסמא - 123456
</p>

<asp:RequiredFieldValidator ID="passwordRequired" Display="None" ControlToValidate="password" runat="server" ErrorMessage="אנא הכנס סיסמא"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator Display="None" ID="passwordRegex" ValidationExpression="^[^<!@#$%^&*() \<\>>]+$" ControlToValidate="password" runat="server" ErrorMessage="סיסמא לא תקינה"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="emailRequired" Display="None" ControlToValidate="email" runat="server" ErrorMessage="אנא הכנס אימייל"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="emailValid" Display="None" ControlToValidate="email" ValidationExpression="^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$" runat="server" ErrorMessage="אימייל לא תקין"></asp:RegularExpressionValidator>
</asp:Content>

