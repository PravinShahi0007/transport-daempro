<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebGas.aspx.cs" Inherits="ACC.WebGas" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="ColorRounded4Corners col-md-12 col-sm-12 col-xs-12">
          
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ اتفاقية فاتورة الغاز ]</b></legend>
              <div class="box box-info" align="right">
            <div class="body">
                <div class="row">

                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="LblCode" runat="server" Text="رقم الفاتورة*"></asp:Label>
                          
                                <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                                </div></div></div>
                   

                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الفاتورة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                           
                                <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:Button ID="BtnFind" runat="server" ValidationGroup="55"
                                    ToolTip="البحث عن بيانات فاتورة المياه" OnClick="BtnFind_Click"  Text="بحث"/>
                          </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="التاريخ*"></asp:Label>
                         
                                <asp:TextBox ID="txtHDate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                        </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="الموافق*"></asp:Label>
                        
                                <asp:TextBox ID="txtGDate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
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
                           </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label22" runat="server" Text="حساب العميل*"></asp:Label>
                         
                                <asp:DropDownList ID="ddlusers" CssClass="form-control" runat="server" 
                                     AutoPostBack="True" 
                                    onselectedindexchanged="ddlusers_SelectedIndexChanged" Enabled="False">
                                </asp:DropDownList>
                        </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label10" runat="server" Text="اسم العميل*"></asp:Label>
                          
                                <asp:TextBox ID="txtname" CssClass="form-control" runat="server" ></asp:TextBox>
                           </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label11" runat="server" Text="رقم الهوية*"></asp:Label>
                         
                                <asp:TextBox ID="txtid" CssClass="form-control" runat="server" ></asp:TextBox>
                          </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label12" runat="server" Text="مصدرها"></asp:Label>
                         
                                <asp:TextBox ID="txtplace" CssClass="form-control" runat="server" ></asp:TextBox>
                           </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="lbl100" runat="server" Text="تاريخها"></asp:Label>
                          
                                <asp:TextBox ID="txtidDate" CssClass="form-control" runat="server" ></asp:TextBox>
                         </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label13" runat="server" Text="العنوان"></asp:Label>
                        
                                <asp:TextBox ID="txtaddr" CssClass="form-control" runat="server" ></asp:TextBox>
                         </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label14" runat="server" Text="*رقم الجوال"></asp:Label>
                         
                                <asp:TextBox ID="txtmob" CssClass="form-control" runat="server" ></asp:TextBox>
                           </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="نوع الخدمة*"></asp:Label>
                        
                                <asp:DropDownList ID="ddltype11" CssClass="form-control" runat="server" 
                                    AutoPostBack="True" Enabled="true" 
                                    onselectedindexchanged="ddltype11_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="إختر الخدمة"></asp:ListItem>
                                <asp:ListItem Value="1" Text="اسطوانة جديدة"></asp:ListItem>
                                <asp:ListItem Value="2" Text="استبدال"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddltype11"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار النوع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                         </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label7" runat="server" Text="نوع الأسطوانة*"></asp:Label>
                          
                                <asp:DropDownList ID="ddldetail" CssClass="form-control" runat="server" 
                                    onselectedindexchanged="ddldetail_SelectedIndexChanged" 
                                    AutoPostBack="True" Enabled="true">
                                <asp:ListItem Value="-1" Text="إختر النوع"></asp:ListItem>
                                <asp:ListItem Value="1" Text="11 كغم فايبر - منظم عادي"></asp:ListItem>
                                <asp:ListItem Value="2" Text="11 كغم معدن - منظم عادي"></asp:ListItem>
                                <asp:ListItem Value="3" Text="22 كغم معدن - منظم عادي"></asp:ListItem>
                                <asp:ListItem Value="4" Text="11 كغم معدن - منظم كبس"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddldetail"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار النوع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                         </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label6" runat="server" Text="العدد*"></asp:Label>
                          
                                <asp:DropDownList ID="ddlcount" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlcount_SelectedIndexChanged" Enabled="true">
                                      <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                      <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                      <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                      <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                      <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                      <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                      <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlcount"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الحجم" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                               
                          </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label15" runat="server" Text="وصف النوع"></asp:Label>
                           
                                <asp:TextBox ID="txtdesc" CssClass="form-control" runat="server" ></asp:TextBox>
                         </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label16" runat="server" Text="سعر البيع"></asp:Label>
                          
                                <asp:TextBox ID="txtprice" CssClass="form-control" runat="server"
                                    ontextchanged="txtprice_TextChanged" AutoPostBack="True" ReadOnly="True" BackColor="#E8E8E8"></asp:TextBox>
                          </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label17" runat="server" Text="سعر الخدمة*"></asp:Label>
                       

                                    <asp:TextBox ID="txtprice2" CssClass="form-control" runat="server" 
                                        ontextchanged="txtprice2_TextChanged" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtprice2"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج السعر" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtprice2"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                               
                           </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label19" runat="server" Text="كوبون خصم"></asp:Label>
                          
                                <asp:TextBox ID="txtpromo" CssClass="form-control" runat="server"></asp:TextBox>
                                   <asp:ImageButton ID="BtnDiscountTerm" runat="server" ValidationGroup="550" ImageUrl="~/images/zoom_16.png"
                                                ToolTip="البحث عن بيانات كود الخصم" 
                                     onclick="BtnDiscountTerm_Click" />
                            </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label20" runat="server" Text="مبلغ الخصم"></asp:Label>
                          
                                <asp:TextBox ID="txtdisc" CssClass="form-control" runat="server"
                                    ontextchanged="txtdisc_TextChanged" AutoPostBack="True"></asp:TextBox>
</div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label18" runat="server" Text="اجمالي التكلفة"></asp:Label>
                          
                                <asp:TextBox ID="txttotal" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                          </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label21" runat="server" Text="ملاحظات"></asp:Label>
                           
                                <asp:TextBox ID="txtremark" CssClass="form-control" runat="server" ></asp:TextBox>
                           </div></div></div>
           
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ تعيين السائق ]</b></legend>
                <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label9" runat="server" Text="نوع الناقلة*"></asp:Label>
                          
                                <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server" 
                                    onselectedindexchanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlType"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار نوع الناقلة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                               
                           </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="السائق*"></asp:Label>
                          
                                <asp:DropDownList ID="ddlDriver" CssClass="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDriver_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValDriver" runat="server" ControlToValidate="ddlDriver"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtRentDriver" CssClass="form-control"  MaxLength="100" runat="server" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValRentDriver" runat="server" ControlToValidate="txtRentDriver"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أدخال السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                           </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                           
                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                        </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label8" runat="server" Text="تاريخ الادخال"></asp:Label>
                          
                                <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>
                         
                                <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                          </div></div></div>
                       <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                            
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png" 
                                    ToolTip="أضافة فاتورة غاز جديدة" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ الفاتورة؟")' 
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل فاتورة الغاز" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح"/>
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء فاتوة الغاز" OnClientClick='return confirm("هل أنت متاكد من الغاء بيان فاتورة الغاز؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1" ToolTip="طباعة السند" OnClick="BtnPrint_Click" Text="طباعة" />
                           </div></div></div></div></div></div>
              
        </div>
      

</asp:Content>
