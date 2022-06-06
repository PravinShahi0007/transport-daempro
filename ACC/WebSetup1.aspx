<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebSetup1.aspx.cs" Inherits="ACC.WebSetup1" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            SetMyStyle();
            $(function () {
                $("#tabs").css("visibility", "visible");
                $("#tabs").tabs({
                    event: "click",                    
                    select: function (e, i) {
                        var selected_tab = i.index;
                        $("#<%= hdnSelectedTab.ClientID %>").val(selected_tab);
                    }
                });
                $("#tabs").tabs('select', parseInt($("#<%= hdnSelectedTab.ClientID %>").val()));
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center dir="rtl">
        <div class="ColorRounded4Corners">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ إعدادات النظام ]</b></legend>
                <center>
                    <div class="demo">
                        <%--<div id="tabs" style="visibility:hidden;">--%>
                        <div id="tabs" >
                            <ul>
                                <li><a href="#tabs-2">عام</a></li>
                                <li><a href="#tabs-3">الوثائق الشخصية</a></li>
                                <li><a href="#tabs-5">بنود الرواتب</a></li>
                                <li><a href="#tabs-4">أجهزة البصمة</a></li>
                                <li><a href="#tabs-1">توقيتات الحضور و الانصراف</a></li>
                            </ul>                 
                            <div id="tabs-2">
                                <table class="box-table-a" width="100%" style="text-align: right">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                                <p style="text-align: right">
                                                    <strong>اسم النشاط - عربي</strong></p>
                                            </td>
                                            <td colspan="3" align="right">                                                
                                                <asp:TextBox ID="txtCompanyName" MaxLength="100" Width="400px" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 120px">                                                
                                            </td>
                                            <td style="width: 50px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <p style="text-align: right">
                                                    <strong>اسم النشاط - أنجليزي</strong></p>
                                            </td>
                                            <td colspan="3" align="right">                                                
                                                <asp:TextBox ID="txtCompanyName2" MaxLength="100" Width="400px" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 120px">                                                
                                            </td>
                                            <td style="width: 50px">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>                                      
                            </div>
                            <div id="tabs-3">
                                <table class="box-table-a" width="100%">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                                <p style="text-align: right">
                                                    <strong>أعدادات مسميات الوثائق الشخصية</strong></p>
                                            </td>
                                            <td style="width:25%">
                                                &nbsp;</td>
                                            <td style="width:25%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>01-
                                                <asp:TextBox ID="txtPaper1" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE1" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>02-
                                                <asp:TextBox ID="txtPaper2" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE2" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>03-
                                                <asp:TextBox ID="txtPaper3" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE3" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>04-
                                                <asp:TextBox ID="txtPaper4" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE4" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>05-
                                                <asp:TextBox ID="txtPaper5" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE5" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>06-
                                                <asp:TextBox ID="txtPaper6" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE6" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>07-
                                                <asp:TextBox ID="txtPaper7" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE7" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>08-
                                                <asp:TextBox ID="txtPaper8" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE8" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>09-
                                                <asp:TextBox ID="txtPaper9" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE9" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>10-
                                                <asp:TextBox ID="txtPaper10" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPaperE10" MaxLength="20" Width="150px" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="tabs-4">

                       <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="False" PageSize="200" Font-Size="Smaller"
                        Width="99.9%" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="رقم الساعة" SortExpression="Code" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوصف بالعربي" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوصف بالانجليزي" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LAN TCP-IP" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLANTCPIP" Text='<%# Bind("LANTCPIP") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LAN Port" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLANPORT" Text='<%# Bind("LANPORT") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WAN TCP-IP" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblWANTCPIP" Text='<%# Bind("WANTCPIP") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WAN Port" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblWANPORT" Text='<%# Bind("WANPORT") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loc" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLOC" Text='<%# Bind("LOC") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
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
                            <div id="tabs-5">
                                <table class="box-table-a" width="100%">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                                <p style="text-align: right">
                                                    <strong>أعدادات مسميات الاستحقاقات و الاستقطاعات</strong></p>
                                            </td>
                                            <td style="width:25%">
                                                &nbsp;</td>
                                            <td style="width:25%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <strong>الاستحقاقات</strong></td>
                                            <td colspan="2">
                                                <strong>الاستقطاعات</strong></td>
                                        </tr>
                                        <tr>
                                            <td>01-
                                                <asp:TextBox ID="txtAdd01" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd201" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd01" runat="server" Width="180px">                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td>01-
                                                <asp:TextBox ID="txtDed01" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed201" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed01" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>02-
                                                <asp:TextBox ID="txtAdd02" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd202" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd02" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>02-
                                                <asp:TextBox ID="txtDed02" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed202" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed02" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>                                        
                                        </tr>
                                        <tr>
                                            <td>03-
                                                <asp:TextBox ID="txtAdd03" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd203" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd03" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>03-
                                                <asp:TextBox ID="txtDed03" MaxLength="30" Width="75px" runat="server"></asp:TextBox>                                           
                                                <asp:TextBox ID="txtDed203" MaxLength="30" Width="75px" runat="server"></asp:TextBox>                                           
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed03" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>04-
                                                <asp:TextBox ID="txtAdd04" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd204" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd04" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>04-
                                                <asp:TextBox ID="txtDed04" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed204" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed04" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>05-
                                                <asp:TextBox ID="txtAdd05" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd205" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd05" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>05-
                                                <asp:TextBox ID="txtDed05" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed205" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed05" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>06-
                                                <asp:TextBox ID="txtAdd06" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd206" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd06" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>06-
                                                <asp:TextBox ID="txtDed06" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed206" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed06" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>07-
                                                <asp:TextBox ID="txtAdd07" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd207" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd07" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>07-
                                                <asp:TextBox ID="txtDed07" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed207" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed07" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>08-
                                                <asp:TextBox ID="txtAdd08" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd208" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd08" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>08-
                                                <asp:TextBox ID="txtDed08" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed208" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed08" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>09-
                                                <asp:TextBox ID="txtAdd09" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd209" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd09" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>09-
                                                <asp:TextBox ID="txtDed09" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed209" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed09" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>10-
                                                <asp:TextBox ID="txtAdd10" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd210" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd10" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>10-
                                                <asp:TextBox ID="txtDed10" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed210" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed10" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>11-
                                                <asp:TextBox ID="txtAdd11" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd211" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd11" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>11-
                                                <asp:TextBox ID="txtDed11" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed211" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed11" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>12-
                                                <asp:TextBox ID="txtAdd12" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd212" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd12" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>12-
                                                <asp:TextBox ID="txtDed12" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed212" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed12" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>13-
                                                <asp:TextBox ID="txtAdd13" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd213" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd13" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>13-
                                                <asp:TextBox ID="txtDed13" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed213" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed13" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>14-
                                                <asp:TextBox ID="txtAdd14" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd214" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd14" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>14-
                                                <asp:TextBox ID="txtDed14" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed214" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed14" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">15-
                                                <asp:TextBox ID="txtAdd15" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtAdd215" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAdd15" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>15-
                                                <asp:TextBox ID="txtDed15" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtDed215" MaxLength="30" Width="75px" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDed15" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">16- الراتب الاساسي                                                
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBasic" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="tabs-1">
                                <table class="box-table-a" width="100%">
                                    <tbody>
                                        <tr>
                                            <td colspan="3">
                                                <p style="text-align: right">
                                                    <strong>توقيتات الحضور و الانصراف</strong>&nbsp;&nbsp;
                                                    <asp:DropDownList ID="ddlShift" Width="250px" runat="server" 
                                                        AutoPostBack="True" onselectedindexchanged="ddlShift_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    
                                                    
                                                    </p>
                                            </td>
                                            <td style="width:25%" colspan="2">
                                                &nbsp;</td>
                                            <td style="width:25%" colspan="2">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="right">
                                                <strong>خلال أيام الاسبوع</strong></td>
                                            <td colspan="4">
                                                <asp:CheckBox ID="ChkThSat" runat="server" Text="دوام الخميس بديل السبت او السبت بديل الخميس" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFTime" runat="server" Text="وقت الحضور"></asp:Label>
                                            </td>
                                            <td colspan="2">                                            
                                                <asp:TextBox ID="txtFTime" MaxLength="10" Width="75px" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFTime" ValidationGroup="1"
                                                    Text="*" SetFocusOnError="true" ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])(:[0-5]\d){0,2}$"
                                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة وقت"></asp:RegularExpressionValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblETime" runat="server" Text="وقت الانصراف"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtETime" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtETime" ValidationGroup="1"
                                                    Text="*" SetFocusOnError="true" ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])(:[0-5]\d){0,2}$"
                                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة وقت"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="right">
                                                <strong>يوم السبت</strong></td>
                                            <td colspan="4">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSFTime" runat="server" Text="وقت الحضور"></asp:Label>
                                            </td>
                                            <td colspan="2">                                            
                                                <asp:TextBox ID="txtSFTime" MaxLength="5" Width="75px" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSFTime" ValidationGroup="1"
                                                    Text="*" SetFocusOnError="true" ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])(:[0-5]\d){0,2}$"
                                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة وقت"></asp:RegularExpressionValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblSETime" runat="server" Text="وقت الانصراف"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtSETime" MaxLength="5" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSETime" ValidationGroup="1"
                                                    Text="*" SetFocusOnError="true" ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])(:[0-5]\d){0,2}$"
                                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة وقت"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="right">
                                                <strong>خلال شهر رمضان</strong></td>
                                            <td colspan="4">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRFTime" runat="server" Text="وقت الحضور"></asp:Label>
                                            </td>
                                            <td colspan="2">                                            
                                                <asp:TextBox ID="txtRFTime" MaxLength="5" Width="75px" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtRFTime" ValidationGroup="1"
                                                    Text="*" SetFocusOnError="true" ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])(:[0-5]\d){0,2}$"
                                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة وقت"></asp:RegularExpressionValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblRETime" runat="server" Text="وقت الانصراف"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtRETime" MaxLength="5" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtRETime" ValidationGroup="1"
                                                    Text="*" SetFocusOnError="true" ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])(:[0-5]\d){0,2}$"
                                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة وقت"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>                                        
                                        <tr>
                                            <td colspan="3" align="right">
                                                <strong>مهله الحضور و الانصراف</strong></td>
                                            <td colspan="4">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td> 
                                                <asp:Label ID="lblLate" runat="server" Text="مهله التاخير بالدقائق"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDLate" runat="server" Text="يومي"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDLate" MaxLength="5" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtDLate" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMDLate" runat="server" Text="شهري"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMDLate" MaxLength="5" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtMDLate" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblYDLate" runat="server" Text="سنوي"></asp:Label>
                                            </td>                                        
                                            <td>
                                                <asp:TextBox ID="txtYDLate" MaxLength="5" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtYDLate" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>                                        
                                        </tr>
                                        <tr>
                                            <td> 
                                                <asp:Label ID="lblLateNo" runat="server" Text="عدد مرات التاخير"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMDLateNo" runat="server" Text="شهري"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMDLateNo" MaxLength="5" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtMDLateNo" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblYDLateNo" runat="server" Text="سنوي"></asp:Label>
                                            </td>                                        
                                            <td>
                                                <asp:TextBox ID="txtYDLateNo" MaxLength="5" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtYDLateNo" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>                                        
                                        </tr>
                                        <tr>
                                            <td> 
                                                <asp:Label ID="lblEarly" runat="server" Text="مهله أنصراف مبكر بالدقائق"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDEarly" runat="server" Text="يومي"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDEarly" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="txtDEarly" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMDEarly" runat="server" Text="شهري"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMDEarly" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtMDEarly" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblYDEarly" runat="server" Text="سنوي"></asp:Label>
                                            </td>                                        
                                            <td>
                                                <asp:TextBox ID="txtYDEarly" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtYDEarly" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>                                        
                                        </tr>
                                         <tr>
                                            <td> 
                                                <asp:Label ID="lblEarlyNo" runat="server" Text="عدد مرات أنصراف مبكر"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMDEarlyNo" runat="server" Text="شهري"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMDEarlyNo" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="txtMDEarlyNo" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblYDEarlyNo" runat="server" Text="سنوي"></asp:Label>
                                            </td>                                        
                                            <td>
                                                <asp:TextBox ID="txtYDEarlyNo" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="txtYDEarlyNo" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>                                        
                                        </tr>
                                        <tr>
                                            <td colspan="3"> 
                                                <asp:Label ID="lblForget" runat="server" Text="عدد مرات نسيان تسجيل الحضور أو الانصراف"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMForget" runat="server" Text="شهري"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMForget" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="txtMForget" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblYForget" runat="server" Text="سنوي"></asp:Label>
                                            </td>                                        
                                            <td>
                                                <asp:TextBox ID="txtYForget" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="txtYForget" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>                                        
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNoTime" runat="server" Text="عدد ساعات العمل شهرياً"></asp:Label>
                                            </td>
                                            <td colspan="2">                                            
                                                <asp:TextBox ID="txtNoTime" MaxLength="10" Width="75px" runat="server"></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="txtNoTime" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="Label1" runat="server" Text="عدد ساعات الخصم في حالة نسيان تسجيل الحضور أو الانصراف"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtForget" MaxLength="10" Width="75px" runat="server"></asp:TextBox>                                                
                                                <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToValidate="txtForget" ValidationGroup="1"
                                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" SetFocusOnError="True"
                                                    Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td>
                                        </tr>                                        
                                    </tbody>
                                </table>
                            </div>

                            <div class="mytd">
                            <table  cellpadding="5px" cellspacing="5px"  width="100%" style="color:Black;" >
                            <tr>
                             <td colspan="3" >
                                <center>
                                       <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                       <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" ValidationGroup="1" />
                                </center>
                             </td>
                             <td style="width:20%; text-align:center" >
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" 
                                        CommandName="Edit" ValidationGroup="1"
                                        ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات أعدادات النظام"
                                        Width="64px" onclick="BtnEdit_Click"   />

                             </td>
                            </tr>
                            </table>
                            </div>
                        </div>
                    </div>
                    <!-- End demo -->
                </center>
            </fieldset>
        </div>
        <asp:HiddenField ID="hdnSelectedTab" runat="server" Value="0" />
    </center>
</asp:Content>
