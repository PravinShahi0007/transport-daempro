<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebClosePeriod.aspx.cs" Inherits="ACC.WebClosePeriod" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="form">
            <fieldset>
                <div class="form-group">
                    <h4 class="text-center alert-heading">[ أقفال الفترة]
                    </h4>
                </div>
                <br />
                <div class="form-row">
                    <div class="form-group col-sm-2">
                        <asp:Label ID="LblFrom" runat="server" Text="تاريخ أقفال الفترة"></asp:Label>
                    </div>
                    <div class="form-group col-sm-3">
                        <asp:TextBox ID="txtClosePeriod" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtClosePeriod"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ أقفال الفترة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtClosePeriod" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtClosePeriod"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtClosePeriod"
                                    ForeColor="Red" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$"
                                    runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:Label ID="lblReason" runat="server" Text="سبب التعديل"></asp:Label>
                    </div>
                    <div class="form-group col-sm-3">
                        <asp:TextBox ID="txtReason" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                    </div>
                </div>
                <br />
                <div class="form-row">
                    <div class="form-group col-sm-4"></div>
                    <div class="form-group col-sm-4">
                        <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
            ImageUrl="~/images/edit2.png" ToolTip="تعديل تاريخ أقفال الفترة" OnClientClick='return confirm("تعديل تاريخ أقفال الفترة؟")'
            Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                    </div>
                    <div class="form-group col-sm-4"></div>
                </div>
            </fieldset>
        </div>

        

</asp:Content>
