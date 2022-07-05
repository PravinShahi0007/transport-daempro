<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebPPO.aspx.cs" Inherits="ACC.WebPPO" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <!--*************************************Ankur Kumar******************************************************-->
   
        <div class="card">
            <fieldset class="card-body">
                <div class="form-group text-center">
                    <asp:Label ID="lblHead" runat="server" Text="[ طلب شراء مواد ]"></asp:Label>
                </div>
                <div class="form-row">
                    <div class="form-group col-sm-2">
                        <asp:Label ID="Label1" runat="server" Text="رقم الطلب"></asp:Label>
                                *
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>
                                *
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:TextBox ID="txtVouDate" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  ControlToValidate="txtVouDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                    </div>
                    <div class="form-group col-sm-3">
                        <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-1">
                        <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/search3.png"
                                    ToolTip="البحث عن بيانات الطلب" OnClick="BtnFind_Click" />
                    </div>
                </div>
             
                   
                                <div id="divGrid" runat="server" class="table table-responsive text-center table-hover" style="background-image: linear-gradient(to right, #185fb2 , #f97d29);">
                                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" AllowPaging="false"
                                        Width="100%" EmptyDataText="لا توجد بيانات" OnRowCancelingEdit="grdCodes_RowCancelingEdit"
                                        OnRowCommand="grdCodes_RowCommand" OnRowDeleting="grdCodes_RowDeleting">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            
                                            <asp:TemplateField HeaderText="الحاله" SortExpression="Approved" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="ddlApproved" CssClass="form-control" SelectedValue='<%# Bind("Approved") %>' Enabled="false" AutoPostBack="true" runat="server" 
                                                        onselectedindexchanged="ddlApproved_SelectedIndexChanged">
                                                        <asp:ListItem Text="معلق" Value="0"> </asp:ListItem>
                                                        <asp:ListItem Text="موافق" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="مرفوض" Value="2"></asp:ListItem>
                                                        <%--<asp:ListItem Text="سدد" Value="3"></asp:ListItem>--%>                                                    
                                                     </asp:DropDownList>
                                                    </div>
                                                    
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="ddlApproved2" Enabled="false" AutoPostBack="true" ToolTip="تحديد حالة جميع الطلبات" CssClass="form-control" runat="server" onselectedindexchanged="ddlApproved2_SelectedIndexChanged">
                                                        <asp:ListItem Text="معلق" Value="0" > </asp:ListItem>
                                                        <asp:ListItem Text="موافق" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="مرفوض" Value="2"></asp:ListItem>
                                                        <%--<asp:ListItem Text="سدد" Value="3"></asp:ListItem>--%>
                                                    </asp:DropDownList>  
                                                    </div>
                                                                                                  
                                                </FooterTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="تسلسل" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="form-group">
                                                        <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                                    </div>
                                                    
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="البند" SortExpression="Item" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="form-group"></div>
                                                    <asp:Label ID="lblItem" Text='<%# Bind("Item") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtItem" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    
                                                </FooterTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="السعر الأفرادي" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="form-group">
                                                        <asp:Label ID="lblPrice" Text='<%# Eval("Price","{0:N2}") %>' runat="server"></asp:Label>
                                                    </div>
                                                    
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                     <div class="form-group">
                                                         <asp:TextBox ID="txtPrice" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                                                     </div>
                                                    
                                                </FooterTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الكمية" SortExpression="Qty" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                     <div class="form-group">
                                                         <asp:Label ID="lblQty" Text='<%# Eval("Qty","{0:N2}") %>' runat="server"></asp:Label>
                                                     </div>
                                                    
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                     <div class="form-group">
                                                         <asp:TextBox ID="txtQty" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                                                     </div>
                                                    
                                                </FooterTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="القيمة" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                     <div class="form-group">
                                                         <asp:Label ID="lblAmount" Text='<%# Eval("Amount","{0:N2}") %>' runat="server"></asp:Label>
                                                     </div>
                                                    
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                     <div class="form-group">
                                                         <asp:Label ID="lblAmount2" runat="server"></asp:Label>
                                                     </div>
                                                    
                                                </FooterTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="form-group">
                                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                                    </div>
                                                    
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <div class="form-group">
                                                        <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="اضافة بند جديد"
                                                        ImageUrl="~/images/add.png" />
                                                    </div>
                                                    
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                            HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" 
                                            BorderColor="#C7C7C7" />
                                        <HeaderStyle Font-Bold="True" ForeColor="White" />
                                        <PagerStyle ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </div>
                        <br />

                        <!--******************************************ANKUR KUMAR******************************************************-->
                            <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label28" runat="server" Text="الاجمالي المعتمد"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:TextBox ID="txtAmount2" MaxLength="15" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label4" runat="server" Text="الاجمالي"></asp:Label>
                        </div>
                        <div class="form-group col-sm-4">
                            <asp:TextBox ID="txtAmount" MaxLength="15" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2"></div>
                    </div>

                    <div class="form-row" id="Table2">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                        </div>
                    </div>
                
                    <div class="form-row">
                        <div class="form-group col-sm-6">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        </div>
                        <div class="form-group col-sm-6">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                        </div>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-4"></div>
                        <div class="form-group col-sm-4">
                            <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png"   ToolTip="أضافة طلب جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الطلب؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png"   ToolTip="تعديل بيانات الطلب"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png"   ToolTip="إلغاء بيانات الطلب" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات الطلب؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png"   ToolTip="البحث عن بيانات الطلب"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print.png" ValidationGroup="1"   ToolTip="طباعة الطلب"
                                    OnClick="BtnPrint_Click" />
                        </div>
                        <div class="form-group col-sm-4"></div>
                    </div>
                    <br />
                    <br />
                    
                   <div class="row">
                    <div class="col-md-12 col-sm-12 col-xm-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">
                                    <asp:Label ID="Label13" runat="server">(عرض التفاصيل)</asp:Label>
                                     المرفقات
                                </h4>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body" style="display: none;">
                         <asp:Panel ID="Panel2" runat="server">
                        <%--<div class="form-row">
                            <div class="form-group col-sm-1">
                               <%-- <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                            --%>
                            <%--<div class="form-group col-sm-2">
                               
                            </div>
                            <div class="form-group col-sm-2">
                                
                            </div>
                            <div class="form-group col-sm-7"></div>
                        </div>--%>
                <asp:Panel ID="Panel1" runat="server"
                        BorderColor="Maroon">
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                            OnRowDeleting="grdAttach_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="form-group">
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء الملف"
                                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء الملف؟")' />
                                        </div>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الملف" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-group">

                                        </div><asp:HyperLink ID="lblFileName" Text='<%# Bind("FileName") %>' NavigateUrl='<%# Bind("FileName2") %>'
                                            Target="_blank" runat="server"></asp:HyperLink>
                                        
                                    </ItemTemplate>
       
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="White" HorizontalAlign="Center" />
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
                        
                       
                    </asp:Panel>
                <div class="form-row">
                            <div class="form-group col-sm-6">
                                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                            </div>
                            <div class="form-group col-sm-6">
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
        </div>
   
</asp:Content>
