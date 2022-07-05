<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebMontlyAttend.aspx.cs" Inherits="ACC.WebMontlyAttend" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">


        <fieldset>
            <!--editing by chanda verma-->
            <div class="card-header">
                <h4 class="card-title">كشف الحضور و الانصراف الشهري
                </h4>
            </div>
            <div class="box box-info" align="right">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label2" runat="server" Text="الموظف"></asp:Label>

                                    <asp:DropDownList ID="ddlEmp" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged">
                                    </asp:DropDownList>


                                    <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                        ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                    <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                        OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                                    <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"
                                        ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                        OnClick="BtnExcel_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label3" runat="server" Text="الشهر"></asp:Label>

                                    <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                    </asp:DropDownList>

                                    <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                    &nbsp;
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <%--<div style="width: 100%; height: 625px; overflow: none; overflow-x: auto; border: 1px solid #800000;">--%>
                        <div class="table-responsive">
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
                                                OnTextChanged="txtInTime_TextChanged" />
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
                                                OnTextChanged="txtOutTime_TextChanged" />
                                            <asp:Button ID="BtnSwap" runat="server" ToolTip="نقل توقيت الحضور إلى الانصراف" Visible='<%# string.IsNullOrEmpty(Eval("ETime").ToString().Trim()) %>'
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
                                                runat="server" AutoPostBack="True" OnTextChanged="txtSRemark_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="75px"></ControlStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="أذن أنصراف">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkEPer" Checked='<%# Eval("EPer") %>' runat="server" AutoPostBack="True"
                                                OnCheckedChanged="ChkEPer_CheckedChanged" />
                                            <asp:TextBox ID="txtERemark" MaxLength="50" Visible='<%# Eval("EPer") %>' Text='<%# Bind("ERemark") %>'
                                                runat="server" AutoPostBack="True" OnTextChanged="txtERemark_TextChanged"></asp:TextBox>
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
                        <div class="table-responsive">
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
                                            <asp:DropDownList ID="ddlFType" runat="server" AutoPostBack="True" SelectedValue='<%# Eval("FType") %>' OnSelectedIndexChanged="ddlFType_SelectedIndexChanged">
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
                                                runat="server" AutoPostBack="True" OnTextChanged="txtRemark_TextChanged"></asp:TextBox>
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
                        </div>
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                    </div>
                </div>
            </div>
        </fieldset>
        <!--editing by chanda verma-->
    </div>

</asp:Content>
