<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebUsers2.aspx.cs" Inherits="ACC.WebUsers2" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            SetMyStyle();
            $(function () {
                $("#tabs").css("visibility", "visible");
                $("#tabs").tabs({
                    event: "click",
                    select: function (e, i) {
                        var selected_tab = i.index;
                        $("#<%= hdnSelectedTab.ClientID %>").val(selected_tab);
                    }
                });
                $("#tabs").tabs('select', parseInt($("#<%= hdnSelectedTab.ClientID %>").val()));
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <asp:Panel ID="Panel3" runat="server" CssClass="ColorRounded4Corners">
            <center id="center1" style="direction: rtl">
                <table id="Table1" dir="rtl" width="99%" style="color: Black;">
                    <tr id="tr16" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="LblCode" runat="server" Text="رمز المستخدم"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" ReadOnly="true" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValName" runat="server" ControlToValidate="txtName"
                                ErrorMessage="يجب إدخال اسم المستخدم" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label12" runat="server" Text="نوع الحساب"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:DropDownList ID="ddlAccType" CssClass="form-control" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlAccType_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">سائق</asp:ListItem>
                                <asp:ListItem Value="2">عميل</asp:ListItem>
                                <asp:ListItem Value="3">مقدم خدمة</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left" rowspan="5" style="width: 120px;">
                            <img id="ImgPhoto" runat="server" src="images/123.jpg" alt="Photo" class="img-circle" />
                            <asp:FileUpload ID="FileUpload0" CssClass="form-control" runat="server" />
                            <asp:Button ID="BtnLoad0" runat="server" Text="تحميل" OnClick="BtnLoad0_Click" />
                        </td>
                    </tr>
                    <tr id="tr17" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label2" runat="server" Text="كلمة المرور"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                        </td>
                        <td style="width: 130px;">
                            <asp:CheckBox ID="ChkActive" runat="server" Text="تفعيل الحساب" />
                        </td>
                        <td style="width: 160px;">
                            <asp:CheckBox ID="ChkOnLine" runat="server" Text="الحالة: أونلاين" />
                        </td>
                    </tr>
                    <tr id="tr18" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label1" runat="server" Text="تأكيد كلمة المرور"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtPassword2" CssClass="form-control" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label35" runat="server" Text="رقم الهوية"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:TextBox ID="txtIDNo" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr19" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label3" runat="server" Text="الاسم الاول"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtFName" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label8" runat="server" Text="الاسم الاخير"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:TextBox ID="txtLName" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr20" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label4" runat="server" Text="الايميل"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:Button ID="BtnEmail" runat="server" Text="Email" Visible="false" OnClick="BtnEmail_Click" />
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label9" runat="server" Text="رقم الجوال"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:TextBox ID="txtCountryCode" CssClass="form-control" runat="server" MaxLength="5"></asp:TextBox>
                            <asp:Button ID="BtnSMS" runat="server" Text="SMS" Visible="false" OnClick="BtnSMS_Click" />
                        </td>
                    </tr>
                    <tr id="tr210" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label10" runat="server" Text="حساب المحفظة"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtAccount" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label6" runat="server" Text="رصيد المحفظة"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:TextBox ID="txtBal" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td align="center" style="width: 120px;">
                            <ajax:Rating runat="server" ID="MyRate" BehaviorID="RatingBehavior1" MaxRating="5"
                                CurrentRating="3" StarCssClass="Star" EmptyStarCssClass="Star" WaitingStarCssClass="WaitingStar"
                                FilledStarCssClass="FilledStar">
                            </ajax:Rating>
                        </td>
                    </tr>
                    <tr id="tr3" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label38" runat="server" Text="رصيد أفتتاحي مدين"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtOdacc" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:CompareValidator ID="Valodacc" runat="server" ControlToValidate="txtOdacc"
                                    Display="Dynamic" ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                    ValidationGroup="1" SetFocusOnError="True" EnableClientScript="False" Operator="DataTypeCheck">*</asp:CompareValidator>
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label39" runat="server" Text="رصيد أفتتاحي دائن"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:TextBox ID="txtOcacc" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtOcacc"
                                    Display="Dynamic" ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                    ValidationGroup="1" SetFocusOnError="True" EnableClientScript="False" Operator="DataTypeCheck">*</asp:CompareValidator>
                        </td>
                        <td align="center" style="width: 120px;">
                        </td>
                    </tr>
                    <tr id="tr211" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label27" runat="server" Text="نوع الجهاز"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtDevice_Type" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label28" runat="server" Text="رقم الإصدار"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:TextBox ID="txtDevice_OS_Version" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td align="center" style="width: 120px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr21" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label29" runat="server" Text="اسم الجهاز"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtDevice_Name" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label30" runat="server" Text="نظام التشغيل"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:TextBox ID="txtDevice_Label" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td align="center" style="width: 120px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr22" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label31" runat="server" Text="رقم إصدار التطبيق"></asp:Label>
                        </td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtApp_Version" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="width: 130px;">
                            <asp:Label ID="Label32" runat="server" Text="لغة الواجهة"></asp:Label>
                        </td>
                        <td style="width: 160px;">
                            <asp:DropDownList ID="ddlILang" runat="server" CssClass="form-control">
                                <asp:ListItem>Ar</asp:ListItem>
                                <asp:ListItem>En</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="center" style="width: 120px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr23" align="right">
                        <td style="width: 130px;">
                            <asp:Label ID="Label36" runat="server" Text="إرسال تنبيه"></asp:Label>
                        </td>
                        <td colspan="4" rowspan="4">
                            <asp:TextBox ID="txtNotify" runat="server" MaxLength="50" CssClass="form-control" TextMode="MultiLine"
                                Height="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr24" align="right">
                        <td style="width: 130px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr25" align="right">
                        <td style="width: 130px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr26" align="right">
                        <td style="width: 130px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr27" align="right">
                        <td style="width: 130px;">
                            &nbsp;
                        </td>
                        <td style="width: 230px">
                            &nbsp;
                        </td>
                        <td style="width: 130px;">
                            &nbsp;
                        </td>
                        <td style="width: 160px;">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 120px;">
                            <asp:Button ID="BtnSendNotify" Width="120px" runat="server" Text="أرسال" />
                        </td>
                    </tr>
                </table>
                <div id="DivDriverDetails" runat="server">
                    <table id="Table4" dir="rtl" width="98%" style="color: Black">
                        <tr id="tr212" align="right">
                            <td style="width: 130px;">
                                <asp:Label ID="Label33" runat="server" Text="الخدمات المتاحة"></asp:Label>
                            </td>
                            <td style="width: 230px" rowspan="6">
                                <asp:CheckBoxList ID="ChkRoles" Width="200px" runat="server" BorderStyle="Solid"
                                    BorderWidth="1" BorderColor="Maroon">
                                    <asp:ListItem Value="1">نقل سيارات</asp:ListItem>
                                    <asp:ListItem Value="2">شحن طرود</asp:ListItem>
                                    <asp:ListItem Value="3">خدمات الطريق</asp:ListItem>
                                    <asp:ListItem Value="4">الغاز</asp:ListItem>
                                    <asp:ListItem Value="5">المياة</asp:ListItem>
                                    <asp:ListItem Value="6">ليموزين</asp:ListItem>
                                    <asp:ListItem Value="7">مزودي الخدمة</asp:ListItem>
                                    <asp:ListItem Value="99">بيان ترحيل</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label5" runat="server" Text="مجال المنطقة"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtCardType" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                كم
                            </td>
                            <td align="center" style="width: 120px;">
                                <asp:CheckBox ID="ChkVersion" runat="server" Text="سائق متعاون" />
                            </td>
                        </tr>
                        <tr id="tr1" align="right">
                            <td style="width: 130px;">
                                &nbsp;
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label34" runat="server" Text="الفرع"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:DropDownList ID="ddlSites" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 120px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr213" align="right">
                            <td style="width: 130px;">
                                &nbsp;
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label7" runat="server" Text="ساعات العمل"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtWorkRate" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr214" align="right">
                            <td style="width: 130px;">
                                &nbsp;
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label13" runat="server" Text="معدل القبول"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtAcceptRate" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr215" align="right">
                            <td style="width: 130px;">
                                &nbsp;
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label16" runat="server" Text="الجنسية"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtNat" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                <asp:DropDownList ID="ddlNat" Width="150px" Visible="false" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 120px;">
                                <asp:RadioButtonList ID="RdoGender" runat="server" RepeatColumns="2">
                                    <asp:ListItem Selected="True" Value="0">ذكر</asp:ListItem>
                                    <asp:ListItem Value="1">أنثى</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="tr216" align="right">
                            <td style="width: 130px;">
                                &nbsp;
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label17" runat="server" Text="تاريخ الميلاد"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtDateofBirth" runat="server" MaxLength="12" CssClass="form-control"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtDateofBirth" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td align="center" style="width: 120px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr217" align="right">
                            <td style="width: 130px;">
                                <asp:Label ID="Label14" runat="server" Text="نوع المركبة"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtDCarType" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                <asp:DropDownList ID="ddlDCareType" Visible="false" Width="150px" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDCareType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label15" runat="server" Text="موديل المركبة"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtDCarModel" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                <asp:DropDownList ID="ddlDCarModel" Visible="false" Width="150px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 120px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr218" align="right">
                            <td style="width: 130px;">
                                <asp:Label ID="Label18" runat="server" Text="الحمولة"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtCarWeight" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label19" runat="server" Text="اللون"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtDCarColor" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr219" align="right">
                            <td style="width: 130px;">
                                <asp:Label ID="Label20" runat="server" Text="رقم اللوحة"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtDPlateNo" runat="server" MaxLength="12" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label21" runat="server" Text="اسم المالك"></asp:Label>
                            </td>
                             <td style="width: 160px;">
                                <asp:TextBox ID="txtCarOwner" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr220" align="right">
                            <td style="width: 130px;">
                                <asp:Label ID="Label22" runat="server" Text="رقم رخصة سير المركبة"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtPHDate1" runat="server" MaxLength="12" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label23" runat="server" Text="سنة الصنع"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtPHDate2" runat="server" MaxLength="12" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr221" align="right">
                            <td style="width: 130px; margin-right: 40px;">
                                <asp:Label ID="Label24" runat="server" Text="صلاحية التأمين"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtPHDate3" runat="server" MaxLength="12" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="width: 130px;">
                                <asp:Label ID="Label25" runat="server" Text="صلاحية تأمين الحمولة"></asp:Label>
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtPHDate4" runat="server" MaxLength="12" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr222" align="right">
                            <td style="width: 130px; margin-right: 40px;">
                                <asp:Label ID="lblAccount01" runat="server" Text="الحساب البنكي 1"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtAccountNo01" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="width: 130px;">
                                <asp:CheckBox ID="ChkAccount01" runat="server" Text="تفعيل حساب البنك" />
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtAccountName01" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                <asp:Button ID="BtnView01" runat="server" Text="عرض صورة الحساب" OnClientClick="aspnetForm.target ='_blank';" />
                            </td>
                        </tr>
                        <tr id="tr223" align="right">
                            <td style="width: 130px; margin-right: 40px;">
                                <asp:Label ID="lblAccount02" runat="server" Visible="false" Text="الحساب البنكي 2"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtAccountNo02" runat="server" MaxLength="100" Visible="false" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="width: 130px;">
                                <asp:CheckBox ID="ChkAccount02" runat="server" Visible="false" Text="تفعيل حساب البنك" />
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtAccountName02" runat="server" Visible="false" MaxLength="100"
                                    CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                <asp:Button ID="BtnView02" runat="server" Text="عرض صورة الحساب" Visible="false"
                                    OnClientClick="aspnetForm.target ='_blank';" />
                            </td>
                        </tr>
                        <tr id="tr224" align="right">
                            <td style="width: 130px; margin-right: 40px;">
                                <asp:Label ID="lblAccount03" runat="server" Visible="false" Text="الحساب البنكي 3"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtAccountNo03" runat="server" Visible="false" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="width: 130px;">
                                <asp:CheckBox ID="ChkAccount03" runat="server" Visible="false" Text="تفعيل حساب البنك" />
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtAccountName03" runat="server" Visible="false" MaxLength="100"
                                   CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                <asp:Button ID="BtnView03" runat="server" Text="عرض صورة الحساب" Visible="false"
                                    OnClientClick="aspnetForm.target ='_blank';" />
                            </td>
                        </tr>
                        <tr id="tr225" align="right">
                            <td style="width: 130px; margin-right: 40px;">
                                <asp:Label ID="lblAccount04" runat="server" Visible="false" Text="الحساب البنكي 4"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtAccountNo04" runat="server" Visible="false" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="width: 130px;">
                                <asp:CheckBox ID="ChkAccount04" runat="server" Visible="false" Text="تفعيل حساب البنك" />
                            </td>
                            <td style="width: 160px;">
                                <asp:TextBox ID="txtAccountName04" runat="server" Visible="false" MaxLength="100"
                                    CssClass="form-control"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 120px;">
                                <asp:Button ID="BtnView04" runat="server" Text="عرض صورة الحساب" Visible="false"
                                    OnClientClick="aspnetForm.target ='_blank';" />
                            </td>
                        </tr>
                    </table>
                </div>
                <table id="Table3" dir="rtl" width="98%" style="color: Black">
                    <tr align="right">
                        <td style="width: 100px;">
                            <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>
                        </td>
                        <td style="width: 250px;">
                            <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 75px;">
                        </td>
                        <td style="width: 250px;" colspan="2">
                        </td>
                    </tr>
                    <tr id="tr5" align="right">
                        <td style="width: 100px;">
                        </td>
                        <td style="width: 250px;">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                        </td>
                        <td style="width: 75px;">
                        </td>
                        <td style="width: 250px;" colspan="2">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                    <tr align="center">
                        <td style="width: 200px;">
                        </td>
                        <td style="width: 350px;">
                            <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                ImageUrl="~/images/insource_642.png" ToolTip="أضافة مستخدم جديد" ValidationGroup="1"
                                OnClick="BtnNew_Click" OnClientClick='return confirm("هل أنت متاكد من حفظ البيانات؟")' />
                            <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات مستخدم" Width="64px"
                                ValidationGroup="1" OnClick="BtnEdit_Click" />
                            <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                ImageUrl="~/images/erasure_642.png" ToolTip="مسح بيانات الشاشة" OnClick="BtnClear_Click" />
                            <asp:ImageButton ID="BtnDelete" ValidationGroup="1" runat="server" AlternateText="الفاء"
                                CommandName="Delete" ImageUrl="~/images/cut_642.png" ToolTip="الغاء بيانات مستخدم"
                                OnClick="BtnDelete_Click" OnClientClick='return confirm("هل أنت متاكد من الغاء البيانات؟")' />
                            <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="مراجعة" CommandName="Find"
                                ImageUrl="~/images/binoculars_642.png" ToolTip="مراجعة بيانات مستخدم" OnClick="BtnSearch_Click" />
                        </td>
                        <td id="td1" runat="server" style="width: 200px; text-align: right">
                            <asp:Label ID="Label11" runat="server" Text="بحث :"></asp:Label>
                            <asp:TextBox ID="txtSearch" MaxLength="200" Width="130px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <div style="text-align: left; width: 50%; float: left;">
                    <asp:Panel ID="Panel20" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                        Direction="RightToLeft" ForeColor="#FFFF99">
                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                                مرفقات ملف الموظف</div>
                            <div style="float: right; margin-right: 20px;">
                                <asp:Label ID="Label340" runat="server">(عرض التفاصيل)</asp:Label>
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel10" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                        BorderColor="Maroon">
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" AllowPaging="false"
                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                            Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء الملف"
                                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء الملف؟")' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الملف" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lblFileName" Text='<%# Bind("FileName") %>' NavigateUrl='<%# Bind("FileName2") %>'
                                            Target="_blank" runat="server"></asp:HyperLink>
                                    </ItemTemplate>
                                    <ControlStyle Width="300px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <table width="100%">
                            <tr>
                                <td align="right">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                        ValidationGroup="1" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel10"
                        ExpandControlID="Panel20" CollapseControlID="Panel20" Collapsed="True" TextLabelID="Label340"
                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                </div>
                <br />
                <br />
                <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True"
                        PageSize="20" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات المستخدم"
                                        ImageUrl="~/images/arrow_undo.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" Visible="false" SortExpression="ID" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# Bind("ID") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاسم الاول" SortExpression="FirstName" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" Text='<%# Bind("FirstName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاسم الاخير" SortExpression="LastName" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLastName" Text='<%# Bind("LastName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الجوال" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الإيميل" SortExpression="Email" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVersion" Text='<%# Bind("Email") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="175px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                            HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
                <br />
                <div class="demo">
                    <%--<div id="tabs" style="visibility:hidden;">--%>
                    <div id="tabs">
                        <ul>
                            <li><a href="#tabs-2">عمليات المستخدمين</a></li>
                            <li><a href="#tabs-3">الطلبات</a></li>
                            <li><a href="#tabs-5">التنبيهات</a></li>
                            <li><a href="#tabs-4">الشكاوي</a></li>
                            <li><a href="#tabs-1">أخرى</a></li>
                        </ul>
                        <div id="tabs-2">
                            <asp:GridView ID="grdUserLog" runat="server" CellPadding="4" ForeColor="#333333"
                                ShowFooter="True" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                DataKeyNames="TranDate" EmptyDataText="لا توجد بيانات" Width="99%" 
                                onpageindexchanging="grdUserLog_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="التاريخ" SortExpression="TranDate" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTranDate" Text='<%# Bind("TranDate") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="75px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="الوقت" SortExpression="TranTime" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTranTime" Text='<%# Bind("TranTime") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="75px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="المستخدم" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="75px" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="البيان" SortExpression="Description" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" Text='<%# Bind("Description") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="200px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="السبب" SortExpression="Reason" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReason" Text='<%# Bind("Reason") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IP" SortExpression="IP" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIP" Text='<%# Bind("IP") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="الموقع" SortExpression="Lat" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lbllat" Text='<%# Eval("lat2") %>' NavigateUrl='<%# string.Format("~/WebMap.aspx?lat={0}&lng={1}",Eval("lat"),Eval("lng")) %>'
                                                Target="_blank" runat="server"></asp:HyperLink>
                                        </ItemTemplate>
                                        <ControlStyle Width="30px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                    HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                        <div id="tabs-3">
                <table id="Table5" dir="rtl" width="99%" style="color: Black;">
                    <tr id="tr2" align="right">
                        <td style="width: 100px;">
                            <asp:Label ID="Label26" runat="server" Text="نوع الطلب"></asp:Label>
                        </td>
                        <td style="width: 130px">
                            <asp:DropDownList ID="ddlOrderType" CssClass="form-control" runat="server" 
                                AutoPostBack="True" onselectedindexchanged="ddlOrderType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">الجميع</asp:ListItem>
                                    <asp:ListItem Value="1">نقل سيارات</asp:ListItem>
                                    <asp:ListItem Value="2">شحن طرود</asp:ListItem>
                                    <asp:ListItem Value="3">خدمات الطريق</asp:ListItem>
                                    <asp:ListItem Value="4">الغاز</asp:ListItem>
                                    <asp:ListItem Value="5">المياة</asp:ListItem>
                                    <asp:ListItem Value="6">ليموزين</asp:ListItem>
                                    <asp:ListItem Value="7">مزودي الخدمة</asp:ListItem>
                                    <asp:ListItem Value="99">بيان ترحيل</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px;">
                            <asp:Label ID="Label37" runat="server" Text="حالة الطلب"></asp:Label>
                        </td>
                        <td style="width: 190px;">
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server" 
                                AutoPostBack="True" onselectedindexchanged="ddlOrderType_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="*">الجميع</asp:ListItem>
                                <asp:ListItem Value="-1">ملغي</asp:ListItem>
                                <asp:ListItem Value="0">تم الطلب</asp:ListItem>
                                <asp:ListItem Value="1">تم قبول الطلب</asp:ListItem>
                                <asp:ListItem Value="99">تم الانجاز</asp:ListItem>
                                <asp:ListItem Value="3">في الطريق إلى المرسل</asp:ListItem>
                                <asp:ListItem Value="4">تم الاستلام</asp:ListItem>
                                <asp:ListItem Value="5">في الطريق إلى المستلم</asp:ListItem>
                                <asp:ListItem Value="6">تم الوصول</asp:ListItem>
                                <asp:ListItem Value="8">في الطريق إلى منطقة التجميع</asp:ListItem>
                                <asp:ListItem Value="80">تم الوصول لمنطقة التجميع</asp:ListItem>
                                <asp:ListItem Value="81">تم التسليم لمنطقة التجميع</asp:ListItem>
                                <asp:ListItem Value="7">تم التسليم</asp:ListItem>
                              </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 240px;">
                            <asp:DropDownList ID="ddlSearch" Width="110px" runat="server">
                                <asp:ListItem Value="0">رقم الطلب</asp:ListItem>
                                <asp:ListItem Value="1">جوال المرسل</asp:ListItem>
                                <asp:ListItem Value="2">جوال المستلم</asp:ListItem>
                                <asp:ListItem Value="3">جوال السائق</asp:ListItem>
                              </asp:DropDownList>
                                <asp:TextBox ID="txtSearch2" MaxLength="20" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث " onclick="BtnFind_Click" style="width: 16px" />
                        </td>
                    </tr>
                </table>
                            <asp:GridView ID="grdOrders" runat="server" CellPadding="4" ForeColor="#333333"
                                ShowFooter="True" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                DataKeyNames="OrderID" EmptyDataText="لا توجد بيانات" Width="99%" 
                                onpageindexchanging="grdOrders_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="نوع الطلب" SortExpression="ServiceName" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblServiceName" Text='<%# Bind("ServiceName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="رقم الطلب" SortExpression="UIID" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUIID" Text='<%# Bind("UIID") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
<%--                                    <asp:TemplateField HeaderText="الحالة" SortExpression="StatusName" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatusName" Text='<%# Bind("StatusName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="75px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
--%>                                    <asp:TemplateField HeaderText="From" SortExpression="FromName" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromName" Text='<%# Bind("FromName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="To" SortExpression="ToName" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToName" Text='<%# Bind("ToName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="جوال المرسل" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                                    </asp:TemplateField>
                                <%--    <asp:TemplateField HeaderText="اسم المرسل" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="جوال المستلم" SortExpression="RecMobileNo" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecMobileNo" Text='<%# Bind("RecMobileNo") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                                    </asp:TemplateField>
                               <%--     <asp:TemplateField HeaderText="اسم المستلم" SortExpression="RecName" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecName" Text='<%# Bind("RecName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="جوال السائق" SortExpression="DriverMobileNo" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDriverMobileNo" Text='<%# Bind("DriverMobileNo") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                                    </asp:TemplateField>
                                 <%--   <asp:TemplateField HeaderText="اسم السائق" SortExpression="DriverName" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDriverName" Text='<%# Bind("DriverName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="150px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                    HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                        <div id="tabs-5">
                            <asp:GridView ID="grdNotify" runat="server" CellPadding="4" ForeColor="#333333"
                                ShowFooter="True" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                DataKeyNames="FDateTime" EmptyDataText="لا توجد بيانات" Width="99%" 
                                onpageindexchanging="grdNotify_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="التاريخ" SortExpression="FDateTime" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFDateTime" Text='<%# Bind("FDateTime") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="175px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="التنبيه" SortExpression="Msg" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" Text='<%# Bind("Msg") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="275px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                    HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                        <div id="tabs-4">
                            <table class="box-table-a" width="100%">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <p style="text-align: right">
                                                &nbsp;</p>
                                        </td>
                                        <td style="width: 25%">
                                            &nbsp;
                                        </td>
                                        <td style="width: 25%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <strong>&nbsp;</strong>
                                        </td>
                                        <td colspan="2">
                                            <strong>&nbsp;</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div id="tabs-1">
                            <table class="box-table-a" width="100%">
                                <tbody>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: right">
                                                <strong>&nbsp;</strong>&nbsp;&nbsp;
                                            </p>
                                        </td>
                                        <td style="width: 25%" colspan="2">
                                            &nbsp;
                                        </td>
                                        <td style="width: 25%" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </center>
        </asp:Panel>
        <asp:HiddenField ID="hdnSelectedTab" runat="server" Value="0" />
    </center>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</asp:Content>
