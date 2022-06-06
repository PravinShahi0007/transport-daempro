<%@ Page Title="" Language="C#" MasterPageFile="~/SupportSite.Master" AutoEventWireup="true" CodeBehind="WebInquiry.aspx.cs" Inherits="ACC.WebInquiry" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type = "text/javascript">
    function SetContextKey() {
        $find('<%=AutoCompleteExtender2.ClientID%>').set_contextKey($get("<%=ddlFType.ClientID %>").value);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Rounded4Corners div1" style="width: 915px; border: thin solid #800000;">
        <center>
            <b>
                <asp:Label ID="Label4" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ البحث ]"
                    meta:resourcekey="Label4"></asp:Label></b></center>
        <table width="100%" style="color:Black;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="فترة البحث"></asp:Label>
                </td>
                <td colspan="4">
                    <asp:RadioButtonList ID="RdoPeriod" runat="server" CellPadding="2" 
                        CellSpacing="2" RepeatColumns="9" Width="100%" AutoPostBack="True" 
                        onselectedindexchanged="RdoPeriod_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="7">أسبوع</asp:ListItem>
                        <asp:ListItem Value="14">أسبوعين</asp:ListItem>
                        <asp:ListItem Value="21">ثلاثة اسابيع</asp:ListItem>
                        <asp:ListItem Value="30">شهر</asp:ListItem>
                        <asp:ListItem Value="60">شهرين</asp:ListItem>
                        <asp:ListItem Value="90">ثلاثة أشهر</asp:ListItem>
                        <asp:ListItem Value="180">سته أشهر</asp:ListItem>
                        <asp:ListItem Value="365">سنة</asp:ListItem>
                        <asp:ListItem Value="0">جميع الفترات</asp:ListItem>
                    </asp:RadioButtonList>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlFType" Width="120px" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="ddlFType_SelectedIndexChanged">
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
                    <asp:TextBox ID="txtSearch" Width="150px" onkeyup = "SetContextKey();" 
                        autocomplete="off" runat="server" AutoPostBack="True" 
                        ontextchanged="txtSearch_TextChanged"></asp:TextBox>
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearch"
                                            ServicePath="AutoComplete.asmx" ServiceMethod="GetSupportData"  UseContextKey="true" 
                                            MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                    <asp:ImageButton ID="BtnSearch" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                        ToolTip="<%$ Resources:SearchCar %>" OnClick="BtnSearch_Click" />
                </td>
                <td style="width:100px">
                </td>
                <td style="width:250px">
                    <asp:TextBox ID="txtSName" PlaceHolder="البحث عن رقم جوال موظف" Width="250px" runat="server"></asp:TextBox>
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSName"
                                            ServicePath="AutoComplete.asmx" ServiceMethod="GetDrivers" 
                                            MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />

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
        <br />
    </div>
</asp:Content>
