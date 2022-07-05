<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebLoanHistory.aspx.cs" Inherits="ACC.WebLoanHistory" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content Culture="ar-EG" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <fieldset class="card text-center">
                    <div class="form-group">
                        <h4 class="text-muted">
                            بيان أعمار الديون
                        </h4>
                    </div>
                    <hr />
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-1"></div>
                        <div class="form-group col-sm-2">
                            <asp:CheckBox ID="ChkPeriod" CssClass="form-control" runat="server" Checked="True" 
                                    Text="جميع الفترات" AutoPostBack="True" 
                                    oncheckedchanged="ChkPeriod_CheckedChanged" />
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"   
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                    
                                <asp:ImageButton ID="BtnExcel" Visible="false" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"  
                                    ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-sm-1"></div>
                        <div class="form-group col-sm-2">
                            <asp:CheckBox ID="ChkCustomer" CssClass="form-control" runat="server" Checked="True" 
                                    Text="جميع العملاء" AutoPostBack="True" 
                                    oncheckedchanged="ChkCustomer_CheckedChanged"/>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:CheckBox ID="ChkSite" runat="server" CssClass="form-control" Checked="false" Text="الفروع" 
                                    AutoPostBack="True" oncheckedchanged="ChkSite_CheckedChanged" />
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlRecordsPerPage" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
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
                        <div class="form-group col-sm-1"> </div>
                        
                        
                    </div>
                    <div class="form-row">
                         <div class="form-group col-sm-1"> </div>
                        <div class="form-group col-sm-6">
                            <asp:DropDownList ID="ddlCustomer" Visible="false" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCustomer_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                         <div class="form-group col-sm-5"> </div>
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
                            <asp:TemplateField HeaderText="رقم الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCode" Text='<%# Eval("Code") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="اسم العميل" SortExpression="AccName1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblAccName1" Text='<%# Eval("AccName1") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalGDate" Text="الاجمالي" runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="افتتاحي" SortExpression="DbAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblDbAmount" Text='<%# Eval("DbAmount","{0:N0}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDbAmount" Text='<%# TotalDbAmount %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="يناير 2014" SortExpression="CrAmount1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCrAmount1" Text='<%# Eval("CrAmount1","{0:N0}") %>' ToolTip = '<%# Eval("Cr1") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalCrAmount1" Text='<%# TotalCrAmount1 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="فبراير 2014" SortExpression="CrAmount2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCrAmount2" Text='<%# Eval("CrAmount2","{0:N0}") %>' ToolTip = '<%# Eval("Cr2") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalCrAmount2" Text='<%# TotalCrAmount2 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مارس 2014" SortExpression="CrAmount3" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCrAmount3" Text='<%# Eval("CrAmount3","{0:N0}") %>' ToolTip = '<%# Eval("Cr3") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalCrAmount3" Text='<%# TotalCrAmount3 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أبريل 2014" SortExpression="CrAmount4" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCrAmount4" Text='<%# Eval("CrAmount4","{0:N0}") %>' ToolTip = '<%# Eval("Cr4") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalCrAmount4" Text='<%# TotalCrAmount4 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مايو 2014" SortExpression="CrAmount5" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCrAmount5" Text='<%# Eval("CrAmount5","{0:N0}") %>' ToolTip = '<%# Eval("Cr5") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalCrAmount5" Text='<%# TotalCrAmount5 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="يونيه 2014" SortExpression="CrAmount6" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCrAmount6" Text='<%# Eval("CrAmount6","{0:N0}") %>' ToolTip = '<%# Eval("Cr6") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalCrAmount6" Text='<%# TotalCrAmount6 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="يوليه 2014" SortExpression="CrAmount7" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblCrAmount7" Text='<%# Eval("CrAmount7","{0:N0}") %>' ToolTip = '<%# Eval("Cr7") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalCrAmount7" Text='<%# TotalCrAmount7 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أغسطس 2014" SortExpression="CrAmount8" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblCrAmount8" Text='<%# Eval("CrAmount8","{0:N0}") %>' ToolTip = '<%# Eval("Cr8") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalCrAmount8" Text='<%# TotalCrAmount8 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سبتمبر 2014" SortExpression="CrAmount9" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblCrAmount9" Text='<%# Eval("CrAmount9","{0:N0}") %>' ToolTip = '<%# Eval("Cr9") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalCrAmount9" Text='<%# TotalCrAmount9 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أكتوبر 2014" SortExpression="CrAmount10"  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblCrAmount10" Text='<%# Eval("CrAmount10","{0:N0}") %>' ToolTip = '<%# Eval("Cr10") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalCrAmount10" Text='<%# TotalCrAmount10 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نوفمبر 2014" SortExpression="CrAmount11" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCrAmount11" Text='<%# Eval("CrAmount11","{0:N0}") %>' ToolTip = '<%# Eval("Cr11") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalCrAmount11" Text='<%# TotalCrAmount11 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ديسمبر 2014" SortExpression="CrAmount12" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCrAmount12" Text='<%# Eval("CrAmount12","{0:N0}") %>' ToolTip = '<%# Eval("Cr12") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalCrAmount12" Text='<%# TotalCrAmount12 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="يناير 2015" SortExpression="DbAmount1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblDbAmount1" Text='<%# Eval("DbAmount1","{0:N0}") %>' ToolTip = '<%# Eval("Db1") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalDbAmount1" Text='<%# TotalDbAmount1 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="فبراير" SortExpression="DbAmount2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblDbAmount2" Text='<%# Eval("DbAmount2","{0:N0}") %>' ToolTip = '<%# Eval("Db2") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDbAmount2" Text='<%# TotalDbAmount2 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مارس" SortExpression="DbAmount3" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblDbAmount3" Text='<%# Eval("DbAmount3","{0:N0}") %>' ToolTip = '<%# Eval("Db3") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalDbAmount3" Text='<%# TotalDbAmount3 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أبريل" SortExpression="DbAmount4" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblDbAmount4" Text='<%# Eval("DbAmount4","{0:N0}") %>' ToolTip = '<%# Eval("Db4") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDbAmount4" Text='<%# TotalDbAmount4 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مايو" SortExpression="DbAmount5" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblDbAmount5" Text='<%# Eval("DbAmount5","{0:N0}") %>' ToolTip = '<%# Eval("Db5") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalDbAmount5" Text='<%# TotalDbAmount5 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="يونيه" SortExpression="DbAmount6" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblDbAmount6" Text='<%# Eval("DbAmount6","{0:N0}") %>' ToolTip = '<%# Eval("Db6") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalDbAmount6" Text='<%# TotalDbAmount6 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="يوليه" SortExpression="DbAmount7" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblDbAmount7" Text='<%# Eval("DbAmount7","{0:N0}") %>' ToolTip = '<%# Eval("Db7") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDbAmount7" Text='<%# TotalDbAmount7 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أغسطس" SortExpression="DbAmount8" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblDbAmount8" Text='<%# Eval("DbAmount8","{0:N0}") %>' ToolTip = '<%# Eval("Db8") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDbAmount8" Text='<%# TotalDbAmount8 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سبتمبر" SortExpression="DbAmount9" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblDbAmount9" Text='<%# Eval("DbAmount9","{0:N0}") %>' ToolTip = '<%# Eval("Db9") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDbAmount9" Text='<%# TotalDbAmount9 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أكتوبر" SortExpression="DbAmount10" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblDbAmount10" Text='<%# Eval("DbAmount10","{0:N0}") %>' ToolTip = '<%# Eval("Db10") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDbAmount10" Text='<%# TotalDbAmount10 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نوفمبر" SortExpression="DbAmount11" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblDbAmount11" Text='<%# Eval("DbAmount11","{0:N0}") %>' ToolTip = '<%# Eval("Db11") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDbAmount11" Text='<%# TotalDbAmount11 %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ديسمبر" SortExpression="DbAmount12" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblDbAmount12" Text='<%# Eval("DbAmount12","{0:N0}") %>' ToolTip = '<%# Eval("Db12") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalDbAmount12" Text='<%# TotalDbAmount12 %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الرصيد" SortExpression="OpenBal" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblBal" Text='<%# Eval("OpenBal","{0:N0}") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalBal" Text='<%# TotalBal %>' runat="server"></asp:Label>
                                    </div>
                                    
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
                
</asp:Content>
