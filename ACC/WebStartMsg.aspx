<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebStartMsg.aspx.cs" Inherits="ACC.WebStartMsg" Culture="ar-EG" UICulture="ar-EG"  MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            $("input[name*='grdCodes'],select[name*='grdCodes']").change(function (event) {
                $(this).addClass('ChangedText');
                $(this).ToolTip = '1';
            });
            SetMyStyle();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
      
            <div class="card">
                    <div class="box box-info card-body">
     <div class="body">
                                    <div class="row">
                                          <div class="col-md-6 col-sm-12 col-xs-12" align="center">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                    <asp:Label ID="Label1" runat="server"  Font-Size="Larger" meta:resourcekey="Label1"
                        Text=" البند"></asp:Label>
                   
                    <asp:DropDownList ID="ddlFtype" CssClass="form-control" runat="server" Width="250" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlFtype_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="1" Text="حسابات بنوك الناقلات البرية"></asp:ListItem>
                        <asp:ListItem Value="2" Text="حسابات بنوك الإدارة"></asp:ListItem>
                        <asp:ListItem Value="3" Text="حسابات بنوك مراقبي الفروع"></asp:ListItem>
                        <asp:ListItem Value="4" Text="حسابات بنوك الموردين"></asp:ListItem>
                        <asp:ListItem Value="5" Text="أرقام الاتصال "></asp:ListItem>
                        <asp:ListItem Value="6" Text="مواقع و بيانات الاتصال بالفروع"></asp:ListItem>
                    </asp:DropDownList>
                
              </div></div></div>
                <div class="table table-responsive table-hover text-center">
                    <asp:GridView ID="grdCodes" runat="server" CssClass="table table-hover"  ShowFooter="false" 
                        GridLines="None" AutoGenerateColumns="false" DataKeyNames="FType,FNo"  AllowPaging="false"
                        >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="البند 1" SortExpression="Fd1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFd1" MaxLength="100" Text='<%# Bind("Fd1") %>' runat="server" CssClass="form-control" />
                                </ItemTemplate>
                                <ControlStyle Width="175px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="البند 2" SortExpression="Fd2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFd2" MaxLength="1500" Text='<%# Bind("Fd2") %>' runat="server" CssClass="form-control" />
                                </ItemTemplate>
                                <ControlStyle Width="175px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="البند 3" SortExpression="Fd3" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFd3" MaxLength="100" Text='<%# Bind("Fd3") %>' runat="server" CssClass="form-control" />
                                </ItemTemplate>
                                <ControlStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="البند 4" SortExpression="Fd4" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFd4" MaxLength="100" Text='<%# Bind("Fd4") %>' runat="server" CssClass="form-control" />
                                </ItemTemplate>
                                <ControlStyle Width="175px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="البند 5" SortExpression="Fd5" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFd5" MaxLength="100" Text='<%# Bind("Fd5") %>' runat="server" CssClass="form-control" />
                                </ItemTemplate>
                                <ControlStyle Width="150px" />
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
                                           <div class="col-md-12 col-sm-12 col-xs-12 text-center">
              <asp:Label ID="LblCodesResult" runat="server" ></asp:Label>
               
                                    <asp:ImageButton ID="BtnEdit" runat="server" 
                    AlternateText="Edit" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" CssClass="ops" ToolTip="Edit Stock Item Inventory"
                                    Width="64px" onclick="BtnEdit_Click"/></div>
                                        </div></div></div>
                                
            </div>
        
</asp:Content>
