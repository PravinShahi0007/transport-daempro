<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebAppConfig.aspx.cs" Inherits="ACC.WebAppConfig" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [إعدادات التوقيت / التطبيق ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">

                         <tr align="right">
                            <td style="width: 200px;">
                                <asp:Label ID="Label10" runat="server" Text="وقت تحديث الموقع الحالي للسائق*"></asp:Label>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txttime1" Width="100px" runat="server" MaxLength="100"></asp:TextBox> / ثانية
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttime1"
                                    Display="Dynamic" ErrorMessage="يجب تحديد الوقت" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txttime1"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </td>
                  
                        </tr>

                        <tr align="right">

                          <td style="width: 200px;">
                                <asp:Label ID="Label4" runat="server" Text="وقت تحديث طلبات شحن سيارة/إكسبرس*"></asp:Label>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txttime2" Width="100px" runat="server" MaxLength="50"></asp:TextBox> / ثانية
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttime2"
                                    Display="Dynamic" ErrorMessage="يجب تحديد الوقت" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txttime2"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </td>

                          </tr>

                            <tr align="right">
                          <td style="width: 200px;">
                                <asp:Label ID="Label3" runat="server" Text="وقت تحديث طلبات طوارئ/مياه/غاز*"></asp:Label>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txttime3" Width="100px" runat="server" MaxLength="50" ></asp:TextBox> / ثانية
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttime3"
                                    Display="Dynamic" ErrorMessage="يجب تحديد الوقت" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txttime3"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </td>

                          </tr>

                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label8" runat="server" Text="تاريخ الادخال"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </td>
                        </tr>

                        <tr align="center">
                            <td colspan="5">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            </td>
                        </tr>
                         <tr align="center">
                            <td colspan="5">
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل إعدادات التوقيت" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                            </td>
                        </tr>

                    </table>
                </center>
                <br />
              
        <br />                
            </fieldset>

           
        </div>
        <br />

</asp:Content>
