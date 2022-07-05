<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebPayReq.aspx.cs" Inherits="ACC.WebPayReq" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ace1_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCode');
            var ace2Value = $get('ContentPlaceHolder1_txtName');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD
<div class="card">
    <div class=" col-md-12 col-sm-12 col-xs-12">
        <div class="card-header">
        <h4 class="card-title text-center">
            <asp:Label ID="lblHead" runat="server" Text="[ طلب دفع]"></asp:Label>
        </h4>
            </div>
=======

    <div class="ColorRounded4Corners col-md-12 col-sm-12 col-xs-12">

        <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
            <asp:Label ID="lblHead" runat="server" Text="[ طلب دفع]"></asp:Label>
        </b></legend>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
        <div class="box box-info" align="right">
            <div class="body">
                <div class="row">

                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="رقم الطلب"></asp:Label>

                                <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
<<<<<<< HEAD
                                <br />
=======
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:TextBox ID="txtSearch" MaxLength="10" CssClass="form-control" placeholder="بحث" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات الطلب" OnClick="BtnFind_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="التاريخ"></asp:Label>

                                <asp:TextBox ID="txtHDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label6" runat="server" Text="الموافق"></asp:Label>

                                <asp:TextBox ID="txtGDate" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الطلب" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtGDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtGDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </div>
                        </div>
                    </div>
<<<<<<< HEAD
                   
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                 <br />
                               
                                <asp:RadioButtonList ID="RdoChq" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
=======
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:RadioButtonList ID="RdoChq" runat="server" AutoPostBack="True"
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    OnSelectedIndexChanged="RdoChq_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">نقدي</asp:ListItem>
                                    <asp:ListItem Value="1">شيك عادي</asp:ListItem>
                                    <asp:ListItem Value="2">شيك مصدق</asp:ListItem>
                                    <asp:ListItem Value="3">تحويل بنكي</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="لأمر"></asp:Label>

                                <asp:TextBox ID="txtPerson" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label11" runat="server" Text="مبلغ وقدرة"></asp:Label>

                                <asp:TextBox ID="txtAmount" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtAmount"
                                    Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                    Type="Currency">*</asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label7" runat="server" Text="وذلك عن"></asp:Label>

                                <asp:TextBox ID="txtRemark" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
<<<<<<< HEAD
                                <asp:Label ID="Label2" runat="server" Text="مدين"></asp:Label>
=======
                                <asp:Label ID="Label28" runat="server" Text="الحساب المدين"></asp:Label>

>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCode"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList" OnClientItemSelected="ace1_itemSelected"
                                    MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                    CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
<<<<<<< HEAD
                                <asp:Label ID="Label28" runat="server" Text="الحساب"></asp:Label>

=======
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtName"
                                    ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                    OnClientItemSelected="ace1_itemSelected" CompletionInterval="500" EnableCaching="true"
                                    CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement1"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="lblAccCode2" runat="server" Text="حساب البنك"></asp:Label>

                                <asp:DropDownList ID="ddlAccCode2" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label30" runat="server" Text="الحالة"></asp:Label>

                                <asp:DropDownList ID="ddlApproved" Enabled="false" CssClass="form-control" AutoPostBack="true" runat="server"
                                    OnSelectedIndexChanged="ddlApproved_SelectedIndexChanged">
                                    <asp:ListItem Text="معلق" Value="0"> </asp:ListItem>
                                    <asp:ListItem Text="موافق" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="مرفوض" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="سدد" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>

                                <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    CssClass="MouseStop form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>

                                <asp:TextBox ID="txtUserDate" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    CssClass="MouseStop form-control" Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>

                                <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
<<<<<<< HEAD
                    <div class="form-group">
                         <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>

                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />

                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                               
=======
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>

                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />

>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7

                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png" ToolTip="أضافة سند جديد" ValidationGroup="1"
                                    OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الطلب؟")' OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات الطلب" OnClientClick="return Validate()"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ValidationGroup="1" ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات الطلب"
                                    OnClientClick="return Validate2()" OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات الطلب" OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
<<<<<<< HEAD
                                    ImageUrl="~/images/print.png" ValidationGroup="1" ToolTip="طباعة الطلب" OnClick="BtnPrint_Click" />
=======
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1" ToolTip="طباعة الطلب" OnClick="BtnPrint_Click" />
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                            </div>
                        </div>
                    </div>
                </div></div></div></div>
<<<<<<< HEAD
</div>
=======
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
</asp:Content>
