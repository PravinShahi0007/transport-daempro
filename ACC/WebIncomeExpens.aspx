<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebIncomeExpens.aspx.cs" Inherits="ACC.WebIncomeExpens" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="form text-center card">
                <fieldset>
                    <div class="form-group">
                        <h4 class="text-muted">
                            حساب الأيرادات و المصروفات
                        </h4>
                    </div>
                    <hr /><br />
                   <div class="form-row">
                       <div class="form-group col-sm-2">
                           <asp:Label ID="Label1" runat="server" Text="المستوى"></asp:Label>
                       </div>
                       <div class="form-group col-sm-2">
                           <asp:DropDownList ID="ddlLevel" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlLevel_SelectedIndexChanged">
                                    <asp:ListItem Value="1">الأول</asp:ListItem>
                                    <asp:ListItem Value="2">الثاني</asp:ListItem>
                                    <asp:ListItem Value="3">الثالث</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="4">الرابع</asp:ListItem>
                                    <asp:ListItem Value="5">الخامس</asp:ListItem>
                                </asp:DropDownList>
                       </div>
                       <div class="form-group col-sm-2">
                           <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" CssClass="form-control" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />
                       </div>
                       


                       <div class="form-group col-sm-3"></div>
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
                        <div class="form-group col-sm-2">
                           <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                       </div>
                       <div class="form-group col-sm-3">
                           <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
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
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                       
                        <div class="form-group col-sm-2"></div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-sm-2"></div>
                        <div class="form-group col-sm-3">
                            <asp:CheckBox ID="ChkPeriod0" runat="server" CssClass="form-control" Text="مقارنة فترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod0_CheckedChanged" />
                        </div>
                        <div class="form-group col-sm-2">
                            <div id="divPeriod" runat="server" visible="false">
                                    <asp:CheckBoxList ID="ChkPeriods" CssClass="form-control" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ChkPeriods_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                        </div>
                      <div class="form-group col-sm-4"></div>
                        <div class="form-group col-sm-1"></div>
                    </div>

                    <div class="form-row">
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
                        <div class="form-group col-sm-6"></div>
                    </div>
             <!--+++++++++++++++++++++++++++++++ Ankur kumar +++++++++++++++++++++++++++++++++++-->
                </fieldset>
            <hr />
            <br />
                <div class="form text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging"  OnRowDataBound="grdCodes_RowDataBound" >
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
                            <asp:TemplateField HeaderText="المصروفات" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblName1" Text='<%# Eval("Name1") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalName1" Text='الاجمالي' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses1" Text='<%# Eval("Expenses1","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses1" Text='<%# TotalExpenses1 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                           
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses2" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses2" Text='<%# Eval("Expenses2","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses2" Text='<%# TotalExpenses2 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses3" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses3" Text='<%# Eval("Expenses3","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses3" Text='<%# TotalExpenses3 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                        
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses4" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses4" Text='<%# Eval("Expenses4","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses4" Text='<%# TotalExpenses4 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                          
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses5" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses5" Text='<%# Eval("Expenses5","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses5" Text='<%# TotalExpenses5 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                         
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses6" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses6" Text='<%# Eval("Expenses6","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses6" Text='<%# TotalExpenses6 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                       
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses7" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses7" Text='<%# Eval("Expenses7","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses7" Text='<%# TotalExpenses7 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                  
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses8" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses8" Text='<%# Eval("Expenses8","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses8" Text='<%# TotalExpenses8 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
      
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses9" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses9" Text='<%# Eval("Expenses9","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses9" Text='<%# TotalExpenses9 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses10" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses10" Text='<%# Eval("Expenses10","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses10" Text='<%# TotalExpenses10 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses11" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses11" Text='<%# Eval("Expenses11","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses11" Text='<%# TotalExpenses11 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Expenses12" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblExpenses12" Text='<%# Eval("Expenses12","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalExpenses12" Text='<%# TotalExpenses12 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الحساب" SortExpression="Code2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:HyperLink ID="HyperLink2" Text='<%# Eval("Code2") %>' NavigateUrl='<%# UrlHelper(Eval("Code2"))%>'
                                        Target="_blank" runat="server"></asp:HyperLink>
                                    </div>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الايرادات" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblName2" Text='<%# Eval("Name2") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome1" Text='<%# Eval("Income1","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome1" Text='<%# TotalIncome1 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income2" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome2" Text='<%# Eval("Income2","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome2" Text='<%# TotalIncome2 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income3" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome3" Text='<%# Eval("Income3","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome3" Text='<%# TotalIncome3 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income4" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome4" Text='<%# Eval("Income4","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome4" Text='<%# TotalIncome4 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income5" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome5" Text='<%# Eval("Income5","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome5" Text='<%# TotalIncome5 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income6" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome6" Text='<%# Eval("Income6","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome6" Text='<%# TotalIncome6 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income7" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome7" Text='<%# Eval("Income7","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome7" Text='<%# TotalIncome7 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income8" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome8" Text='<%# Eval("Income8","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome8" Text='<%# TotalIncome8 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income9" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome9" Text='<%# Eval("Income9","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome9" Text='<%# TotalIncome9 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income10" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome10" Text='<%# Eval("Income10","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome10" Text='<%# TotalIncome10 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income11" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome11" Text='<%# Eval("Income11","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome11" Text='<%# TotalIncome11 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="القيمة" SortExpression="Income12" Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblIncome12" Text='<%# Eval("Income12","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalIncome12" Text='<%# TotalIncome12 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
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