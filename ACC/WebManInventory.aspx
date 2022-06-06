<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebManInventory.aspx.cs" Inherits="ACC.WebManInventory" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            $("input[name*='grdCodes'],select[name*='grdCodes']").change(function (event) {
                var res = event.target.id.split("_");
                var ctrl = document.getElementById("ContentPlaceHolder1_grdCodes_txtAction_" + res[3]);
                ctrl.value = "123";
                $(this).addClass('ChangedText');
                $(this).ToolTip = '1';
            });
            SetMyStyle();
        }

        function CallMe(src, dest, no1) {
            var ctrl = document.getElementById(src);
            var dest1 = document.getElementById(dest);
            // call server side method
            PageMethods.GetDate(ctrl.value,dest1.innerHTML, CallSuccess, CallFailed, no1);
        }
        // set the destination textbox value with the ContactName
        function CallSuccess(res, no1) {
            var dest = document.getElementById(no1[0]);
            dest.innerHTML = res[0];

            var dest125 = document.getElementById(no1[1]);
            //alert(dest125.innerHTML);
            dest125.innerHTML = res[1];
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            alert(res.get_message());
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Round4Courner" style="width: 99%">
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
            border: solid 2px #800000">
            <legend id="leg1" runat="server" align="<%$ Resources:Resource, dir2 %>" style="font-size: 18px;
                color: #800000; text-align: center;"><b>
                    <asp:Literal ID="Literal2" Text="Manual Inventory Data Entry" runat="server"></asp:Literal>
                    <!-- [ بيانات الأصناف ] -->
                </b></legend>
            <br />
            <center>
                <table width="100%" cellpadding="2px">
                    <tr>
                        <td style="width: 120px;">
                            <asp:Label ID="Label22" runat="server" Text="Select Store:"></asp:Label>
                        </td>
                        <td style="width: 250px;">
                            <asp:DropDownList ID="ddlStore" Width="240px" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 50px;">
                        </td>
                        <td style="width: 120px;">
                            <asp:Label ID="Label1" runat="server" Text="Inventory Date"></asp:Label>
                        </td>
                        <td style="width: 200px;">
                            <asp:TextBox ID="txtFYear" MaxLength="10" Width="100px" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFYear"
                                Display="Dynamic" ErrorMessage="You Should Enter Inventory Date" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="1" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="Search for Manual Inventory" OnClick="BtnFind_Click" />
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtFYear"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="Note Date Should be Date Value"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFYear" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px;">
                            &nbsp;</td>
                        <td style="width: 250px;">
                            &nbsp;</td>
                        <td style="width: 50px;">
                            &nbsp;</td>
                        <td style="width: 120px;">
                            <asp:Label ID="Label23" runat="server" Text="Type"></asp:Label>
                        </td>
                        <td style="width: 200px;">
                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True"  ValidationGroup="1"
                                onselectedindexchanged="ddlType_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="1">Addition & Lost</asp:ListItem>
                                <asp:ListItem Value="2">Lost</asp:ListItem>
                                <asp:ListItem Value="3">Addition</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="50"
                        DataKeyNames="Code" Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Item Code" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description" SortExpression="ITName1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblITName1" Text='<%# Bind("ITName1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance" SortExpression="Bal" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBal" runat="server" Text='<%# Bind("Bal") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="65px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manual Bal." SortExpression="FBal" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFBal" Text='<%# Bind("FBal") %>' MaxLength="20" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="txtFBal"
                                        Display="Dynamic" ErrorMessage="You Should Enter Numeric Value" ForeColor="Red"
                                        Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="65px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost Price" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrice" Text='<%# Bind("Price") %>' MaxLength="20" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator207" runat="server" ControlToValidate="txtPrice"
                                        Display="Dynamic" ErrorMessage="You Should Enter Numeric Value" ForeColor="Red"
                                        Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="65px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="+" SortExpression="FAdd" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFAdd" runat="server" Text='<%# Bind("FAdd") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="-" SortExpression="FDed" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFDed" runat="server" Text='<%# Bind("FDed") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" SortExpression="FStatus" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlAction" runat="server" OnInit="ddlAction_Init"></asp:DropDownList>
                                    <asp:HiddenField ID="txtAction" Value="" runat="server" />
                                </ItemTemplate>
                                <ControlStyle Width="120px" />
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
                <br />
                <div id="divEdit" runat="server" visible="false" class="DivButtons" style="width: 95%">
                    <table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="center">
                            <td style="width: 250px;">
                                &nbsp;
                            </td>
                            <td style="width: 250px;">
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_641.png" CssClass="ops" ToolTip="Edit Stock Item Inventory"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnRefresh" runat="server" AlternateText="Refresh" CommandName="Refresh"
                                    ImageUrl="~/images/Refresh_642.png" CssClass="ops" ToolTip="Refresh Data For Stock Item Inventory"
                                    Width="64px" ValidationGroup="1" onclick="BtnRefresh_Click"/>
                                <asp:ImageButton ID="BtnPost" runat="server" Visible="false" AlternateText="ترحيل االقيد" ValidationGroup="1"
                                    ImageUrl="~/images/Process.png" ToolTip="ترحيل االقيد"  />
                                <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print_641.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                                                    
                            </td>
                            <td id="td1" runat="server" style="width: 250px; text-align: right">
                                &nbsp;
                                <asp:HyperLink ID="BtnAdd" target="_blank" Visible="false" runat="server" Text= "+ معالجة الزيادة"></asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink ID="BtnDed" target="_blank" Visible="false"  runat="server" Text= "- معالجة النقص"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
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
        </fieldset>
    </div>
</asp:Content>
