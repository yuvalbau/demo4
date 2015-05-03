<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersUpdate.aspx.cs" Inherits="PsyForCom.AdminPages.UsersUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:auto;margin-right:auto;width:1000px;overflow:auto">
        <div><h3>רשימת משתמשים</h3></div>
        <asp:GridView ID="GridViewUsers" runat="server" DataSourceID="SqlDataSourceUsers" AutoGenerateColumns="False" DataKeyNames="Id" style="margin-left:auto;margin-right:auto;width:1000px;overflow:auto"> 
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceUsers" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" SelectCommand="SELECT Id, FirstName, LastName, Email, UserName, Password, DateCreated, Role FROM Users"  DeleteCommand="DELETE FROM Users WHERE (Id = @id)" UpdateCommand="UPDATE Users SET FirstName =, LastName =, Email =, UserName =, Password =">
            <DeleteParameters>
                <asp:Parameter Name="id" />
            </DeleteParameters>
        </asp:SqlDataSource>
       
    </div>
</asp:Content>
