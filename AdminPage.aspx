<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:GridView ID="UsersGridView" CellSpacing="10" CellPadding="15" 
        GridLines="None" OnRowDeleting="DeleteUser" AutoGenerateColumns="false"
        runat="server" 
        onselectedindexchanged="UsersGridView_SelectedIndexChanged" >
    <Columns>
        <asp:BoundField DataField="userId" HeaderText="מספר משתמש" ReadOnly="True" /> 
        <asp:BoundField DataField="name" HeaderText="שם" ReadOnly="True" />
        <asp:BoundField DataField="email" HeaderText="אימייל" ReadOnly="True" />
        <asp:BoundField DataField="userPassword" HeaderText="סיסמא" ReadOnly="True" />
        <asp:BoundField DataField="gender" HeaderText="מין" ReadOnly="True" />
        <asp:BoundField DataField="creationDate" HeaderText="תאריך יצירה" ReadOnly="True" />
        <asp:BoundField DataField="phone" HeaderText="טלפון" ReadOnly="True" />
        <asp:BoundField DataField="isAdmin" HeaderText="מנהל" ReadOnly="True" />
        <asp:ImageField DataImageUrlField="picture" ControlStyle-Width="40px" ControlStyle-Height="40px" HeaderText=""></asp:ImageField>
        <asp:ButtonField ButtonType="Button" runat="server" CommandName="Delete" Text="מחק" />
        <asp:ButtonField ButtonType="Button" runat="server" CommandName="Select" Text="ערוך" />
    </Columns>
    </asp:GridView>


</asp:Content>

