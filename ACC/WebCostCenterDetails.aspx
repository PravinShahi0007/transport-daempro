<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCostCenterDetails.aspx.cs" Inherits="ACC.WebCostCenterDetails" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <fieldset class="card text-center">
                    <div class="form-group">
                        <h4 class="text-muted">
                            أيرادات ومصروفات مركز
                        </h4>
                    </div>
                    <hr />
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label1" runat="server" Text="نوع المركز"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlCenter" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlCenter_SelectedIndexChanged">
                                    <asp:ListItem Value="0">المناطق</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="1">الفروع</asp:ListItem>
                                    <asp:ListItem Value="2">الأنشطة</asp:ListItem>
                                    <asp:ListItem Value="3">التكاليف</asp:ListItem>
                                    <asp:ListItem Value="4">الشاحنات</asp:ListItem>
                                    <asp:ListItem Value="5">الموظفين</asp:ListItem>
                                    <asp:ListItem Value="6">المصاريف</asp:ListItem>
                                </asp:DropDownList>  
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:CheckBox ID="ChkPeriod" runat="server" CssClass="form-control" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                      ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server"
                                    ImageUrl="~/images/print.png"   OnCommand="BtnPrint1_Command"
                                    OnClientClick="aspnetForm.target ='_blank';" />
                                <asp:ImageButton ID="BtnExcel" Visible="false" runat="server" AlternateText="تصدير للإكسل"
                                    CommandName="Excel"   ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير"
                                    OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnExcel_Click" />
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-sm-2"><asp:Label ID="Label2" runat="server" Text="الفرع"></asp:Label></div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlBranch" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlBranch_SelectedIndexChanged">                                  
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlRecordsPerPage" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
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
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                        </div>
                    </div>
<hr />
                    <br />
                </fieldset>
                <div class="text-center form">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="رقم الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Code") %>' NavigateUrl='<%# UrlHelper(Eval("Code"))%>'
                                        Target="_blank" runat="server"></asp:HyperLink>
                                    </div>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الحساب" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblName1" Text='<%# Eval("Name1") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"> <asp:Label ID="lblTotalName1" Text='الاجمالي' runat="server"></asp:Label></div>
                                   
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الايراد" SortExpression="Income" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblIncome" Text='<%# Eval("Income","{0:N2}") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalIncome" Text='<%# TotalIncome %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="النسبة" SortExpression="IncomePer2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblIncomePer2" Text='<%# Eval("IncomePer2","{0:N2}")+"%" %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotal1" Text='100%' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نسبة التوزيع" SortExpression="IncomePer" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblIncomePer" Text='<%# Eval("IncomePer","{0:N2}")+"%" %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المصروف" SortExpression="Expenses" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblExpenses" Text='<%# Eval("Expenses","{0:N2}") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses" Text='<%# TotalExpenses %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="النسبة" SortExpression="ExpensesPer2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblExpensesPer2" Text='<%# Eval("ExpensesPer2","{0:N2}")+"%" %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotal2" Text='100%' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نسبة التوزيع" SortExpression="ExpensesPer" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblExpensesPer" Text='<%# Eval("ExpensesPer","{0:N2}")+"%" %>' runat="server"></asp:Label>
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
                
</asp:Content>
