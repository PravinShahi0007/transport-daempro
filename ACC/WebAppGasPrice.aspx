<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebAppGasPrice.aspx.cs" Inherits="ACC.WebAppGasPrice" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ColorRounded4Corners col-md-12 col-sm-12 col-xs-12">

        <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>[بطاقة تسعير الغاز / التطبيق ]</b></legend>

        <div class="box box-info" align="right">
            <div class="body">
                <div class="row">

                    
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label7" runat="server" Text="نوع الخدمة*"></asp:Label>

                                <asp:DropDownList ID="ddltype11" CssClass="form-control" runat="server"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="ddltype11_SelectedIndexChanged">
                                    <asp:ListItem Value="-1" Text="إختر الخدمة"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="اسطوانة جديدة"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="استبدال"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddltype11"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار النوع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label6" runat="server" Text="نوع الاسطوانة*"></asp:Label>

                                <asp:DropDownList ID="ddlcyl" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcyl_SelectedIndexChanged">
                                    <asp:ListItem Value="-1" Text="إختر النوع"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="11 كغم فايبر - منظم عادي"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="11 كغم معدن - منظم عادي"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="22 كغم معدن - منظم عادي"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="11 كغم معدن - منظم كبس"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlcyl"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار النوع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="LblCode" runat="server" Text=""></asp:Label>

                                <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop form-control" ReadOnly="True" Width="60px" Visible="False"></asp:TextBox>



                                <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات التسعير" OnClick="BtnFind_Click" Text="بحث" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">

                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label10" runat="server" Text="الاسم*"></asp:Label>

                                <asp:TextBox ID="txtname" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="التكلفة*"></asp:Label>

                                <asp:TextBox ID="txtcost" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcost"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج التكلفة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtcost"
                                    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="سعر البيع*"></asp:Label>


                                <asp:TextBox ID="txtprice" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtprice"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج السعر" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprice"
                                    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="سعر الخدمة*"></asp:Label>

                                <asp:TextBox ID="txtprice2" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtprice2"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج السعر" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtprice2"
                                    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />

                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة تسعير" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات التسعير؟")'
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات التسعير" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات التسعير" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات التسعير؟")' OnClick="BtnDelete_Click" Text="إلغاء" />
                            </div>
                        </div>
                    </div>


                    <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>[ بيانات التسعير ]</b></legend>

                    <div class="table-responsive">
                        <!-- edited by hanan3 (update gridview) -->
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="Black" GridLines="None"
                            AutoGenerateColumns="False" DataKeyNames="FType3" Width="99.9%" EmptyDataText="لا توجد بيانات">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="رقم الصنف" HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" Text='<%# Bind("FType3") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="نوع الاسطوانة" SortExpression="FType3" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" Text='<%# getType(int.Parse(Eval("FType3").ToString())) %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="تكلفة الشراء" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice2" Text='<%# Bind("Cost")%>'
                                            runat="server"></asp:Label>

                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="تكلفة الاستبدال" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice3" Text='<%# Bind("Cost")%>'
                                            runat="server"></asp:Label>

                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="سعر البيع" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice" Text='<%# Bind("Price")%>'
                                            runat="server"></asp:Label>

                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="سعر الخدمة" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice4" Text='<%# Bind("SerPrice")%>'
                                            runat="server"></asp:Label>

                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="إجمالي البيع" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltotal" Text='<%# (int.Parse(Eval("Price").ToString())+int.Parse(Eval("SerPrice").ToString())).ToString()%>'
                                            runat="server"></asp:Label>

                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
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

</asp:Content>
