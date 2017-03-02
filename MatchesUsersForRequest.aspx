<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MatchesUsersForRequest.aspx.cs" Inherits="MatchesUsersForRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <script type="text/javascript">

 
     function createAutoComplete() {// responsible for textboxes with automatic dropdown list of addresses.
         var input = document.getElementById('<%= originTB.ClientID %>');
         var autocomplete = new google.maps.places.Autocomplete(input);
         var input2 = document.getElementById('<%= destinationTB.ClientID %>');
         var autocomplete2 = new google.maps.places.Autocomplete(input2);
         autocomplete.bindTo('bounds', map);
         autocomplete2.bindTo('bounds', map);
         start = "<%=originPoint %>";
         end = "<%=destinationPoint %>";
         calcRoute();//in js. calls setDirectionsService
     }

     function setDirectionsService(request) {
         directionsService = new google.maps.DirectionsService();
         directionsService.route(request, function (response, status) {
             if (status == google.maps.DirectionsStatus.OK) {
                 SaveReqPoints(response);
                 document.getElementById("<%= originLat.ClientID%>").value = yMarkerArray[0];
                 document.getElementById("<%= originLng.ClientID%>").value = xMarkerArray[0];
                 document.getElementById("<%= destinationLat.ClientID%>").value = yMarkerArray[1];
                 document.getElementById("<%= destinationLng.ClientID%>").value = xMarkerArray[1];
                 var myLatlng = new google.maps.LatLng(yMarkerArray[0], xMarkerArray[0]);
                 var myOptions = {
                     zoom: 12,
                     center: myLatlng,
                     mapTypeId: google.maps.MapTypeId.ROADMAP
                 }
                 var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

                 var marker = new google.maps.Marker({
                     position: myLatlng,
                     title: 'מיקומך',
                     animation: google.maps.Animation.BOUNCE,
                     map: map
                 });
             }
         });
             
             
     }
     google.maps.event.addDomListener(window, 'load', initialize);
    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="map_canvas" style="width:97%; height:250px"></div>
<asp:Button ID="InsertRideRequest" Text="אשר" runat="server" 
        onclick="InsertRideRequest_Click" />
<asp:Repeater runat="server" ID="matchUsersRepeater">
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
                 </div>
                <div style="display:inline-block; width:600px">
                     <div class="Box">
                        <p>תאריך</p>
                        <p class="BoxP"><%#DataBinder.Eval(Container.DataItem, "rideDate")%></p>
                     </div>
                        <div class="Box">
                        <p>שעה</p>
                        <p class="BoxP"><%#DataBinder.Eval(Container.DataItem, "hour")%>:<%#DataBinder.Eval(Container.DataItem, "minute")%></p>
                     </div>
                     <div class="Box">
                        <p>מחיר</p>
                        <p class="BoxP"><%#DataBinder.Eval(Container.DataItem, "price")%></p>
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
     <asp:TextBox id="originTB" Text="<%=originPoint %>" runat="server" CssClass="TBhidden" ></asp:TextBox>
     <asp:TextBox id="destinationTB" Text="<%=destinationPoint %>" runat="server" CssClass="TBhidden" ></asp:TextBox>
    <asp:TextBox ID="originLat" runat="server" CssClass="TBhidden"></asp:TextBox>
     <asp:TextBox ID="originLng" runat="server" CssClass="TBhidden"></asp:TextBox>  
     <asp:TextBox ID="destinationLat" runat="server" CssClass="TBhidden"></asp:TextBox>
     <asp:TextBox ID="destinationLng" runat="server" CssClass="TBhidden"></asp:TextBox>
</asp:Content>

