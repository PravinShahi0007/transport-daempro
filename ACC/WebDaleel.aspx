<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"
    CodeBehind="WebDaleel.aspx.cs" Inherits="ACC.WebDaleel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="card text-center">
                <fieldset class="form">
                    <div class="form-group text-center">
                        <h4>
                            تقرير دليل الحسابات
                        </h4>
                        <hr />
                    </div>
                    <br />
                    <div class="form-row">
                        <!--*********************************chanda verma******************************-->
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label2" runat="server" Text="المستوى"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlLevel" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                    <asp:ListItem Value="0">الجميـع</asp:ListItem>
                                    <asp:ListItem Value="1">المستوى 1</asp:ListItem>
                                    <asp:ListItem Value="2">المستوى 2</asp:ListItem>
                                    <asp:ListItem Value="3">المستوى 3</asp:ListItem>
                                    <asp:ListItem Value="4">المستوى 4</asp:ListItem>
                                    <asp:ListItem Value="5">المستوى 5</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label3" runat="server" Text="الحساب الرئيسي"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:DropDownList ID="ddlFather" CssClass="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-1">
                            <asp:CheckBox ID="chkCode" Text="كود الحساب" runat="server" AutoPostBack="true" OnCheckedChanged="chkCode_CheckedChanged" />
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                    
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"  
                                    ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlRecordsPerPage" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="-1">الكل</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                        </div>
                        <div class="form-group col-sm-4"></div>
                    </div>
                    <hr />
                </fieldset>
                <br />
                <div class="text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="100%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="كود الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوصف بالعربي" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوصف بالانجليزي" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="النوع" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblFype" Text='<%# Bind("ftype2") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                
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
                <div class="form-group">
                    <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                </div>
           
        </div>
</asp:Content>
