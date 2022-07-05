<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebStatement.aspx.cs" Inherits="ACC.WebStatement" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    <script type="text/javascript">
        function pageLoad() {
            SetMyStyle();
            $(function () {
                $('input[id="ContentPlaceHolder1_txtCode"]').watermark("كود الحساب");
                $('input[id="ContentPlaceHolder1_txtName"]').watermark("اسم الحساب");
            });
        }

        function ace2_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            var str2 = 'ContentPlaceHolder1_txtName';
            var ace1Value = $get(str);
            var ace2Value = $get(str2);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

        function ace1_itemSelected(sender, e) {
            var str = sender.get_element().id;
            var x1 = str.split('_');
            var str2 = 'ContentPlaceHolder1_txtCode';
            var ace1Value = $get(str2);
            var ace2Value = $get(str);
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="row">
       <div class="col-sm-12">
           <h4 class="text-center panel-heading">
                        كشف حساب تفصيلي</h4>
       </div>
   </div>

 <fieldset class="border border-primary card">   
                        <div class="form-row">
                       <div class="form-group col-sm-3">
                                <asp:CheckBox ID="ChkPeriod" CssClass="form-control" runat="server" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />
                            <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
             </div><div class="form-group col-sm-4">
                
                   </div>
                        <div class="form-group col-sm-5">
                            
                        </div>
                           
                       </div>
                    <div class="form-row">
                        <div class="form-group col-sm-1">
                          <asp:Label ID="Label1" runat="server" Text="الحساب"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:TextBox ID="txtCode"  runat="server" AutoPostBack="True" CssClass="form-control"
                                    ontextchanged="txtCode_TextChanged"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCode"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionListAll" OnClientItemSelected="ace2_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:TextBox ID="txtName" Width="230px" runat="server" AutoPostBack="True" CssClass="form-control"
                                    ontextchanged="txtName_TextChanged"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtName"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionListAll2" OnClientItemSelected="ace1_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                        </div>
                        <div class="form-group col-sm-5">
                            <asp:CheckBox ID="ChkDetailsPrint" CssClass="form-control" Text="طباعة تفصيلية" runat="server" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-sm-1">
                            <asp:Label ID="Label2" runat="server" Text="المنطقة"></asp:Label> 
                        </div>
                        <div class="form-group col-sm-5">
                            <asp:DropDownList ID="ddlArea" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:Label ID="Label3" runat="server" Text="الفرع"></asp:Label>
                        </div>
                        <div class="form-group col-sm-5">
                            <asp:DropDownList ID="ddlCostCenter" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCostCenter_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-sm-1"><asp:Label ID="Label5" runat="server" Text="المشروع"></asp:Label></div>
                        <div class="form-group col-sm-5">
                            <asp:DropDownList ID="ddlProject" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlProject_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:Label ID="Label7" runat="server" Text="حساب التكاليف"></asp:Label>
                        </div>
                        <div class="form-group col-sm-5">
                             <asp:DropDownList ID="ddlCostAcc" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCostAcc_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                    </div>
                            <div class="form-row">
                                <div class="form-group col-sm-1"><asp:Label ID="Label8" runat="server" Text="الموظف"></asp:Label></div>
                                <div class="form-group col-sm-5">
                                    <asp:DropDownList ID="ddlEmp" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlEmp_SelectedIndexChanged">
                                </asp:DropDownList>
                                </div>
                                <div class="form-group col-sm-1">
                                    <asp:Label ID="Label9" runat="server" Text="مركز الحسابات"></asp:Label>
                                </div>
                                <div class="form-group col-sm-5">
                                    <asp:DropDownList ID="ddlCenter" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCenter_SelectedIndexChanged">
                                </asp:DropDownList>
                                </div>
                            </div>
                    <div class="form-row">
                        <div class="form-group col-sm-1"><asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label></div>
                        <div class="form-group col-sm-5">
                            <asp:DropDownList ID="ddlRecordsPerPage" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="-1">الكل</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                &nbsp;
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                            <asp:Label ID="Label10" runat="server" Text="الشاحنة"></asp:Label>
                        </div>
                        <div class="form-group col-sm-5">
                            <asp:DropDownList ID="ddlCars" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlCars_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                    </div>

       <div class="form-row"><div class="form-group col-sm-3"></div>
           <div class="form-group col-sm-2">
                  <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                      ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                          </div>
           <div class="form-group col-sm-2">
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                               </div>
           <div class="form-group col-sm-2">
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"
                                      ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير"
                                    OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnExcel_Click" />
               </div>
           <div class="form-group col-sm-3"></div>
       </div>
     <div class="from-row">
         <div class="form-group col-sm-6">
              <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
         </div>
         <div class="form-group col-sm-6">
             <!--star here this is hidden in form group-->      <asp:TextBox ID="txtFDate" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                        <!--this End here is hidden in form group-->  
         </div>
     </div>
 
                </fieldset>
    <br />
    <br />
                <div class="border border-primary card" style="width: 100%;  height:500px; overflow:none; overflow-x:auto;">
                    <asp:GridView ID="grdCodes" runat="server" Width="700px" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="نوع القيد" SortExpression="FType2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFType2" Text='<%# Bind("FType2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lbltot" Text="الاجمالي" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم القيد" SortExpression="Number" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblNumber" Text='<%# Eval("LocType").ToString()=="2" ? Eval("LocNumber")+"/"+Eval("Number") : Eval("FType").ToString()=="801" ? "001/"+Eval("Number") : Eval("Number") %>' NavigateUrl='<%# UrlHelper(Eval("FType") ,Eval("Number"),Eval("LocNumber"),Eval("LocType") )%>' Target="_blank" runat="server"></asp:HyperLink> 
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أسم الحساب" SortExpression="AccName1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccName" Text='<%# Bind("AccName1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مدين" SortExpression="DbAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotDbAmount" Text='<%# Eval("DbAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalDbAmount" Text='<%# TotalDbAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="دائن" SortExpression="CrAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotCrAmount" Text='<%# Eval("CrAmount","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalCrAmount" Text='<%# TotalCrAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الرصيد" SortExpression="Bal" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotBal" Text='<%# Eval("Bal","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المستند" SortExpression="InvNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvNo" Text='<%# Bind("InvNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التوجيه" SortExpression="Area" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAreaName" Text='<%# Bind("AreaName1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="LblCostName" Text='<%# Bind("CostName1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="LblProjectName" Text='<%# Bind("ProjectName1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="LblCostAccName" Text='<%# Bind("CostAccName1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblCarName" Text='<%# Bind("CarType") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="شرح القيد" SortExpression="Remark" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotBal" Text='<%# Bind("Remark") %>' runat="server"></asp:Label>
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
                </div>
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                <br />
            
       
</asp:Content>
