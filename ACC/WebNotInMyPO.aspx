<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebNotInMyPO.aspx.cs" Inherits="ACC.WebNotInMyPO" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="form card">

                <fieldset class="text-center">
                    <div class="form-group">
                        <h4 class="text-muted">
                            سندات صرف لم تدرج في طلب دفع
                        </h4>
                    </div>
                    <hr />
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label2" runat="server" Text="الفرع"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:DropDownList ID="ddlBranch" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlBranch_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-4"></div>
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
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
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
                        <div class="form-group col-sm-2"></div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2"></div>
                    </div>

                  <hr />
                </fieldset>
            <br />
            <br />
                <div class="form text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="سند الصرف" SortExpression="VouNo2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:HyperLink ID="lblVouNo2" Text='<%# Eval("VouNo2") %>' NavigateUrl='<%# UrlHelper("1" ,Eval("VouNo2"))%>' Target="_blank" runat="server"></asp:HyperLink> 
                                    </div>
                                    
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblFDate" Text='<%# Eval("FDate") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalFDate" Text="الاجمالي" runat="server"></asp:Label>
                                    </div>
                                    
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاجمالي" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblAmount" Text='<%# Eval("Amount","{0:N0}") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalAmount" Text='<%# TotalAmount %>' runat="server"></asp:Label>
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
                
        </div>
</asp:Content>
