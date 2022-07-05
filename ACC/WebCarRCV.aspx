<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCarRCV.aspx.cs" Inherits="ACC.WebCarRCV" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        
            <fieldset class="card">
                <div class="card-header">
                    <!--editing by chanda verma-->
                    <h4 class="card-title">
                    <asp:Label ID="lblHead" runat="server" Text="[ سند أستلام سيارة ]"></asp:Label>
                </h4>

                </div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:Label ID="Label1" runat="server" Text="رقم السند"></asp:Label>
                                *
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:TextBox ID="txtVouNo" MaxLength="10" Enabled="false" CssClass="MouseStop form-control" runat="server"></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>*
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="txtVouDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:CheckBox ID="ChkDeleteInv" runat="server" Text="الغاء فاتورة"/>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:Label ID="Label6" runat="server" Text="وقت التسليم"></asp:Label> *
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:TextBox ID="txtGTime" MaxLength="10" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGTime"
                                    Display="Dynamic" ErrorMessage="يجب أختيار وقت السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:Label ID="Label9" runat="server" Text="أسم المستلم"></asp:Label>*
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                             <asp:TextBox ID="txtCustomer" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCustomer"
                                    Display="Dynamic" ErrorMessage="يجب أدخال أسم المستلم" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                     <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xm-12">
                            <asp:Label ID="Label16" runat="server" Text="ملاحظات"></asp:Label>
                        </div>
                        <div class="form-group col-md-6 col-sm-12 col-xm-12">
                            <asp:TextBox ID="txtRemark" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        
                        <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                    </div>
                    <div class="table table-responsive table-hover">
                        <div class="form-group">
                            
                                <div id="divGrid" runat="server">
                                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                        Width="100%" EmptyDataText="لا توجد بيانات" OnRowCancelingEdit="grdCodes_RowCancelingEdit"
                                        OnRowCommand="grdCodes_RowCommand" OnRowDeleting="grdCodes_RowDeleting">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="اضافة بند جديد"
                                                        ImageUrl="~/images/add.png" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="رقم الفاتورة" SortExpression="InvNo" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink2" Text='<%# Bind("InvNo") %>' NavigateUrl='<%# UrlHelper(Eval("InvNo"))%>'
                                                        Target="_blank" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtVouNo" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="رقم اللوحة أو الهيكل" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="العميل" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="200px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="جهة الترحيل" SortExpression="DestinationName1" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDestinationName" Text='<%# Bind("DestinationName1") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                            HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" 
                                            BorderColor="#C7C7C7" />
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
                        <div class="form-group col-md-12 col-sm-12 col-xm-12">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />

                        </div>
                        
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12 col-sm-12 col-xm-12">
                                                            <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png"   ToolTip="أضافة سند جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السند؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png"   ToolTip="تعديل بيانات السند"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png"   ToolTip="إلغاء بيانات السند" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات السند؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png"   ToolTip="البحث عن بيانات السند"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print.png" ValidationGroup="1"   ToolTip="طباعة السند"
                                    OnClick="BtnPrint_Click" />
                        </div>
                       
                    </div>
                    
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12 col-sm-12 col-xm-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">
                                    المرفقات<asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                </h4>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                        
                <div class="card-body" style="display:none;">
                    <asp:Panel ID="Panel2" runat="server">
                        <%--<div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                                </div>
                            <div style="float: right; margin-right: 20px;">
                               
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                            </div>
                        </div>--%>
                        <asp:Panel ID="Panel1" runat="server">
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                            Width="100%" OnRowDeleting="grdAttach_RowDeleting">
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
                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label13"
                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                        <%--<table width="100%">
                            <tr>
                                <td align="right">
                                    
                                </td>
                                <td align="left">
                                  
                                </td>
                            </tr>
                        </table>--%>
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
            </fieldset>
        
</asp:Content>