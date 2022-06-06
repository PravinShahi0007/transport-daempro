<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebDealOut.aspx.cs" Inherits="ACC.WebDealOut" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="ColorRounded4Corners" style="width: 99.9%">
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margi n: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                أعدادات خط سير المعاملات الالكترونية</legend>
            <table width="99%" cellpadding="5px">
                <tr>
                    <td style="width: 100px;">
                        <asp:Label ID="Label1" runat="server" Text="نوع المعاملة"></asp:Label>
                    </td>
                    <td style="width: 300px;">
                        <asp:DropDownList ID="ddlType1" Width="300px" runat="server" 
                            AutoPostBack="True" onselectedindexchanged="ddlType1_SelectedIndexChanged">
                            <asp:ListItem Value="001" Text="طلب إجازة"></asp:ListItem>
                            <asp:ListItem Value="002" Text="إشعار مباشرة عمل"></asp:ListItem>
                            <asp:ListItem Value="003" Text="نموذج استلام أصل وثائق"></asp:ListItem>
                            <asp:ListItem Value="004" Text="صرف بدل انتداب"></asp:ListItem>
                            <asp:ListItem Value="005" Text="إخلاء طرف موظف"></asp:ListItem>
                            <asp:ListItem Value="006" Text="طلب تحديد موعد"></asp:ListItem>
                            <asp:ListItem Value="007" Text="خطاب لفت نظر/إنذار"></asp:ListItem>
                            <asp:ListItem Value="008" Text="طلب تحقيق إداري"></asp:ListItem>
                            <asp:ListItem Value="009" Text="طلب أمر إركاب"></asp:ListItem>
                            <asp:ListItem Value="010" Text="طلب تحديد الإجازات الرسمية"></asp:ListItem>
                            <asp:ListItem Value="011" Text="طلب استئذان"></asp:ListItem>
                            <asp:ListItem Value="012" Text="طلب إبلاغ عن مشكلة"></asp:ListItem>
                            <asp:ListItem Value="013" Text="طلب تعريف موظف/راتب"></asp:ListItem>
                            <asp:ListItem Value="014" Text="طلب تأمين طبي"></asp:ListItem>
                            <asp:ListItem Value="015" Text="طلبات التجديد"></asp:ListItem>
                            <asp:ListItem Value="016" Text="طلب زيادة راتب"></asp:ListItem>
                            <asp:ListItem Value="017" Text="طلب ترقية موظف"></asp:ListItem>
                            <asp:ListItem Value="018" Text="طلب تحويل موظف من قسم لقسم"></asp:ListItem>
                            <asp:ListItem Value="019" Text="طلب تجديد عقد ايجار"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 100px;">
                    </td>
                    <td style="width: 300px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        <asp:Label ID="Label2" runat="server" Text="صلاحية الإنشاء"></asp:Label>
                    </td>
                    <td rowspan="3" style="width: 300px;" >
                                       <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
											BorderColor="Maroon" Width="100%" Height="170px">
                                           <asp:CheckBoxList ID="ddlcreat" runat="server">
                                           </asp:CheckBoxList>
										</asp:Panel>
                    </td>
                    <td style="width: 100px;">
                    </td>
                    <td style="width: 300px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                    </td>
                    <td style="width: 150px;">
                    </td>
                    <td style="width: 300px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                    </td>
                    <td style="width: 150px;">
                    </td>
                    <td style="width: 300px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                        <asp:Label ID="Label3" runat="server" Text="دورة الموافقة على الطلب"></asp:Label>
                        &nbsp;
                    </td>
                    <td style="width: 100px;">
                        &nbsp;
                    </td>
                    <td style="width: 300px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        <asp:Label ID="Label4" runat="server" Text="الموافقة الأولى"></asp:Label>
                    </td>
                    <td style="width: 320px;">
                        <asp:DropDownList ID="ddlappr1" runat="server" Width="185px">
                            <asp:ListItem Value="-1" Text="اختيار"></asp:ListItem>
                            <asp:ListItem Value="1" Text="user 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="user 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="user 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="user 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="user 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="user 6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="user 7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="user 8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSType1" runat="server" Width="92px">
                            <asp:ListItem Value="0" Text="موافقة ورفض"></asp:ListItem>
                            <asp:ListItem Value="1" Text="للعلم"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="ChkAction1" ToolTip="تحديث البيانات" runat="server" AutoPostBack="True" oncheckedchanged="ChkAction1_CheckedChanged" />
                    </td>
                    <td style="width: 80px;">
                        <asp:Label ID="Label5" runat="server" Text="الموافقة الثانية"></asp:Label>
                    </td>
                    <td style="width: 320px;">
                        <asp:DropDownList ID="ddlappr2" runat="server" Width="175px">
                            <asp:ListItem Value="-1" Text="اختيار"></asp:ListItem>
                            <asp:ListItem Value="1" Text="user 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="user 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="user 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="user 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="user 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="user 6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="user 7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="user 8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSType2" runat="server" Width="90px">
                            <asp:ListItem Value="0" Text="موافقة ورفض"></asp:ListItem>
                            <asp:ListItem Value="1" Text="للعلم"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="ChkAction2" ToolTip="تحديث البيانات" runat="server" AutoPostBack="True" oncheckedchanged="ChkAction1_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        <asp:Label ID="Label6" runat="server" Text="الموافقة الثالثة"></asp:Label>
                    </td>
                    <td style="width: 320px;">
                        <asp:DropDownList ID="ddlappr3" runat="server" Width="185px">
                            <asp:ListItem Value="-1" Text="اختيار"></asp:ListItem>
                            <asp:ListItem Value="1" Text="user 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="user 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="user 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="user 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="user 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="user 6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="user 7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="user 8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSType3" runat="server" Width="92px">
                            <asp:ListItem Value="0" Text="موافقة ورفض"></asp:ListItem>
                            <asp:ListItem Value="1" Text="للعلم"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="ChkAction3" ToolTip="تحديث البيانات" runat="server" AutoPostBack="True" oncheckedchanged="ChkAction1_CheckedChanged" />
                    </td>
                    <td style="width: 80px;">
                        <asp:Label ID="Label7" runat="server" Text="الموافقة الرابعة"></asp:Label>
                    </td>
                    <td style="width: 320px;">
                        <asp:DropDownList ID="ddlappr4" runat="server" Width="175px">
                            <asp:ListItem Value="-1" Text="اختيار"></asp:ListItem>
                            <asp:ListItem Value="1" Text="user 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="user 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="user 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="user 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="user 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="user 6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="user 7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="user 8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSType4" runat="server" Width="90px">
                            <asp:ListItem Value="0" Text="موافقة ورفض"></asp:ListItem>
                            <asp:ListItem Value="1" Text="للعلم"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="ChkAction4" ToolTip="تحديث البيانات" runat="server" AutoPostBack="True" oncheckedchanged="ChkAction1_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        <asp:Label ID="Label8" runat="server" Text="الموافقة الخامسة"></asp:Label>
                    </td>
                    <td style="width: 320px;">
                        <asp:DropDownList ID="ddlappr5" runat="server" Width="185px">
                            <asp:ListItem Value="-1" Text="اختيار"></asp:ListItem>
                            <asp:ListItem Value="1" Text="user 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="user 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="user 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="user 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="user 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="user 6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="user 7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="user 8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSType5" runat="server" Width="92px">
                            <asp:ListItem Value="0" Text="موافقة ورفض"></asp:ListItem>
                            <asp:ListItem Value="1" Text="للعلم"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="ChkAction5" ToolTip="تحديث البيانات" runat="server" AutoPostBack="True" oncheckedchanged="ChkAction1_CheckedChanged" />
                    </td>
                    <td style="width: 80px;">
                        <asp:Label ID="Label9" runat="server" Text="الموافقة السادسة"></asp:Label>
                    </td>
                    <td style="width: 320px;">
                        <asp:DropDownList ID="ddlappr6" runat="server" Width="175px">
                            <asp:ListItem Value="-1" Text="اختيار"></asp:ListItem>
                            <asp:ListItem Value="1" Text="user 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="user 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="user 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="user 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="user 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="user 6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="user 7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="user 8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSType6" runat="server" Width="90px">
                            <asp:ListItem Value="0" Text="موافقة ورفض"></asp:ListItem>
                            <asp:ListItem Value="1" Text="للعلم"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="ChkAction6" ToolTip="تحديث البيانات" runat="server" AutoPostBack="True" oncheckedchanged="ChkAction1_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        <asp:Label ID="Label10" runat="server" Text="الموافقة السابعة"></asp:Label>
                    </td>
                    <td style="width: 320px;">
                        <asp:DropDownList ID="ddlappr7" runat="server" Width="185px">
                            <asp:ListItem Value="-1" Text="اختيار"></asp:ListItem>
                            <asp:ListItem Value="1" Text="user 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="user 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="user 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="user 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="user 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="user 6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="user 7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="user 8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSType7" runat="server" Width="92px">
                            <asp:ListItem Value="0" Text="موافقة ورفض"></asp:ListItem>
                            <asp:ListItem Value="1" Text="للعلم"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="ChkAction7" ToolTip="تحديث البيانات" runat="server" AutoPostBack="True" oncheckedchanged="ChkAction1_CheckedChanged" />
                    </td>
                    <td style="width: 100px;">
                        <asp:Label ID="Label11" runat="server" Text="الموافقة الثامنة"></asp:Label>
                    </td>
                    <td style="width: 320px;">
                        <asp:DropDownList ID="ddlappr8" runat="server" Width="175px">
                            <asp:ListItem Value="-1" Text="اختيار"></asp:ListItem>
                            <asp:ListItem Value="1" Text="user 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="user 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="user 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="user 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="user 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="user 6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="user 7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="user 8"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSType8" runat="server" Width="90px">
                            <asp:ListItem Value="0" Text="موافقة ورفض"></asp:ListItem>
                            <asp:ListItem Value="1" Text="للعلم"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="ChkAction8" ToolTip="تحديث البيانات" runat="server" AutoPostBack="True" oncheckedchanged="ChkAction1_CheckedChanged" />
                    </td>
                </tr>
            </table>
                <center>
            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
            <br />            
                    <div class="DivButtons" style="width: 95%">
                        <table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                            <tr align="center">
                                <td style="width: 150px;">
                                    &nbsp;
                                </td>
                                <td style="width: 400px;">
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                        ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل الإعدادات"
                                        Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                            <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" 
                                        onclick="BtnClear_Click" />
                                </td>
                                <td id="td1" runat="server" style="width: 200px; text-align: right">
                                    <br />
                                    &nbsp;
                                    </td>
                            </tr>
                        </table>
                    </div>
                    <br />
        </center>
        </fieldset>        
        <br />
    </div>
</asp:Content>
