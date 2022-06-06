<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebOpenBalances.aspx.cs" Inherits="ACC.WebOpenBalances" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Round4Courner" style="width: 99%">
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
            border: solid 2px #800000">
            <legend id="leg1" runat="server" align="<%$ Resources:Resource, dir2 %>" style="font-size: 18px;
                color: #800000; text-align: center;"><b>
                    <asp:Literal ID="Literal2" Text="Inventory Data Entry" runat="server"></asp:Literal>
                    <!-- [ بيانات الأصناف ] -->
                </b></legend>
            <br />
            <center>
                <table width="100%" cellpadding="2px">
                    <tr>
                        <td style="width: 100px;">
                            <asp:Label ID="Label22" runat="server" Text="Select Store:"></asp:Label>
                        </td>
                        <td style="width: 250px;">
                            <asp:DropDownList ID="ddlStore" Width="250px" AutoPostBack="true" runat="server"
                                OnSelectedIndexChanged="ddlStore_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 200px;">
                        </td>
                        <td style="width: 200px;">
                        </td>
                    </tr>
                </table>
                <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="false" PageSize="2000"
                        DataKeyNames="Code" Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Item Code<br/>New Code<br/>Part No." SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label><br />
                                    <asp:TextBox ID="txtNCode" Text='<%# Bind("NCode") %>' MaxLength="20" runat="server"></asp:TextBox><br />
                                    <asp:TextBox ID="TxtITCode2" Text='<%# Bind("ITCode2") %>' MaxLength="20" runat="server"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description" SortExpression="ITName1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblITName1" Text='<%# Bind("ITName1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location" SortExpression="Loc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLoc" Text='<%# Bind("Loc") %>' MaxLength="20" runat="server"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance" SortExpression="IOpen" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIOpen" Text='<%# Bind("IOpen") %>' MaxLength="20" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="txtIOpen"
                                        Display="Dynamic" ErrorMessage="You Should Enter Numeric Value" ForeColor="Red" Enabled="false"
                                        Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost Price" SortExpression="ITCPrice" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtITCPrice" Text='<%# Bind("ITCPrice") %>' MaxLength="20" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator207" runat="server" ControlToValidate="txtITCPrice"
                                        Display="Dynamic" ErrorMessage="You Should Enter Numeric Value" ForeColor="Red" Enabled="false"
                                        Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
<%--                            <asp:TemplateField HeaderText="Expiry Date" SortExpression="OpenDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOpenDate" Text='<%# Bind("OpenDate") %>' MaxLength="10" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="ValOpenDate" runat="server" ControlToValidate="txtOpenDate"
                                        CultureInvariantValues="true" ErrorMessage="You Should Enter Date Value" ForeColor="Red"
                                        Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtOpenDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                        PopupPosition="BottomLeft" />
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
--%>                        </Columns>
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
                <br />
                <div class="DivButtons" style="width: 95%">
                    <table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="center">
                            <td style="width: 250px;">
                                &nbsp;
                            </td>
                            <td style="width: 250px;">
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_641.png" CssClass="ops" ToolTip="Edit Stock Item Inventory"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" 
                                    ImageUrl="~/images/print_64A.png" CssClass="ops"  OnClientClick="aspnetForm.target ='_blank';" 
                                    onclick="BtnPrint1_Click" />                                    
                            </td>
                            <td id="td1" runat="server" style="width: 250px; text-align: right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </center>
        </fieldset>
    </div>
</asp:Content>
