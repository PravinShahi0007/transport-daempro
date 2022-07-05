<%@ Page Title="بيان مصروفات نثرية" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebPettyCash.aspx.cs" Inherits="ACC.WebPettyCash" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div class="card">
            <fieldset>
                <div class="card-header"><h4 class="card-title">
                    <asp:Label ID="lblHead" runat="server" Text="[بيان مصروفات نثرية]"></asp:Label>
                </h4></div>
                <div class="card-body">
                        <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                  <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="رقم البيان"></asp:Label>
                              
                        
                                <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"   ></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                         </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>
                            
                        
                                <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ السند" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                         
                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="70px" placeholder="بحث" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات البيان" OnClick="BtnFind_Click" />
                          </div></div></div>
                  <div class="table table-responsive table-hover text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" 
                        AllowPaging="false" Width="99.9%" OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowCommand="grdCodes_RowCommand"
                        OnRowDeleting="grdCodes_RowDeleting">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ValidationGroup="2" ToolTip="أضافة بند جديد"
                                        ImageUrl="~/images/add.png" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المصروف" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode2" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlCode" runat="server" CssClass="form-control" OnInit="ddlCode_Init"/>
                                </FooterTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ملاحظات" SortExpression="Remark" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" Text='<%# Bind("Remark") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtRemark" MaxLength="100" runat="server" CssClass="form-control" ></asp:TextBox>
                                </FooterTemplate>
                                <ControlStyle Width="150px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المبلغ بدون الضريبة" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtAmount2" MaxLength="15" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ValAmount2" runat="server" ControlToValidate="txtAmount2"
                                        Display="Dynamic" ErrorMessage="يجب أدخال المبلغ" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="2">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="ValAmount20" runat="server" ControlToValidate="txtAmount2"
                                        ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                        Display="Dynamic" Type="Currency" ValidationGroup="2" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </FooterTemplate>
                                <ControlStyle Width="100px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الضريبة" SortExpression="Tax" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTax" Text='<%# Bind("Tax") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtTax2" MaxLength="15" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:CompareValidator ID="ValTax2" runat="server" ControlToValidate="txtTax2"
                                        ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                        Display="Dynamic" Type="Currency" ValidationGroup="2" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </FooterTemplate>
                                <ControlStyle Width="100px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الفاتورة" SortExpression="InvNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvNo" Text='<%# Bind("InvNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtInvNo2" runat="server" MaxLength="20" CssClass="form-control" />
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFDate2" runat="server" MaxLength="10" CssClass="form-control" />
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

                  <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="lblStatus" runat="server"  CssClass="blink" ForeColor="Red" Text=""></asp:Label>     
                            </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label12" runat="server" Text="الاجمالي"></asp:Label>                                
                         
                                <asp:TextBox ID="txtTotal" ReadOnly="true" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                            </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label3" runat="server" Text="ملاحظات"></asp:Label>                               
                            
                                    <asp:TextBox ID="txtRemark2" MaxLength="800" TextMode="MultiLine" CssClass="form-control" Height="100px" runat="server"></asp:TextBox>
                           </div></div></div>
                   
                   <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                           
                                <asp:TextBox ID="txtUserName"  runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop form-control"
                                    Enabled="false"></asp:TextBox>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                          
                                <asp:TextBox ID="txtUserDate"  runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop form-control"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>
                          
                                <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="10">*</asp:RequiredFieldValidator>
                         </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                         </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png"   ToolTip="أضافة سند جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات البيان؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png"   ToolTip="تعديل بيانات البيان" OnClientClick="return Validate()"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete" ValidationGroup="1"
                                    ImageUrl="~/images/delete2.png"   ToolTip="إلغاء بيانات البيان" OnClientClick="return Validate2()"
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png"   ToolTip="البحث عن بيانات البيان"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print.png" ValidationGroup="1"   ToolTip="طباعة البيان"
                                    OnClick="BtnPrint_Click" />
                         </div></div></div>
                        <br />
                <div class="col-md-12 col-sm-12 col-xs-12">
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
                        <div class="card-body" style="display:none;">
                    <asp:Panel ID="Panel2" runat="server">
                       <asp:Panel ID="Panel1" runat="server">
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
                        </asp:GridView>
                   
                           <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
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
          
      
          <br />
          <br />
                        <div class="col-md-12 col-sm-12 col-xs-12">
             <div class="card">                                
            <fieldset>
                <div class="card-header">
                    <h4 class="card-title">
                        <asp:Literal ID="lblManage1" runat="server" Text="<b>[  أعتماد مدير التشغيل ]</b>" ></asp:Literal>
                    </h4>
                </div>
              <div class="card-body">
                  <div class="form-row">
                      <div class="form-group col-md-2 col-sm-12 col-xs-12">
                          <asp:Label ID="lblRemark9" runat="server" Text="ملاحظات"></asp:Label>
                      </div>
                      <div class="form-group col-md-6 col-sm-12 col-xs-12">
                          <asp:TextBox ID="txtAgreeRemark1" MaxLength="100" TextMode="MultiLine" CssClass="form-control" Height="100px" runat="server"></asp:TextBox>
                      </div>
                      <div class="form-group col-md-2 col-sm-12 col-xs-12">
                          <asp:CheckBox ID="chkAgree1" runat="server" Text="تم الأعتماد" 
                                            oncheckedchanged="chkAgree1_CheckedChanged" AutoPostBack="True" />
                      </div>
                      <div class="form-group col-md-2 col-sm-12 col-xs-12">
                          <asp:ImageButton ID="BtnAgree1" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1" CssClass="ops"
                                            OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")' />
                                        <asp:ImageButton ID="BtnDisagree1" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1" 
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' />
                      </div>
                      
                  </div>
                  <div class="form-row">
                      <div class="form-group col-md-2 col-sm-12 col-xs-12">
                          <asp:Label ID="lblAgreeUser" runat="server" Text="المستخدم"></asp:Label>
                      </div>
                      <div class="form-group col-md-4 col-sm-12 col-xs-12">
                          <asp:TextBox ID="txtAgreeUser1" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                      </div>
                      <div class="form-group col-md-2 col-sm-12 col-xs-12">
                          <asp:Label ID="lblAgreeUserDate" runat="server" Text="تاريخ التعميد"></asp:Label>
                      </div>
                      <div class="form-group col-md-4 col-sm-12 col-xs-12">
                          <asp:TextBox ID="txtAgreeUserDate1" runat="server" CssClass="form-control" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                      </div>
                  </div>
              </div>

            </fieldset>
            </div>
                            </div>
          <br />
                <div class="col-md-12 col-sm-12 col-xs-12">
                      <div class="card">
            <fieldset>
              <div class="card-header">
                    <h4 class="card-title">[  أعتماد الحسابات ]</h4></div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="Label4" runat="server" Text="ملاحظات"></asp:Label>
                        </div>
                        <div class="form-group col-md-6 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAgreeRemark2" MaxLength="100" TextMode="MultiLine" CssClass="form-control" Height="100px" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:CheckBox ID="chkAgree2" runat="server" Text="تم الأعتماد" 
                                            oncheckedchanged="chkAgree2_CheckedChanged" AutoPostBack="True" />
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12"></div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                        </div>
                        <div class="form-group col-md-4 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAgreeUser2" CssClass="form-control"  runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="Label6" runat="server" Text="تاريخ التعميد"></asp:Label>
                        </div>
                        <div class="form-group col-md-4 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAgreeUserDate2" runat="server" CssClass="form-control" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </fieldset>            
        </div>   
                </div>
                             
<br />
       <div class="col-md-12 col-sm-12 col-xs-12">   
             <div class="card">
            <fieldset>
              <div class="card-header">
                    <h4 class="card-title">[  أعتماد الإدارة المالية ]</h4></div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="Label51" runat="server" Text="ملاحظات"></asp:Label>
                        </div>
                        <div class="form-group col-md-6 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAgreeRemark3" MaxLength="100" TextMode="MultiLine" CssClass="form-control" Height="100px" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:CheckBox ID="chkAgree3" runat="server" Text="تم الأعتماد" 
                                            oncheckedchanged="chkAgree3_CheckedChanged" AutoPostBack="True" />
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12"></div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="Label52" runat="server" Text="المستخدم"></asp:Label>
                        </div>
                        <div class="form-group col-md-4 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAgreeUser3" CssClass="form-control"  runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="Label53" runat="server" Text="تاريخ التعميد"></asp:Label>
                        </div>
                        <div class="form-group col-md-4 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtAgreeUserDate3" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </fieldset>            
        </div>
           </div>
       </div></div></div>  
                </div>
                
  </fieldset>
        </div>
</asp:Content>
