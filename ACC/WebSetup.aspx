<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebSetup.aspx.cs" Inherits="ACC.WebSetup" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ أعدادات النظام ]"></asp:Label>
                </b></legend>
                <center>
                    <table width="99.9%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label1" runat="server" Text="تسلسل الفواتير"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtInvNo" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="ValInvNo" runat="server" ControlToValidate="txtInvNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل الفواتير" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label22" runat="server" Text="حساب الصندوق"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlCashAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValCashAcc" runat="server" ControlToValidate="ddlCashAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الصندوق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label2" runat="server" Text="تسلسل سندات القبض"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtRecNo" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:Label ID="lblBranch1" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="ValRecNo" runat="server" ControlToValidate="txtRecNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل سندات القبض" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label4" runat="server" Text="مصاريف التشغيل"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlExpAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValExpAcc" runat="server" ControlToValidate="ddlExpAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب مصاريف التشغيل"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label5" runat="server" Text="تسلسل سندات الصرف"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtPayNo" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="ValPayNo" runat="server" ControlToValidate="txtPayNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل سندات الصرف" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label7" runat="server" Text="حساب الأيرادات"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlInComeAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValInComeAcc" runat="server" ControlToValidate="ddlInComeAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الأيرادات"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label8" runat="server" Text="تسلسل بيان الحركة"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtCarMoveNo" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:Label ID="lblBranch3" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCarMoveNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل بيان الحركة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label10" runat="server" Text="حساب الفرع"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlSiteAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValSiteAcc" runat="server" ControlToValidate="ddlSiteAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الفرع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label11" runat="server" Text="تسلسل سند أستلام "></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtCarRcvNo" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:Label ID="lblBranch4" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCarRcvNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل سند أستلام سيارة"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label3" runat="server" Text="المشروع"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlProject" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValProject" runat="server" ControlToValidate="ddlProject"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المشروع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label13" runat="server" Text="حساب الديزل"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlDezelAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDezelAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الديزل" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label6" runat="server" Text="المنطقة"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlArea" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValArea" runat="server" ControlToValidate="ddlArea"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المنطقة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label16" runat="server" Text="حساب بدل الرحلات"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlTripAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTripAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب بدل الرحلات"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label9" runat="server" Text="المدينة"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlCity" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValCity" runat="server" ControlToValidate="ddlCity"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المدينة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label12" runat="server" Text="حساب العملاء"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlClientsAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlClientsAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب العملاء" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label17" runat="server" Text="مصاريف مستحقة"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlCurExpAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCurExpAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب المصاريف المستحقة"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label18" runat="server" Text="حساب الخصم"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlDiscountAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDiscountAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الخصم" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label19" runat="server" Text="مصروفات نثرية"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlPettyExpAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlPettyExpAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الرد" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label20" runat="server" Text="حساب الرد"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlRadAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlRadAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب المصاريف المستحقة"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label21" runat="server" Text="ح العهدة المستديمة"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlLoanAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlLoanAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب العهدة المستديمة"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label24" runat="server" Text="حساب الارضية"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlLateAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlLateAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الارضية" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label25" runat="server" Text="حساب الرسوم الإدارية"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:DropDownList ID="ddlCancelInvAcc" Width="275" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlCancelInvAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الرد" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label26" runat="server" Text="قيمة الارضية باليوم"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtLandDay" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label30" runat="server" Text="قيمة الارضية بالساعة"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtLandHour" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label28" runat="server" Text="رصيد الرسائل"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:Label ID="lblSMS" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label23" runat="server" Text="حد الائتمان"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtCrLimit" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label29" runat="server" Text="العنوان الوطني للفرع"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                            </td>
                            <td align="right" style="width: 175px">
                            </td>
                            <td align="right" style="width: 300px">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label31" runat="server" Text="رقم المبنى"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtAddr1" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label32" runat="server" Text="اسم الشارع"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                 <asp:TextBox ID="txtAddr2" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label33" runat="server" Text="الحي"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtAddr3" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label34" runat="server" Text="المدينة"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtAddr4" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label35" runat="server" Text="البلد"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtAddr5" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label36" runat="server" Text="الرمز البريدي"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtAddr6" Width="200px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label37" runat="server" Text="الرقم الإضافي"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtAddr7" Width="200px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 175px">
                                <asp:Label ID="Label38" runat="server" Text="رقم الوحدة"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtAddr8" Width="200px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table width="99.9%" cellpadding="3" cellspacing="0">
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="300px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="text-align: right;">
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل أعدادات النظام"
                                    OnClientClick='return confirm("تعديل أعدادات النظام؟")' Width="64px" ValidationGroup="1"
                                    OnClick="BtnEdit_Click" />
                            </td>
                            <td colspan="3" style="text-align: center;">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                            </td>
                        </tr>
                    </table>
                </center>
            </fieldset>
        </div>
    </center>
</asp:Content>
