<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebOffers.aspx.cs" Inherits="ACC.WebOffers" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend id="leg1" runat="server" align="center" style="font-size: 18px; color: #800000;
                    text-align: center;"><b>
                        <asp:Literal ID="Literal2" Text="[العروض الخاصة و المواسم]" runat="server"></asp:Literal></b></legend>
                <br />
                <center>
                    <table width="100%" cellpadding="2px">
                        <tr>
                            <td align="right" style="width: 137px;">
                                <asp:Label ID="LblOfferNo" runat="server" Text="كود العرض*"></asp:Label>
                            </td>
                            <td align="right" style="width: 280px; margin-right: 40px;" colspan="3">
                                <asp:TextBox ID="txtPromoCode" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات عرض" OnClick="BtnSearch_Click" />
                                <asp:RequiredFieldValidator ID="ValOfferNo" runat="server" ControlToValidate="txtPromoCode"
                                    ErrorMessage="يجب إدخال كود العرض" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtOfferNo" Visible="false" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 120px;">
                                <asp:CheckBox ID="ChkOfferActive" Text="تفعيل العرض" runat="server" />
                            </td>
                            <td align="right" style="width: 120px;">
                                <asp:CheckBox ID="ChkFirstOrder" Text="لأول طلب" runat="server" 
                                    AutoPostBack="True" oncheckedchanged="ChkFirstOrder_CheckedChanged" />
                            </td>
                            <td align="right" style="width: 160px;" colspan="2">
                                <asp:CheckBox ID="ChkFromServices" Text="خصم من الخدمة" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 137px;">
                                <asp:Label ID="Label2" runat="server" Text="من تاريخ*"></asp:Label>
                            </td>
                            <td align="right" style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtFDate" MaxLength="10"  autocomplete="off" Width="100px"  
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    Display="Dynamic" ErrorMessage="يجب إدخال من تاريخ" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValFDate1" runat="server" ControlToValidate="txtFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="يجب أن يكون التاريخ أكبر من أو يساوي تاريخ اليوم"
                                 ControlToValidate="txtFDate" Display="Dynamic" ForeColor="Red" ValidationGroup="1" Type="Date">*</asp:RangeValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="txtFDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                <ajax:CalendarExtender ID="CalFDate" runat="server" CssClass="MyCalendar" TargetControlID="txtFDate"
                                    Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday" PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtFTime" Width="75px" MaxLength="10" runat="server"></asp:TextBox>                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4"  ForeColor="Red" ControlToValidate="txtFTime" ValidationGroup="1" ValidationExpression="^([0-1]\d|2[0-3]):([0-5]\d)(:([0-5]\d))?$" runat="server" ErrorMessage="يجب أن تكون القيمة وقت">*</asp:RegularExpressionValidator>
                            </td>
                            <td align="right" style="width: 120px;">
                                <asp:Label ID="Label3" runat="server" Text="إلى تاريخ"></asp:Label>
                            </td>
                            <td align="right" style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtEDate" MaxLength="10"  autocomplete="off" Width="100px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                    Display="Dynamic" ErrorMessage="يجب إدخال إلى تاريخ" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValEDate1" runat="server" ControlToValidate="txtEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  ControlToValidate="txtEDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="يجب أن يكون التاريخ أكبر من أو يساوي تاريخ اليوم"
                                 ControlToValidate="txtEDate" Display="Dynamic" ForeColor="Red" ValidationGroup="1" Type="Date">*</asp:RangeValidator>
                                <ajax:CalendarExtender ID="CalEDate" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtETime" Width="75px" MaxLength="10" runat="server" ></asp:TextBox>                                                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red"  ControlToValidate="txtETime" ValidationGroup="1" ValidationExpression="^([0-1]\d|2[0-3]):([0-5]\d)(:([0-5]\d))?$" runat="server" ErrorMessage="يجب أن تكون القيمة وقت">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>                        
                        <tr>
                            <td align="right" style="width: 137px;">
                                <asp:Label ID="Label26" runat="server" Text="الخصم"></asp:Label>
                            </td>
                            <td align="right" style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtDiscount" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValDiscount" runat="server" ControlToValidate="txtDiscount"
                                    Display="Dynamic" ErrorMessage="يجب إدخال الخصم" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValDiscount2" runat="server" ControlToValidate="txtDiscount"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red"
                                    Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:CheckBox ID="ChkAmount" Text="خصم بالنسبة" runat="server" />
                            </td>
                            <td style="width: 120px;">
                                 <asp:Label ID="Label1" runat="server" Text="رقم فاتوره"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 137px;" rowspan="6">
                                <asp:Label ID="Label4" runat="server" Text="الخدمات"></asp:Label>
                            </td>
                            <td align="right" style="width: 280px;" colspan="3" rowspan="6">
                                 <asp:CheckBoxList ID="ChkServices" Width="200px" runat="server" BorderStyle="Solid"
                                        BorderWidth="1" BorderColor="Maroon">
                                        <asp:ListItem Value="1">نقل سيارات</asp:ListItem>
                                        <asp:ListItem Value="2">شحن طرود</asp:ListItem>
                                        <asp:ListItem Value="3">خدمات الطريق</asp:ListItem>
                                        <asp:ListItem Value="4">الغاز</asp:ListItem>
                                        <asp:ListItem Value="5">المياة</asp:ListItem>
                                        <asp:ListItem Value="6">ليموزين</asp:ListItem>
                                        <asp:ListItem Value="7">مزودي الخدمة</asp:ListItem>                                        
                                 </asp:CheckBoxList>
                            </td>
                            <td align="right" style="width: 120px;">
                                <asp:CheckBox ID="ChkUseApp" Text="التطبيق" runat="server" />
                            </td>
                            <td align="right" style="width: 120px;" colspan="2">
                                <asp:CheckBox ID="ChkUseWebsite" Text="الموقع" runat="server" />
                            </td>
                            <td align="right" style="width: 160px;">
                                <asp:CheckBox ID="ChkUseSystem" Text="الفرع" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                 <asp:Label ID="Label5" runat="server" Text="جهة الشحن"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                    <asp:DropDownList ID="ddlFromLoc" Width="260" runat="server">
                                    </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                 <asp:Label ID="Label6" runat="server" Text="جهة الوصول"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                    <asp:DropDownList ID="ddlToLoc" Width="260" runat="server">
                                    </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                 <asp:Label ID="Label7" runat="server" Text="حساب العميل"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                    <asp:DropDownList ID="ddlCustomer" Width="260" runat="server">
                                    </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                 <asp:Label ID="Label8" runat="server" Text="عدد مرات الاستخدام للعميل"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtNoofUse" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNoofUse"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقم"
                                    ForeColor="Red" Type="Integer" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                 <asp:Label ID="Label9" runat="server" Text="عدد مستخدمين الخصم"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtTotalofUse" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtTotalofUse"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقم"
                                    ForeColor="Red" Type="Integer" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px;">
                                <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl="WebGetMap.aspx" runat="server">تحديد موقع الخصم</asp:HyperLink>
                            </td>
                            <td style="width: 280px;" colspan="3">                                
                                <asp:Button ID="btnFrom" runat="server" Text="حفظ الموقع" OnClick="btnFrom_Click" />                                
                                &nbsp;&nbsp;
                                <asp:HyperLink ID="lnkFrom" Target="_blank" Visible="false" runat="server">عرض الموقع</asp:HyperLink>        
                            </td>
                            <td style="width: 120px;">
                                <asp:Label ID="Label10" runat="server" Text="البعد عن الموقع"></asp:Label>
                            </td>
                            <td style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtLocKM" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtLocKM"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقم"
                                    ForeColor="Red" Type="Integer" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:Label ID="Label11" runat="server" Text="KM"></asp:Label>
                            </td>
                        </tr>                                               
                        <tr>
                            <td align="right" style="width: 137px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td align="right" style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtUserName" Width="300px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 120px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ" ></asp:Label>
                            </td>
                            <td align="right" style="width: 280px;" colspan="3">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية" ></asp:Label>
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
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png"   ToolTip="أضافة عرض جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات العرض؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات العرض"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات العرض" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات العرض؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png"   ToolTip="البحث عن بيانات العرض"
                                    OnClick="BtnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                     <br />
                    <div style="width: 100%; overflow:none; overflow-x:auto ; border: 1px solid #800000;">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="OfferNo" AllowPaging="True"
                            PageSize="20" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات العرض"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="كود العرض" SortExpression="PromoCode" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPromoCode" Text='<%# Bind("PromoCode") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من تاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى تاريخ" SortExpression="EDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEDate" Text='<%# Bind("EDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="النسبة" SortExpression="Discount" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscount" Text='<%# Eval("Discount","{0:N2}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الحالة" SortExpression="OfferActive" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkOfferActive" Enabled="false" Checked='<%# Bind("OfferActive") %>' runat="server" />
                                   </ItemTemplate>
                                    <ControlStyle Width="50px" />
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
    </center>
    <br />
</asp:Content>
