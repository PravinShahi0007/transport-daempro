<%@ Page Title="خطوط الرحلة" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebLines.aspx.cs" Inherits="ACC.WebLines" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            $('input,select').change(function () {
                $(this).addClass('ChangedText');
                $(this).ToolTip = '1';
            });
            SetMyStyle();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="" class="card">
            <fieldset class="card-body">
                <div class="card-header">
                    <h4 class="card-title">
                    <asp:Label ID="LblHeader" runat="server" Text="[ خط سير الرحلة ]"></asp:Label>
                    </h4>
                </div>
                <br />
         <div id="Table1" class="card-body">
             <div class="form-row" id="tr2">
             <div class="form-group col-md-2 col-sm-6 col-xs-12">
                 <asp:Label ID="Label2" runat="server" Text="من"></asp:Label>
             </div>
             <div class="form-group col-md-4 col-sm-6 col-xs-12">
                 <asp:DropDownList ID="ddlFromCity" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlFromCity_SelectedIndexChanged">
                                </asp:DropDownList>
             </div>
             <div class="form-group col-md-2 col-sm-6 col-xs-12">
                 <asp:Label ID="Label1" runat="server" Text="إلى"></asp:Label>
             </div>
             <div class="form-group col-md-4 col-sm-6 col-xs-12">
                 <asp:DropDownList ID="ddlToCity" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlFromCity_SelectedIndexChanged">
                                </asp:DropDownList>
             </div></div>
         </div>
                    
                    <div class="table table-responsive table-hover text-center">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                            PageSize="50" Width="99.9%" EmptyDataText="لا توجد بيانات">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من موقع" SortExpression="Area1" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtArea1" Text='<%# Bind("Area1") %>' MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى موقع" SortExpression="Area2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtArea2" Text='<%# Bind("Area2") %>' MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المسافة" SortExpression="KM" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtKM" Text='<%# Bind("KM") %>' MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="80" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المصروف" SortExpression="Cost" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCost" Text='<%# Bind("Cost") %>' MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="العميل" SortExpression="CustCode" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlCust" runat="server" CssClass="form-control" OnInit="ddlCust_Init" EnableViewState="false">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="250px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
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

                <div class="form-row" id="tr3">
                    <div class="form-group col-md-4 col-sm-6 col-xs-12"></div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png"   ToolTip="تعديل بيانات خط سير الرحلة"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                    </div>
                    <div class="form-group col-md-4 col-sm-6 col-xs-12">
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                    </div>
                </div>
                 
                    <br />
            </fieldset>
        </div>
</asp:Content>
