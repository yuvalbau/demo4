<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PsyRegistration.aspx.cs" Inherits="PsyForCom.Account.PsyRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" style="margin-left: auto; margin-right: auto; width: 1000px">

    <div dir="rtl" style="margin-left: auto; margin-right: auto; width: 1000px">
        <h1 style="direction: rtl">דף רישום פסיכולוגים </h1>
    </div>
    <style type="text/css">
        .class1 {
            float: right;
            margin-left: 583px;
        }
    </style>
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" OnFinishButtonClick="Wizard1_FinishButtonClick" OnNextButtonClick="Wizard1_NextButtonClick" Style="margin-left: auto; margin-right: auto; width: 1000px" Font-Bold="False" ForeColor="Black" SideBarButtonStyle-BorderColor="#9900CC" SideBarStyle-BackColor="White" BorderStyle="None" SideBarButtonStyle-BorderStyle="None" SideBarStyle-Wrap="False">
        <FinishNavigationTemplate>
            <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious" Text="הקודם" />
            <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" Text="סיים" />
        </FinishNavigationTemplate>

        <SideBarTemplate>
            <asp:DataList ID="SideBarList" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="SideBarButton" runat="server" OnClientClick="return false;">LinkButton</asp:LinkButton>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <asp:LinkButton ID="SideBarButton" runat="server" OnClientClick="return false;">LinkButton</asp:LinkButton>
                </AlternatingItemTemplate>
                <SelectedItemTemplate>
                    <asp:LinkButton ID="SideBarButton" runat="server" Font-Bold="True" Font-Italic="True"
                        OnClientClick="return false;">LinkButton</asp:LinkButton>
                </SelectedItemTemplate>
            </asp:DataList>
        </SideBarTemplate>
        <SideBarButtonStyle BorderColor="#9900CC" BorderStyle="None"></SideBarButtonStyle>

        <SideBarStyle Wrap="False" BackColor="White"></SideBarStyle>
        <StartNavigationTemplate>
            <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="התחל הרשמה" />
        </StartNavigationTemplate>

        <StepNavigationTemplate>
            <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious" Text="הקודם" />
            <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="הבא" />
        </StepNavigationTemplate>

        <WizardSteps>
            <asp:WizardStep runat="server" StepType="Start" Title="הקדמה" ID="step0">
                <div>

                    <p>
                        על מנת להירשם לאתר,נא מלאו את הפרטים הטופס המקוון.
                           יש לקרוא את התקנון 
                        <a class="btn btn-default2" href="/Terms">תקנון &raquo;</a>
                    </p>

                </div>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="פרטים כלליים" StepType="Step" ID="step1">
                <table border="0" dir="rtl" style="height: 285px">
                    
                    <tr>
                        <td>שם פרטי </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="שדה זה הוא חובה" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>שם משפחה </td>
                        <td>
                            <asp:TextBox ID="TextLastName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextLastName" ErrorMessage="שדה זה הוא חובה" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">כתובת מייל </td>
                        <td class="auto-style3">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="שדה זה הוא חובה" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="כתובת האי מייל לא תקינה" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>מספר טלפון </td>
                        <td>
                            <asp:TextBox ID="txtPhoneNum" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhoneNum" ErrorMessage="שדה זה הוא חובה" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="מספר טלפון אינו תקין" ValidationExpression="^[0-9]*$" ControlToValidate="txtPhoneNum"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>מין: </td>
                        <td>
                            <asp:RadioButtonList ID="rdoGender" runat="server">
                                <asp:ListItem>זכר</asp:ListItem>
                                <asp:ListItem>נקבה</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdoGender" ErrorMessage="שדה זה הוא חובה" SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>תואר </td>
                        <td>
                            <asp:TextBox ID="txtDegree" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>מס' רשיון </td>
                        <td>
                            <asp:TextBox ID="txtLiecence" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>שנות נסיון </td>
                        <td>
                            <asp:TextBox ID="txtExperience" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>התמקצעות בתחום </td>
                        <td>
                            <asp:TextBox ID="txtSpeciality" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                </table>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="פרטי הקליניקה" StepType="Step">
                <table border="0" dir="rtl" style="height: 285px">
                    <tr>
                        <td>עיר </td>
                        <td>
                            <asp:TextBox ID="txtClinicLocation" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClinicLocation" ErrorMessage="שדה זה הוא חובה" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>רחוב </td>
                        <td>
                            <asp:TextBox ID="txtClinicStreet" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtClinicStreet" ErrorMessage="שדה זה הוא חובה" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>מספר רחוב </td>
                        <td>
                            <asp:TextBox ID="txtClinicStreetNum" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtClinicStreetNum" ErrorMessage="שדה זה הוא חובה" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>כתובת אי-מייל של המרפאה </td>
                        <td>
                            <asp:TextBox ID="txtClinicEmail" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtClinicEmail" Display="Dynamic" ErrorMessage="שדה זה הוא חובה" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtClinicEmail" Display="Dynamic" ErrorMessage="כתובת האי מייל לא תקינה" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>מספר טלפון: </td>
                        <td>
                            <asp:TextBox ID="txtClinicPhone" runat="server"></asp:TextBox>
                        </td>

                    </tr>


                    <tr>
                        <td>אתר אינטרנט </td>
                        <td>
                            <asp:TextBox ID="txtClinicWeb" runat="server" TextMode="Url"></asp:TextBox>
                        </td>
                    </tr>


                </table>
            </asp:WizardStep>

           
            <asp:WizardStep runat="server" Title="פרטים מקצועיים" StepType="Step">
                <div dir="rtl">
                    <div class="clas" dir="rtl">
                        <p>קבוצת מיקוד: </p>
                        <div>
                            <asp:CheckBoxList ID="CheckBoxMikud" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                <asp:ListItem Text="אישי" Value="1" />
                                <asp:ListItem Text="זוגות" Value="2" />
                                <asp:ListItem Text="משפחה" Value="3" />
                                <asp:ListItem Text="קבוצות" Value="4" />
                            </asp:CheckBoxList>

                        </div>
                        <br />

                    </div>
                    <div class="clas" dir="rtl">
                        <p>שפות:</p>
                        <asp:CheckBoxList ID="CheckBoxLang" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" EnableTheming="True">
                            <asp:ListItem Text="עברית" Value="1" />
                            <asp:ListItem Text="ערבית" Value="2" />
                            <asp:ListItem Text="רוסית" Value="3" />
                            <asp:ListItem Text="אנגלית" Value="4" />
                            <asp:ListItem Text="צרפתית" Value="5" />
                            <asp:ListItem Text="ספרדית" Value="6" />
                            <asp:ListItem Text="אידיש" Value="7" />
                            <asp:ListItem Text="רומנית" Value="8" />
                            <asp:ListItem Text="גרמנית" Value="9" />
                            <asp:ListItem Text="אמהרית" Value="10" />
                            <asp:ListItem Text="הונגרית" Value="11" />
                            <asp:ListItem Text="שפת הסימנים" Value="12" />
                        </asp:CheckBoxList>
                    </div>
                    <br />
                    <div>
                        <p>קבוצות גיל:</p>
                        <asp:CheckBoxList ID="CheckBoxAges" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                            <asp:ListItem Text="4-0" Value="1" />
                            <asp:ListItem Text="12-5" Value="2" />
                            <asp:ListItem Text="18-13" Value="3" />
                            <asp:ListItem Text="65-19" Value="4" />
                            <asp:ListItem Text="65+" Value="4" />
                        </asp:CheckBoxList>
                    </div>
                    <br />
                    <div>
                        <p>הערות:</p>
                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <br />
                </div>
            </asp:WizardStep>
            <asp:WizardStep runat="server" StepType="Step" Title="פרטי כניסה לאתר">
                <table border="0" dir="rtl" style="height: 285px">
                    <tr dir="rtl">
                        <th colspan="3" style="text-align: right">נא לבחור ססמא המורכבת מאותיות אנגליות ומספרים. מינימום 5 תווים עד 10 תווים:  </th>
                    </tr>
                    <tr>
                        <td>סיסמא: </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="SingleLine"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ErrorMessage="שדה זה הוא חובה" ForeColor="Red" ControlToValidate="txtPassword" runat="server" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="נא הכנס סיסמא באנגלית ומספרים מינימום 5 תווים ומקסימום 10 תווים" ValidationExpression="^[a-zA-Z1-9]{5,10}$" ControlToValidate="txtPassword"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>חזרה על סיסמא </td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CompareValidator ErrorMessage="הסיסמא אינה תואמת" ForeColor="Red" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="שדה זה הוא חובה" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep runat="server" StepType="Finish" Title="סיום הרשמה">
                <table class="table-general" dir="rtl">
                    <tr dir="rtl">

                        <td>פסיכולוג יקר,
                    תהליך ההרשמה הסתיים בהצלחה  !       
אנו שמחים על הצטרפותך למאגר 'פסיכולוגים למען הקהילה'  .    
בשעה זו מתבצע תהליך זיהוי לצורך אימות רישיונך בפנקס הפסיכולוגים.
בתום הזיהוי ישלח מייל לכתובת שהזנת ותתאפשר גישתך לאתר. 
לכל שאלה/בעיה ניתן לפנות כאן: (לינק).
                        </td>
                        </tr>
                    <tr>
                        <td>על מנת לסיים את תהליך ההרשמה יש ללחוץ על כפתור &quot;סיים&quot;.
                            <br />
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>

        </WizardSteps>
    </asp:Wizard>




</asp:Content>
