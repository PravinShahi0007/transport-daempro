<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="default3.aspx.cs" Inherits="ACC.default3" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="ProcessDiv" runat="server">
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[
                    <asp:Literal ID="Literal2" Text="<%$ Resources:Title %>" runat="server"></asp:Literal>
                    ]</b></legend>
            <div style="width: 100%; text-align: left;">
                <asp:LinkButton ID="BtnRefresh2" runat="server" ToolTip="<%$ Resources:CarRefresh %>"
                    OnClick="BtnRefresh2_Click"><i class='fa fa-refresh' style="color:Blue;" ></i></asp:LinkButton></div>
            <table>
                <tr>
                    <td style="width: 90px">
                        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Branch %>"></asp:Label>
                    </td>
                    <td style="width: 150px">
                        <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>

                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                            RepeatColumns="6" Width="500px">
                            <asp:ListItem Value="-1" Text="<%$ Resources:Month %>"></asp:ListItem>
                            <asp:ListItem Selected="True" Value="-3" Text="<%$ Resources:3Month %>"></asp:ListItem>
                            <asp:ListItem Value="-6" Text="<%$ Resources:6Month %>"></asp:ListItem>
                            <asp:ListItem Value="-12" Text="<%$ Resources:Year %>"></asp:ListItem>
                            <asp:ListItem Value="-24" Text="<%$ Resources:2Year %>"></asp:ListItem>
                            <asp:ListItem Value="-200" Text="<%$ Resources:All %>"></asp:ListItem>
                        </asp:RadioButtonList>

                    </td>
                </tr>
            </table>
            <asp:GridView ID="grdDCars" CellPadding="4" AutoGenerateColumns="False" runat="server" AllowPaging="false"
                ForeColor="#333333" GridLines="None" PageSize="200" DataKeyNames="FNo" Width="99.9%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFNo2" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Invoice %>" SortExpression="InvNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblInvoice" Text='<%# Eval("InvNo").ToString() + "<br/>" + Eval("InvDate").ToString() +"<br/>"+ Eval("InvTime").ToString()  %>' ToolTip="<%$ Resources:ViewInvoice %>" NavigateUrl='<%# UrlHelper("3" ,Eval("InvNo"))%>'
                                Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="95px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarMove %>" SortExpression="CarMoveNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMove" Text='<%# Eval("CarMoveNo").ToString() + "<br/>" + Eval("CarMoveDate").ToString() + "<br/>" + Eval("CarMoveTime").ToString()  %>' ToolTip="<%$ Resources:ViewCarMove %>" NavigateUrl='<%# UrlHelper("1" ,Eval("CarMoveNo"))%>'
                                Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="95px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="<%$ Resources:CarMoveRCV %>" SortExpression="CarMoveRCVNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMoveRCV" Text='<%# Eval("CarMoveRCVNo").ToString() + "<br/>" + Eval("GDate").ToString() + "<br/>" + Eval("FTime").ToString() %>' ToolTip="<%$ Resources:ViewCarMoveRCV %>" NavigateUrl='<%# UrlHelper("2" ,Eval("CarMoveRCVNo"))%>'
                                Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="95px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:PlateNo %>" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarNo" Text='<%# Eval("PlateNo").ToString() + "<br/>" + Eval("ChassisNo").ToString() %>' ToolTip="<%$ Resources:IssueCar %>" NavigateUrl='<%# UrlHelper("210" ,Eval("InvNo"))%>'
                                runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Sender %>" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblSender" Text='<%# Eval("Name") + "<br/>" + Eval("MobileNo").ToString() %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Receiver %>" SortExpression="RecName" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblRecName" Text='<%# Eval("RecName") + "<br/>" + Eval("RecMobileNo").ToString() %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Amount %>" SortExpression="SiteAmount2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblSiteAmount2" Text='<%# Eval("SiteAmount2") + "<br/>" + GetLandCost(Eval("GDate").ToString(),Eval("FTime").ToString())  %>' ToolTip="<%$ Resources:IssueRecVou %>" NavigateUrl='<%# UrlHelper("211" ,Eval("InvNo"))%>'
                                runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center"
                    Font-Bold="True" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:Panel ID="Panel4" runat="server" CssClass="popupControl">
            </asp:Panel>
        </fieldset>
</div>
</asp:Content>
