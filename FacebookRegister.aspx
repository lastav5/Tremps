<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FacebookRegister.aspx.cs" Inherits="FacebookRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="fb-root"></div>
<script type="text/javascript" src="//connect.facebook.net/en_US/all.js"></script>
<script type="text/javascript">
    // Additional JS functions here
    window.fbAsyncInit = function () {
        FB.init({
            appId: '243673205779223', // App ID
            //channelUrl: '//localhost:1685/Tremps', // Channel File
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });

        FB.getLoginStatus(function (response) {
            if (response.status === 'connected') {
                // connected
            } else if (response.status === 'not_authorized') {
                // not_authorized
                function login() {
                    FB.login(function (response) {
                        if (response.authResponse) {
                            // connected
                        } else {
                            // cancelled
                        }
                    });
                }
            } else {
                // not_logged_in
                function login() {
                    FB.login(function (response) {
                        if (response.authResponse) {
                            // connected
                        } else {
                            // cancelled
                        }
                    });
                }
            }
        });

        // Additional init code here

    };

    // Load the SDK Asynchronously
    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    } (document));
</script>



</asp:Content>

