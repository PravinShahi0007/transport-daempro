<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCoin.aspx.cs" Inherits="ACC.WebCoin" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <div class="Round4Courner" style="width: 98%">
                <center>
                    <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="العملات"></asp:Label></center>
                <div style="width: 100%; overflow:none; overflow-x:auto ; text-align:center; background-image: linear-gradient(to right, #185fb2 , #f97d29);">
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="Code" 
                        AllowPaging="True" Width="99.9%" OnRowUpdating="grdCodes_RowUpdating" OnPageIndexChanging="grdCodes_PageIndexChanging"
                    OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowCommand="grdCodes_RowCommand"
                    OnRowDeleting="grdCodes_RowDeleting" OnRowEditing="grdCodes_RowEditing" 
                        OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        
                        <asp:TemplateField HeaderText="الوصف بالعربي" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName1" Text='<%# Bind("Name1") %>' runat="server" CssClass="form-control" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtName1" runat="server" placeholder="الوصف باللغة العربية" CssClass="form-control" />
                            </FooterTemplate>
                            <ControlStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الوصف بالانجليزي" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName2" Text='<%# Bind("Name2") %>' runat="server" CssClass="form-control" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtName2" runat="server" placeholder="الوصف باللغة الإنجليزية" CssClass="form-control" />
                            </FooterTemplate>
                            <ControlStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الوصف باللغة الإنجليزية" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblFdate" Text='<%# Bind("Fdate") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFdate" Text='<%# Bind("Fdate") %>' runat="server" CssClass="form-control" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtFdate" runat="server" placeholder="تاريخ التقييم" CssClass="form-control" />
                            </FooterTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="سعر التحويل" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblChrate" Text='<%# Bind("Chrate") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtChrate" Text='<%# Bind("Chrate") %>' runat="server" CssClass="form-control" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtChrate" runat="server" placeholder="سعر الصرف" CssClass="form-control" />
                            </FooterTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="شكل العملة" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblShape" Text='<%# Bind("Shape") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtShape" Text='<%# Bind("Shape") %>' runat="server" CssClass="form-control" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtShape" placeholder="شكل العملة" CssClass="form-control" runat="server" />
                            </FooterTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء العملة"
                                    ImageUrl="~/images/DELETE1.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="اختيار العملة"
                                    ImageUrl="~/images/SELECT1.png" />
                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="تعديل بيانات العملة"
                                    ImageUrl="~/images/EDIT1.png" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="حفظ التعديلات"
                                    ImageUrl="~/images/accept.png" onload="btnUpdate_Load" />
                                <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="تجاهل التعديلات"
                                    ImageUrl="~/images/delete.png" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="اضافة عملة جديدة"
                                    ImageUrl="~/images/ADD1.png" />
                                <asp:Label ID="Label2" runat="server" Text="Insert"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                        HorizontalAlign="Center" />
                    <HeaderStyle Font-Bold="True" ForeColor="White" />
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
            </div>
        </center>
    </div>
</asp:Content>

