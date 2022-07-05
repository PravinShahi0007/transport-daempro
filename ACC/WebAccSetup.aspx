<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebAccSetup.aspx.cs" Inherits="ACC.WebAccSetup" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-row">
        <div class="form-group col-sm-2">
            <asp:Label ID="Label1" runat="server" Text="حساب المصاريف البنكية"></asp:Label>
        </div>
        <div class="form-group col-sm-3">
            <asp:DropDownList ID="ddlBankExpAcc" CssClass="form-control" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlBankExpAcc"
                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المصاريف البنكية"
                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-sm-3">
            <asp:Button ID="Button1" runat="server" Visible="false" CssClass="btn btn-primary" OnClick="Button1_Click" Text="مطابقة الأرصدة" />
        </div>
        <div class="form-group col-sm-4"></div>
    </div>
    <div class="form-row">
        <div class="form-group col-sm-2">
            <asp:Label ID="Label2" runat="server" Text="سبب التعديل"></asp:Label>
        </div>
        <div class="form-group col-sm-3">
            <asp:TextBox ID="txtReason" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-sm-2">
            <asp:Label ID="LblCodesResult" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group col-sm-2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
        <div class="form-group col-sm-3"></div>
    </div>
    <div class="form-row">
        <div class="form-group col-sm-3"></div>
        <div class="form-group col-sm-3">
            <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                    ImageUrl="~/images/edit2.png"   ToolTip="تعديل أعدادات النظام"
                    OnClientClick='return confirm("تعديل أعدادات النظام؟")' Width="64px" ValidationGroup="1"
                    OnClick="BtnEdit_Click" />
        </div>
        <div class="form-group col-sm-6"></div>
        
    </div>
</asp:Content>
