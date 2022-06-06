<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebMontlyAttend.aspx.cs" Inherits="ACC.WebMontlyAttend" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRound4Courner">
            <div style="text-align: right; float: right; display: block;">
            </div>
            <center>
                <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                    border: solid 2px #800000">
                    <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                        كشف الحضور و الانصراف الشهري</legend>
                    <table width="99%">
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label2" runat="server" Text="الموظف"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlEmp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 150px">
                                &nbsp;
                            </td>
                            <td rowspan="2" style="text-align: center" style="width: 300px">
                                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                    ImageUrl="~/images/Process.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print_64A.png"
                                    OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"
                                    ImageUrl="~/images/Excel.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label3" runat="server" Text="الشهر"></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2" style="text-align: right;">
                                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                &nbsp;
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <%--<div style="width: 100%; height: 625px; overflow: none; overflow-x: auto; border: 1px solid #800000;">--%>
                <div style="width: 100%;overflow: none; overflow-x: auto; border: 1px solid #800000;">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="False" PageSize="200"
                        Width="99.9%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="اليوم/الوردية">
                                <ItemTemplate>
                                    <asp:Label ID="Lblday" runat="server" Text='<%# Bind("FDate2") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlShift" SelectedValue='<%# Eval("Shift") %>' runat="server"
                                        AutoPostBack="True" OnInit="ddlShift_Init" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ControlStyle Width="140px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="وقت الحضور">
                                <ItemTemplate>
                                    <asp:Label ID="Lblin" runat="server" Text='<%# Bind("STime2") %>'></asp:Label>                        
                                    <asp:TextBox ID="txtInTime" Text='<%# Bind("STime") %>' MaxLength="15" 
                                        runat="server" Width="75px" AutoPostBack="True" 
                                        ontextchanged="txtInTime_TextChanged" />            
                                    <asp:Button ID="BtnSwap2" runat="server" ToolTip="نقل توقيت الانصراف إلى الحضور" Visible='<%# string.IsNullOrEmpty(Eval("STime").ToString().Trim()) %>'
                                        Text="نقل التوقيت" OnClick="BtnSwap2_Click" />
                                </ItemTemplate>
                                <ControlStyle Width="75px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="وقت الإنصراف">
                                <ItemTemplate>
                                    <asp:Label ID="Lblout" runat="server" Text='<%# Bind("ETime2") %>'></asp:Label>
                                    <asp:TextBox ID="txtOutTime" Text='<%# Bind("ETime") %>' MaxLength="15" 
                                        runat="server" Width="75px" AutoPostBack="True" 
                                        ontextchanged="txtOutTime_TextChanged" />
                                    <asp:Button ID="BtnSwap"  runat="server" ToolTip="نقل توقيت الحضور إلى الانصراف" Visible='<%# string.IsNullOrEmpty(Eval("ETime").ToString().Trim()) %>'
                                        Text="نقل التوقيت" OnClick="BtnSwap_Click" />
                                </ItemTemplate>
                               <ControlStyle Width="75px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ساعات الحضور">
                                <ItemTemplate>
                                    <asp:Label ID="LblAttend" runat="server" Text='<%# Bind("MyAttend") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="txttotal2" Text='' Width="70px" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="75px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أذن حضور">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkSPer" Checked='<%# Eval("SPer") %>' runat="server" AutoPostBack="True"
                                        OnCheckedChanged="ChkSPer_CheckedChanged" />
                                    <asp:TextBox ID="txtSRemark" MaxLength="50" Visible='<%# Eval("SPer") %>' Text='<%# Bind("SRemark") %>'
                                        runat="server" AutoPostBack="True" ontextchanged="txtSRemark_TextChanged"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="75px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أذن أنصراف">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkEPer" Checked='<%# Eval("EPer") %>' runat="server" AutoPostBack="True"
                                        OnCheckedChanged="ChkEPer_CheckedChanged" />
                                    <asp:TextBox ID="txtERemark" MaxLength="50" Visible='<%# Eval("EPer") %>' Text='<%# Bind("ERemark") %>'
                                        runat="server" AutoPostBack="True" ontextchanged="txtERemark_TextChanged"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="75px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="التاخير">
                                <ItemTemplate>
                                    <asp:Label ID="LblDelay" runat="server" Text='<%# Bind("Delay") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotDelay" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="75px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ملاحظات">
                                <ItemTemplate>
                                    <asp:Label ID="LblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblSRemark" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="200px"></ControlStyle>
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
                        <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                </div>
                <br />
                <asp:GridView ID="grdAbs" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    Caption="الغياب" GridLines="None" AutoGenerateColumns="False" AllowPaging="False"
                    PageSize="200" Width="99.9%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="اليوم">
                            <ItemTemplate>
                                <asp:Label ID="LblFDate" runat="server" Text='<%# Bind("FDate2") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="140px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نوع الغياب">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlFType" runat="server" AutoPostBack="True" SelectedValue='<%# Eval("FType") %>'  OnSelectedIndexChanged="ddlFType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">بدون عذر</asp:ListItem>
                                    <asp:ListItem Value="1">أجازة مرضية</asp:ListItem>
                                    <asp:ListItem Value="2">أضطراري</asp:ListItem>
                                    <asp:ListItem Value="3">أجازة براتب</asp:ListItem>
                                    <asp:ListItem Value="4">أجازة بدون راتب</asp:ListItem>
                                    <asp:ListItem Value="9">بدون خصم</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <ControlStyle Width="140px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ملاحظات">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemark" MaxLength="50" Text='<%# Bind("Remark") %>' 
                                    runat="server" AutoPostBack="True" ontextchanged="txtRemark_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="250px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="المستند">
                                <ItemTemplate>
                               <asp:HyperLink ID="lblRemark2" Text='<%# Eval("FNo2") %>' ToolTip="عرض المستند"
                                            NavigateUrl='<%# Eval("Remark2") %>' Target="_blank" runat="server"></asp:HyperLink>

                                </ItemTemplate>
                                <ControlStyle Width="50px"></ControlStyle>
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
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                <br />
            </center>
        </div>
    </center>
</asp:Content>
