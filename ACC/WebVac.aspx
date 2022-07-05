<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebVac.aspx.cs" Inherits="ACC.WebVac" Culture="ar-EG" UICulture="ar-EG"  MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <center>
            <div class="card">
            <fieldset>
                
                <div class="card-header"><h4 class="card-title">
                    [ الاجازات الرسمية ]</h4></div>             
                <div class="card-body table-responsive">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" PageSize = "100"  
                        AllowPaging="True" Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnRowCommand="grdCodes_RowCommand" OnRowDeleting="grdCodes_RowDeleting">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="اضافة بند جديد"
                                        ImageUrl="~/images/add.png" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFDate" MaxLength="10" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الاجازة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" 
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                </FooterTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="البيان" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName" MaxLength="50" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="ValName" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="يجب أختيار بيان الاجازة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </FooterTemplate>
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
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                <br />
            </fieldset>
            </div>
        </center>
</asp:Content>
