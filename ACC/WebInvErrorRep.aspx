<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebInvErrorRep.aspx.cs" Inherits="ACC.WebInvErrorRep" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="box box-info card" align="right">
        <div class="card-header">
            <h4>مراقبة تحصيل الفواتير</h4>
        </div>

        
            <div class="card-body">
                <div class="form-row">
                    <div class="form-group col-md-4 col-sm-12 col-xm-12">


                        <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                            ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                        <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                            OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                        <asp:ImageButton ID="BtnExcel" Visible="false" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"
                            ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                            OnClick="BtnExcel_Click" />
                    </div>
                    <div class="form-group col-md-4 col-sm-12 col-xs-12">

                        <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>

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
                    <div class="form-group col-md-4 col-sm-12 col-xs-12">

                        <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>

                        <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                    </div>
                </div>

                <div class="table table-responsive table-hover text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الفاتورة" SortExpression="InvNo2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblInvNo" Text='<%# Eval("InvNo2") %>' NavigateUrl='<%# UrlHelper("1" ,Eval("InvNo2"))%>' Target="_blank" runat="server"></asp:HyperLink>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lbltot" Text="الاجمالي" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الفاتورة" SortExpression="GDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblGDate" Text='<%# Bind("GDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="آجل فرع" SortExpression="SiteAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSiteAmount" Text='<%# Eval("SiteAmount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalSiteAmount" Text='<%# TotalSiteAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عملاء" SortExpression="CustomerAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerAmount" Text='<%# Eval("CustomerAmount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalCustomerAmount" Text='<%# TotalCustomerAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <%--                            <asp:TemplateField HeaderText="سند القبض" SortExpression="VouNo2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblVouNo" Text='<%# Eval("VouNo2") %>' NavigateUrl='<%# UrlHelper("2" ,Eval("VouNo2"))%>' Target="_blank" runat="server"></asp:HyperLink> 
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            --%>
                            <asp:TemplateField HeaderText="قيمة التسوية" SortExpression="JvAmount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblJvAmount" Text='<%# Eval("JvAmount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalJvAmount" Text='<%# TotalJvAmount %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الفرق" SortExpression="Diff" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiff" Text='<%# Eval("Diff","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalDiff" Text='<%# TotalDiff %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سندات التسوية" SortExpression="CustomerName" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerName" Text='<%# Eval("CustomerName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
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

