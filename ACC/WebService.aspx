<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" Culture="auto:ar-EG" UICulture="auto"
    CodeBehind="WebService.aspx.cs" Inherits="ACC.WebService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="Round4Courner" style="width: 99%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
                border: solid 2px #800000">
                <legend id="leg1" runat="server" align="<%$ Resources:Resource, dir2 %>" style="font-size: 18px; color: #800000; text-align: center;"><b>
                <asp:Literal ID="Literal2" Text="<%$ Resources:Header %>" runat="server"></asp:Literal></b></legend>
                <br />
                <center>
                    <table width="100%" cellpadding="2px">
                        <tr>
                            <td style="width: 137px;">
                                <asp:Label ID="LblCode" runat="server" Text="كود الخدمة*" meta:resourcekey="LblCode" ></asp:Label>
                            </td>
                            <td style="width: 280px; margin-right: 40px;" colspan="3">
                                <asp:TextBox ID="txtITCode" Width="100px" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="<%$ Resources:SearchCode %>" OnClick="BtnFind_Click" />
                                <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtITCode"
                                    ErrorMessage="<%$ Resources:EnterCode %>" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 120px;">
                                &nbsp;
                            </td>
                            <td style="width: 280px;" colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px;">
                                <asp:Label ID="Label2" runat="server" Text="الاسم عربي" meta:resourcekey="Label2"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtITName1" Width="280px" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="width: 120px;">
                                <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي" meta:resourcekey="Label3"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtITName2" Width="280px" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px;">
                                <asp:Label ID="Label5" runat="server" Text="حساب المصروف" meta:resourcekey="Label5"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:DropDownList ID="ddlExpenses" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 120px;">
                                <asp:Label ID="Label6" runat="server" Text="حساب الايراد" meta:resourcekey="Label6"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:DropDownList ID="ddlRevenue" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px;">
                                <asp:Label ID="Label1" runat="server" Text="الحد الادنى / ساعة" meta:resourcekey="Label1"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtLTime" Width="100px" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLTime"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:NumericValue %>" ForeColor="Red" Type="Double"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td style="width: 120px;">
                                <asp:Label ID="Label4" runat="server" Text="الحد الاقصى / ساعة" meta:resourcekey="Label4"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtHTime" Width="100px" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtHTime"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:NumericValue %>" ForeColor="Red" Type="Double"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px;">
                                <asp:Label ID="Label26" runat="server" Text="السعر" meta:resourcekey="Label26"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtITSPrice1" Width="100px" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtITSPrice1"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:NumericValue %>" ForeColor="Red" Type="Currency"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td style="width: 120px;">
                            </td>
                            <td style="width: 280px;" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم" meta:resourcekey="Label14"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtUserName" Width="300px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 120px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ" meta:resourcekey="Label15"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية" meta:resourcekey="Label27"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px;">
                                &nbsp;
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            </td>
                            <td style="width: 120px;">
                                &nbsp;
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="8">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="<%$ Resources:New %>" CommandName="New"
                                    ImageUrl="<%$ Resources:NewImage %>" CssClass="ops" ToolTip="<%$ Resources:NewTooltip %>"
                                    ValidationGroup="1" OnClientClick='<%$ Resources:NewConfirm %>'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="<%$ Resources:Edit %>" CommandName="Edit"
                                    ImageUrl="<%$ Resources:EditImage %>" CssClass="ops" ToolTip="<%$ Resources:EditTooltip %>"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="<%$ Resources:Clear %>" CommandName="Clear"
                                    ImageUrl="<%$ Resources:ClearImage %>" CssClass="ops" ToolTip="<%$ Resources:ClearTooltip %>"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="<%$ Resources:Delete %>" CommandName="Delete"
                                    ImageUrl="<%$ Resources:DeleteImage %>" CssClass="ops" ToolTip="<%$ Resources:DeleteTooltip %>" OnClientClick='<%$ Resources:DeleteConfirm %>'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="<%$ Resources:Search %>" CommandName="Find"
                                    ImageUrl="<%$ Resources:SearchImage %>" CssClass="ops" ToolTip="<%$ Resources:SearchTooltip %>"
                                    OnClick="BtnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
            </fieldset>
        </div>
    </center>
    <br />
</asp:Content>
