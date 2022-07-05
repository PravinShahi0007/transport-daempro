<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebTripCollect.aspx.cs" Inherits="ACC.WebTripCollect" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <fieldset>
            <!--editing by chanda verma-->
            <div class="card-header">
                <h4 class="card-title">[ بيان التجميع ]</h4>
            </div>

            <br />
            <div class="card-body">
                <div class="form-row">
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="LblCode" runat="server" Text="رقم البيان*"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                        <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                            Display="Dynamic" ErrorMessage="يجب أختيار رقم بيان التجميع" ForeColor="Red"
                            SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:CheckBox ID="ChkRent" runat="server" Text="سائق متعاون" Visible="false" CssClass="form-control"
                            AutoPostBack="True" OnCheckedChanged="ChkRent_CheckedChanged" />

                        &nbsp;&nbsp;&nbsp;

                                <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                        <asp:Button ID="BtnFind" runat="server" ValidationGroup="55" CssClass="btn  btn-primary"
                            ToolTip="البحث عن بيانات بيان التجميع" OnClick="BtnFind_Click" Text="بحث" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label2" runat="server" Text="التاريخ*"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:TextBox ID="txtHDate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHDate"
                            Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label3" runat="server" Text="الموافق*"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:TextBox ID="txtGDate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtGDate"
                            Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGDate"
                            CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                            ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>م&nbsp;
                                <asp:Label ID="LblFTime" runat="server" Text=""></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtGDate"
                            ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$"
                            runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label7" runat="server" Text="مدينة أو منطقة التجميع*"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:DropDownList ID="ddlFrom" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddlFrom"
                            InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الجهة من" ForeColor="Red"
                            SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label6" runat="server" Visible="false" Text="نوع الناقلة"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server" Visible="false"
                            OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label1" runat="server" Text="السائق*"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:DropDownList ID="ddlDriver" CssClass="form-control" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlDriver_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ValDriver" runat="server" ControlToValidate="ddlDriver"
                            InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار السائق" ForeColor="Red"
                            SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRentDriver" CssClass="form-control" MaxLength="100" Visible="false" runat="server" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValRentDriver" runat="server" ControlToValidate="txtRentDriver" Visible="false" Enabled="false"
                            InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أدخال السائق" ForeColor="Red"
                            SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label4" runat="server" Visible="false" Text="الناقلة"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:DropDownList ID="ddlCar" CssClass="form-control" Visible="false" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCar_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ValCar" runat="server" ControlToValidate="ddlCar" Visible="false" Enabled="false"
                            InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الناقلة" ForeColor="Red"
                            SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRentMobileNo" MaxLength="15" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12 col-sm-12 col-xm-12">
                        <asp:CheckBox ID="ChkAll" Text="عرض المتاح" runat="server" AutoPostBack="True" Visible="false"
                            CssClass="form-control" OnCheckedChanged="ChkAll_CheckedChanged" />
                    </div>

                </div>
                <div class="form-row">
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label9" runat="server" Text="نوع الحمولة"></asp:Label>
                    </div>
                    <div class="form-group col-md-9 col-sm-12 col-xm-12">
                        <asp:CheckBoxList ID="ChkInvType" runat="server" CssClass="form-control"
                            RepeatColumns="2" AutoPostBack="True"
                            OnSelectedIndexChanged="ChkInvType_SelectedIndexChanged">
                            <asp:ListItem Value="0">سيارات</asp:ListItem>
                            <asp:ListItem Value="1">طرود</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>

                </div>
                <div class="form-row">
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                            Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="Label8" runat="server" Text="تاريخ الادخال"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                            Enabled="false">                                                               
                        </asp:TextBox>
                        <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>

                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12">
                        <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                            ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                            SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                    <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12 col-sm-12 col-xm-12">
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                            EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                    </div>

                </div>
                <div class="form-row text-center">
                    <div class="form-group col-md-12 col-sm-12 col-xm-12">
                        <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                            ImageUrl="~/images/data add.png"
                            ToolTip="أضافة بيان تجميع جديد" ValidationGroup="1"
                            OnClientClick='return confirm("هل أنت متاكد من حفظ بيان التجميع؟")'
                            OnClick="BtnNew_Click" Text="جديد" />
                        <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                            ImageUrl="~/images/edit2.png" ToolTip="تعديل بيان تجميع" Width="64px"
                            ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                        <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                            ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح" />
                        <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                            ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيان التجميع" OnClientClick='return confirm("هل أنت متاكد من الغاء بيان التجميع؟")' OnClick="BtnDelete_Click" Text="إلغاء" />
                        <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                            ImageUrl="~/images/print.png" ValidationGroup="1" ToolTip="طباعة السند" OnClick="BtnPrint_Click" Text="طباعة" />
                    </div>

                </div>

                <!-- edited by chanda verma -->
            </div>
            <br />

            <br />
        </fieldset>

    </div>
    <br />

    <fieldset class="card">
        <div class="card-header">
            <h4 class="card-header">[ فواتير الحمولة ]</h4>
        </div>
        <div id="divGrd" runat="server" class="card-body">
            <!-- edited by hanan3 ( copy & paste the gridview ) -->
            <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="False" DataKeyNames="VouNo" Width="100%" EmptyDataText="لا توجد بيانات">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkStatus" runat="server" Checked='<%# Bind("Status") %>' ToolTip="أختيار او عدم اختيار الفاتورة" CssClass="form-control" />
                        </ItemTemplate>
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="رقم الفاتورة" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Flag") + int.Parse(Eval("InvoiceVouLoc").ToString()).ToString() + "/" + Eval("VouNo") %>'
                                NavigateUrl='<%# UrlHelper(Eval("VouNo"),Eval("InvoiceVouLoc"),Eval("Flag"))%>' Target="_blank"
                                runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="التاريخ" SortExpression="FTime" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTime" Text='<%# Bind("GDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="مرسل الشحنة" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="جوال المرسل" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="رقم اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="PlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="جهة الترحيل" SortExpression="DestinationName1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDestination" Text='<%# Eval("DestinationName1") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="العنوان" SortExpression="Address" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblAddress" Text='<%# Bind("Address") %>'
                                NavigateUrl='<%# "WebMap.aspx?lat=" +Eval("SLat").ToString() + "&lng="+ Eval("SLong").ToString()%>' Target="_blank"
                                runat="server"></asp:HyperLink>

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
    </fieldset>
</asp:Content>
