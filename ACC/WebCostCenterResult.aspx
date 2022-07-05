<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCostCenterResult.aspx.cs" Inherits="ACC.WebCostCenterResult" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="card text-center">

            <fieldset>
                <div class="form-group">
                    <h4 class="text-muted">
                        تقييم مراكز الفروع
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
                                OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged">
                                <asp:ListItem Value="0">المناطق</asp:ListItem>
                                <asp:ListItem Selected="True" Value="1">الفروع</asp:ListItem>
                                <asp:ListItem Value="2">الأنشطة</asp:ListItem>
                                <asp:ListItem Value="3">التكاليف</asp:ListItem>
                                <asp:ListItem Value="4">الشاحنات</asp:ListItem>
                                <asp:ListItem Value="5">الموظفين</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:CheckBox ID="ChkPeriod" CssClass="form-control" runat="server" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                OnCheckedChanged="ChkPeriod_CheckedChanged" />
                    </div>
                    <div class="form-group col-sm-3"></div>
                    <div class="form-group col-sm-3">
                        <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                            <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server"
                                ImageUrl="~/images/print.png" OnCommand="BtnPrint1_Command"
                                OnClientClick="aspnetForm.target ='_blank';" />
                            <asp:ImageButton ID="BtnExcel" Visible="false" runat="server" AlternateText="تصدير للإكسل"
                                CommandName="Excel" ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير"
                                OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnExcel_Click" />
                    </div>
                </div>
<div class="form-row">
<div class="form-group col-sm-2">
                        <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                    </div>
                    <div class="form-group col-sm-3">
                        <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false"
                                runat="server" AutoPostBack="True" OnTextChanged="txtFDate_TextChanged"></asp:TextBox>
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
                                runat="server" AutoPostBack="True" OnTextChanged="txtEDate_TextChanged"></asp:TextBox>
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
<div class="form-group col-sm-6"></div>

                    <div class="form-group col-sm-2">
                        <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                    </div>
                </div>

            </fieldset>
            <hr />
            <br />
            <div class="form">
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                    Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging"
                    OnRowDataBound="grdCodes_RowDataBound">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="رقم الفرع" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:HyperLink ID="lblCode" Text='<%# Eval("Code") %>' NavigateUrl='<%# UrlHelper(Eval("Code"))%>'
                                    Target="_blank" runat="server"></asp:HyperLink>
                                </div>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الفرع" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblName1" Text='<%# Eval("Name1") %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblTotalName1" Text='الاجمالي' runat="server"></asp:Label>
                                </div>
                                
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
                        <asp:TemplateField HeaderText="نسبة الايراد" SortExpression="IncomePer" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblIncomePer" Text='<%# Eval("IncomePer","{0:N2}")+"%" %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblTotalIncomePer" Text='100%' runat="server"></asp:Label>
                                </div>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="المصروف" SortExpression="Expenses" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblExpenses" Text='<%# Eval("Expenses","{0:N2}") %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblTotalExpenses" Text='<%# TotalExpenses %>' runat="server"></asp:Label>
                                </div>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نسبة المصروف" SortExpression="ExpensesPer" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblExpensesPer" Text='<%# Eval("ExpensesPer","{0:N2}")+"%" %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblTotalExpensesPer" Text='100%' runat="server"></asp:Label>
                                </div>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الربحية" SortExpression="Net" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblNet" Text='<%# Eval("Net","{0:N2}") %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="form-group"><asp:Label ID="lblTotalNet" Text='<%# TotalNet %>' runat="server"></asp:Label></div>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نسبة الربحية" SortExpression="NetPer" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group"><asp:Label ID="lblNetPer" Text='<%# Eval("NetPer","{0:N2}")+"%" %>' runat="server"></asp:Label></div>
                                
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="form-group"><asp:Label ID="lblTotalNetPer" Text='100%' runat="server"></asp:Label></div>
                                
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
            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
            <div>
                <asp:Chart ID="Chart1" runat="server" Width="900px" Height="700px">
                    <Titles>
                        <asp:Title Font="Arial, 16pt, style=Bold" Name="Title1" ForeColor="Blue"
                            Text="مصروفات الفروع">
                        </asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Categories" Palette="EarthTones" ChartArea="MainChartArea"
                            BorderWidth="5" IsValueShownAsLabel="true" Label="#VALY   #PERCENT"
                            Color="Red" LabelForeColor="White" LabelFormat="##,#" CustomProperties="BarLabelStyle=Right"
                            ChartType="StackedBar">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" Area3DStyle-IsClustered="true">
                            <Area3DStyle Enable3D="True"></Area3DStyle>
                            <AxisX Interval="1"></AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <br />

            <div>
                <asp:Chart ID="Chart2" runat="server" Width="900px" Height="700px">
                    <Titles>
                        <asp:Title Font="Arial, 16pt, style=Bold" Name="Title2" ForeColor="Blue"
                            Text="الايرادات الفروع">
                        </asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Categories2" Palette="BrightPastel" ChartArea="MainChartArea2"
                            BorderWidth="5" IsValueShownAsLabel="true" Label="#VALY   #PERCENT" CustomProperties="BarLabelStyle=Top"
                            Color="Red" LabelForeColor="White" LabelFormat="##,#"
                            ChartType="StackedBar">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea2" Area3DStyle-IsClustered="true">
                            <Area3DStyle Enable3D="True"></Area3DStyle>
                            <AxisX Interval="1"></AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <br />

            <div>
                <asp:Chart ID="Chart3" runat="server" Width="900px" Height="700px">
                    <Titles>
                        <asp:Title Font="Arial, 16pt, style=Bold" Name="Title3" ForeColor="Blue"
                            Text="ايرادات ومصروفات الفروع">
                        </asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Categories3" Palette="Excel" ChartArea="MainChartArea3"
                            BorderWidth="5" IsValueShownAsLabel="true" Label="#VALY   #PERCENT"
                            Color="Red" LabelForeColor="White" LabelFormat="##,#"
                            ChartType="StackedBar">
                        </asp:Series>

                        <asp:Series Name="Categories30" Palette="Fire" ChartArea="MainChartArea3"
                            BorderWidth="5" IsValueShownAsLabel="true" Label="#VALY   #PERCENT"
                            Color="Red" LabelForeColor="White" LabelFormat="##,#"
                            ChartType="StackedBar">
                        </asp:Series>

                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea3" Area3DStyle-IsClustered="true">
                            <Area3DStyle Enable3D="True"></Area3DStyle>
                            <AxisX Interval="1"></AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <br />

            <div>
                <asp:Chart ID="Chart4" runat="server" Width="900px" Height="700px">
                    <Titles>
                        <asp:Title Font="Arial, 16pt, style=Bold" Name="Title4" ForeColor="Blue"
                            Text="ربحية الفروع">
                        </asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Categories4" Palette="SeaGreen" ChartArea="MainChartArea4"
                            BorderWidth="5" IsValueShownAsLabel="true" Label="#VALY   #PERCENT"
                            Color="Red" LabelForeColor="White" LabelFormat="##,#"
                            ChartType="StackedBar">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea4" Area3DStyle-IsClustered="true">
                            <Area3DStyle Enable3D="True"></Area3DStyle>
                            <AxisX Interval="1"></AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <br />
        </div>
    </center>
</asp:Content>
