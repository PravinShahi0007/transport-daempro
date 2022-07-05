<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" CodeBehind="WebPay1.aspx.cs" Inherits="ACC.WebPay1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<<<<<<< HEAD
    <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
            <h3 align="center">
                <asp:Label ID="lblHead" runat="server" Text="[ سند الصرف ]"></asp:Label>
            </h3>
=======
    <div class="ColorRounded4Corners col-md-10 col-md-offset-1 col-sm-12 col-xs-12">
        <fieldset class="Rounded4CornersNoShadow">
            <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                <asp:Label ID="lblHead" runat="server" Text="[ سند الصرف ]"></asp:Label>
            </b></legend>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
            <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
<<<<<<< HEAD
                                    <br />
=======
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:Label ID="lblStatus" runat="server" CssClass="blink" ForeColor="Red" Text=""></asp:Label>

                                    <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                        ToolTip="البحث عن بيانات سند الصرف" OnClick="BtnFind_Click" />
                                </div>
<<<<<<< HEAD
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label1" runat="server" Text="رقم السند"></asp:Label>

                                    <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                                    <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                        Display="Dynamic" ErrorMessage="يجب أختيار رقم السند" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>

                                    <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                        Display="Dynamic" ErrorMessage="يجب أختيار تاريخ السند" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                        ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtVouDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                        PopupPosition="BottomLeft" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <br />
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                        <asp:ListItem Value="2" Selected="True">بيان ترحيل</asp:ListItem>
                                        <%--<asp:ListItem Value="1">طلب دفع</asp:ListItem>--%>
                                        <asp:ListItem Value="3">مصروفات نثرية</asp:ListItem>
                                        <asp:ListItem Value="4">طلب شراء مواد</asp:ListItem>
                                        <asp:ListItem Value="5">أصلاح خارجي</asp:ListItem>
                                        <asp:ListItem Value="9">مصروفات نثرية 2</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="table-responsive table">
                            <div id="divGrid" runat="server" style="width: 100%; overflow: none; overflow-y: none; overflow-x: auto; border: 1px solid #800000;">
                                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                    Width="99.5%" EmptyDataText="لا توجد بيانات" OnRowCancelingEdit="grdCodes_RowCancelingEdit"
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
                                        <asp:TemplateField HeaderText="رقم المستند" SortExpression="VouNo2" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lblVouNo2" Text='<%# Eval("VouNo2") %>' NavigateUrl='<%# UrlHelper("1" ,Eval("VouNo2"))%>' Target="_blank" runat="server"></asp:HyperLink>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtVouNo2" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ControlStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="أسم المستلم/البيان" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="400px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="المبلغ" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" Text='<%# Eval("Amount","{0:N2}") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                        HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"
                                        BorderColor="#C7C7C7" />
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
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label4" runat="server" Text="الاجمالي"></asp:Label>

                                    <asp:TextBox ID="txtAmount" MaxLength="15" CssClass="form-control" ReadOnly="true" runat="server"
                                        AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount"
                                        Display="Dynamic" ErrorMessage="يجب إدخال مبلغ السند" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="ValDebit2" runat="server" ControlToValidate="txtAmount"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label11" runat="server" Text="وذلك عن"></asp:Label>

                                    <asp:TextBox ID="txtRemark" MaxLength="150" Height="100px" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label12" runat="server" Text="فرق مصروف"></asp:Label>

                                    <asp:TextBox ID="txtDiscount" MaxLength="10" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDiscount"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblChqDate" runat="server" Visible="false" Text="تاريخ الشيك"></asp:Label>

                                    <asp:TextBox ID="txtChqDate" MaxLength="10" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtChqDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                        PopupPosition="BottomLeft" />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtChqDate"
                                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                        ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label7" runat="server" Text="الصافي"></asp:Label>

                                    <asp:TextBox ID="txtNet" CssClass="form-control" MaxLength="10" ReadOnly="true" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="ChkCheque" Visible="false" Text="بشيك" runat="server" AutoPostBack="True" OnCheckedChanged="ChkCheque_CheckedChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblChqNo" runat="server" Visible="false" Text="رقم الشيك"></asp:Label>

                                    <asp:TextBox ID="txtchqNo" Visible="false" MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">

                                    <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>

                                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop form-control"
                                        Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>

                                    <asp:TextBox ID="txtUserDate" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop form-control"
                                        Enabled="false">                                                               
                                    </asp:TextBox>
                                    <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblBankName" runat="server" Visible="false" Text="مسحوب على بنك"></asp:Label>

                                    <asp:TextBox ID="txtBankName" MaxLength="50" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="form-group">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>

                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
