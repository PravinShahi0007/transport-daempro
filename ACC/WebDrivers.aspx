<%@ Page Title="بيانات السواقين" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebDrivers.aspx.cs" Inherits="ACC.WebDrivers" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ بيانات السائقين ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم السائق"></asp:Label>
                            </td>
                            <td style="width: 325px; margin-right: 40px;">
                                <asp:TextBox ID="txtCode" Width="100px" runat="server" MaxLength="5"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات سائق" OnClick="BtnSearch_Click" />
                                <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtCode"
                                    ErrorMessage="يجب إدخال رقم السائق" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:CheckBox ID="ChkStatus" Text="في الخدمة" runat="server" Checked="True" />
                            </td>
                            <td style="width: 275px;">
                                <asp:CheckBox ID="ChkAjir" Text="على نظام أجير" runat="server" Checked="false" 
                                    AutoPostBack="True" oncheckedchanged="ChkAjir_CheckedChanged" />
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label2" runat="server" Text="الاسم عربي"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtName1" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtName2" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label4" runat="server" Text="رقم الهوية"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtIqamaNo" Width="150px" runat="server" MaxLength="15"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label5" runat="server" Text="مصدرها"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtIqamaFrom" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label8" runat="server" Text="تاريخ الانتهاء"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtIqamaDate" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label11" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtMobileNo" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" Text="حساب السائق"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:DropDownList ID="ddlSponosor" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="lblCost" runat="server" Visible="false" Text="مصروف الطريق"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtCost" Width="150px" Visible="false" runat="server" MaxLength="20"></asp:TextBox>
                                 &nbsp;<asp:CompareValidator ID="ValFdacc" runat="server" ControlToValidate="txtCost"
                                    ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" Type="Currency" Operator="DataTypeCheck" ValidationGroup="1">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label6" runat="server" Text="حساب التطبيق"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:DropDownList ID="ddlShipDriver" Width="280px" runat="server">

                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                            </td>
                            <td style="width: 275px;">
                            </td>
                        </tr>

                        <tr align="center">
                            <td colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                    ValidationGroup="1" EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            </td>
                            <td colspan="2">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png"   ToolTip="أضافة سائق جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السائق؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات سائق"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات سائق" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات السائق؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png"   ToolTip="البحث عن بيانات سائق"
                                    OnClick="BtnSearch_Click" />
                                <asp:Button ID="Button1" runat="server" Visible="false" onclick="Button1_Click" ValidationGroup="1" 
                                    Text="أنشاء حساب للأجهزة الذكية" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="width: 100%; overflow:none; overflow-x:auto ; border: 1px solid #800000;">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="Code" AllowPaging="True"
                            PageSize="20" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات السائق"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم السائق" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم السائق" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="250px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الجوال" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </div>
                    <br />
                </center>
            </fieldset>
        </div>
        <br />
    </center>
</asp:Content>
