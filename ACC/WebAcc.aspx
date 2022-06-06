<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" CodeBehind="WebAcc.aspx.cs"
    Inherits="ACC.WebAcc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        function CheckItemO(sender, args) {
            var Opendb = document.getElementById('<%=txtodacc.ClientID %>');
            var Opencr = document.getElementById('<%=txtocacc.ClientID %>');
            args.IsValid = false;
            if (Opendb && Opencr) {
                if (parseFloat(Opendb.value) != 0 && parseFloat(Opencr.value) != 0) {
                    return
                }

            }
            args.IsValid = true;
            return
        }

        function CheckItemF(sender, args) {
            var Fdb = document.getElementById('<%=txtFdacc.ClientID %>');
            var Fcr = document.getElementById('<%=txtFcacc.ClientID %>');
            args.IsValid = false;
            if (Fdb && Fcr) {
                if (parseFloat(Fdb.value) != 0 && parseFloat(Fcr.value) != 0) {
                    return
                }
            }
            args.IsValid = true;
            return
        }

        function MyConfirm() {
            var code = document.getElementById('<%=txtCode.ClientID %>');
            var Name = document.getElementById('<%=txtName.ClientID %>');
            if (code && Name) {
                if (code.value != "") {
                    return confirm(<asp:Literal runat="server" Text="<%$ Resources:SureDelete%>" /> + " " + code.value + " " + Name.value);
                }
            }

            return false;
        }

	
    </script>
    <center>
        <div class="Round4Courner" style="width: 98%">
            <center>
                <asp:LinkButton ID="LbtnLevel1" runat="server" CommandName="1" Text="الحسابات" Visible="true" meta:resourcekey="LbtnLevel1"
                    OnCommand="LbtnLevel1_Command" Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel2" runat="server" CommandName="2" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel3" runat="server" CommandName="3" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel4" runat="server" CommandName="4" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel5" runat="server" CommandName="5" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FCode;Code" AllowPaging="True"
                        Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging" OnSelectedIndexChanging="grdCodes_SelectedIndexChanging"
                        EmptyDataText="<%$ Resources: NoData %>">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="<%$ Resources: SelectAccount %>"
                                        ImageUrl="~/images/arrow_undo.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: ArabicDescr %>" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="350px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources: EnglishDescr %>" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="350px" />
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
            </center>
        </div>
        <div id="Panel2" runat="server" visible="false">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ <asp:Literal ID="Literal90" Text="<%$ Resources:AccountData %>" runat="server"></asp:Literal>  ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="LblCode" runat="server" Text="كود الحساب" meta:resourcekey="LblCode"></asp:Label>
                            </td>
                            <td style="width: 325px; margin-right: 40px;">
                                <asp:TextBox ID="txtCode" Width="100px" runat="server" MaxLength="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtCode"
                                    ErrorMessage="<%$ Resources:EnterAccount %>" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" Text="نوع الحساب" meta:resourcekey="Label1"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:DropDownList ID="ddlSType2" Width="200px" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValSType2" runat="server" ControlToValidate="ddlSType2"
                                    ForeColor="Red" InitialValue="0" SetFocusOnError="True" Display="Dynamic" ErrorMessage="<%$ Resources:SelectAccountType %>"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CheckBox ID="ChkDepDo" Checked="false" Visible="false" Text="فني" runat="server" meta:resourcekey="ChkDepDo" />
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label2" runat="server" Text="الاسم عربي" meta:resourcekey="Label2"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:TextBox ID="txtName" Width="300px" runat="server" MaxLength="80"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي" meta:resourcekey="Label3"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtName2" Width="300px" runat="server" MaxLength="80"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label4" runat="server" Text="الرصيد الافتتاحي" meta:resourcekey="Label4"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:Label ID="Label6" runat="server" Text="مدين" meta:resourcekey="Label6"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtodacc" Width="100px" runat="server" MaxLength="10"></asp:TextBox>
                                &nbsp;<asp:CompareValidator ID="Valodacc" runat="server" ControlToValidate="txtodacc"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:NumberValue %>" ForeColor="Red" Type="Currency"
                                    ValidationGroup="1" SetFocusOnError="True" EnableClientScript="False" Operator="DataTypeCheck">*</asp:CompareValidator>
                                &nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="دائن" meta:resourcekey="Label7"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtocacc" Width="100px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CustomValidator ID="ValOpen" runat="server" ClientValidationFunction="CheckItemO"
                                    ControlToValidate="txtocacc" ErrorMessage="<%$ Resources:DebitOrCredit %>"
                                    ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ValidationGroup="1">*</asp:CustomValidator>
                                <asp:CompareValidator ID="Valocacc" runat="server" ControlToValidate="txtocacc" ErrorMessage="<%$ Resources:NumberValue %>"
                                    ForeColor="Red" SetFocusOnError="True" Display="Dynamic" Type="Currency" ValidationGroup="1"
                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label5" runat="server" Text="العملة" meta:resourcekey="Label5"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:DropDownList ID="ddlCoin" Width="200px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label8" runat="server" Text="الرصيد المتوقع" meta:resourcekey="Label8"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:Label ID="Label9" runat="server" Text="مدين" meta:resourcekey="Label9"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtFdacc" Width="100px" runat="server" MaxLength="10"></asp:TextBox>
                                &nbsp;<asp:CompareValidator ID="ValFdacc" runat="server" ControlToValidate="txtFdacc"
                                    ErrorMessage="<%$ Resources:NumberValue %>" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" Type="Currency" Operator="DataTypeCheck" ValidationGroup="1">*</asp:CompareValidator>
                                &nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="دائن" meta:resourcekey="Label10"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtFcacc" Width="100px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="CheckItemF"
                                    ControlToValidate="txtFcacc" ErrorMessage="<%$ Resources:FDebitOrCredit %>"
                                    ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ValidationGroup="1">*</asp:CustomValidator>
                                <asp:CompareValidator ID="ValFcacc" runat="server" ControlToValidate="txtFcacc" ErrorMessage="<%$ Resources:NumberValue %>"
                                    ForeColor="Red" SetFocusOnError="True" Type="Currency" Display="Dynamic" Operator="DataTypeCheck"
                                    ValidationGroup="1">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label11" runat="server" Text="مركز الحسابات" meta:resourcekey="Label11"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:DropDownList ID="ddlCenter" Width="200px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label13" runat="server" Text="التوجية" meta:resourcekey="Label13"></asp:Label>
                            </td>
                            <td style="width: 325px;">
                                <asp:CheckBox ID="ChkCostCenter" Text="الفرع" runat="server" meta:resourcekey="ChkCostCenter" />&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ChkProject" Text="المشروع" runat="server" meta:resourcekey="ChkProject"/>&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ChkArea" Text="المنطقة" runat="server" meta:resourcekey="ChkArea" />
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label12" runat="server" Text="ملاحظات" meta:resourcekey="Label12"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtRemark" Width="300px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                            </td>
                            <td style="width: 325px;">
                                <asp:CheckBox ID="ChkEmp" Text="الموظفين" runat="server" meta:resourcekey="ChkEmp" />&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ChkCostAcc" Text="التكاليف" runat="server" meta:resourcekey="ChkCostAcc" />&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ChkCarNo" Text="الشاحنة" runat="server" meta:resourcekey="ChkCarNo"/>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="lblCost" Visible="false" runat="server" Text="حساب المصروف" meta:resourcekey="lblCost"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:DropDownList ID="ddlCost" Visible="false" Width="250px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td colspan="4">
                                <div id="Div1" runat="server">
                                    <asp:GridView ID="grdValue" runat="server" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="FDate"
                                        Width="99.9%" EmptyDataText="" BackColor="White" 
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"> 
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:StartPeriod %>" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:OpenDebit %>" SortExpression="odacc" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblodacc" Text='<%# Eval("odacc","{0:N2}") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="200px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:OpenCredit %>" SortExpression="ocacc" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblocacc" Text='<%# Eval("ocacc","{0:N2}") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="200px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:AcBal %>" SortExpression="Depamount" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDepamount" Text='<%# Eval("depamount","{0:N2}") %>' runat="server"></asp:Label>
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
                                </div>
                            </td>
                        </tr>
                        <tr align="right">
                            <td colspan="4">
                                <div id="FixAssets" runat="server">
                                    <table dir="rtl" width="100%" cellpadding="2px">
                                        <tr align="right">
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label14" runat="server" Text="الأصول الثابتة" Font-Bold="True" Font-Underline="True"
                                                    ForeColor="#0000CC" meta:resourcekey="Label14"></asp:Label>
                                            </td>
                                            <td style="width: 325px;">
                                            </td>
                                            <td style="width: 100px;">
                                            </td>
                                            <td style="width: 275px;">
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label15" runat="server" Text="مجمع الأهلاك" meta:resourcekey="Label15"></asp:Label>
                                            </td>
                                            <td style="width: 325px;">
                                                <asp:DropDownList ID="ddlDepCode" Width="250px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label16" runat="server" Text="رصيد المجمع" meta:resourcekey="Label16"></asp:Label>
                                            </td>
                                            <td style="width: 275px;">
                                                <asp:TextBox ID="txtDepAmount" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label17" runat="server" Text="حساب الاهلاك" meta:resourcekey="Label17"></asp:Label>
                                            </td>
                                            <td style="width: 325px;">
                                                <asp:DropDownList ID="ddlAcDep" Width="250px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label18" runat="server" Text="نسبة الاهلاك" meta:resourcekey="Label18"></asp:Label>
                                            </td>
                                            <td style="width: 275px;">
                                                <asp:TextBox ID="txtDepPer" Text="" MaxLength="10" runat="server"></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator201" runat="server" ControlToValidate="txtDepPer"
                                                    ErrorMessage="<%$ Resources:NumberValue %>" ForeColor="Red" SetFocusOnError="True"
                                                    Type="Currency" Operator="DataTypeCheck" Display="Dynamic" ValidationGroup="1">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label19" runat="server" Text="قيمة الشراء" meta:resourcekey="Label19"></asp:Label>
                                            </td>
                                            <td style="width: 325px;">
                                                <asp:TextBox ID="txtFixPurch" MaxLength="15" runat="server"></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator202" runat="server" ControlToValidate="txtFixPurch"
                                                    ErrorMessage="<%$ Resources:NumberValue %>" ForeColor="Red" SetFocusOnError="True"
                                                    Type="Currency" Operator="DataTypeCheck" Display="Dynamic" ValidationGroup="1">*</asp:CompareValidator>
                                            </td>
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label20" runat="server" Text="تاريخ الشراء" meta:resourcekey="Label20"></asp:Label>
                                            </td>
                                            <td style="width: 275px;">
                                                <asp:TextBox ID="txtFixPurDate" MaxLength="10" runat="server"></asp:TextBox>
                                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                                    TargetControlID="txtFixPurDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                                    PopupPosition="BottomLeft" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="CostCenters" runat="server">
                                    <table dir="rtl" width="100%" cellpadding="2px">
                                        <tr align="right">
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label21" runat="server" Text="المنطقة" meta:resourcekey="Label21"></asp:Label>
                                            </td>
                                            <td style="width: 325px;">
                                                <asp:DropDownList ID="ddlArea" Width="250px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label22" runat="server" Text="الفرع" meta:resourcekey="Label22"></asp:Label>
                                            </td>
                                            <td style="width: 275px;">
                                                <asp:DropDownList ID="ddlCostCenter" Width="250px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label23" runat="server" Text="المشروع" meta:resourcekey="Label23"></asp:Label>
                                            </td>
                                            <td style="width: 325px;">
                                                <asp:DropDownList ID="ddlProject" Width="250px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label24" runat="server" Text="حساب التكاليف" meta:resourcekey="Label24"></asp:Label>
                                            </td>
                                            <td style="width: 275px;">
                                                <asp:DropDownList ID="ddlCostAcc" Width="250px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label25" runat="server" Text="الموظف" meta:resourcekey="Label25"></asp:Label>
                                            </td>
                                            <td style="width: 325px;">
                                                <asp:DropDownList ID="ddlEmpCode" Width="250px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label26" runat="server" Text="السيارة" meta:resourcekey="Label26"></asp:Label>
                                            </td>
                                            <td style="width: 275px;">
                                                <asp:DropDownList ID="ddlCarNo" Width="250px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Button ID="Button1" Visible="false" runat="server" OnClick="Button1_Click" Text="Button" />
                                &nbsp;
                            </td>
                            <td style="width: 325px;">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" CssClass="playbeep"
                                    ValidationGroup="1" EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء" meta:resourcekey="lblReason"></asp:Label>
                            </td>
                            <td style="width: 275px;">
                                <asp:TextBox ID="txtReason" Width="300px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="<%$ Resources:EnterDeleteReason %>" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="<%$ Resources:New %>" CommandName="New"
                                    ImageUrl="<%$ Resources:NewImage %>" ToolTip="<%$ Resources:NewTooltip %>" ValidationGroup="1"
                                    OnClientClick='<%$ Resources:NewConfirm %>' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="<%$ Resources:Edit %>" CommandName="Edit"
                                    ImageUrl="<%$ Resources:EditImage %>" ToolTip="<%$ Resources:EditTooltip %>" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="<%$ Resources:Clear %>" CommandName="Clear"
                                    ImageUrl="<%$ Resources:ClearImage %>" ToolTip="<%$ Resources:ClearTooltip %>" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="<%$ Resources:Delete %>" CommandName="Delete"
                                    ValidationGroup="1" ImageUrl="<%$ Resources:DeleteImage %>" ToolTip="<%$ Resources:DeleteTooltip %>"
                                    OnClientClick='<%$ Resources:DeleteConfirm %>' OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="<%$ Resources:Search %>" CommandName="Find"
                                    ImageUrl="<%$ Resources:SearchImage %>" ToolTip="<%$ Resources:SearchTooltip %>" OnClick="BtnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
            </fieldset>
        </div>
        <br />
    </center>
</asp:Content>
