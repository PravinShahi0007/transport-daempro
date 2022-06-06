<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebBankPay.aspx.cs" Inherits="ACC.WebBankPay" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

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
            return confirm( <asp:Literal runat="server" Text="<%$ Resources: DeleteVou%>" /> );
        }        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ قسيمة إيداع بنكي]" meta:resourcekey="lblHead"></asp:Label>
                </b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label1" runat="server" Text="رقم السند" meta:resourcekey="Label1"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop"   ></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="<%$ Resources: EnterVouNo %>" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ" meta:resourcekey="Label2"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 17%;">
                                <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                    Display="Dynamic" ErrorMessage="<%$ Resources: EnterVouDate %>" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="<%$ Resources: DateValue %>"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td align="left" style="width: 17%;">

                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="<%$ Resources: Search %>" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="<%$ Resources: FindVou %>" OnClick="BtnFind_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label4" runat="server" Text="حساب البنك" meta:resourcekey="Label4"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlDbCode" Width="250px" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDbCode"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="<%$ Resources: FindVou %>" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label11" runat="server" Text="مبلغ وقدرة" meta:resourcekey="Label11"></asp:Label>
                            </td>
                            <td align="right" style="width: 17%;">
                                <asp:TextBox ID="txtAmount" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtAmount"
                                    Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                    Type="Currency">*</asp:CompareValidator>
                            </td>
                            <td align="right" style="width: 17%;">
                                <asp:RadioButtonList ID="RdoChq" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RdoChq_SelectedIndexChanged"
                                    RepeatColumns="2">
                                    <asp:ListItem Selected="True" Value="0" Text="<%$ Resources: Cash %>"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="<%$ Resources: Cheque %>"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label12" runat="server" Text="الحساب الدائن" meta:resourcekey="Label12"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtCode" runat="server" Width="90px"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCode"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace2_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCode"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:EnterCrAccount %>" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtName"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                    OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                    CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:EnterCrName %>" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblChqDate" runat="server" Visible="false" Text="تاريخ الشيك" meta:resourcekey="lblChqDate"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtChqDate" MaxLength="10" Visible="false" runat="server"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtChqDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtChqDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="<%$ Resources:DateValue %>"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label7" runat="server" Text="وذلك عن" meta:resourcekey="Label7"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtRemark" MaxLength="50" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblChqNo" runat="server" Visible="false" Text="رقم الشيك" meta:resourcekey="lblChqNo"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtchqNo" Visible="false" MaxLength="15" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label35" runat="server" Text="اسم المودع" meta:resourcekey="Label35"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtPerson" MaxLength="50" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblBankName" runat="server" Visible="false" Text="مسحوب على بنك" meta:resourcekey="lblBankName"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:TextBox ID="txtBankName" MaxLength="50" Visible="false" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblArea" runat="server" Text="المنطقة" meta:resourcekey="lblArea"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlArea" Width="250px" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblCostCenter" runat="server" Text="الفرع" meta:resourcekey="lblCostCenter"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:DropDownList ID="ddlCostCenter" Width="250px" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCostCenter_SelectedIndexChanged">
                                </asp:DropDownList>
                             </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblProject" runat="server" Text="المشروع" meta:resourcekey="lblProject"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlProject" Width="250px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblCostAcc" runat="server" Text="حساب التكاليف" meta:resourcekey="lblCostAcc"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;" colspan="2">
                                <asp:DropDownList ID="ddlCostAcc" Width="250px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblEmp" runat="server" Text="الموظف" meta:resourcekey="lblEmp"></asp:Label>
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
                                <asp:Label ID="Label14" runat="server" Text="المستخدم" meta:resourcekey="Label14"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="285px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ" meta:resourcekey="Label15"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية" meta:resourcekey="Label27"></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء" meta:resourcekey="lblReason"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="285px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="<%$ Resources: EnterReason %>" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="10">*</asp:RequiredFieldValidator>
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
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="<%$ Resources:New %>" CommandName="New"
                                    ImageUrl="<%$ Resources:NewImage %>"   ToolTip="<%$ Resources:NewTooltip %>"
                                    ValidationGroup="1" OnClientClick='<%$ Resources:NewConfirm %>'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="<%$ Resources:Edit %>" CommandName="Edit"
                                    ImageUrl="<%$ Resources:EditImage %>"   ToolTip="<%$ Resources:EditTooltip %>" OnClientClick="return Validate()"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="<%$ Resources:Clear %>" CommandName="Clear"
                                    ImageUrl="<%$ Resources:ClearImage %>"   ToolTip="<%$ Resources:ClearTooltip %>"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="<%$ Resources:Delete %>" CommandName="Delete" ValidationGroup="1"
                                    ImageUrl="<%$ Resources:DeleteImage %>"   ToolTip="<%$ Resources:DeleteTooltip %>" OnClientClick="return Validate2()"
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="<%$ Resources:Search %>" CommandName="Find"
                                    ImageUrl="<%$ Resources:SearchImage %>"   ToolTip="<%$ Resources:SearchTooltip %>"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="<%$ Resources:Print %>" CommandName="Print"
                                    ImageUrl="<%$ Resources:PrintImage %>" ValidationGroup="1"   ToolTip="<%$ Resources:PrintTooltip %>"
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
                                <asp:Literal ID="Literal1" Text="<%$ Resources:Attach2 %>" runat="server"></asp:Literal>
                            </div>
                            <div style="float: right; margin-right: 20px;">
                                <asp:Label ID="Label34" runat="server" Text="(عرض التفاصيل)" meta:resourcekey="Label34"></asp:Label>
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="<%$ Resources: Label34.Text %>" />
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
                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="<%$ Resources: DeleteFile %>"
                                            ImageUrl="~/images/cross.png" OnClientClick='<%$ Resources: SureDeleteFile %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources: File %>" ItemStyle-HorizontalAlign="Center">
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
                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="<%$ Resources: Attach %>" CommandName="Attach"
                                          ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="<%$ Resources: Attach2 %>"
                                        ValidationGroup="1" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                        ImageControlID="Image1" ExpandedText="<%$ Resources: HideDetails %>" CollapsedText="<%$ Resources: Label34.Text %>"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" /> 
                </div>

                     <div style="text-align: left; width: 50%; float:right;">
                    <asp:Panel ID="Panel3" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                        Direction="RightToLeft" ForeColor="#FFFF99">
                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                                <asp:Literal ID="Literal90" Text="<%$ Resources:TrackUser %>" runat="server"></asp:Literal>
                             </div>
                            <div style="float: right; margin-right: 20px;">
                                <asp:Label ID="Label6" runat="server" meta:resourcekey="Label34" Text="(عرض التفاصيل)"></asp:Label>
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Img6" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="<%$ Resources: Label34.Text %>" />
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
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="<%$ Resources: SelectTask %>"
                                        ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources: DateTime %>" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserDate" Text='<%# Bind("UserDate2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="125px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources: User %>" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="125px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources: Task %>" ItemStyle-HorizontalAlign="Center">
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
                        ExpandControlID="Panel3" CollapseControlID="Panel3" Collapsed="True" TextLabelID="Label6"
                        ImageControlID="Img6" ExpandedText="<%$ Resources: HideDetails %>" CollapsedText="<%$ Resources: Label34.Text %>"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                </div>
            </fieldset>


        </div>

              

    </center>
</asp:Content>
