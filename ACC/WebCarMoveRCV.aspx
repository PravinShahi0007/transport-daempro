<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebCarMoveRCV.aspx.cs" Inherits="ACC.WebCarMoveRCV" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ بيان الوصول ]"></asp:Label>
                </b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 125px;">
                            </td>
                            <td align="right" style="width: 300px;">
                            </td>
                            <td align="right" style="width: 25px;">
                            </td>
                            <td align="center" style="width: 125px;">
                            </td>
                            <td align="left" style="width: 300px;">
                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات بيان الوصول" OnClick="BtnFind_Click" />                                
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 125px;">
                                <asp:Label ID="Label1" runat="server" Text="رقم البيان"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop"></asp:TextBox>
                                <asp:Label ID="lblBranch2" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم البيان" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 25px;">
                            </td>
                            <td align="center" style="width: 125px;">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ البيان" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtVouDate"
                                    ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$"
                                    runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                                &nbsp;
                                <asp:Label ID="LblFTime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 125px;">
                                <asp:Label ID="Label6" runat="server" Text="رقم بيان الترحيل"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtCarMove" MaxLength="20" runat="server" AutoPostBack="True" OnTextChanged="txtCarMove_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCarMove"
                                    Display="Dynamic" ErrorMessage="يجب إدخال بيان الترحيل" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:ImageButton ID="BtnFind2" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات بيان الترحيل" OnClick="BtnFind2_Click" />
                            </td>
                            <td align="right" style="width: 25px;">
                            </td>
                            <td align="center" style="width: 125px;">
                                <asp:Label ID="Label9" runat="server" Text="ملاحظات"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtRemark" MaxLength="100" Width="250px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label7" runat="server" Text="من"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:Label ID="lblFrom" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="right" style="width: 25px;">
                            </td>
                            <td align="center" style="width: 125px;">
                                <asp:Label ID="Label3" runat="server" Text="إلى"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label40" runat="server" Text="الناقلة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:Label ID="lblCar" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="right" style="width: 25px;">
                            </td>
                            <td align="center" style="width: 125px;">
                                <asp:Label ID="Label4" runat="server" Text="السائق"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label5" runat="server" Text="ملحقات الناقلة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:Label ID="lblFType2" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="right" style="width: 25px;">
                            </td>
                            <td align="center" style="width: 125px;">
                                <asp:Label ID="Label10" runat="server" Text="الحمولة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:Label ID="lblCap" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="5" style="width: 100%;">
                                <div id="divGrid" runat="server" style="width: 100%; overflow: none; overflow-y: none;
                                    overflow-x: auto; border: 1px solid #800000;">
                                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" Width="99.5%"
                                        EmptyDataText="لا توجد بيانات">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ترانزيت" SortExpression="Transit" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkTrans" Checked='<%# Bind("Transit") %>' runat="server" />
                                                </ItemTemplate>
                                                <ControlStyle Width="50px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="رقم الفاتورة" SortExpression="VouNo2" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink2" Text='<%# Bind("VouNo2") %>' NavigateUrl='<%# UrlHelper33(Eval("VouNo"),Eval("InvoiceVouLoc"),Eval("Flag"))%>'
                                                        Target="_blank" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="رقم اللوحة أو الهيكل" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="العميل" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="200px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="جهة الترحيل" SortExpression="DestinationName1" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDestinationName" Text='<%# Bind("DestinationName1") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                            HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="#C7C7C7" />
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
                        <tr align="center">
                            <td colspan="5" style="width: 100%;">
                                <div id="div1" runat="server" style="width: 100%; overflow: none; overflow-y: none;
                                    overflow-x: auto; border: 1px solid #800000;">
                                    <asp:GridView ID="grdStatus" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                                        Caption="حالة أرسال الرسائل" CaptionAlign="Top" GridLines="None" AutoGenerateColumns="False"
                                        DataKeyNames="FNo" Width="99.5%" EmptyDataText="لا توجد بيانات">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="رقم الفاتورة" SortExpression="VouNo2" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" Text='<%# Bind("VouNo2") %>' NavigateUrl='<%# UrlHelper33(Eval("VouNo"),Eval("InvoiceVouLoc"),Eval("Flag"))%>'
                                                        Target="_blank" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="رقم الموبيل" SortExpression="MobileNo2" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo2") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="بيان الاستلام" SortExpression="VouNo20" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="lnkVouNo20" Text='<%# Bind("RcvNo2") %>' NavigateUrl='<%# UrlHelper330(Eval("RcvNo2"))%>'
                                                        Target="_blank" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الحالة" SortExpression="Status2" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus2" Text='<%# Bind("Status2") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="250px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" SortExpression="Status" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="Image2" runat="server" ToolTip="أضغط هنا لأعادة ارسال الرسالة للعميل"
                                                        ImageUrl='<%# Eval("Status").ToString().Equals("1") ? "~/images/accept.png" : "~/images/Cross.png" %>' 
                                                        onclick="Image2_Click"  />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                            HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" BorderColor="#C7C7C7" />
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
                    </table>
                    <table id="Table2" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 125px;">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="280px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                            </td>
                            <td style="width: 275px;">
                            </td>
                        </tr>

                        <tr align="center">
                            <td colspan="4">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                            </td>
                        </tr>
                        <tr align="right">
                            <td colspan="4" style="text-align: center">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة بيان وصول جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات بيان الوصول؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات بيان الوصول" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات بيان الوصول" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات بيان الوصول؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png" ToolTip="البحث عن بيانات بيان الوصول"
                                    OnClick="BtnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
                <div style="text-align: left; width: 50%; float: left;">
                    <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                        Direction="RightToLeft" ForeColor="#FFFF99">
                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                                المرفقات</div>
                            <div style="float: right; margin-right: 20px;">
                                <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                        BorderColor="#5D7B9D">
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowHeader="False"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                <div id="CarAlert" runat="server" visible="false">
                     <br />
              <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="right" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ مستندات الشاحنة ]</b></legend>
            <asp:GridView ID="grdCarAlert" runat="server" CellPadding="4" ForeColor="Black"
                GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Code" Width="99.9%"
                EmptyDataText="لا توجد بيانات" BackColor="White" BorderColor="#DEDFDE" 
                BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>                
                    <asp:TemplateField HeaderText="م" SortExpression="WorkShopCode" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" Text='<%# Bind("WorkShopCode") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="الرقم" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarNo" Text='<%# Eval("Code") %>'  NavigateUrl='<%# UrlHelper("110" ,Eval("Code"))%>' ToolTip="عرض السيارة" Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="85px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الاستمارة" SortExpression="strDate1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate1" Text='<%# Bind("strDate1") %>' ToolTip='<%# Bind("PLoc1") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="التامين" SortExpression="strDate2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate2" Text='<%# Bind("strDate2") %>' ToolTip='<%# Bind("PLoc2") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="بطاقة التشغيل" SortExpression="strDate3" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate3" Text='<%# Bind("strDate3") %>' ToolTip='<%# Bind("PLoc3") %>' runat="server"></asp:Label>
                       </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الفحص الدوري" SortExpression="strDate4" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate4" Text='<%# Bind("strDate4") %>' ToolTip='<%# Bind("PLoc4") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" VerticalAlign="Middle"
                    HorizontalAlign="Center" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </fieldset>
        </div>
            </fieldset>
        </div>
    </center>
</asp:Content>
