<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebSetup.aspx.cs" Inherits="ACC.WebSetup" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="card">
            <fieldset class="card-body">
                <div class="card-header">
                    <h4 class="card-title text-center">
                        أعدادات النظام
                    </h4>
                </div>
                <br />
                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label1" runat="server" Text="تسلسل الفواتير"></asp:Label>
                                *
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtInvNo" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="ValInvNo" runat="server" ControlToValidate="txtInvNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل الفواتير" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1">
                        <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label22" runat="server" Text="حساب الصندوق"></asp:Label>
                                *
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlCashAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValCashAcc" runat="server" ControlToValidate="ddlCashAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الصندوق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label2" runat="server" Text="تسلسل سندات القبض"></asp:Label>
                                *
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtRecNo" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="ValRecNo" runat="server" ControlToValidate="txtRecNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل سندات القبض" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1">
                        <asp:Label ID="lblBranch1" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label4" runat="server" Text="مصاريف التشغيل"></asp:Label>
                                *
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlExpAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValExpAcc" runat="server" ControlToValidate="ddlExpAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب مصاريف التشغيل"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label5" runat="server" Text="تسلسل سندات الصرف"></asp:Label>
                                *
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtPayNo" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="ValPayNo" runat="server" ControlToValidate="txtPayNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل سندات الصرف" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1">
                       <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label7" runat="server" Text="حساب الأيرادات"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlInComeAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValInComeAcc" runat="server" ControlToValidate="ddlInComeAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الأيرادات"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label8" runat="server" Text="تسلسل بيان الحركة"></asp:Label>
                                *
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtCarMoveNo" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCarMoveNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل بيان الحركة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1">
                       <asp:Label ID="lblBranch3" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label10" runat="server" Text="حساب الفرع"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlSiteAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValSiteAcc" runat="server" ControlToValidate="ddlSiteAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الفرع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>


                 <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label11" runat="server" Text="تسلسل سند أستلام "></asp:Label>
                                *
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtCarRcvNo" CssClass="form-control" MaxLength="10" runat="server"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCarRcvNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بداية تسلسل سند أستلام سيارة"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1">
                       <asp:Label ID="lblBranch4" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label3" runat="server" Text="المشروع"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlProject" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValProject" runat="server" ControlToValidate="ddlProject"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المشروع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label13" runat="server" Text="حساب الديزل"></asp:Label>*
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlDezelAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDezelAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الديزل" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1"></div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label6" runat="server" Text="المنطقة"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlArea" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValArea" runat="server" ControlToValidate="ddlArea"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المنطقة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label16" runat="server" Text="حساب بدل الرحلات"></asp:Label>*
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlTripAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTripAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب بدل الرحلات"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1"></div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label9" runat="server" Text="المدينة"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlCity" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValCity" runat="server" ControlToValidate="ddlCity"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المدينة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label12" runat="server" Text="حساب العملاء"></asp:Label>*
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlClientsAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlClientsAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب العملاء" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1"></div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                       <asp:Label ID="Label17" runat="server" Text="مصاريف مستحقة"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlCurExpAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCurExpAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب المصاريف المستحقة"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label18" runat="server" Text="حساب الخصم"></asp:Label>*
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlDiscountAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDiscountAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الخصم" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1"></div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                       <asp:Label ID="Label19" runat="server" Text="مصروفات نثرية"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlPettyExpAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlPettyExpAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الرد" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                         <asp:Label ID="Label20" runat="server" Text="حساب الرد"></asp:Label>*
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                         <asp:DropDownList ID="ddlRadAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlRadAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب المصاريف المستحقة"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1"></div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                       <asp:Label ID="Label21" runat="server" Text="ح العهدة المستديمة"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                       <asp:DropDownList ID="ddlLoanAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlLoanAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب العهدة المستديمة"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                         <asp:Label ID="Label24" runat="server" Text="حساب الارضية"></asp:Label>*
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                         <asp:DropDownList ID="ddlLateAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlLateAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الارضية" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-1 col-sm-1 col-xs-1"></div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                       <asp:Label ID="Label25" runat="server" Text="حساب الرسوم الإدارية"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                       <asp:DropDownList ID="ddlCancelInvAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlCancelInvAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب الرد" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                         <asp:Label ID="Label26" runat="server" Text="قيمة الارضية باليوم"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                         <asp:TextBox ID="txtLandDay" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                       <asp:Label ID="Label30" runat="server" Text="قيمة الارضية بالساعة"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                       <asp:TextBox ID="txtLandHour" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                         <asp:Label ID="Label28" runat="server" Text="رصيد الرسائل"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                         <asp:Label ID="lblSMS" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                       <asp:Label ID="Label23" runat="server" Text="حد الائتمان"></asp:Label>*
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                      <asp:TextBox ID="txtCrLimit" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label29" runat="server" Text="العنوان الوطني للفرع"></asp:Label>
                </div>

                 <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                          <asp:Label ID="Label31" runat="server" Text="رقم المبنى"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                         <asp:TextBox ID="txtAddr1" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                       <asp:Label ID="Label32" runat="server" Text="اسم الشارع"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                      <asp:TextBox ID="txtAddr2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                         <asp:Label ID="Label33" runat="server" Text="الحي"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtAddr3" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label34" runat="server" Text="المدينة"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtAddr4" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                          <asp:Label ID="Label35" runat="server" Text="البلد"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                     <asp:TextBox ID="txtAddr5" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                         <asp:Label ID="Label36" runat="server" Text="الرمز البريدي"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtAddr6" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label37" runat="server" Text="الرقم الإضافي"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                   <asp:TextBox ID="txtAddr7" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                       <asp:Label ID="Label38" runat="server" Text="رقم الوحدة"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                  <asp:TextBox ID="txtAddr8" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                        <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                  <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-6 col-xs-12">
                         <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-6 col-xs-12">
                  <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                    </div>
                    <div class="form-group col-md-1 col-sm-6 col-xs-12">
                 <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                     <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4"></div>
                    <div class="form-group col-md-4">
                        <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png"   ToolTip="تعديل أعدادات النظام"
                                    OnClientClick='return confirm("تعديل أعدادات النظام؟")' Width="64px" ValidationGroup="1"
                                    OnClick="BtnEdit_Click" />
                    </div>
                    <div class="form-group col-md-4">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                    </div>
                </div>
                 
            </fieldset>
        </div>

</asp:Content>
