<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"
    CodeBehind="WebRVou.aspx.cs" Inherits="ACC.WebRVou" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ سندات القبض المجمعة ]</b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 10%;">
                                <asp:Label ID="Label1" runat="server" Text="رقم القيد"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 25%;">
                                <asp:TextBox ID="txtVouNo" runat="server" CssClass="MouseStop"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات السند" OnClick="BtnFind_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم القيد" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 5%;">
                            </td>
                            <td align="center" style="width: 10%;">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 20%;">
                                <asp:TextBox ID="txtVouDate" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ القيد" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td style="width: 5%;">
                            </td>
                            <td style="width: 15%;">
                                <asp:Label ID="Label6" runat="server" Text="السجلات/الصفحة"></asp:Label>
                            </td>
                            <td style="width: 10%;">
                                <asp:DropDownList ID="ddlRecordsPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="20">25</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="width: 100%; overflow:none; overflow-x:auto ; border: 1px solid #800000;">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" Width="100%" ForeColor="#333333"
                            ShowFooter="True" ViewStateMode="Enabled" GridLines="None" AutoGenerateColumns="False"
                            DataKeyNames="sno" AllowPaging="True" PageSize="25" OnRowCommand="grdCodes_RowCommand"
                            OnPageIndexChanging="grdCodes_PageIndexChanging" OnRowCancelingEdit="grdCodes_RowCancelingEdit"
                            OnRowUpdating="grdCodes_RowUpdating" OnRowDeleting="grdCodes_RowDeleting" OnSelectedIndexChanging="grdCodes_SelectedIndexChanging"
                            OnRowEditing="grdCodes_RowEditing">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="مدين" SortExpression="Debit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDebit" Text='<%# Eval("Debit","{0:N2}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDebit2" Text='<%# Bind("Debit") %>' runat="server" Width="100px" />
                                        <asp:CompareValidator ID="ValDebit2" runat="server" ControlToValidate="txtDebit2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 120px">
                                            <asp:TextBox ID="txtDebit" runat="server" Width="100px" />
                                            <asp:CompareValidator ID="ValDebit" runat="server" ControlToValidate="txtDebit" Display="Dynamic"
                                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                                Type="Currency">*</asp:CompareValidator>
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="دائن" SortExpression="Credit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCredit" Text='<%# Eval("Credit","{0:N2}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCredit2" Text='<%# Bind("Credit") %>' runat="server" Width="100px" />
                                        <asp:CompareValidator ID="ValCredit2" runat="server" ControlToValidate="txtCredit2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 120px">
                                            <asp:TextBox ID="txtCredit" runat="server" Width="100px" />
                                            <asp:CompareValidator ID="ValCredit" runat="server" ControlToValidate="txtCredit"
                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                                Type="Currency">*</asp:CompareValidator>
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
                                        <asp:TextBox ID="txtCode2" Text='<%# Bind("Code") %>' runat="server" Width="100%" />
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCode2"
                                            ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace2_itemSelected"
                                            MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 120px">
                                            <asp:TextBox ID="txtCode" runat="server" Width="100%" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCode"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace1_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="أسم الحساب/شرح القيد" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lblRemark" Text='<%# Bind("Remark") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtName2" Text='<%# Bind("Name") %>' runat="server" Width="100%" />
                                        <asp:TextBox ID="txtRemark2" Text='<%# Bind("Remark") %>' runat="server" Width="100%" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 260px">
                                            <asp:TextBox ID="txtName" runat="server" Width="100%" autocomplete="off" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtName"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                            <asp:TextBox ID="txtRemark" runat="server" Width="100%" />
                                        </div>
                                    </FooterTemplate>
                                    <ControlStyle Width="260px" />
                                    <ItemStyle HorizontalAlign="Center" Width="260px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="مركز تكلفة / مشروع" SortExpression="CostCenter" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostCenter" Text='<%# bind("CostCenterCode") %>' runat="server"
                                            Width="50px"></asp:Label>
                                        <asp:Label ID="lblProject" Text='<%# bind("CostCenter") %>' runat="server" Width="135px"></asp:Label>
                                        <asp:Label ID="Label7" Text='<%# bind("ProjectCode") %>' runat="server" Width="50px"></asp:Label>
                                        <asp:Label ID="Label8" Text='<%# bind("Project") %>' runat="server" Width="135px"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div style="width: 200px; display: block; float: right;">
                                            <asp:TextBox ID="txtCostCenterCode" runat="server" Width="50px" />
                                            <asp:TextBox ID="txtCostCenter2" runat="server" Width="130px" />
                                            <asp:TextBox ID="txtProjectCode" runat="server" Width="50px" />
                                            <asp:TextBox ID="txtProject2" runat="server" Width="130px" />
                                        </div>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <div style="width: 200px">
                                            <asp:TextBox ID="txtCostCenter" runat="server" Width="100%" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender7" runat="server" TargetControlID="txtCostCenter"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList3" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace1_itemSelectedCostCenter" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                            <asp:TextBox ID="txtProject" runat="server" Width="100%" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender8" runat="server" TargetControlID="txtProject"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList4" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace1_itemSelectedProject" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                            <asp:HiddenField ID="lblCostCenterCode" runat="server" />
                                            <asp:HiddenField ID="lblProjectCode" runat="server" />
                                        </div>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                        <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="تعديل البند"
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
                    <table width="100%" cellpadding="3" cellspacing="0" border="2px">
                        <tr>
                            <td style="width: 17%;">
                                <asp:Label ID="Label3" runat="server" Text="إجمالي مدين"></asp:Label>
                            </td>
                            <td style="width: 17%;">
                                <asp:Label ID="lblTotalDB" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 17%;">
                                <asp:Label ID="Label5" runat="server" Text="إجمالي دائن"></asp:Label>
                            </td>
                            <td style="width: 17%;">
                                <asp:Label ID="lblTotalCR" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 16%;">
                                <asp:Label ID="Label4" runat="server" Text="الفرق"></asp:Label>
                            </td>
                            <td style="width: 16%;">
                                <asp:Label ID="lblDiff" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table id="Table2" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="right">
                            <td colspan="4">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="300px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
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
                            <td colspan="4">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4" style="width: 100%;">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png"   ToolTip="أضافة قيد يومية جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات القيد؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات قيد يومية"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات قيد يومية"
                                    OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات القيد؟")' OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png"   ToolTip="البحث عن بيانات القيد"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1"   ToolTip="طباعة قيد اليومية" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </center>
            </fieldset>
        </div>
    </center>
</asp:Content>
