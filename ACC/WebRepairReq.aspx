<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebRepairReq.aspx.cs" Inherits="ACC.WebRepairReq" Culture="en-GB"
    UICulture="en-GB" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Plate_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCarNo');
            //var ace2Value = $get('ContentPlaceHolder1_txtPlateNo');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            //ace2Value.value = x[1];
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend id="leg1" runat="server" align="<%$ Resources:Resource, dir2 %>" style="font-size: 18px; color: #800000; text-align: center;">
                    <b><asp:Literal ID="Literal2" Text="[ Repair Request ]" meta:resourcekey="Literal2" runat="server"></asp:Literal></b></legend>
                <table width="99%" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label1" runat="server" Text="Request No." meta:resourcekey="Label1"></asp:Label>
                            *
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                            <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                ToolTip="<%$ Resources:SearchReq %>" OnClick="BtnFind_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                Display="Dynamic" ErrorMessage="<%$ Resources:EnterReq %>" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 15%;">
                        </td>
                        <td style="width: 35%;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label6" runat="server" Text="From" meta:resourcekey="Label6"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlFrom2" Width="250" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddlFrom2"
                                InitialValue="-1" Display="Dynamic" ErrorMessage="<%$ Resources:SelectFrom %>" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label2" runat="server" Text="Date/Time" meta:resourcekey="Label2"></asp:Label>
                            *
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                Display="Dynamic" ErrorMessage="<%$ Resources:SelectReqDate %>" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="<%$ Resources:ReqDate %>"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />
                            <asp:TextBox ID="txtInTime" runat="server" Text="00:00" MaxLength="5" Width="60px" ReadOnly="true" ></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtInTime"
                                Mask="99:99" MaskType="Time" CultureName="en-us" MessageValidatorTip="true"
                                runat="server">
                            </ajaxToolkit:MaskedEditExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInTime"
                                Display="Dynamic" ErrorMessage="<%$ Resources:EnterTime %>" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="LblCode" runat="server" Text="Vehicle Type" meta:resourcekey="LblCode"></asp:Label>*
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlVehType" Width="250" runat="server" 
                                AutoPostBack="True" onselectedindexchanged="ddlVehType_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlVehType"
                                InitialValue="-1" Display="Dynamic" ErrorMessage="<%$ Resources:SelectVehicle %>" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label10" runat="server" Text="Vehicle/No." meta:resourcekey="Label10"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlVehicle" Width="230" runat="server" 
                                AutoPostBack="True" onselectedindexchanged="ddlVehicle_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlVehicle"
                                InitialValue="-1" Display="Dynamic" ErrorMessage="<%$ Resources:SelectVeh %>" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtCarNo" MaxLength="15" Width="35px" runat="server" 
                                autocomplete="off" AutoPostBack="True" ontextchanged="txtCarNo_TextChanged"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender03" runat="server" TargetControlID="txtCarNo"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars20" OnClientItemSelected="Plate_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />             
                            <asp:ImageButton ID="BtnFind2" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                ToolTip="<%$ Resources:SearchVeh %>" onclick="BtnFind2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label3" runat="server" Text="Model" meta:resourcekey="Label3"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtModel" MaxLength="20" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label4" runat="server" Text="KMS" meta:resourcekey="Label4"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtKMS" MaxLength="20" runat="server"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtKMS"
                                 Display="Dynamic" ErrorMessage="<%$ Resources:IntegerVal %>"
                                ForeColor="Red" Type="Integer" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label5" runat="server" Text="Driver Name" meta:resourcekey="Label5"></asp:Label>*
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlDriver" Width="250" runat="server">
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="ValDriver" runat="server" ControlToValidate="ddlDriver"
                                InitialValue="-1" Display="Dynamic" ErrorMessage="<%$ Resources:SelectDriver %>" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label7" runat="server" Text="Repair Required" meta:resourcekey="Label7"></asp:Label>
                        </td>
                        <td style="width: 35%;" rowspan="2">
                            <asp:CheckBoxList ID="ChkRequire" runat="server">
                                <asp:ListItem Value="0" Text = "<%$ Resources:Req0 %>"></asp:ListItem>
                                <asp:ListItem Value="1" Text = "<%$ Resources:Req1 %>"></asp:ListItem>
                                <asp:ListItem Value="2" Text = "<%$ Resources:Req2 %>"></asp:ListItem>
                                <asp:ListItem Value="3" Text = "<%$ Resources:Req3 %>"></asp:ListItem>
                                <asp:ListItem Value="4" Text = "<%$ Resources:Req4 %>"></asp:ListItem>
                                <asp:ListItem Value="5" Text = "<%$ Resources:Req5 %>"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label8" runat="server" Text="Remark" meta:resourcekey="Label8"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtRemark" MaxLength="100" Width="250px" runat="server"></asp:TextBox>
