<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebPriceList.aspx.cs" Inherits="ACC.WebPriceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function pageLoad() {
            SetMyStyle();
        }
        function makesum(sender, args) {
            var items = document.getElementById('<%=ddlItems.ClientID %>');
            var Total2 = document.getElementById('ContentPlaceHolder1_grdCodes_lblTotal2');
            var x = 0;
            for (i = 0; i < items.value; i++) {
                var Qty = document.getElementById('ContentPlaceHolder1_grdCodes_txtQty_' + i.toString().trim());
                var Price = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_' + i.toString().trim());
                var Total = document.getElementById('ContentPlaceHolder1_grdCodes_lblTotal_' + i.toString().trim());
                Total.innerHTML = (parseFloat(Qty.value) * parseFloat(Price.value)).toString();
                x += parseFloat(Qty.value) * parseFloat(Price.value);
            }
            Total2.innerHTML = x.toFixed(2).toString();
        }
    </script>
    <style type="text/css">
        .style1 {
            direction: ltr;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <fieldset class="card">
        <div class="card-header">
            <h4 class="card-title">عرض سعر
            </h4>
        </div>
        <div class="card-body">
            <div class="form-row">
                <div class="form-group col-md-2 col-sm-12 col-xm-12">
                    <asp:Label ID="Label1" runat="server" Text="رقم العرض"></asp:Label>
                    *
                </div>
                <div class="form-group col-md-2 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                        Display="Dynamic" ErrorMessage="يجب أختيار رقم العرض" ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-md-2 col-sm-12 col-xm-12">
                    <asp:Label ID="Label42" runat="server" Text="نوع العرض"></asp:Label>
                </div>
                <div class="form-group col-md-4 col-sm-12 col-xm-12">
                    <asp:RadioButtonList ID="rdoVouType" runat="server" RepeatColumns="2"
                        AutoPostBack="True" OnSelectedIndexChanged="rdoVouType_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">سيارات</asp:ListItem>
                        <asp:ListItem Value="1">بضاعة</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group col-md-2 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                        ToolTip="البحث عن بيانات العرض" OnClick="BtnFind_Click" />
                </div>

            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label4" runat="server" Text="التاريخ"></asp:Label>
                    *
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtHDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHDate"
                        Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label7" runat="server" Text="الموافق"></asp:Label>
                    *
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtGDate" MaxLength="10" runat="server" AutoPostBack="True"
                        OnTextChanged="txtGDate_TextChanged" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtGDate"
                        Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGDate"
                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                        ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>م&nbsp;
                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                            TargetControlID="txtGDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                            PopupPosition="BottomLeft" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label6" runat="server" Text="أسم الجهة"></asp:Label>
                    *
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtName" MaxLength="200" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="يجب إدخال أسم الجهة" ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:DropDownList ID="ddlName" CssClass="form-control" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlName_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label10" runat="server" Text="الموضوع"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtSubject" MaxLength="200" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="lblItems" runat="server" Text="البنود"></asp:Label>&nbsp;
                        <asp:DropDownList ID="ddlItems" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                        </asp:DropDownList>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                <div class="form-group col-md-2 col-sm-12 col-xm-12"></div>
                <div class="form-group col-md-4 col-sm-12 col-xm-12">
                    <asp:CheckBox ID="ChkLoc" runat="server" AutoPostBack="True" CssClass="form-control" OnCheckedChanged="ChkLoc_CheckedChanged" Text="نفس الجهات لكل البنود" />

                </div>
            </div>
            <div class="form-row text-center">
                <div class="form-group col-md-12 col-sm-12 col-xm-12">
                    <div id="DivMulti" runat="server">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="true"
                            AutoGenerateColumns="False" DataKeyNames="FNo" Width="100%" EmptyDataText="لا توجد بيانات">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFNo" runat="server" Text='<%# Bind("FNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="50px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من" SortExpression="PlaceofLoading" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPlaceofLoading" CssClass="form-control" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlCarType_SelectedIndexChanged">
                                        </asp:DropDownList><br />
                                        <asp:TextBox ID="txtFrom2" MaxLength="100" runat="server" CssClass="spmargin form-control" Text='<%# Bind("From2") %>' Width="275px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="130px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى" SortExpression="Destination" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlDestination" runat="server" CssClass="form-control" AutoPostBack="false" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                                        </asp:DropDownList><br />
                                        <asp:TextBox ID="txtTo2" MaxLength="100" CssClass="spmargin form-control" runat="server" Text='<%# Bind("To2") %>' Width="275px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="130px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="نوع السيارة" SortExpression="CarType" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlCarType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCarType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الطراز" SortExpression="Model" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="160px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="وصف الشحنة" SortExpression="Name" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtName" runat="server" MaxLength="200" CssClass="form-control" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ControlStyle Width="300px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="العدد" SortExpression="Qty" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty" Text='<%# Bind("Qty") %>' MaxLength="10" CssClass="form-control" runat="server" onchange="makesum()"></asp:TextBox>
                                        <asp:CompareValidator ID="ValQty" runat="server" ControlToValidate="txtQty" ErrorMessage="يجب ان تكون القيمة رقمية"
                                            ForeColor="Red" SetFocusOnError="True" Display="Dynamic" Type="Currency" ValidationGroup="1"
                                            Operator="DataTypeCheck">*</asp:CompareValidator>
                                    </ItemTemplate>
                                    <ControlStyle Width="70px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="السعر" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPrice" Text='<%# Bind("Price") %>' MaxLength="15" runat="server"
                                            onchange="makesum()" CssClass="form-control"></asp:TextBox>
                                        <asp:CompareValidator ID="ValAmount3" runat="server" ControlToValidate="txtPrice"
                                            ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                            Display="Dynamic" Type="Currency" ValidationGroup="1" Operator="DataTypeCheck">*</asp:CompareValidator>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotal0" runat="server" Text="الأجمالي"></asp:Label>
                                    </FooterTemplate>
                                    <ControlStyle Width="70px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="القيمة" SortExpression="Total" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotal" Text='<%# Bind("Total") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotal2" runat="server" Text="<%# Total20 %>"></asp:Label>
                                    </FooterTemplate>
                                    <ControlStyle Width="90px"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                            <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>
                            <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>
                            <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>
                            <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>






            <div class="table-responsive table-hover">
                <table class="table">
                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="LblTax" runat="server" Text="الضريبة 5%"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTax" ReadOnly="true" CssClass="form-control" MaxLength="15" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 150px;"></td>
                        <td style="width: 300px;" align="left">
                            <asp:CheckBox ID="ChkPrintTot" runat="server" CssClass="form-control" Text="طباعة الاجمالي" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="Label2" runat="server" Text="الاجمالي شامل الضريبة"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:TextBox ID="txtTotal" ReadOnly="true" CssClass="form-control" MaxLength="15" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 150px;"></td>
                        <td style="width: 300px;" align="left"></td>
                    </tr>

                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="Label31" runat="server" Text="المستخدم"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                CssClass="MouseStop form-control" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 150px;">
                            <asp:Label ID="Label32" runat="server" Text="بتاريخ"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:TextBox ID="txtUserDate" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                CssClass="MouseStop form-control" Enabled="false"> </asp:TextBox>
                            <asp:Label ID="Label35" runat="server" Text="* حقول الزامية"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px;">
                            <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>
                        </td>
                        <td style="width: 300px;">
                            <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 150px;"></td>
                        <td style="width: 300px;"></td>
                    </tr>
                    <tr align="center">
                        <td colspan="4">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>



            <div class="table table-responsive table-hover text-center">
                <asp:GridView ID="grdList" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="VouNo" AllowPaging="True"
                    PageSize="30" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdList_PageIndexChanging"
                    OnSelectedIndexChanging="grdList_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات عرض السعر"
                                    ImageUrl="~/images/arrow_undo.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="رقم العرض" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVouNo" Text='<%# Bind("VouNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="التاريخ" SortExpression="GDate" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblGDate" Text='<%# Bind("GDate") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الاسم" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الموضوع" SortExpression="Subject" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblSubject" Text='<%# Bind("Subject") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="200px" />
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
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                </div>
                <div class="form-group col-md-6 col-sm-12 col-xm-12">
                    <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                        ImageUrl="~/images/data add.png" ToolTip="أضافة سند جديد" ValidationGroup="1"
                        OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السند؟")' OnClick="BtnNew_Click" />
                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                        ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات السند" Width="64px"
                        ValidationGroup="1" OnClick="BtnEdit_Click" />
                    <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                        ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                    <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                        ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات السند" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات السند؟")'
                        OnClick="BtnDelete_Click" />
                    <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                        ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات السند" OnClick="BtnSearch_Click" />
                    <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                        ImageUrl="~/images/print.png" ValidationGroup="1" ToolTip="طباعة السند" OnClick="BtnPrint_Click" />
                </div>

                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:CheckBox ID="ChkGMApprove" CssClass="form-control" Text="تعميد الرئيس التنفيذي" runat="server" />
                </div>
            </div>
            <!--editing by chanda verma-->
            <div class="form-row">
                <div class="form-group col-md-12 col-sm-12 col-xm-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">المرفقات
                                     <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                            </h4>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body" style="display: none;">
                            <asp:Panel ID="Panel2" runat="server">
                                <asp:Panel ID="Panel1" runat="server">
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
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />

                                </asp:Panel>
                                <div class="form-row">
                                    <div class="col-sm-6">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                            ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                            ValidationGroup="1" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <!--editing by chanda verma-->
                        </div>
                    </div>
                </div>
            </div>


        </div>
        <br />


    </fieldset>
    <br />


</asp:Content>
