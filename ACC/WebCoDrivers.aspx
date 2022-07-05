<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCoDrivers.aspx.cs" Inherits="ACC.WebCoDrivers" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


            <fieldset class="card" >
                <div class="card-header"><h4>
                    [حساب سائق متعاون ]</h4>

                </div>
                
                    <br />
                <div class="card-body">
                    <div class="form">
                        <div class="form-group">
                            <div class="form-row">
                                            <!-- edited by chanda -->
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:Label ID="LblCode" runat="server" Text="رقم السائق*"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop form-control" ReadOnly="True"></asp:TextBox>
                             
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                                
                                

                                <div class="col-md-4 col-sm-12 col-xs-12">
                                     <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                
                                </div>
                                <div class="col-md-1 col-sm-12 col-xs-12">
                                    <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/search2.png"
                                    ToolTip="البحث عن بيانات فاتورة الخدمات" OnClick="BtnFind_Click"  Text="بحث"/>
                            
                                </div>
                                 <div class="col-md-1 col-sm-12 col-xs-12"></div>
                                
                            </div>
                            </div>
                            <br />
                            <div class="form-row">
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                     <asp:Label ID="Label10" runat="server" Text="اسم السائق*"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                      <asp:TextBox ID="txtname" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                   <!-- edited by chanda -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtname"
                                    Display="Dynamic" ErrorMessage="يجب ادخال اسم السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                     <asp:Label ID="Label2" runat="server" Text="الاسم بالإنجليزية*"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtname2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <div class="form-row">
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label11" runat="server" Text="رقم الهوية*"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                     <asp:TextBox ID="txtid" CssClass="form-control" runat="server" ></asp:TextBox>
                              
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtid"
                                    Display="Dynamic" ErrorMessage="يجب ادخال رقم الهوية" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                    <asp:Label ID="lbl100" runat="server" Text="تاريخها"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                      <asp:TextBox ID="txtidDate" CssClass="form-control" runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-sm-12 col-xs-12"></div>

                            </div>
                            <br />
                            <div class="form-row">
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label13" runat="server" Text="العنوان"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtaddr" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                     <asp:Label ID="Label14" runat="server" Text="*رقم الجوال"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtmob" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                 <!-- edited by hanan2 -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmob"
                                    Display="Dynamic" ErrorMessage="يجب ادخال رقم الجوال" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <div class="form-row">
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label22" runat="server" Text="الجنسية*"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:DropDownList ID="ddlnat" CssClass="form-control" runat="server" 
                                     AutoPostBack="True" onselectedindexchanged="ddlnat_SelectedIndexChanged" >
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlnat"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الجنسية" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                               
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12"></div>
                                <div class="col-md-3 col-sm-12 col-xs-12"></div>
                                <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <div class="form-row">
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label7" runat="server" Text="نوع/حجم المركبة*"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                      <asp:DropDownList ID="ddltype11" CssClass="form-control" runat="server" 
                                    onselectedindexchanged="ddltype11_SelectedIndexChanged" 
                                    AutoPostBack="True"> 
                                </asp:DropDownList> <!-- edited by chanda verma -->
                                <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddltype11"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار النوع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label6" runat="server" Text="موديل السيارة*"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                      <asp:TextBox ID="txtmodel" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>   <!-- edited by hanan2 -->
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmodel"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادخال الموديل" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>   <!-- edited by hanan2 -->
                               
                                </div>
                                <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <div class="form-row">
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:Label ID="Label16" runat="server" Text="الحساب المرتبط"></asp:Label>
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <asp:DropDownList ID="ddlColor" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-sm-12 col-xs-12">
                                   <asp:Label ID="Label17" runat="server" Text="رقم اللوحة"></asp:Label> 
                                </div>
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                     <asp:TextBox ID="txtplate" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtplate"
                                    Display="Dynamic" ErrorMessage="يجب ادخال رقم اللوحة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <!--editing by chanda-->
                            <div class="form-row">
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                     <asp:Label ID="Label19" runat="server" Text="البنك"></asp:Label>
                                 </div>
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                      <asp:DropDownList ID="ddlbank" CssClass="form-control" runat="server" >
                                </asp:DropDownList>
                                 </div>
                                 <div class="col-md-2 col-sm-12 col-xs-12">
                                     <asp:Label ID="Label20" runat="server" Text="رقم الآيبان"></asp:Label>
                                 </div>
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                     <asp:TextBox ID="txtiban" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            
                                 </div>
                                 <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <div class="form-row">
                                 <!--editing by chanda-->
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                     <asp:Label ID="Label18" runat="server" Text="نوع السائق"></asp:Label>
                                 </div>
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                       <asp:DropDownList ID="ddltrans" CssClass="form-control" runat="server" >
                                <asp:ListItem Value="1" Text="سيارة صغيرة"></asp:ListItem>
                                <asp:ListItem Value="2" Text="سطحة"></asp:ListItem>
                                <asp:ListItem Value="3" Text="شاحنة رأس تريلا"></asp:ListItem>
                                </asp:DropDownList>
                                 </div>
                                 <div class="col-md-2 col-sm-12 col-xs-12">
                                     <asp:Label ID="Label1" runat="server" Text="نسبة عمولة السائق"></asp:Label>
                                 </div>
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                      <asp:TextBox ID="txtpercent" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox><asp:Label
                                    ID="Label3" runat="server" Text="%" Font-Bold="True"></asp:Label>
                                    <asp:Label ID="lblacc" Visible="false" runat="server" Text=""></asp:Label>
                                 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpercent"
                                    Display="Dynamic" ErrorMessage="يجب أختيار نسبة الدخل" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtpercent"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

                                 </div>
                                 <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <div class="form-row">
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                     <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>

                                 </div>
                                 <div class="col-md-3 col-sm-12 col-xs-12">
                                     <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                                 </div>
                                 <div class="col-md-2 col-sm-12 col-xs-12"></div>
                                 <div class="col-md-3 col-sm-12 col-xs-12"></div>
                                 <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <div class="form-row">
                                 <div class="col-md-11 col-sm-12 col-xs-12">
                                     <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                                 </div>
                                
                                 <div class="col-md-1 col-sm-12 col-xs-12"></div>
                            </div>
                            <br />
                            <div class="form-row">
                                 <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                     <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png" ToolTip="أضافة سائق" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السائق؟")' 
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات السائق" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح"/>
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات السائق" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات السائق؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>

                                 </div>
                                 
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
                   <%-- <table dir="rtl" width="99%" cellpadding="2px">
                       
                        

                    </table>--%>
                
                <br />
              
        <br />                
            </fieldset>

               <!-- edited by hanan11 : from here -->
              <fieldset class="card">
                <div class="card-header"><h4 class="card-title text-center">
                    [ السائقون المتعاونون ]</h4></div>
                
                    <br />
                     <div id="divGrd" class="form-body">
               
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="Black" GridLines="None"
                    AutoGenerateColumns="False" DataKeyNames="ID" Width="100%" EmptyDataText="لا توجد بيانات" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                         <asp:TemplateField HeaderText="كود السائق" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label ID="lblcode" Text='<%# Bind("ID") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </asp:TemplateField>
                 
                          <asp:TemplateField HeaderText="الاسم بالعربي" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="الاسم بالإنجليزي" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="الجنسية" SortExpression="Nat" ItemStyle-HorizontalAlign="Center" Visible="True">
                            <ItemTemplate>
                                <asp:Label ID="lblnat" Text='<%# Bind("MobileNo")%>' 
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

               
                <br />               
            </fieldset>
            <!-- edited by chanda verma : to here -->

           
         
        
        <br />

</asp:Content>
