<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebAccSetup.aspx.cs" Inherits="ACC.WebAccSetup" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 150px;">
                <asp:Label ID="Label1" runat="server" Text="حساب المصاريف البنكية"></asp:Label>
            </td>
            <td style="width: 300px;">
                <asp:DropDownList ID="ddlBankExpAcc" Width="275" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlBankExpAcc"
                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المصاريف البنكية"
                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
            </td>
            <td style="width: 150px;">
            </td>
            <td style="width: 300px;">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Visible="false" OnClick="Button1_Click" Text="مطابقة الأرصدة" />
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
           <tr>
            <td style="width: 150px;">
                <asp:Label ID="Label2" runat="server" Text="سبب التعديل"></asp:Label>
            </td>
            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="275px" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
            </td>
            <td style="width: 150px;">
            </td>
            <td style="width: 300px;">
            </td>
        </tr>
        <tr align="right">
            <td colspan="4" style="text-align: center;">
                <asp:Label ID="LblCodesResult" runat="server" Text=""></asp:Label>
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
</asp:Content>
