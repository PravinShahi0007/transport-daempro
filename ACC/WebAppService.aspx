<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebAppService.aspx.cs" Inherits="ACC.WebAppService" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [بطاقة خدمة / التطبيق ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">
                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم الخدمة*"></asp:Label>
                            </td>
                            <td style="width: 300px; margin-right: 40px;">
                                <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop" ReadOnly="True" Width="60px"></asp:TextBox>
                             
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الخدمة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                &nbsp;</td>
                            <td style="width: 275px;" align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;

                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات الخدمة" OnClick="BtnFind_Click"  Text="بحث"/>
                            </td>
                        </tr>

                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label10" runat="server" Text="اسم الخدمة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtname" Width="150px" runat="server" MaxLength="100"></asp:TextBox>
                            </td>

                             <td style="width: 125px;">
                                <asp:Label ID="Label2" runat="server" Text="الاسم بالإنجليزية*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtname2" Width="150px" runat="server" MaxLength="100"></asp:TextBox>
                            </td>

                            
                  
                        </tr>
                       <!-- edited by hanan11 : from here -->
                    <tr align="right">
                             <td style="width: 125px;">
                                <asp:Label ID="Label1" runat="server" Text="السعر*"></asp:Label>
                            </td>
                            <td style="width: 300px;">

                                    <asp:TextBox ID="txtprice" Width="60px" runat="server" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtprice"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج السعر" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprice"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                               
                            </td>
                      </tr>
                      <!-- edited by hanan11 : to here -->

                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label21" runat="server" Text="ملاحظات"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtremark" Width="280px" runat="server" MaxLength="100"></asp:TextBox>
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
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة صنف" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الخدمة؟")' 
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات الخدمة" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح"/>
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات الخدمة" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات الخدمة؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>
                            </td>
                        </tr>

                    </table>
                </center>
                <br />
              
        <br />                
            </fieldset>


                <!-- edited by hanan3 : from here -->
              <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ الأصناف ]</b></legend>
                <center>
                    <br />
                     <div id="divGrd" runat="server" style="width: 100%; overflow: none; overflow-x: auto;
                border: 1px solid #800000;">
               
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

                </center>
                <br />               
            </fieldset>
            <!-- edited by hanan3 : to here -->

           
         
        </div>
        <br />

</asp:Content>

