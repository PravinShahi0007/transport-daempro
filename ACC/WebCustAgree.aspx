<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCustAgree.aspx.cs" Inherits="ACC.WebCustAgree" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <fieldset class="card text-center">
                <div class="form-group">
                    <h4 class="text-muted">
                        مصادقة على صحة رصيد حساب
                    </h4>
                </div>
                <hr />
                <br />

                <div class="form-row">
                    <div class="form-group col-sm-2">
                        <asp:Label ID="LblFDate" runat="server" Text="حتى تاريخ"></asp:Label>
                    </div>
                    <div class="form-group col-sm-2">
                        <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />                                

                    </div>
                    <div class="form-group col-sm-5">
                        <asp:RadioButtonList ID="RdoType" CssClass="form-control"  runat="server" RepeatColumns="3" 
                                    AutoPostBack="True" onselectedindexchanged="RdoType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">جميع العملاء</asp:ListItem>
                                    <asp:ListItem Value="1">جميع الموردين</asp:ListItem>
                                    <asp:ListItem Value="2">حساب</asp:ListItem>
                                </asp:RadioButtonList>
                    </div>
                    <div class="form-group col-sm-1"></div>
                    <div class="form-group col-sm-2">
                        <asp:ImageButton ID="BtnPrint" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                      OnCommand="BtnPrint_Command" OnClientClick="aspnetForm.target ='_blank';" /> 
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-sm-2">
                        <asp:Label ID="lblAccount" Visible="false" runat="server" Text="الحساب"></asp:Label>
                    </div>
                    <div class="form-group col-sm-3">
                        <asp:TextBox ID="txtCode" CssClass="form-control"  Visible="false" runat="server" Width="250px" />
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender02" runat="server" TargetControlID="txtCode"
                                            ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCodeName" 
                                            MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                    </div>
                    <div class="form-group col-sm-7"></div>
                </div>
                 
                <div class="form-group">
                    <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label> 
                </div>
                   <hr />                 
            </fieldset>

</asp:Content>
