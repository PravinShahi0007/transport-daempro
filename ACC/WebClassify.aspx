<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"
    CodeBehind="WebClassify.aspx.cs" Inherits="ACC.WebClassify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       
            <div class="col-md-12  col-sm-12 col-xs-12">
                <asp:LinkButton ID="LbtnLevel1" runat="server" CssClass="text-center form-control" CommandName="1" Text="أنواع الأصناف"
                    Visible="true" OnCommand="LbtnLevel1_Command" Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel2" runat="server" CommandName="2" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel3" runat="server" CommandName="3" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel4" runat="server" CommandName="4" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel5" runat="server" CommandName="5" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
               <div class="table table-responsive table-hover text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FCode;Code" 
                        AllowPaging="True" Width="100%" OnRowUpdating="grdCodes_RowUpdating" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowCommand="grdCodes_RowCommand"
                        OnRowDeleting="grdCodes_RowDeleting" OnRowEditing="grdCodes_RowEditing" 
                        OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="إختيار البند"
                                        ImageUrl="~/images/arrow_undo.png" />
                                    <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="تعديل البند"
                                        ImageUrl="~/images/pencil.png" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="حفظ التعديلات"
                                        ImageUrl="~/images/accept.png" onload="btnUpdate_Load" />
                                    <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="تجاهل التعديلات"
                                        ImageUrl="~/images/delete.png" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="أضافة بند جديد"
                                        ImageUrl="~/images/add.png" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوصف بالعربي" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName1" Text='<%# Bind("Name1") %>' runat="server" CssClass="form-control" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName1" runat="server" CssClass="form-control" />
                                </FooterTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوصف بالانجليزي" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName2" Text='<%# Bind("Name2") %>' runat="server" CssClass="form-control" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName2" runat="server" CssClass="form-control" />
                                </FooterTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="النوع" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFype" Text='<%# Bind("ftype2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="dllFType2" runat="server" CssClass="form-control" EnableViewState="false"
                                        OnInit="dllFType2_Init">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlFType" runat="server" CssClass="form-control" />
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
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
              
           
       
    </div>
</asp:Content>
