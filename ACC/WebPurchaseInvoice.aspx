<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebPurchaseInvoice.aspx.cs" Inherits="ACC.WebPurchaseInvoice" Culture="en-GB"
    UICulture="en-GB" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

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
          
                <h3 align="center">
                    <b>[ Purchase Invoice ]</b></h3>
                 <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label1" runat="server" Text="Invoice No."></asp:Label>
                          
                            <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                            <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                ToolTip="Search for Job Order Data" OnClick="BtnFind_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                Display="Dynamic" ErrorMessage="You should Enter Invoice No." ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                      </div></div></div>
                        
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                         
                            <asp:TextBox ID="txtVouDate"  runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                Display="Dynamic" ErrorMessage="You Should Select Invoice Date" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="Invoice Date Should be Date Value"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />
                     </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label6" runat="server" Text="Delivery Note No."></asp:Label>
                   
                            <asp:TextBox ID="txtRefNo"  runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:ImageButton ID="BtnFind2" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                ToolTip="Search for Purchase Order Data" OnClick="BtnFind2_Click" />
                    </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label7" runat="server" Text="Remark"></asp:Label>
                 
                            <asp:TextBox ID="txtRemark" CssClass="form-control" MaxLength="100" runat="server"></asp:TextBox>
                       </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="LblCode" runat="server" Text="Cash Account"></asp:Label>*
                     
                            <asp:TextBox ID="txtCode" MaxLength="15" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCode"
                                Display="Dynamic" ErrorMessage="You Should Select Invoice Code" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCode"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="acc1_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="30"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" /><br />
                            <asp:TextBox ID="txtName" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtName"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" OnClientItemSelected="acc1_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="30"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                      </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label10" runat="server" Text="Invoice Type"></asp:Label>
                   
                            <asp:RadioButtonList ID="rdoInvType" runat="server" RepeatColumns="2" CellPadding="2"
                                CellSpacing="2" AutoPostBack="True" OnSelectedIndexChanged="rdoInvType_SelectedIndexChanged">
                                <asp:ListItem Value="0" Selected="True">Cash</asp:ListItem>
                                <asp:ListItem Value="1">Credit</asp:ListItem>
                            </asp:RadioButtonList>
                       </div></div></div>
          
                <div class="table table-responsive table-hove text-center">
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" Width="100%" ForeColor="#333333"
                    ShowFooter="True" ViewStateMode="Enabled" GridLines="None" AutoGenerateColumns="False"
                    DataKeyNames="FNo" AllowPaging="True" PageSize="100" OnPageIndexChanging="grdCodes_PageIndexChanging"
                    OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowCommand="grdCodes_RowCommand"
                    OnRowDeleting="grdCodes_RowDeleting" OnRowEditing="grdCodes_RowEditing" OnRowUpdating="grdCodes_RowUpdating"
                    OnSelectedIndexChanging="grdCodes_SelectedIndexChanging" 
                    onselectedindexchanged="grdCodes_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="Delete Item"
                                    ImageUrl="~/images/cross.png" OnClientClick='<%# Eval("ItCode", "return confirm(\"Delete This Item {0} ...Are You Sure?\");") %>' />
                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="Select" ToolTip="Edit Item"
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
                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
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
                                <asp:TextBox ID="txtITName" Text='<%# Bind("ITName2") %>' autocomplete="off" runat="server" CssClass="form-control"  />
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtITName"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionStock2" MinimumPrefixLength="1"
                                    OnClientItemSelected="ace3_itemSelected" CompletionInterval="500" EnableCaching="true"
                                    CompletionSetCount="30" CompletionListCssClass="autocomplete_completionListElement"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtITName2" runat="server" autocomplete="off" CssClass="form-control"  />
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtITName2"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionStock2" MinimumPrefixLength="1"
                                    OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                    CompletionSetCount="30" CompletionListCssClass="autocomplete_completionListElement"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                            </FooterTemplate>
                            <ControlStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit" SortExpression="Unitname2" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblUnit" Text='<%# Bind("UnitName2") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlUnit" CssClass="form-control" EnableViewState="false" OnInit="ddlUnit2_Init" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlUnit2" CssClass="form-control" runat="server" OnInit="ddlUnit2_Init">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center" Width="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" SortExpression="Quan" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblQuan" Text='<%# Bind("Quan") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtQuan" Text='<%# Bind("Quan") %>' runat="server" CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtQuan2" runat="server" CssClass="form-control"></asp:TextBox>
                            </FooterTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center" Width="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" Text='<%# Bind("Price") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrice" Text='<%# Bind("Price") %>' runat="server" CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPrice2" runat="server" CssClass="form-control"></asp:TextBox>
                            </FooterTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center" Width="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblAmount2" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                            </EditItemTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center" Width="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bal" SortExpression="Bal" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblBal" Text='<%# Bind("Bal") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center" Width="75px"></ItemStyle>
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
                   
                        <asp:Label ID="lblTotalQty" runat="server" Text=""></asp:Label>
                 
                 
                        <asp:Label ID="Label4" runat="server" Text="Amount:"></asp:Label>
                 
                        <asp:Label ID="LblTotal" runat="server" Text=""></asp:Label>
                   
                        <asp:Label ID="Label5" runat="server" Text="Expenses:"></asp:Label>
                 
                        <asp:TextBox ID="txtExpAmount" CssClass="form-control"  runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="txtExpAmount"
                            Display="Dynamic" ErrorMessage="You Should Enter Numeric Value" ForeColor="Red"
                            Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                 </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                        <asp:Label ID="Label12" runat="server" Text="VAT 5%:"></asp:Label>
                 
                        <asp:TextBox ID="txtTax" CssClass="form-control"  runat="server" AutoPostBack="True" 
                            ontextchanged="txtTax_TextChanged"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator280" runat="server" ControlToValidate="txtTax"
                            Display="Dynamic" ErrorMessage="You Should Enter Numeric Value" ForeColor="Red"
                            Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
              </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                        <asp:Label ID="Label8" runat="server" Text="Expenses Reference:"></asp:Label>
                 
                        <asp:TextBox CssClass="form-control" ID="txtExpRef"  runat="server"></asp:TextBox>
              
                        <asp:Label ID="Label18" runat="server" Text="Total:"></asp:Label>
              
                        <asp:Label ID="LblTotNet" runat="server" CssClass="form-control" Text=""></asp:Label>
                  </div></div></div>
            <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                        <asp:Label ID="Label14" runat="server" Text="User Name"></asp:Label>
                 

                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" 
                            Enabled="false"></asp:TextBox>
                  </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                        <asp:Label ID="Label15" runat="server" Text="Date"></asp:Label>
                
                        <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" 
                            Enabled="false">                                                               
                        </asp:TextBox>
                        <asp:Label ID="Label27" runat="server" Text="* Required Fields"></asp:Label>
                  </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                   
                        <asp:ImageButton ID="BtnNew" runat="server" AlternateText="New" CommandName="New"
                            ImageUrl="~/images/data add.png" CssClass="ops" ToolTip="Add New Purchase Invoice"
                            ValidationGroup="1" OnClientClick='return confirm("Adding New Purchase Invoice...Are You Sure?")'
                            OnClick="BtnNew_Click" />
                        <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                            ImageUrl="~/images/edit2.png" CssClass="ops" ToolTip="Edit Purchase Invoice"
                            Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                        <asp:ImageButton ID="BtnClear" runat="server" AlternateText="Clear" CommandName="Clear"
                            ImageUrl="~/images/clear all.png" CssClass="ops" ToolTip="Clear Form Fields"
                            OnClick="BtnClear_Click" />
                        <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="Delete" CommandName="Delete"
                            ImageUrl="~/images/delete2.png" CssClass="ops" ToolTip="Delete Purchase Invoice"
                            OnClientClick='return confirm("Delete This Purchase Invoice...Are You Sure?")'
                            OnClick="BtnDelete_Click" />
                        <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="Find" CommandName="Find"
                            ImageUrl="~/images/data search.png" CssClass="ops" ToolTip="Search for Purchase Invoice"
                            OnClick="BtnSearch_Click" />
                        <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="Print" CommandName="Print"
                            ImageUrl="~/images/print.png" ValidationGroup="1" CssClass="ops" ToolTip="Print Purchase Invoice"
                            OnClick="BtnPrint_Click" />
                 </div></div></div>

                        <div class="col-md-12 col-sm-12 col-xm-12">
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
                   
                        <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                    ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label13"
                    ImageControlID="Image1" ExpandedText="(Hide Details)" CollapsedText="(Show Details)"
                    ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                    SuppressPostBack="true" />
                </asp:Panel>
                 <div class="form-row">
                   
                            <div class="form-group col-md-6 col-sm-12 col-xm-12">
                                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                            </div>
                            <div class="form-group col-md-6 col-sm-12 col-xm-12">
                                <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="Attach" CommandName="Attach"
                                    CssClass="ops" ImageUrl="~/images/attach1.png" ToolTip="Attach File" ValidationGroup="1"
                                    OnClick="BtnAttach_Click" />
                            </div>
            
                    </div>
                </asp:Panel>
                                </div>
                            </div>
                        </div>

           
        </div></div></div></div>
          </div>
</asp:Content>
