<%@ Page Title="سياسة التسعير" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebPrices.aspx.cs" Inherits="ACC.WebPrices" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <div class="card-header">
            <h4 class="card-title">
        <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Blue"
            Text="سياسة التسعير"></asp:Label></h4>
            </div>
        <div class="card-body box box-info" align="right">
            <div class="body">
                <div class="row">
                    <!--Ankur kumar-->
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="العميل"></asp:Label>

                                <asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                                </asp:DropDownList>

                                <a id="NewVer" runat="server" href='<%= string.Format("WebPrices2.aspx?AreaNo={0}&StoreNo={1}&Customer={2}&Level={3}&City={4}",AreaNo,StoreNo,ddlCustomer.SelectedValue,ddlLevel.SelectedValue,ddlCity.SelectedValue) %>'>المطور												<i class="fa fa-files-o"></i></a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="مستوى التسعير"></asp:Label>

                                <asp:DropDownList ID="ddlLevel" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="المدينة"></asp:Label>

                                <asp:DropDownList ID="ddlCity" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="FromCode,ToCode" AllowPaging="True"
                            PageSize="30" Width="100%" OnRowUpdating="grdCodes_RowUpdating" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowCommand="grdCodes_RowCommand"
                            OnRowDeleting="grdCodes_RowDeleting" OnRowEditing="grdCodes_RowEditing" OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                        <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="تعديل بيانات البند"
                                            ImageUrl="~/images/pencil.png" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="حفظ التعديلات"
                                            ImageUrl="~/images/accept.png" OnLoad="btnUpdate_Load" />
                                        <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="تجاهل التعديلات"
                                            ImageUrl="~/images/delete.png" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="اضافة سعر مسار جديد"
                                            ImageUrl="~/images/add.png" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFromCode2" Text='<%# Bind("FromCode2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlFromCode2" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ControlStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblToCode2" Text='<%# Bind("ToCode2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlToCode2" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ControlStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المسافة كم" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblKMeter" Text='<%# Eval("KMeter","{0:N0}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtKMeter" Text='<%# Bind("KMeter") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValKMeter" runat="server" ControlToValidate="txtKMeter"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtKMeter2" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValKMeter2" runat="server" ControlToValidate="txtKMeter2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="زمن الوصول" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFTime" Text='<%# Bind("FTime") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtFTime" Text='<%# Bind("FTime") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValFTime" runat="server" ControlToValidate="txtFTime"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtFTime2" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValFTime2" runat="server" ControlToValidate="txtFTime2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="سعر الذهاب" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHOneWay" Text='<%# Bind("HOneWay") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtHOneWay" Text='<%# Bind("HOneWay") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValHOneWay" runat="server" ControlToValidate="txtHOneWay"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtHOneWay2" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValHOneWay2" runat="server" ControlToValidate="txtHOneWay2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الادنى للذهاب" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLOneWay" Text='<%# Eval("LOneWay","{0:N0}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLOneWay" Text='<%# Bind("LOneWay") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValLOneWay" runat="server" ControlToValidate="txtLOneWay"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtLOneWay2" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValLOneWay2" runat="server" ControlToValidate="txtLOneWay2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="سعر ذهاب وعوده" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHTwoWay" Text='<%# Eval("HTwoWay","{0:N0}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtHTwoWay" Text='<%# Bind("HTwoWay") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValHTwoWay" runat="server" ControlToValidate="txtHTwoWay"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtHTwoWay2" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValHToWay2" runat="server" ControlToValidate="txtHTwoWay2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الادنى ذهاب وعوده" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLTwoWay" Text='<%# Eval("LTwoWay","{0:N0}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLTwoWay" Text='<%# Bind("LTwoWay") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValLTwoWay" runat="server" ControlToValidate="txtLTwoWay"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtLTwoWay2" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValLTwoWay2" runat="server" ControlToValidate="txtLTwoWay2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="سطحة عادي" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEPrice1" Text='<%# Eval("ExPrice1","{0:N0}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEPrice1" Text='<%# Bind("ExPrice1") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValEPrice1" runat="server" ControlToValidate="txtEPrice1"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtE21Price" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValE21Price" runat="server" ControlToValidate="txtE21Price"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="هيدروليك" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEPrice2" Text='<%# Eval("ExPrice2","{0:N0}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEPrice2" Text='<%# Bind("ExPrice2") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValEPrice2" runat="server" ControlToValidate="txtEPrice2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtE22Price" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValE22Price" runat="server" ControlToValidate="txtE22Price"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="هيدروليك مغطى" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEPrice3" Text='<%# Eval("ExPrice3","{0:N0}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEPrice3" Text='<%# Bind("ExPrice3") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValEPrice3" runat="server" ControlToValidate="txtEPrice3"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtE23Price" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValE23Price" runat="server" ControlToValidate="txtE23Price"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="المصروف" Visible="false" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostAmount" Text='<%# Eval("CostAmount","{0:N0}") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCostAmount" Text='<%# Bind("CostAmount") %>' runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValCostAmount" runat="server" ControlToValidate="txtCostAmount"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtCostAmount2" runat="server" CssClass="form-control" />
                                        <asp:CompareValidator ID="ValCostAmount2" runat="server" ControlToValidate="txtCostAmount2"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                            Type="Currency">*</asp:CompareValidator>
                                    </FooterTemplate>
                                    <ControlStyle Width="50px" />
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
            </div>
        </div>
    </div>

</asp:Content>
