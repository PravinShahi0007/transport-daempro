<%@ Page Title="بلاغ حادث" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebAccident.aspx.cs" Inherits="ACC.WebAccident" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<div class="ColorRounded4Corners" style="width: 99.9%">
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.8%;
            border: solid 2px #800000">
            <legend align="right" style="font-size: 18px; color: #800000; text-align: center;">بلاغ حادث</legend>
            <table width="99%" cellpadding="5px" dir="rtl">
                <tr>
                    <td style="width: 150px;">
                        <asp:Label ID="Label1" runat="server" Text="رقم البلاغ"></asp:Label>
                        *
                    </td>
                    <td style="width: 300px;" colspan="2">
                        <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop"></asp:TextBox>
                        <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                            Display="Dynamic" ErrorMessage="يجب أختيار رقم البلاغ" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 150px;">
                    </td>
                    <td style="width: 300px;" align="left" colspan="2">
                        <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                            ToolTip="البحث عن بيانات بلاغ حادث" OnClick="BtnFind_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px;">
                        <asp:Label ID="Label4" runat="server" Text="التاريخ"></asp:Label>
                        *
                    </td>
                    <td style="width: 300px;" colspan="2">
                        <asp:TextBox ID="txtHDate" MaxLength="10" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHDate"
                            Display="Dynamic" ErrorMessage="يجب أختيار التاريخ الهجري" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                    </td>
                    <td style="width: 150px;">
                        <asp:Label ID="Label7" runat="server" Text="الموافق"></asp:Label>
                        *
                    </td>
                    <td style="width: 300px;" colspan="2">
                        <asp:TextBox ID="txtGDate" MaxLength="10" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtGDate"
                            Display="Dynamic" ErrorMessage="يجب أختيار التاريخ الميلادي" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGDate"
                            CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                            ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>م&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtGDate"
                            ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$"
                            runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                            TargetControlID="txtGDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                            PopupPosition="BottomLeft" />
                        <asp:Label ID="LblFTime" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <asp:Label ID="Label25" Font-Underline="true" ForeColor="#800000" runat="server"
                            Text="بيانات الرحلة"></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td style="width: 150px;">
                        <asp:Label ID="Label6" runat="server" Text="رقم بيان الترحيل"></asp:Label>
                    </td>
                    <td style="width: 300px;" colspan="2">
                        <asp:TextBox ID="txtCarMoveNo" MaxLength="10" runat="server" ></asp:TextBox>                        
                    </td>
                    <td style="width: 150px;">
                        <asp:Label ID="Label9" runat="server" Text="الشاحنة"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:TextBox ID="txtIDNo" MaxLength="15" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 150px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 150px;">
                        <asp:Label ID="Label10" runat="server" Text="السائق"></asp:Label>
                    </td>
                    <td style="width: 300px;" colspan="2">
                        <asp:TextBox ID="txtIDFrom" MaxLength="50" runat="server" Width="275px"></asp:TextBox>
                    </td>
                    <td style="width: 150px;">
                        <asp:Label ID="Label11" runat="server" Text="موقع الحادث"></asp:Label>
                    </td>
                    <td style="width: 300px;" colspan="2">
                        <asp:TextBox ID="txtIdDate" MaxLength="10" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtIdDate"
                            CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                            ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px;">
                        <asp:Label ID="Label3" runat="server" Text="من"></asp:Label>
                    </td>
                    <td style="width: 300px;" colspan="2">
                        <asp:TextBox ID="txtAddress" MaxLength="200" runat="server" Width="275px"></asp:TextBox>
                    </td>
                    <td style="width: 150px;">
                        <asp:Label ID="Label28" runat="server" Text="إلى"></asp:Label>
                    </td>
                    <td style="width: 300px;" colspan="2">
                        <asp:TextBox ID="txtMobileNo" MaxLength="20" runat="server"></asp:TextBox>
                    </td>
                </tr>
               </table>
        </fieldset>
        <br />
    </div>
--%>
</asp:Content>
