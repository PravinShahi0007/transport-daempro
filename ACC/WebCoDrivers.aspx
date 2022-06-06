<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCoDrivers.aspx.cs" Inherits="ACC.WebCoDrivers" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [حساب سائق متعاون ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم السائق*"></asp:Label>
                            </td>
                            <td style="width: 300px; margin-right: 40px;">
                                <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop" ReadOnly="True"></asp:TextBox>
                             
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                &nbsp;</td>
                            <td style="width: 275px;" align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;

                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات فاتورة الخدمات" OnClick="BtnFind_Click"  Text="بحث"/>
                            </td>
                        </tr>

                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label10" runat="server" Text="اسم السائق*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtname" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                                   <!-- edited by hanan2 -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtname"
                                    Display="Dynamic" ErrorMessage="يجب ادخال اسم السائق" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>

                             <td style="width: 125px;">
                                <asp:Label ID="Label2" runat="server" Text="الاسم بالإنجليزية*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtname2" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>

                            
                  
                        </tr>

                        <tr align="right">

                          <td style="width: 125px;">
                                <asp:Label ID="Label11" runat="server" Text="رقم الهوية*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtid" Width="150px" runat="server" ></asp:TextBox>
                                <!-- edited by hanan2 -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtid"
                                    Display="Dynamic" ErrorMessage="يجب ادخال رقم الهوية" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="txtaddr" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label14" runat="server" Text="*رقم الجوال"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtmob" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                                 <!-- edited by hanan2 -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmob"
                                    Display="Dynamic" ErrorMessage="يجب ادخال رقم الجوال" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                  
                        </tr>

                        
                         <tr align="right">
                             <td style="width: 125px;">
                                <asp:Label ID="Label22" runat="server" Text="الجنسية*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlnat" Width="150px" runat="server" 
                                     AutoPostBack="True" onselectedindexchanged="ddlnat_SelectedIndexChanged" >
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlnat"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الجنسية" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                               
                            </td>
                      </tr>

                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label7" runat="server" Text="نوع/حجم المركبة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddltype11" Width="305px" runat="server" 
                                    onselectedindexchanged="ddltype11_SelectedIndexChanged" 
                                    AutoPostBack="True"> 
                                </asp:DropDownList> <!-- edited by hanan5 -->
                                <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddltype11"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار النوع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label6" runat="server" Text="موديل السيارة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                               <asp:TextBox ID="txtmodel" Width="150px" runat="server" MaxLength="10"></asp:TextBox>   <!-- edited by hanan2 -->
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmodel"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادخال الموديل" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>   <!-- edited by hanan2 -->
                               
                            </td>
                  
                        </tr>

                            <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label16" runat="server" Text="الحساب المرتبط"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlColor" Width="305px" runat="server"></asp:DropDownList>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label17" runat="server" Text="رقم اللوحة"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtplate" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                                 <!-- edited by hanan2 -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtplate"
                                    Display="Dynamic" ErrorMessage="يجب ادخال رقم اللوحة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                  
                        </tr>

                          <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label19" runat="server" Text="البنك"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlbank" Width="150px" runat="server" >
                                </asp:DropDownList>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label20" runat="server" Text="رقم الآيبان"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtiban" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                  
                        </tr>

                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label18" runat="server" Text="نوع السائق"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                               <asp:DropDownList ID="ddltrans" Width="150px" runat="server" >
                                <asp:ListItem Value="1" Text="سيارة صغيرة"></asp:ListItem>
                                <asp:ListItem Value="2" Text="سطحة"></asp:ListItem>
                                <asp:ListItem Value="3" Text="شاحنة رأس تريلا"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <!-- edited by hanan3 ( adding field -->
                               <td style="width: 125px;">
                                <asp:Label ID="Label1" runat="server" Text="نسبة عمولة السائق"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtpercent" Width="150px" runat="server" MaxLength="50"></asp:TextBox><asp:Label
                                    ID="Label3" runat="server" Text="%" Font-Bold="True"></asp:Label>
                                    <asp:Label ID="lblacc" Visible="false" runat="server" Text=""></asp:Label>
                                 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpercent"
                                    Display="Dynamic" ErrorMessage="يجب أختيار نسبة الدخل" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtpercent"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </td>
                            <!-- end edited by hanan3 -->
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
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة سائق" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السائق؟")' 
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات السائق" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح"/>
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات السائق" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات السائق؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>
                            </td>
                        </tr>

                    </table>
                </center>
                <br />
              
        <br />                
            </fieldset>

               <!-- edited by hanan11 : from here -->
              <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ السائقون المتعاونون ]</b></legend>
                <center>
                    <br />
                     <div id="divGrd" runat="server" style="width: 100%; overflow: none; overflow-x: auto;
                border: 1px solid #800000;">
               
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="Black" GridLines="None"
                    AutoGenerateColumns="False" DataKeyNames="ID" Width="99.9%" EmptyDataText="لا توجد بيانات" >
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

                </center>
                <br />               
            </fieldset>
            <!-- edited by hanan11 : to here -->

           
         
        </div>
        <br />

</asp:Content>
