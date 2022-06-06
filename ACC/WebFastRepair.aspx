<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebFastRepair.aspx.cs" Inherits="ACC.WebFastRepair" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function Plate_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCarNo');
            //var ace2Value = $get('ContentPlaceHolder1_txtPlateNo');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            //ace2Value.value = x[1];
            return false;
        }


        function CheckItem(sender, args) {
            var Am1 = document.getElementById('<%=txtAm1.ClientID %>');
            var Am2 = document.getElementById('<%=txtAm2.ClientID %>');
            var Am3 = document.getElementById('<%=txtAm3.ClientID %>');
            var Am4 = document.getElementById('<%=txtAm4.ClientID %>');
            var Am5 = document.getElementById('<%=txtAm5.ClientID %>');
            var Am6 = document.getElementById('<%=txtAm6.ClientID %>');
            var Am7 = document.getElementById('<%=txtAm7.ClientID %>');
            var Am8 = document.getElementById('<%=txtAm8.ClientID %>');
            var Am9 = document.getElementById('<%=txtAm9.ClientID %>');
            var Am10 = document.getElementById('<%=txtAm10.ClientID %>');
            var Am11 = document.getElementById('<%=txtAm11.ClientID %>');
            var Am12 = document.getElementById('<%=txtAm12.ClientID %>');
            var Am13 = document.getElementById('<%=txtAm13.ClientID %>');
            var Am14 = document.getElementById('<%=txtAm14.ClientID %>');
            var Am15 = document.getElementById('<%=txtAm15.ClientID %>');
            var Am16 = document.getElementById('<%=txtAm16.ClientID %>');
            var Am17 = document.getElementById('<%=txtAm17.ClientID %>');
            var Am18 = document.getElementById('<%=txtAm18.ClientID %>');
            var Am19 = document.getElementById('<%=txtAm19.ClientID %>');
            var Am20 = document.getElementById('<%=txtAm20.ClientID %>');
            var Am21 = document.getElementById('<%=txtAm21.ClientID %>');
            var Am22 = document.getElementById('<%=txtAm22.ClientID %>');
            var Am23 = document.getElementById('<%=txtAm23.ClientID %>');
            var Am24 = document.getElementById('<%=txtAm24.ClientID %>');
            var Am25 = document.getElementById('<%=txtAm25.ClientID %>');
            var Am26 = document.getElementById('<%=txtAm26.ClientID %>');
            var Am27 = document.getElementById('<%=txtAm27.ClientID %>');
            var Am28 = document.getElementById('<%=txtAm28.ClientID %>');
            var Am29 = document.getElementById('<%=txtAm29.ClientID %>');
            var Am30 = document.getElementById('<%=txtAm30.ClientID %>');
            var Am31 = document.getElementById('<%=txtAm31.ClientID %>');
            var Am32 = document.getElementById('<%=txtAm32.ClientID %>');
            var Am33 = document.getElementById('<%=txtAm33.ClientID %>');
            var Am34 = document.getElementById('<%=txtAm34.ClientID %>');
            var total = document.getElementById('<%=txtTotal.ClientID %>');

            if (!Am1.value) Am1.value = '0';
            if (!Am2.value) Am2.value = '0';
            if (!Am3.value) Am3.value = '0';
            if (!Am4.value) Am4.value = '0';
            if (!Am5.value) Am5.value = '0';
            if (!Am6.value) Am6.value = '0';
            if (!Am7.value) Am7.value = '0';
            if (!Am8.value) Am8.value = '0';
            if (!Am9.value) Am9.value = '0';
            if (!Am10.value) Am10.value = '0';
            if (!Am11.value) Am11.value = '0';
            if (!Am12.value) Am12.value = '0';
            if (!Am13.value) Am13.value = '0';
            if (!Am14.value) Am14.value = '0';
            if (!Am15.value) Am15.value = '0';
            if (!Am16.value) Am16.value = '0';
            if (!Am17.value) Am17.value = '0';
            if (!Am18.value) Am18.value = '0';
            if (!Am19.value) Am19.value = '0';
            if (!Am20.value) Am20.value = '0';
            if (!Am21.value) Am21.value = '0';
            if (!Am22.value) Am22.value = '0';
            if (!Am23.value) Am23.value = '0';
            if (!Am24.value) Am24.value = '0';
            if (!Am25.value) Am25.value = '0';
            if (!Am26.value) Am26.value = '0';
            if (!Am27.value) Am27.value = '0';
            if (!Am28.value) Am28.value = '0';
            if (!Am29.value) Am29.value = '0';
            if (!Am30.value) Am30.value = '0';
            if (!Am31.value) Am31.value = '0';
            if (!Am32.value) Am32.value = '0';
            if (!Am33.value) Am33.value = '0';
            if (!Am34.value) Am34.value = '0';

            total.value = Am1.value + Am2.value + Am3.value + Am4.value + Am5.value + Am6.value + Am7.value + Am8.value + Am9.value + Am10.value + Am11.value + Am12.value + Am13.value + Am14.value + Am15.value + Am16.value + Am17.value + Am18.value + Am19.value + Am20.value + Am21.value + Am22.value + Am23.value + Am24.value + Am25.value + Am26.value + Am27.value + Am28.value + Am29.value + Am30.value + Am31.value + Am32.value + Am33.value + Am34.value;

            return
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center>
        <div class="ColorRounded4Corners" style="width: 100%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 100%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[بيان أصلاح خارجي سريع]" meta:resourcekey="lblHead"></asp:Label>
                </b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label1" runat="server" Text="رقم البيان" meta:resourcekey="Label1"></asp:Label>
                                *
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop" ></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width:5px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ" meta:resourcekey="Label2"></asp:Label>
                                *
                            </td>
                            <td style="width:175px;">
                                <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td style="width:125px;">
                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="70px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات البيان" OnClick="BtnFind_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label4" runat="server" Text="الوحدة" meta:resourcekey="Label4"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:DropDownList ID="ddlVehicle" Width="200" runat="server" AutoPostBack="True" Enabled="false"
                                    OnSelectedIndexChanged="ddlVehicle_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtCarNo" MaxLength="15" Width="80px" autocomplete="off" runat="server" ReadOnly="true"
                                    AutoPostBack="True" OnTextChanged="txtCarNo_TextChanged"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender03" runat="server" TargetControlID="txtCarNo"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars21" OnClientItemSelected="Plate_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                            </td>
                            <td style="width:5px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label11" runat="server" Text="السائق" meta:resourcekey="Label11"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:DropDownList ID="ddlDriver" Width="200" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="lblJobOrder" runat="server" Text="Job Work" meta:resourcekey="lblJobOrder"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtJobOrder" MaxLength="15" runat="server" AutoPostBack="True" 
                                    ontextchanged="txtJobOrder_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValJobOrder" runat="server" ControlToValidate="txtJobOrder"
                                    Display="Dynamic" ErrorMessage="يجب إدخال رقم أمر العمل" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValJobOrder2" runat="server" ControlToValidate="txtJobOrder"
                                    ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" Type="Integer" ValidationGroup="1" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td style="width:5px;">
                            </td>
                            <td colspan="3" style="width:450px;">
                                 <asp:Label ID="lblStatus" runat="server"  CssClass="blink" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label23" runat="server" Text="البند" meta:resourcekey="Label23"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:Label ID="Label25" Width="60px"  CssClass="alignCenter"  runat="server" Text="المبلغ" meta:resourcekey="Label25"></asp:Label>
                                <asp:Label ID="Label26" Width="75px" CssClass="alignCenter" runat="server" Text="أرقام الفواتير" meta:resourcekey="Label26"></asp:Label>
                                <asp:Label ID="Label28" Width="65px" CssClass="alignCenter" runat="server" Text="التاريخ" meta:resourcekey="Label28"></asp:Label>
                                <asp:Label ID="Label49" Width="40px" CssClass="alignCenter" runat="server" Text="العدد" meta:resourcekey="Label49"></asp:Label>
                            </td>
                            <td style="width:5px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label24" runat="server" Text="البند" meta:resourcekey="Label23"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:Label ID="Label29" Width="60px" CssClass="alignCenter"  runat="server" Text="المبلغ" meta:resourcekey="Label25"></asp:Label>
                                <asp:Label ID="Label30" Width="75px" CssClass="alignCenter" runat="server" Text="أرقام الفواتير" meta:resourcekey="Label26"></asp:Label>
                                <asp:Label ID="Label31" Width="65px" CssClass="alignCenter" runat="server" Text="التاريخ" meta:resourcekey="Label28"></asp:Label>
                                <asp:Label ID="Label50" Width="40px" CssClass="alignCenter" runat="server" Text="العدد" meta:resourcekey="Label49"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label3" runat="server" Text="غسيل" meta:resourcekey="Label3"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm1" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtAm1"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo1" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate1" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtInvDate1"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate1" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty1" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:5px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label5" runat="server" Text="زيوت وشحومات" meta:resourcekey="Label5"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm2" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtAm2"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo2" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate2" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtInvDate2"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate2" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty2" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label6" runat="server" Text="بنشر" meta:resourcekey="Label6"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm3" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtAm3"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo3" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate3" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator17" runat="server" ControlToValidate="txtInvDate3"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate3" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty3" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label8" runat="server" Text="أجره أصلاح ميكانيكي" meta:resourcekey="Label8"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm4" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtAm4"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo4" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate4" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToValidate="txtInvDate4"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate4" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty4" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label9" runat="server" Text="أطارات جديدة" meta:resourcekey="Label9"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm5" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="txtAm5"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo5" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate5" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator19" runat="server" ControlToValidate="txtInvDate5"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate5" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty5" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label10" runat="server" Text="أطارات مستعملة" meta:resourcekey="Label10"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm6" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtAm6"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo6" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate6" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator20" runat="server" ControlToValidate="txtInvDate6"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate6" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty6" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label13" runat="server" Text="فحص كمبيوتر" meta:resourcekey="Label13"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm7" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtAm7"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo7" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate7" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="txtInvDate7"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender8" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate7" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty7" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label16" runat="server" Text="أجره أصلاح كهربائي" meta:resourcekey="Label16"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm8" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="txtAm8"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo8" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate8" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="txtInvDate8"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender9" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate8" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty8" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label17" runat="server" Text=" بطارية" meta:resourcekey="Label17"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm9" MaxLength="10" Width="55px" runat="server" AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="txtAm9"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo9" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate9" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator23" runat="server" ControlToValidate="txtInvDate9"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender10" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate9" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty9" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label18" runat="server" Text="أجره خراطه" meta:resourcekey="Label18"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm10" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="txtAm10"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo10" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate10" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator24" runat="server" ControlToValidate="txtInvDate10"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender11" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate10" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty10" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label19" runat="server" Text="تغيير ماء مقطر" meta:resourcekey="Label19"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm11" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="txtAm11"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo11" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate11" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator25" runat="server" ControlToValidate="txtInvDate11"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender12" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate11" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty11" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label20" runat="server" Text="أجره لحام" meta:resourcekey="Label20"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm12" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="txtAm12"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo12" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate12" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator26" runat="server" ControlToValidate="txtInvDate12"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender13" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate12" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty12" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label21" runat="server" Text="قطع غيار" meta:resourcekey="Label21"></asp:Label><br />
                                <asp:CheckBox ID="ChkFix" ToolTip="أضافة الى الاصل" runat="server" Visible="false"
                                    AutoPostBack="True" oncheckedchanged="ChkFix_CheckedChanged" />
                                <asp:CheckBox ID="ChkRep" ToolTip="أطفاءات"  runat="server" AutoPostBack="True"  Visible="false"
                                    oncheckedchanged="ChkRep_CheckedChanged" />
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm13" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="txtAm13"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo13" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate13" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="txtInvDate13"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender14" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate13" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty13" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label22" runat="server" Text="أجره حداده" meta:resourcekey="Label22"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm14" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToValidate="txtAm14"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo14" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate14" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator28" runat="server" ControlToValidate="txtInvDate14"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender15" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate14" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty14" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label32" runat="server" Text="أجره أصلاح بخاخات" meta:resourcekey="Label32"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm15" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator29" runat="server" ControlToValidate="txtAm15"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo15" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate15" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator30" runat="server" ControlToValidate="txtInvDate15"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender16" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate15" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty15" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label33" runat="server" Text="أصلاح بساتم هيدرلوريك" meta:resourcekey="Label33"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm16" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator31" runat="server" ControlToValidate="txtAm16"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo16" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate16" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator32" runat="server" ControlToValidate="txtInvDate16"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender17" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate16" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty16" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label35" runat="server" Text="تركيب قماشات فرامل" meta:resourcekey="Label35"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm17" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator33" runat="server" ControlToValidate="txtAm17"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo17" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate17" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator34" runat="server" ControlToValidate="txtInvDate17"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender18" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate17" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty17" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label36" runat="server" Text="سمكره و دهان" meta:resourcekey="Label36"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm18" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator35" runat="server" ControlToValidate="txtAm18"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo18" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate18" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator36" runat="server" ControlToValidate="txtInvDate18"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender19" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate18" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty18" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label37" runat="server" Text="أصلاح ستارتر ودينمو" meta:resourcekey="Label37"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm19" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator37" runat="server" ControlToValidate="txtAm19"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo19" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate19" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator38" runat="server" ControlToValidate="txtInvDate19"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender20" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate19" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty19" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label38" runat="server" Text="كبس ليات هيدرلوريك" meta:resourcekey="Label38"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm20" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator39" runat="server" ControlToValidate="txtAm20"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo20" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate20" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator40" runat="server" ControlToValidate="txtInvDate20"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender21" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate20" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty20" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label39" runat="server" Text="أصلاح تكييف" meta:resourcekey="Label39"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm21" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator41" runat="server" ControlToValidate="txtAm21"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo21" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate21" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator42" runat="server" ControlToValidate="txtInvDate21"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender22" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate21" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty21" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label40" runat="server" Text="اصلاح رديتر" meta:resourcekey="Label40"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm22" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator43" runat="server" ControlToValidate="txtAm22"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo22" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate22" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator44" runat="server" ControlToValidate="txtInvDate22"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender23" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate22" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty22" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label41" runat="server" Text="لحام تانك الديزل" meta:resourcekey="Label41"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm23" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator45" runat="server" ControlToValidate="txtAm23"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo23" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate23" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator46" runat="server" ControlToValidate="txtInvDate23"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender24" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate23" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty23" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label42" runat="server" Text="ميزان و ترصيص" meta:resourcekey="Label42"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm24" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator47" runat="server" ControlToValidate="txtAm24"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo24" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate24" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator48" runat="server" ControlToValidate="txtInvDate24"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender25" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate24" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty24" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label43" runat="server" Text="اصلاح راحه" meta:resourcekey="Label43"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm25" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator49" runat="server" ControlToValidate="txtAm25"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo25" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate25" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator50" runat="server" ControlToValidate="txtInvDate25"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender26" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate25" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty25" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label44" runat="server" Text="تركيب زجاج" meta:resourcekey="Label44"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm26" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator51" runat="server" ControlToValidate="txtAm26"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo26" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate26" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator52" runat="server" ControlToValidate="txtInvDate26"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender27" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate26" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty26" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label45" runat="server" Text="الفحص الدوري" meta:resourcekey="Label45"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm27" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator53" runat="server" ControlToValidate="txtAm27"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo27" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate27" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator54" runat="server" ControlToValidate="txtInvDate27"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender28" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate27" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty27" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label54" runat="server" Text="أصلاح بلوف هواء" meta:resourcekey="Label54"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm29" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator61" runat="server" ControlToValidate="txtAm29"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo29" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate29" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator62" runat="server" ControlToValidate="txtInvDate29"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender32" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate29" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty29" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label47" runat="server" Text="تقديرات حوادث" meta:resourcekey="Label47"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm30" MaxLength="10"  runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator57" runat="server" ControlToValidate="txtAm30" 
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo30"  MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate30"  MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator58"  runat="server" ControlToValidate="txtInvDate30"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender30" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate30" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty30" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label48" runat="server" Text="مواد مستهلكه للصيانة" meta:resourcekey="Label48"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm31" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator59" runat="server" ControlToValidate="txtAm31" 
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo31" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate31" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator60" runat="server" ControlToValidate="txtInvDate31" 
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender31" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate31" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty31" MaxLength="10" Width="40px"  runat="server"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td style="width:175px;">                                
                                <asp:Label ID="Label55" runat="server" Text="فرشه و تنجيد" meta:resourcekey="Label55"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm32" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator63" runat="server" ControlToValidate="txtAm32" 
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo32" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate32" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator64" runat="server" ControlToValidate="txtInvDate32" 
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender33" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate32" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty32" MaxLength="10" Width="40px"  runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label58" runat="server" Text="أصلاح طريق" meta:resourcekey="Label58"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtAm34" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator68" runat="server" ControlToValidate="txtAm34" 
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo34" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate34" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator69" runat="server" ControlToValidate="txtInvDate34" 
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender35" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate34" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty34" MaxLength="10" Width="40px"  runat="server"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td style="width:175px;">                                
                                <asp:Label ID="Label57" runat="server" Text="ديزل" meta:resourcekey="Label57"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtAm33" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator66" runat="server" ControlToValidate="txtAm33" 
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo33" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate33" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator67" runat="server" ControlToValidate="txtInvDate33" 
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender34" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate33" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty33" MaxLength="10" Width="40px"  runat="server"></asp:TextBox>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label46" runat="server" Text="أخرى" meta:resourcekey="Label46"></asp:Label>
                            </td>
                            <td style="width:300px;" colspan="2">
                                                            <asp:TextBox ID="txtAm28" MaxLength="10" runat="server" Width="55px"  AutoPostBack="True" ontextchanged="txtAm1_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator55" runat="server" ControlToValidate="txtAm28"
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                                <asp:TextBox ID="txtInvNo28" MaxLength="50" Width="55px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtInvDate28" MaxLength="10" Width="65px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator56" runat="server" ControlToValidate="txtInvDate28"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender29" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtInvDate28" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtInvQty28" MaxLength="10" Width="40px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label7" runat="server" Text="ملاحظات" meta:resourcekey="Label7"></asp:Label>
                            </td>
                            <td colspan="5" style="width:775px;">
                                <asp:TextBox ID="txtRemark" MaxLength="800" TextMode="MultiLine" Width="99%" Height="100px" runat="server"></asp:TextBox>
                            </td>
                        </tr>              
                        <tr>
                            <td style="width:175px;">
                                <asp:Label ID="Label56" runat="server" Text="الضريبة" meta:resourcekey="Label56"></asp:Label>
                            </td>
                            <td style="width:300px;">
                                <asp:TextBox ID="txtTax" MaxLength="20" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator65" runat="server" ControlToValidate="txtTax" 
                                  Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                            </td>
                            <td style="width:10px;">
                            </td>
                            <td style="width:175px;">
                                <asp:Label ID="Label12" runat="server" Text="الاجمالي" meta:resourcekey="Label12"></asp:Label>                                
                            </td>
                            <td style="width:300px;" colspan="2">
                                <asp:TextBox ID="txtTotal" ReadOnly="true" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>              
                    </table>
                    <br />
                    <table id="Table2" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 130px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم" meta:resourcekey="Label14"></asp:Label>
                            </td>
                            <td style="width: 280px;">
                                <asp:TextBox ID="txtUserName" Width="270px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 120px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ" meta:resourcekey="Label15"></asp:Label>
                            </td>
                            <td style="width: 250px;">
                                <asp:TextBox ID="txtUserDate" Width="100px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية" meta:resourcekey="Label27"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء" meta:resourcekey="lblReason"></asp:Label>
                            </td>
                            <td style="width: 280px;">
                                <asp:TextBox ID="txtReason" Width="270px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="10">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 120px;">
                            </td>
                            <td style="width: 250px;">
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png"   ToolTip="أضافة سند جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات البيان؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات البيان" OnClientClick="return Validate()"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete" ValidationGroup="1"
                                    ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات البيان" OnClientClick="return Validate2()"
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png"   ToolTip="البحث عن بيانات البيان"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1"   ToolTip="طباعة البيان"
                                    OnClick="BtnPrint_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
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
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                            Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
            </fieldset>
        </div>          

            <br />
             <div class="ColorRounded4Corners" style="width: 99.8%">                                
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
              <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                    <b>[  أعتماد مدير الصيانة ]</b></legend>
                <center>
                       <table width="99.5%" dir="rtl" >
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark9" runat="server" Text="ملاحظات" meta:resourcekey="Label7"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark1" MaxLength="100" TextMode="MultiLine" Width="99%" Height="100px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                           <asp:CheckBox ID="chkAgree1" runat="server" Text="تم الأعتماد" meta:resourcekey="chkAgree2"
                                            oncheckedchanged="chkAgree1_CheckedChanged" AutoPostBack="True" />
                                    </td>
                                    <td align="left" style="width: 300px;" rowspan="3" >
                                        <asp:ImageButton ID="BtnAgree1" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1" CssClass="ops"
                                            OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")' />
                                        <asp:ImageButton ID="BtnDisagree1" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1" 
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUser" runat="server" Text="المستخدم" meta:resourcekey="Label14"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser1" Width="250px" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate" runat="server" Text="تاريخ التعميد" meta:resourcekey="lblAgreeUserDate"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate1" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                </center>
            </fieldset>
            </div>
            <br />
             <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
              <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                    <b>[  أعتماد الحسابات ]</b></legend>
                <center>
                        <table width="99.5%" dir="rtl" >
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label51" runat="server" Text="ملاحظات" meta:resourcekey="Label7"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark2" MaxLength="100" TextMode="MultiLine" Width="99%" Height="100px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:CheckBox ID="chkAgree2" runat="server" Text="تم الأعتماد" meta:resourcekey="chkAgree2"
                                            oncheckedchanged="chkAgree2_CheckedChanged" AutoPostBack="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label52" runat="server" Text="المستخدم" meta:resourcekey="Label14"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser2" Width="250px"  runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label53" runat="server" Text="تاريخ التعميد" meta:resourcekey="lblAgreeUserDate"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate2" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                </center>
            </fieldset>            
        </div>         

  <br />
             <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
              <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                    <b>[  أعتماد الإدارة المالية ]</b></legend>
                <center>
                        <table width="99.5%" dir="rtl" >
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label59" runat="server" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark3" MaxLength="100" TextMode="MultiLine" Width="99%" Height="100px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:CheckBox ID="chkAgree3" runat="server" Text="تم الأعتماد" 
                                            oncheckedchanged="chkAgree3_CheckedChanged" AutoPostBack="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label60" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser3" Width="250px"  runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label61" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate3" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                </center>
            </fieldset>            
        </div>         

    </center>
</asp:Content>
