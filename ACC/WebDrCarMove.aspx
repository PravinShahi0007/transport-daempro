<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebDrCarMove.aspx.cs" Inherits="ACC.WebDrCarMove" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="box box-info card" align="right">
        <div class="card-header">
            <h4 class="card-title">بيان حركة شاحنة / سائق</h4>
        </div>

        <div class="card-body">
            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group form-float">
                        <div class="form-line">
                            <asp:Label ID="Label2" runat="server" Text="الشاحنة"></asp:Label>


                            <asp:DropDownList ID="ddlCars" CssClass="form-control" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlCars_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group form-float">
                        <div class="form-line">
                            <asp:Label ID="Label1" runat="server" Text="السائق"></asp:Label>

                            <asp:DropDownList ID="ddlDrivers" CssClass="form-control" runat="server"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlDrivers_SelectedIndexChanged">
                            </asp:DropDownList>


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
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group form-float">
                        <div class="form-line">
                            <asp:Label ID="Label3" runat="server" Text="من"></asp:Label>


                            <asp:DropDownList ID="ddlFrom" CssClass="form-control" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlFrom_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group form-float">
                        <div class="form-line">
                            <asp:Label ID="Label5" runat="server" Text="إلى"></asp:Label>


                            <asp:DropDownList ID="ddlTo" CssClass="form-control" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlTo_SelectedIndexChanged">
                            </asp:DropDownList>

                            <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                OnCheckedChanged="ChkPeriod_CheckedChanged" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group form-float">
                        <div class="form-line">
                            <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>

                            <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false"
                                runat="server" AutoPostBack="True" OnTextChanged="txtFDate_TextChanged"></asp:TextBox>
                            <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />

                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group form-float">
                        <div class="form-line">
                            <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>


                            <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false"
                                runat="server" AutoPostBack="True" OnTextChanged="txtEDate_TextChanged"></asp:TextBox>
                            <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />

                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group form-float">
                        <div class="form-line">
                            <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>

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
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <div class="form-group form-float">
                        <div class="form-line">
                            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                            &nbsp;
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>

                            <asp:CheckBox ID="ChkQuan" runat="server" Checked="false" Text="بدون حمولة"
                                AutoPostBack="True" OnCheckedChanged="ChkQuan_CheckedChanged" />
                        </div>
                    </div>
                </div>

                <div class="table table-responsive table-hover text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        DataKeyNames="FNo" Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnRowDataBound="grdCodes_RowDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أسم السائق" SortExpression="Driver" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDriver" Text='<%# Bind("Driver") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalGDate" Text="الاجمالي" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الشاحنة" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="بيان الترحيل" SortExpression="CarMoveNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblCarMoveNo" Text='<%# Eval("CarMoveNo") %>' NavigateUrl='<%# UrlHelper("1" ,Eval("CarMoveNo"))%>'
                                        Target="_blank" runat="server"></asp:HyperLink>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="CarMoveDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCarMoveDate" Text='<%# Bind("CarMoveDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوقت" SortExpression="CarMoveFTime" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCarMoveFTime" Text='<%# Bind("CarMoveFTime") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="جهة الترحيل" SortExpression="CarMoveFromLoc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCarMoveFromLoc" Text='<%# Bind("CarMoveFromLoc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="جهة الوصول" SortExpression="CarMoveToLoc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCarMoveToLoc" Text='<%# Bind("CarMoveToLoc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الحالة" SortExpression="Status" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" Text='<%# Bind("Status") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="وقت الوصول المتوقع" SortExpression="RCVFTime2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRCVFTime" Text='<%# Bind("RCVFTime2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="بيان الوصول" SortExpression="CarMoveRCVNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblCarMoveRCVNo" Text='<%# Eval("CarMoveRCVNo") %>' NavigateUrl='<%# UrlHelper("2" ,Eval("CarMoveRCVNo"))%>'
                                        Target="_blank" runat="server"></asp:HyperLink>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="CarMoveRCVDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCarMoveRCVDate" Text='<%# Bind("CarMoveRCVDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblPer1" Text="نسبة الحركة" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوقت" SortExpression="CarMoveRCVFTime" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCarMoveRCVFTime" Text='<%# Bind("CarMoveRCVFTime") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalPer2" Text='<%# TotalPer2 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="فرق الوصول" SortExpression="Diff" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiff" Text='<%# Bind("Diff") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalDiff" Text='<%# TotalDiff %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="الحمولة" SortExpression="Qty" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" Text='<%# Bind("Qty") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalQty" Text='<%# TotalQty %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="عدد كم" SortExpression="KMeter" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblkMeter" Text='<%# Bind("KMeter") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalKMeter" Text='<%# TotalKMeter %>' runat="server"></asp:Label>
                                </FooterTemplate>
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
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>

            </div>
        </div>
    </div>

</asp:Content>
