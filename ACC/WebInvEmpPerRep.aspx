<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebInvEmpPerRep.aspx.cs" Inherits="ACC.WebInvEmpPerRep" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card col-md-12 col-sm-12 col-xs-12">
        <div class="card-header"><h4 class="card-title">
                        معدل أداء موظف الفرع
                        </h4></div>
        <div class="box box-info card-body" align="right">
            <div class="body">
                <div class="row">
             
                    
             <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="الموظف"></asp:Label>
                     

                                <asp:DropDownList ID="ddlEmp" runat="server" CssClass="form-control" AutoPostBack="True" 
                                    onselectedindexchanged="ddlEmp_SelectedIndexChanged">
                                </asp:DropDownList>  </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">

                                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                      ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server"
                                    ImageUrl="~/images/print.png"   OnCommand="BtnPrint1_Command"
                                    OnClientClick="aspnetForm.target ='_blank';" />
                                <asp:ImageButton ID="BtnExcel" Visible="false" runat="server" AlternateText="تصدير للإكسل"
                                    CommandName="Excel"   ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير"
                                    OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnExcel_Click" />
                         

                                <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />
                        </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                      
                                <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" 
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
                         

                                <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
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
                            <asp:TemplateField HeaderText="أتفاقية شحن" SortExpression="InvoiceNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblInvoiceNo" Text='<%# Eval("InvNo2") %>' NavigateUrl='<%# UrlHelper("1" ,Eval("InvNo2"))%>'
                                        Target="_blank" runat="server"></asp:HyperLink>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="GDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblGDate" Text='<%# Eval("GDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalGDate" Text="الاجمالي" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نقدي" SortExpression="CashAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCashAmount" Text='<%# Eval("CashAmount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalCashAmount" Text='<%# TotalCashAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="فروع" SortExpression="SiteAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSiteAmount" Text='<%# Eval("SiteAmount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalSiteAmount" Text='<%# TotalSiteAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عملاء" SortExpression="CustomerAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerAmount" Text='<%# Eval("CustomerAmount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalCustomerAmount" Text='<%# TotalCustomerAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="اجمالي الاتفاقية" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" Text='<%# Eval("Amount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAmount" Text='<%# TotalAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الحد الادنى" SortExpression="LowAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLowAmount" Text='<%# Eval("LowAmount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalLowAmount" Text='<%# TotalLowAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="هامش الخصم" SortExpression="Net" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblNet" Text='<%# Eval("Net","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalNet" Text='<%# TotalNet %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الفرع" SortExpression="SiteName" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSiteName" Text='<%# Eval("SiteName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="العميل" SortExpression="CustomerName" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerName" Text='<%# Eval("CustomerName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المستلم" SortExpression="RecName" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRecName" Text='<%# Eval("RecName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
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
               </div></div></div></div>
</asp:Content>