=======
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
<<<<<<< HEAD


                                    <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                        ImageUrl="~/images/data add.png" ToolTip="أضافة سند جديد"
                                        ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السند؟")'
                                        OnClick="BtnNew_Click" />
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                        ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات السند"
                                        Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                    <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                        ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة"
                                        OnClick="BtnClear_Click" />
                                    <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                        ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات السند" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات السند؟")'
                                        OnClick="BtnDelete_Click" />
                                    <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                        ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات السند"
                                        OnClick="BtnSearch_Click" />
                                    <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                        ImageUrl="~/images/print.png" ValidationGroup="1" ToolTip="طباعة السند"
=======
                                    <asp:Label ID="Label1" runat="server" Text="رقم السند"></asp:Label>

                                    <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                                    <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                        Display="Dynamic" ErrorMessage="يجب أختيار رقم السند" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>

                                    <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                        Display="Dynamic" ErrorMessage="يجب أختيار تاريخ السند" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                        ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtVouDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                        PopupPosition="BottomLeft" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                        <asp:ListItem Value="2" Selected="True">بيان ترحيل</asp:ListItem>
                                        <%--<asp:ListItem Value="1">طلب دفع</asp:ListItem>--%>
                                        <asp:ListItem Value="3">مصروفات نثرية</asp:ListItem>
                                        <asp:ListItem Value="4">طلب شراء مواد</asp:ListItem>
                                        <asp:ListItem Value="5">أصلاح خارجي</asp:ListItem>
                                        <asp:ListItem Value="9">مصروفات نثرية 2</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="table-responsive">
                            <div id="divGrid" runat="server" style="width: 100%; overflow: none; overflow-y: none; overflow-x: auto; border: 1px solid #800000;">
                                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                    Width="99.5%" EmptyDataText="لا توجد بيانات" OnRowCancelingEdit="grdCodes_RowCancelingEdit"
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
                                        <asp:TemplateField HeaderText="رقم المستند" SortExpression="VouNo2" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lblVouNo2" Text='<%# Eval("VouNo2") %>' NavigateUrl='<%# UrlHelper("1" ,Eval("VouNo2"))%>' Target="_blank" runat="server"></asp:HyperLink>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtVouNo2" runat="server"></asp:TextBox>
                                            </FooterTemplate>
                                            <ControlStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="أسم المستلم/البيان" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="400px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="المبلغ" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" Text='<%# Eval("Amount","{0:N2}") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                        HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"
                                        BorderColor="#C7C7C7" />
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
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label4" runat="server" Text="الاجمالي"></asp:Label>

                                    <asp:TextBox ID="txtAmount" MaxLength="15" CssClass="form-control" ReadOnly="true" runat="server"
                                        AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount"
                                        Display="Dynamic" ErrorMessage="يجب إدخال مبلغ السند" ForeColor="Red" SetFocusOnError="True"
                                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="ValDebit2" runat="server" ControlToValidate="txtAmount"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label11" runat="server" Text="وذلك عن"></asp:Label>

                                    <asp:TextBox ID="txtRemark" MaxLength="150" Height="100px" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label12" runat="server" Text="فرق مصروف"></asp:Label>

                                    <asp:TextBox ID="txtDiscount" MaxLength="10" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDiscount"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblChqDate" runat="server" Visible="false" Text="تاريخ الشيك"></asp:Label>

                                    <asp:TextBox ID="txtChqDate" MaxLength="10" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                        TargetControlID="txtChqDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                        PopupPosition="BottomLeft" />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtChqDate"
                                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                        ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label7" runat="server" Text="الصافي"></asp:Label>

                                    <asp:TextBox ID="txtNet" CssClass="form-control" MaxLength="10" ReadOnly="true" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="ChkCheque" Visible="false" Text="بشيك" runat="server" AutoPostBack="True" OnCheckedChanged="ChkCheque_CheckedChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblChqNo" runat="server" Visible="false" Text="رقم الشيك"></asp:Label>

                                    <asp:TextBox ID="txtchqNo" Visible="false" MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblBankName" runat="server" Visible="false" Text="مسحوب على بنك"></asp:Label>

                                    <asp:TextBox ID="txtBankName" MaxLength="50" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>

                                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop form-control"
                                        Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>

                                    <asp:TextBox ID="txtUserDate" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop form-control"
                                        Enabled="false">                                                               
                                    </asp:TextBox>
                                    <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>

                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />

                                    <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                        ImageUrl="~/images/insource_642.png" ToolTip="أضافة سند جديد"
                                        ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السند؟")'
                                        OnClick="BtnNew_Click" />
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                        ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات السند"
                                        Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                    <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                        ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة"
                                        OnClick="BtnClear_Click" />
                                    <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                        ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات السند" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات السند؟")'
                                        OnClick="BtnDelete_Click" />
                                    <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                        ImageUrl="~/images/binoculars_642.png" ToolTip="البحث عن بيانات السند"
                                        OnClick="BtnSearch_Click" />
                                    <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                        ImageUrl="~/images/print_64A.png" ValidationGroup="1" ToolTip="طباعة السند"
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                        OnClick="BtnPrint_Click" />
                                </div>
                            </div>
                        </div>