<%--                            <asp:TextBox ID="txtDateOut" Visible="false" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" Enabled="false" runat="server" ControlToValidate="txtDateOut"
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="Request Date Should be Date Value"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                TargetControlID="txtDateOut" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />
                            <asp:TextBox ID="txtTimeOut" runat="server" Text="00:00:01" MaxLength="8" Width="60px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="txtTimeOut"
                                Mask="99:99:99" MaskType="Time" CultureName="en-us" MessageValidatorTip="true"
                                runat="server">
                            </ajaxToolkit:MaskedEditExtender> --%>                       
                        </td>
                        <td style="width: 15%;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label9" runat="server" Text="Load No." meta:resourcekey="Label9"></asp:Label>*
                        </td>
                        <td style="width: 35%;">
                            <asp:Label ID="lblStatus" runat="server"  CssClass="blink" Text=""></asp:Label>
                        </td>                        
                        <td style="width: 15%;">
                            <asp:Label ID="Label35" runat="server" Text="Others" meta:resourcekey="Label35"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtRequire" MaxLength="50" Width="250px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label14" runat="server" Text="User Name" meta:resourcekey="Label14"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                        <asp:TextBox ID="txtUserName" Width="300px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                            Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                        <asp:Label ID="Label15" runat="server" Text="Date" meta:resourcekey="Label15"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                        <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                            Enabled="false">                                                               
                        </asp:TextBox>
                        <asp:Label ID="Label27" runat="server" Text="* Required Fields" meta:resourcekey="Label27"></asp:Label>
                        </td>
                    </tr>

                </table>
            </fieldset>
            <table id="Table2" width="100%" cellpadding="0" cellspacing="0">              
                <tr align="center">
                    <td colspan="4">
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4" style="width: 100%;">
                        <asp:ImageButton ID="BtnNew" runat="server" AlternateText="<%$ Resources:New %>" CommandName="New"
                            ImageUrl="<%$ Resources:NewImage %>" CssClass="ops" ToolTip="<%$ Resources:NewTooltip %>"
                            ValidationGroup="1" OnClientClick='<%$ Resources:NewConfirm %>'
                            OnClick="BtnNew_Click" />
                        <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="<%$ Resources:Edit %>" CommandName="Edit"
                            ImageUrl="<%$ Resources:EditImage %>" CssClass="ops" ToolTip="<%$ Resources:EditTooltip %>"
                            Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                        <asp:ImageButton ID="BtnClear" runat="server" AlternateText="<%$ Resources:Clear %>" CommandName="Clear"
                            ImageUrl="<%$ Resources:ClearImage %>" CssClass="ops" ToolTip="<%$ Resources:ClearTooltip %>"
                            OnClick="BtnClear_Click" />
                        <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="<%$ Resources:Delete %>" CommandName="Delete"
                            ImageUrl="<%$ Resources:DeleteImage %>" CssClass="ops" ToolTip="<%$ Resources:DeleteTooltip %>"
                            OnClientClick='<%$ Resources:DeleteConfirm %>'
                            OnClick="BtnDelete_Click" />
                        <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="<%$ Resources:Search %>" CommandName="Find"
                            ImageUrl="<%$ Resources:SearchImage %>" CssClass="ops" ToolTip="<%$ Resources:SearchTooltip %>"
                            OnClick="BtnSearch_Click" />
                        <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="<%$ Resources:Print %>" CommandName="Print"
                            ImageUrl="<%$ Resources:PrintImage %>" ValidationGroup="1" CssClass="ops" ToolTip="<%$ Resources:PrintTooltip %>"
                            />
                    </td>
                </tr>
            </table>
            <div style="text-align: right; width: 50%;">
                <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                    Direction="LeftToRight" ForeColor="#FFFF99">
                    <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left;">
                            Attach Files</div>
                        <div style="float: left; margin-right: 20px;">
                            <asp:Label ID="Label34" runat="server" Text="(Show Details...)" meta:resourcekey="Label34"></asp:Label>
                        </div>
                        <div style="float: right; vertical-align: middle;">
                            <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="<%$ Resources:ShowDetails %>" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                    BorderColor="Maroon">
                    <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                        ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                        Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="<%$ Resources:DeleteFile %>"
                                        ImageUrl="~/images/cross.png" OnClientClick='<%$ Resources:DeleteFileConfirm %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblFileName" Text='<%# Bind("FileName") %>' NavigateUrl='<%# Bind("FileName2") %>'
                                        Target="_blank" runat="server"></asp:HyperLink>
                                </ItemTemplate>
                                <ControlStyle Width="300px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td align="right">
                                <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="Attach" CommandName="Attach"
                                    CssClass="ops" ImageUrl="~/images/attach1.png" ToolTip="Attach File" ValidationGroup="1"
                                    OnClick="BtnAttach_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                    ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label13"
                    ImageControlID="Image1" ExpandedText="<%$ Resources:HideDetails %>" CollapsedText="<%$ Resources:ShowDetails %>"
                    ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                    SuppressPostBack="true" />
            </div>
        </div>
    </center>
</asp:Content>
