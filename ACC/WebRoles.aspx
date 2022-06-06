<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebRoles.aspx.cs" Inherits="ACC.WebRoles" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Styles/PrevCheckList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript">
        function ChangeState(state) {

            var chkBoxList = document.getElementById("ContentPlaceHolder1_ChkPass");
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            for (var i = 0; i < chkBoxCount.length; i++) {
                chkBoxCount[i].checked = state;
            }
            return false;
        }

        function uncheckList(sender) {
            return false;
            var chkBoxList = document.getElementById("ContentPlaceHolder1_ChkPass");
            var chkBox = document.getElementById(sender);
            var vsubstr = chkBox.value;
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            if (vsubstr.length > 6) {
                if (chkBox.checked) {
                    var vstr = vsubstr.substr(0, 6);
                    for (var i = 0; i < chkBoxCount.length; i++) {
                        if (chkBoxCount[i].value == vstr) {
                            chkBoxCount[i].checked = true;
                            break;
                        }
                    }
                }
                else {
                    var vstr = vsubstr.substr(0, 6);
                    var vfound = true;
                    for (var i = 0; i < chkBoxCount.length; i++) {
                        var vstr2 = chkBoxCount[i].value;
                        if (vstr2.length > 6) {
                            vstr2 = vstr2.substr(0, 6);
                            if (vstr2 == vstr) {
                                if (chkBoxCount[i].checked) {
                                    vfound = false;
                                    break;
                                }
                            }
                        }
                    }

                    if (vfound) {
                        for (var i = 0; i < chkBoxCount.length; i++) {
                            if (chkBoxCount[i].value == vstr) {
                                chkBoxCount[i].checked = false;
                                break;
                            }
                        }
                    }
                }
            }
            else {
                for (var i = 0; i < chkBoxCount.length; i++) {
                    var vstr = chkBoxCount[i].value;
                    if (vstr.indexOf(vsubstr) != -1) {
                        chkBoxCount[i].checked = chkBox.checked;
                    }
                }
            }
            return false;
        }
    </script>
    <center dir="rtl">
        <asp:Panel ID="Panel1" runat="server" CssClass="ColorRounded4Corners" >
        <center>
                <table id="Table1" dir="rtl"  cellpadding="2" style="color:Black">
                
                    <tr id="tr1">
                     
                        <td >
                             <asp:Label ID="LblCode" runat="server" Text="اسم مجموعة العمل"></asp:Label>
                       
                            <asp:TextBox ID="txtRoleName" CssClass="form-control"  runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValRoleName" runat="server" ControlToValidate="txtRoleName"
                                ErrorMessage="يجب إدخال اسم مجموعة العمل" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                     
                        
                    </tr>
                        <tr id="tr005" >
                       
                        <td style="width: 280px">
                              <asp:Label ID="Label2" runat="server" Text="نوع الواجهة"></asp:Label>
                       
                            <asp:DropDownList ID="ddlInterface" CssClass="form-control" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlInterface_SelectedIndexChanged">
                                <asp:ListItem Value="0">عام</asp:ListItem>
                                <asp:ListItem Value="1">دعم فني</asp:ListItem>
                                <asp:ListItem Value="2">موردين</asp:ListItem>
                                <asp:ListItem Value="3">عملاء</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                        </tr>
                        <tr id="tr2" align="right">
                      
                        <td style="width: 280px">
                                <asp:Label ID="Label4" runat="server" Text="نسخ مجموعة العمل"></asp:Label>
                     
                            <asp:DropDownList ID="ddlRoles" CssClass="form-control" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlRoles_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px;">
                            &nbsp;
                        </td>
                        </tr>
                       <tr id="tr5" align="right">
                        <td  colspan="2" style="width: 200px;">
                            <div class="list_collapse" style="width:50%">
                                <asp:CheckBoxList ID="ChkPass" Width="100%" runat="server" CssClass="chicklist">
                                </asp:CheckBoxList>
                            </div>
                            <div class="card-footer">
                            <input id="Button1" type="button" value="أختيار الجميع" class="btn btn-primary" onclick="ChangeState(true);" />
                            <input id="Button2" type="button" value="مسـح الجميع" class="btn btn-primary" onclick="ChangeState(false);" />
                       </div> </td>
                        <td style="width: 100px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr4" align="right">
                        <td style="width: 100px;">
                            <asp:Label ID="Label1" runat="server" Text="إدخلت بواسطة"></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="txtUserName" CssClass="form-control" style="width: 105px;" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                Enabled="false"></asp:TextBox>
                        </td>
                        <td >
                            <asp:Label ID="Label3" runat="server" Text="بتاريخ"></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="txtUserDate" CssClass="form-control" style="width: 105px;"  runat="server" MaxLength="50" BackColor="#E8E8E8"
                                Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                     <tr align="right">
                         <td style="width: 100px;">
                                <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>
                         </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                          
                        
                        </tr>

                    <tr id="tr3" align="right">
                    
                        <td >
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        </td>
                       
                        <td  rowspan="4">
                            <div  >
                                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" EmptyDataText="لا توجد بيانات"
                                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="RoleName" AllowPaging="True"
                                    ShowFooter="True" PageSize="5"  OnPageIndexChanging="grdCodes_PageIndexChanging"
                                    OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="اختيار مجموعة العمل"
                                                    ImageUrl="~/images/arrow_undo.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="مجموعة العمل" SortExpression="RoleName" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" Text='<%# Bind("RoleName") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="350px" />
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
                        </td>

                    </tr>
                </table></center>
        
                <table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                    <tr align="center">
                        <td style="width: 200px;">
                        </td>
                        <td style="width: 350px;">
                            <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                ImageUrl="~/images/insource_642.png"   ToolTip="أضافة مجموعة عمل جديدة"
                                ValidationGroup="1" OnClick="BtnNew_Click" OnClientClick='return confirm("هل أنت متاكد من حفظ البيانات؟")' />
                            <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات مجموعة عمل"
                                Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                            <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                ImageUrl="~/images/erasure_642.png"   ToolTip="مسح خانات الشاشة"
                                OnClick="BtnClear_Click" />
                            <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete" ValidationGroup="1"
                                ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات مجموعة عمل"
                                OnClick="BtnDelete_Click" OnClientClick='return confirm("هل أنت متاكد من الغاء البيانات؟")' />
                            <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                ImageUrl="~/images/binoculars_642.png"   ToolTip="البحث عن بيانات مجموعة عمل"
                                OnClick="BtnSearch_Click" />
                        </td>
                         <td id="td1" runat="server" style="width: 200px; text-align: right">
                            <asp:Label ID="Label11" runat="server" Text="بحث :"></asp:Label>
                            <asp:TextBox ID="txtSearch" CssClass="form-control" MaxLength="200" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
          
        </asp:Panel>
        <br />
    </center>
</asp:Content>
