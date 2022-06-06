<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebTransferEmp.aspx.cs" Inherits="ACC.WebTransferEmp"  Culture="auto:ar-EG" UICulture="auto" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="JavaScript">
    function Name_itemSelected(sender, e) {
        var ace1Value = $get('ContentPlaceHolder1_txtEmpCode');
        var ace2Value = $get('ContentPlaceHolder1_txtName');
        var x = e.get_value().split(' . ');
        ace1Value.value = x[0];
        ace2Value.value = x[1];
        return false;
    }
    function Name2_itemSelected(sender, e) {
        var ace1Value = $get('ContentPlaceHolder1_txtEmpCode2');
        var ace2Value = $get('ContentPlaceHolder1_txtName2');
        var x = e.get_value().split(' . ');
        ace1Value.value = x[0];
        ace2Value.value = x[1];
        return false;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="ColorRounded4Corners" style="width: 99.9%" dir="rtl">
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.8%;
            border: solid 2px #800000">
            <legend align="right" style="font-size: 18px; color: #800000; text-align: center;">[طلب نقل موظف من قسم إلى قسم]</legend>
            <center>
                <table width="99.5%">
                    <tr>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="lblFNum" runat="server" Text="رقم الطلب"></asp:Label>*
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtDocNo" MaxLength="10" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDocNo"
                                Display="Dynamic" ErrorMessage="يجب أختيار رقم الطلب" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="lblFDate" runat="server" Text="التاريخ"></asp:Label>*
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtFDate" Width="90px" ReadOnly="true" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtFTime" Width="75px" MaxLength="10" ReadOnly="true" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFDate"
                                Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الطلب" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtFDate"
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4" style="width: 500px;">
                            <asp:Label ID="Label33" runat="server" Text="تفيدكم علماً بطلب نقل الموظف"></asp:Label>
                        </td>
                    </tr>                                    
                    <tr>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label1" runat="server" Text="رقم الموظف"></asp:Label>*
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtEmpCode" Width="120px" runat="server" MaxLength="50" autocomplete="off"
                                AutoPostBack="True" OnTextChanged="txtEmpCode_TextChanged"></asp:TextBox>
                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtEmpCode"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionEMPCode" OnClientItemSelected="Name_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="50"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                            <asp:RequiredFieldValidator ID="ValEmpCode" runat="server" ControlToValidate="txtEmpCode"
                                ErrorMessage="يجب إدخال رقم الملف" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1"
                                Display="Dynamic">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="ValEmpCode2" runat="server" ControlToValidate="txtEmpCode"
                                ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" ValidationGroup="1"
                                SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic">*</asp:CompareValidator>
                        </td>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label2" runat="server" Text="الاسم"></asp:Label>
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtName" Width="280px" runat="server" autocomplete="off" MaxLength="100"
                                AutoPostBack="True" OnTextChanged="txtEmpCode_TextChanged"></asp:TextBox>
                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtName"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionEMP" OnClientItemSelected="Name_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="50"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label3" runat="server" Text="مسمى الوظيفة"></asp:Label>
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtJob" Width="200px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label4" runat="server" Text="الجنسية"></asp:Label>
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtNational" Width="200px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label5" runat="server" Text="القسم"></asp:Label>
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtDept" Width="200px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label36" runat="server" Text="مع صلاحيات"></asp:Label>                            
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:DropDownList ID="ddlFType" runat="server">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label7" runat="server" Text="لفرع"></asp:Label>*
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:DropDownList ID="ddlSection" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlFType"
                                Display="Dynamic" ErrorMessage="يجب أختيار الوظيفة" ForeColor="Red" SetFocusOnError="True"
                                InitialValue="-1" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label6" runat="server" Visible="false" Text="الإدارة"></asp:Label>
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:DropDownList ID="ddlDep" runat="server" Visible="false" Enabled="false" CssClass="MouseStop">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label10" runat="server" Text="بدلأً من الموظف"></asp:Label>
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtName2" Width="280px" runat="server" autocomplete="off" MaxLength="100"></asp:TextBox>
                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtName2"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionEMP" OnClientItemSelected="Name2_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="50"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                        </td>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label35" runat="server" Text="الرقم الوظيفي"></asp:Label>
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtEmpCode2" Width="120px" runat="server" MaxLength="50" autocomplete="off"></asp:TextBox>
                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtEmpCode2"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionEMPCode" OnClientItemSelected="Name2_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="50"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label31" runat="server" Text="اعتباراً من تاريخ*"></asp:Label>
                        </td>
                        <td align="right" style="width: 280px;">
                            <asp:TextBox ID="txtSDate" Width="100px" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSDate"
                                Display="Dynamic" ErrorMessage="يجب أختيار تاريخ النقل" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtSDate" 
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar" 
                                TargetControlID="txtSDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />
                        </td>
                        <td align="right" style="width: 120px;">
                            &nbsp;</td>
                        <td align="right" style="width: 280px;">
                            &nbsp;</td>
                    </tr>                   
                    <tr>
                        <td align="right" style="width: 120px;">
                            <asp:Label ID="Label8" runat="server" Text="السبب/ملاحظات"></asp:Label>
                        </td>
                        <td align="right" colspan="4" rowspan="3">
                            <asp:TextBox ID="txtFNote" MaxLength="500" TextMode="MultiLine" Width="99%" Height="100px"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 120px;">
                            &nbsp;
                        </td>
                        <td align="center" colspan="3" rowspan="3">
                            <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                ImageUrl="~/images/Agree_641.png" ToolTip="أضافة سند جديد" ValidationGroup="1"
                                OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السند؟")' OnClick="BtnNew_Click" />
                            <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                Visible="false" ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات السند"
                                OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السند؟")' Width="64px"
                                ValidationGroup="1" OnClick="BtnEdit_Click" />
                            <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                            <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                ImageUrl="~/images/print_64A.png" ValidationGroup="1" ToolTip="طباعة السند" OnClick="BtnPrint_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 100px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 100px;">
                            &nbsp;
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
                </table>
                <br />
                <table width="99.5%">
                    <tr align="right">
                        <td style="width: 125px;">
                            <asp:Label ID="Label9" runat="server" Text="المستخدم"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:TextBox ID="txtUserName" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 100px;">
                            <asp:Label ID="Label11" runat="server" Text="تاريخ الادخال"></asp:Label>
                        </td>
                        <td style="width: 275px;" colspan="2">
                            <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                Enabled="false">                                                               
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="width: 99.5%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="DocNo" AllowPaging="True"
                        PageSize="50" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات المعاملة"
                                        ImageUrl="~/images/arrow_undo.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الإشعار" SortExpression="DocNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocNo" Text='<%# Bind("DocNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="DocDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFDate" Text='<%# Eval("DocDate").ToString() + " " + Eval("DocTime").ToString() %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عدد الأيام" SortExpression="VacDays" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblsDate" Text='<%# Bind("VacDays") %>' runat="server"></asp:Label>
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
                <br />
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
                    <div>
                        <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                            BorderColor="Maroon">
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
                            ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                            ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                </div>
            </center>
        </fieldset>
        <br />
        <div id="Agrees" runat="server">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.8%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;">الاعتمادات</legend>
                <center>
                    <div id="divAgree1" visible="false" runat="server" width="99.8%">
                        <asp:Panel ID="PAgree1" runat="server" Height="30px" BackColor="#3333CC" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree1" Text="أعتماد نائب المدير المباشر" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree1" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree11" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff1" Visible="false" runat="server" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff1" Visible="false" runat="server" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount1" Visible="false" runat="server" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount1" Visible="false" runat="server" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark1" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark1" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label12" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree1User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label13" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree1UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree1" runat="server" AlternateText="موافق" CommandName="Agree1"
                                                CommandArgument="1" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree1" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                                CommandArgument="1" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer1" runat="server" AlternateText="تحويل" CommandName="Transfer1"
                                                CommandArgument="1" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer1" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer1" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="LblCodesResult1" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree1A1" runat="server" Height="30px" BackColor="#3333CC" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree1A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree1A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree11A1" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree1A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree1A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree1A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree1A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree1A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo1" runat="Server" TargetControlID="PAgree11A1"
                                        ExpandControlID="PAgree1A1" CollapseControlID="PAgree1A1" Collapsed="True" TextLabelID="lblAgree1A1"
                                        ImageControlID="ImgAgree1A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo01" runat="Server" TargetControlID="PAgree11"
                            ExpandControlID="PAgree1" CollapseControlID="PAgree1" Collapsed="True" TextLabelID="lblAgree1"
                            ImageControlID="ImgAgree1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                    <div id="divAgree2" visible="false" runat="server" width="99.8%">
                        <asp:Panel ID="PAgree2" runat="server" Height="30px" BackColor="#990000" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree2" Text="أعتماد المدير المباشر" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree2" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree2" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree21" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff2" runat="server" Visible="false" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff2" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount2" runat="server" Visible="false" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount2" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark2" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark2" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree2User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label15" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree2UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree2" runat="server" AlternateText="موافق" CommandName="Agree2"
                                                CommandArgument="2" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree2" runat="server" AlternateText="رفض" CommandName="Disagree2"
                                                CommandArgument="2" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer2" runat="server" AlternateText="تحويل" CommandName="Transfer2"
                                                CommandArgument="2" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer2" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer2" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <div style="text-align: right; padding-right: 25px;">
                                </div>
                                <br />
                                <asp:Label ID="LblCodesResult2" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree2A1" runat="server" Height="30px" BackColor="#990000" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree2A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree2A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree2A11" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree2A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree2A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree2A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree2A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree2A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo2" runat="Server" TargetControlID="PAgree2A11"
                                        ExpandControlID="PAgree2A1" CollapseControlID="PAgree2A1" Collapsed="True" TextLabelID="lblAgree2A1"
                                        ImageControlID="ImgAgree2A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo02" runat="Server" TargetControlID="PAgree21"
                            ExpandControlID="PAgree2" CollapseControlID="PAgree2" Collapsed="True" TextLabelID="lblAgree2"
                            ImageControlID="ImgAgree2" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                    <div id="divAgree3" runat="server" visible="false" width="99.8%">
                        <asp:Panel ID="PAgree3" runat="server" Height="30px" BackColor="#006699" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree3" Text="أعتماد الشئون الأدارية" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree3" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree3" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree31" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff3" runat="server" Visible="false" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff3" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount3" runat="server" Visible="false" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount3" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark3" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark3" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label16" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree3User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label17" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree3UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree3" runat="server" AlternateText="موافق" CommandName="Agree3"
                                                CommandArgument="3" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree3" runat="server" AlternateText="رفض" CommandName="Disagree3"
                                                CommandArgument="3" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer3" runat="server" AlternateText="تحويل" CommandName="Transfer3"
                                                CommandArgument="3" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer3" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer3" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="LblCodesResult3" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree3A1" runat="server" Height="30px" BackColor="#006699" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree3A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree3A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree3A11" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree3A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree3A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree3A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree3A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree3A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo3" runat="Server" TargetControlID="PAgree3A11"
                                        ExpandControlID="PAgree3A1" CollapseControlID="PAgree3A1" Collapsed="True" TextLabelID="lblAgree3A1"
                                        ImageControlID="ImgAgree3A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo03" runat="Server" TargetControlID="PAgree31"
                            ExpandControlID="PAgree3" CollapseControlID="PAgree3" Collapsed="True" TextLabelID="lblAgree3"
                            ImageControlID="ImgAgree3" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                    <div id="divAgree4" runat="server" visible="false" width="99.8%">
                        <asp:Panel ID="PAgree4" runat="server" Height="30px" BackColor="#006666" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree4" Text="أعتماد الحسابات" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree4" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree4" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree41" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff4" runat="server" Visible="false" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff4" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount4" runat="server" Visible="false" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount4" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark4" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark4" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label18" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree4User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label19" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree4UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree4" runat="server" AlternateText="موافق" CommandName="Agree4"
                                                CommandArgument="4" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree4" runat="server" AlternateText="رفض" CommandName="Disagree4"
                                                CommandArgument="4" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer4" runat="server" AlternateText="تحويل" CommandName="Transfer4"
                                                CommandArgument="4" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer4" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer4" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="LblCodesResult4" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree4A1" runat="server" Height="30px" BackColor="#006666" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree4A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree4A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree4A11" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree4A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree4A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree4A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree4A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree4A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo4" runat="Server" TargetControlID="PAgree4A11"
                                        ExpandControlID="PAgree4A1" CollapseControlID="PAgree4A1" Collapsed="True" TextLabelID="lblAgree4A1"
                                        ImageControlID="ImgAgree4A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo04" runat="Server" TargetControlID="PAgree41"
                            ExpandControlID="PAgree4" CollapseControlID="PAgree4" Collapsed="True" TextLabelID="lblAgree4"
                            ImageControlID="ImgAgree4" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                    <div id="divAgree5" visible="false" runat="server" width="99.8%">
                        <asp:Panel ID="PAgree5" runat="server" Height="30px" BackColor="#990000" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree5" Text="أعتماد 4" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree5" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree5" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree51" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff5" runat="server" Visible="false" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff5" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount5" runat="server" Visible="false" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount5" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark5" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark5" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label20" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree5User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label21" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree5UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree5" runat="server" AlternateText="موافق" CommandName="Agree5"
                                                CommandArgument="5" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree5" runat="server" AlternateText="رفض" CommandName="Disagree5"
                                                CommandArgument="5" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer5" runat="server" AlternateText="تحويل" CommandName="Transfer5"
                                                CommandArgument="5" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer5" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer5" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="LblCodesResult5" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree5A1" runat="server" Height="30px" BackColor="#990000" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree5A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree5A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree5A11" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree5A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree5A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree5A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree5A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree5A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo5" runat="Server" TargetControlID="PAgree5A11"
                                        ExpandControlID="PAgree5A1" CollapseControlID="PAgree5A1" Collapsed="True" TextLabelID="lblAgree5A1"
                                        ImageControlID="ImgAgree5A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo05" runat="Server" TargetControlID="PAgree51"
                            ExpandControlID="PAgree5" CollapseControlID="PAgree5" Collapsed="True" TextLabelID="lblAgree5"
                            ImageControlID="ImgAgree5" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                    <div id="divAgree6" visible="false" runat="server" width="99.8%">
                        <asp:Panel ID="PAgree6" runat="server" Height="30px" BackColor="#666666" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree6" Text="أعتماد 5" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree6" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree6" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree61" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff6" runat="server" Visible="false" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff6" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount6" runat="server" Visible="false" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount6" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark6" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark6" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label22" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree6User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label23" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree6UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree6" runat="server" AlternateText="موافق" CommandName="Agree6"
                                                CommandArgument="6" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree6" runat="server" AlternateText="رفض" CommandName="Disagree6"
                                                CommandArgument="6" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer6" runat="server" AlternateText="تحويل" CommandName="Transfer6"
                                                CommandArgument="6" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer6" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer6" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="LblCodesResult6" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree6A1" runat="server" Height="30px" BackColor="#666666" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree6A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree6A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree6A11" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree6A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree6A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree6A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree6A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree6A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo6" runat="Server" TargetControlID="PAgree6A11"
                                        ExpandControlID="PAgree6A1" CollapseControlID="PAgree6A1" Collapsed="True" TextLabelID="lblAgree6A1"
                                        ImageControlID="ImgAgree6A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo06" runat="Server" TargetControlID="PAgree61"
                            ExpandControlID="PAgree6" CollapseControlID="PAgree6" Collapsed="True" TextLabelID="lblAgree6"
                            ImageControlID="ImgAgree6" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                    <div id="divAgree7" visible="false" runat="server" width="99.8%">
                        <asp:Panel ID="PAgree7" runat="server" Height="30px" BackColor="#009900" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree7" Text="أعتماد 6" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree7" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree7" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree71" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff7" runat="server" Visible="false" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff7" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount7" runat="server" Visible="false" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount7" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark7" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark7" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label24" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree7User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label25" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree7UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree7" runat="server" AlternateText="موافق" CommandName="Agree7"
                                                CommandArgument="7" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree7" runat="server" AlternateText="رفض" CommandName="Disagree7"
                                                CommandArgument="7" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer7" runat="server" AlternateText="تحويل" CommandName="Transfer7"
                                                CommandArgument="7" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer7" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer7" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="LblCodesResult7" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree7A1" runat="server" Height="30px" BackColor="#009900" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree7A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree7A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree7A11" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree7A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree7A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree7A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree7A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree7A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo7" runat="Server" TargetControlID="PAgree7A11"
                                        ExpandControlID="PAgree7A1" CollapseControlID="PAgree7A1" Collapsed="True" TextLabelID="lblAgree7A1"
                                        ImageControlID="ImgAgree7A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo07" runat="Server" TargetControlID="PAgree71"
                            ExpandControlID="PAgree7" CollapseControlID="PAgree7" Collapsed="True" TextLabelID="lblAgree7"
                            ImageControlID="ImgAgree7" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                    <div id="divAgree8" visible="false" runat="server" width="99.8%">
                        <asp:Panel ID="PAgree8" runat="server" Height="30px" BackColor="#663300" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree8" Text="أعتماد 7" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree8" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree8" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree81" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff8" runat="server" Visible="false" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff8" runat="server"  Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount8" runat="server" Visible="false" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount8" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark8" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark8" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label26" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree8User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label27" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree8UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree8" runat="server" AlternateText="موافق" CommandName="Agree8"
                                                CommandArgument="8" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree8" runat="server" AlternateText="رفض" CommandName="Disagree8"
                                                CommandArgument="8" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer8" runat="server" AlternateText="تحويل" CommandName="Transfer8"
                                                CommandArgument="8" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer8" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer8" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="LblCodesResult8" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree8A1" runat="server" Height="30px" BackColor="#663300" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree8A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree8A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree8A11" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree8A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree8A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree8A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree8A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree8A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo8" runat="Server" TargetControlID="PAgree8A11"
                                        ExpandControlID="PAgree8A1" CollapseControlID="PAgree8A1" Collapsed="True" TextLabelID="lblAgree8A1"
                                        ImageControlID="ImgAgree8A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo08" runat="Server" TargetControlID="PAgree81"
                            ExpandControlID="PAgree8" CollapseControlID="PAgree8" Collapsed="True" TextLabelID="lblAgree8"
                            ImageControlID="ImgAgree8" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                    <div id="divAgree9" visible="false" runat="server" width="99.8%">
                        <asp:Panel ID="PAgree9" runat="server" Height="30px" BackColor="#990033" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    <asp:Literal ID="litAgree9" Text="أعتماد 8" runat="server"></asp:Literal>
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="lblAgree9" runat="server" Text="(عرض التفاصيل)"></asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="ImgAgree9" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                        AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PAgree91" runat="server" Height="0" BackColor="#FFFFEC" class="Round4Courner"
                            Width="99.3%" BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                <table width="99.5%">
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDaysOff9" runat="server" Visible="false" Text="أيام الانقطاع"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDaysOff9" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblDiscount9" runat="server" Visible="false" Text="الخصم"></asp:Label>
                                        </td>
                                        <td align="right" style="width: 300px;">
                                            <asp:TextBox ID="txtDiscount9" runat="server" Visible="false" ReadOnly="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            <asp:Label ID="lblRemark9" runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                        <td align="right" colspan="3" rowspan="5">
                                            <asp:TextBox ID="txtRemark9" MaxLength="300" TextMode="MultiLine" Width="99%" Height="100px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99.5%">
                                    <tr align="right">
                                        <td style="width: 125px;">
                                            <asp:Label ID="Label28" runat="server" Text="المستخدم"></asp:Label>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtAgree9User" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:Label ID="Label29" runat="server" Text="تاريخ الاعتماد"></asp:Label>
                                        </td>
                                        <td style="width: 275px;" colspan="2">
                                            <asp:TextBox ID="txtAgree9UserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                                Enabled="false">                                                               
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="width: 325px">
                                        </td>
                                        <td style="width: 250px">
                                            <asp:ImageButton ID="BtnAgree9" runat="server" AlternateText="موافق" CommandName="Agree9"
                                                CommandArgument="9" ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                                OnCommand="BtnAgree1_Command" />
                                            <asp:ImageButton ID="BtnDisagree9" runat="server" AlternateText="رفض" CommandName="Disagree9"
                                                CommandArgument="9" ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب"
                                                ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")'
                                                OnCommand="BtnDisagree1_Command" />
                                            <asp:ImageButton ID="BtnTransfer9" runat="server" AlternateText="تحويل" CommandName="Transfer9"
                                                CommandArgument="9" ImageUrl="~/images/Forward_A.png" ToolTip="تحويل الطلب" ValidationGroup="1"
                                                OnClientClick='return confirm("هل أنت متاكد من أعادة تحويل الطلب؟")' OnCommand="BtnTransfer1_Command" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblTransfer9" runat="server" Text="تحول إلى"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="ddlTransfer9" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="LblCodesResult9" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; width: 50%; float: left;">
                                    <asp:Panel ID="PAgree9A1" runat="server" Height="30px" BackColor="#990033" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="lblAgree9A1" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="ImgAgree9A1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PAgree9A11" runat="server" Height="0" BackColor="#FFFFEC" Width="99.3%"
                                        BorderWidth="2" BorderColor="Maroon">
                                        <asp:GridView ID="grdAgree9A1" runat="server" CellPadding="4" ForeColor="#333333"
                                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAgree9A1_RowDeleting">
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
                                                    <asp:FileUpload ID="FldAgree9A1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttachAgree9A1" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttachAgree9A1_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo9" runat="Server" TargetControlID="PAgree9A11"
                                        ExpandControlID="PAgree9A1" CollapseControlID="PAgree9A1" Collapsed="True" TextLabelID="lblAgree9A1"
                                        ImageControlID="ImgAgree9A1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </div>
                        </asp:Panel>
                        <ajax:CollapsiblePanelExtender ID="cpeDemo09" runat="Server" TargetControlID="PAgree91"
                            ExpandControlID="PAgree9" CollapseControlID="PAgree9" Collapsed="True" TextLabelID="lblAgree9"
                            ImageControlID="ImgAgree9" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                            SuppressPostBack="true" />
                    </div>
                    <br />
                </center>
            </fieldset>
        </div>
    </div>
</asp:Content>
