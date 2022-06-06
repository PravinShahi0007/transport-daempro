<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebEmergInv.aspx.cs" Inherits="ACC.WebEmergInv" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ اتفاقية خدمات الطريق ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم الفاتورة*"></asp:Label>
                            </td>
                            <td style="width: 300px; margin-right: 40px;">
                                <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop"></asp:TextBox>
                                <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الفاتورة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                &nbsp;</td>
                            <td style="width: 275px;" align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;

                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:Button ID="BtnFind" runat="server" ValidationGroup="55"
                                    ToolTip="البحث عن بيانات فاتورة الخدمات" OnClick="BtnFind_Click"  Text="بحث"/>
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
                                <asp:TextBox ID="txtGDate" Width="150px" runat="server" MaxLength="10" 
                                    AutoPostBack="True" ontextchanged="txtGDate_TextChanged"></asp:TextBox>
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
                         <!-- start: edited by hanan -->
                         <tr align="right">
                             <td style="width: 125px;">
                                <asp:Label ID="Label22" runat="server" Text="حساب العميل*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlusers" Width="150px" runat="server" 
                                     AutoPostBack="True" 
                                    onselectedindexchanged="ddlusers_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                      </tr>
                       <!-- end : edited by hanan -->
                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label10" runat="server" Text="اسم العميل*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtname" Width="150px" runat="server" ></asp:TextBox>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label11" runat="server" Text="رقم الهوية*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtid" Width="150px" runat="server" ></asp:TextBox>
                            </td>
                  
                        </tr>

                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label12" runat="server" Text="مصدرها"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtplace" Width="150px" runat="server" ></asp:TextBox>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="lbl100" runat="server" Text="تاريخها"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtidDate" Width="150px" runat="server" ></asp:TextBox>
                            </td>
                          </tr>

                            <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label13" runat="server" Text="العنوان"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtaddr" Width="150px" runat="server" ></asp:TextBox>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label14" runat="server" Text="*رقم الجوال"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtmob" Width="150px" runat="server" ></asp:TextBox>
                            </td>
                  
                        </tr>

                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label7" runat="server" Text="نوع الخدمة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddltype11" Width="150px" runat="server" 
                                    onselectedindexchanged="ddltype11_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                <asp:ListItem Value="-1" Text="إختر النوع"></asp:ListItem>
                                <asp:ListItem Value="1" Text="بنزين"></asp:ListItem>
                                <asp:ListItem Value="2" Text="بطارية"></asp:ListItem>
                                <asp:ListItem Value="3" Text="بنشر"></asp:ListItem>
                                <asp:ListItem Value="4" Text="سطحة"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddltype11"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار النوع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label6" runat="server" Text="تفاصيل الخدمة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddldetail" Width="150px" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddldetail_SelectedIndexChanged">
                                </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddldetail"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار تفاصيل الخدمة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                               
                            </td>
                  
                        </tr>
                 <!-- start : edited by hanan11 -->
                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label4" runat="server" Text="نوع الصنف*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlitem" Width="150px" runat="server" AutoPostBack="True"
                                    onselectedindexchanged="ddlitem_SelectedIndexChanged" > 
                                </asp:DropDownList>
                            </td>

                        </tr>
                 <!-- end : edited by hanan11 -->

                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label15" runat="server" Text="وصف النوع"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtdesc" Width="265px" runat="server" ></asp:TextBox>
                            </td>

                          </tr>

                            <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label16" runat="server" Text="سعر الخدمة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtprice" Width="150px" runat="server"
                                    ontextchanged="txtprice_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label17" runat="server" Text="سعر السلعة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtprod" Width="150px" runat="server"
                                    ontextchanged="txtprod_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </td>
                  
                        </tr>

                          <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label19" runat="server" Text="كوبون خصم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtpromo" Width="150px" runat="server"></asp:TextBox>
                                   <asp:ImageButton ID="BtnDiscountTerm" runat="server" ValidationGroup="550" ImageUrl="~/images/zoom_16.png"
                                                ToolTip="البحث عن بيانات كود الخصم" 
                                     onclick="BtnDiscountTerm_Click" />
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label20" runat="server" Text="مبلغ الخصم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtdisc" Width="150px" runat="server"
                                    ontextchanged="txtdisc_TextChanged" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                            </td>
                  
                        </tr>

                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label18" runat="server" Text="اجمالي التكلفة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txttotal" Width="150px" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>

                          </tr>

                          <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label21" runat="server" Text="ملاحظات"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtremark" Width="150px" runat="server" ></asp:TextBox>
                            </td>

                           </tr>
                    </table>
                </center>
                <br />
              
        <br />                
            </fieldset>

              <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ تعيين السائق ]</b></legend>
                <center>
                    <br />
                 <table dir="rtl" width="99%" cellpadding="2px">
                      <tr align="right">
                             <td style="width: 125px;">
                                <asp:Label ID="Label9" runat="server" Text="نوع الناقلة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlType" Width="280" runat="server" 
                                    onselectedindexchanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlType"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار نوع الناقلة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                               
                            </td>
                      </tr>

                       <!-- edited by hanan2 -->
                        <tr align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" Text="السائق*"></asp:Label>
                            </td>
                            <td style="width: 275px;" colspan="2">
                                <asp:DropDownList ID="ddlDriver" Width="280px" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDriver_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValDriver" runat="server" ControlToValidate="ddlDriver"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtRentDriver" Width="280px"  MaxLength="100" runat="server" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValRentDriver" runat="server" ControlToValidate="txtRentDriver"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أدخال السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
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
                                    ToolTip="أضافة بيان ترحيل جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيان الترحيل؟")' 
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيان ترحيل" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح"/>
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيان الترحيل" OnClientClick='return confirm("هل أنت متاكد من الغاء بيان الترحيل؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1" ToolTip="طباعة السند" OnClick="BtnPrint_Click" Text="طباعة" />
                            </td>
                        </tr>

                        </table>
                        </center>
                <br />               
            </fieldset>
         
        </div>
        <br />


</asp:Content>
