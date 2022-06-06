<%@ Page Title="" Language="C#" MasterPageFile="~/SupportSite.Master" AutoEventWireup="true"
    CodeBehind="WebTSupport.aspx.cs" Inherits="ACC.WebTSupport" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ColorRounded4Corners">
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                [ خدمة العملاء ]</b></legend>
            <table id="Table1" dir="rtl" width="98%" cellpadding="2" style="color: Black">
                <tr id="tr1">
                    <td style="width: 100px;">
                        <asp:Label ID="LblCode" runat="server" Text="التاريخ"></asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtFDate" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 50px;">
                    </td>
                    <td style="width: 100px;">
                        <asp:Label ID="Label19" runat="server" Text="الوقت"></asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtFTime" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="tr2">
                    <td style="width: 100px;">
                        <asp:Label ID="Label1" runat="server" Text="اسم العميل"></asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtCustomer" MaxLength="100" Width="280px" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 50px;">
                    </td>
                    <td style="width: 100px;">
                        <asp:Label ID="Label20" runat="server" Text="رقم الفاتورة"></asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtInvNo" MaxLength="10" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="tr3">
                    <td style="width: 100px;">
                        <asp:Label ID="Label2" runat="server" Text="رقم الجوال"></asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtMobileNo" MaxLength="15" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 50px;">
                    </td>
                    <td style="width: 100px;">
                        <asp:Label ID="Label21" runat="server" Text="رقم اللوحة"></asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtPlateNo" MaxLength="10" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="tr4">
                    <td style="width: 100px;">
                        <asp:Label ID="Label3" runat="server" Text="نوع الخدمة"></asp:Label>
                    </td>
                    <td colspan="4" style="width: 700px;" align="left">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="5" Width="700px">
                            <asp:ListItem Value="0" Text="استفسار عن سيارة"></asp:ListItem>
                            <asp:ListItem Value="1" Text="استفسار عن زمن الوصول"></asp:ListItem>
                            <asp:ListItem Value="2" Text="شكوى"></asp:ListItem>
                            <asp:ListItem Value="3" Text="موقع الفرع"></asp:ListItem>
                            <asp:ListItem Value="4" Text="اخرى"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr id="tr5">
                    <td style="width: 100px;">
                        <asp:Label ID="Label4" runat="server" Text="الرد"></asp:Label>
                    </td>
                    <td colspan="4" style="width: 700px;" align="left" rowspan="5">
                        <asp:TextBox ID="txtReply" TextMode="MultiLine" MaxLength="500" Width="750px" Height="120px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="tr6">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr7">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr8">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr9">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr10">
                    <td style="width: 100px;">
                        <asp:Label ID="Label9" runat="server" Text="ملاحظات"></asp:Label>
                    </td>
                    <td colspan="4" style="width: 700px;" align="left" rowspan="5">
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" MaxLength="500" Width="750px" Height="120px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="tr20">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr21">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr22">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr23">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr11">
                    <td style="width: 100px;">
                    </td>
                    <td colspan="4" style="width: 700px;" align="left" rowspan="5">
                        <asp:TextBox ID="txtRemark2" Visible="false" TextMode="MultiLine" MaxLength="500" Width="750px" Height="120px"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="tr12">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr13">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr14">
                    <td style="width: 100px;">
                    </td>
                </tr>
                <tr id="tr15">
                    <td style="width: 100px;">
                    </td>
                </tr>
            </table>
            <center>
                <div class="DivButtons" style="width: 95%">
                    <table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="center">
                            <td style="width: 200px;">
                                &nbsp;
                            </td>
                            <td style="width: 400px;">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة بيانات موظف جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الموظف؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات موظف" Width="64px"
                                    ValidationGroup="1" Visible="false" onclick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات موظف" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات الموظف؟")'
                                    Visible="false" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png" ToolTip="البحث عن بيانات معاملة" Visible="false" />
                            </td>
                            <td id="td1" runat="server" style="width: 200px; text-align: right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                    <table width="100%">
                        <tr>
                            <td style="width: 120px;">
                                <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 200px;">
                                <asp:DropDownList ID="ddlUser" Width="200px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                            </td>
                            <td style="width: 120px">
                            </td>
                            <td style="width: 200px">
                                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 120px" rowspan="2">
                                                            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                    ImageUrl="~/images/Process.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 120px">
                                <asp:CheckBox ID="ChkPeriod" runat="server" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />

                                   
                            </td>
                            <td align="right" style="width: 200px;">
                                <asp:TextBox ID="txtMyFDate" Placeholder="تاريخ بداية الفترة" MaxLength="10" Width="100px"
                                    Visible="false" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtMyFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>                                                                   
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtMyFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td colspan="2" style="width: 220px;">
                                <asp:TextBox ID="txtMyEDate" Placeholder="تاريخ نهاية الفترة" MaxLength="10" Width="100px"
                                    Visible="false" runat="server"></asp:TextBox>                                
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtMyEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtMyEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td style="width: 200px">
                                <asp:Label ID="Label6" runat="server" Text="عرض السجلات"></asp:Label>&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlRecordsPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="-1">الكل</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FDate,FTime" AllowPaging="True"
                        PageSize="50" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="أختيار الطلب و عرض تفاصيله"
                                        ImageUrl="~/images/arrow_undo.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوقت" SortExpression="FTime" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFTime" Text='<%# Bind("FTime") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="85px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="العميل" SortExpression="Customer" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomer" Text='<%# Bind("Customer") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الجوال" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
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
            </center>
        </fieldset>
    </div>
</asp:Content>
