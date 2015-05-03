<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PsyUpdate.aspx.cs" Inherits="PsyForCom.PsyPages.PsyUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div  dir="rtl">
            <h2>עדכון פרטים</h2>
            <h3>שינוי סטטוס זמינות :</h3>
            <p>*שינוי סטטוס ללא פנוי יסיר אותך זמנית מרשימת הפסיכולוגים.</p><br />
        <asp:Label ID="Label1" runat="server" Text="סטטוס:"></asp:Label>
        <asp:DropDownList ID="DropDownListStatus" runat="server">
            <asp:ListItem Value="1">זמין</asp:ListItem>
            <asp:ListItem Value="0">לא זמין</asp:ListItem>            
            </asp:DropDownList>
        <asp:Button runat="server" Text="עדכן סטטוס" OnClick="ChangeStatus" />
            
     
      </div>
</asp:Content>
