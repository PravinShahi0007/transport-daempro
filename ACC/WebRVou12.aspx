<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" CodeBehind="WebRVou12.aspx.cs"
    Inherits="ACC.WebRVou12" %>

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

        function ace2_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            //var str2 = 'ContentPlaceHolder1_txtName_' + x1[3];
            var str2 = 'ContentPlaceHolder1_txtName';
            var ace1Value = $get(str);
            var ace2Value = $get(str2);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

        function ace0_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var ace1Value = $get(str);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[1];
            ace1Value.title = x[0];
            return false;
        }

        function ace1_itemSelectedCostCenter(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtCostCenter');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_lblCostCenterCode');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[1];
            ace2Value.value = x[0];
            return false;
        }

        function ace1_itemSelectedProject(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtProject');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_lblProjectCode');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[1];
            ace2Value.value = x[0];
            return false;
        }

        function Validate() {
            var isValid = false;
            isValid = Page_ClientValidate('1');
            if (isValid) {
                isValid = Page_ClientValidate('10');
            }
            return isValid;
        }

        function Validate2() {
            var isValid = false;
            isValid = Page_ClientValidate('1');
            if (isValid) {
                isValid = Page_ClientValidate('10');
            }
            return confirm("هل أنت متاكد من الغاء بيانات السند؟");
        }        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ سند القبض ]"></asp:Label>
                </b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label1" runat="server" Text="رقم السند"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 18%;">
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
                            <td align="right" style="width: 16%;">
                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات سند القبض" OnClick="BtnFind_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label6" runat="server" Text="أستلمنا من"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtPerson" runat="server" MaxLength="50" Width="305px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPerson"
                                    Display="Dynamic" ErrorMessage="يجب إدخال الاسم" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                &nbsp;<asp:Label ID="Label28" runat="server" Text="المستند"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:DropDownList ID="ddlDocType" runat="server">
                                    <asp:ListItem Value="0">طلب دفع</asp:ListItem>
                                    <asp:ListItem Value="9">أخرى</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtInvNo" MaxLength="15" runat="server"></asp:TextBox>
                                 <asp:ImageButton ID="BtnInvFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                  ToolTip="البحث عن بيانات المستند" OnClick="BtnInvFind_Click" />
                            
                            </td>
                        </tr>

                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label4" runat="server" Text="الحساب"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtCode" runat="server" Width="90px"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCode"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace2_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCode"
                                    Display="Dynamic" ErrorMessage="يجب إدخال رقم الحساب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtName"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                    OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                    CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="يجب إدخال أسم الحساب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label9" runat="server" Text="مبلغ وقدرة"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtAmount" MaxLength="15" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount"
                                    Display="Dynamic" ErrorMessage="يجب إدخال مبلغ السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValDebit2" runat="server" ControlToValidate="txtAmount"
                                    Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                    Type="Currency">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label10" runat="server" Text="النقدية/البنك"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlDbCode" Width="250px" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDbCode"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب النقدية/البنك"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CheckBox ID="ChkCheque" Text="بشيك" runat="server" AutoPostBack="True" OnCheckedChanged="ChkCheque_CheckedChanged" />
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label11" runat="server" Text="وذلك عن"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtRemark" MaxLength="200" Width="99.5%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label3" runat="server" Text="المنطقة"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlArea" Width="250px" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblChqDate" runat="server" Visible="false" Text="تاريخ الشيك"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtChqDate" MaxLength="10" Visible="false" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtChqDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtChqDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                             </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label13" runat="server" Text="الفرع"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlCostCenter" Width="250px" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCostCenter_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblChqNo" runat="server" Visible="false" Text="رقم الشيك"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtchqNo" Visible="false" MaxLength="15" Width="99.5%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label5" runat="server" Text="المشروع"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlProject" Width="250px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblBankName" runat="server" Visible="false" Text="مسحوب على بنك"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtBankName" MaxLength="50" Visible="false" Width="99.5%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label8" runat="server" Text="حساب التكاليف"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlCostAcc" Width="250px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label17" runat="server" Text="الموظف"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlEmp" Width="250px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
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
                                <asp:TextBox ID="txtUserName" Width="285px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>
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
                            <td colspan="4">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td colspan="4" style="text-align: center">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4" style="width: 100%;">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png"   ToolTip="أضافة سند جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السند؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات السند"
                                    OnClientClick="return Validate()" Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ValidationGroup="1" ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات السند"
                                    OnClientClick="return Validate2()" OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png"   ToolTip="البحث عن بيانات السند"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1"   ToolTip="طباعة السند"
                                    OnClick="BtnPrint_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </center>
            </fieldset>
        </div>
    </center>
</asp:Content>
