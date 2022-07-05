<%@ Page Title="بيانات العملاء" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebClients.aspx.cs" Inherits="ACC.WebClients" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
        <div class="card">
            <fieldset class="card-body">
                <div class="card-header">
                    <h4>
                    [ بيانات العملاء ]</h4></div>
                <center>
                    <br />
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="LblCode" runat="server" Text="رقم العميل"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" MaxLength="5"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtCode"
                                    ErrorMessage="يجب إدخال رقم العميل" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-1 col-sm-12 col-xs-12">
                            <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/search2.png"
                                    ToolTip="البحث عن بيانات عميل" OnClick="BtnSearch_Click" />
                        </div>
                        <div class="form-group col-md-5 col-sm-12 col-xs-12"></div>
                        
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label2" runat="server" Text="الاسم عربي"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtName1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtName2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                       
                        
                       
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:Label ID="Label4" runat="server" Text="الرقم الضريبي"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtIqamaNo" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label1" runat="server" Visible="false" Text="نوعها"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:RadioButtonList ID="rdoIDType" Width="200px" runat="server" Visible="false" RepeatColumns="2">
                                    <asp:ListItem Selected="True" Value="0">الهوية</asp:ListItem>
                                    <asp:ListItem Value="1">بطاقة</asp:ListItem>
                                </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                              <asp:Label ID="Label5" runat="server" Visible="false" Text="مصدرها"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtIqamaFrom" CssClass="form-control" runat="server" Visible="false" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label8" runat="server" Visible="false" Text="تاريخ الانتهاء"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtIqamaDate" CssClass="form-control" runat="server" Visible="false" MaxLength="10"></asp:TextBox>
                        </div>
                       
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label6" runat="server" Text="العنوان"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" MaxLength="200"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label11" runat="server" Text="رقم الاتصال"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:Label ID="Label7" runat="server" Text="بريد واصل"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                           <asp:TextBox ID="txtPostal" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label9" runat="server" Text="البريد الالكتروني"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:Label ID="Label13" runat="server" Text="رقم المكتب"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                              <asp:TextBox ID="txtOfficeNo" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:Label ID="Label16" runat="server" Text="نوع الدفع"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:RadioButtonList ID="rdoPayment" Width="250px" runat="server" 
                                    RepeatColumns="2" AutoPostBack="True" 
                                    onselectedindexchanged="rdoPayment_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">أجل فرع</asp:ListItem>
                                    <asp:ListItem Value="1">Credit</asp:ListItem>
                                </asp:RadioButtonList>
                        </div>
                    </div>
                     <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label17" runat="server" Text="العنوان الوطني"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="lblCust" runat="server" Visible="false" Text="حساب العميل"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12"></div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:DropDownList ID="ddlAccount" CssClass="form-control" Visible="false" runat="server">
                                </asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label18" runat="server" Text="رقم المبنى"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtAddr1" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label19" runat="server" Text="اسم الشارع"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAddr2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label20" runat="server" Text="الحي"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAddr3" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label21" runat="server" Text="المدينة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAddr4" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label22" runat="server" Text="البلد"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAddr5" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:Label ID="Label23" runat="server" Text="الرمز البريدي"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtAddr6" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label24" runat="server" Text="الرقم الإضافي"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAddr7" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label25" runat="server" Text="رقم الوحدة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtAddr8" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:Label ID="Label10" runat="server" Text="اسم المسئول"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:Label ID="Label12" runat="server" Text="الوظيفة"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label14" runat="server" Text="رقم الاتصال"></asp:Label>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:Label ID="Label15" runat="server" Text="الايميل"></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtManage1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtJob1" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtMobileNo1" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtEmail1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtManage2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtJob2" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtMobileNo2" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtEmail2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtManage3" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtJob3" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtMobileNo3" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3 col-sm-12 col-xs-12">
                            <asp:TextBox ID="txtEmail3" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="table table-responsive table-hover text-center">
                           <asp:GridView ID="grdDetails" runat="server" CellPadding="3" Width="100%" 
                                    ViewStateMode="Enabled" GridLines="Horizontal" AutoGenerateColumns="False" 
                                    ShowFooter="true" AllowPaging="false"
                                    DataKeyNames="FNo" PageSize="250" OnRowCommand="grdDetails_RowCommand" 
                                    OnRowDeleting="grdDetails_RowDeleting" BackColor="White" BorderColor="#E7E7FF" 
                                    BorderStyle="None" BorderWidth="1px" 
                                    onrowcancelingedit="grdDetails_RowCancelingEdit">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="المدينة" SortExpression="City2" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <div class="form-group">
                                                    <asp:Label ID="lblCity2" Text='<%# Eval("City2") %>' runat="server"></asp:Label>
                                                </div>
                                                
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                                
                                            </FooterTemplate>
                                            <ControlStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="المندوب المرسل" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <div class="form-group">
                                                <asp:Label ID="lblName" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div class="form-group">
                                               <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="form-control"/>
                                                    </div>
                                            </FooterTemplate>
                                            <ControlStyle Width="200px" />
                                            <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="رقم الاتصال" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <div class="form-group">
                                                <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                            </div>
                                           </ItemTemplate>
                                            <FooterTemplate>
                                                <div class="form-group">
                                               <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="20" CssClass="form-control"/>
                                                    </div>
                                            </FooterTemplate>
                                            <ControlStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="المندوب المستلم" SortExpression="RecName" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <div class="form-group">
                                                <asp:Label ID="lblRecName" Text='<%# Eval("RecName") %>' runat="server"></asp:Label>
                                                    </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div class="form-group">
                                               <asp:TextBox ID="txtRecName" runat="server" MaxLength="50" CssClass="form-control"/>
                                                    </div>
                                            </FooterTemplate>
                                            <ControlStyle Width="200px" />
                                            <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="رقم الاتصال" SortExpression="RecMobileNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <div class="form-group">
                                                <asp:Label ID="lblRecMobileNo" Text='<%# Bind("RecMobileNo") %>' runat="server"></asp:Label>
                                                    </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div class="form-group">
                                               <asp:TextBox ID="txtRecMobileNo" runat="server" MaxLength="20" CssClass="form-control"/>
                                                    </div>
                                            </FooterTemplate>
                                            <ControlStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                                    ValidationGroup="1" ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="أضافة بند جديد"
                                                    ImageUrl="~/images/add.png" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" VerticalAlign="Middle"
                                        HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                </asp:GridView>
                    </div>
          <div class="form">
              <div class="form-group">
                   <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
              </div>
              <div class="form-group">
                   <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
              </div>
              <div class="form-group">
                   <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png" ToolTip="أضافة عميل جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات العميل؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات عميل" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات عميل" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات العميل؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات عميل" OnClick="BtnSearch_Click" />
              </div>
              
          </div>                   
                  <div class="form">
                    
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="Code" AllowPaging="True"
                            PageSize="20" Width="100%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات العميل"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم العميل" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-group">
                                        <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                            </div>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم السائق" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-group">
                                        <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                            </div>
                                    </ItemTemplate>
                                    <ControlStyle Width="250px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الجوال" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="form-group">
                                        <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                            </div>
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
                    <br />
                </center>
            </fieldset>
        </div>
        <br />
</asp:Content>
