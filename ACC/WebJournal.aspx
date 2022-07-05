<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebJournal.aspx.cs" Inherits="ACC.WebJournal" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="ColorRound4Courner">

                <fieldset class="Rounded4CornersNoShadow">
                    <div class="form-gruop">
                        <h4 class="text-center text-muted">دفتر قيود اليومية</h4>
                        <hr />
                    </div>
                    <br />
                   <div class="form-row">
                       <div class="form-group col-sm-2">
                           <asp:Label ID="Label2" runat="server" Text="المستوى"></asp:Label>
                       </div>
                       <div class="form-group col-sm-2">
                           <asp:DropDownList ID="ddlLevel" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlLevel_SelectedIndexChanged1">
                                    <asp:ListItem Value="0">الجميـع</asp:ListItem>
                                    <asp:ListItem Value="101">سندات القبض</asp:ListItem>
                                    <asp:ListItem Value="102">سندات الصرف</asp:ListItem>
                                    <asp:ListItem Value="100">قيود اليومية</asp:ListItem>
                                    <asp:ListItem Value="103">فاتورة شحن</asp:ListItem>
                                    <asp:ListItem Value="104">بيان ترحيل</asp:ListItem>
                                    <asp:ListItem Value="105">قسيمة إيداع بنكي</asp:ListItem>
                                    <asp:ListItem Value="106">تحويل بنكي</asp:ListItem>
                                    <asp:ListItem Value="111">مصروف التجميع</asp:ListItem>
                                    <asp:ListItem Value="112">سداد مصروف التجميع</asp:ListItem>
                                    <asp:ListItem Value="113">مصروف التوزيع</asp:ListItem>
                                    <asp:ListItem Value="114">سداد مصروف التوزيع</asp:ListItem>
                                    <asp:ListItem Value="107">فاتورة شحن طرود</asp:ListItem>
                                    <asp:ListItem Value="501">فاتورة  مشتريات</asp:ListItem>
                                    <asp:ListItem Value="502">فاتورة مرتجع مشتريات</asp:ListItem>
                                    <asp:ListItem Value="503">بيان استلام مستعمل</asp:ListItem>
                                    <asp:ListItem Value="701">سند صرف بضاعة</asp:ListItem>
                                    <asp:ListItem Value="801">بيان أصلاح خارجي</asp:ListItem>
                                    <asp:ListItem Value="802">بيان مصروفات نثرية</asp:ListItem>
                                </asp:DropDownList>
                       </div>
                       <div class="form-group col-sm-2">
                           <asp:CheckBox ID="ChkPeriod" CssClass="form-control" runat="server" Checked="True" 
                                    Text="جميع الفترات" AutoPostBack="True" 
                                    oncheckedchanged="ChkPeriod_CheckedChanged" />
                       </div>
                       
                       <div class="form-group col-sm-3">
                           <asp:CheckBox ID="ChkDetailsPrint" CssClass="form-control" Text="طباعة المستندات" runat="server" />
                       </div>
                       <div class="form-group col-sm-3">
                           <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"   
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                    
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"  
                                    ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                       </div>
                       
                   </div>

                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlRecordsPerPage" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
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
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:TextBox ID="txtVouNo" MaxLength="20" CssClass="form-control" placeholder="رقم السند"  
                                    Visible="false" runat="server" AutoPostBack="True" 
                                    ontextchanged="txtVouNo_TextChanged" ></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-2"></div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-sm-2">
                           <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                       </div>
                       <div class="form-group col-sm-3">
                           <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                       </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-2"></div>
                    </div>
                </fieldset>
                <hr />
                <br />
                <div class="form text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="نوع القيد" SortExpression="FType2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblFType2" Text='<%# Bind("FType2") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lbltot" Text="الاجمالي" runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم القيد" SortExpression="Number" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:HyperLink ID="lblNumber" Text='<%# Eval("LocType").ToString()=="2" ? Eval("LocNumber")+"/"+Eval("Number") : Eval("FType").ToString()=="801" ? "001/"+Eval("Number") : Eval("Number") %>' NavigateUrl='<%# UrlHelper(Eval("FType") ,Eval("Number"),Eval("LocNumber"),Eval("LocType") )%>' Target="_blank" runat="server"></asp:HyperLink> 
                                    </div>
                                    
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="كود الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أسم الحساب" SortExpression="AccName1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblAccName" Text='<%# Bind("AccName1") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مدين" SortExpression="DbAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotDbAmount" Text='<%# Eval("DbAmount","{0:N2}") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalDbAmount" Text='<%# TotalDbAmount %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="دائن" SortExpression="CrAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotCrAmount" Text='<%# Eval("CrAmount","{0:N2}") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalCrAmount" Text='<%# TotalCrAmount %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المستند" SortExpression="InvNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblInvNo" Text='<%# Bind("InvNo") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التوجيه" SortExpression="Area" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                         <asp:Label ID="lblAreaName" Text='<%# Bind("AreaName1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="LblCostName" Text='<%# Bind("CostName1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="LblProjectName" Text='<%# Bind("ProjectName1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="LblCostAccName" Text='<%# Bind("CostAccName1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblCarNo" Text='<%# Bind("CarType") %>' runat="server"></asp:Label>
                                    </div>
                                   
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="شرح القيد" SortExpression="Remark" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotBal" Text='<%# Bind("Remark") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                               
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
                <div class="form-group">
                    <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                </div>

        </div>

</asp:Content>