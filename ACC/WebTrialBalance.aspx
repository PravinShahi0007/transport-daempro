<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebTrialBalance.aspx.cs" Inherits="ACC.WebTrialBalance" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div class="card">
           
                <fieldset>
                    <div class="form-group">
                        <h4 class="text-center text-muted">
                            ميزان المراجعة
                        </h4>
                    </div>
                    <hr />
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label2" runat="server" Text="المستوى"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlLevel" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                    <asp:ListItem Value="0">الجميـع</asp:ListItem>
                                    <asp:ListItem Value="1">المستوى 1</asp:ListItem>
                                    <asp:ListItem Value="2">المستوى 2</asp:ListItem>
                                    <asp:ListItem Value="3">المستوى 3</asp:ListItem>
                                    <asp:ListItem Value="4">المستوى 4</asp:ListItem>
                                    <asp:ListItem Value="5">المستوى 5</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label3" runat="server" Text="الحساب الرئيسي"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:DropDownList ID="ddlFather" CssClass="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:CheckBox ID="chkCode" CssClass="form-control" Text="كود الحساب" runat="server" AutoPostBack="true" OnCheckedChanged="chkCode_CheckedChanged" />
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-sm-2"></div>
                        <div class="form-group col-sm-2">
                            <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" CssClass="form-control" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />
                        </div>
                        <div class="form-group col-sm-2">
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
                        <div class="form-group col-sm-1">
                            <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                    OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
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
                        <div class="form-group col-sm-5"></div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"
                                    ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                        </div>
                    </div>
                  <!--..........................Ankur Kumar.......................-->
                </fieldset>
                <hr />
                <br />
                <div class="form">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging" 
                        onrowcreated="grdCodes_RowCreated">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="كود الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <div class="form-group"><asp:HyperLink ID="lblCode" Text='<%# Bind("Code") %>' NavigateUrl='<%# string.Format("~/WebStatement.aspx?Code={0}",Eval("Code")) %>'
                                        Target="_blank" runat="server"></asp:HyperLink></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate><div class="form-group"><asp:Label ID="lbltot" Text="الاجمالي" runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أسم الحساب" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group"> <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label></div>
                                   
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أول مدين" SortExpression="odacc" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <div class="form-group">أول الفترة</div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6">مدين</div>
                                        <div class="form-group col-sm-6">دائن</div>
                                    </div>
                             
                                </HeaderTemplate>
                                <ItemTemplate><div class="form-group"><asp:Label ID="lblTotodacc" Text='<%# Eval("odacc","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate><div class="form-group"><asp:Label ID="lblTotalodacc" Text='<%# Totalodacc %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotocacc" Text='<%# Eval("ocacc","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalocacc" Text='<%# Totalocacc %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                             
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حركة مدينة" SortExpression="dacc" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <div class="form-group">حركة حالية</div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6">مدين</div>
                                        <div class="form-group col-sm-6">دائن</div>
                                    </div>
                             
                                </HeaderTemplate>
                                
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotdacc" Text='<%# Eval("dacc","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotaldacc" Text='<%# Totaldacc %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حركة دائنة" SortExpression="cacc" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotcacc" Text='<%# Eval("cacc","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalcacc" Text='<%# Totalcacc %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رصيد مدين" SortExpression="DBal" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <div class="form-group">رصيد نهاية الفترة</div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6">مدين</div>
                                        <div class="form-group col-sm-6">دائن</div>
                                    </div>
                               
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotDBal" Text='<%# Eval("DBal","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalDBal" Text='<%# TotalDBal %>' runat="server"></asp:Label></div>
                                    
                                </FooterTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رصيد دائن" SortExpression="CBal" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotCBal" Text='<%# Eval("CBal","{0:N2}") %>' runat="server"></asp:Label></div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group"><asp:Label ID="lblTotalCBal" Text='<%# TotalCBal %>' runat="server"></asp:Label></div>
                                    
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
