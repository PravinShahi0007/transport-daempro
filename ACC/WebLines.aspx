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
    <center dir="rtl">
        <div style="" class="Round4Courner">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="LblHeader" runat="server" Text="[ خط سير الرحلة ]"></asp:Label>
                    </b></legend>
                <center>
                    <table id="Table1" dir="rtl" width="98%" cellpadding="2" style="color: Black">
                        <tr id="tr2" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label2" runat="server" Text="من"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlFromCity" Width="250" runat="server" 
                                    AutoPostBack="True" onselectedindexchanged="ddlFromCity_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" Text="إلى"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlToCity" Width="250" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlFromCity_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <div style="width: 100%; overflow: auto; border: 1px solid #800000;">
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
                                        <asp:TextBox ID="txtArea1" Text='<%# Bind("Area1") %>' MaxLength="50" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى موقع" SortExpression="Area2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtArea2" Text='<%# Bind("Area2") %>' MaxLength="50" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المسافة" SortExpression="KM" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtKM" Text='<%# Bind("KM") %>' MaxLength="15" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="80" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المصروف" SortExpression="Cost" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCost" Text='<%# Bind("Cost") %>' MaxLength="15" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="العميل" SortExpression="CustCode" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlCust" runat="server" OnInit="ddlCust_Init" EnableViewState="false">
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
                    <table width="98%" cellpadding="2">
                        <tr id="tr3" align="right">
                            <td style="width: 200px;">
                            </td>
                            <td style="width: 400px" align="center">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                            <td style="width: 200px;">
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="3">
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات خط سير الرحلة"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </center>
            </fieldset>
        </div>
    </center>
</asp:Content>
