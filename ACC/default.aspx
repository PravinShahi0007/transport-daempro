<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="ACC._default" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        var rowid = '';
        var ptop = '';
        function pageLoad() {
            $(document).ready(function () {
                $("#myMenu").hide();
                $("ul[id$='ContentPlaceHolder1_bllBank'] > li,ul[id$='ContentPlaceHolder1_bllCash'] > li,ul[id$='ContentPlaceHolder1_BllLoans'] > li,ul[id$='ContentPlaceHolder1_bllCustomers'] > li,ul[id$='ContentPlaceHolder1_BllVendors'] > li,ul[id$='ContentPlaceHolder1_bllVendors1'] > li,ul[id$='ContentPlaceHolder1_bllVendors2'] > li,ul[id$='ContentPlaceHolder1_bllVendors3'] > li").bind('contextmenu', function (e) {
                    $("#myMenu").hide();
                    e.preventDefault();
                    //rowid = $(this).children(':first-child').text();
                    rowid = $(this).attr("id");
                    ptop = e.pageY + "px";
                    $("#myState").attr("href", "WebStatement.aspx?FMode=0&AreaNo=" + $("#myArea").attr("value") + "&StoreNo=" + $("#myStore").attr("value") + "&Code=" + rowid);
                    if (!isNaN(rowid)) {
                        //call context menu here
                        $("#myMenu").css({
                            top: e.pageY + "px",
                            left: e.pageX + "px",
                            position: 'absolute'
                        });
                        $("#myMenu").show();
                    }
                });
                //                $("ul[id$='ContentPlaceHolder1_bllBank'] > li,ul[id$='ContentPlaceHolder1_bllCash'] > li,ul[id$='ContentPlaceHolder1_BllLoans'] > li,ul[id$='ContentPlaceHolder1_bllCustomers'] > li,ul[id$='ContentPlaceHolder1_BllVendors'] > li,ul[id$='ContentPlaceHolder1_bllVendors1'] > li,ul[id$='ContentPlaceHolder1_bllVendors2'] > li,ul[id$='ContentPlaceHolder1_bllVendors3'] > li").bind("click", function (e) {
                //                    $("#myMenu").hide();
                //                    e.preventDefault();
                //                    //rowid = $(this).children(':first-child').text();
                //                    rowid = $(this).attr("id");
                //                    ptop = e.pageY + "px";
                //                    $("#myState").attr("href", "WebStatement.aspx?FMode=0&AreaNo=" + $("#myArea").attr("value") + "&StoreNo=" + $("#myStore").attr("value") + "&Code=" + rowid);
                //                    if (!isNaN(rowid)) {
                //                        //call context menu here
                //                        $("#myMenu").css({
                //                            top: e.pageY + "px",
                //                            left: e.pageX + "px",
                //                            position: 'absolute'
                //                        });
                //                        $("#myMenu").show();
                //                    }
                //                });


                //hide when left mouse is clicked
                $(document).bind('click', function (e) {
                    $("#myMenu").hide();
                });

            });

            SetMyStyle();
        }
        function fnClose() {
            $("#ContentPlaceHolder1_Panel1").addClass('popupControl');
            $("#ContentPlaceHolder1_Panel1").removeClass('popupControl2');
        }
        function fnView() {
            $("#ContentPlaceHolder1_Panel1").html($("#" + rowid).attr("data-title"));
            $("#ContentPlaceHolder1_Panel1").removeClass('popupControl');
            $("#ContentPlaceHolder1_Panel1").addClass('popupControl2');
            $("#ContentPlaceHolder1_Panel1").css({ top: ptop });
        }
        function SetContextKey() {
            $find('<%=AutoCompleteExtender2.ClientID%>').set_contextKey($get("<%=ddlFType.ClientID %>").value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mdiv1" runat="server" class="Rounded4Corners div1" style="<%$ Resources: mDiv1 %>">
        <center>
            <b>
                <asp:Label ID="Label1" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ الفروع ]"
                    meta:resourcekey="Label1"></asp:Label></b></center>
        <asp:BulletedList ID="BulletedList1" Target="_blank" Width="95%" DisplayMode="HyperLink"
            CssClass="Bullet" runat="server">
        </asp:BulletedList>
    </div>
    <span id="span1" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
    <div id="mdiv2" runat="server" class="Rounded4Corners div2" style="<%$ Resources: mDiv1 %>">
        <center>
            <b>
                <asp:Label ID="Label5" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ فواتير معلقة ]" meta:resourcekey="Label5"></asp:Label></b></center>
        <asp:GridView ID="grdInv" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
            AllowPaging="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="False"  Font-Size="Smaller"
            DataKeyNames="InvNo,Area,Code" Width="90%" EmptyDataText="<%$ Resources:Resource, NoData %>" OnRowDeleting="grdInv_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblFNo" Text='<%# Bind("Name1") %>' NavigateUrl='<%# Bind("Name2") %>'
                            runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="150px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="<%$ Resources: DeleteItem %>"
                            ImageUrl="~/images/cross.png" OnClientClick='<%$ Resources: ConfirmDelete %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <span id="span2" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
    <div id="mdiv3" runat="server" class="Rounded4Corners div3" style="<%$ Resources: mDiv1 %>">
        <center>
            <b>
                <asp:Label ID="Label6" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ أرصدة الفرع ]" meta:resourcekey="Label6"></asp:Label></b>
            <table id="table1" runat="server" class="box-table-a123" width="98%" style="<%$ Resources: TableStyle %>">
                <tbody>
                    <tr>
                        <td style="width: 57%">
                            <strong>
                                <asp:Label ID="lblCashs" runat="server" Text="رصيد الصندوق" meta:resourcekey="lblCashs"></asp:Label></strong>
                        </td>
                        <td style="width: 43%">
                            <asp:Label ID="lblCash" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="lblLoans" runat="server" Text="رصيد العهدة" meta:resourcekey="lblLoans"></asp:Label></strong>
                        </td>
                        <td>
                            <asp:Label ID="lblLoan" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="lblIncomes" runat="server" Text="إيرادات الفرع" meta:resourcekey="lblIncomes"></asp:Label></strong>
                        </td>
                        <td>
                            <asp:Label ID="lblIncome" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="lblMonthIncomes" runat="server" Text="الايراد الشهري" meta:resourcekey="lblMonthIncomes"></asp:Label></strong>
                        </td>
                        <td>
                            <asp:Label ID="lblMonthIncome" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="lblDayIncomes" runat="server" Text="الايراد اليومي" meta:resourcekey="lblDayIncomes"></asp:Label></strong>
                        </td>
                        <td>
                            <asp:Label ID="lblDayIncome" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="lblSMS" runat="server" Text="رصيد الرسائل" meta:resourcekey="lblSMS"></asp:Label></strong>
                        </td>
                        <td>
                            <asp:Label ID="lblSMSBal" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </center>
    </div>
    <span id="span3" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
    <div id="DivHold" class="Rounded4Corners div4" style="width: 235px; height: 300px;
        float: right; border: thin solid #444444; overflow: hidden; overflow-x: hidden;
        overflow-y: auto;">
        <center>
            <b>
                <asp:Label ID="Label2" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ طلبات معلقة ]"
                    meta:resourcekey="Label2"></asp:Label></b></center>
        <div style="width: 100%; text-align: left">
            <table width="99%" cellpadding="0" cellspacing="0">
              <tr>
                    <td style="width: 50%" align="right">
                            <asp:DropDownList ID="ddlTypes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDays_SelectedIndexChanged">
                            </asp:DropDownList>
                    </td>
                    <td style="width: 50%" align="left">
                            <asp:DropDownList ID="ddlDays" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDays_SelectedIndexChanged">
                            </asp:DropDownList>
                    </td>
              </tr>
            </table>
        </div>
        <asp:BulletedList ID="bllPO" Target="_blank" Width="95%" DisplayMode="HyperLink"
            CssClass="Bullet" runat="server">
        </asp:BulletedList>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="Rounded4Corners div1" style="width: 915px; border: thin solid #800000;">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:RadioButtonList ID="RdoActive" runat="server" CellPadding="2" CellSpacing="2"
                        RepeatColumns="3" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="RdoActive_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="1" Text="<%$ Resources:Active1 %>"></asp:ListItem>
                        <asp:ListItem Value="2" Text="<%$ Resources:Active2 %>"></asp:ListItem>
                        <asp:ListItem Value="3" Text="<%$ Resources:Active3 %>"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label4" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ البحث ]"
                            meta:resourcekey="Label4"></asp:Label></b>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="فترة البحث" meta:resourcekey="Label13"></asp:Label>
                </td>
                <td colspan="4">
                    <asp:RadioButtonList ID="RdoPeriod" runat="server" CellPadding="2" CellSpacing="2"
                        RepeatColumns="9" Width="100%">
                        <asp:ListItem Selected="True" Value="7" Text="<%$ Resources:Period7 %>"></asp:ListItem>
                        <asp:ListItem Value="14" Text="<%$ Resources:Period14 %>"></asp:ListItem>
                        <asp:ListItem Value="21" Text="<%$ Resources:Period21 %>"></asp:ListItem>
                        <asp:ListItem Value="30" Text="<%$ Resources:Period30 %>"></asp:ListItem>
                        <asp:ListItem Value="60" Text="<%$ Resources:Period60 %>"></asp:ListItem>
                        <asp:ListItem Value="90" Text="<%$ Resources:Period90 %>"></asp:ListItem>
                        <asp:ListItem Value="180" Text="<%$ Resources:Period180 %>"></asp:ListItem>
                        <asp:ListItem Value="365" Text="<%$ Resources:Period365 %>"></asp:ListItem>
                        <asp:ListItem Value="0" Text="<%$ Resources:Period0 %>"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlFType" Width="120px" runat="server">
                        <asp:ListItem Selected="True" Value="0" Text="<%$ Resources:FType1 %>"></asp:ListItem>
                        <asp:ListItem Value="1" Text="<%$ Resources:FType2 %>"></asp:ListItem>
                        <asp:ListItem Value="2" Text="<%$ Resources:FType3 %>"></asp:ListItem>
                        <asp:ListItem Value="3" Text="<%$ Resources:FType4 %>"></asp:ListItem>
                        <asp:ListItem Value="4" Text="<%$ Resources:FType5 %>"></asp:ListItem>
                        <asp:ListItem Value="5" Text="<%$ Resources:FType6 %>"></asp:ListItem>
                        <asp:ListItem Value="6" Text="<%$ Resources:FType7 %>"></asp:ListItem>
                        <asp:ListItem Value="7" Text="<%$ Resources:FType8 %>"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtSearch" Width="150px" onkeyup="SetContextKey();" autocomplete="off"
                        runat="server"></asp:TextBox>
                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearch"
                        ServicePath="AutoComplete.asmx" ServiceMethod="GetSupportData" UseContextKey="true"
                        MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                        CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                    <asp:ImageButton ID="BtnSearch" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                        ToolTip="<%$ Resources:SearchCar %>" OnClick="BtnSearch_Click" />
                    <asp:ImageButton ID="BtnClear" runat="server" ValidationGroup="55" ImageUrl="~/images/erasure_24.png"
                        ToolTip="<%$ Resources:Clear %>" OnClick="BtnClear_Click" />
     
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 250px">
                    <asp:TextBox ID="txtSName" PlaceHolder="<%$ Resources:SearchEmpMobile %>" Width="250px" runat="server"></asp:TextBox>
                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSName"
                        ServicePath="AutoComplete.asmx" ServiceMethod="GetDrivers" MinimumPrefixLength="1"
                        CompletionInterval="500" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement"
                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                </td>
            </tr>
        </table>
        <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
            <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="False" DataKeyNames="TranDate" Width="99.9%" EmptyDataText="<%$ Resources:NoData %>">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:FDate %>" SortExpression="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTranDate" Text='<%# Bind("TranDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:DocNumber %>" SortExpression="DocNumber"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDocNumber" Text='<%# Bind("DocNumber") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:PlateNo %>" SortExpression="PlateNo"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:ChassisNo %>" SortExpression="ChassisNo"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblChassisNo" Text='<%# Bind("ChassisNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Area %>" SortExpression="Area" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblArea" Text='<%# Bind("Area") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Remark %>" SortExpression="Remark" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblRemark" Text='<%# Bind("Remark") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="200px" />
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
        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
    </div>
    <br />
    <a name="1"></a>
    <div id="ProcessDiv" runat="server">
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[<a target="_blank" href='<%= string.Format("WebTrackMoveIn.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'>&nbsp;<i
                    class="fa fa-tv"></i></a>
                    <asp:Literal ID="Literal90" Text="<%$ Resources:IncomeCars %>" runat="server"></asp:Literal>
                    ]</b></legend>
            <div style="width: 100%; text-align: left;">
                <asp:LinkButton ID="BtnRefresh" runat="server" ToolTip="<%$ Resources:CarRefresh %>"
                    OnClick="BtnRefresh_Click"><i class='fa fa-refresh' style="color:Blue;" ></i></asp:LinkButton></div>
            <asp:GridView ID="grdTrackMove" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="False" PageSize="200" DataKeyNames="FNo"
                Width="99.9%" OnRowCreated="grdTrackMove_RowCreated" OnRowDataBound="grdTrackMove_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:DriverName %>" SortExpression="Driver"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDriver" Text='<%# Bind("Driver") %>' data-placement="left" data-toggle="popover"
                                data-container="body" runat="server"></asp:Label>
                            <ajax:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel1"
                                TargetControlID="lblDriver" DynamicContextKey='<%# Eval("CarMoveNo") %>' DynamicControlID="Panel1"
                                DynamicServicePath="default.aspx" DynamicServiceMethod="GetDynamicContent" Position="Bottom">
                            </ajax:PopupControlExtender>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarNo %>" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCode" Text='<%# Eval("Code").ToString() + "<br/>" + Eval("PlateNo").ToString()  %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarMove %>" SortExpression="CarMoveNo"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMoveNo" Text='<%# Eval("CarMoveNo") %>' ToolTip="<%$ Resources:ViewCarMove %>"
                                NavigateUrl='<%# UrlHelper("1" ,Eval("CarMoveNo"))%>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FDate %>" SortExpression="CarMoveDate"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveDate" Text='<%# Bind("CarMoveDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FTime %>" SortExpression="CarMoveFTime"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveFTime" Text='<%# Bind("CarMoveFTime") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Dest %>" SortExpression="CarMoveFromLoc"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveFromLoc" Text='<%# Bind("CarMoveFromLoc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:RCVTime %>" SortExpression="RCVFTime"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblRCVFTime" Text='<%# Eval("RCVFTime") %>' ToolTip="<%$ Resources:IssueCarMoveRCV %>"
                                NavigateUrl='<%# UrlHelper("20" ,Eval("CarMoveNo"))%>' runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <%--  <asp:TemplateField HeaderText="الحالة" SortExpression="Status" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" Text='<%# Bind("Status") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="وقت الوصول المتوقع" SortExpression="RCVFTime2" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRCVFTime" Text='<%# Bind("RCVFTime2") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>s
                </asp:TemplateField>--%>
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
            <br />
        </fieldset>
        <br />
        <a name="2"></a>
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[<a target="_blank" href='<%= string.Format("WebTrackMoveHere.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'>&nbsp;<i
                    class="fa fa-tv"></i></a>
                    <asp:Literal ID="Literal1" Text="<%$ Resources:CarHere %>" runat="server"></asp:Literal>
                    ]</b></legend>
            <asp:GridView ID="grdTrackMove2" CellPadding="4" AutoGenerateColumns="False" runat="server"
                ForeColor="#333333" GridLines="None" PageSize="200" DataKeyNames="FNo" Width="99.9%" OnRowDataBound="grdTrackMove2_RowDataBound"
                OnRowCreated="grdTrackMove2_RowCreated">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFNo2" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:DriverName %>" SortExpression="Driver"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDriver2" Text='<%# Bind("Driver") %>' data-placement="left" data-toggle="popover1"
                                data-container="body" runat="server"></asp:Label>
                            <ajax:PopupControlExtender ID="PopupControlExtender2" runat="server" PopupControlID="Panel2"
                                TargetControlID="lblDriver2" DynamicContextKey='<%# Eval("CarMoveNo") %>' DynamicControlID="Panel2"
                                DynamicServicePath="default.aspx" DynamicServiceMethod="GetDynamicContent" Position="Bottom">
                            </ajax:PopupControlExtender>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarNo %>" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCode2" Text='<%# Eval("Code").ToString() + "<br/>" + Eval("PlateNo").ToString() %>'
                                ToolTip="<%$ Resources:MakeIssueNote %>" NavigateUrl='<%# UrlHelper("21" ,Eval("CarMoveNo"))%>'
                                Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarMove %>" SortExpression="CarMoveNo"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMoveNo2" Text='<%# Eval("CarMoveNo") %>' ToolTip="<%$ Resources:ViewCarMove %>"
                                NavigateUrl='<%# UrlHelper("1" ,Eval("CarMoveNo"))%>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FDate %>" SortExpression="CarMoveFTime2"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveDate2" Text='<%# Bind("CarMoveFTime2") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Dest %>" SortExpression="CarMoveFromLoc"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveFromLoc2" Text='<%# Bind("CarMoveFromLoc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:RCVDest %>" SortExpression="CarMoveToLoc"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveToLoc" Text='<%# Bind("CarMoveToLoc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarMoveRCV %>" SortExpression="CarMoveRCVNo"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMoveRCVNo" Text='<%# Eval("CarMoveRCVNo") %>' ToolTip="<%$ Resources:ViewCarMoveRCV %>"
                                NavigateUrl='<%# UrlHelper("2" ,Eval("CarMoveRCVNo"))%>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FDate %>" SortExpression="CarMoveRCVFTime2"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveRCVFTime2" Text='<%# Bind("CarMoveRCVFTime2") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <%--  <asp:TemplateField HeaderText="الحالة" SortExpression="Status" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" Text='<%# Bind("Status") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="وقت الوصول المتوقع" SortExpression="RCVFTime2" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRCVFTime" Text='<%# Bind("RCVFTime2") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>--%>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center"
                    Font-Bold="True" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:Panel ID="Panel2" runat="server" CssClass="popupControl">
            </asp:Panel>
        </fieldset>
        <br />
        <a name="3"></a>
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[<a target="_blank" href='<%= string.Format("WebTrackMoveOut.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'>&nbsp;<i
                    class="fa fa-tv"></i></a> <asp:Literal ID="Literal2" Text="<%$ Resources:CarLeaveBranch %>" runat="server"></asp:Literal> ]</b></legend>
            <asp:GridView ID="grdTrackMove1" CellPadding="4" AutoGenerateColumns="False" runat="server"
                ForeColor="#333333" GridLines="None" PageSize="200" DataKeyNames="FNo" Width="99.9%"
                OnRowCreated="grdTrackMove1_RowCreated" OnRowDataBound="grdTrackMove1_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFNo1" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:DriverName %>" SortExpression="Driver" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDriver1" Text='<%# Bind("Driver") %>' data-placement="left" data-toggle="popover"
                                data-container="body" runat="server"></asp:Label>
                            <ajax:PopupControlExtender ID="PopupControlExtender3" runat="server" PopupControlID="Panel3"
                                TargetControlID="lblDriver1" DynamicContextKey='<%# Eval("CarMoveNo") %>' DynamicControlID="Panel3"
                                DynamicServicePath="default.aspx" DynamicServiceMethod="GetDynamicContent" Position="Bottom">
                            </ajax:PopupControlExtender>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarNo %>" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCode1" Text='<%# Eval("Code").ToString() + "<br/>" + Eval("PlateNo").ToString() %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarMove %>" SortExpression="CarMoveNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMoveNo1" Text='<%# Eval("CarMoveNo") %>' ToolTip="<%$ Resources:ViewCarMove %>"
                                NavigateUrl='<%# UrlHelper("1" ,Eval("CarMoveNo"))%>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FDate %>" SortExpression="CarMoveDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveDate1" Text='<%# Bind("CarMoveDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FTime %>" SortExpression="CarMoveFTime" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveFTime1" Text='<%# Bind("CarMoveFTime") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Dest %>" SortExpression="CarMoveFromLoc" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveFromLoc1" Text='<%# Bind("CarMoveFromLoc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:RCVDest %>" SortExpression="CarMoveToLoc" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveTOLoc1" Text='<%# Bind("CarMoveToLoc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center"
                    Font-Bold="True" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:Panel ID="Panel3" runat="server" CssClass="popupControl">
            </asp:Panel>
        </fieldset>
        <br />
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ <asp:Literal ID="Literal3" Text="<%$ Resources:CarToWorkshop %>" runat="server"></asp:Literal> ]</b></legend>
            <div style="width: 100%; text-align: left;">
                <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="<%$ Resources:CarRefresh %>"
                    OnClick="BtnRefresh_Click"><i class='fa fa-refresh' style="color:Blue;" ></i></asp:LinkButton></div>
            <asp:GridView ID="grdWSTrackMove" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="False" PageSize="200" DataKeyNames="FNo"
                Width="99.9%" OnRowCreated="grdWSTrackMove_RowCreated">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:DriverName %>" SortExpression="DriverName1"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDriver" Text='<%# Bind("DriverName1") %>' data-placement="left"
                                data-toggle="popover" data-container="body" runat="server"></asp:Label>
                            <ajax:PopupControlExtender ID="PopupControlExtender100" runat="server" PopupControlID="Panel1"
                                TargetControlID="lblDriver" DynamicContextKey='<%# Eval("CarMove") %>' DynamicControlID="Panel1"
                                DynamicServicePath="default.aspx" DynamicServiceMethod="GetDynamicContent" Position="Bottom">
                            </ajax:PopupControlExtender>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarNo %>" SortExpression="Vehicle" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCode" Text='<%# Eval("Vehicle").ToString() + "<br/>" + Eval("PlateNo").ToString()  %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:RepairReqNo %>" SortExpression="VouNo"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblRepairReqNo" Text='<%# Eval("VouNo2") %>' ToolTip="<%$ Resources:ViewRepairReq %>"
                                NavigateUrl='<%# UrlHelper("8" ,Eval("VouNo2"))%>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FDate %>" SortExpression="VouDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblVouDate" Text='<%# Bind("VouDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FTime %>" SortExpression="InTime" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCarMoveFTime" Text='<%# Bind("InTime") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarMove %>" SortExpression="CarMove"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMoveNo" Text='<%# Eval("CarMove") %>' ToolTip="<%$ Resources:ViewCarMove %>"
                                NavigateUrl='<%# UrlHelper("1" ,Eval("CarMove"))%>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Dest %>" SortExpression="SiteName1"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMoveFromLoc" Text='<%# Eval("SiteName1") %>' ToolTip="<%$ Resources:OpenJobWork %>"
                                NavigateUrl='<%# UrlHelper("90" ,Eval("VouNo2"))%>' Target="_blank" runat="server"></asp:HyperLink>
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
        </fieldset>
        <br />
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ <asp:Literal ID="Literal4" Text="<%$ Resources:CarInWorkShop %>" runat="server"></asp:Literal> ]</b></legend>
            <div style="width: 100%; text-align: left;">
                <asp:LinkButton ID="LinkButton2" runat="server" ToolTip="<%$ Resources:CarRefresh %>"
                    OnClick="BtnRefresh_Click"><i class='fa fa-refresh' style="color:Blue;" ></i></asp:LinkButton></div>
            <asp:GridView ID="grdWSInTrackMove" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                AutoGenerateColumns="False" PageSize="200" DataKeyNames="FNo" Width="99.9%" OnRowCreated="grdWSInTrackMove_RowCreated">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:DriverName %>" SortExpression="DriverName1"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDriver" Text='<%# Bind("DriverName1") %>' data-placement="left"
                                data-toggle="popover" data-container="body" runat="server"></asp:Label>
                            <ajax:PopupControlExtender ID="PopupControlExtender101" runat="server" PopupControlID="Panel1"
                                TargetControlID="lblDriver" DynamicContextKey='<%# Eval("CarMove") %>' DynamicControlID="Panel1"
                                DynamicServicePath="default.aspx" DynamicServiceMethod="GetDynamicContent" Position="Bottom">
                            </ajax:PopupControlExtender>
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarNo %>" SortExpression="Vehicle" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCode" Text='<%# Eval("Vehicle").ToString() + "<br/>" + Eval("PlateNo").ToString()  %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:RepairReqNo %>" SortExpression="VouNo2"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblRepairReqNo" Text='<%# Eval("VouNo2") %>' ToolTip="<%$ Resources:ViewRepairReq %>"
                                NavigateUrl='<%# UrlHelper("8" ,Eval("VouNo2"))%>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="<%$ Resources:JobWorkNo %>" SortExpression="JobWorkVouNo2"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblJobWorkNo" Text='<%# Eval("JobWorkVouNo2") %>' ToolTip="<%$ Resources:ViewJobWork %>"
                                NavigateUrl='<%# UrlHelper("9" ,Eval("JobWorkVouNo2"))%>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FDate %>" SortExpression="JobWorkVouDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblJobWorkVouDate" Text='<%# Bind("JobWorkVouDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FTime %>" SortExpression="JobWorkVouTime" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblJobWorkVouTime" Text='<%# Bind("JobWorkVouTime") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:CarMove %>" SortExpression="CarMove"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarMoveNo" Text='<%# Eval("CarMove") %>' ToolTip="<%$ Resources:ViewCarMove %>"
                                NavigateUrl='<%# UrlHelper("1" ,Eval("CarMove"))%>' Target="_blank" runat="server"></asp:HyperLink>
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
        </fieldset>
        <br />
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ <asp:Literal ID="Literal5" Text="<%$ Resources:CarLeaveWorkShop %>" runat="server"></asp:Literal> ]</b></legend>
            <div style="width: 100%; text-align: left;">
                <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="<%$ Resources:CarRefresh %>"
                    OnClick="BtnRefresh_Click"><i class='fa fa-refresh' style="color:Blue;" ></i></asp:LinkButton></div>
        </fieldset>
        <br />
        <a name="4"></a>
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ <asp:Literal ID="Literal6" Text="<%$ Resources:CarsInStore %>" runat="server"></asp:Literal> ]</b></legend>
            <div style="width: 100%; text-align: left;">
                <asp:LinkButton ID="BtnRefresh1" runat="server" ToolTip="<%$ Resources:CarRefresh %>"
                    OnClick="BtnRefresh1_Click"><i class='fa fa-refresh' style="color:Blue;" ></i></asp:LinkButton></div>
            <table>
                <tr>
                    <td style="width: 90px">
                        <asp:Label ID="Label3" runat="server" Text="الفرع" meta:resourcekey="Label3"></asp:Label>
                    </td>
                    <td style="width: 150px">
                        <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="grdOverCarMove" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="False" DataKeyNames="VouNo" Width="99.9%"
                EmptyDataText="<%$ Resources:NoData %>">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="" Visible="false" HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkStatus" runat="server" Checked='<%# Bind("Status") %>' ToolTip="<%$ Resources:SelectInvoiceOnOff %>" />
                        </ItemTemplate>
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFNo1" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FType4 %>" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblVouNo" Text='<%# Eval("Flag").ToString()+int.Parse(Eval("InvoiceVouLoc").ToString()).ToString() + "/" + Eval("VouNo") %>'
                                NavigateUrl='<%# UrlHelper(3,Eval("Flag").ToString()+Eval("InvoiceVouLoc").ToString()+"/"+Eval("VouNo").ToString())%>'
                                ToolTip="<%$ Resources:ViewInvoice %>" Target="_blank" runat="server"></asp:HyperLink>                                
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:FDate %>" SortExpression="GDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblGDate" Text='<%# Bind("GDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="<%$ Resources:PlateNo %>" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Taraz %>" SortExpression="Model" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblModel" Text='<%# Bind("Model") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:SenderRCV %>" SortExpression="RecName"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                            <asp:Label ID="lblRecName" Text='<%# Bind("RecName") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="200px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Dest %>" SortExpression="DestinationName1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDestinationName" Text='<%# Bind("DestinationName1") %>' runat="server"></asp:Label>
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
        </fieldset>
        <br />
        <a name="5"></a>
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ <asp:Literal ID="Literal7" Text="<%$ Resources:TripList %>" runat="server"></asp:Literal> ]</b></legend>
            <table width="99.5%">
                <tr>
                    <td style="width: 270px">
                        <asp:UpdatePanel ID="chidlup" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdOverTrip" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" Width="99.9%"
                                    EmptyDataText="<%$ Resources:NoData %>">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkStatus" runat="server" AutoPostBack="true" Checked='<%# Bind("Status") %>'
                                                    ToolTip="<%$ Resources:TripSetting %>" OnCheckedChanged="ChkStatus_CheckedChanged" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:TripNo %>" SortExpression="FNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lblFNo1" Text='<%# Bind("FNo") %>' NavigateUrl='<%# UrlHelper(4,Eval("Destination").ToString())%>'
                                                    ToolTip="<%$ Resources:IssueCarMove %>" runat="server"></asp:HyperLink>
                                            </ItemTemplate>
                                            <ControlStyle Width="75px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:TripDist %>" SortExpression="DestinationName1" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDestinationName" Text='<%# Bind("DestinationName1") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="125px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:TripWeight %>" SortExpression="Model" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblModel" Text='<%# Bind("Model") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="50px" />
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 550px">
                        <asp:Chart ID="Chart1" runat="server" Width="550px" Height="450px" Palette="SeaGreen">
                            <%--                        <Titles>
                            <asp:Title Font="Arial, 16pt, style=Bold" Name="Title1"  ForeColor="Blue"
                                Text="عدد السيارات حسب جهة الترحيل">
                            </asp:Title>
                        </Titles>
                            --%>
                            <Series>
                                <asp:Series Name="Categories" Palette="Pastel" ChartArea="MainChartArea" Label="#VALY  #VALX"
                                    Color="Red" LabelForeColor="Black" IsValueShownAsLabel="true" ChartType="Pie"
                                    Font="Microsoft Sans Serif, 9.75pt">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="MainChartArea">
                                    <Area3DStyle Enable3D="True"></Area3DStyle>
                                    <AxisX Interval="1">
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <a name="6"></a>
    </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="popupControl">
    </asp:Panel>
    <a name="7"></a>
    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
        border: solid 2px #800000">
        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
            <b>[ <asp:Literal ID="Literal8" Text="<%$ Resources:TruckAlerts %>" runat="server"></asp:Literal> ]</b></legend>
        <asp:GridView ID="grdCarAlert" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            AutoGenerateColumns="False" DataKeyNames="Code" Width="99.9%" EmptyDataText="<%$ Resources:NoData %>"
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="WorkShopCode" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNo" Text='<%# Bind("WorkShopCode") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="40px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TruckNo %>" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblCarNo" Text='<%# Eval("Code") %>' NavigateUrl='<%# UrlHelper("110" ,Eval("Code"))%>'
                            ToolTip='<%# Bind("PLoc") %>' Target="_blank" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:PlateNo %>" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="85px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarDoc %>" SortExpression="strDate1" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate1" Text='<%# Bind("strDate1") %>' ToolTip='<%# Bind("PLoc1") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarIns %>" SortExpression="strDate2" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate2" Text='<%# Bind("strDate2") %>' ToolTip='<%# Bind("PLoc2") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarOp %>" SortExpression="strDate3" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate3" Text='<%# Bind("strDate3") %>' ToolTip='<%# Bind("PLoc3") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarInspec %>" SortExpression="strDate4" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate4" Text='<%# Bind("strDate4") %>' ToolTip='<%# Bind("PLoc4") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarWIns %>" SortExpression="strDate5" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate5" Text='<%# Bind("strDate5") %>' ToolTip='<%# Bind("PLoc5") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" VerticalAlign="Middle" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </fieldset>
    <br />
    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
        border: solid 2px #800000">
        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
            <b>[ <asp:Literal ID="Literal9" Text="<%$ Resources:CarAlerts %>" runat="server"></asp:Literal>]</b></legend>
        <asp:GridView ID="grdCarAlert2" runat="server" CellPadding="4" ForeColor="Black"
            GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Code" Width="99.9%"
            EmptyDataText="<%$ Resources:NoData %>" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="WorkShopCode" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNo" Text='<%# Bind("WorkShopCode") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="40px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TruckNo %>" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblCarNo" Text='<%# Eval("Code") %>' NavigateUrl='<%# UrlHelper("110" ,Eval("Code"))%>'
                            ToolTip="<%$ Resources:ViewCar %>" Target="_blank" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:PlateNo %>" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarDoc %>" SortExpression="strDate1" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate1" Text='<%# Bind("strDate1") %>' ToolTip='<%# Bind("PLoc1") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarIns %>" SortExpression="strDate2" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate2" Text='<%# Bind("strDate2") %>' ToolTip='<%# Bind("PLoc2") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarInspec %>" SortExpression="strDate4" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate4" Text='<%# Bind("strDate4") %>' ToolTip='<%# Bind("PLoc4") %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:CarLoc %>" SortExpression="PLoc" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPLoc" Text='<%# Bind("PLoc") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" VerticalAlign="Middle" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </fieldset>
    <br />
    <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
        border: solid 2px #800000" runat="server" id="divPaperAlert" >
        <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
            <b>[ <asp:Literal ID="Literal10" Text="<%$ Resources:EmpDoc %>" runat="server"></asp:Literal> ]</b></legend>
        <asp:GridView ID="grdPaperAlert" runat="server" CellPadding="4" ForeColor="Black"
            GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Code" Width="99.9%"
            EmptyDataText="<%$ Resources:NoData %>" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:SNo %>" SortExpression="InvNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNo" Text='<%# Bind("InvNo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="40px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TruckNo %>" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblCarNo" Text='<%# Eval("Code") %>' NavigateUrl='<%# UrlHelper("222" ,Eval("Code"))%>'
                            ToolTip="<%$ Resources:ViewEmp %>" Target="_blank" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:EmpName %>" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPlateNo" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="200px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:EmpID %>" SortExpression="SiteAcc" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate1" Text='<%# Bind("SiteAcc") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:EmpPass %>" SortExpression="TripAcc" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblstrDate2" Text='<%# Bind("TripAcc") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="125px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" VerticalAlign="Middle" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </fieldset>
    <br />
    <div runat="server" id="DivAccBal">
        <div id="DivBanks" runat="server" class="Rounded4Corners div1" style="<%$ Resources: mDiv1 %>">
            <center>
                <b>
                    <asp:Label ID="LblBanks" ForeColor="#800000" Font-Underline="true" runat="server"
                        Text="[ البنوك ]" meta:resourcekey="LblBanks"></asp:Label></b></center>
            <asp:BulletedList ID="bllBank" Target="_blank" Width="99%" DisplayMode="Text" CssClass="Bullet"
                runat="server">
            </asp:BulletedList>
        </div>
        <span id="span4" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
        <div id="Div2" runat="server" class="Rounded4Corners div2" style="<%$ Resources: mDiv1 %>">
            <center>
                <b>
                    <asp:Label ID="Label8" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ النقدية ]" meta:resourcekey="Label8"></asp:Label></b></center>
            <asp:BulletedList ID="bllCash" Target="_blank" Width="95%" DisplayMode="Text" CssClass="Bullet"
                runat="server">
            </asp:BulletedList>
        </div>
        <span id="span5" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
        <div id="Div3" runat="server" class="Rounded4Corners div3" style="<%$ Resources: mDiv1 %>">
            <center>
                <b>
                    <asp:Label ID="Label9" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ العهد ]" meta:resourcekey="Label9"></asp:Label></b>
            </center>
            <asp:BulletedList ID="BllLoans" Target="_blank" Width="95%" DisplayMode="Text" CssClass="Bullet"
                runat="server">
            </asp:BulletedList>
        </div>
        <span id="span6" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
        <div id="Div4" class="Rounded4Corners div4" style="width: 235px; height: 300px; float: right;
            border: thin solid #444444; overflow: hidden; overflow-x: hidden; overflow-y: auto;">
            <center>
                <b>
                    <asp:Label ID="Label22" ForeColor="#800000" Font-Underline="true" runat="server"
                        Text="[ العملاء ]" meta:resourcekey="Label22"></asp:Label></b></center>
            <asp:BulletedList ID="bllCustomers" Target="_blank" Width="87%" DisplayMode="Text"
                CssClass="Bullet" runat="server">
            </asp:BulletedList>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div id="DivVendors" runat="server" class="Rounded4Corners div1" style="<%$ Resources: mDiv1 %>">
            <center>
                <b>
                    <asp:Label ID="Label7" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ الموردين ]" meta:resourcekey="Label7"></asp:Label></b></center>
            <asp:BulletedList ID="BllVendors" Target="_blank" Width="90%" DisplayMode="Text"
                CssClass="Bullet" runat="server">
            </asp:BulletedList>
        </div>
        <span id="span7" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
        <div id="DivVendors1" runat="server" class="Rounded4Corners div2" style="<%$ Resources: mDiv1 %>">
            <center>
                <b>
                    <asp:Label ID="Label10" ForeColor="#800000" Font-Underline="true" runat="server"
                        Text="[ تأمينات مستحقة ]" meta:resourcekey="Label10"></asp:Label></b></center>
            <asp:BulletedList ID="bllVendors1" Target="_blank" Width="99%" DisplayMode="HyperLink"
                CssClass="Bullet" runat="server">
            </asp:BulletedList>
        </div>
        <span id="span8" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
        <div id="DivVendors2" runat="server" class="Rounded4Corners div3" style="<%$ Resources: mDiv1 %>">
            <center>
                <b>
                    <asp:Label ID="Label11" ForeColor="#800000" Font-Underline="true" runat="server"
                        Text="[  ايجارات مستحقة  ]" meta:resourcekey="Label11"></asp:Label></b></center>
            <asp:BulletedList ID="bllVendors2" Target="_blank" Width="99%" DisplayMode="Text"
                CssClass="Bullet" runat="server">
            </asp:BulletedList>
        </div>
        <span id="span9" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
        <div id="DivVendors3" runat="server" class="Rounded4Corners div4" style="width: 235px;
            height: 300px; float: right; border: thin solid #444444; overflow: hidden; overflow-x: hidden;
            overflow-y: auto;">
            <center>
                <b>
                    <asp:Label ID="Label12" ForeColor="#800000" Font-Underline="true" runat="server"
                        Text="[ أقساط مستحقة ]" meta:resourcekey="Label12"></asp:Label></b></center>
            <asp:BulletedList ID="bllVendors3" Target="_blank" Width="99%" DisplayMode="Text"
                CssClass="Bullet" runat="server">
            </asp:BulletedList>
        </div>         
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <%-- <div runat="server" id="Div6">
       <div id="Div1" runat="server" class="Rounded4Corners div1" style="width: 440px; height: 300px;
            float: right; border: thin solid #444444; overflow: hidden; overflow-x: hidden;
            overflow-y: auto;">
            <center>
                <b>
                    <asp:Label ID="lblCars" ForeColor="#800000" Font-Underline="true" runat="server"
                        Text="[ حالة الشاحنات و السائقين ]"></asp:Label></b></center>
            <asp:BulletedList ID="bllDrivers" Target="_blank" Width="90%" DisplayMode="Text"
                CssClass="Bullet" runat="server">
            </asp:BulletedList>
        </div>
        <span id="span10" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
        <br />
    </div>--%>
    <div style="width: 100%;">
        <table width="100%" cellpadding="2" cellspacing="2">
            <tr>
                <td align="right">
                    <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                    <asp:Timer ID="Timer1" Interval="20000" runat="server" Enabled="False" OnTick="Timer1_Tick">
                    </asp:Timer>
                </td>
                <td align="left">
                    <asp:CheckBox ID="ChkAutoUpdate" Text="تحديث تلقائي" runat="server" AutoPostBack="True" meta:resourcekey="ChkAutoUpdate"
                        OnCheckedChanged="ChkAutoUpdate_CheckedChanged" />
                </td>
            </tr>
        </table>
    </div>
    <div id="DivInfo" runat="server" class="Rounded4Corners div1" style="<%$ Resources: mDivInfo %>">
        <center>
            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th colspan="3" align="center">
                            <asp:Literal ID="Literal11" Text="<%$ Resources:BankAccounts %>" runat="server"></asp:Literal>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Literal ID="Literal12" Text="<%$ Resources:Bank %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal13" Text="<%$ Resources:AccountNo %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal14" Text="<%$ Resources:IBAN %>" runat="server"></asp:Literal>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(1)%>
                </tbody>
            </table>
                 <div id="myMenu" class="contextMenu"  >
        <table style='width: 100%;'>
            <tr>
                <td onclick="fnView();">
                    <asp:Literal ID="Literal15" Text="<%$ Resources:Last20 %>" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <a id="myState" href="WebStatement.aspx" target="_blank"><asp:Literal ID="Literal16" Text="<%$ Resources:AccountStatement %>" runat="server"></asp:Literal></a>
                </td>
            </tr>
        </table>
    </div>

            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th>
                            <asp:Literal ID="Literal17" Text="<%$ Resources:ManagementAccounts %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal18" Text="<%$ Resources:Section %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal19" Text="<%$ Resources:Bank %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal20" Text="<%$ Resources:AccountNo %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal21" Text="<%$ Resources:IBAN %>" runat="server"></asp:Literal>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(2)%>
                </tbody>
            </table>
            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th>
                            <asp:Literal ID="Literal22" Text="<%$ Resources:BranchManagerAccounts %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal23" Text="<%$ Resources:Branch %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal24" Text="<%$ Resources:Bank %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal25" Text="<%$ Resources:AccountNo %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal26" Text="<%$ Resources:IBAN %>" runat="server"></asp:Literal>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(3)%>
                </tbody>
            </table>
            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th>
                            <asp:Literal ID="Literal27" Text="<%$ Resources:VendorAccount %>" runat="server"></asp:Literal>                            
                        </th>
                        <th>
                            <asp:Literal ID="Literal28" Text="<%$ Resources:Bank %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal29" Text="<%$ Resources:AccountNo %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal30" Text="<%$ Resources:IBAN %>" runat="server"></asp:Literal>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(4)%>
                </tbody>
            </table>
            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th>
                            <asp:Literal ID="Literal31" Text="<%$ Resources:Job %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal32" Text="<%$ Resources:Name %>" runat="server"></asp:Literal>
                       </th>
                        <th>
                            <asp:Literal ID="Literal33" Text="<%$ Resources:MobileNo %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal34" Text="<%$ Resources:TelNo %>" runat="server"></asp:Literal>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(5)%>
                </tbody>
            </table>
        </center>
    </div>      
    &nbsp;
    <br />
    <br />
</asp:Content>