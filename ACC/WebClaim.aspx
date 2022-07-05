<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebClaim.aspx.cs" Inherits="ACC.WebClaim" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="card">
            <fieldset>
                <div class="card-header"><h4 class="card-title">
                    <asp:Label ID="lblHead" runat="server" Text="[ المطالبة المالية ]"></asp:Label>
                </h4></div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-2 col-sm-12 col-xm-12">
                             <asp:Label ID="Label1" runat="server" Text="رقم المطالبة"></asp:Label>
                                *
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtDocNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDocNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم المطالبة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xm-12">
                            <asp:Label ID="Label2" runat="server" Text="تاريخ المطالبة"></asp:Label>
                                *
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtDocDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDocDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ المطالبة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtDocDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtDocDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات المطالبة المالية" OnClick="BtnFind_Click" />
                        </div>
                        
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-2 col-sm-12 col-xm-12">
                            <asp:Label ID="Label4" runat="server" Text="حساب العميل*"></asp:Label>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xm-12">
                             <asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCustomer"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب العميل" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xm-12">
                            <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" 
                                    Text="جميع الفترات" AutoPostBack="True" 
                                    oncheckedchanged="ChkPeriod_CheckedChanged" />
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xm-12">
                            <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xm-12"></div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:Label ID="Label3" runat="server" Text="أسم الجهة*"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtCustomer" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCustomer"
                                    Display="Dynamic" ErrorMessage="يجب أختيار الجهة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"   
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <a id="BtnPay" runat="server" target="_blank" href="~/WebRVou1.aspx?FType=1&AreaNo=0&StoreNo=0"><img alt="تحصيل" src='images/Pay_642.png'/></a>

                        </div>
                        <div class="form-group col-md-9 col-sm-12 col-xm-12"></div>
                      
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-9 col-sm-12 col-xm-12"></div>
                     
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:Label ID="lblStatus" runat="server"  CssClass="blink" ForeColor="Red" Text=""></asp:Label>

                        </div>
                    </div>
                       <div class="form-row table-responsive text-center">
                           <div class="form-group col-md-12 col-sm-12 col-xm-12">
                                  <asp:GridView ID="grdCodes" runat="server" CellPadding="4" Width="100%" ForeColor="#333333"
                            ShowFooter="True" ViewStateMode="Enabled" GridLines="None" AutoGenerateColumns="False"
                            DataKeyNames="Fno" PageSize="250" AllowPaging="false">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="" SortExpression="State" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                         <asp:CheckBox ID="ChkState2" runat="server" Checked='<%# Chkall %>' AutoPostBack="true" oncheckedchanged="ChkState2_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkState" Checked='<%# Bind("State") %>' runat="server" AutoPostBack="true"
                                            oncheckedchanged="ChkState_CheckedChanged" />
                                    </ItemTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="أتفاقية الشحن" SortExpression="InvNo2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                       <asp:HyperLink ID="lblVouNo" Text='<%# Bind("InvNo2") %>' NavigateUrl='<%# UrlHelper(Eval("InvNo2").ToString())%>' ToolTip="عرض الفاتورة" Target="_blank" runat="server"></asp:HyperLink>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التاريخ" SortExpression="DocDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocDate" Text='<%# Bind("DocDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTot2" Text='الاجمالي' runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <ControlStyle Width="90px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المبلغ" SortExpression="Amount0" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" Text='<%# Eval("Amount0","{0:N2}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTot" Text='<%# Bind("Tot") %>' runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الضريبة" SortExpression="Tax" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTax" Text='<%# Eval("Tax","{0:N2}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotTax" Text='<%# Bind("TotTax") %>' runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عدد السيارات" SortExpression="Qty" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" Text='<%# Bind("Qty") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotQty" Text='<%# Bind("TotQty") %>' runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <ControlStyle Width="90px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من - إلى" SortExpression="Source" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSource" Text='<%# Eval("Source").ToString() + " - " + Eval("Destination").ToString() %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المرجع" SortExpression="Ref" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRef" Text='<%# Bind("Ref") %>' MaxLength="30" CssClass="form-control"
                                            runat="server" AutoPostBack="True" ontextchanged="txtRef_TextChanged"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
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
                           </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                              <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                        </div>

                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>

                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6 col-sm-12 col-xm-12">
                             <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        </div>
                        <div class="form-group col-md-6 col-sm-12 col-xm-12">
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />

                        </div>
                        
                    </div>
                     <div class="form-row text-center">
                        <div class="form-group col-md-12 col-sm-12 col-xm-12">
                             <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png" ToolTip="أضافة مطالبة جديدة" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات المطالبة؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات المطالبة"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ValidationGroup="1" ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات المطالبة"
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات المطالبة" OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print.png" ValidationGroup="1" ToolTip="طباعة التحويل"
                                    OnClick="BtnPrint_Click" />
                        </div>
                        
                        
                    </div>
                    <div class="form-row table-responsive text-center">
                        <div class="form-group col-md-12 col-sm-12 col-xm-12">
                            <asp:GridView ID="grdList" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="DocNo" AllowPaging="True"
                            PageSize="30" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdList_PageIndexChanging"
                            OnSelectedIndexChanging="grdList_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات المطالبة"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم المطالبة" SortExpression="DocNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocNo" Text='<%# Bind("DocNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التاريخ" SortExpression="DocDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocDate" Text='<%# Bind("DocDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الاسم" SortExpression="Customer" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomer" Text='<%# Bind("Customer") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="350px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من تاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى تاريخ" SortExpression="EDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEDate" Text='<%# Bind("EDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
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
                        </div>
                  <%--  <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                    </div>--%>
                </div>
                    
                      
                    <!--editing by chanda verma-->
                <div class="form-row">
                    <div class="form-group col-md-12 col-sm-12 col-xm-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">
                                    المرفقات
                                     <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                </h4>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body" style="display: none;">
                                <!--editing by chanda verma-->
                                 <asp:Panel ID="Panel2" runat="server">
                       <asp:Panel ID="Panel1" runat="server">
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
                            <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                        
                    </asp:Panel>
                                     <div class="form-row">
                                        <div class="col-sm-6">
                                             <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>
                                        <div class="col-sm-6">
                                           <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                        ValidationGroup="1" />
                                        </div>
                                    </div>
                    </asp:Panel>
                                </div>
                                </div>
                                </div>
                                </div>

                
                   
                    
                   
                </div>
            
    
</asp:Content>