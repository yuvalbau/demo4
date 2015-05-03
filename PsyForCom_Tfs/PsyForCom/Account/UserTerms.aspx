<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserTerms.aspx.cs" Inherits="PsyForCom.Account.UserTerms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <tr>
    <td><div dir="rtl">
    
        <h1>דף כניסה משתמשים </h1>
    
        <table border="0" >
    <tr>
        <th colspan="3">
            תקנון שימוש בשירות
        </th>
    </tr>
            <tr>
        <td > הצהרת משתמש:</td  >
    </tr>
           <tr>
        <td>
         
אני מצהיר/ה בזאת כי ידוע לי שהשירות מיועד לאנשים בעלי הכנסה נמוכה, אשר אינם יכולים לכלכל טיפול פסיכולוגי פרטי.
 מתוקף הצטרפותי לשירות זה אני מעיד/ה כי אני עונה לקריטריונים המפורטים לעיל. 
        </td>
                
               </tr>
              <tr>
        
        <td>
              <a class="btn btn-default" href="/Terms">תקנון &raquo;</a><br />
           
            <asp:Button Text="הבא" runat="server" OnClick="RegisterUser"/>
        </td>
        
    </tr>
    
</table>
    </div>
    

    </td>
</tr>
    

</asp:Content>
