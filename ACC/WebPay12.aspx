<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebPay12.aspx.cs" Inherits="ACC.WebPay12" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ace1_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtCode');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_txtName');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }
        function ace22_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtCode2_' + x1[3]);
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_txtName2_' + x1[3]);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

        function car1_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var ace1Value = $get(str);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            return false;
        }

        function ace2_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            var str2 = 'ContentPlaceHolder1_grdCodes_txtName2_' + x1[3];
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

        function ace1_itemSelectedArea(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtArea');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_lblAreaCode');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[1];
            ace2Value.value = x[0];
            return false;
        }

        function ace1_itemSelectedCostAcc(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtCostAcc');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_lblCostAccCode');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[1];
            ace2Value.value = x[0];
            return false;
        }

        function ace1_itemSelectedEmp(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtEmp');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_lblEmpCode');
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


        function CallMe(src, Type2, no1) {
            var ctrl = document.getElementById(src);
            // call server side method
            PageMethods.GetDate(ctrl.value,Type2, CallSuccess, CallFailed, no1);
        }
        // set the destination textbox value with the ContactName
        function CallSuccess(res, no1) {
            var dest = document.getElementById(no1[0]);
            dest.value = res[0];

            var dest125 = document.getElementById(no1[1]);
            dest125.value = res[1];

            var dest130 = document.getElementById(no1[2]);
            dest130.value = res[2];

            var dest140 = document.getElementById(no1[3]);
            dest140.value = res[3];


            if (res[4] != "") {
                var dest150 = document.getElementById(no1[4]);
                dest150.innerHTML = res[4];
                $(function () {
                    var options = { id: 'message_from_top1',
                        position: 'top',
                        size: 50,
                        backgroundColor: '#D95429',
                        border_bottom_width: '1px',
                        border_bottom_color: '#CC0000',
                        border_bottom_style: 'solid',
                        color: 'white',
                        width: '100%',
                        delay: 3000,
                        speed: 500,
                        fontSize: '18px'
                    };
                    $.showMessage(res[4], options);
                    return false;
                });
            }
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            alert(res.get_message());
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
                                <asp:TextBox ID="txtPerson" runat="server" MaxLength="50" Width="285px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPerson"
                                    Display="Dynamic" ErrorMessage="يجب إدخال الاسم" ForeColor="Red" SetFocusOnError="True"
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
                                <asp:Label ID="Label10" runat="server" Text="حساب البنك"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlDbCode" Width="250px" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDbCode"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب النقدية/البنك"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CheckBox ID="ChkCheque" Text="بشيك" runat="server" Visible="false" AutoPostBack="True" OnCheckedChanged="ChkCheque_CheckedChanged" />
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label11" runat="server" Text="وذلك عن"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtRemark" MaxLength="200" Width="99%" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblChqNo" runat="server" Visible="false" Text="رقم الشيك*"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtchqNo" Visible="false" MaxLength="15" Width="285px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValchqNo" runat="server" ControlToValidate="txtchqNo"
                                    Display="Dynamic" ErrorMessage="يجب إدخال رقم الشيك" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblChqDate" runat="server" Visible="false" Text="تاريخ الشيك"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtChqDate" MaxLength="10" Visible="false" Width="200px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtChqDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtChqDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:RequiredFieldValidator ID="valtxtChqDate" runat="server" ControlToValidate="txtChqDate"
                                    Display="Dynamic" ErrorMessage="يجب إدخال تاريخ الشيك" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblBankName" runat="server" Visible="false" Text="مسحوب على بنك"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtBankName" MaxLength="50" Visible="false" Width="285px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label28" runat="server" Text="نوع المستند"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:DropDownList ID="ddlDocType" Width="120px" runat="server" AutoPostBack="true" 
                                    onselectedindexchanged="ddlDocType_SelectedIndexChanged">
                                    <asp:ListItem Value="0">طلب دفع</asp:ListItem>
                                    <asp:ListItem Value="2">بيان ترحيل</asp:ListItem>
                                    <asp:ListItem Value="5">أصلاح خارجي</asp:ListItem>                                    
                                    <asp:ListItem Value="1" Selected="True">أخرى</asp:ListItem>
                                </asp:DropDownList>                                
                             </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label4" runat="server" Text="الحسابات المدينة"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                &nbsp;</td>
                            <td align="right" style="width: 1%;">
                                &nbsp;</td>
                            <td align="center" style="width: 15%;">
                                &nbsp;</td>
                            <td align="right" style="width: 34%;" colspan="2">
                                &nbsp;</td>
                        </tr>
                        </table>
                       <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" Width="99.95%" ForeColor="#333333"
                            ShowFooter="True" ViewStateMode="Enabled" GridLines="None" AutoGenerateColumns="False"
                            DataKeyNames="sno" PageSize="25" OnRowCommand="grdCodes_RowCommand" 
                               AllowPaging="false" OnRowUpdating="grdCodes_RowUpdating"
                            OnPageIndexChanging="grdCodes_PageIndexChanging" 
                               OnRowDeleting="grdCodes_RowDeleting" 
                               OnSelectedIndexChanging="grdCodes_SelectedIndexChanging" 
                               onselectedindexchanged="grdCodes_SelectedIndexChanged" 
                               onrowcancelingedit="grdCodes_RowCancelingEdit">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="المبلغ" SortExpression="Debit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDebit" Text='<%# Eval("Debit","{0:N2}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div style="width: 126px">
                                            <asp:TextBox ID="txtDebit2" MaxLength="15" Text='<%# Eval("Debit") %>' runat="server" Width="100px" />
                                            <asp:CompareValidator ID="ValDebit2" runat="server" ControlToValidate="txtDebit2" Display="Dynamic"
                                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                                Type="Currency">*</asp:CompareValidator><br />
                                        </div>                                    
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 120px">
                                            <asp:TextBox ID="txtDebit" MaxLength="15" runat="server" Width="100px" />
                                            <asp:CompareValidator ID="ValDebit" runat="server" ControlToValidate="txtDebit" Display="Dynamic"
                                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                                Type="Currency">*</asp:CompareValidator><br />
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="كود الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div style="width: 120px">
                                            <asp:TextBox ID="txtCode2" runat="server" Width="120px" Text='<%# Bind("Code") %>' autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender01" runat="server" TargetControlID="txtCode2"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace22_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </div>                                    
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 120px">
                                            <asp:TextBox ID="txtCode" runat="server" Width="120px" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender02" runat="server" TargetControlID="txtCode"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace1_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="أسم الحساب/الشرح/المستند" SortExpression="Name"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lblRemark" Text='<%# Bind("Remark") %>' MaxLength="200" runat="server"></asp:Label>
                                        <asp:Label ID="lblInvNo" Text='<%# Bind("InvNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div style="width: 350px">
                                            <asp:TextBox ID="txtName2" Text='<%# Bind("Name") %>' runat="server" Width="100%" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender03" runat="server" TargetControlID="txtName2"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace22_itemSelected" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                            <asp:TextBox ID="txtRemark2" Text='<%# Bind("Remark") %>'  runat="server" Width="100%" />
                                            <asp:TextBox ID="txtInvNo2" Text='<%# Bind("InvNo") %>' runat="server" MaxLength="15" Width="100%"/>
                                        </div>                                    
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 350px">
                                            <asp:TextBox ID="txtName" placeholder="أدخل اسم الحساب" runat="server" Width="100%" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender04" runat="server" TargetControlID="txtName"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                            <asp:TextBox ID="txtRemark" placeholder="أدخل شرح القيد" runat="server" Width="100%" />
                                            <asp:TextBox ID="txtInvNo"  placeholder="أدخل رقم المستند" runat="server" MaxLength="15" Width="100%"/>
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle Width="350px" />
                                    <ItemStyle HorizontalAlign="Center" Width="350px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التوجية" SortExpression="CostCenter" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblArea" Text='<%# bind("Area") %>' runat="server" Width="100%"></asp:Label>
                                        <asp:Label ID="lblCostCenter" Text='<%# bind("CostCenter") %>' runat="server" Width="100%"></asp:Label>
                                        <asp:Label ID="lblProject" Text='<%# bind("Project") %>' runat="server" Width="100%"></asp:Label>
                                        <asp:Label ID="lblCostAcc" Text='<%# bind("CostAcc") %>' runat="server" Width="100%"></asp:Label>
                                        <asp:Label ID="lblEmp" Text='<%# bind("Emp") %>' runat="server" Width="100%"></asp:Label>
                                        <asp:Label ID="lblCarNo" Text='<%# bind("CarNo2") %>' runat="server" Width="100%"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div style="width: 200px; display: block; float: right;">
                                            <asp:DropDownList ID="ddlArea" EnableViewState="false" Width="99%" runat="server"
                                                OnInit="ddlArea_Init">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCostCenter" EnableViewState="false" Width="99%" runat="server"
                                                OnInit="ddlCostCenter_Init">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlProject" EnableViewState="false" Width="99%" runat="server"
                                                OnInit="ddlProject_Init">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCostAcc" EnableViewState="false" Width="99%" runat="server"
                                                OnInit="ddlCostAcc_Init">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlEmp" EnableViewState="false" Width="99%" runat="server"
                                                OnInit="ddlEmp_Init" AutoPostBack="True" onselectedindexchanged="ddlEmp2_SelectedIndexChanged">
                                             </asp:DropDownList>
                                            <asp:TextBox ID="txtCarNo" runat="server" Width="99%" placeholder="ادخل رقم اللوحة"  autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender05" runat="server" TargetControlID="txtCarNo"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars2" OnClientItemSelected="car1_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />                                          
                                        </div>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 200px">
                                            <asp:DropDownList ID="ddlArea2" Width="99%" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCostCenter2" Width="99%" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlProject2" Width="99%" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCostAcc2" Width="99%" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlEmp2" Width="99%" AutoPostBack="True" runat="server" 
                                                onselectedindexchanged="ddlEmp2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                           <%-- <asp:DropDownList ID="ddlCarNo2" Width="99%" runat="server">
                                            </asp:DropDownList>--%>
                                             <asp:TextBox ID="txtCarNo2" runat="server" placeholder="ادخل رقم اللوحة" Width="192px" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender06" runat="server" TargetControlID="txtCarNo2" 
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars2" OnClientItemSelected="car1_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />                                            
                                        </div>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند" ValidationGroup="55"
                                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                        <asp:ImageButton ID="btnEdit" runat="server" CommandName="Select" ToolTip="تعديل البند"
                                            ImageUrl="~/images/pencil.png" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="حفظ التعديلات"
                                            ImageUrl="~/images/accept.png" />
                                        <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="تجاهل التعديلات"
                                            ImageUrl="~/images/delete.png" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="أضافة بند جديد"
                                            ImageUrl="~/images/add.png" />
                                    </FooterTemplate>
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
                    <table id="Table2" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="right">
                            <td style="width: 120px;">
                                <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>                                
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="285px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label3" runat="server" Text="الاجمالي"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtTotal" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr align="right">
                            <td style="width: 120px;">
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
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowHeader="False"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" Width="99%" OnRowDeleting="grdAttach_RowDeleting">
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
                   <div style="text-align: left; width: 50%; float:right;">
                    <asp:Panel ID="Panel3" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                        Direction="RightToLeft" ForeColor="#FFFF99">
                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                                تتبع عمليات المستخدم</div>
                            <div style="float: right; margin-right: 20px;">
                                <asp:Label ID="Label60" runat="server">(عرض التفاصيل)</asp:Label>
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Img6" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                        BorderColor="Maroon">
                        <asp:GridView ID="grdTrans" runat="server" CellPadding="4" ForeColor="#333333" 
                            AllowPaging="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="UserDate2"
                            Width="99%" onselectedindexchanging="grdTrans_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="أختيار العملية و عرض تفاصيلها"
                                        ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التاريخ والوقت" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserDate" Text='<%# Bind("UserDate2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="125px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المستخدم" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="125px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الإجراء" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="OPName" Text='<%# Bind("OPName") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="50px" />
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
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="cpeDemo2" runat="Server" TargetControlID="Panel4"
                        ExpandControlID="Panel3" CollapseControlID="Panel3" Collapsed="True" TextLabelID="Label60"
                        ImageControlID="Img6" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                </div>
                </center>
            </fieldset>
        </div>
  <br />
             <div class="ColorRounded4Corners" style="width: 99.8%">                                
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
              <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                    <b>[  أعتماد رئيس الحسابات ]</b></legend>
                <center>
                       <table width="99.5%" dir="rtl" >
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark9" runat="server" Text="ملاحظات"></asp:Label>
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
                                        
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:CheckBox ID="chkAgree1" runat="server" Text="تم الأعتماد" 
                                            AutoPostBack="True" oncheckedchanged="chkAgree1_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUser" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser1" Width="250px" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate" runat="server" Text="تاريخ التعميد"></asp:Label>
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
                    <b>[  أعتماد المدير التنفيذي ]</b></legend>
                <center>
                        <table width="99.5%" dir="rtl" >
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label51" runat="server" Text="ملاحظات"></asp:Label>
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
                                        <asp:CheckBox ID="chkAgree2" runat="server" Text="تم الأعتماد" 
                                            oncheckedchanged="chkAgree2_CheckedChanged" AutoPostBack="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label52" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser2" Width="250px"  runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label53" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate2" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                </center>
            </fieldset>            
        </div>                
    </center>
</asp:Content>
