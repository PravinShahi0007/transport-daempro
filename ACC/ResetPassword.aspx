<%@ Page Title="" Language="C#" MasterPageFile="~/MySiteNoMenu.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="ACC.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel12" runat="server" Height="30px" Width="100%" Font-Bold="False" Direction="RightToLeft">
        <div id="Div7" runat="server">
            <div id="topban">
                <div id="Div16" runat="server">
                    <ul id="Ul1" runat="server">
                        <li id="Home" runat="server"><a href="default.aspx">
                            <asp:Label ID="lblRstPass" Text="الرئيسية" runat="server" meta:resourcekey="lblRstPass"></asp:Label></a></li>
                        <li><a href="logout.aspx">
                            <asp:Label ID="lblLogout" Text="تسجيل خروج" runat="server" meta:resourcekey="lblLogout"></asp:Label></a></li>
                    </ul>
                    <br style="clear: both" />
                </div>
                <br style="clear: both" />
            </div>
        </div>
    </asp:Panel>
    <br />
    <center id="center1" runat="server">
        <div class="minheight">
            <asp:Panel ID="Panel3" runat="server" Height="300" CssClass="ShadowPanel" Width="95%"
                Direction="RightToLeft">
                <h2>
                    <asp:Label ID="Label4" runat="server" ForeColor="#0D3D87" Text="تغيير كلمة المرور" meta:resourcekey="Label4"></asp:Label></h2>
                <center>
                    <table id="Table1" runat="server" width="60%" cellpadding="2" style="color: Black;">
                        <tr id="tr1" runat="server">
                            <td style="width: 120px;">
                                <asp:Label ID="LblCode" runat="server" Text="كلمة المرور الحالية" meta:resourcekey="LblCode"></asp:Label>
                            </td>
                            <td style="width: 250px">
                                <asp:TextBox ID="txtOldPassword" Width="150px" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValOldPassword" runat="server" ControlToValidate="txtOldPassword"
                                    Display="Dynamic" ErrorMessage="<%$ Resources: EnterCurrentPassword %>" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="tr2" runat="server">
                            <td style="width: 120px;">
                                <asp:Label ID="Label1" runat="server" Text="كلمة المرور الجديدة" meta:resourcekey="Label1"></asp:Label>
                            </td>
                            <td style="width: 250px">
                                <asp:TextBox ID="txtNewPassword" Width="150px" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValNewPassword" runat="server" ControlToValidate="txtNewPassword"
                                    Display="Dynamic" ErrorMessage="<%$ Resources: EnterNewPassword %>" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="tr3" runat="server">
                            <td style="width: 120px;">
                                <asp:Label ID="Label2" runat="server" Text="تأكيد كلمة المرور" meta:resourcekey="Label2"></asp:Label>
                            </td>
                            <td style="width: 250px">
                                <asp:TextBox ID="txtNewPassword2" Width="150px" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValNewPassword2" runat="server" ControlToValidate="txtNewPassword2"
                                    Display="Dynamic" ErrorMessage="<%$ Resources: ConfirmPassword %>" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValNewPassword3" runat="server" ForeColor="Red" ControlToCompare="txtNewPassword"
                                    Display="Dynamic" ControlToValidate="txtNewPassword2" Operator="Equal" 
                                    ErrorMessage="<%$ Resources:MismatchPassword %>">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr id="tr50" runat="server">
                            <td colspan="2" align="center">
                                <asp:Literal ID="ltHome" Visible="true" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr id="tr5" runat="server">
                            <td style="width: 120px;">
                            </td>
                            <td style="width: 250px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr id="tr6" runat="server">
                            <td style="width: 120px;">
                                <asp:Label ID="lblReason" runat="server" Text="سبب التعديل" meta:resourcekey="lblReason"></asp:Label>
                            </td>
                            <td style="width: 250px">
                                <asp:TextBox ID="txtReason" Width="225px" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="<%$ Resources:EditReason %>" ForeColor="Red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr id="tr4" runat="server">
                            <td style="width: 120px;">
                            </td>
                            <td style="width: 250px">
                                <asp:Button ID="BtnConfirm" Width="100px" runat="server" Text="موافق" OnClick="BtnConfirm_Click"
                                    Style="height: 26px" meta:resourcekey="BtnConfirm" />
                                <asp:Button ID="BtnClear" Width="100px" ValidationGroup="2" runat="server" Text="مسح"
                                    OnClick="BtnClear_Click" meta:resourcekey="BtnClear" />
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:Panel>
            <br style="clear: both;" />
        </div>
    </center>
</asp:Content>
