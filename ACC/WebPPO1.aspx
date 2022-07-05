<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebPPO1.aspx.cs" Inherits="ACC.WebPPO1" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function CallMe(src, no1) {            
                var ctrl = document.getElementById(src);
                // call server side method
                PageMethods.GetDate(ctrl.value, CallSuccess, CallFailed, no1);
            }
            // set the destination textbox value with the ContactName
            function CallSuccess(res, no1) {
                var dest = document.getElementById(no1[0]);
                var dest2 = document.getElementById(no1[1]);
                dest.value = res[0];
                dest2.value = res[1];
                if (dest.value != '') {
                    dest.readOnly = true;
                }
                else {
                    dest.readOnly = false;
                }
            }
            // alert message on some failure
            function CallFailed(res, destCtrl) {
                alert(res.get_message());
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
                <h3 align="center">
                    <asp:Label ID="lblHead" runat="server" Text="[ طلب دفع ]"></asp:Label>
              </h3>
                <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                     <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="رقم الطلب"></asp:Label>
                              
                                <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>
                             
                                <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
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
                          </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                      <asp:Label ID="lblStatus" runat="server"  CssClass="blink" ForeColor="Red" Text=""></asp:Label>                                
                          
                               <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات الطلب" OnClick="BtnFind_Click" />
                             </div></div></div>
                      
                               
                                <div id="divGrid" runat="server"  class="table table-responsive">
                                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                        Width="99.5%" EmptyDataText="لا توجد بيانات" OnRowCancelingEdit="grdCodes_RowCancelingEdit"
                                        OnRowCommand="grdCodes_RowCommand" OnRowDeleting="grdCodes_RowDeleting">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="الحاله" SortExpression="Approved" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlApproved" SelectedValue='<%# Bind("Approved") %>' Enabled="false" CssClass="form-control" AutoPostBack="true" runat="server" onselectedindexchanged="ddlApproved_SelectedIndexChanged">
                                                        <asp:ListItem Text="معلق" Value="0" > </asp:ListItem>
                                                        <asp:ListItem Text="موافق" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="مرفوض" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="سدد" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlApproved2" Enabled="false" AutoPostBack="true" CssClass="form-control" ToolTip="تحديد حالة جميع الطلبات" runat="server" onselectedindexchanged="ddlApproved2_SelectedIndexChanged">
                                                        <asp:ListItem Text="معلق" Value="0" > </asp:ListItem>
                                                        <asp:ListItem Text="موافق" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="مرفوض" Value="2"></asp:ListItem>
                                                        <%--<asp:ListItem Text="سدد" Value="3"></asp:ListItem>--%>
                                                    </asp:DropDownList>                                                
                                                </FooterTemplate>
                                                <ControlStyle Width="65px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="تسلسل" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="50px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="سند الصرف" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lblVouNo" Text='<%# Eval("VouNo") %>' NavigateUrl='<%# UrlHelper("1" ,Eval("VouNo"))%>' Target="_blank" runat="server"></asp:HyperLink> 
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtVouNo2" MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="البند" SortExpression="Item" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItem" Text='<%# Bind("Item") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtItem" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                                <ControlStyle Width="400px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="المبلغ" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrice" Text='<%# Eval("Price","{0:N2}") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPrice" MaxLength="20" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
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
                              <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label28" runat="server" Text="الاجمالي المعتمد"></asp:Label>
                         
                                <asp:TextBox ID="txtAmount2" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div></div></div>
                            <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="الاجمالي"></asp:Label>
                                <asp:TextBox ID="txtAmount" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                          </div></div></div>
                            <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                          
                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" 
                                    Enabled="false"></asp:TextBox>
                          </div></div></div>
                            <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                         
                                <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" 
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                    </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                    </div>
                                    </div>
                                    </div>
                        <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                                    </div>
                                    </div>
                                    </div>
                            <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                
                          
                                
                         
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                           
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
                                    ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات الطلب" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات الطلب؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png"   ToolTip="البحث عن بيانات الطلب"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print.png" ValidationGroup="1"   ToolTip="طباعة الطلب"
                                    OnClick="BtnPrint_Click" />
                           </div></div></div>
             <div class="col-md-12 col-sm-12 col-xs-12">
                 <div class="card">
                     <div class="card-header">
                         <h4 class="card-title">
                             المرفقات
                             <asp:Label ID="Label13" runat="server">(عرض التفاصيل)</asp:Label>
                         </h4>
                         <div class="card-tools">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                            <i class="fas fa-minus"></i>
                                        </button>
                                    </div>
                     </div>
                     <!--************************************************Ankur Kumar**********************************-->
                     <div class="card-body" style="display:none;">
                         <asp:Panel ID="Panel2" runat="server">
                        <asp:Panel ID="Panel1" runat="server" >
                        <div class="table table-responsive">
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                            Width="99%" OnRowDeleting="grdAttach_RowDeleting">
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
                        </asp:GridView></div>
                       
                            <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label13"
                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                    </asp:Panel>
                     
                            <div class="form-row">                                
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
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
</div></div></div>
</asp:Content>
