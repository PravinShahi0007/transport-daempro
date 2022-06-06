<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCarMoveLines.aspx.cs"
    Inherits="ACC.WebCarMoveLines" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>خط سير الرحلة</title>  
    <script src="Script/jquery-1.7.js" type="text/javascript"></script>
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            SetMyStyle();
        }

        function SetMyStyle() {
            $(function () {
                //$('input[type="text"],select[name*="ContentPlaceHolder"],input[type="password"]').focusin(function () {
                $('input,select,textarea').focusin(function () {
                    $(this).addClass('HoverHighLightText ');
                });
                //$('input[type="text"],select[name*="ContentPlaceHolder"],input[type="password"]').focusout(function () {
                $('input,select,textarea').focusout(function () {
                    $(this).removeClass('HoverHighLightText');
                });

                //                $('a[target!="_blank"],a[src!="images/Favorites.png"').click(function (e) {
                //                    $.blockUI({ message: '<P>برجاء الانتظار ... جاري معالجة البيانات &nbsp;&nbsp; <img src="images/busy.gif" /></P>' });
                //                });

                $('input,select,textarea').keydown(function (e) {
                    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                    if (key == 13) {
                        e.preventDefault();
                        var inputs = $(this).closest('form').find(':input:visible');
                        inputs.eq(inputs.index(this) + 1).focus();
                    }
                });

                $('table[id*="Content"] tr').mouseover(function () {
                    $(this).addClass('HoverHighLight');
                });
                $('table[id*="Content"] tr').mouseout(function () {
                    $(this).removeClass('HoverHighLight');
                });
            });
        }
    </script>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
            EnablePageMethods="true" EnablePartialRendering="true" runat="server" AsyncPostBackTimeout="36000">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress" runat="server" DynamicLayout="true">
                </asp:UpdateProgress>
                <div>
                    <center>
                        <div class="Round4Courner" style="width: 98%">
                            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                                border: solid 2px #800000">
                                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                                    [ خط سير الرحلة]</b></legend>
                                <center>
                                    <br />
                                    <table dir="rtl" width="99%" cellpadding="2px">
                                        <tr align="right">
                                            <td style="width: 100px;">
                                                <asp:Label ID="LblFrom" runat="server" Text="من"></asp:Label>
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:DropDownList ID="ddlFrom" Width="170" Enabled="false" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 100px;">
                                                <asp:Label ID="Label1" runat="server" Text="إلى"></asp:Label>
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:DropDownList ID="ddlTo" Width="170" Enabled="false" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            PageSize="20" Width="99.9%" EmptyDataText="لا توجد بيانات">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkStatus" runat="server" Checked='<%# Bind("Status") %>' 
                                                            ToolTip="أختيار او عدم اختيار الجهة"  AutoPostBack="true"
                                                            oncheckedchanged="ChkStatus_CheckedChanged" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="20px"></HeaderStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="من موقع" SortExpression="Area1" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblArea1" Text='<%# Bind("Area1") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lbltot" Text="الاجمالي" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                    <ControlStyle Width="150px" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="إلى موقع" SortExpression="Area2" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblArea2" Text='<%# Bind("Area2") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="150px" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المسافة" SortExpression="KM" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtKM" Text='<%# Bind("KM") %>' MaxLength="15" runat="server" 
                                                            AutoPostBack="True" ontextchanged="txtKM_TextChanged"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTotalKM" Text='<%# TotalKM %>' runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                    <ControlStyle Width="80" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المصروف" SortExpression="Cost" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCost" Text='<%# Bind("Cost") %>' MaxLength="15" 
                                                            runat="server" AutoPostBack="True" ontextchanged="txtCost_TextChanged"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTotalCost" Text='<%# TotalCost %>' runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                    <ControlStyle Width="80px" />
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
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label><br />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل خط سير الرحلة"
                                    OnClientClick='return confirm("تعديل خط سير الرحلة؟")' Width="64px" ValidationGroup="1"
                                    OnClick="BtnEdit_Click" />
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
