<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebOffers.aspx.cs" Inherits="ACC.WebOffers" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
       <div class="card col-md-12 col-sm-12 col-xs-12">
        <div class="box box-info" align="right">
            <div class="body">
                <div class="row">
   
          
                <legend id="leg1" runat="server" align="center" style="font-size: 18px; color: #800000;
                    text-align: center;"><b>
                        <asp:Literal ID="Literal2" Text="[العروض الخاصة و المواسم]" runat="server"></asp:Literal></b></legend>
              
                 <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="LblOfferNo" runat="server" Text="كود العرض*"></asp:Label>
                           
                                <asp:TextBox ID="txtPromoCode" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات عرض" OnClick="BtnSearch_Click" />
                                <asp:RequiredFieldValidator ID="ValOfferNo" runat="server" ControlToValidate="txtPromoCode"
                                    ErrorMessage="يجب إدخال كود العرض" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtOfferNo" Visible="false" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        
                                
                          </div></div></div>
                    
                    <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <br />
                                                <div class="form-line">
                                                    <asp:CheckBox ID="ChkOfferActive" Text="تفعيل العرض" runat="server" />
                         
                                <asp:CheckBox ID="ChkFirstOrder" Text="لأول طلب" runat="server" 
                                    AutoPostBack="True" oncheckedchanged="ChkFirstOrder_CheckedChanged" />
                          
                                <asp:CheckBox ID="ChkFromServices" Text="خصم من الخدمة" runat="server" />
                                                    </div>
                                                    </div>
                                                    </div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="من تاريخ*"></asp:Label>
                      
                                <asp:TextBox ID="txtFDate" MaxLength="10"  autocomplete="off" CssClass="form-control"  
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    Display="Dynamic" ErrorMessage="يجب إدخال من تاريخ" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValFDate1" runat="server" ControlToValidate="txtFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="يجب أن يكون التاريخ أكبر من أو يساوي تاريخ اليوم"
                                 ControlToValidate="txtFDate" Display="Dynamic" ForeColor="Red" ValidationGroup="1" Type="Date">*</asp:RangeValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="txtFDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                <ajax:CalendarExtender ID="CalFDate" runat="server" CssClass="MyCalendar" TargetControlID="txtFDate"
                                    Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday" PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtFTime" CssClass="form-control" MaxLength="10" runat="server"></asp:TextBox>                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4"  ForeColor="Red" ControlToValidate="txtFTime" ValidationGroup="1" ValidationExpression="^([0-1]\d|2[0-3]):([0-5]\d)(:([0-5]\d))?$" runat="server" ErrorMessage="يجب أن تكون القيمة وقت">*</asp:RegularExpressionValidator>
                         </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="إلى تاريخ"></asp:Label>
                          
                                <asp:TextBox ID="txtEDate" MaxLength="10"  autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                    Display="Dynamic" ErrorMessage="يجب إدخال إلى تاريخ" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValEDate1" runat="server" ControlToValidate="txtEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  ControlToValidate="txtEDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="يجب أن يكون التاريخ أكبر من أو يساوي تاريخ اليوم"
                                 ControlToValidate="txtEDate" Display="Dynamic" ForeColor="Red" ValidationGroup="1" Type="Date">*</asp:RangeValidator>
                                <ajax:CalendarExtender ID="CalEDate" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                <asp:TextBox ID="txtETime" CssClass="form-control" MaxLength="10" runat="server" ></asp:TextBox>                                                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red"  ControlToValidate="txtETime" ValidationGroup="1" ValidationExpression="^([0-1]\d|2[0-3]):([0-5]\d)(:([0-5]\d))?$" runat="server" ErrorMessage="يجب أن تكون القيمة وقت">*</asp:RegularExpressionValidator>
                           </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label26" runat="server" Text="الخصم"></asp:Label>
                   
                                <asp:TextBox ID="txtDiscount" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValDiscount" runat="server" ControlToValidate="txtDiscount"
                                    Display="Dynamic" ErrorMessage="يجب إدخال الخصم" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValDiscount2" runat="server" ControlToValidate="txtDiscount"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red"
                                    Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:CheckBox ID="ChkAmount" Text="خصم بالنسبة" runat="server" />
                        </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                 <asp:Label ID="Label1" runat="server" Text="رقم فاتوره"></asp:Label>
                        
                                <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                          </div></div></div>
                     <div class="col-md-6 col-sm-12 col-xs-12"></div>
                     <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                                      <asp:CheckBox ID="ChkUseApp" Text="التطبيق" runat="server" />
                         
                                <asp:CheckBox ID="ChkUseWebsite" Text="الموقع" runat="server" />
                         
                                <asp:CheckBox ID="ChkUseSystem" Text="الفرع" runat="server" />
                                                    </div>
                                                    </div>
                                                    </div>
                      <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="الخدمات"></asp:Label>
                      
                                 <asp:CheckBoxList ID="ChkServices" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">نقل سيارات</asp:ListItem>
                                        <asp:ListItem Value="2">شحن طرود</asp:ListItem>
                                        <asp:ListItem Value="3">خدمات الطريق</asp:ListItem>
                                        <asp:ListItem Value="4">الغاز</asp:ListItem>
                                        <asp:ListItem Value="5">المياة</asp:ListItem>
                                        <asp:ListItem Value="6">ليموزين</asp:ListItem>
                                        <asp:ListItem Value="7">مزودي الخدمة</asp:ListItem>                                        
                                 </asp:CheckBoxList>
                          
                              
                           </div></div></div>
                   
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                 <asp:Label ID="Label5" runat="server" Text="جهة الشحن"></asp:Label>
                        
                                    <asp:DropDownList ID="ddlFromLoc" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                         </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                 <asp:Label ID="Label6" runat="server" Text="جهة الوصول"></asp:Label>
                      
                                    <asp:DropDownList ID="ddlToLoc" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                           </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                 <asp:Label ID="Label7" runat="server" Text="حساب العميل"></asp:Label>
                  
                                    <asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                         </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                 <asp:Label ID="Label8" runat="server" Text="عدد مرات الاستخدام للعميل"></asp:Label>
                       
                                <asp:TextBox ID="txtNoofUse" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNoofUse"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقم"
                                    ForeColor="Red" Type="Integer" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                       </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                 <asp:Label ID="Label9" runat="server" Text="عدد مستخدمين الخصم"></asp:Label>
                         
                                <asp:TextBox ID="txtTotalofUse" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtTotalofUse"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقم"
                                    ForeColor="Red" Type="Integer" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                           
                                <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl="WebGetMap.aspx" runat="server">تحديد موقع الخصم</asp:HyperLink>
                                                     
                                <asp:Button ID="btnFrom" runat="server" CssClass="btn btn-primary" Text="حفظ الموقع" OnClick="btnFrom_Click" />                                
                            
                                <asp:HyperLink ID="lnkFrom" Target="_blank" Visible="false" runat="server">عرض الموقع</asp:HyperLink>        
                         </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label10" runat="server" Text="البعد عن الموقع"></asp:Label>
                        
                                <asp:TextBox ID="txtLocKM" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtLocKM"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقم"
                                    ForeColor="Red" Type="Integer" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:Label ID="Label11" runat="server" Text="KM"></asp:Label>
                         </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                      
                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                      </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ" ></asp:Label>
                          
                                <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية" ></asp:Label>
                        
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                        </div></div></div>
                      <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                         
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png"   ToolTip="أضافة عرض جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات العرض؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png"   ToolTip="تعديل بيانات العرض"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png"   ToolTip="إلغاء بيانات العرض" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات العرض؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png"   ToolTip="البحث عن بيانات العرض"
                                    OnClick="BtnSearch_Click" />
                         </div></div></div>
                 
                <div class="table-responsive text-center">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="OfferNo" AllowPaging="True"
                            PageSize="20" Width="100%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات العرض"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="كود العرض" SortExpression="PromoCode" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPromoCode" Text='<%# Bind("PromoCode") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من تاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى تاريخ" SortExpression="EDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEDate" Text='<%# Bind("EDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="النسبة" SortExpression="Discount" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscount" Text='<%# Eval("Discount","{0:N2}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الحالة" SortExpression="OfferActive" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkOfferActive" Enabled="false" Checked='<%# Bind("OfferActive") %>' runat="server" />
                                   </ItemTemplate>
                                    <ControlStyle Width="50px" />
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
                        </asp:GridView></div></div></div>
                    </div>
                 
        </div>
  
</asp:Content>
