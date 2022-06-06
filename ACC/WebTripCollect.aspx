<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebTripCollect.aspx.cs" Inherits="ACC.WebTripCollect" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ بيان التجميع ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم البيان*"></asp:Label>
                            </td>
                            <td style="width: 300px; margin-right: 40px;">
                                <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop"></asp:TextBox>
                                <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم بيان التجميع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                &nbsp;</td>
                            <td style="width: 275px;" align="left" colspan="2">
                               <!-- edited by hanan2 -->
                                <asp:CheckBox ID="ChkRent" runat="server" Text="سائق متعاون" Visible="false"
                                    AutoPostBack="True" oncheckedchanged="ChkRent_CheckedChanged" />

                                &nbsp;&nbsp;&nbsp;

                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:Button ID="BtnFind" runat="server" ValidationGroup="55"
                                    ToolTip="البحث عن بيانات بيان التجميع" OnClick="BtnFind_Click"  Text="بحث"/>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtHDate" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label3" runat="server" Text="الموافق*"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtGDate" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtGDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>م&nbsp;
                                <asp:Label ID="LblFTime" runat="server" Text=""></asp:Label>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtGDate"
                                    ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$"
                                    runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label7" runat="server" Text="مدينة أو منطقة التجميع*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlFrom" Width="280" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddlFrom"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الجهة من" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label6" runat="server" Visible="false" Text="نوع الناقلة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlType" Width="280" runat="server" Visible="false"
                                    onselectedindexchanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                               
                            </td>
                  
                        </tr>
                      
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label1" runat="server" Text="السائق*"></asp:Label>
                                
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlDriver" Width="280px" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDriver_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValDriver" runat="server" ControlToValidate="ddlDriver"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtRentDriver" Width="280px"  MaxLength="100" Visible="false" runat="server" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValRentDriver" runat="server" ControlToValidate="txtRentDriver" Visible="false" Enabled="false"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أدخال السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label4" runat="server" Visible="false" Text="الناقلة"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:DropDownList ID="ddlCar" Width="280" Visible="false" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCar_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValCar" runat="server" ControlToValidate="ddlCar" Visible="false" Enabled="false"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الناقلة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtRentMobileNo" MaxLength="15" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>

                          <!-- edited by hanan5 ( adding row) -->
                        <tr align="right">
                          <td style="width: 125px;">   
                            </td>
                            <td style="width: 100px;">
                              <asp:CheckBox ID="ChkAll" Text="عرض المتاح" runat="server" AutoPostBack="True" Visible="false"
                                    oncheckedchanged="ChkAll_CheckedChanged" />
                             </td>
                         </tr>

                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label9" runat="server" Text="نوع الحمولة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:CheckBoxList ID="ChkInvType" runat="server" Width="190px" 
                                    RepeatColumns="2" AutoPostBack="True" 
                                    onselectedindexchanged="ChkInvType_SelectedIndexChanged">
                                    <asp:ListItem Value="0">سيارات</asp:ListItem>
                                    <asp:ListItem Value="1">طرود</asp:ListItem>
                                </asp:CheckBoxList>
                            </td> 
                        </tr>
                    
                       
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="280px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label8" runat="server" Text="تاريخ الادخال"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 125px;">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="280px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                            </td>
                            <td colspan="2" style="width: 275px;">
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="5">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="5">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" 
                                    ToolTip="أضافة بيان تجميع جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيان التجميع؟")' 
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيان تجميع" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح"/>
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيان التجميع" OnClientClick='return confirm("هل أنت متاكد من الغاء بيان التجميع؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1" ToolTip="طباعة السند" OnClick="BtnPrint_Click" Text="طباعة" />
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
              
        <br />                
            </fieldset>
         
        </div>
        <br />

  <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%; direction:rtl;
            border: solid 2px #800000">
            <legend align="right" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ فواتير الحمولة ]</b></legend>
        <div id="divGrd" runat="server" style="width: 100%; overflow: none; overflow-x: auto;
                border: 1px solid #800000;">
                  <!-- edited by hanan3 ( copy & paste the gridview ) -->
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                    AutoGenerateColumns="False" DataKeyNames="VouNo" Width="99.9%" EmptyDataText="لا توجد بيانات">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkStatus" runat="server" Checked='<%# Bind("Status") %>' ToolTip="أختيار او عدم اختيار الفاتورة" />
                            </ItemTemplate>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="رقم الفاتورة" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Flag") + int.Parse(Eval("InvoiceVouLoc").ToString()).ToString() + "/" + Eval("VouNo") %>'
                                NavigateUrl='<%# UrlHelper(Eval("VouNo"),Eval("InvoiceVouLoc"),Eval("Flag"))%>' Target="_blank"
                                runat="server"></asp:HyperLink>                                
                            </ItemTemplate>
                            <ControlStyle Width="70px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="التاريخ" SortExpression="FTime" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" Text='<%# Bind("GDate") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="70px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="مرسل الشحنة" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="جوال المرسل" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="رقم اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="PlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="جهة الترحيل" SortExpression="DestinationName1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDestination" Text='<%# Eval("DestinationName1") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="العنوان" SortExpression="Address" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                                        <asp:HyperLink ID="lblAddress" Text='<%# Bind("Address") %>'
                                NavigateUrl='<%# "WebMap.aspx?lat=" +Eval("SLat").ToString() + "&lng="+ Eval("SLong").ToString()%>' Target="_blank"
                                runat="server"></asp:HyperLink>

                            </ItemTemplate>
                            <ControlStyle Width="150px" />
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
           </fieldset>
</asp:Content>
