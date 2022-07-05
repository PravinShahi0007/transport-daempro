<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebEmpSalOp.aspx.cs" Inherits="ACC.WebEmpSalOp" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            $("input[name*='grdAbs'],select[name*='grdAbs']").change(function (event) {
                var res = event.target.id.split("_");
                var ctrl = document.getElementById("ContentPlaceHolder1_grdAbs_txtAction_" + res[3]);
                ctrl.value = "123";
                $(this).addClass('ChangedText');
                $(this).ToolTip = '1';
            });
            SetMyStyle();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
            <h3 align="center">
                <asp:Label ID="LblHeader" runat="server" Text="[ مؤثرات الرواتب ]"></asp:Label>
           </h3>
             <div class="box box-info" align="right">
     <div class="body">
                                    <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                        <asp:Label ID="Label2" runat="server" Text="الإدارة"></asp:Label>
                 
                        <asp:DropDownList ID="ddlSection" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                        </asp:DropDownList>
                  
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Button" Visible="false" onclick="Button1_Click" />
                     </div></div></div>
                 <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                        <asp:Label ID="Label3" runat="server" Text="الشهر"></asp:Label>
                  
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                        </asp:DropDownList>
                  </div></div></div>
            <div class="table-responsive table">
                <asp:GridView ID="grdAbs" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    GridLines="None" AutoGenerateColumns="False" AllowPaging="False" DataKeyNames="EmpCode"
                    PageSize="2000" Width="99.9%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="الرقم">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" Text='<%# Eval("EmpCode") %>' NavigateUrl='<%# string.Format("~/WebMontlyAttend.aspx?AreaNo={0}&StoreNo={1}&EmpCode={2}&FMonth={3}&FYear={4}",AreaNo,StoreNo,Eval("EmpCode"),Eval("Month1"),Eval("Year1")) %>' Target="_blank" runat="server"></asp:HyperLink>   
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم الموظف">
                            <ItemTemplate>
                                <asp:Label ID="LblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                <asp:HiddenField ID="txtAction" Value="" runat="server" />
                                <ajax:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel1"
                                    TargetControlID="LblName" DynamicContextKey='<%# Eval("EmpCode").ToString()+"/"+Eval("Year1").ToString() %>'
                                    DynamicControlID="Panel1" DynamicServicePath="WebEmpSalOp.aspx" DynamicServiceMethod="GetSalOPDynamicContent"
                                    Position="Bottom">
                                </ajax:PopupControlExtender>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="بدون عذر">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAbs0" MaxLength="10" Text='<%# Bind("Abs0") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="مرضي">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAbs1" MaxLength="10" Text='<%# Bind("Abs1") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أضطراري">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAbs2" MaxLength="10" Text='<%# Bind("Abs2") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أجازة براتب">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAbs3" MaxLength="10" Text='<%# Bind("Abs3") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أجازة بدون راتب">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAbs4" MaxLength="10" Text='<%# Bind("Abs4") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أجازة أخرى">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAbs5" MaxLength="10" Text='<%# Bind("Abs5") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أضافي الجمع">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOver0" MaxLength="10" Text='<%# Bind("Over0") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أضافي ساعات">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOver1" MaxLength="10" Text='<%# Bind("Over1") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اعياد">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOver2" MaxLength="10" Text='<%# Bind("Over2") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاخيرات دقائق">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOver3" MaxLength="10" Text='<%# Bind("Over3") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="جزاءات أيام">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPen0" MaxLength="10" Text='<%# Bind("Pen0") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="41px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ملاحظات">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemark" MaxLength="200" Text='<%# Bind("Remark") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="45px" />
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

           <div class="table-responsive">
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    GridLines="None" AutoGenerateColumns="False" AllowPaging="False" DataKeyNames="EmpCode"
                    PageSize="2000" Width="99.9%" Visible="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="الرقم">
                            <ItemTemplate>
                                <asp:HyperLink ID="LblEmpCode" Text='<%# Bind("EmpCode") %>' NavigateUrl='<%# string.Format("~/WebSal.aspx?FNum={0}&Month={1}&Year={2}",Eval("EmpCode"),Eval("Month1"),Eval("Year1")) %>' Target="_blank" runat="server"></asp:HyperLink>   
                            </ItemTemplate>
                            <ControlStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم الموظف">
                            <ItemTemplate>
                                <asp:Label ID="LblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="عدد الايام">
                            <ItemTemplate>
                                <asp:Label ID="LblAbs0" runat="server" Text='<%# Bind("Abs0") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="الاضافي">
                            <ItemTemplate>
                                <asp:Label ID="LblAbs2" runat="server" Text='<%# Bind("Abs2") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="45px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أجمالي الراتب">
                            <ItemTemplate>
                                <asp:Label ID="LblNet0" runat="server" Text='<%# Bind("Net0") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="55px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الحسميات">
                            <ItemTemplate>
                                <asp:Label ID="LblAbs3" runat="server" Text='<%# Bind("Abs3") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="45px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الذمم">
                            <ItemTemplate>
                                <asp:HyperLink ID="LblOver0" Text='<%# Eval("Over0") %>' NavigateUrl='<%# UrlHelper(Eval("EmpCode")) %>' Target="_blank" runat="server"></asp:HyperLink> 
                            </ItemTemplate>
                            <ControlStyle Width="70px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="قسط السلفة">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDed03" MaxLength="10" Text='<%# Bind("Ded03") %>' 
                                    runat="server" AutoPostBack="True" ontextchanged="txtDed03_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نسبة الحسميات">
                            <ItemTemplate>
                                <asp:Label ID="LblPer0" runat="server" Text='<%# Bind("Per0") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="صافي الراتب">
                            <ItemTemplate>
                                <asp:Label ID="LblNet00" runat="server" Text='<%# Bind("Net00") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="55px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ملاحظات">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemark" MaxLength="200" Text='<%# Bind("Remark") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ControlStyle Width="50px" />
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

          <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                            <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                     
                            <asp:TextBox ID="txtUserName"  runat="server" MaxLength="50" BackColor="#E8E8E8"
                                CssClass="MouseStop form-control" Enabled="false"></asp:TextBox>
                      </div></div></div>
                                        <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                            <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                   
                            <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                CssClass="MouseStop form-control" Enabled="false">                                                               
                            </asp:TextBox>
                      </div></div></div>
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                <table dir="rtl" width="100%" cellpadding="2px">
                    <tr align="center">
                        <td colspan="4">
                            <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات مؤثرات الرواتب" Width="64px"
                                ValidationGroup="1" OnClick="BtnEdit_Click" />
                            <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                            <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                ImageUrl="~/images/print.png" ValidationGroup="1" ToolTip="طباعة مؤثرات الرواتب"
                                OnClick="BtnPrint_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">
                                المرفقات
                                <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                            </h4>
                             <div class="card-tools">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                            <i class="fas fa-minus"></i>
                                        </button>
                                    </div>
                        </div>
                        <div class="card-body" style="display:none;">
                            <asp:Panel ID="Panel20" runat="server">
                    <asp:Panel ID="Panel10" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                        BorderColor="Maroon">
                         <div class="table-responsive">
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
                        </asp:GridView></div>
                        
                        <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel10"
                        ExpandControlID="Panel20" CollapseControlID="Panel20" Collapsed="True" TextLabelID="Label34"
                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                    </asp:Panel>
                    
                            <div class="form-row">
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                        ValidationGroup="1" />
                                </div>
                            </div>
          

                    </asp:Panel>
                        </div>


                    </div>
                    
                   
                </div>
                <br />
                <div id="divStep1" runat="server" class="ColorRounded4Corners" style="width: 99.8%">
                    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                        border: solid 2px #800000">
                        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                            <asp:Literal ID="Literal4" runat="server" Text="<b>[  أعتماد المدير المباشر ]</b>"></asp:Literal>
                        </legend>
                        <center>
                            <table width="99.5%" dir="rtl">
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark1" runat="server" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark1" MaxLength="300" TextMode="MultiLine" CssClass="form-control"
                                            Height="100px" runat="server"></asp:TextBox>
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
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="left" style="width: 300px;" rowspan="3">
                                        <asp:ImageButton ID="BtnAgree1" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1"
                                            CssClass="ops" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                            OnClick="BtnAgree1_Click" />
                                        <asp:ImageButton ID="BtnDisagree1" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1"
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' OnClick="BtnDisagree1_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="LblAgreeUser1" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser1" CssClass="form-control" runat="server" BackColor="#E8E8E8"
                                            ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate1" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate1" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </fieldset>
                </div>
                <br />
                <div id="divStep2" runat="server" class="ColorRounded4Corners" style="width: 99.8%">
                    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                        border: solid 2px #800000">
                        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                            <asp:Literal ID="lblManage1" runat="server" Text="<b>[  أعتماد الشئون الأدارية ]</b>"></asp:Literal>
                        </legend>
                        <center>
                            <table width="99.5%" dir="rtl">
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark2" runat="server" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark2" CssClass="form-control" MaxLength="300" TextMode="MultiLine" Width="99%" 
                                            Height="100px" runat="server"></asp:TextBox>
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
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="left" style="width: 300px;" rowspan="3">
                                        <asp:ImageButton ID="BtnAgree2" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1"
                                            CssClass="ops" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                            OnClick="BtnAgree2_Click" />
                                        <asp:ImageButton ID="BtnDisagree2" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1"
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' OnClick="BtnDisagree2_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUser2" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser2" CssClass="form-control" runat="server" BackColor="#E8E8E8"
                                            ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate2" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate2" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </fieldset>
                </div>
                <br />
                <div id="divStep3" runat="server" class="ColorRounded4Corners" style="width: 99.8%">
                    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                        border: solid 2px #800000">
                        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                            <asp:Literal ID="Literal3" runat="server" Text="<b>[  أعتماد الشئون الأدارية ]</b>"></asp:Literal>
                        </legend>
                        <center>
                            <table width="99.5%" dir="rtl">
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark3" runat="server" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark3" MaxLength="300" TextMode="MultiLine" CssClass="form-control"
                                            Height="100px" runat="server"></asp:TextBox>
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
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="left" style="width: 300px;" rowspan="3">
                                        <asp:ImageButton ID="BtnAgree3" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1"
                                            CssClass="ops" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                            OnClick="BtnAgree3_Click" />
                                        <asp:ImageButton ID="BtnDisagree3" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1"
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' OnClick="BtnDisagree3_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUser3" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser3" CssClass="form-control" runat="server" BackColor="#E8E8E8"
                                            ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate3" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate3" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </fieldset>
                </div>
                <br />
                <div id="divStep4" runat="server" class="ColorRounded4Corners" style="width: 99.8%">
                    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                        border: solid 2px #800000">
                        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                            <asp:Literal ID="Literal2" runat="server" Text="<b>[  أعتماد الحسابات ]</b>"></asp:Literal>
                        </legend>
                        <center>
                            <table width="99.5%" dir="rtl">
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark4" runat="server" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark4" MaxLength="300" TextMode="MultiLine" CssClass="form-control" 
                                            Height="100px" runat="server"></asp:TextBox>
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
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="left" style="width: 300px;" rowspan="3">
                                        <asp:ImageButton ID="BtnAgree4" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1"
                                            CssClass="ops" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                            OnClick="BtnAgree4_Click" />
                                        <asp:ImageButton ID="BtnDisagree4" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1"
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' OnClick="BtnDisagree4_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUser4" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser4" CssClass="form-control" runat="server" BackColor="#E8E8E8"
                                            ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate4" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate4" runat="server" CssClass="form-control" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </fieldset>
                </div>
                <br />
                <div id="divStep5" runat="server" class="ColorRounded4Corners" style="width: 99.8%">
                    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                        border: solid 2px #800000">
                        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                            <asp:Literal ID="Literal1" runat="server" Text="<b>[  أعتماد رئيس الحسابات ]</b>"></asp:Literal>
                        </legend>
                        <center>
                            <table width="99.5%" dir="rtl">
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark5" runat="server" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark5" MaxLength="300" TextMode="MultiLine" CssClass="form-control" 
                                            Height="100px" runat="server"></asp:TextBox>
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
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="left" style="width: 300px;" rowspan="3">
                                        <asp:ImageButton ID="BtnAgree5" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1"
                                            CssClass="ops" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                            OnClick="BtnAgree5_Click" />
                                        <asp:ImageButton ID="BtnDisagree5" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1"
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' OnClick="BtnDisagree5_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUser5" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser5" CssClass="form-control" runat="server" BackColor="#E8E8E8"
                                            ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate5" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate5" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </fieldset>
                </div>
                <div id="divStep6" runat="server" class="ColorRounded4Corners" style="width: 99.8%">
                    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                        border: solid 2px #800000">
                        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                            <asp:Literal ID="Literal5" runat="server" Text="<b>[  أعتماد الشئون الأدارية ]</b>"></asp:Literal>
                        </legend>
                        <center>
                            <table width="99.5%" dir="rtl">
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark6" runat="server" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark6" MaxLength="300" TextMode="MultiLine" CssClass="form-control"
                                            Height="100px" runat="server"></asp:TextBox>
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
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="left" style="width: 300px;" rowspan="3">
                                        <asp:ImageButton ID="BtnAgree6" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1"
                                            CssClass="ops" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                            OnClick="BtnAgree6_Click" />
                                        <asp:ImageButton ID="BtnDisagree6" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1"
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' OnClick="BtnDisagree6_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUser6" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser6" CssClass="form-control" runat="server" BackColor="#E8E8E8"
                                            ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate6" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate6" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </fieldset>
                </div>

                      <div id="divStep7" runat="server" class="ColorRounded4Corners" style="width: 99.8%">
                    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                        border: solid 2px #800000">
                        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                            <asp:Literal ID="Literal6" runat="server" Text="<b>[  أعتماد الرئيس التنفيذي ]</b>"></asp:Literal>
                        </legend>
                        <center>
                            <table width="99.5%" dir="rtl">
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblRemark7" runat="server" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td align="right" colspan="3" rowspan="5">
                                        <asp:TextBox ID="txtAgreeRemark7" MaxLength="300" TextMode="MultiLine" CssClass="form-control"
                                            Height="100px" runat="server"></asp:TextBox>
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
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="left" style="width: 300px;" rowspan="3">
                                        <asp:ImageButton ID="BtnAgree7" runat="server" AlternateText="موافق" CommandName="Agree1"
                                            ImageUrl="~/images/Agree_641.png" ToolTip="الموافقة على الطلب" ValidationGroup="1"
                                            CssClass="ops" OnClientClick='return confirm("هل أنت متاكد من الموافقة على الطلب؟")'
                                            OnClick="BtnAgree7_Click" />
                                        <asp:ImageButton ID="BtnDisagree7" runat="server" AlternateText="رفض" CommandName="Disagree1"
                                            ImageUrl="~/images/DisAgree_641.png" ToolTip="رفض الطلب" CssClass="ops" ValidationGroup="1"
                                            OnClientClick='return confirm("هل أنت متاكد من رفض الطلب؟")' OnClick="BtnDisagree7_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                    <td align="right" style="width: 300px;">
                                    </td>
                                    <td align="right" style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUser7" runat="server" Text="المستخدم"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUser7" CssClass="form-control" runat="server" BackColor="#E8E8E8"
                                            ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="lblAgreeUserDate7" runat="server" Text="تاريخ التعميد"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 300px;">
                                        <asp:TextBox ID="txtAgreeUserDate7" CssClass="form-control" runat="server" BackColor="#E8E8E8" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </fieldset>
                </div>
                <br />
            </center></div></div></div>
        </fieldset>
    </div></div>
    <asp:Panel ID="Panel1" runat="server" CssClass="popupControl">
    </asp:Panel>
</asp:Content>
