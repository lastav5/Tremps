<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RideOfferForm.aspx.cs" Inherits="RideOfferForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">

        
        google.maps.event.addDomListener(window, 'load', initialize);

        function createAutoComplete() {
            
            var input = document.getElementById('<%= originTB.ClientID %>');
            var autocomplete = new google.maps.places.Autocomplete(input);
            var input2 = document.getElementById('<%= destinationTB.ClientID %>');
            var autocomplete2 = new google.maps.places.Autocomplete(input2);
        }

        function validateEmailPhone(source, arguments) {
            var email = document.getElementById('<%= emailTb.ClientID %>').value;
            var phone = document.getElementById('<%= phoneTb.ClientID %>').value;
            if (email == "" && phone == "") {
                arguments.IsValid = false;
            }
        }
        function originRequired() {
            if (document.getElementById("originTB").value != "הזן מיקום") {
                document.getElementById("originRequired").isValid = true;
            }
            else {
                document.getElementById("originRequired").isValid = false;
            }
        }
        function destinationRequired() {
            if (document.getElementById("destinationTB").value != "הזן מיקום") {
                document.getElementById("destinationRequired").isValid = true;
            }
            else {
                document.getElementById("destinationRequired").isValid = false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <h1>הצעת טרמפ</h1>
    
    <table class="RideOfferTable">   
    <tr><td colspan="4"><asp:ValidationSummary ID="ValidationSummary" runat="server" DisplayMode="List" Font-Bold="false" ForeColor="Red" /></td></tr>
        <tr>
            <td> תאריך הטרמפ</td> 
            <td>
                <asp:CalendarExtender TargetControlID="calendarTB" ID="calendar" Format="dd/MM/yy" runat="server"></asp:CalendarExtender>              
                <asp:TextBox class="textBoxClass" ID="calendarTB" runat="server"></asp:TextBox>
            </td>
            <td>שעה</td>
            <td>
                <asp:DropDownList ID="minuteDDL" runat="server">
                <asp:ListItem>00</asp:ListItem>  <asp:ListItem>15</asp:ListItem>  <asp:ListItem>30</asp:ListItem>  <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList> : <asp:DropDownList ID="hourDDL" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>מוצא</td><td><asp:TextBox ID="originTB" class="textBoxClass" onkeypress="return noEnter()" runat="server"></asp:TextBox></td>

            <td>יעד</td><td><asp:TextBox ID="destinationTB" class="textBoxClass"  onkeypress="return noEnter()" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>טלפון</td>
            <td><asp:TextBox ID="phoneTb" runat="server"></asp:TextBox></td>
            <td>דוא"ל</td>
            <td><asp:TextBox ID="emailTb" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp</td><td colspan="3"></td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
           <td>מין</td>
            <td colspan="3">
                <asp:RadioButtonList ID="gender" RepeatDirection="Horizontal" runat="server">
                    <asp:ListItem>&nbspזכר</asp:ListItem>
                    <asp:ListItem>&nbspנקבה</asp:ListItem>
                    <asp:ListItem Selected="True">&nbspלא משנה לי</asp:ListItem>
                </asp:RadioButtonList>
            </td>         
        </tr>
        <tr>
            <td></td>
            <td>
            </td>
            <td>דמי השתתפות</td>
            <td><asp:TextBox ID="price" Width="70px" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
           <td>הערות</td>
           <td colspan="3"><asp:TextBox ID="notes" Width="100%" runat="server"></asp:TextBox></td>
        </tr>
    
    </table>
    <asp:Button ID="SubmitRideOffer" runat="server" onclick="SubmitRideOffer_Click" Text="המשך" CssClass="SubmitRideOfferBtn" />
    <asp:CustomValidator ID="EmailPhoneValidator" Display="None" ClientValidationFunction="validateEmailPhone" runat="server" ErrorMessage="אנא הכנס אימייל או טלפון"></asp:CustomValidator>
    <asp:RegularExpressionValidator ID="emailValid" Display="None" ControlToValidate="emailTb" ValidationExpression="^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$" runat="server" ErrorMessage="אימייל לא תקין"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="phoneRegex" Display="None" ControlToValidate="phoneTb" ValidationExpression="^[0-9]{9,10}$" runat="server" ErrorMessage="טלפון מוכרח להכיל 9-10 מספרים בלבד"></asp:RegularExpressionValidator>
    <asp:CustomValidator ID="originRequired" Display="None" ControlToValidate="originTB" runat="server" ClientValidationFunction="originRequired" ErrorMessage="אנא הכנס מוצא"></asp:CustomValidator>
    <asp:CustomValidator ID="destinationRequired" Display="None" runat="server" ControlToValidate="destinationTB" ClientValidationFunction="destinationRequired" ErrorMessage="אנא הכנס יעד"></asp:CustomValidator>
    <div id="map_canvas" style="visibility:hidden"></div>
</asp:Content>

