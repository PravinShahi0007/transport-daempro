<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebPayReq.aspx.cs" Inherits="ACC.WebPayReq" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ace1_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCode');
            var ace2Value = $get('ContentPlaceHolder1_txtName');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ طلب دفع]"></asp:Label>
                </b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width:150px;">
                                <asp:Label ID="Label1" runat="server" Text="رقم الطلب"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width:300px;">
                                <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width:50px;">
                            </td>
                            <td align="center" style="width:150px;">
                            </td>
                            <td align="right" style="width:150px;">
                            </td>
                            <td align="center" style="width:150px;">
                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="70px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات الطلب" OnClick="BtnFind_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" >
                                <asp:Label ID="Label3" runat="server" Text="التاريخ"></asp:Label>
                                *
                            </td>
                            <td align="right" >
                                <asp:TextBox ID="txtHDate" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                            </td>
                            <td align="right" >
                            </td>
                            <td align="center">
                                <asp:Label ID="Label6" runat="server" Text="الموافق"></asp:Label>
                                *
                            </td>
                            <td align="right" >
                                <asp:TextBox ID="txtGDate" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtGDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtGDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td align="left" rowspan="5" >
                                <asp:RadioButtonList ID="RdoChq" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="RdoChq_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">نقدي</asp:ListItem>
                                    <asp:ListItem Value="1">شيك عادي</asp:ListItem>
                                    <asp:ListItem Value="2">شيك مصدق</asp:ListItem>
                                    <asp:ListItem Value="3">تحويل بنكي</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" >
                                <asp:Label ID="Label4" runat="server" Text="لأمر"></asp:Label>
                            </td>
                            <td align="right" >
                                <asp:TextBox ID="txtPerson" MaxLength="50" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" >
                            </td>
                            <td align="center">
                                <asp:Label ID="Label11" runat="server" Text="مبلغ وقدرة"></asp:Label>
                            </td>
                            <td align="right" >
                                <asp:TextBox ID="txtAmount" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtAmount"
                                    Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                    Type="Currency">*</asp:CompareValidator>
                            </td>
                        </tr>
                         <tr>
                            <td align="right" >
                                <asp:Label ID="Label7" runat="server" Text="وذلك عن"></asp:Label>
                            </td>
                            <td align="right" >
                                <asp:TextBox ID="txtRemark" MaxLength="50" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" >
                            </td>
                            <td align="center">
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                         <tr>
                            <td align="right" >
                                <asp:Label ID="Label28" runat="server" Text="الحساب المدين"></asp:Label>
                            </td>
                            <td align="right" >
                                <asp:TextBox ID="txtCode" runat="server" Width="90px"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCode"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace1_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                <asp:TextBox ID="txtName" runat="server" Width="198px"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtName"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                    OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                    CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                            </td>
                            <td align="right" >
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td align="right" >
                                <asp:Label ID="lblAccCode2" runat="server" Text="حساب البنك"></asp:Label>
                            </td>
                            <td align="right" >
                                <asp:DropDownList ID="ddlAccCode2" Width="300px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right" >
                                &nbsp;</td>
                            <td align="center">
                                <asp:Label ID="Label30" runat="server" Text="الحالة"></asp:Label>
                             </td>
                            <td align="right">
                              <asp:DropDownList ID="ddlApproved" Enabled="false" AutoPostBack="true" runat="server" 
                                                        onselectedindexchanged="ddlApproved_SelectedIndexChanged">
                                                        <asp:ListItem Text="معلق" Value="0"> </asp:ListItem>
                                                        <asp:ListItem Text="موافق" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="مرفوض" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="سدد" Value="3"></asp:ListItem>                                                    
                              </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table id="Table2" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="285px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    CssClass="MouseStop" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    CssClass="MouseStop" Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="285px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 70px;">
                            </td>
                            <td style="width: 300px;">
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
                        <tr align="right">
                            <td colspan="4" style="text-align: center">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة سند جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الطلب؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات الطلب" OnClientClick="return Validate()"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ValidationGroup="1" ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات الطلب"
                                    OnClientClick="return Validate2()" OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png" ToolTip="البحث عن بيانات الطلب" OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1" ToolTip="طباعة الطلب" OnClick="BtnPrint_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
            </fieldset>
        </div>
    </center>
</asp:Content>
