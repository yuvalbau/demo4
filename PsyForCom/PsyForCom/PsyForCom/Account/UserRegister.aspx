<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="PsyForCom.Account.UserRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div dir="rtl" style="margin-left:auto;margin-right:auto;width:1000px">
        
        <h1>דף הרשמה  </h1>
    
        <table border="0" >
    
            <tr>
        <td colspan="3">
            &nbsp;</td>
    </tr>
           <tr>
        <td>
            שם פרטי
        </td>
        <td>
            <asp:TextBox ID="TextName" runat="server" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextName"
                runat="server" />
        </td>
            </tr>
           <tr>
        <td>
            שם משפחה
        </td>
        <td>
            <asp:TextBox ID="TextLastName" runat="server" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextLastName"
                runat="server" />
        </td>
          </tr>
             <tr>
        <td>
            כתובת מייל
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="שדה זה הוא חובה" Display="Dynamic" ForeColor="Red"
                ControlToValidate="txtEmail" runat="server" />
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="כתובת האי מייל לא תקינה" />
        </td>
    </tr>
    <tr>
        <td>
            שם משתמש
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            סיסמא
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="שדה זה הוא חובה" ForeColor="Red" ControlToValidate="txtPassword"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            חזור על הסיסמא
        </td>
        <td>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
        </td>
        <td>
            <asp:CompareValidator ErrorMessage="הסיסמא לא תואמת" ForeColor="Red" ControlToCompare="txtPassword"
                ControlToValidate="txtConfirmPassword" runat="server" />
        </td>
    </tr>
   
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="הרשם" />
        </td>
        <td>
        </td>
    </tr>
</table>
    </div>
    


</asp:Content>
