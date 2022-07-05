<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCarIssue.aspx.cs" Inherits="ACC.WebCarIssue" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<<<<<<< HEAD
    <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
            <h3 align="center">
                <asp:Label ID="lblHead" runat="server" Text="أجمالي مصروفات الشاحنات" meta:resourcekey="lblHead"></asp:Label>
            </h3>
=======
    <div class="ColorRounded4Corners col-md-10 col-md-offset-1 col-sm-12 col-xs-12">
        <fieldset class="Rounded4CornersNoShadow">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <asp:Label ID="lblHead" runat="server" Text="أجمالي مصروفات الشاحنات" meta:resourcekey="lblHead"></asp:Label>
            </legend>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
            <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" Text="جميع الفترات" meta:resourcekey="ChkPeriod" AutoPostBack="True" OnCheckedChanged="ChkPeriod_CheckedChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ" meta:resourcekey="LblFDate"></asp:Label>

                                    <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false"
                                        runat="server" AutoPostBack="True" OnTextChanged="txtFDate_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="<%$ Resources: DateValue %>"
                                        ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                        PopupPosition="BottomLeft" />
                                </div>
                                </div></div>
                            <div class="col-md-3 col-sm-12 col-xs-12">
                              <div class="form-group form-float">
                                  <div class="form-line">
<<<<<<< HEAD
                                      <asp:ImageButton ID="BtnPrint" ToolTip="<%$ Resources: PrintTooltip %>" AlternateText="<%$ Resources: Print %>" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                          OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                                      <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="<%$ Resources: Excel %>" CommandName="Excel"
                                          ImageUrl="~/images/sheet.png" ToolTip="<%$ Resources: ExcelTooltip %>" OnClientClick="aspnetForm.target ='_blank';"
                                          OnClick="BtnExcel_Click" />
                                      <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="<%$ Resources: Process %>" ValidationGroup="1"
                                          ImageUrl="~/images/setting.png" ToolTip="<%$ Resources: ProcessTooltip %>" OnClick="BtnProcess_Click" />
=======
                                      <asp:ImageButton ID="BtnPrint" ToolTip="<%$ Resources: PrintTooltip %>" AlternateText="<%$ Resources: Print %>" CommandName="1" runat="server" ImageUrl="<%$ Resources: PrintImage %>"
                                          OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                                      <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="<%$ Resources: Excel %>" CommandName="Excel"
                                          ImageUrl="<%$ Resources: ExcelImage %>" ToolTip="<%$ Resources: ExcelTooltip %>" OnClientClick="aspnetForm.target ='_blank';"
                                          OnClick="BtnExcel_Click" />
                                      <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="<%$ Resources: Process %>" ValidationGroup="1"
                                          ImageUrl="<%$ Resources: ProcessImage %>" ToolTip="<%$ Resources: ProcessTooltip %>" OnClick="BtnProcess_Click" />
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                  </div>
                            </div>
                        </div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ" meta:resourcekey="LblEDate"></asp:Label>

                                    <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false"
                                        runat="server" AutoPostBack="True" OnTextChanged="txtEDate_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate"
                                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="<%$ Resources: DateValue %>"
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
                                    <asp:Label ID="Label4" runat="server" Text="عرض السجلات" meta:resourcekey="Label4"></asp:Label>

                                    <asp:DropDownList ID="ddlRecordsPerPage" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="100">100</asp:ListItem>
                                        <asp:ListItem Value="200">200</asp:ListItem>
                                        <asp:ListItem Value="500">500</asp:ListItem>
                                        <asp:ListItem Value="1000">1000</asp:ListItem>
                                        <asp:ListItem Value="2000">2000</asp:ListItem>
                                        <asp:ListItem Value="-1" Text="<%$ Resources: All %>"></asp:ListItem>
                                    </asp:DropDownList>
<<<<<<< HEAD
                                     <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>

                                    <asp:Label ID="Label6" runat="server" Text="سجل" meta:resourcekey="Label6"></asp:Label>
                               
                                </div>
                            </div>
                        </div>
                         

                        <div class="table-responsive table">
=======
                                </div>
                            </div>
                        </div>
                         <div class="col-md-3 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>

                                    <asp:Label ID="Label6" runat="server" Text="سجل" meta:resourcekey="Label6"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="table-responsive">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                            <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                                Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources: No %>" SortExpression="ExpRef" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lblExpRef" Text='<%# Bind("ExpRef") %>' NavigateUrl='<%# string.Format("~/WebStatement.aspx?Code={0}",Eval("ExpRef")) %>' Target="_blank" runat="server"></asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbltot" Text="الاجمالي" runat="server" meta:resourcekey="lbltot"></asp:Label>
                                        </FooterTemplate>
                                        <ControlStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: ArabicName %>" SortExpression="CarName1" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCarName1" Text='<%# Bind("CarName1") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="250px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: EnglishName %>" SortExpression="CarName2" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCarName2" Text='<%# Bind("CarName2") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="250px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources: Amount %>" SortExpression="Bal" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBal" Text='<%# Eval("Bal","{0:N2}") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalBal" Text='<%# TotalBal %>' runat="server"></asp:Label>
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
<<<<<<< HEAD

    </div></div>
=======
        </fieldset>
    </div>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7

</asp:Content>
