<%@ Page Title="بيانات الشاحنات" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebCars.aspx.cs" Inherits="ACC.WebCars" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">

        function Plate_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCode');
            var ace2Value = $get('ContentPlaceHolder1_txtPlateNo');
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
                <h3 align="center" >
                    [ بيانات الشاحنات ]</h3>
               <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label10" runat="server" Text="نوع المركبه"></asp:Label>
                         
                                <asp:DropDownList ID="ddlCarsType" CssClass="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCarsType_SelectedIndexChanged">
                                </asp:DropDownList>
                           </div></div></div>
                        
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:CheckBox ID="ChkStatus" runat="server" Text="في الخدمة" />
                         
                             </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:TextBox ID="txtPLoc" Placeholder="موقع الشاحنة/السيارة" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCode" runat="server" Text="رقم الشاحنة"></asp:Label>
                          
                                <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" MaxLength="5"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/search2.png"
                                    ToolTip="البحث عن بيانات شاحنة" OnClick="BtnSearch_Click" />
                                <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtCode"
                                    ErrorMessage="يجب إدخال رقم الشاحنة" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label13" runat="server" Text="النوع عربي"></asp:Label>
                        
                                <asp:TextBox ID="txtWorkShopCode" CssClass="form-control" Visible="false" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtCarType" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="رقم اللوحه"></asp:Label>
                         
                                <asp:TextBox ID="txtPlateNo" CssClass="form-control" runat="server" MaxLength="15" autocomplete="off"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender03" runat="server" TargetControlID="txtPlateNo"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars20" OnClientItemSelected="Plate_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="النوع أنجليزي"></asp:Label>
                          
                                <asp:TextBox ID="txtCarType2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label7" runat="server" Text="الطراز"></asp:Label>
                         
                                <asp:TextBox ID="txtTaraz" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label9" runat="server" Text="الموديل"></asp:Label>
                         
                                <asp:TextBox ID="txtModel" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="عداد الكيلومتر"></asp:Label>
                         
                                <asp:TextBox ID="txtKMeter" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                                <asp:CompareValidator ID="ValKMeter" runat="server" ControlToValidate="txtKMeter"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                        </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="الموظف/السائق"></asp:Label>
                          
                                <asp:DropDownList ID="ddlDrivers" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                      
                                <asp:Label ID="Label16" runat="server" Text="نوع الملحق"></asp:Label>
                          
                                <asp:DropDownList ID="ddlFollowType" CssClass="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlFollowType_SelectedIndexChanged">
                                </asp:DropDownList>
                         </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label14" runat="server" Text="الملحق"></asp:Label>
                          
                                <asp:DropDownList ID="ddlFollow2" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label15" runat="server" Text="حساب الاصل"></asp:Label>
                        
                                <asp:DropDownList ID="ddlFixAssetCode" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                         </div></div></div>
                            <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label12" runat="server" Text="الملحقات"></asp:Label>
                     
                                <asp:DropDownList ID="ddlFType2" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                           </div></div></div>
                            <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label5" runat="server" Text="قراءة تغيير الزيت"></asp:Label>
                          
                                <asp:TextBox ID="txtChOilKMeter" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtChOilKMeter"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                       </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label8" runat="server" Text="تاريخ التغيير"></asp:Label>
                          
                                <asp:TextBox ID="txtChOilDate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                         </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label6" runat="server" Text="قراءة تعبئة الوقود"></asp:Label>
                         
                                <asp:TextBox ID="txtChDezelKMeter" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtChDezelKMeter"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                            </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label11" runat="server" Text="تاريخ التعبئة"></asp:Label>
                         
                                <asp:TextBox ID="txtChDezelDate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                          </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label17" runat="server" Text="أنتهاء الاستمارة"></asp:Label>
                          
                                <asp:TextBox ID="txtPHDate1" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc1" Placeholder="موقع الاصل" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>

                           </div></div></div>
                            <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label18" runat="server" Text="أنتهاء التامين"></asp:Label>
                       
                                <asp:TextBox ID="txtPHDate2" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc2" Placeholder="موقع الاصل" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                       </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label19" runat="server" Text="أنتهاء بطاقة التشغيل"></asp:Label>
                        
                                <asp:TextBox ID="txtPHDate3" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc3" Placeholder="موقع الاصل" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                           </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label20" runat="server" Text="تاريخ الفحص"></asp:Label>
                         
                                <asp:TextBox ID="txtPHDate4" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc4" Placeholder="موقع الاصل" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                         </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label21" runat="server" Text="أنتهاء تامين حمولة"></asp:Label>
                          
                                <asp:TextBox ID="txtPHDate5" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:TextBox ID="txtPLoc5" Placeholder="موقع الاصل" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                          </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label35" runat="server" Text="القطاع"></asp:Label>
                         </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label22" runat="server" Text="النوع"></asp:Label>
                          
                                <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                           </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label23" runat="server" Text="رقم الهيكل"></asp:Label>
                    
                                <asp:TextBox ID="txtCarStruct" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                           </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label24" runat="server" Text="رقم التسلسلي"></asp:Label>
                           
                                <asp:TextBox ID="txtCarSerial" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                          </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label25" runat="server" Text="قيمة ومدة الأستمارة"></asp:Label>
                          
                                <asp:TextBox ID="txtamP1" CssClass="form-control" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP1" CssClass="form-control" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP1LDate" CssClass="form-control" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP1LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                           </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label28" runat="server" Text="قيمة ومدة تأمين الغير"></asp:Label>
                         
                                <asp:TextBox ID="txtamP2" CssClass="form-control" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP2" CssClass="form-control" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP2LDate" CssClass="form-control" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP2LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                           </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label26" runat="server" Text="قيمة ومدة بطاقة التشغيل"></asp:Label>
                         
                                <asp:TextBox ID="txtamP3" CssClass="form-control" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP3" CssClass="form-control" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP3LDate" CssClass="form-control" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP3LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                          </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label29" runat="server" Text="قيمة ومدة الفحص"></asp:Label>
                          
                                <asp:TextBox ID="txtamP4" CssClass="form-control" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP4" CssClass="form-control" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP4LDate" CssClass="form-control" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP4LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label27" runat="server" Text="قيمة ومدة تامين حموله"></asp:Label>
                           
                                <asp:TextBox ID="txtamP5" CssClass="form-control" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP5" CssClass="form-control" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP5LDate" CssClass="form-control" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP5LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label30" runat="server" Text="قيمة ومدة تامين شامل"></asp:Label>
                           
                                <asp:TextBox ID="txtamP6" CssClass="form-control" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP6" CssClass="form-control" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP6LDate" CssClass="form-control" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP6LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                          
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                          </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                           </div></div></div>
                  <div class="table table-responsive text-center">
                        <asp:GridView ID="grdMan" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="CarNo" AllowPaging="false"
                            PageSize="1000" Width="100%" EmptyDataText="لا توجد بيانات">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="نوع المستند" SortExpression="VouType2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVouType2" Text='<%# Bind("VouType2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الرقم" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVouNo" Text='<%# Bind("VouNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التاريخ" SortExpression="VouDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVouDate" Text='<%# Bind("VouDate") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="البيان" SortExpression="Ref" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRef" Text='<%# Bind("Ref") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="القيمة" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تاريخ أخر تنفيذ" SortExpression="LDate" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLDate" Text='<%# Bind("LDate") %>' runat="server"></asp:Label>
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
                 
                   <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png" ToolTip="أضافة شاحنة جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الشاحنة؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات شاحنة" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات شاحنة" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات العميل؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات شاحنة" OnClick="BtnSearch_Click" />
                         </div></div></div>
                               <br />
                        <div class="col-md-12 col-sm-12 col-xm-12">
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
                                     <asp:Panel ID="Panel2" runat="server">
                                         <asp:Panel ID="Panel1" runat="server">
                                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                                            ShowHeader="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="100%" OnRowDeleting="grdAttach_RowDeleting">
                                            <AlternatingRowStyle BackColor="White" />
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
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        </asp:GridView>
                                       
                                             <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                    </asp:Panel>
                                     <div class="form-row">
                                      
                                                <div class="col-md-6 col-sm-12 col-xm-12">
                                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                                                </div>
                                                <div class="col-md-6 col-sm-12 col-xm-12">
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
                         
                    <div class="table table-responsive text-center">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="Code" AllowPaging="True"
                            PageSize="20" Width="100%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات الشاحنة"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم الشاحنة" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName1" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="نوع الشاحنة" SortExpression="CarType" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobileNo" Text='<%# Bind("CarType") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="250px" />
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
                    </div></div></div>
                   
          </div>
        </div>
       
 
</asp:Content>
