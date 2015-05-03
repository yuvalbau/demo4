<%@ Page UICulture="he-IL" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PsyList.aspx.cs" Inherits="PsyForCom.PsyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div dir="rtl" style="margin-left: auto; margin-right: auto; width: 1000px; overflow: auto">
        <link rel="stylesheet" href="/style.css" type="text/css" />
        <h2>רשימת פסיכולוגים</h2>
        <%----%>
        <p>
            <% if (HttpContext.Current.User.IsInRole("User"))
               { %>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1" Style="margin-left: auto; margin-right: auto; width: 1000px; overflow: auto">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="שם פרטי" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="שם משפחה" SortExpression="LastName" />
                    <asp:BoundField DataField="Gender" HeaderText="מין" SortExpression="Gender" />
                    <asp:BoundField DataField="Experience" HeaderText="שנות נסיון" SortExpression="Experience" />
                    <asp:BoundField DataField="Degree" HeaderText="תואר" SortExpression="Degree" />
                    <asp:BoundField DataField="City" HeaderText="עיר" SortExpression="City" />                                       
                    <asp:BoundField DataField="Phone" HeaderText="טלפון" SortExpression="Phone" />
                    <asp:BoundField DataField="WebSite" HeaderText="אתר" SortExpression="WebSite" />
                    <asp:BoundField DataField="Speciality" HeaderText="התמחות" SortExpression="Speciality" />
                    <asp:BoundField DataField="Mikud" HeaderText="קבוצות מיקות" SortExpression="Mikud" />
                    <asp:BoundField DataField="Languages" HeaderText="שפות" SortExpression="Languages" />
                    <asp:BoundField DataField="Ages" HeaderText="גילאים" SortExpression="Ages" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" SelectCommand="SELECT PsycologistInfo.FirstName, PsycologistInfo.LastName, PsycologistInfo.Gender, PsycologistInfo.Experience, PsycologistInfo.Degree, ClinicInfo.City, PsycologistInfo.Phone, ClinicInfo.WebSite, TherapyInfo.Speciality, TherapyInfo.Mikud, TherapyInfo.Languages, TherapyInfo.Ages FROM [ClinicInfo] INNER JOIN [PsycologistInfo] ON ClinicInfo.C_Id = PsycologistInfo.P_Id INNER JOIN TherapyInfo ON ClinicInfo.C_Id = TherapyInfo.Id And PsycologistInfo.Availability=1"></asp:SqlDataSource>
            <%} %>
            <% if (HttpContext.Current.User.IsInRole("Admin"))
               { %>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Font-Size="Smaller" Style="margin-left: auto; margin-right: auto; width: 1000px; overflow: auto" DataKeyNames="P_Id">
                <Columns>

                    <asp:BoundField DataField="FirstName" HeaderText="שם פרטי" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="שם משפחה" SortExpression="LastName" />
                    <asp:BoundField DataField="Email" HeaderText="כתובת מייל" SortExpression="Email" />
                    <asp:BoundField DataField="Phone" HeaderText="מספר טלפון" SortExpression="Phone" />
                    <asp:BoundField DataField="Gender" HeaderText="מין" SortExpression="Gender" />
                    <asp:BoundField DataField="Experience" HeaderText="שנות נסיון" SortExpression="Experience" />
                    <asp:BoundField DataField="License" HeaderText="מס' רשיון" SortExpression="License" />
                    <asp:BoundField DataField="Degree" HeaderText="תואר" SortExpression="Degree" />
                    <asp:BoundField DataField="City" HeaderText="עיר המרפאה" SortExpression="City" />
                    <asp:BoundField DataField="Street" HeaderText="רחוב המרפאה" SortExpression="Street" />
                    <asp:BoundField DataField="Number" HeaderText="מספר רחוב" SortExpression="Number" />
                    <asp:BoundField DataField="PhoneNum" HeaderText="טלפון מרפאה" SortExpression="PhoneNum" />
                    <asp:BoundField DataField="WebSite" HeaderText="אתר" SortExpression="WebSite" />
                    <asp:BoundField DataField="Speciality" HeaderText="התמחות" SortExpression="Speciality" />
                    <asp:BoundField DataField="Availability" HeaderText="זמינות" SortExpression="Availability" />
                    <asp:BoundField HeaderText="ID" DataField="P_Id" />
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="True" />


                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>"
                SelectCommand="SELECT PsycologistInfo.FirstName, PsycologistInfo.LastName, PsycologistInfo.Email, PsycologistInfo.Phone, PsycologistInfo.Gender, PsycologistInfo.Experience, PsycologistInfo.License, PsycologistInfo.Degree, ClinicInfo.City, ClinicInfo.Street, ClinicInfo.Number, ClinicInfo.PhoneNum, ClinicInfo.WebSite, TherapyInfo.Speciality, PsycologistInfo.Availability, PsycologistInfo.P_Id FROM [ClinicInfo] INNER JOIN [PsycologistInfo] ON ClinicInfo.C_Id = PsycologistInfo.P_Id INNER JOIN TherapyInfo ON ClinicInfo.C_Id = TherapyInfo.Id"
                DeleteCommand="DELETE FROM PsycologistInfo WHERE (P_Id = @P_Id);Delete FROM ClinicInfo Where (C_Id=@P_Id);DELETE FROM TherapyInfo WHERE (Id=@P_Id);" 
                UpdateCommand="UPDATE PsycologistInfo SET PsycologistInfo.Availability = @Availability WHERE P_Id = @P_Id" OnUpdating="SqlDataSource3_Updating">
                <DeleteParameters>
                    <asp:Parameter Name="ID"  />
                </DeleteParameters>
                <UpdateParameters>

                    <asp:Parameter Name="Availability" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <%} %>
        </p>

    </div>
    <div>
        <asp:Label ID="lblresult" runat="server"></asp:Label>
    </div>
</asp:Content>
