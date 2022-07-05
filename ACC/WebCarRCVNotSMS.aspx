<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebCarRCVNotSMS.aspx.cs" Inherits="ACC.WebCarRCVNotSMS" Culture="auto:ar-EG"
    UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset class="card">
        <div class="card-header">
            <h4>[
                <asp:Literal ID="Literal2" Text="متابعة رسائل الوصول" runat="server"></asp:Literal>
                ]</h4></div>
        <div class="card-body table table-responsive table-hover text-center">
        <asp:GridView ID="grdDCars" CellPadding="4" AutoGenerateColumns="False" runat="server"
            AllowPaging="false" ForeColor="#333333" GridLines="None" PageSize="200" DataKeyNames="FNo"
            Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblFNo2" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="50px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="الفاتورة" SortExpression="InvNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblInvoice" Text='<%# Eval("InvNo").ToString() + "<br/>" + Eval("InvDate").ToString() +"<br/>"+ Eval("InvTime").ToString()  %>'
                            ToolTip="عرض الفاتورة" NavigateUrl='<%# UrlHelper("3" ,Eval("InvNo"))%>' Target="_blank"
                            runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="95px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="بيان الترحيل" SortExpression="CarMoveNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblCarMove" Text='<%# Eval("CarMoveNo").ToString() + "<br/>" + Eval("CarMoveDate").ToString() + "<br/>" + Eval("CarMoveTime").ToString()  %>'
                            ToolTip="عرض بيان الترحيل" NavigateUrl='<%# UrlHelper("1" ,Eval("CarMoveNo"))%>'
                            Target="_blank" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="95px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="بيان الوصول" SortExpression="CarMoveRCVNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblCarMoveRCV" Text='<%# Eval("CarMoveRCVNo").ToString() + "<br/>" + Eval("GDate").ToString() + "<br/>" + Eval("FTime").ToString() %>'
                            ToolTip="عرض بيان الوصول" NavigateUrl='<%# UrlHelper("2" ,Eval("CarMoveRCVNo"))%>'
                            Target="_blank" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="95px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="أسم المرسل" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSender" Text='<%# Eval("Name") + "<br/>" + Eval("MobileNo").ToString() %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="150px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="أسم المرسل اليه" SortExpression="RecName" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRecName" Text='<%# Eval("RecName") + "<br/>" + Eval("RecMobileNo").ToString() %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="150px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" SortExpression="Status" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton  ID="Image2" runat="server" ToolTip="أضغط هنا لأعادة ارسال الرسالة للعميل"  AutoPostBack="true"
                            ImageUrl='<%# Eval("Status").ToString().Equals("1") ? "~/images/accept.png" : "~/images/Cross.png" %>'
                            OnClick="Image2_Click" />
                    </ItemTemplate>
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
            </div>
    </fieldset>
</asp:Content>
