<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"
    CodeBehind="WebBranch.aspx.cs" Inherits="ACC.WebBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center style="direction: rtl">
        <div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                <asp:Label ID="lblHead" runat="server" Text="[ بيانات الفروع ]" meta:resourcekey="lblHead"></asp:Label>
                    </b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="100%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="LblCode" runat="server" Text="كود الفرع" meta:resourcekey="LblCode"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtNumber" Width="100px" runat="server" MaxLength="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValNumber" runat="server" ControlToValidate="txtNumber"
                                    ErrorMessage="<%$ Resources: EnterCode %>" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 70px;">
                            </td>
                            <td style="width: 300px;">
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="Label2" runat="server" Text="الاسم عربي" meta:resourcekey="Label2"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtName1" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي" meta:resourcekey="Label3"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtName2" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="Label4" runat="server" Text="المدير المسئول" meta:resourcekey="Label4"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtManager" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label5" runat="server" Text="العنوان" meta:resourcekey="Label5"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="Label8" runat="server" Text="رقم التليفون" meta:resourcekey="Label8"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtTel" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label32" runat="server" Text="ملاحظات" meta:resourcekey="Label32"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                            </td>
                            <td style="width: 300px;">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            </td>
                            <td style="width: 70px;">
                            </td>
                            <td style="width: 300px;">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="<%$ Resources: New %>" CommandName="New"
                                    ImageUrl="<%$ Resources: NewImage %>"   ToolTip="<%$ Resources: NewTooltip %>"
                                    ValidationGroup="1" OnClientClick='<%$ Resources: NewConfirm %>'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="<%$ Resources: Edit %>" CommandName="Edit"
                                    ImageUrl="<%$ Resources: EditImage %>"   ToolTip="<%$ Resources: EditTooltip %>"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="<%$ Resources: Clear %>" CommandName="Clear"
                                    ImageUrl="<%$ Resources:ClearImage %>"   ToolTip="<%$ Resources: ClearTooltip %>"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="<%$ Resources: Delete %>" CommandName="Delete"
                                    ImageUrl="<%$ Resources: DeleteImage %>"   ToolTip="<%$ Resources: DeleteTooltip %>" OnClientClick='<%$ Resources: DeleteConfirm %>'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="<%$ Resources: Search %>" CommandName="Find"
                                    ImageUrl="<%$ Resources: SearchImage %>"   ToolTip="<%$ Resources: SearchTooltip %>"
                                    OnClick="BtnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                    <div style="width: 100%; overflow:none; overflow-x:auto ; border: 1px solid #800000;">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="number" AllowPaging="True"
                            PageSize="5" Width="99.9%" EmptyDataText="<%$ Resources: NoData %>" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" ToolTip="<%$ Resources: SelectBranch %>"
                                            CommandName="Select" ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources: LblCode.Text %>" SortExpression="number" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnumber" Text='<%# Bind("number") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources: Label2.Text %>" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="300px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources: Label3.Text %>" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="300px" />
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
                    <br />
                </center>
            </fieldset>
        </div>
    </center>
    <br />
</asp:Content>
