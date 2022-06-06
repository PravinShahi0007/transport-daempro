<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebAppPrice.aspx.cs" Inherits="ACC.WebAppPrice" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Round4Courner" style="width: 98%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [بطاقة تسعير المياه / التطبيق ]</b></legend>
                <center>
                    <br />
                    <table dir="rtl" width="99%" cellpadding="2px">

                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم التصنيف*"></asp:Label>
                            </td>
                            <td style="width: 300px; margin-right: 40px;">
                                <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop" ReadOnly="True" Width="60px"></asp:TextBox>
                             
                            </td>
                            <td style="width: 100px;">
                                &nbsp;</td>
                            <td style="width: 275px;" align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;

                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات التسعير" OnClick="BtnFind_Click"  Text="بحث"/>
                            </td>
                        </tr>

                        <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label7" runat="server" Text="نوع المياه*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddltype11" Width="150px" runat="server"  
                                    AutoPostBack="True" 
                                    onselectedindexchanged="ddltype11_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="إختر النوع"></asp:ListItem>
                                <asp:ListItem Value="1" Text="مياه عذبة"></asp:ListItem>
                                <asp:ListItem Value="2" Text="مياه صالحة للشرب"></asp:ListItem>
                                <asp:ListItem Value="3" Text="مياه غير صالحة"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddltype11"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار النوع" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>

                             <td style="width: 125px;">
                                <asp:Label ID="Label6" runat="server" Text="المدينة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlcity" Width="150px" runat="server" AutoPostBack="True" onselectedindexchanged="ddlcity_SelectedIndexChanged" 
                                   >
                                </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlcity"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار المدينة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                               
                            </td>
                        </tr>
                      <!-- edited by hanan4 : from here -->  
                         <tr align="right">
                            <td style="width: 125px;">
                                <asp:Label ID="Label10" runat="server" Text="الحجم*"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtname" Width="60px" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="m^3"></asp:Label>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtname"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </td>

                              <td style="width: 125px;">
                                <asp:Label ID="Label3" runat="server" Text="التكلفة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">

                                    <asp:TextBox ID="txtcost" Width="60px" runat="server" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcost"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج التكلفة" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtcost"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                               
                            </td>
                       
                        </tr>

                            <tr align="right">
                          
                          <td style="width: 125px;">
                                <asp:Label ID="Label2" runat="server" Text="سعر البيع*"></asp:Label>
                            </td>
                            <td style="width: 300px;">

                                    <asp:TextBox ID="txtprice" Width="60px" runat="server" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtprice"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج السعر" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprice"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                               
                            </td>

                             <td style="width: 125px;">
                                <asp:Label ID="Label4" runat="server" Text="سعر الخدمة*"></asp:Label>
                            </td>
                            <td style="width: 300px;">

                                    <asp:TextBox ID="txtprice2" Width="60px" runat="server" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtprice2"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب ادراج السعر" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtprice2"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                               
                            </td>

                        </tr>
                    <!-- edited by hanan4 : to here -->  

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
                                    ImageUrl="~/images/insource_642.png" ToolTip="أضافة تسعير" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات التسعير؟")' 
                                    OnClick="BtnNew_Click" Text="جديد" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات التسعير" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" Text="مسح"/>
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات التسعير" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات التسعير؟")' OnClick="BtnDelete_Click" Text="إلغاء"/>
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
                    [ بيانات التسعير ]</b></legend>
                <center>
                    <br />
                     <div id="divGrd" runat="server" style="width: 100%; overflow: none; overflow-x: auto;
                border: 1px solid #800000;">
                 <!-- edited by hanan3 (update gridview) -->  
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="Black" GridLines="None"
                    AutoGenerateColumns="False" DataKeyNames="FType3" Width="99.9%" EmptyDataText="لا توجد بيانات" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                         <asp:TemplateField HeaderText="الرقم" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label ID="lblno" Text='<%# Bind("FType3") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الحجم" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="تكلفة الشراء" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                            <ItemTemplate>
                                <asp:Label ID="lblprice2" Text='<%# Bind("Cost")%>' 
                                    runat="server"></asp:Label>
                                
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="سعر البيع" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                            <ItemTemplate>
                                <asp:Label ID="lblprice" Text='<%# Bind("Price")%>' 
                                    runat="server"></asp:Label>
                                
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="سعر الخدمة" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                            <ItemTemplate>
                                <asp:Label ID="lblprice3" Text='<%# Bind("SerPrice")%>' 
                                    runat="server"></asp:Label>
                                
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="إجمالي البيع" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center" Visible="True">
                            <ItemTemplate>
                                <asp:Label ID="lbltotal" Text='<%# (int.Parse(Eval("Price").ToString())+int.Parse(Eval("SerPrice").ToString())).ToString()%>' 
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

           
         
        </div>
        <br />


</asp:Content>
