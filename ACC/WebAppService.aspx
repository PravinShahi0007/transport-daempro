<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebAppService.aspx.cs" Inherits="ACC.WebAppService" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD
<div class="col-md-12  col-sm-12 col-xs-12">
      <div class="card card-body">
                <h3 align="center" ><b>
                    [بطاقة خدمة / التطبيق ]</b></h3>
=======
 <div class="ColorRounded4Corners col-md-12 col-sm-12 col-xs-12">
           
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [بطاقة خدمة / التطبيق ]</b></legend>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
               <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCode" runat="server" Text="رقم الخدمة*"></asp:Label>
                        
                                <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop form-control" ReadOnly="True" ></asp:TextBox>
                             
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الخدمة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                          </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
<<<<<<< HEAD
                                    <br />
=======

>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات الخدمة" OnClick="BtnFind_Click"  Text="بحث"/>
                       </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label10" runat="server" Text="اسم الخدمة*"></asp:Label>
                            
                                <asp:TextBox ID="txtname" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                           </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="الاسم بالإنجليزية*"></asp:Label>
                         
                                <asp:TextBox ID="txtname2" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                         </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                 
                                <asp:Label ID="Label1" runat="server" Text="السعر*"></asp:Label>
                          

                                    <asp:TextBox ID="txtprice" CssClass="form-control" runat="server" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtprice"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج السعر" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprice"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                               
                          </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label21" runat="server" Text="ملاحظات"></asp:Label>
                        
                                <asp:TextBox ID="txtremark" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
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
                                    ImageUrl="~/images/data add.png" ToolTip="أضافة صنف" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الخدمة؟")' 
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات الخدمة" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح"/>
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
<<<<<<< HEAD
                                    ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات الخدمة" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات الخدمة؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>
                           </div></div></div>
            
                <h3 class="text-center">
                    [ الأصناف ]</h3>
              
                          <div class="table table-responsive table-hove text-center">
=======
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات الخدمة" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات الخدمة؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>
                           </div></div></div>
            
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ الأصناف ]</b></legend>
              
                          <div class="table-responsive">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
               
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="Black" GridLines="None"
                    AutoGenerateColumns="False" DataKeyNames="SCode" Width="99.9%" EmptyDataText="لا توجد بيانات" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                         <asp:TemplateField HeaderText="كود الصنف" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label ID="lblcode" Text='<%# Bind("SCode") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </asp:TemplateField>
                 
                          <asp:TemplateField HeaderText="اسم الصنف" SortExpression="SName1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<%# Bind("SName1") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="اسم الصنف" SortExpression="SName1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName2" Text='<%# Bind("SName2") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="السعر" SortExpression="Sprice" ItemStyle-HorizontalAlign="Center" Visible="True">
                            <ItemTemplate>
                                <asp:Label ID="lblprice" Text='<%# Bind("Sprice")%>' 
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

                      
       
            <!-- edited by hanan3 : to here -->

           
         </div></div></div>
        </div>
<<<<<<< HEAD
   </div>
=======
   
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7

</asp:Content>

