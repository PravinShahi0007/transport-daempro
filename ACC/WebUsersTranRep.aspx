<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebUsersTranRep.aspx.cs" Inherits="ACC.WebUsersTranRep" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRound4Courner">
            <center>
                <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
                    border: solid 2px #800000">
                    <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                        كشف متابعة المستخدمين</legend>
                    <table width="99%">
                        <tr>
                            <td style="width: 75px; text-align:center;">
                                <asp:Label ID="Label5" runat="server" Text="اليوم" 
                                    style="font-weight: 700; text-align: center;"></asp:Label>
                            </td>
                            <td style="text-align: right;" rowspan="2">
                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                                    BorderColor="#3366CC" BorderWidth="1px" DayNameFormat="Shortest"
                                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" 
                                    style="text-align: right" Width="220px" 
                                    FirstDayOfWeek="Saturday" 
                                    onselectionchanged="Calendar1_SelectionChanged" CellPadding="1" >
                                    <DayHeaderStyle BackColor="#99CCCC" Height="1px" ForeColor="#336666" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#CCCCFF" BorderColor="#3366CC" BorderWidth="1px" 
                                        Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </td>
                            <td>
                                <table width="100%">
                                  <tr>
                                     <td>
                                         <asp:Label ID="Label1" runat="server" Text="المستخدم"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="ddlUserName" Width="250px" runat="server" 
                                             AutoPostBack="True" onselectedindexchanged="ddlUserName_SelectedIndexChanged">
                                         </asp:DropDownList>
                                     </td>
                                  </tr>
                                  <tr>
                                     <td>
                                         <asp:Label ID="Label2" runat="server" Text="الصفحة"></asp:Label>                         
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="ddlFormName" Width="250px" runat="server" 
                                             AutoPostBack="True" onselectedindexchanged="ddlFormName_SelectedIndexChanged">
                                         </asp:DropDownList>
                                     </td>
                                  </tr>
                                  <tr>
                                     <td>
                                         <asp:Label ID="Label3" runat="server" Text="الحدث"></asp:Label>                         
                                     </td>
                                     <td>
                                         <asp:DropDownList ID="ddlFormAction" Width="250px" runat="server" 
                                             AutoPostBack="True" onselectedindexchanged="ddlFormAction_SelectedIndexChanged">
                                         </asp:DropDownList>
                                     </td>
                                  </tr>
                                </table>
                            </td>
                            <td style="width: 200px; text-align: center;" rowspan="2">
                                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                    ImageUrl="~/images/Process.png" ToolTip="تشغيل التقرير" 
                                    onclick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"
                                    ImageUrl="~/images/Excel.png" ToolTip="'طباعة بيانات التقرير" 
                                    OnClientClick="aspnetForm.target ='_blank';" onclick="BtnExcel_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ToolTip="'طباعة بيانات التقرير" 
                                    OnClientClick="aspnetForm.target ='_blank';" onclick="BtnPrint_Click" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 75px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="tr13" align="right">
                            <td>
                                &nbsp;</td>
                            <td style="width: 150px">
                                <asp:Label ID="lblRecordsNo" Text='عدد السجلات' runat="server"></asp:Label>                                    
                                &nbsp;                                    
                                <asp:DropDownList ID="ddlRecordsPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="10000">10000</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <div style="width: 100%;  height:500px; overflow:none; overflow-x:auto ; border: 1px solid #800000;">
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    GridLines="None" AutoGenerateColumns="False" AllowPaging="True"  DataKeyNames="TranDate"
                    EmptyDataText="لا توجد بيانات" Width="99%"  
                        onpageindexchanging="grdCodes_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="التاريخ" SortExpression="TranDate" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTranDate" Text='<%# Bind("TranDate") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الوقت" SortExpression="TranTime" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTranTime" Text='<%# Bind("TranTime") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="المستخدم" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="75px" />
                            <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="البيان" SortExpression="Description" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" Text='<%# Bind("Description") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="السبب" SortExpression="Reason" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblReason" Text='<%# Bind("Reason") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IP" SortExpression="IP" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblIP" Text='<%# Bind("IP") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الموقع" SortExpression="Lat" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="lbllat" Text='<%# Eval("lat2") %>' NavigateUrl='<%# string.Format("~/WebMap.aspx?lat={0}&lng={1}",Eval("lat"),Eval("lng")) %>' Target="_blank" runat="server"></asp:HyperLink>   
                            </ItemTemplate>
                            <ControlStyle Width="30px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                <table width="98%" cellpadding="2">
                    <tr id="tr3" align="right">
                        <td style="width: 200px;">
                        </td>
                        <td style="width: 400px" align="center">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                        </td>
                        <td style="width: 200px;">
                        </td>
                    </tr>
                </table>
            </center>
        </div>
    </center>
</asp:Content>
