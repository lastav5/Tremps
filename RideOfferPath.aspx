<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RideOfferPath.aspx.cs" Inherits="RideOfferPath" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">

     xMarkerArray = new Array();
     yMarkerArray = new Array();

     function createAutoComplete() {

         var input = document.getElementById('<%= originTB.ClientID %>');
         var autocomplete = new google.maps.places.Autocomplete(input);
         var input2 = document.getElementById('<%= destinationTB.ClientID %>');
         var autocomplete2 = new google.maps.places.Autocomplete(input2);

         autocomplete.bindTo('bounds', map);
         autocomplete2.bindTo('bounds', map);
         start = "<%=originPoint %>";
         end = "<%=destinationPoint %>";
         calcRoute();
     }

     function setDirectionsService(request) {
         directionsService = new google.maps.DirectionsService();
         directionsService.route(request, function (response, status) {
             if (status == google.maps.DirectionsStatus.OK) {
                 directionsDisplay.setDirections(response);
                 SaveOfferPoints(response);
                 document.getElementById('<%=coordinateXArray.ClientID %>').value = xMarkerArray;
                 document.getElementById('<%=coordinateYArray.ClientID %>').value = yMarkerArray;
             }
         });
     }

     google.maps.event.addDomListener(window, 'load', initialize);
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            <div class="RideOfferDiv">
                    <p>
                        &nbsp;</p>
                    <asp:Button ID="BackBtn" runat="server" Text="<< חזור" Width="70px" Height="30px"
                        BackColor="#B4C0C4" Font-Size="Small" OnClick="BackBtn_Click" />
                    <p>
                        &nbsp;</p>
                    <p class="headerTitle">
                        מסלול הנסיעה שהמערכת מציעה לך
                    </p>
                    <p class="note">
                        שים לב! המערכת תאתר נוסעים שתוכל לאסוף במסלול זה
                    </p>
       
                    <div style="text-align: center">
                        <div id="map_canvas" style="width:90%; height:400px">
                        </div>
                    </div> 
                    <p>
                        &nbsp;</p>
                    <asp:Button ID="RideOfferPathBtn" Text="המשך לצפייה במשתמשים מתאימים" 
                        runat="server" CssClass="RideOfferPathBtn" onclick="RideOfferPathBtn_Click"/>
            
            </div>
  
    <asp:TextBox id="originTB" Text="<%=originPoint %>" runat="server" CssClass="TBhidden" ></asp:TextBox>
     <asp:TextBox id="destinationTB" Text="<%=destinationPoint %>" runat="server" CssClass="TBhidden" ></asp:TextBox>
     <asp:TextBox ID="coordinateXArray" runat="server" CssClass="TBhidden"></asp:TextBox> 
     <asp:TextBox ID="coordinateYArray" runat="server" CssClass="TBhidden"></asp:TextBox>
</asp:Content>