<<<<<<< HEAD
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="form-row">
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h4 class="card-title">المرفقات
                                            <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                            </h4>
                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                                    <i class="fas fa-minus"></i>
                                                </button>
                                            </div>
                                        </div>
                                        <div class="card-body" style="display: none;">
                                            <asp:Panel ID="Panel2" runat="server">
                                                <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                                                    BorderColor="Maroon">
                                                    <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                                                        ShowHeader="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                                        Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء الملف"
                                                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء الملف؟")' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="الملف" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="lblFileName" Text='<%# Bind("FileName") %>' NavigateUrl='<%# Bind("FileName2") %>'
                                                                        Target="_blank" runat="server"></asp:HyperLink>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="300px" />
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                    </asp:GridView>

                                                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                                        SuppressPostBack="true" />
                                                </asp:Panel>

                                                <div class="form-row">
                                                    <div class="form-group col-sm-6 col-xs-12">
                                                        <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                                                    </div>
                                                    <div class="form-group col-sm-6 col-xs-12">
                                                        <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                            ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                                            ValidationGroup="1" />
                                                    </div>
                                                </div>

                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h4 class="card-title">تتبع عمليات المستخدم
                                            <asp:Label ID="Label16" runat="server">(عرض التفاصيل)</asp:Label>
                                            </h4>
                                            <div class="card-tools">
                                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                                    <i class="fas fa-minus"></i>
                                                </button>
                                            </div>
                                        </div>
                                        <div class="card-body" style="display: none;">
                                            <%--<asp:Panel ID="Panel5" runat="server">
                                       
                                    </asp:Panel>--%>
                                            <asp:Panel ID="Panel6" runat="server">
                                                <div class="table-responsive table text-center">
                                                    <asp:GridView ID="grdTrans" runat="server" CellPadding="4" ForeColor="#333333"
                                                        AllowPaging="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="UserDate2"
                                                        Width="99%" OnSelectedIndexChanging="grdTrans_SelectedIndexChanging">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="أختيار العملية و عرض تفاصيلها"
                                                                        ImageUrl="~/images/arrow_undo.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="التاريخ والوقت" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserDate" Text='<%# Bind("UserDate2") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="125px" />
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="المستخدم" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="125px" />
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="الإجراء" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="OPName" Text='<%# Bind("OPName") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="50px" />
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <EditRowStyle BackColor="#999999" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
                                                <ajax:CollapsiblePanelExtender ID="cpeDemo2" runat="Server" TargetControlID="Panel6"
                                                    ExpandControlID="Panel5" CollapseControlID="Panel5" Collapsed="True" TextLabelID="Label16"
                                                    ImageControlID="Img16" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                                    ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                                    SuppressPostBack="true" />
                                            </asp:Panel>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--editing by chanda verma-->
                        <div class="form-row">
                            <div class="form-group col-md-12 col-sm-12 col-xm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h4 class="card-title">التوجيه  المحاسبي
                               <asp:Label ID="Label6" runat="server">(عرض التفاصيل)</asp:Label>
                                        </h4>
                                        <div class="card-tools">
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>
                                        </div>
                                    </div>
                                    <div class="card-body" style="display: none;">
                                        <!--editing by chanda verma-->
                                        <asp:Panel ID="Panel3" runat="server">
                                            <asp:Panel ID="Panel4" runat="server">
                                                <table class="table  table-responsive table-hover">
                                                    <tr>
                                                        <td align="center" style="width: 125px;">
                                                            <asp:Label ID="Label10" runat="server" Text="النقدية/البنك"></asp:Label>
                                                            *
                                                        </td>
                                                        <td align="center" style="width: 300px;">
                                                            <asp:DropDownList ID="ddlDbCode" CssClass="form-control" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDbCode"
                                                                InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب النقدية/البنك"
                                                                ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 125px;">
                                                            <asp:Label ID="Label3" runat="server" Text="المنطقة"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 300px;">
                                                            <asp:DropDownList ID="ddlArea" CssClass="form-control" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 125px;">
                                                            <asp:Label ID="Label13" runat="server" Text="الفرع"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 300px;">
                                                            <asp:DropDownList ID="ddlCostCenter" CssClass="form-control" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 125px;">
                                                            <asp:Label ID="Label5" runat="server" Text="المشروع"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 300px;">
                                                            <asp:DropDownList ID="ddlProject" CssClass="form-control" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 125px;">
                                                            <asp:Label ID="Label8" runat="server" Text="حساب التكاليف"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 300px;">
                                                            <asp:DropDownList ID="ddlCostAcc" CssClass="form-control" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 125px;">
                                                            <asp:Label ID="Label17" runat="server" Text="الموظف"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 300px;">
                                                            <asp:DropDownList ID="ddlEmp" CssClass="form-control" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 125px;">
                                                            <asp:Label ID="Label9" runat="server" Text="الشاحنة"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 300px;">
                                                            <asp:DropDownList ID="ddlCarNo" CssClass="form-control" runat="server" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" TargetControlID="Panel4"
                                                    ExpandControlID="Panel3" CollapseControlID="Panel3" Collapsed="True" TextLabelID="Label6"
                                                    ImageControlID="ImageButton1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                                    ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                                    SuppressPostBack="true" />
                                            </asp:Panel>
                                        </asp:Panel>
                                        <!--editing by chanda verma-->
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--editing by chanda verma-->

                    </div>
                </div>
            </div>


