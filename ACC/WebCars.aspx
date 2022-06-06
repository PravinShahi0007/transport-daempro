<%@ Page Title="بيانات الشاحنات" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebCars.aspx.cs" Inherits="ACC.WebCars" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">

        function Plate_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCode');
            var ace2Value = $get('ContentPlaceHolder1_txtPlateNo');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ بيانات الشاحنات ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label10" runat="server" Text="نوع المركبه"></asp:Label>
                            </td>
                            <td style="width: 300px; margin-right: 40px;">
                                <asp:DropDownList ID="ddlCarsType" Width="280px" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCarsType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                            </td>
                            <td style="width: 135px;">
                                <asp:CheckBox ID="ChkStatus" runat="server" Text="في الخدمة" />
                            </td>
                            <td style="width: 140px;">
                                <asp:TextBox ID="txtPLoc" Placeholder="موقع الشاحنة/السيارة" Width="155px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم الشاحنة"></asp:Label>
                            </td>
                            <td style="width: 300px; margin-right: 40px;">
                                <asp:TextBox ID="txtCode" Width="100px" runat="server" MaxLength="5"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات شاحنة" OnClick="BtnSearch_Click" />
                                <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtCode"
                                    ErrorMessage="يجب إدخال رقم الشاحنة" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label13" runat="server" Text="النوع عربي"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtWorkShopCode" Width="150px" Visible="false" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtCarType" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label2" runat="server" Text="رقم اللوحه"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtPlateNo" Width="150px" runat="server" MaxLength="15" autocomplete="off"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender03" runat="server" TargetControlID="txtPlateNo"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars20" OnClientItemSelected="Plate_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label3" runat="server" Text="النوع أنجليزي"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtCarType2" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label7" runat="server" Text="الطراز"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtTaraz" Width="150px" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label9" runat="server" Text="الموديل"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtModel" Width="150px" runat="server" MaxLength="30"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label4" runat="server" Text="عداد الكيلومتر"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtKMeter" Width="150px" runat="server" MaxLength="15"></asp:TextBox>
                                <asp:CompareValidator ID="ValKMeter" runat="server" ControlToValidate="txtKMeter"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" Text="الموظف/السائق"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:DropDownList ID="ddlDrivers" Width="300px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label16" runat="server" Text="نوع الملحق"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlFollowType" Width="280px" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlFollowType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label14" runat="server" Text="الملحق"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:DropDownList ID="ddlFollow2" Width="300px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label15" runat="server" Text="حساب الاصل"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlFixAssetCode" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label12" runat="server" Text="الملحقات"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:DropDownList ID="ddlFType2" Width="300px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label5" runat="server" Text="قراءة تغيير الزيت"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtChOilKMeter" Width="150px" runat="server" MaxLength="15"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtChOilKMeter"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label8" runat="server" Text="تاريخ التغيير"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtChOilDate" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label6" runat="server" Text="قراءة تعبئة الوقود"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtChDezelKMeter" Width="150px" runat="server" MaxLength="15"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtChDezelKMeter"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label11" runat="server" Text="تاريخ التعبئة"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtChDezelDate" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>

                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label17" runat="server" Text="أنتهاء الاستمارة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtPHDate1" Width="135px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc1" Placeholder="موقع الاصل" Width="135px" runat="server" MaxLength="50"></asp:TextBox>

                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label18" runat="server" Text="أنتهاء التامين"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtPHDate2" Width="125px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc2" Placeholder="موقع الاصل" Width="125px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label19" runat="server" Text="أنتهاء بطاقة التشغيل"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtPHDate3" Width="135px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc3" Placeholder="موقع الاصل" Width="135px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label20" runat="server" Text="تاريخ الفحص"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtPHDate4" Width="125px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc4" Placeholder="موقع الاصل" Width="125px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label21" runat="server" Text="أنتهاء تامين حمولة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtPHDate5" Width="135px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc5" Placeholder="موقع الاصل" Width="135px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label35" runat="server" Text="القطاع"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label22" runat="server" Text="النوع"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtBrand" Width="135px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label23" runat="server" Text="رقم الهيكل"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtCarStruct" Width="135px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label24" runat="server" Text="رقم التسلسلي"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtCarSerial" Width="135px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                            </td>
                            <td style="width: 275px;" colspan="2">
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label25" runat="server" Text="قيمة ومدة الأستمارة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtamP1" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP1" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP1LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP1LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label28" runat="server" Text="قيمة ومدة تأمين الغير"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtamP2" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP2" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP2LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP2LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label26" runat="server" Text="قيمة ومدة بطاقة التشغيل"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtamP3" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP3" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP3LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP3LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label29" runat="server" Text="قيمة ومدة الفحص"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtamP4" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP4" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP4LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP4LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label27" runat="server" Text="قيمة ومدة تامين حموله"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtamP5" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP5" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP5LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP5LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label30" runat="server" Text="قيمة ومدة تامين شامل"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtamP6" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP6" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP6LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP6LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            </td>
                            <td colspan="3">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                        <asp:GridView ID="grdMan" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="CarNo" AllowPaging="false"
                            PageSize="1000" Width="99.9%" EmptyDataText="لا توجد بيانات">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="نوع المستند" SortExpression="VouType2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVouType2" Text='<%# Bind("VouType2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الرقم" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVouNo" Text='<%# Bind("VouNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التاريخ" SortExpression="VouDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVouDate" Text='<%# Bind("VouDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="البيان" SortExpression="Ref" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRef" Text='<%# Bind("Ref") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="القيمة" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تاريخ أخر تنفيذ" SortExpression="LDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLDate" Text='<%# Bind("LDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
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
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="center">
                            <td colspan="5">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة شاحنة جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الشاحنة؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات شاحنة" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات شاحنة" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات العميل؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png" ToolTip="البحث عن بيانات شاحنة" OnClick="BtnSearch_Click" />
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="5">
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                                        BorderColor="Maroon">
                                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                                            ShowHeader="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء الملف"
                                                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء الملف؟")' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="الملف" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="lblFileName" Text='<%# Bind("FileName") %>' NavigateUrl='<%# Bind("FileName2") %>'
                                                            Target="_blank" runat="server"></asp:HyperLink>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="300px" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        </asp:GridView>
                                        <table width="100%">
                                            <tr>
                                                <td align="right">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
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
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات الشاحنة"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم الشاحنة" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName1" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="نوع الشاحنة" SortExpression="CarType" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobileNo" Text='<%# Bind("CarType") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="250px" />
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
