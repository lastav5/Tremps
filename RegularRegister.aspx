<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegularRegister.aspx.cs" Inherits="RegularRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table id="regularRegisterTable" cellspacing="10px">
<tr><td colspan="4"><asp:ValidationSummary ID="ValidationSummary" runat="server" DisplayMode="List" CssClass="validationSummaryClass" />
    </td></tr>
    <tr>
        <td>שם</td><td><asp:TextBox ID="name" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>אימייל</td><td><asp:TextBox ID="email" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>סיסמא</td><td><asp:TextBox TextMode="Password" ID="password" runat="server"></asp:TextBox></td>
        
    </tr>
    <tr>
        <td>סיסמא חוזרת</td><td><asp:TextBox TextMode="Password" ID="repeatPassword" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>מין</td><td><asp:RadioButtonList ID="genderRadioList" runat="server">
                        <asp:ListItem Text="זכר" Value="male" Selected="True"></asp:ListItem> 
                        <asp:ListItem Text="נקבה" Value="female"></asp:ListItem>
                        </asp:RadioButtonList>
                 </td>
                 <td></td>
    </tr>
    <tr>
        <td>טלפון</td>
        <td><asp:TextBox ID="phone" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>תמונת פרופיל</td><td><asp:FileUpload ID="pictureUpload" runat="server" /><asp:Label runat="server" ID="pictureLabel"></asp:Label></td>
        <td></td>
    </tr>
    <tr>
        <td><asp:Button ID="submit" runat="server" Text="שלח" onclick="submit_Click" /></td><td></td><td></td>
    </tr>
    
</table>

<asp:RegularExpressionValidator ID="phoneRegex" Display="None" ControlToValidate="phone" ValidationExpression="^[0-9]{9,10}$" runat="server" ErrorMessage="טלפון מוכרח להכיל 9-10 מספרים בלבד"></asp:RegularExpressionValidator>
<asp:CompareValidator ID="passwordCompareValidator" Display="None" ControlToValidate="repeatPassword" ControlToCompare="password" runat="server" ErrorMessage="סיסמאות לא תואמות"></asp:CompareValidator>
<asp:RequiredFieldValidator ID="passwordRequired" Display="None" ControlToValidate="password" runat="server" ErrorMessage="אנא הכנס סיסמא"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="passwordCustom" OnServerValidate="ValidatePassword" runat="server" ControlToValidate="password" ErrorMessage="סיסמא לא תקינה. וודא שהסיסמא בעלת 6 ספרות לפחות ומכילה מספרים ואותיות בלבד"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="emailRequired" Display="None" ControlToValidate="email" runat="server" ErrorMessage="אנא הכנס אימייל"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="emailValid" Display="None" ControlToValidate="email" ValidationExpression="^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$" runat="server" ErrorMessage="אימייל לא תקין"></asp:RegularExpressionValidator>
<%--<asp:RegularExpressionValidator ID="nameRegex" Display="None"  ControlToValidate="name" runat="server" ValidationExpression="/[\p{L}' -]/" ErrorMessage="השם יכול להכיל אותיות בלבד"></asp:RegularExpressionValidator>--%>
<asp:RequiredFieldValidator ID="nameRequired" Display="None" ControlToValidate="name" runat="server" ErrorMessage="אנא הכנס שם"></asp:RequiredFieldValidator>

</asp:Content>

