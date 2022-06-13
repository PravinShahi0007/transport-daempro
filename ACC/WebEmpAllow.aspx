<%@ Page Title="تقرير مستحقات العاملين" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebEmpAllow.aspx.cs" Inherits="ACC.WebEmpAllow" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
       <div class="ColorRounded4Corners col-md-10 col-md-offset-1 col-sm-12 col-xs-12">
           
     
                <fieldset class="Rounded4CornersNoShadow" >
                    <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                       كشف مستحقات الموظفين</legend>
                      <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                
                                <asp:Label ID="Label1" runat="server" Text="القسم"></asp:Label>
                          
                                <asp:DropDownList ID="ddlSection" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlSection_SelectedIndexChanged" >
                                </asp:DropDownList>
                           
                                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"   
                                    ImageUrl="~/images/Process.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print_64A.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                    
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"  
                                    ImageUrl="~/images/Excel.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                                <asp:ImageButton ID="BtnPostJv" runat="server" AlternateText="ترحيل قيد المستحقات" ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من ترحيل قيد المستحقات؟")'
                                ImageUrl="~/images/JVPost_642.png" ToolTip="ترحيل قيد المستحقات" OnClick="BtnPostJv_Click" />
                         </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:CheckBox ID="ChkFDate" Text="من بداية الفترة" Checked="true" 
                                    runat="server" AutoPostBack="True" oncheckedchanged="ChkFDate_CheckedChanged" />
                           
                               <asp:TextBox ID="txtFDate" Visible="false" MaxLength="10" CssClass="form-control" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFDate" Enabled="false"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" Enabled="false"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                           </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="إلى تاريخ"></asp:Label>
                          
                               <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                          </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                        
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
                         
                                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                &nbsp;
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                            </div></div></div>
             
                   <div class="table-responsive">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الرقم الوظيفي" SortExpression="EmpCode" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblEmpCode" Text='<%# Bind("EmpCode") %>' NavigateUrl='<%# string.Format("~/WebEMP.aspx?FNum={0}",Eval("EmpCode")) %>' Target="_blank" runat="server"></asp:HyperLink>   
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lbltot" Text="الاجمالي" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="75px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاسم" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاساسي" SortExpression="Basic" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBasic" Text='<%# Eval("Basic","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalBasic" Text='<%# TotalBasic %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="انتقال" SortExpression="Add01" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdd01" Text='<%# Eval("Add01","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAdd01" Text='<%# TotalAdd01 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="السكن" SortExpression="Add02" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdd02" Text='<%# Eval("Add02","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAdd02" Text='<%# TotalAdd02 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أخرى" SortExpression="AddAll0" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddAll" Text='<%# Eval("AddAll0","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAddAll0" Text='<%# TotalAddAll0 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="اجمالي الإجازة" SortExpression="totVac" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotVac" Text='<%# Eval("totVac","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="اجمالي المكافأة" SortExpression="totAward" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotAward" Text='<%# Eval("totAward","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ بداية التعيين" SortExpression="JoinDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblJoinDate" Text='<%# Eval("JoinDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ اخر اجازة" SortExpression="VacDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVacDate" Text='<%# Eval("VacDate") %>'  runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ العودة من اخر اجازة" SortExpression="ReturnDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblReturnDate" Text='<%# Eval("ReturnDate") %>'  runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مدة الخدمة" SortExpression="DutyDays" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDutyDays" Text='<%# Eval("DutyDays") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المدة المستحق عنها الإجازة" SortExpression="VacDays" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVacDays" Text='<%# Eval("VacDays") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عدد ايام الإجازة المستحقة" SortExpression="Vac" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVac" Text='<%# Eval("Vac","{0:N2}") %>'  runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="قيمة التذكرة" SortExpression="TicketValue" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTicketValue" Text='<%# Eval("TicketValue","{0:N2}") %>'  runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عدد التذاكر" SortExpression="TicketNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTicketNo" Text='<%# Eval("TicketNo","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أجمالي التذاكر" SortExpression="totTicket" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotTicket" Text='<%# Eval("totTicket","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotaltotTicket" Text='<%# TotalTotTicket %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تذاكر السفر" SortExpression="Ticketam" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTicketam" Text='<%# Eval("Ticketam","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalTicketam" Text='<%# TotalTicketam %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="بدل اجازة" SortExpression="Vacam" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVacam" Text='<%# Eval("Vacam","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalVacam" Text='<%# TotalVacam %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نهاية الخدمة" SortExpression="Awardam" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAwardam" Text='<%# Eval("Awardam","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAwardam" Text='<%# TotalAwardam %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاقامة" SortExpression="IDam" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblIDam" Text='<%# Eval("IDam","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalIDam" Text='<%# TotalIDam %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المقابل المالي" SortExpression="Workeram" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkeram" Text='<%# Eval("Workeram","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalWorkeram" Text='<%# TotalAwardam %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تأمين طبي" SortExpression="Insam" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblInsam" Text='<%# Eval("Insam","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalInsam" Text='<%# TotalInsam %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                            HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
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
                                    </div></div></div>
                 </fieldset>
          
        </div>

</asp:Content>
