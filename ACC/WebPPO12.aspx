<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebPPO12.aspx.cs" Inherits="Pro.WebPPO12" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function CallMe(src, no1) {            
                var ctrl = document.getElementById(src);
                // call server side method
                PageMethods.GetDate(ctrl.value, CallSuccess, CallFailed, no1);
            }
            // set the destination textbox value with the ContactName
            function CallSuccess(res, no1) {
                var dest = document.getElementById(no1[0]);
                var dest2 = document.getElementById(no1[1]);
                dest.value = res[0];
                dest2.value = res[1];
                if (dest.value != '') {
                    dest.readOnly = true;
                }
                else {
                    dest.readOnly = false;
                }
            }
            // alert message on some failure
            function CallFailed(res, destCtrl) {
                alert(res.get_message());
            }

            function Validate() {
                var isValid = false;
                isValid = Page_ClientValidate('1');
                if (isValid) {
                    isValid = Page_ClientValidate('10');
                }
                return isValid;
            }

            function Validate2() {
                var isValid = false;
                isValid = Page_ClientValidate('1');
                if (isValid) {
                    isValid = Page_ClientValidate('10');
                }
                return confirm("هل أنت متاكد من الغاء بيانات الطلب؟");
            }        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ طلب دفع ]"></asp:Label>
                </b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label1" runat="server" Text="رقم الطلب"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 20%;">
                                <asp:TextBox ID="txtVouNo" MaxLength="10" CssClass="MouseStop"  runat="server"></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 5%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 20%;">
                                <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td align="left" style="width:25%">
                               <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات الطلب" OnClick="BtnFind_Click" />
                                </td>
                        </tr>
                        <tr align="center">
                            <td colspan="6" style="width: 100%;">
                                <div id="divGrid" runat="server" style="width: 100%; overflow: none; overflow-y: none;
                                    overflow-x: auto; border: 1px solid #800000;">
                                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                        Width="99.5%" EmptyDataText="لا توجد بيانات" OnRowCancelingEdit="grdCodes_RowCancelingEdit"
                                        OnRowCommand="grdCodes_RowCommand" OnRowDeleting="grdCodes_RowDeleting">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="الحاله" SortExpression="Approved" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlApproved" SelectedValue='<%# Bind("Approved") %>' Enabled="true" AutoPostBack="true"
                                                          runat="server" 
                                                        onselectedindexchanged="ddlApproved_SelectedIndexChanged">
                                                        <asp:ListItem Text="معلق" Value="0" > </asp:ListItem>
                                                        <asp:ListItem Text="موافق" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="مرفوض" Value="2"></asp:ListItem>
                                                        <%--<asp:ListItem Text="سدد" Value="3"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="65px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="تسلسل" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="50px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="سند الصرف" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVouNo" Text='<%# Bind("VouNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtVouNo2" MaxLength="15" Width="100px" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="البند" SortExpression="Item" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItem" Text='<%# Bind("Item") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtItem" MaxLength="100" Width="400px" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                                <ControlStyle Width="400px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="المبلغ" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrice" Text='<%# Eval("Price","{0:N2}") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtPrice" MaxLength="20" Width="100px" ReadOnly="true" runat="server"></asp:TextBox>
                                                </FooterTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند" ValidationGroup="1"
                                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="اضافة بند جديد"
                                                        ImageUrl="~/images/add.png" />
                                                </FooterTemplate>
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
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                            </td>
                            <td align="right" style="width: 35%;">
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                            </td>
                            <td align="left" style="width: 34%;" colspan="2">
                                <asp:Label ID="Label4" runat="server" Text="الاجمالي"></asp:Label>&nbsp;&nbsp;
                                <asp:TextBox ID="txtAmount" MaxLength="15" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table id="Table2" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="285px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 70px;">
                                <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="285px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="10">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 70px;">
                            </td>
                            <td style="width: 300px;">
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                            </td>
                        </tr>
                        <tr align="right">
                            <td colspan="4" style="text-align: center;">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png"   ToolTip="أضافة طلب جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الطلب؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات الطلب" OnClientClick="return Validate()"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات الطلب" OnClientClick="return Validate2()"
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png"   ToolTip="البحث عن بيانات الطلب"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1"   ToolTip="طباعة الطلب"
                                    OnClick="BtnPrint_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
                <div style="text-align: left; width: 50%; float: left;">
                    <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="Maroon" Width="99.5%"
                        Direction="RightToLeft" ForeColor="#FFFF99">
                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                                المرفقات</div>
                            <div style="float: right; margin-right: 20px;">
                                <asp:Label ID="Label13" runat="server">(عرض التفاصيل)</asp:Label>
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
                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label13"
                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                </div>
            </fieldset>
        </div>
    </center>
</asp:Content>
