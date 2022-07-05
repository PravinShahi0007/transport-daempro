<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebDetailsItemCard.aspx.cs" Inherits="ACC.WebDetailsItemCard" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function acc1_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtItemCode');
            var ace2Value = $get('ContentPlaceHolder1_txtITName');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
                    <h3 align="center">
                        حركة تفصيلية لصنف</h3>
                     <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                             
                         
                                <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                        
                                <asp:TextBox ID="txtFDate"  CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                         </div></div></div>
                         
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                         
                                <asp:TextBox ID="txtEDate"  CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server"
                                    ImageUrl="~/images/print.png" OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                                <asp:ImageButton ID="BtnExcel" Visible="false" runat="server" AlternateText="تصدير للإكسل"
                                    CommandName="Excel" ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير"
                                    OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnExcel_Click" />
                           

                              
                          
                              </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                              
                                <asp:DropDownList ID="ddlICat" Visible="false" CssClass="form-control"  runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlICat_SelectedIndexChanged">
                                </asp:DropDownList>
                        
                                <asp:RadioButtonList ID="rdoInVou" Width="100%" runat="server" 
                                    RepeatColumns="2" BorderColor="#CC0000" BorderStyle="Solid" 
                                    BorderWidth="1px" AutoPostBack="True" 
                                    onselectedindexchanged="rdoInVou_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">فاتورة مشتريات</asp:ListItem>
                                    <asp:ListItem Value="1">سند أضافة</asp:ListItem>
                                </asp:RadioButtonList>
                        
                        </div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:TextBox ID="txtItemCode" placeholder="كود الصنف" autocomplete="off" MaxLength="10"
                                    CssClass="form-control" Visible="false" runat="server" AutoPostBack="True" 
                                    ontextchanged="txtItemCode_TextChanged"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemCode"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionStock" OnClientItemSelected="acc1_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="30"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                         
                                <asp:TextBox ID="txtITName" placeholder="أسم الصنف" autocomplete="off" CssClass="form-control" Visible="false" runat="server" AutoPostBack="True" 
                                    ontextchanged="txtITName_TextChanged"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtITName"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionStock2" MinimumPrefixLength="1"
                                    OnClientItemSelected="acc1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                    CompletionSetCount="30" CompletionListCssClass="autocomplete_completionListElement"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                        </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                       <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />
                                <asp:CheckBox ID="ChkJob" runat="server" Checked="True" Text="جميع أوامر العمل" AutoPostBack="True"
                                    OnCheckedChanged="ChkJob_CheckedChanged" />
                            <asp:CheckBox ID="ChkICat" runat="server" Checked="True" Text="جميع الانواع" AutoPostBack="True"
                                    OnCheckedChanged="ChkICat_CheckedChanged" />
                                <asp:CheckBox ID="ChkItems" runat="server" Checked="True" Text="جميع الاصناف" AutoPostBack="True"
                                    OnCheckedChanged="ChkItems_CheckedChanged" />
                                <asp:DropDownList ID="ddlJob" Visible="false" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlJob_SelectedIndexChanged">
                                </asp:DropDownList>
                         
                                <asp:CheckBox ID="ChkCars" runat="server" Checked="True" Text="جميع الشاحنات" AutoPostBack="True"
                                    OnCheckedChanged="ChkCars_CheckedChanged" />
                        
                                <asp:DropDownList ID="ddlCar" Visible="false" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCar_SelectedIndexChanged">
                                </asp:DropDownList>
                          </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                         
                                <asp:DropDownList ID="ddlRecordsPerPage" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="-1">الكل</asp:ListItem>
                                </asp:DropDownList>
                          
                                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>&nbsp;
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                          </div></div></div>
               
                <div class="table-responsive table">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="المستند" SortExpression="FType2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFType2" Text='<%# Bind("FType2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="120px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الرقم" SortExpression="VouNo2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblVouNo2" Text='<%# Eval("VouNo2") %>' NavigateUrl='<%# UrlHelper(Eval("FType") ,Eval("VouNo2"))%>'
                                        Target="_blank" runat="server"></asp:HyperLink>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="VouDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVouDate" Text='<%# Eval("VouDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalVouDate" Text="الاجمالي" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الصنف" SortExpression="ITCode" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblITCode" Text='<%# Eval("ITCode") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوصف عربي" SortExpression="ITName1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblITName1" Text='<%# Eval("ITName1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاستلام" SortExpression="Quan2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuan2" Text='<%# Eval("Quan2","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalQuan2" Text='<%# TotalQuan2 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الصرف" SortExpression="Quan" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuan" Text='<%# Eval("Quan","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalQuan" Text='<%# TotalQuan %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الرصيد" SortExpression="Bal" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBal" Text='<%# Eval("Bal","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="السعر" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" Text='<%# Eval("Price") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="قيمة الصرف" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" Text='<%# Eval("Amount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAmount" Text='<%# TotalAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="قيمة الاستلام" SortExpression="Amount2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount2" Text='<%# Eval("Amount2","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAmount2" Text='<%# TotalAmount2 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ملاحظات" SortExpression="Remark" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" Text='<%# Eval("Remark") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalRemark" Text='<%# TotalRemark %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="120px" />
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
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                </div></div></div></div></div>
</asp:Content>
