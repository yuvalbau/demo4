<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PsyForCom.Account.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
     
    <div class="row" id="defalutItem" style="margin-left:auto;margin-right:auto;width:1000px">
        <link rel="stylesheet" href="/style.css" type="text/css" />
    <div class="col-md-3" style="float:right" >
    
        <h1>דף כניסה למשתמשים</h1>
        
            <p>
     <asp:DropDownList ID="DropDownList1" runat="server" >
        <asp:ListItem value="1">כניסה למשתמשים רשומים</asp:ListItem>
        <asp:ListItem Value="2">כניסה לפסיכולוגים רשומים</asp:ListItem>
        <asp:ListItem Value="3">כניסת מנהל אתר</asp:ListItem>
    </asp:DropDownList>
            </p>
     <p>Username: <input id="Username" runat="server" type="text"/><br />
        Password: <input id="Password" runat="server" type="password"/><br/>
    <asp:Button id="btnLogin" runat="server" OnClick="btnLogin_Click"
     Text="Login"/>
    <asp:Label id="ErrorLabel" runat="Server" ForeColor="Red"
     Visible="false"/></p>
        <p></p>
        <asp:Button ID="Button1" runat="server" Text="שכחת סיסמא?" OnClick="btnPasswordRecovery" />
        
        <p>*במידה ושכחת את הסיסמא שלך נא בחר את אופן הכניסה(פסיכולוג/משתמש) בתחילת העמוד ולאחר מכן על כפתור "שכחת סיסמא". </p>
    </div>
         <% if (!HttpContext.Current.User.IsInRole("Psychologist"))
            { %>                                   
    <div class="col-md-3" id="defalutItem1" style="float:right">       
            <h1>הרשמה לאתר</h1>         
            <p>
                <a class="btnnn" runat="server" href="UserRegister.aspx" >
                לחץ כאן על מנת להרשם &raquo</a>
            </p>
        </div>
         <%} %>
        
          </div>
</asp:Content>
