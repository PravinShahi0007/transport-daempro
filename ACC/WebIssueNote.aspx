<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebIssueNote.aspx.cs" Inherits="ACC.WebIssueNote" Culture="en-GB"
    UICulture="en-GB" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Plate_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCarNo');
            //var ace2Value = $get('ContentPlaceHolder1_txtPlateNo');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            //ace2Value.value = x[1];
            return false;
        }

        function acc1_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCode');
            var ace2Value = $get('ContentPlaceHolder1_txtName');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

        function ace1_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_grdCodes_txtITCode2');
            var ace2Value = $get('ContentPlaceHolder1_grdCodes_txtITName2');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            $get('ContentPlaceHolder1_grdCodes_ddlUnit2').focus();
            return false;
        }

        function ace2_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            var str2 = 'ContentPlaceHolder1_grdCodes_txtITName_' + x1[3];
            var ace1Value = $get(str);
            var ace2Value = $get(str2);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

        function ace3_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            var str2 = 'ContentPlaceHolder1_grdCodes_txtITCode_' + x1[3];
            var ace1Value = $get(str);
            var ace2Value = $get(str2);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[1];
            ace2Value.value = x[0];
            return false;
        }

        function ace0_itemSelected(sender, e) {
            alert('3');
            var str = sender.get_element().id;
            var ace1Value = $get(str);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[1];
            ace1Value.title = x[0];
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
            <h3 align="center">[ Issue Note ]</h3>
            <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label1" runat="server" Text="Note No."></asp:Label>

                                    <asp:TextBox ID="txtVouNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                                    <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                        ToolTip="Search for Issue Note Data" OnClick="BtnFind_Click" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                        Display="Dynamic" ErrorMessage="You should Enter Note No." ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>

                                    <asp:TextBox ID="txtVouDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                        Display="Dynamic" ErrorMessage="You Should Select Note Date" ForeColor="Red"
                                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="Note Date Should be Date Value"
                                        ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                        PopupPosition="BottomLeft" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label6" runat="server" Text="J.Order No."></asp:Label>

                                    <asp:TextBox ID="txtRefNo" CssClass="form-control" runat="server" AutoPostBack="True"
                                        OnTextChanged="txtRefNo_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ValRefNo" runat="server" ControlToValidate="txtRefNo"
                                        InitialValue="" Display="Dynamic" ErrorMessage="You Should Enter Job Work" ForeColor="Red"
                                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ImageButton ID="BtnFind2" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                        ToolTip="Search for Purchase Order Data" OnClick="BtnFind2_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label4" runat="server" Text="Car No."></asp:Label>

                                    <asp:TextBox ID="txtCarNo" MaxLength="15" CssClass="form-control" autocomplete="off" ReadOnly="true"
                                        AutoPostBack="True" runat="server" OnTextChanged="txtCarNo_TextChanged"></asp:TextBox>
                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender03" runat="server" TargetControlID="txtCarNo"
                                        ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars20" OnClientItemSelected="Plate_itemSelected"
                                        MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="30"
                                        CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                    <asp:ImageButton ID="BtnFindCar" runat="server" ValidationGroup="55" Enabled="false" ImageUrl="~/images/zoom_16.png"
                                        ToolTip="Search for Car" OnClick="BtnFindCar_Click" />
                                    <asp:DropDownList ID="ddlCar" CssClass="form-control" runat="server" AutoPostBack="True" Enabled="false"
                                        OnSelectedIndexChanged="ddlCar_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ValCar" runat="server" ControlToValidate="ddlCar"
                                        InitialValue="-1" Display="Dynamic" ErrorMessage="You Should Select Car" ForeColor="Red"
                                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:CheckBox ID="ChkLost" runat="server" AutoPostBack="True"
                                        OnCheckedChanged="ChkLost_CheckedChanged" Text="عجز بضاعة" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label8" runat="server" Text="Part No."></asp:Label>

                                    <asp:TextBox ID="txtItemCode" CssClass="form-control" MaxLength="100" runat="server"
                                        AutoPostBack="True" OnTextChanged="txtItemCode_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label7" runat="server" Text="Remark"></asp:Label>

                                    <asp:TextBox ID="txtRemark" CssClass="form-control" MaxLength="100" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="table table-responsive text-center">
                            <asp:GridView ID="grdCodes" runat="server" CellPadding="4" Width="100%" ForeColor="#333333"
                                ShowFooter="True" ViewStateMode="Enabled" GridLines="None" AutoGenerateColumns="False"
                                DataKeyNames="FNo" AllowPaging="True" PageSize="200" OnPageIndexChanging="grdCodes_PageIndexChanging"
                                OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowCommand="grdCodes_RowCommand"
                                OnRowDeleting="grdCodes_RowDeleting" OnRowEditing="grdCodes_RowEditing" OnRowUpdating="grdCodes_RowUpdating"
                                OnSelectedIndexChanging="grdCodes_SelectedIndexChanging"
                                OnSelectedIndexChanged="grdCodes_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="Delete Item"
                                                ImageUrl="~/images/cross.png" OnClientClick='<%# Eval("ItCode", "return confirm(\"Delete This Item {0} ...Are You Sure?\");") %>' />
                                            <asp:ImageButton ID="btnEdit" Visible="false" runat="server" CommandName="Select" ToolTip="Edit Item"
                                                ImageUrl="~/images/pencil.png" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="Save Changes"
                                                ImageUrl="~/images/accept.png" />
                                            <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="Cancel Changes"
                                                ImageUrl="~/images/delete.png" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="Add New Item"
                                                ImageUrl="~/images/add.png" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SL" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part No." SortExpression="ITCode" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblITCode" Text='<%# Bind("ITCode") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtITCode" Text='<%# Bind("ITCode") %>' autocomplete="off" runat="server" CssClass="form-control" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtITCode"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionStock" OnClientItemSelected="ace2_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="30"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtITCode2" runat="server" autocomplete="off" CssClass="form-control" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtITCode2"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionStock" OnClientItemSelected="ace1_itemSelected"
                                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="30"
                                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </FooterTemplate>
                                        <ControlStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part Name" SortExpression="ITName2" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblITName" Text='<%# Bind("ITName2") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtITName" Text='<%# Bind("ITName2") %>' autocomplete="off" runat="server" CssClass="form-control" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtITName"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionStock2" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace3_itemSelected" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="30" CompletionListCssClass="autocomplete_completionListElement"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtITName2" runat="server" autocomplete="off" CssClass="form-control" />
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtITName2"
                                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionStock2" MinimumPrefixLength="1"
                                                OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                                CompletionSetCount="30" CompletionListCssClass="autocomplete_completionListElement"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                        </FooterTemplate>
                                        <ControlStyle Width="300px" />
                                        <ItemStyle HorizontalAlign="Center" Width="300px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit" SortExpression="Unitname2" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit" Text='<%# Bind("UnitName2") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlUnit" EnableViewState="false" OnInit="ddlUnit2_Init" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlUnit2" runat="server" OnInit="ddlUnit2_Init">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ControlStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty" SortExpression="Quan" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuan" Text='<%# Bind("Quan") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtQuan" Text='<%# Bind("Quan") %>' CssClass="form-control" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtQuan2" Width="80px" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                        <ControlStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" Text='<%# Bind("Price") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblPrice2" Text='<%# Bind("Price") %>' runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ControlStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblAmount2" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ControlStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
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
                            <!--OnInit="ddlArea_Init"-->
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label3" runat="server" Text="Total Qty:"></asp:Label>

                                    <asp:Label ID="lblTotalQty" runat="server" CssClass="form-control" Text=""></asp:Label>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label9" runat="server" Text="Balance"></asp:Label>

                                    <asp:Label ID="lblBal" runat="server" CssClass="form-control" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label5" runat="server"  Text="Total:"></asp:Label>

                                   <asp:Label ID="LblTotal" runat="server" CssClass="form-control" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label14" runat="server" Text="User Name"></asp:Label>

                                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                        Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label15" runat="server" Text="Date"></asp:Label>

                                    <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                        Enabled="false">                                                               
                                    </asp:TextBox>
                                    <asp:Label ID="Label27" runat="server" Text="* Required Fields"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label10" runat="server" Text="Password"></asp:Label>

                                    <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:Button ID="BtnUnlock" runat="server" CssClass="btn btn-primary" Text="Unlock"
                                        OnClick="BtnUnlock_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    

                                    <asp:ImageButton ID="BtnNew" runat="server" AlternateText="New" CommandName="New"
                                        ImageUrl="~/images/data add.png" CssClass="ops" ToolTip="Add New Issue Note"
                                        ValidationGroup="1" OnClientClick='return confirm("Adding New Issue Note...Are You Sure?")'
                                        OnClick="BtnNew_Click" />
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                        ImageUrl="~/images/edit2.png" CssClass="ops" ToolTip="Edit Issue Note"
                                        Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                    <asp:ImageButton ID="BtnClear" runat="server" AlternateText="Clear" CommandName="Clear"
                                        ImageUrl="~/images/clear all.png" CssClass="ops" ToolTip="Clear Form Fields"
                                        OnClick="BtnClear_Click" />
                                    <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="Delete" CommandName="Delete"
                                        ImageUrl="~/images/delete2.png" CssClass="ops" ToolTip="Delete Issue Note" OnClientClick='return confirm("Delete This Issue Note...Are You Sure?")'
                                        OnClick="BtnDelete_Click" />
                                    <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="Find" CommandName="Find"
                                        ImageUrl="~/images/data search.png" CssClass="ops" ToolTip="Search for Issue Note"
                                        OnClick="BtnSearch_Click" />
                                    <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="Print" CommandName="Print"
                                        ImageUrl="~/images/print.png" ValidationGroup="1" CssClass="ops" ToolTip="Print Issue Note"
                                        OnClick="BtnPrint_Click" />
                                    <asp:ImageButton ID="BtnChPrice" runat="server" AlternateText="Print" CommandName="ChPrice" Visible="false"
                                        ImageUrl="~/images/ChangePrice2.png" ValidationGroup="1" CssClass="ops" ToolTip="Change Price for All Issue Notes" OnClientClick='return confirm("Change Prices for ALL Issue Note...Are You Sure?")'
                                        OnClick="BtnChPrice_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">
                                        Attach Files
                                        <asp:Label ID="Label34" runat="server">(Show Details...)</asp:Label>
                                    </h4>
                                    <div class="card-tools">
                                  <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                              </div>
                                </div>
                                <div class="card-body" style="display:none;">
                                    <asp:Panel ID="Panel2" runat="server">
                                        <asp:Panel ID="Panel1" runat="server">
                            <div class="table-responsive table">
                                <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                                    ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                    Width="100%" OnRowDeleting="grdAttach_RowDeleting">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="Delete File"
                                                    ImageUrl="~/images/cross.png" OnClientClick='return confirm("Delete tis File ... Are you Sure?")' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="File" ItemStyle-HorizontalAlign="Center">
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
                            </div>
                            
                                            <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                            ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                            ImageControlID="Image1" ExpandedText="(Hide Details)" CollapsedText="(Show Details)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                        </asp:Panel>
                       
                                <div class="form-row">
                                    <div class="form-group col-sm-6">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>
                                    <div class="form-group col-sm-6">
                                        <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="Attach" CommandName="Attach"
                                            CssClass="ops" ImageUrl="~/images/attach1.png" ToolTip="Attach File" ValidationGroup="1"
                                            OnClick="BtnAttach_Click" />
                                        </div> 
                                   </div>
   
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>

                       
                        
                   

<hr />
            <h3 align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[  أعتماد المدير المباشر ]</b></h3>
             <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="lblRemark9" runat="server" Text="ملاحظات"></asp:Label>
                      
                            <asp:TextBox ID="txtAgreeRemark1"  TextMode="MultiLine" CssClass="form-control"  runat="server"></asp:TextBox>
                     
                            <asp:CheckBox ID="chkAgree1" runat="server" Text="تم الأعتماد"
                                AutoPostBack="True" OnCheckedChanged="chkAgree1_CheckedChanged" />
                   </div></div></div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="lblAgreeUser" runat="server" Text="المستخدم"></asp:Label>
                  
                            <asp:TextBox ID="txtAgreeUser1" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                    </div></div></div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="lblAgreeUserDate" runat="server" Text="تاريخ التعميد"></asp:Label>
                      
                            <asp:TextBox ID="txtAgreeUserDate1" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                    </div></div></div>
        </div>
<hr />
     
                <h3 align="center" >
                  [  أعتماد الإدارة المالية ]</h3>
                              <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label11" runat="server" Text="ملاحظات"></asp:Label>
                       
                                <asp:TextBox ID="txtAgreeRemark2"  TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                          
                                <asp:CheckBox ID="chkAgree2" runat="server" Text="تم الأعتماد"
                                    OnCheckedChanged="chkAgree2_CheckedChanged" AutoPostBack="True" />
                           </div></div></div>
           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label12" runat="server" Text="المستخدم"></asp:Label>
                         
                                <asp:TextBox ID="txtAgreeUser2" CssClass="form-control" runat="server"  ReadOnly="false"></asp:TextBox>
                          </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label13" runat="server" Text="تاريخ التعميد"></asp:Label>
                          
                                <asp:TextBox ID="txtAgreeUserDate2" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                           
        </div>
    </div>
    </div></div></div></div></div>
</asp:Content>
