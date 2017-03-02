<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyTremps.aspx.cs" Inherits="MyTremps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="requestsAndOffersMenu" style="text-align:center">
    <asp:LinkButton ID="myOffersBtn" BorderWidth="1px" runat="server" onclick="myOffersBtn_Click">ההצעות שלי </asp:LinkButton>
    |
    <asp:LinkButton ID="myRequestsBtn" BorderWidth="1px" runat="server" onclick="myRequestsBtn_Click">הבקשות שלי</asp:LinkButton>
</div>
<div id="myTrempsContent" style="display: inline-block; margin-bottom: 10px;">
<asp:Repeater runat="server" ID="TrempsRepeater" onitemcommand="trempsRepeater_ItemDataBound" >
    <ItemTemplate>   
         <div class="MatchUsers">
                <div class="MatchUsersRight">
                   <div class="MatchUsersRightLable"><asp:Label ID="userName" runat="server"><%#DataBinder.Eval(Container.DataItem, "name")%></asp:Label></div>
                   <div><asp:Image ID="userPic" runat="server" ImageUrl='<%# "~/images/" + Eval("picture") %>' CssClass="MatchUsersPic" /></div>
                </div>
                <div class="MatchUsersMiddle">
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
                <div class="MatchUsersLeft">
                    <div class="buttonBox">
                    <asp:Button runat="server" ID="DeleteRide" CommandName="delete" Text="מחק" OnClientClick='javascript:return confirm("Are you sure you want to delete?")' 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, rideType.Text+"Id") %>'></asp:Button>
                    <asp:Button runat="server" ID="showMacthingRides" Text="הצג טרמפים מתאימים" CommandName="showMatching" 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, rideType.Text+"Id") %>'></asp:Button>
                    </div>
                </div>
         </div>
    </ItemTemplate>  
</asp:Repeater>
</div>
<asp:TextBox ID="rideType" runat="server" Visible="false"></asp:TextBox>


</asp:Content>

