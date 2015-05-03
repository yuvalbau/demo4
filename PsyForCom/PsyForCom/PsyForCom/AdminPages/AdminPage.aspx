<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="PsyForCom.AdminPages.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:auto;margin-right:auto;width:1000px">
        <div ><h2>דף מנהל</h2></div>
        <div>
            <asp:DropDownList ID="DropDownListAdmin" runat="server" >
            <asp:ListItem value="1">לניהול משתמשים רשומים</asp:ListItem>
            <asp:ListItem Value="2">לניהול לפסיכולוגים רשומים</asp:ListItem>              
    </asp:DropDownList><br />
        </div>
        <asp:Button ID="Button1" runat="server" Text="המשך" OnClick="Button1_Click" />

    </div>

</asp:Content>
