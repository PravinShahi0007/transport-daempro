<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebDailyTrackRep.aspx.cs" Inherits="ACC.WebDailyTrackRep" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
       <div class="ColorRounded4Corners col-md-12 col-sm-12 col-xs-12">
        <div class="box box-info" align="right">
            <div class="body">
                <div class="row">
   
   
                    <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                        الحركة اليومية للفرع</legend>
                   <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="الفرع"></asp:Label>
                       
                                <asp:DropDownList ID="ddlBranch" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlBranch_SelectedIndexChanged">                                  
                                </asp:DropDownList>
                   
                    
                                <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" 
                                    Text="اليوم" AutoPostBack="True" 
                                    oncheckedchanged="ChkPeriod_CheckedChanged" />       </div></div></div>   
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
                         </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                          
                               <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        
                                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"   
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                    
                                <asp:ImageButton ID="BtnExcel" Visible="false" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"  
                                    ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />

                           </div></div></div>
                                                      
                                                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                &nbsp;
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                          
                                <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                           
                               <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                          </div></div></div>
            
             <div class="table-responsive">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مرسل السيارة/العميل" SortExpression="Customer" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomer" Text='<%# Bind("Customer") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lbltot" Text="الاجمالي" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نوع السيارة" SortExpression="CarType" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCarType" Text='<%# Bind("CarType") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalCar" Text='<%# TotalCars %>'  runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="جهة الترحيل" SortExpression="Location" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" Text='<%# Bind("Location") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أتفاقية شحن" SortExpression="InvoiceNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblInvoiceNo" Text='<%# Eval("InvoiceNo") %>' NavigateUrl='<%# UrlHelper("1" ,Eval("InvoiceNo"))%>' Target="_blank" runat="server"></asp:HyperLink> 
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سند قبض" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblVouNo" Text='<%# Eval("VouNo") %>' NavigateUrl='<%# UrlHelper("2" ,Eval("VouNo"))%>' Target="_blank" runat="server"></asp:HyperLink> 
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="فروع" SortExpression="SiteAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSiteAmount" Text='<%# Eval("SiteAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalSiteAmount" Text='<%# TotalSiteAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نقدي" SortExpression="CashAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCashAmount" Text='<%# Eval("CashAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalCashAmount" Text='<%# TotalCashAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="شبكة" SortExpression="ShabakaAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblShabakaAmount" Text='<%# Eval("ShabakaAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalShabakaAmount" Text='<%# TotalShabakaAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="خصم شبكة" SortExpression="ShabakaDiscount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblShabakaDiscount" Text='<%# Eval("ShabakaDiscount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalShabakaDiscount" Text='<%# TotalShabakaDiscount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="آجل" SortExpression="CreditAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreditAmount" Text='<%# Eval("CreditAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalCreditAmount" Text='<%# TotalCreditAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عملاء" SortExpression="CustomerAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerAmount" Text='<%# Eval("CustomerAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalCustomerAmount" Text='<%# TotalCustomerAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الخصومات" SortExpression="DiscountAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscountAmount" Text='<%# Eval("DiscountAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalDiscountAmount" Text='<%# TotalDiscountAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الضريبة" SortExpression="VAT" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVAT" Text='<%# Eval("VAT","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalVAT" Text='<%# TotalVAT %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="قسيمة الايداع" SortExpression="DepositNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblDepositNo" Text='<%# Eval("DepositNo") %>' NavigateUrl='<%# UrlHelper("3" ,Eval("DepositNo"))%>' Target="_blank" runat="server"></asp:HyperLink> 
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="قيمة الايداع" SortExpression="DepositAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepositAmount" Text='<%# Eval("DepositAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalDepositAmount" Text='<%# TotalDepositAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="الرصيد بدون إيداع" SortExpression="DepositAmount2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepositAmount2" Text='<%# Eval("DepositAmount2","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalDepositAmount2" Text='<%# TotalDepositAmount2 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="رصيد العهدة" SortExpression="LoanAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLoanAmount" Text='<%# Eval("LoanAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalLoanAmount" Text='<%# TotalLoanAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="سند الصرف" SortExpression="PayNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblPayNo" Text='<%# Eval("PayNo") %>' NavigateUrl='<%# UrlHelper("4" ,Eval("PayNo"))%>' Target="_blank" runat="server"></asp:HyperLink> 
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="قيمة الصرف" SortExpression="PayAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPayAmount" Text='<%# Eval("PayAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalPayAmount" Text='<%# TotalPayAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="أستعاضة العهدة" SortExpression="PayAdd" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPayAdd" Text='<%# Eval("PayAdd","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalPayAdd" Text='<%# TotalPayAdd %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="بيان ترحيل" SortExpression="CarMoveNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblCarMoveNo" Text='<%# Eval("CarMoveNo") %>' NavigateUrl='<%# UrlHelper("5" ,Eval("CarMoveNo"))%>' Target="_blank" runat="server"></asp:HyperLink> 
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رصيد العهدة بعد" SortExpression="LoanAmount2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLoanAmount2" Text='<%# Eval("LoanAmount2","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalLoanAmount2" Text='<%# TotalLoanAmount2 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
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
              
        </div>
         <div class="card">
                <fieldset class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label1" CssClass="form-control" runat="server" Text="الرصيد المرحل"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblOldBal" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label11" runat="server" CssClass="form-control" Text="أجمالي الشبكة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblShabaka" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label8" runat="server" CssClass="form-control" Text="متحصلات نقدية"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblCash" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label14" runat="server" CssClass="form-control" Text="مصاريف الشبكة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblShabakaDiscount" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label12" CssClass="form-control" runat="server" Text="المجموع"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblTot" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label16" runat="server" CssClass="form-control" Text="صافي تحويلات الشبكة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblShabakaNet" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label5" runat="server" CssClass="form-control" Text="الرصيد النقدي"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblBal" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label17" runat="server" CssClass="form-control" Text="إجمالي الإيداعات"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:Label ID="lblNetDeposit" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label9" runat="server" CssClass="form-control" Text="العهدة اول الفترة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblLoan" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label3" runat="server" CssClass="form-control" Text="إجمالي الإيداعات والشبكة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblDeposit" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label13" runat="server" CssClass="form-control" Text="أجمالي الصرف"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblPay" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label7" runat="server" CssClass="form-control" Text="إجمالي الإيراد"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblIncome" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label15" runat="server" CssClass="form-control" Text="أستعاضة العهدة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblLoanAdd" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label10" runat="server" CssClass="form-control" Text="خصومات"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblDiscount" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label18" runat="server" CssClass="form-control" Text="العهدة أخر الفترة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblLoan2" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label19" runat="server" CssClass="form-control" Text="الضريبة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblVat2" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                    </div>
                </fieldset>
            </div>
  </div></div></div>
</asp:Content>
