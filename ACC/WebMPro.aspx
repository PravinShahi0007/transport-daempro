<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebMPro.aspx.cs" Inherits="ACC.WebMPro" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .containerStep {
            width: 780px;
            margin: 6px auto;
            z-index: 5;
        }

        .progressbar {
            margin: 0;
            padding: 0;
            counter-reset: step;
            z-index: 7;
        }

            .progressbar li {
                list-style-type: none;
                width: 12%;
                float: right;
                font-size: 12px;
                position: relative;
                text-align: center;
                color: #7d7d7d;
                z-index: 1;
            }

                .progressbar li:before {
                    width: 30px;
                    height: 30px;
                    content: counter(step);
                    counter-increment: step;
                    line-height: 30px;
                    border: 2px solid #7d7d7d;
                    display: block;
                    text-align: center;
                    margin: 0 auto 6px auto;
                    border-radius: 50%;
                    background-color: white;
                }

                .progressbar li:after {
                    width: 100%;
                    height: 2px;
                    content: '';
                    position: absolute;
                    background-color: #7d7d7d;
                    top: 15px;
                    right: -32%;
                    z-index: -1;
                }

                .progressbar li:first-child:after {
                    content: none;
                }

                .progressbar li.active {
                    color: green;
                }

                    .progressbar li.active:before {
                        border-color: #55b776;
                    }

                    .progressbar li.active + li:after {
                        background-color: #55b776;
                    }

                .progressbar li.current {
                    color: blue;
                }

                    .progressbar li.current:before {
                        border-color: #55b776;
                    }

                .progressbar li.refuse {
                    color: red;
                }

                    .progressbar li.refuse:before {
                        border-color: #55b776;
                    }

                .progressbar li.transfer {
                    color: Orange;
                }

                .progressbar li.refuse:before {
                    border-color: #55b776;
                }
    </style>
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
            var ace1Value = $get('ContentPlaceHolder1_txtEmpCode');
            var ace2Value = $get('ContentPlaceHolder1_txtName2');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
            <h3 align="center" >[ التشغيل الشهري ]</h3>
            <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label1" runat="server" Text="السنة"></asp:Label>

                                    <asp:DropDownList ID="ddlYear" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                    </asp:DropDownList>


                                    <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ImageUrl="~/images/setting.png"
                                        ToolTip="التشغيل الشهري للمرتبات" OnClick="BtnProcess_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label2" runat="server" Text="الشهر"></asp:Label>

                                    <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                    </asp:DropDownList>


                                    <asp:CheckBox ID="ChkEmpCode" runat="server" AutoPostBack="true" Checked="false"
                                        Text="كود الموظف" OnCheckedChanged="ChkEmpCode_CheckedChanged" />
                                </div>
                    </div>
                        </div>
                        <asp:DropDownList ID="ddlEmpCode" CssClass="form-control" runat="server" Visible="false">
                        </asp:DropDownList>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="lblStatus" runat="server" CssClass="blink" ForeColor="Red" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:ImageButton ID="BtnPostJv" runat="server" AlternateText="ترحيل قيد الرواتب"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من ترحيل قيد الرواتب؟")'
                                    ImageUrl="~/images/JVPost_642.png" ToolTip="ترحيل قيد الرواتب" OnClick="BtnPostJv_Click" />

                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء التشغيل" ImageUrl="~/images/cut_642.png"
                                    ToolTip="إلغاء التشغيل الشهري" OnClientClick='return confirm("هل أنت متاكد من الغاء التشغيل الشهري؟")'
                                    OnClick="BtnDelete_Click" />
                            </div>
                        </div>
                    </div>
                    <%-- *********************Ankur kumar  *********************** --%>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="المستخدم"></asp:Label>

                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="بتاريخ"></asp:Label>

                                <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="lblEmp" runat="server" Text="الموظف"></asp:Label>

                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" autocomplete="off" MaxLength="100"></asp:TextBox>
                                <asp:TextBox ID="txtEmpCode" CssClass="form-control" runat="server" MaxLength="50" Enabled="false" BackColor="#E8E8E8"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtName"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionEMP" OnClientItemSelected="Name_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                <asp:Button ID="BtnAdd" runat="server" Text="+ تحويل راتب"
                                    OnClick="BtnAdd_Click" />
                                <asp:Button ID="BtnRemove" runat="server" Text="- الغاء التحويل"
                                    OnClick="BtnRemove_Click" />
                            </div>
                        </div>
                    </div>


                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <b>
                                    <asp:Label ID="Label5" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ حالة المؤثرات ]"></asp:Label></b>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive table">
                        <asp:GridView ID="grdActiveTran" CellPadding="4" AutoGenerateColumns="False" runat="server" AllowPaging="false"
                            ForeColor="#333333" GridLines="None" PageSize="20" DataKeyNames="Section" Width="99.9%">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="المعاملة" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lblName" Text='<%# Eval("Name").ToString() %>' ToolTip="عرض المعاملة"
                                            NavigateUrl='<%# string.Format("~/WebEmpSalOp.aspx?AreaNo={0}&StoreNo={1}&FMode=1&Month={2}&Year={3}&Dep={4}&FStep=-1",AreaNo,StoreNo,Eval("Month1"),Eval("Year1"),Eval("Section")) %>' Target="_blank" runat="server"></asp:HyperLink>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="خط سير المعاملة" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal122" Text='<%# Eval("MakeDiv") %>' runat="server"></asp:Literal>
                                    </ItemTemplate>
                                    <ControlStyle Width="780px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center"
                                Font-Bold="True" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="center" />
                            <RowStyle BackColor="#EFF3FB" Font-Size="Medium" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>

                    <div style="text-align: left; width: 50%; float: left;" id="divTransfer" runat="server">
                        <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                            Direction="RightToLeft" ForeColor="#FFFF99">
                            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                <div style="float: right;">
                                    رفع ملفات الرواتب المحوله
                                </div>
                                <div style="float: right; margin-right: 20px;">
                                    <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                </div>
                                <div style="float: left; vertical-align: middle;">
                                    <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="table-responsive table">
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
                        <div class="table-responsive table">
                            <asp:GridView ID="grvData" runat="server" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center"
                                    Font-Bold="True" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
     
    </div></div>
</asp:Content>
