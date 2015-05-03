<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="PsyForCom.Account.PasswordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:auto;margin-right:auto;width:1000px" dir="rtl">
            
        <h1 id="Title1" runat="server">  דף איפוס סיסמא :</h1>
        
      

        <div id="id1">
            <p>
                <label id="userName" runat="server">שם משתמש:</label>
                <asp:TextBox ID="txtUserName" runat="server" />
            </p>
             <p>
                <label id="Email" runat="server">כתובת מייל:</label>
                <asp:TextBox ID="txtEmail" runat="server" />
            </p>
            <p>
                <label id="Liecence" runat="server">מס' רשיון:</label>
                <asp:TextBox ID="txtLiecence" runat="server" />
            </p>
            <p>
                <label id="NewPassword" runat="server">סיסמא חדשה:</label>
                <asp:TextBox ID="txtNewPassword" runat="server"   TextMode="Password" />
                <asp:RequiredFieldValidator ControlToValidate="txtNewPassword" ID="RequiredFieldValidator1" runat="server" ErrorMessage="שדה זה הינו חובה"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="Button" runat="server" Text="אפס סיסמא" OnClick="btnLogin_Click" />
            </p>
        </div>
      
    </div>
</asp:Content>
