<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUserDetailsByAdmin.aspx.cs" Inherits="EditUserDetailsByAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">

    function DetailsSaved() {
        alert("השינויים נשמרו בהצלחה");
    }
    function inputFocus(i) {
        if (i.value == i.defaultValue) { i.value = ""; i.style.color = "#000"; }
    }
    function inputBlur(i) {
        if (i.value == "") { i.value = i.defaultValue; i.style.color = "#888"; }
    }
    function showChangePass() {
        document.getElementById("newPassTable").style.display = "";
    }
    function ComparePass(source, arguments) {
        newPass = document.getElementById('<%=newPass.ClientID %>').value.toString();
        repeatPass = document.getElementById('<%=repeatPass.ClientID %>').value.toString();

        if (newPass == repeatPass || (repeatPass == "הקש סיסמא בשנית" && newPass == "סיסמא חדשה")) {
            arguments.IsValid = true;
        }
        else {
            arguments.IsValid = false;
        }
    }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<div class="userProfileLeftDiv">
    <asp:Image ID="picture" runat="server"  width="300px"/>
    <asp:FileUpload ID="pictureUpload" runat="server"/>
    <asp:CustomValidator ID="PictureValidator" runat="server" OnServerValidate="ValidatePicture"></asp:CustomValidator>
</div>
<div class="userProfileRightDiv">
<table class="userProfileTable" cellpadding="10" cellspacing="5">
    <tr>
        <td colspan="4"><asp:ValidationSummary ID="ValidationSummary" runat="server" DisplayMode="List" Font-Bold="false" ForeColor="Red" /></td>
   </tr>
    <tr>
        <td>שם</td>
        <td>
            <asp:TextBox ID="name" runat="server"></asp:TextBox></td>
        <td></td>
    </tr>
    <tr>
        <td>אימייל</td>
        <td>
            <asp:TextBox ID="email" runat="server"></asp:TextBox></td>
        <td></td>
    </tr>
    <tr>
        <td>סיסמא</td>
        <td>
            <asp:TextBox ID="password" runat="server"></asp:TextBox></td>
        <td>
            <a href="javascript:showChangePass()" style="font-size:12px; float:right; color:#888">שנה סיסמא</a>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td align="right">
                <table id="newPassTable" style="display:none">
                    <tr>
                    <td>
                        <asp:TextBox ID="newPass" style="color:#888;" value="סיסמא חדשה" onfocus="inputFocus(this)" onblur="inputBlur(this)" runat="server"></asp:TextBox>
                        <asp:TextBox ID="repeatPass" style="color:#888;" value="הקש סיסמא בשנית" onfocus="inputFocus(this)" onblur="inputBlur(this)" runat="server"></asp:TextBox>
                    </td>
                    </tr>
                </table>
        </td>
    </tr>
    <tr>
        <td>מין</td>
        <td>
            <asp:Label ID="genderFemale" runat="server" Visible="false" ForeColor="Red" Font-Bold="true">נקבה</asp:Label>
             <asp:Label ID="genderMale" runat="server" Visible="false" ForeColor="Blue" Font-Bold="true">זכר</asp:Label>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>טלפון</td>
        <td>
            <asp:TextBox ID="phone" runat="server"></asp:TextBox></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="submit" runat="server" Text="שמור שינויים" 
                onclick="submit_Click" /></td>
        <td></td>

    </tr>
</table>
<asp:RegularExpressionValidator ID="phoneRegex" Display="None" ControlToValidate="phone" ValidationExpression="^[0-9]{9,10}$" runat="server" ErrorMessage="טלפון מוכרח להכיל 9-10 מספרים בלבד"></asp:RegularExpressionValidator>
<asp:CustomValidator ID="passwordMatch" Display="None" ClientValidationFunction="ComparePass" runat="server" ErrorMessage="הסיסמאות לא תואמות"></asp:CustomValidator>
<asp:RegularExpressionValidator ID="passwordRegex" Display="None" ValidationExpression="^[^<!@#$%^&*() \<\>>]+$" ControlToValidate="newPass" runat="server" ErrorMessage="סיסמא לא תקינה"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="emailRequired" Display="None" ControlToValidate="email" runat="server" ErrorMessage="אנא הכנס אימייל"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="emailValid" Display="None" ControlToValidate="email" ValidationExpression="^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$" runat="server" ErrorMessage="אימייל לא תקין"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="nameRegex" Display="None"  ControlToValidate="name" runat="server" ValidationExpression="^(?:[A-Za-zא-ת]+\s?)+$" ErrorMessage="השם יכול להכיל אותיות בלבד"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="nameRequired" Display="None" ControlToValidate="name" runat="server" ErrorMessage="אנא הכנס שם"></asp:RequiredFieldValidator>

</div>
</div>
</asp:Content>

