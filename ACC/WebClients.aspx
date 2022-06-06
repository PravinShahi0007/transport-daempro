<%@ Page Title="بيانات العملاء" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebClients.aspx.cs" Inherits="ACC.WebClients" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ بيانات العملاء ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم العميل"></asp:Label>
                            </td>
                            <td style="width: 325px; margin-right: 40px;">
                                <asp:TextBox ID="txtCode" Width="100px" runat="server" MaxLength="5"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات عميل" OnClick="BtnSearch_Click" />
                                <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtCode"
                                    ErrorMessage="يجب إدخال رقم العميل" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                            </td>
                            <td style="width: 275px;">
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
                                <asp:Label ID="Label4" runat="server" Text="الرقم الضريبي"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtIqamaNo" Width="150px" runat="server" MaxLength="15"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" Visible="false" Text="نوعها"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:RadioButtonList ID="rdoIDType" Width="200px" runat="server" Visible="false" RepeatColumns="2">
                                    <asp:ListItem Selected="True" Value="0">الهوية</asp:ListItem>
                                    <asp:ListItem Value="1">بطاقة</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label5" runat="server" Visible="false" Text="مصدرها"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtIqamaFrom" Width="150px" runat="server" Visible="false" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label8" runat="server" Visible="false" Text="تاريخ الانتهاء"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtIqamaDate" Width="150px" runat="server" Visible="false" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label6" runat="server" Text="العنوان"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtAddress" Width="300px" runat="server" MaxLength="200"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label11" runat="server" Text="رقم الاتصال"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtMobileNo" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label7" runat="server" Text="بريد واصل"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtPostal" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label9" runat="server" Text="البريد الالكتروني"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtEmail" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label13" runat="server" Text="رقم المكتب"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtOfficeNo" Width="300px" runat="server" MaxLength="15"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label16" runat="server" Text="نوع الدفع"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:RadioButtonList ID="rdoPayment" Width="250px" runat="server" 
                                    RepeatColumns="2" AutoPostBack="True" 
                                    onselectedindexchanged="rdoPayment_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">أجل فرع</asp:ListItem>
                                    <asp:ListItem Value="1">Credit</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label17" runat="server" Text="العنوان الوطني"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                &nbsp;</td>
                            <td style="width: 100px;">
                                <asp:Label ID="lblCust" runat="server" Visible="false" Text="حساب العميل"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:DropDownList ID="ddlAccount" Width="280px" Visible="false" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label18" runat="server" Text="رقم المبنى"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtAddr1" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label19" runat="server" Text="اسم الشارع"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtAddr2" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label20" runat="server" Text="الحي"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtAddr3" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label21" runat="server" Text="المدينة"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtAddr4" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label22" runat="server" Text="البلد"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtAddr5" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label23" runat="server" Text="الرمز البريدي"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtAddr6" Width="200px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label24" runat="server" Text="الرقم الإضافي"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtAddr7" Width="200px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label25" runat="server" Text="رقم الوحدة"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtAddr8" Width="200px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 350px;">
                                <asp:Label ID="Label10" runat="server" Text="اسم المسئول"></asp:Label>
                            </td>
                            <td style="width: 150px;">
                                <asp:Label ID="Label12" runat="server" Text="الوظيفة"></asp:Label>
                            </td>
                            <td style="width: 150px;">
                                <asp:Label ID="Label14" runat="server" Text="رقم الاتصال"></asp:Label>
                            </td>
                            <td style="width: 150px;">
                                <asp:Label ID="Label15" runat="server" Text="الايميل"></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 350px;">
                                <asp:TextBox ID="txtManage1" Width="350px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtJob1" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtMobileNo1" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtEmail1" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 350px;">
                                <asp:TextBox ID="txtManage2" Width="350px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtJob2" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtMobileNo2" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtEmail2" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 350px;">
                                <asp:TextBox ID="txtManage3" Width="350px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtJob3" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtMobileNo3" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 150px;">
                                <asp:TextBox ID="txtEmail3" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4">
                                <asp:GridView ID="grdDetails" runat="server" CellPadding="3" Width="99.95%" 
                                    ViewStateMode="Enabled" GridLines="Horizontal" AutoGenerateColumns="False" 
                                    ShowFooter="true" AllowPaging="false"
                                    DataKeyNames="FNo" PageSize="250" OnRowCommand="grdDetails_RowCommand" 
                                    OnRowDeleting="grdDetails_RowDeleting" BackColor="White" BorderColor="#E7E7FF" 
                                    BorderStyle="None" BorderWidth="1px" 
                                    onrowcancelingedit="grdDetails_RowCancelingEdit">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="المدينة" SortExpression="City2" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCity2" Text='<%# Eval("City2") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlCity" runat="server" Width="150px"></asp:DropDownList>
                                            </FooterTemplate>
                                            <ControlStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="المندوب المرسل" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                               <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="200px"/>
                                            </FooterTemplate>
                                            <ControlStyle Width="200px" />
                                            <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="رقم الاتصال" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                               <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="20" Width="100px"/>
                                            </FooterTemplate>
                                            <ControlStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="المندوب المستلم" SortExpression="RecName" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecName" Text='<%# Eval("RecName") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                               <asp:TextBox ID="txtRecName" runat="server" MaxLength="50" Width="200px"/>
                                            </FooterTemplate>
                                            <ControlStyle Width="200px" />
                                            <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="رقم الاتصال" SortExpression="RecMobileNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecMobileNo" Text='<%# Bind("RecMobileNo") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                               <asp:TextBox ID="txtRecMobileNo" runat="server" MaxLength="20" Width="100px"/>
                                            </FooterTemplate>
                                            <ControlStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                                    ValidationGroup="1" ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="أضافة بند جديد"
                                                    ImageUrl="~/images/add.png" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" VerticalAlign="Middle"
                                        HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="center">
                            <td colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            </td>
                            <td colspan="2">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة عميل جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات العميل؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات عميل" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات عميل" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات العميل؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png" ToolTip="البحث عن بيانات عميل" OnClick="BtnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="Code" AllowPaging="True"
                            PageSize="20" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات العميل"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم العميل" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
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
