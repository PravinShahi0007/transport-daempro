<%@ Page Title="" Language="C#" MasterPageFile="~/SupportSite.Master" AutoEventWireup="true"
    CodeBehind="WebTSupport.aspx.cs" Inherits="ACC.WebTSupport" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div class="card">
        <fieldset>
            <div class="card-header">
                <h4 class="card-title text-center">[ خدمة العملاء ]
                </h4>
            </div>
            <br />
            <div class="card-body">
                <div class="form-row">
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="LblCode" runat="server" Text="التاريخ"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xs-12">
                        <asp:TextBox ID="txtFDate" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="Label19" runat="server" Text="الوقت"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xs-12">
                        <asp:TextBox ID="txtFTime" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-12 col-xs-12"></div>
                </div>

                <div class="form-row" id="tr2">
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="Label1" runat="server" Text="اسم العميل"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xs-12">
                        <asp:TextBox ID="txtCustomer" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="Label20" runat="server" Text="رقم الفاتورة"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xs-12">
                        <asp:TextBox ID="txtInvNo" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-12 col-xs-12"></div>
                </div>

                <div class="form-row" id="tr3">
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="Label2" runat="server" Text="رقم الجوال"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xs-12">
                        <asp:TextBox ID="txtMobileNo" MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="Label21" runat="server" Text="رقم اللوحة"></asp:Label>
                    </div>
                    <div class="form-group col-md-3 col-sm-12 col-xs-12">
                        <asp:TextBox ID="txtPlateNo" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-12 col-xs-12"></div>
                </div>

                <div class="form-row" id="tr4">
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="Label3" runat="server" Text="نوع الخدمة"></asp:Label>
                    </div>
                    <div class="form-group col-md-10 col-sm-12 col-xs-12">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Text="استفسار عن سيارة"></asp:ListItem>
                            <asp:ListItem Value="1" Text="استفسار عن زمن الوصول"></asp:ListItem>
                            <asp:ListItem Value="2" Text="شكوى"></asp:ListItem>
                            <asp:ListItem Value="3" Text="موقع الفرع"></asp:ListItem>
                            <asp:ListItem Value="4" Text="اخرى"></asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                    
                </div>

                <div class="form-row" id="tr5">
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="Label4" runat="server" Text="الرد"></asp:Label>
                    </div>
                    <div class="form-group col-md-8 col-sm-12 col-xs-12">
                        <asp:TextBox ID="txtReply" TextMode="MultiLine" MaxLength="500" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-12 col-xs-12"></div>
                </div>

                <div class="form-row" id="tr10">
                    <div class="form-group col-md-2 col-sm-12 col-xs-12">
                        <asp:Label ID="Label9" runat="server" Text="ملاحظات"></asp:Label>
                    </div>
                    <div class="form-group col-md-8 col-sm-12 col-xs-12">
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" MaxLength="500" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-2 col-sm-12 col-xs-12"></div>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtRemark2" Visible="false" TextMode="MultiLine" MaxLength="500" CssClass="form-control"
                            runat="server"></asp:TextBox>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-4 col-sm-12 col-xs-12"></div>
                    <div class="form-group col-md-4 col-sm-12 col-xs-12">
                        <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png" ToolTip="أضافة بيانات موظف جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الموظف؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات موظف" Width="64px"
                                    ValidationGroup="1" Visible="false" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات موظف" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات الموظف؟")'
                                    Visible="false" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات معاملة" Visible="false" />
                    </div>
                    <div class="form-group col-md-4 col-sm-12 col-xs-12"></div>
                </div>
                <div class="form-group">
                    <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                </div>
            </div>
         
            <center>
            <hr />
                <div class="text-center">
                    <div class="row">
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:DropDownList ID="ddlUser" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12"></div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                        </div>
                        
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:CheckBox ID="ChkPeriod" CssClass="form-control" runat="server" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtMyFDate" Placeholder="تاريخ بداية الفترة" MaxLength="10" CssClass="form-control"
                                    Visible="false" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtMyFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtMyFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtMyEDate" Placeholder="تاريخ نهاية الفترة" MaxLength="10" CssClass="form-control"
                                    Visible="false" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtMyEDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtMyEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:Label ID="Label6" runat="server" Text="عرض السجلات"></asp:Label>
                        </div>
                        <div class="form-group col-md-2 col-sm-12 col-xs-12">
                            <asp:DropDownList ID="ddlRecordsPerPage" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="-1">الكل</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                  
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FDate,FTime" AllowPaging="True"
                        PageSize="50" Width="100%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="التاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblFDate" Text='<%# Bind("FDate") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوقت" SortExpression="FTime" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblFTime" Text='<%# Bind("FTime") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="العميل" SortExpression="Customer" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblCustomer" Text='<%# Bind("Customer") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الجوال" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="أختيار الطلب و عرض تفاصيله"
                                        ImageUrl="~/images/arrow_undo.png" />
                                </ItemTemplate>
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
</asp:Content>