=======

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات
                                            </div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                                        BorderColor="Maroon">
                                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                                            ShowHeader="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء الملف"
                                                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء الملف؟")' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="الملف" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="lblFileName" Text='<%# Bind("FileName") %>' NavigateUrl='<%# Bind("FileName2") %>'
                                                            Target="_blank" runat="server"></asp:HyperLink>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="300px" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        </asp:GridView>
                                        <table width="100%">
                                            <tr>
                                                <td align="right">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">

                                    <asp:Panel ID="Panel3" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                التوجيه المحاسبي
                                            </div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="Label6" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel4" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                                        BorderColor="#5D7B9D">
                                        <table width="99%" cellpadding="3" cellspacing="0">
                                            <tr>
                                                <td align="center" style="width: 125px;">
                                                    <asp:Label ID="Label10" runat="server" Text="النقدية/البنك"></asp:Label>
                                                    *
                                                </td>
                                                <td align="center" style="width: 300px;">
                                                    <asp:DropDownList ID="ddlDbCode" Width="250px" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDbCode"
                                                        InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب النقدية/البنك"
                                                        ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 125px;">
                                                    <asp:Label ID="Label3" runat="server" Text="المنطقة"></asp:Label>
                                                </td>
                                                <td align="center" style="width: 300px;">
                                                    <asp:DropDownList ID="ddlArea" Width="250px" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 125px;">
                                                    <asp:Label ID="Label13" runat="server" Text="الفرع"></asp:Label>
                                                </td>
                                                <td align="center" style="width: 300px;">
                                                    <asp:DropDownList ID="ddlCostCenter" Width="250px" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 125px;">
                                                    <asp:Label ID="Label5" runat="server" Text="المشروع"></asp:Label>
                                                </td>
                                                <td align="center" style="width: 300px;">
                                                    <asp:DropDownList ID="ddlProject" Width="250px" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 125px;">
                                                    <asp:Label ID="Label8" runat="server" Text="حساب التكاليف"></asp:Label>
                                                </td>
                                                <td align="center" style="width: 300px;">
                                                    <asp:DropDownList ID="ddlCostAcc" Width="250px" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 125px;">
                                                    <asp:Label ID="Label17" runat="server" Text="الموظف"></asp:Label>
                                                </td>
                                                <td align="center" style="width: 300px;">
                                                    <asp:DropDownList ID="ddlEmp" Width="250px" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 125px;">
                                                    <asp:Label ID="Label9" runat="server" Text="الشاحنة"></asp:Label>
                                                </td>
                                                <td align="center" style="width: 300px;">
                                                    <asp:DropDownList ID="ddlCarNo" Width="250px" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" TargetControlID="Panel4"
                                        ExpandControlID="Panel3" CollapseControlID="Panel3" Collapsed="True" TextLabelID="Label6"
                                        ImageControlID="ImageButton1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Panel ID="Panel5" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                تتبع عمليات المستخدم
                                            </div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="Label16" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="Img16" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel6" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                                        BorderColor="Maroon">
                                        <asp:GridView ID="grdTrans" runat="server" CellPadding="4" ForeColor="#333333"
                                            AllowPaging="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="UserDate2"
                                            Width="99%" OnSelectedIndexChanging="grdTrans_SelectedIndexChanging">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="أختيار العملية و عرض تفاصيلها"
                                                            ImageUrl="~/images/arrow_undo.png" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="التاريخ والوقت" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserDate" Text='<%# Bind("UserDate2") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="125px" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المستخدم" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="125px" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="الإجراء" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="OPName" Text='<%# Bind("OPName") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo2" runat="Server" TargetControlID="Panel6"
                                        ExpandControlID="Panel5" CollapseControlID="Panel5" Collapsed="True" TextLabelID="Label16"
                                        ImageControlID="Img16" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
   
    </fieldset>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
        </div>
    </div>

<<<<<<< HEAD


=======
           
   
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
</asp:Content>
