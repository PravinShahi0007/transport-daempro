<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebProfile.aspx.cs" Inherits="ACC.WebProfile" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Styles/PrevCheckList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" runat="server" CssClass="ColorRounded4Corners">
        <br />
        <center id="center1" style="direction: rtl">
            <table id="Table1" dir="rtl" width="98%" style="color: Black">
                <tr id="tr1" align="right">
                    <td style="width: 100px;">
                        <asp:Label ID="LblCode" runat="server" Text="اسم المستخدم"></asp:Label>
                    </td>
                    <td style="width: 175px">
                        <asp:TextBox ID="txtName" ReadOnly="true" Width="175px" runat="server" CssClass="MouseStop"
                            MaxLength="20"></asp:TextBox>
                    </td>
                    <td style="width: 100px;">
                        <asp:Label ID="Label33" runat="server" Text="عضو بمجموعة"></asp:Label>
                    </td>
                    <td style="width: 175px;">
                        <asp:TextBox ID="txtRole" ReadOnly="true" Width="175px" runat="server" CssClass="MouseStop"
                            MaxLength="20"></asp:TextBox>
                    </td>
                    <td rowspan="5" align="left" style="width: 150px;" >
                        <img id="ImgPhoto" runat="server" src="images/123.jpg" alt="Photo" class="img-circle" />
                    </td>
                </tr>
                <tr id="tr6" align="right">
                    <td style="width: 100px;">
                        <asp:Label ID="Label3" runat="server" Text="الاسم بالكامل"></asp:Label>
                    </td>
                    <td style="width: 175px;">
                        <asp:TextBox ID="txtFName" Width="175px" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="width: 100px;">
                        <asp:Label ID="Label36" runat="server" Text="الصلاحية البديلة"></asp:Label>                        
                    </td>
                    <td style="width: 175px;">
                        <asp:TextBox ID="txtBranRoll" ReadOnly="true" CssClass="MouseStop" Width="250px"
                            runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr id="tr7" align="right">
                    <td style="width: 100px;">
                        <asp:Label ID="Label35" runat="server" Text="الفرع الرئيسي"></asp:Label>
                    </td>
                    <td style="width: 175px;">
                        <asp:TextBox ID="txtMainBran" ReadOnly="true" CssClass="MouseStop" Width="175px"
                            runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="width: 100px;">
                        <asp:Label ID="Label34" runat="server" Text="الفروع البديلة"></asp:Label>
                    </td>
                    <td style="width: 175px;" rowspan="7">
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
                            BorderColor="Maroon" Width="100%" Height="175px">
                            <asp:CheckBoxList ID="ChkBranch" runat="server" Enabled="false" CssClass="MouseStop">
                            </asp:CheckBoxList>
                        </asp:Panel>
                    </td>
                </tr>
                <tr id="tr9" align="right">
                    <td style="width: 100px;">
                        <asp:Label ID="Label8" runat="server" Text="الايميل"></asp:Label>    
                    </td>
                    <td style="width: 175px;">
                        <asp:TextBox ID="txtEmail" Width="175px" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr8" align="right">
                    <td style="width: 100px;">
                        <asp:Label ID="Label5" runat="server" Text="رقم التليفون"></asp:Label>
                    </td>
                    <td style="width: 175px">
                        <asp:TextBox ID="txtTel" runat="server" MaxLength="50" Width="175px"></asp:TextBox>
                    </td>
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr10" align="right">
                    <td style="width: 100px;">
                        <asp:Label ID="Label6" runat="server" Text="رقم الموبيل"></asp:Label>
                    </td>
                    <td style="width: 175px">
                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="50" Width="175px"></asp:TextBox>
                    </td>
                    <td style="width: 100px;">
                    </td>
                   <td align="center" style="width: 150px;" >
                       <asp:FileUpload ID="FileUpload0" Width="100px" runat="server" />
                   </td>
                </tr>
                <tr ID="tr10" align="right">
                    <td style="width: 100px;" rowspan="3">
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" 
                                        CommandName="Edit" ValidationGroup="1"
                                        ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات أعدادات النظام"
                                        Width="64px" onclick="BtnEdit_Click"   />
                    </td>
                    <td style="width: 175px">
                        &nbsp;</td>
                    <td style="width: 100px;">
                        &nbsp;</td>
                   <td align="center" style="width: 150px;" >
                        <asp:Button ID="BtnLoad0" runat="server" Text="تحميل الصورة" OnClick="BtnLoad0_Click" />                        
                   </td>
                </tr>
                <tr ID="tr10" align="right">
                    <td style="width: 175px">
                        &nbsp;</td>
                    <td style="width: 100px;">
                        &nbsp;</td>
                </tr>
                <tr ID="tr10" align="right">
                    <td style="width: 175px">
                        &nbsp;</td>
                    <td style="width: 100px;">
                        &nbsp;</td>
                </tr>
            </table>
            <div>
                <asp:CheckBoxList ID="ChkPass" Width="60%" runat="server" Enabled="false" CssClass="chicklist MouseStop"
                    CellPadding="2" CellSpacing="2">
                </asp:CheckBoxList>
            </div>
            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
        </center>
    </asp:Panel>
</asp:Content>
