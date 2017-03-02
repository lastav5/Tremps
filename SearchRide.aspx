<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchRide.aspx.cs" Inherits="SearchRide" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript" language="javascript">

    function createAutoComplete() {
        var input = document.getElementById('<%= originTB.ClientID %>');
        var autocomplete = new google.maps.places.Autocomplete(input);
        var input2 = document.getElementById('<%= destinationTB.ClientID %>');
        var autocomplete2 = new google.maps.places.Autocomplete(input2);
        autocomplete.bindTo('bounds', map);
        autocomplete2.bindTo('bounds', map);
    }

    google.maps.event.addDomListener(window, 'load', initialize);
   
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div id="filtersDiv" class="SearchRideFiltersDiv">


    <table id="filtersTable" cellpadding="3px" cellspacing="15px">
        <tr>
            <td style="text-align:right">סוג הטרמפ</td>
            <td style="text-align:right">
                <asp:DropDownList ID="rideTypeDDL" runat="server">
                <asp:ListItem Value="RideOffer" Selected="True" Text="הצעות טרמפ"></asp:ListItem>
                <asp:ListItem Value="RideRequest" Text="בקשות טרמפ"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>מוצא</td><td>יעד</td><td>תאריך</td><td>שעה</td><td>מין</td>
        </tr>
         <tr>
            <td>
                <asp:TextBox ID="originTB" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="destinationTB" runat="server"></asp:TextBox>
            </td>
            <td><asp:CalendarExtender ID="calendar" TargetControlID="calendarTB" Format="dd/MM/yy" runat="server"></asp:CalendarExtender>
                <asp:TextBox ID="calendarTB" class="textBoxClass" runat="server"></asp:TextBox></td>
            <td>
                <asp:DropDownList ID="hourDDL" runat="server">
                <asp:ListItem Value="-1">בחר</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="minuteDDL" runat="server">
                <asp:ListItem Value="-1">בחר</asp:ListItem>
                <asp:ListItem>00</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="genderPrefDDL" runat="server">
                <asp:ListItem Value="0">זכר</asp:ListItem>
                <asp:ListItem Value="1">נקבה</asp:ListItem>
                <asp:ListItem Value="-1">לא משנה לי</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="submit" runat="server" Text="סנן" onclick="submit_Click" />
            </td>
        </tr>
    </table>
</div>

<asp:Repeater runat="server" ID="ridesRepeater">
    <ItemTemplate>   
         <div class="MatchUsers">
                <div class="MatchUsersRight">
                   <div class="MatchUsersRightLable"><asp:Label ID="userName" runat="server"><%#DataBinder.Eval(Container.DataItem, "name")%></asp:Label></div>
                   <div><asp:Image ID="userPic" runat="server" ImageUrl='<%# "~/images/" + Eval("picture") %>' CssClass="MatchUsersPic" /></div>
                </div>
                <div class="MatchUsersLeft">
                <div style="display:inline-block; width:600px">
                     <div class="Box">
                       <p>מוצא</p>
                       <p class="BoxP"><%#DataBinder.Eval(Container.DataItem, "originName")%></p>
                     </div>
                     <div class="Box">
                        <p>יעד</p>
                        <p class="BoxP"><%#DataBinder.Eval(Container.DataItem, "destinationName")%></p>
                     </div>
                     <div class="Box">
                        <p>שעה</p>
                        <p class="BoxP"><%#DataBinder.Eval(Container.DataItem, "hour")%>:<%#DataBinder.Eval(Container.DataItem, "minute")%></p>
                     </div>
                 </div>
                 <div style="display:inline-block; width:558px; margin-top:10px;">
                   <div class="OrangeBox" style="float:right">
                    <p> <%#DataBinder.Eval(Container.DataItem, "phone")%></p>
                   </div>
                    <div class="OrangeBox" style="float:left">
                    <p><%#DataBinder.Eval(Container.DataItem, "email")%></p>
                   </div>
                 </div>
                 <div class="NotesBox">
                   <p><%#DataBinder.Eval(Container.DataItem, "notes")%></p>
                 </div>
                </div>
         </div>
    </ItemTemplate>  
</asp:Repeater>

<div id="map_canvas" style="visibility:hidden;width: 600px; height: 400px" ></div>
</asp:Content>

