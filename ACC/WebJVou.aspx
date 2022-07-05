<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" CodeBehind="WebJVou.aspx.cs"
    Inherits="ACC.WebJVou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pageLoad() {
            $("input[name*='grdCodes'],select[name*='grdCodes']").change(function (event) {
                if ($get('ContentPlaceHolder1_ChkEdit').checked) {
                    var res = event.target.id.split("_");
                    $(this).addClass('ChangedText');
                }
            });
            SetMyStyle();
        }
        function ace1_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtCode');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_txtName');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

        function ace00_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtCode0_' + x1[3]);
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_txtName0_' + x1[3]);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }


        function ace20_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtCode2_' + x1[3]);
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_txtName2_' + x1[3]);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

        function ace22_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtCode2');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_txtName2');
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
            return confirm("هل أنت متاكد من الغاء بيانات قيد اليومية؟");
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <center>
        <div class="form border border-primary">
            <fieldset>
                <div class="form-group text-center">
                    <h4>قيد اليومية
                    </h4>
                    <br />
                </div>
                <div class="form-row">
                    <div class="form-group col-sm-2">
                        <asp:Label ID="Label1" runat="server" Text="رقم القيد"></asp:Label>
                        *
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                            Display="Dynamic" ErrorMessage="يجب أختيار رقم القيد" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-sm-1">
                        <asp:Button ID="BtnCheckNo" CssClass="form-control" runat="server" Text="..."
                            OnClick="BtnCheckNo_Click" />
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>
                        *
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:TextBox ID="txtVouDate" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                            Display="Dynamic" ErrorMessage="يجب أختيار تاريخ القيد" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                            CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                            ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                            TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                            PopupPosition="BottomLeft" />
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-1">
                        <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/search3.png"
                            ToolTip="البحث عن بيانات قيد يومية" OnClick="BtnFind_Click" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-sm-2"></div>
                    <div class="form-group col-sm-2">
                        <asp:CheckBox ID="ChkClaim" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnCheckedChanged="ChkClaim_CheckedChanged" Text="عرض المطالبات" />
                    </div>

                    <div class="form-group col-sm-2" style="background-image: linear-gradient(to right, #185fb2 , #f97d29); padding: 5px; border-radius: 4px;">
                        <asp:LinkButton ID="BtnRecovery" CssClass="text-white" runat="server" OnClick="BtnRecovery_Click">الاسترداد التلقائي</asp:LinkButton>
                    </div>

                    <div class="form-group col-sm-2">
                        <asp:DropDownList ID="ddlClaim" Visible="false" CssClass="form-control" runat="server"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlClaim_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                    <div class="form-group col-sm-2">
                        <asp:Label ID="Label9" runat="server" Text="السجلات/الصفحة"></asp:Label>
                    </div>
                    <div class="form-group col-sm-1">
                        <asp:DropDownList ID="ddlRecordsPerPage" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                            <asp:ListItem Value="20">25</asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>
                            <asp:ListItem Value="100">100</asp:ListItem>
                            <asp:ListItem Value="200">200</asp:ListItem>
                            <asp:ListItem Value="500">500</asp:ListItem>
                            <asp:ListItem Value="1000">1000</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-sm-1"></div>
                </div>

                <center>

                    <div class="text-center" style="background-image: linear-gradient(to right, #185fb2 , #f97d29);">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4"
                            ShowFooter="True" ViewStateMode="Enabled" GridLines="None" AutoGenerateColumns="False"
                            DataKeyNames="sno" PageSize="25" OnRowCommand="grdCodes_RowCommand"
                            OnPageIndexChanging="grdCodes_PageIndexChanging" OnRowCancelingEdit="grdCodes_RowCancelingEdit"
                            OnRowUpdating="grdCodes_RowUpdating" OnRowDeleting="grdCodes_RowDeleting" OnSelectedIndexChanging="grdCodes_SelectedIndexChanging"
                            OnRowEditing="grdCodes_RowEditing"
                            OnSelectedIndexChanged="grdCodes_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>

                                <asp:TemplateField HeaderText="تسلسل" SortExpression="sno" ItemStyle-HorizontalAlign="Center">

                                    <ItemTemplate>
                                        <div class="text-center form-group">
                                            <asp:Label ID="lblSNo" Text='<%# Eval("SNo") %>' runat="server"></asp:Label>
                                        </div>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="text-center form-group">
                                            <asp:Label ID="lblSNo2" Text='<%# Eval("SNo") %>' runat="server"></asp:Label>
                                        </div>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtFNo" placeholder="تسلسل" MaxLength="4" runat="server" CssClass="form-control" />
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle />
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="مدين" SortExpression="Debit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-group">
                                            <asp:Label ID="lblDebit" Text='<%# Eval("Debit","{0:N2}") %>' runat="server"></asp:Label>
                                        </div>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtDebit2" Text='<%# Bind("Debit") %>' MaxLength="15" runat="server"
                                                CssClass="form-control" />
                                            <asp:CompareValidator ID="ValDebit2" runat="server" ControlToValidate="txtDebit2"
                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                                Type="Currency">*</asp:CompareValidator>
                                        </div>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div class="col-sm-12 form-group">
                                            <asp:TextBox ID="txtDebit" MaxLength="15" runat="server" CssClass="form-control" />
                                            <asp:CompareValidator ID="ValDebit" runat="server" ControlToValidate="txtDebit" Display="Dynamic"
                                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                                Type="Currency">*</asp:CompareValidator>
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle />
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="دائن" SortExpression="Credit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-group">
                                            <asp:Label ID="lblCredit" Text='<%# Eval("Credit","{0:N2}") %>' runat="server"></asp:Label>
                                        </div>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCredit2" Text='<%# Bind("Credit") %>' MaxLength="15" runat="server"
                                                CssClass="form-control" />
                                            <asp:CompareValidator ID="ValCredit2" runat="server" ControlToValidate="txtCredit2"
                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                                Type="Currency">*</asp:CompareValidator>
                                        </div>

                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div class="form-group col-sm-12">
                                            <asp:TextBox ID="txtCredit" runat="server" MaxLength="15" CssClass="form-control" />
                                            <asp:CompareValidator ID="ValCredit" runat="server" ControlToValidate="txtCredit"
                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                                Type="Currency">*</asp:CompareValidator>
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle />
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="كود الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-group">
                                            <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                        </div>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCode2" Text='<%# Bind("Code") %>' CssClass="form-control" runat="server" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender02" runat="server" TargetControlID="txtCode2"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace2_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </div>

                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div class="form-group col-sm-12">
                                            <asp:TextBox ID="txtCode" runat="server" CssClass="form-control" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender03" runat="server" TargetControlID="txtCode"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace1_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle />
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="أسم الحساب/شرح القيد/المستند" SortExpression="Name"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-row">
                                            <div class="form-group col-sm-12">
                                                <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                                <asp:Label ID="lblRemark" Text='<%# Bind("Remark") %>' MaxLength="200" runat="server"></asp:Label>
                                                <asp:Label ID="lblInvNo" Text='<%# Bind("InvNo") %>' runat="server"></asp:Label>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtName2" Text='<%# Bind("Name") %>' runat="server" CssClass="form-control" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteName2" runat="server" TargetControlID="txtName2"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace20_itemSelected" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                            <asp:TextBox ID="txtRemark2" Text='<%# Bind("Remark") %>' MaxLength="200" runat="server" CssClass="form-control" />
                                            <asp:TextBox ID="txtInvNo2" Text='<%# Bind("InvNo") %>' MaxLength="15" runat="server" CssClass="form-control" />
                                        </div>

                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtName" placeholder="أدخل اسم الحساب" runat="server" CssClass="form-control" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteName" runat="server" TargetControlID="txtName"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                            <asp:TextBox ID="txtRemark" placeholder="أدخل شرح القيد" runat="server" CssClass="form-control" />
                                            <asp:TextBox ID="txtInvNo" placeholder="أدخل رقم المستند" runat="server" MaxLength="15" CssClass="form-control" />
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle />
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التوجية" SortExpression="CostCenter" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-group">
                                            <asp:Label ID="lblArea" Text='<%# Bind("Area") %>' runat="server"></asp:Label>
                                            <asp:Label ID="lblCostCenter" Text='<%# Bind("CostCenter") %>' runat="server"></asp:Label>
                                            <asp:Label ID="lblProject" Text='<%# Bind("Project") %>' runat="server"></asp:Label>
                                            <asp:Label ID="lblCostAcc" Text='<%# Bind("CostAcc") %>' runat="server"></asp:Label>
                                            <asp:Label ID="lblEmp" Text='<%# Bind("Emp") %>' runat="server"></asp:Label>
                                            <asp:Label ID="lblCarNo" Text='<%# Bind("CarNo2") %>' runat="server"></asp:Label>
                                        </div>

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="form-group col-sm-12">
                                            <asp:DropDownList ID="ddlArea" EnableViewState="false" CssClass="form-control" runat="server"
                                                OnInit="ddlArea_Init" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCostCenter" EnableViewState="true" CssClass="form-control" runat="server"
                                                OnInit="ddlCostCenter_Init" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlCostCenter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlProject" EnableViewState="false" CssClass="form-control" runat="server"
                                                OnInit="ddlProject_Init">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCostAcc" EnableViewState="false" CssClass="form-control" runat="server"
                                                OnInit="ddlCostAcc_Init">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlEmp" EnableViewState="false" CssClass="form-control" runat="server"
                                                OnInit="ddlEmp_Init" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <%--<asp:DropDownList ID="ddlCarNo" EnableViewState="false" Width="99%" runat="server"
                                                OnInit="ddlCarNo_Init"></asp:DropDownList>--%>
                                            <asp:TextBox ID="txtCarNo" runat="server" CssClass="form-control" placeholder="ادخل رقم اللوحة" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteCarNo" runat="server" TargetControlID="txtCarNo"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars2" OnClientItemSelected="car1_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </div>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div class="form-group col-sm-12">
                                            <asp:DropDownList ID="ddlArea2" CssClass="form-control" AutoPostBack="True" runat="server"
                                                OnSelectedIndexChanged="ddlArea2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCostCenter2" CssClass="form-control" runat="server"
                                                AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlCostCenter2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlProject2" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCostAcc2" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlEmp2" CssClass="form-control" AutoPostBack="True" runat="server"
                                                OnSelectedIndexChanged="ddlEmp2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <%-- <asp:DropDownList ID="ddlCarNo2" Width="99%" runat="server">
                                            </asp:DropDownList>--%>
                                            <asp:TextBox ID="txtCarNo2" runat="server" placeholder="ادخل رقم اللوحة" CssClass="form-control" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteCarNo2" runat="server" TargetControlID="txtCarNo2"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars2" OnClientItemSelected="car1_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </div>
                                    </FooterTemplate>
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند" ValidationGroup="1"
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
                            <FooterStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                HorizontalAlign="Center" />
                            <HeaderStyle Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </div>
                    <br />
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label3" runat="server" Text="إجمالي مدين"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblTotalDB" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label5" runat="server" Text="إجمالي دائن"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblTotalCR" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label4" runat="server" Text="الفرق"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblDiff" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>

                    </div>
                    <!--***********Edit by ankur kumar ***********-->
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop form-control"
                                Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:TextBox ID="txtUserDate" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop form-control"
                                Enabled="false">                                                               
                            </asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:TextBox ID="txtReason" Visible="false" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                ValidationGroup="10">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                    </div>
                    <br />
                    <div class="form-row">

                        <div class="form-group col-sm-4"></div>
                        <div class="form-group col-sm-4">
                            <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                ImageUrl="~/images/data add.png" ToolTip="أضافة قيد يومية جديد"
                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات القيد؟")'
                                OnClick="BtnNew_Click" />
                            <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات قيد يومية" OnClientClick="return Validate();"
                                Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                            <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة"
                                OnClick="BtnClear_Click" />
                            <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات قيد يومية"
                                OnClientClick="return Validate2();" OnClick="BtnDelete_Click" />
                            <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات القيد"
                                OnClick="BtnSearch_Click" />
                            <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                ImageUrl="~/images/print_64A.png" ValidationGroup="1" ToolTip="طباعة قيد اليومية"
                                OnClick="BtnPrint_Click" />
                        </div>
                        <div class="form-group col-sm-4">
                            <asp:CheckBox ID="ChkAccApprove" CssClass="form-control" Text="تعميد رئيس الحسابات" runat="server"
                                AutoPostBack="True" OnCheckedChanged="ChkAccApprove_CheckedChanged" />
                        </div>


                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                </center>
                <div class="row">
                    <div class="col-md-6 col-sm-12 col-xm-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">
                                    <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                    المرفقات
                                </h4>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                    <%--<button type="button" class="btn btn-tool" data-card-widget="remove" title="Remove">
                                        <i class="fas fa-times"></i>
                                    </button>--%>
                                </div>
                                <%--
                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />--%>
                            </div>



                            <div class="card-body" style="display: none;">
                                <asp:Panel ID="Panel2" runat="server">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="100%" OnRowDeleting="grdAttach_RowDeleting">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="form-group col-sm-2">
                                                            <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء الملف"
                                                                ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء الملف؟")' />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="الملف" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <div class="form-group col-sm-2">
                                                            <asp:HyperLink ID="lblFileName" Text='<%# Bind("FileName") %>' NavigateUrl='<%# Bind("FileName2") %>'
                                                                Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ControlStyle />
                                                    <ItemStyle></ItemStyle>
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
                                    <div class="form-row">
                                        <div class="form-group col-sm-6">
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>
                                        <div class="form-group col-sm-6">
                                            <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                                ValidationGroup="1" />
                                        </div>
                                        
                                    </div>
                                </asp:Panel>
                                <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                    ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                    ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                    ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                    SuppressPostBack="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xm-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">
                                    <asp:Label ID="Label6" runat="server">(عرض التفاصيل)</asp:Label>
                                    تتبع عمليات المستخدم
                                    

                                </h4>

                            

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                                <%--<button type="button" class="btn btn-tool" data-card-widget="remove" title="Remove">
                                    <i class="fas fa-times"></i>
                                </button>--%>
                            </div>
                            </div>

                            <div class="card-body" style="display: none;">
                                <!---->
                                <asp:Panel ID="Panel3" runat="server">
                                    <asp:Panel ID="Panel4" runat="server">
                                        <asp:GridView ID="grdTrans" runat="server" CellPadding="4" ForeColor="#333333"
                                            AllowPaging="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="UserDate2"
                                            Width="99%" OnSelectedIndexChanging="grdTrans_SelectedIndexChanging">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="form-group col-sm-12">
                                                            <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="أختيار العملية و عرض تفاصيلها"
                                                                ImageUrl="~/images/arrow_undo.png" />
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="التاريخ والوقت" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <div class="form-group col-sm-2">
                                                            <asp:Label ID="lblUserDate" Text='<%# Bind("UserDate2") %>' runat="server"></asp:Label>
                                                        </div>

                                                    </ItemTemplate>
                                                    <ControlStyle />
                                                    <ItemStyle></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المستخدم" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <div class="form-group col-sm-2">
                                                            <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                                        </div>

                                                    </ItemTemplate>
                                                    <ControlStyle />
                                                    <ItemStyle></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="الإجراء" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <div class="form-group col-sm-2">
                                                            <asp:Label ID="OPName" Text='<%# Bind("OPName") %>' runat="server"></asp:Label>
                                                        </div>

                                                    </ItemTemplate>
                                                    <ControlStyle />
                                                    <ItemStyle></ItemStyle>
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
                                        ExpandControlID="Panel3" CollapseControlID="Panel3" Collapsed="True" TextLabelID="Label6"
                                        ImageControlID="Img6" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </asp:Panel>

                            </div>
                        </div>

                    </div>
                </div>
        </div>


        <div class="form-group">
            <div class="form">

                <div class="form-row">



                    <div class="form-group col-sm-1">
                        
                    </div>
                    <div class="form-group col-sm-2">

                        <%-- <asp:ImageButton ID="Img6" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />--%>
                    </div>
                    <div class="form-group col-sm-2">
                    </div>
                    <div class="form-group col-sm-1">
                        
                                
                    </div>

                </div>

            </div>

        </div>
        <br />
        <br />
        <br />
        <br />

       
        </fieldset>
        </div>
         <br />
        <br />

        <fieldset class="form border border-danger">
            <h4 class="text-center">أعتماد الحسابات</h4>
            <br />

            <div class="form-row">
                <div class="form-group col-sm-2">
                    <asp:Label ID="lblRemark9" runat="server" Text="ملاحظات"></asp:Label>
                </div>
                <div class="form-group col-sm-6">
                    <asp:TextBox ID="txtAgreeRemark1" MaxLength="100" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-sm-4">
                    <asp:CheckBox ID="chkAgree1" runat="server" CssClass="form-control" Text="تم الأعتماد"
                        AutoPostBack="True" OnCheckedChanged="chkAgree1_CheckedChanged" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-2">
                    <asp:Label ID="lblAgreeUser" runat="server" Text="المستخدم"></asp:Label>
                </div>
                <div class="form-group col-sm-4">
                    <asp:TextBox ID="txtAgreeUser1" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                </div>
                <div class="form-group col-sm-2">
                    <asp:Label ID="lblAgreeUserDate" runat="server" Text="تاريخ التعميد"></asp:Label>
                </div>
                <div class="form-group col-sm-4">
                    <asp:TextBox ID="txtAgreeUserDate1" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                </div>
            </div>

        </fieldset>

        <br />

        <fieldset class="form border border-success">
            <h4 class="text-center">أعتماد رئيس الحسابات</h4>
            <br />

            <div class="form-row">
                <div class="form-group col-sm-2">
                    <asp:Label ID="Label51" runat="server" Text="ملاحظات"></asp:Label>
                </div>
                <div class="form-group col-sm-6">
                    <asp:TextBox ID="txtAgreeRemark2" MaxLength="100" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-sm-4">
                    <asp:CheckBox ID="chkAgree2" runat="server" Text="تم الأعتماد"
                        CssClass="form-control" OnCheckedChanged="chkAgree2_CheckedChanged" AutoPostBack="True" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-2">
                    <asp:Label ID="Label52" runat="server" Text="المستخدم"></asp:Label>
                </div>
                <div class="form-group col-sm-4">
                    <asp:TextBox ID="txtAgreeUser2" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                </div>
                <div class="form-group col-sm-2">
                    <asp:Label ID="Label53" runat="server" Text="تاريخ التعميد"></asp:Label>
                </div>
                <div class="form-group col-sm-4">
                    <asp:TextBox ID="txtAgreeUserDate2" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                </div>
            </div>


        </fieldset>


    </center>
</asp:Content>
