<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebStores.aspx.cs" Inherits="WHS.WebStores" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD

    <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
            <h3 align="center"><b>[ بيانات المخازن و الورش ]</b></h3>

            <div class="box box-info" align="right">
=======
   
      <div class="ColorRounded4Corners col-md-12 col-sm-12 col-xs-12">
            <fieldset class="Rounded4CornersNoShadow" >
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ بيانات المخازن و الورش ]</b></legend>
              
                   <div class="box box-info" align="right">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                <div class="body">
                    <div class="row">

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
<<<<<<< HEAD
                                    <asp:Label ID="Label1" runat="server" Text="كود الورشة/المخزن"></asp:Label>

                                    <asp:TextBox ID="txtNumber" CssClass="form-control" runat="server" MaxLength="5"></asp:TextBox>
                                    <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                        ToolTip="البحث عن كود الورشة/المخزن" OnClick="BtnFind_Click" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                        ErrorMessage="يجب إدخال كود الورشة/المخزن" ForeColor="Red" SetFocusOnError="True"
                                        Display="Dynamic" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label2" runat="server" Text="الاسم عربي"></asp:Label>

                                    <asp:TextBox ID="txtName1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي"></asp:Label>

                                    <asp:TextBox ID="txtName2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label4" runat="server" Text="المدير المسئول"></asp:Label>

                                    <asp:TextBox ID="txtManager" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label5" runat="server" Text="العنوان"></asp:Label>

                                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label8" runat="server" Text="رقم التليفون"></asp:Label>

                                    <asp:TextBox ID="txtTel" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="Label32" runat="server" Text="ملاحظات"></asp:Label>

                                    <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!--Here update pending by ankur kumar-->
                        <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">
                                    <asp:Label ID="Label13" runat="server">(عرض التفاصيل)</asp:Label></h3>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove" title="Remove">
                                        <i class="fas fa-times"></i>
                                    </button>
                                </div>
                            </div>

                            <div class="card-body" style="display: none;">
                                <asp:Panel ID="Panel1" runat="server" Width="100%">
                                    <table class="table table-responsive table-hover">
=======
                                <asp:Label ID="Label1" runat="server" Text="كود الورشة/المخزن"></asp:Label>
                   
                                <asp:TextBox ID="txtNumber" CssClass="form-control" runat="server" MaxLength="5"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن كود الورشة/المخزن" OnClick="BtnFind_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                    ErrorMessage="يجب إدخال كود الورشة/المخزن" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" ValidationGroup="1">*</asp:RequiredFieldValidator>
                          </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="الاسم عربي"></asp:Label>
                         
                                <asp:TextBox ID="txtName1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                       </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي"></asp:Label>
                        
                                <asp:TextBox ID="txtName2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                          </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="المدير المسئول"></asp:Label>
                        
                                <asp:TextBox ID="txtManager" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                          </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label5" runat="server" Text="العنوان"></asp:Label>
                       
                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                           </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label8" runat="server" Text="رقم التليفون"></asp:Label>
                         
                                <asp:TextBox ID="txtTel" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label32" runat="server" Text="ملاحظات"></asp:Label>
                          
                                <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                          </div></div></div>
                          
                                <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                                    Direction="RightToLeft" ForeColor="#FFFF99">
                                    <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                        <div style="float: right;">
                                            بيانات الحسابات</div>
                                        <div style="float: right; margin-right: 20px;">
                                            <asp:Label ID="Label13" runat="server">(عرض التفاصيل)</asp:Label>
                                        </div>
                                        <div style="float: left; vertical-align: middle;">
                                            <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel1" runat="server" Height="0"  Width="99.3%"
                                    BorderColor="Maroon">
                                    <table dir="rtl" width="100%" cellpadding="2px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                        <tr>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label14" runat="server" Text="حساب المبيعات النقدية"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlCSal" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label15" runat="server" Text="حساب المبيعات الآجلة"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlCRSal" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label16" runat="server" Text="حساب ترجيع المبيعات النقدية"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlRCSal" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label17" runat="server" Text="حساب ترجيع المبيعات الآجلة"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlRCRSal" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label18" runat="server" Text="حساب المشتريات النقدية"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlCPur" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label19" runat="server" Text="حساب المشتريات الآجلة"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlCRPur" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label20" runat="server" Text="حساب ترجيع المشتريات النقدية"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlRCPur" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label21" runat="server" Text="حساب ترجيع المشتريات الآجلة"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlRCRPur" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label22" runat="server" Text="حساب النقدية"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlCash" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label28" runat="server" Text="حساب الخدمات"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlService" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label24" runat="server" Text="حساب الخصم المكتسب"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlPDisc" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 25%; text-align: center">
                                                <asp:Label ID="Label26" runat="server" Text="حساب الخصم المسموح به"></asp:Label>
                                            </td>
                                            <td align="right" style="width: 25%">
                                                <asp:DropDownList ID="ddlSDisc" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
<<<<<<< HEAD
                                
                            </div>

                            </div>
                        </div>


                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                            EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    

                                    <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                        ImageUrl="~/images/data add.png" CssClass="ops" ToolTip="أضافة مخزن/معرض جديد"
                                        ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات المخزن/المعرض؟")'
                                        OnClick="BtnNew_Click" />
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                        ImageUrl="~/images/edit2.png" CssClass="ops" ToolTip="تعديل بيانات مخزن/معرض"
                                        Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                    <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                        ImageUrl="~/images/clear all.png" CssClass="ops" ToolTip="مسح خانات الشاشة"
                                        OnClick="BtnClear_Click" />
                                    <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                        ImageUrl="~/images/delete2.png" CssClass="ops" ToolTip="إلغاء بيانات مخزن/معرض"
                                        OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات المخزن/المعرض؟")'
                                        OnClick="BtnDelete_Click" />
                                    <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                        ImageUrl="~/images/data search.png" CssClass="ops" ToolTip="البحث عن بيانات المخزن/المعرض"
                                        OnClick="BtnSearch_Click" />
                                </div>
                                <div class="form-group"><asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label></div>
                            </div>
                        </div>
                        <div class="table table-responsive table-hover text-center">
                            <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                                GridLines="None" AutoGenerateColumns="False" DataKeyNames="number" AllowPaging="True"
                                PageSize="5" Width="100%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                                OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="أختيار و عرض بيانات المعرض/المخزن"
                                                ImageUrl="~/images/arrow_undo.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="الرقم" SortExpression="number" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnumber" Text='<%# Bind("number") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="الوصف بالعربي" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="300px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="الوصف بالانجليزي" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="300px" />
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
                    </div>
                </div>
            </div>

        </div>
    </div>
=======
                                <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                    ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label13"
                                    ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                    ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                    SuppressPostBack="true" />
                         
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                          
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" CssClass="ops" ToolTip="أضافة مخزن/معرض جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات المخزن/المعرض؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" CssClass="ops" ToolTip="تعديل بيانات مخزن/معرض"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" CssClass="ops" ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" CssClass="ops" ToolTip="إلغاء بيانات مخزن/معرض"
                                    OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات المخزن/المعرض؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png" CssClass="ops" ToolTip="البحث عن بيانات المخزن/المعرض"
                                    OnClick="BtnSearch_Click" />
                       </div></div></div>
                       <div class="table-responsive">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="number" AllowPaging="True"
                            PageSize="5" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="أختيار و عرض بيانات المعرض/المخزن"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الرقم" SortExpression="number" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnumber" Text='<%# Bind("number") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الوصف بالعربي" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="300px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الوصف بالانجليزي" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="300px" />
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
                 </div></div></div>
            </fieldset>
        </div>
  
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
</asp:Content>
