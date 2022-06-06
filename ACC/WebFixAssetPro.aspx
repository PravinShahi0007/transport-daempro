<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebFixAssetPro.aspx.cs" Inherits="ACC.WebFixAssetPro" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
        border: solid 2px #800000">
        <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
            [ تشغيل اهلاكات الاصول الثابتة ]</b></legend>
        <center>
            <br />
            <table dir="rtl" width="99%" cellpadding="2px">
                <tr align="center">
                    <td style="width: 120px">
                        <asp:Label ID="LblFDate" runat="server" Text="من تاريخ"></asp:Label>
                    </td>
                    <td style="width: 120px">
                        <asp:TextBox ID="txtFDate" MaxLength="10" Width="100px" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate" CultureInvariantValues="true"
                            Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                            ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                            TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                            PopupPosition="BottomLeft" />
                        <asp:RequiredFieldValidator ID="ValSType2" runat="server" ControlToValidate="txtFDate"
                            ForeColor="Red" InitialValue="0" SetFocusOnError="True" Display="Dynamic" ErrorMessage='يجب أختيار تاريخ بداية الفترة'
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 60px">
                    </td>
                    <td style="width: 120px">
                        <asp:Label ID="LblEDate" runat="server" Text="إلى تاريخ"></asp:Label>
                    </td>
                    <td style="width: 120px">
                        <asp:TextBox ID="txtEDate" MaxLength="10" Width="100px" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                            Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                            ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                            TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                            PopupPosition="BottomLeft" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEDate"
                            ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ErrorMessage='يجب أختيار تاريخ نهاية الفترة'
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 60px">
                    </td>
                    <td style="width: 120px">
                        <asp:Label ID="Label1" runat="server" Text="بداية القيود"></asp:Label>
                    </td>
                    <td style="width: 150px">
                            <asp:TextBox ID="txtStart" MaxLength="10" Width="100px" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStart"
                            ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ErrorMessage='يجب أدخل تاريخ بداية تسلسل قيود الاهلاك'
                            ValidationGroup="1">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                EnableClientScript="true" ShowSummary="true" />
            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
            <br />
            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                  ImageUrl="~/images/Refresh_642.png" ToolTip="تشغيل" OnClick="BtnProcess_Click" />
            <br />
            <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="true"
                GridLines="None" AutoGenerateColumns="False" AllowPaging="false"
                Width="99.9%" EmptyDataText="لا توجد بيانات">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="من تاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFDate" Text='<%# Eval("fDate","{0:d}") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="إلى تاريخ" SortExpression="TDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTDate" Text='<%# Eval("TDate","{0:d}") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="قيمة الاصل/الاضافة " SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblAmount" Text='<%# Eval("Amount","{0:N2}") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="النسبة" SortExpression="Per" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPer" Text='<%# Bind("Per") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الاهلاك" SortExpression="Total2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" Text='<%# Eval("Total","{0:N2}") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTot" Text='<%# Tot %>' runat="server"></asp:Label>
                        </FooterTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="صافي الاصل" SortExpression="Net2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNet2" Text='<%# Eval("Net2","{0:N2}") %>' runat="server"></asp:Label>
                        </ItemTemplate>
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
        </center>
            <asp:ImageButton ID="BtnPost" runat="server" Visible="false" AlternateText="ترحيل االقيد" ValidationGroup="1"
                  ImageUrl="~/images/Process.png" ToolTip="ترحيل االقيد" OnClick="BtnPost_Click" />
    </fieldset>
</asp:Content>
