<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCustAgree.aspx.cs" Inherits="ACC.WebCustAgree" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ مصادقة على صحة رصيد حساب ]"></asp:Label>
                </b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="LblFDate" runat="server" Text="حتى تاريخ"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtFDate" MaxLength="10" Width="100px" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />                                
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">

                                &nbsp;</td>
                            <td align="right" style="width: 17%;">
                                
                                </td>
                            <td align="left" style="width: 17%;">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                &nbsp;</td>
                            <td align="right" style="width: 35%;">
                                <asp:RadioButtonList ID="RdoType" runat="server" RepeatColumns="3" 
                                    AutoPostBack="True" onselectedindexchanged="RdoType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">جميع العملاء</asp:ListItem>
                                    <asp:ListItem Value="1">جميع الموردين</asp:ListItem>
                                    <asp:ListItem Value="2">حساب</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                &nbsp;</td>
                            <td align="right" colspan="2" rowspan="2">
                                <asp:ImageButton ID="BtnPrint" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print_64A.png"
                                      OnCommand="BtnPrint_Command" OnClientClick="aspnetForm.target ='_blank';" />                                    
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblAccount" Visible="false" runat="server" Text="الحساب"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                        <asp:TextBox ID="txtCode"  Visible="false" runat="server" Width="250px" />
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender02" runat="server" TargetControlID="txtCode"
                                            ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCodeName" 
                                            MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                            </td>
                            <td align="right" style="width: 1%;">
                                &nbsp;</td>
                            <td align="center" style="width: 15%;">
                                &nbsp;</td>
                        </tr>
                        </table>
                       <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                </center>                
            </fieldset>
        </div>
    </center>
</asp:Content>
