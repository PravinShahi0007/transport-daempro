<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeBehind="WebEmp.aspx.cs" Inherits="ACC.WebEmp"
    Culture="ar-EG" UICulture="ar-EG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            SetMyStyle();
            $(function () {
                //$('input[id="ContentPlaceHolder1_txtSearch"]').watermark("***جملة البحث***");
                //$("#ContentPlaceHolder1_txtSubject1").watermark("***إدخل الموضوع***");
                //$('input[id*="ContentPlaceHolder1_txtTo"]').watermark("*جملة البحث*");
                //$('input[id="ContentPlaceHolder1_txtVac"]').watermark("رصيد أيام الإجازة");
                //$('input[id="ContentPlaceHolder1_txtVac2"]').watermark("*أيام العارضة*");
                //$('input[id="ContentPlaceHolder1_txtJoinDate2"]').watermark("*تاريخ تعيين سابق*");
                //$('input[id="ContentPlaceHolder1_txtStepYear"]').watermark("*سنه الترقية*");
            });
            // fF9C591      
        }

        function Name_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtEmpCode');
            var ace2Value = $get('ContentPlaceHolder1_txtName');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }

        function Name2_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtEmpCode');
            var ace2Value = $get('ContentPlaceHolder1_txtName2');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            ace2Value.value = x[1];
            return false;
        }


    </script>
    <style type="text/css">
        .containerStep {
          width: 615px;
          margin: 6px auto;           
          z-index : 5;
        }
        .progressbar {
          margin: 0;
          padding: 0;
          counter-reset: step;
          z-index: 7;
        }
        .progressbar li {
          list-style-type: none;
          width: 15%;
          float: right;
          font-size: 12px;
          position: relative;
          text-align: center;
          color: #7d7d7d;
          z-index: 1;
        }
        .progressbar li:before {
          width: 30px;
          height: 30px;
          content: counter(step);
          counter-increment: step;
          line-height: 30px;
          border: 2px solid #7d7d7d;
          display: block;
          text-align: center;
          margin: 0 auto 6px auto;
          border-radius: 50%;
          background-color: white;
        }
        .progressbar li:after {
          width: 100%;
          height: 2px;
          content: '';
          position: absolute;
          background-color: #7d7d7d;
          top: 15px;
          right: -32%;        
          z-index: -1;
        }
        .progressbar li:first-child:after {
          content: none;
        }
        .progressbar li.active {
          color: green;
        }
        .progressbar li.active:before {
          border-color: #55b776;
        }
        .progressbar li.active + li:after {
          background-color: #55b776;
        }

        .progressbar li.current {
          color: blue;
        }
        .progressbar li.current:before {
          border-color: #55b776;
        }
        .progressbar li.refuse {
          color: red;
        }
        .progressbar li.refuse:before {
          border-color: #55b776;
        }
        .progressbar li.transfer {
          color:Orange;
        }
        .progressbar li.refuse:before {
          border-color: #55b776;
        }        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center dir="rtl">
        <div class="ColorRounded4Corners">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ البيانات الإساسية ]</b></legend>
                <center>
                    <table id="Table1" dir="rtl" width="98%" cellpadding="2" style="color: Black">
                        <tr id="tr1" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="LblCode" runat="server" Text="رقم الملف*"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtEmpCode" Width="120px" runat="server" MaxLength="50" EnableViewState="false" ></asp:TextBox>
                                <asp:ImageButton ID="BtnFind2" runat="server" ImageUrl="~/images/zoom_16.png" OnClick="BtnFind2_Click"
                                    ImageAlign="Top" ToolTip="البحث عن رقم الملف و عرض بياناتة" />
                                <asp:RequiredFieldValidator ID="ValEmpCode" runat="server" ControlToValidate="txtEmpCode"
                                    ErrorMessage="يجب إدخال رقم الملف" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1"
                                    Display="Dynamic">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValEmpCode2" runat="server" ControlToValidate="txtEmpCode"
                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" ValidationGroup="1"
                                    SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;" >
                            </td>
                            <td align="left" style="width: 160px;">
                                <asp:FileUpload ID="FileUpload0" Width="80px" runat="server" />
                                <asp:Button ID="BtnLoad0" runat="server" Text="تحميل الصورة" OnClick="BtnLoad0_Click" />
                            </td>
                            <td style="width: 140px" rowspan="5">
                                <img id="ImgPhoto" runat="server" src="images/123.jpg" alt="Photo" class="img-circle" />
                            </td>
                        </tr>
                        <tr id="tr4" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label30" runat="server" Text="الرقم الوظيفي*"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtJobNo" Width="120px" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind3" runat="server" ImageUrl="~/images/zoom_16.png"
                                    OnClick="BtnFind3_Click" ImageAlign="Top" 
                                    ToolTip="البحث عن الرقم الوظيفي و عرض بياناتة" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmpCode"
                                    ErrorMessage="يجب إدخال الرقم الوظيفي" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1" Display="Dynamic">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label3" runat="server" Text="نوع العقد"></asp:Label>
                            </td>
                            <td style="width: 160px">
                                <asp:RadioButtonList ID="rdoContractType" runat="server" RepeatColumns="2">
                                    <asp:ListItem Selected="True" Value="0">سنوي</asp:ListItem>
                                    <asp:ListItem Value="1">سنتين</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="tr25" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label7" runat="server" Text="الاسم بالعربية*"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtName" Width="280px" runat="server" autocomplete="off" MaxLength="100"></asp:TextBox>
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtName"
                                            ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionEMP" OnClientItemSelected="Name_itemSelected"
                                            MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                <asp:RequiredFieldValidator ID="ValName" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="يجب إدخال اسم الموظف" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2">
                                <asp:RadioButtonList ID="rdoState" runat="server" RepeatColumns="3">
                                    <asp:ListItem Selected="True" Value="0">على رأس العمل</asp:ListItem>
                                    <asp:ListItem Value="1">في إجازة</asp:ListItem>
                                    <asp:ListItem Value="2">أنهاء تعاقد</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>

                        <tr id="tr17" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label31" runat="server" Text="الاسم بالانجليزية*"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtName2" Width="280px" runat="server" autocomplete="off" MaxLength="100"></asp:TextBox>
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtName2"
                                            ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionEMP2" OnClientItemSelected="Name2_itemSelected"
                                            MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtName2"
                                    ErrorMessage="يجب إدخال اسم الموظف" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label33" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td style="width: 160px">
                                <asp:TextBox ID="txtMobileNo" Width="120px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr18" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label40" runat="server" Text="الكفيل"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlSponsor" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label23" runat="server" Text="الجنسية"></asp:Label>
                            </td>
                            <td style="width: 160px">
                                <asp:DropDownList ID="ddlNational" Width="140px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="tr50" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label21" runat="server" Text="المؤهل الدراسي"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlCertificate" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label39" runat="server" Text="جوال أحد الاقارب"></asp:Label>
                            </td>
                            <td style="width: 160px">
                                <asp:TextBox ID="txtMobileNo2" Width="120px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr13" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label57" runat="server" Text="الإدارة*"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlDep" Width="280px" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDep"
                                    InitialValue="-1" ErrorMessage="يجب اختيار الإدارة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label24" runat="server" Text="الديانة"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:DropDownList ID="ddlReginal" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="tr14" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label25" runat="server" Text="القسم*"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlSection" Width="280px" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSection"
                                    InitialValue="-1" ErrorMessage="يجب اختيار القسم" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label26" runat="server" Text="الوظيفة"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:DropDownList ID="ddlJob" Width="280px" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlJob"
                                    InitialValue="-1" ErrorMessage="يجب اختيار الوظيفة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="tr7" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label9" runat="server" Text="تاريخ الميلاد*"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtBirthDate" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtBirthDate"
                                    CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                    Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label10" runat="server" Text="مكان الميلاد"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:DropDownList ID="ddlBirthPlace" Width="150px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="tr2" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label4" runat="server" Text="تأشيرة الدخول"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtEnterVisaNo" Width="280px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label2" runat="server" Text="محل الدخول"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtVisaPlace" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr46" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label5" runat="server" Text="رقم الحدود"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtEnterVisaNo2" Width="280px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label14" runat="server" Text="تاريخ الدخول"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtEnterVisaDate2" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtEnterVisaDate2"
                                    CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                    Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr id="tr47" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label12" runat="server" Text="تاريخ التأشيرة"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtEnterVisaDate" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="txtEnterVisaDate"
                                    CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                    Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label22" runat="server" Text="تاريخ الانتهاء"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtIqamaEnd" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator28" runat="server" ControlToValidate="txtIqamaEnd"
                                    CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                    Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr id="tr48" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label8" runat="server" Text="رقم مكتب العمل"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtWorkerNo" Width="150px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label32" runat="server" Text="وكالة الاستقدام"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtOffice" Width="280px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr49" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label37" runat="server" Text="مدير الوكالة"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtOfficeManager" Width="280px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label38" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtOfficeMobile" Width="150px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr24" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label46" runat="server" Text="تاريخ بداية الخدمة"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtJoinDate" Width="130px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator26" runat="server" ControlToValidate="txtJoinDate"
                                    CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                    Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label47" runat="server" Text="تاريخ أخر إجازة"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtVacDate" Width="130px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtVacDate"
                                    CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                    Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr id="tr8" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label13" runat="server" Text="تاريخ أخر مباشرة عمل"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtReturnDate" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtReturnDate"
                                    CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                    Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label51" runat="server" Text="تاريخ نهاية الخدمة"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtEndDate" Width="150px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtEndDate"
                                    CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                    Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr id="tr5" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label1" runat="server" Text="عدد تذاكر السفر"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtTicketNo" Width="120px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator47" runat="server" ControlToValidate="txtTicketNo"
                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" ValidationGroup="1"
                                    SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label11" runat="server" Text="مدة الإجازة بالعقد"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtVacDays" Width="90px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:Label ID="Label49" runat="server" Text="متبقي ايام "></asp:Label>
                                <asp:TextBox ID="txtVacRemain"  Width="90px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator48" runat="server" ControlToValidate="txtVacDays"
                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" ValidationGroup="1"
                                    SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic">*</asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator61" runat="server" ControlToValidate="txtVacRemain"
                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" ValidationGroup="1"
                                    SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic">*</asp:CompareValidator>                                
                            </td>
                        </tr>
                        <tr id="tr51" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label17" runat="server" Text="قيمة تذاكر السفر"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtTicketValue" Width="120px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator59" runat="server" ControlToValidate="txtTicketValue"
                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency" ValidationGroup="1"
                                    SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic">*</asp:CompareValidator>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label18" runat="server" Text="ايام الانقطاع"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtOffDays" Width="120px" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator60" runat="server" ControlToValidate="txtOffDays"
                                    ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Integer" ValidationGroup="1"
                                    SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr id="tr6" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label19" runat="server" Text="البنك"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlBank" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label53" runat="server" Text="رقم الايبان"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtIBan" Width="280px" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr9" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label15" runat="server" Text="رقم بطاقة الصراف"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtATM" Width="280px" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label16" runat="server" Text="ملاحظات"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtRemark" Width="280px" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="tr52" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label20" runat="server" Text="حساب المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlUserName" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label27" runat="server" Text="حساب المستخدم2"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:DropDownList ID="ddlUserName2" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="tr55" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label50" runat="server" Text="المدير المباشر"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlManag1" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label54" runat="server" Text="نائب المدير"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:DropDownList ID="ddlManag2" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="tr56" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label56" runat="server" Text="توقيت العمل"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:DropDownList ID="ddlShift" Width="280px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px;">
                            </td>
                            <td style="width: 300px" colspan="2">
                            </td>
                        </tr>


                        <tr id="tr53" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label28" runat="server" Text="قيمة ومدة الهوية"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtamP10" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP10" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP10LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP10LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label29" runat="server" Text="قيمة ومدة تأمين صحي"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtamP11" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP11" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>                            
                                <asp:TextBox ID="txtP11LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                 <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP11LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                        </tr>
                        <tr id="tr54" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label48" runat="server" Text="قيمة ومدة كارت العمل"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtamP12" Width="100px" Placeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP12" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP12LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                   <ajax:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP12LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="Label55" runat="server" Text="قيمة ومدة المقابل المالي"></asp:Label>
                            </td>
                            <td style="width: 300px" colspan="2">
                                <asp:TextBox ID="txtamP13" Width="100px" Placسeholder="القيمة" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtMP13" Width="70px" Placeholder="عدد الشهور" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:TextBox ID="txtP13LDate" Width="80px" Placeholder="أخر تنفيذ" runat="server" MaxLength="20"></asp:TextBox>
                                   <ajax:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtP13LDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                            </td>
                        </tr>
                        <tr id="tr19" align="right">
                            <td colspan="5">
                                <div class="myPanelSH" style="width: 99%; background-color: #FFFBD6">
                                    <asp:Panel ID="Panel4" runat="server" Height="30px" BackColor="#5D7B9D" Width="100%"
                                        Direction="RightToLeft" ForeColor="White" Font-Bold="False">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div id="div4" runat="server" style="float: right; text-align: right;">
                                                <asp:Label ID="Label6" runat="server" Text="الوثائق الشخصية"></asp:Label></div>
                                            <div id="div5" runat="server" style="float: left; vertical-align: middle;">
                                                <asp:Label ID="Label34" runat="server" Text="عرض التفاصيل"></asp:Label>
                                            </div>
                                            <div id="div6" runat="server" style="float: right; margin-right: 20px;">
                                                <asp:ImageButton ID="Image2" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="..." />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel5" runat="server" Height="0" Width="100%">
                                        <center>
                                            <table class="box-table-a" width="98%">
                                                <hbody>
                                        <tr id="tr22" align="center">
                                            <td  style="width: 80px;">
                                                <asp:Label ID="Label41" runat="server" Text="المستند"></asp:Label>
                                            </td>
                                            <td style="width: 125px">
                                                <asp:Label ID="Label42" runat="server" Text="رقم المستند"></asp:Label>
                                            </td>
                                            <td style="width: 125px;">
                                                <asp:Label ID="Label43" runat="server" Text="صادر من"></asp:Label>
                                            </td>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label44" runat="server" Text="تاريخ الاصدار"></asp:Label>
                                            </td>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label45" runat="server" Text="تاريخ الانتهاء"></asp:Label>
                                            </td>
                                            <td style="width: 225px">
                                                <asp:Label ID="Label52" runat="server" Text="الصورة"></asp:Label>
                                            </td>
                                        </tr>
                                    </hbody>
                                                <tbody>
                                                    <tr id="tr20" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper1" Width="80px" runat="server" Text="الهوية"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo1" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc1" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate1" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtIssueDate1"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate1" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator25" runat="server" ControlToValidate="txtExpDate1"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload1" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad1" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView1" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr21" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper2" Width="80px" runat="server" Text="جواز السفر"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo2" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc2" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate2" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator29" runat="server" ControlToValidate="txtIssueDate2"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate2" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator38" runat="server" ControlToValidate="txtExpDate2"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload2" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad2" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView2" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr23" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper3" Width="80px" runat="server" Text="العقد"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo3" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc3" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate3" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator30" runat="server" ControlToValidate="txtIssueDate3"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate3" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator39" runat="server" ControlToValidate="txtExpDate3"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload3" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad3" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView3" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr26" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper4" Width="80px" runat="server" Text="تأمين صحي"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo4" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc4" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate4" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator31" runat="server" ControlToValidate="txtIssueDate4"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate4" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator40" runat="server" ControlToValidate="txtExpDate4"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload4" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad4" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView4" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr27" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper5" runat="server" Width="80px" Text="رخصة العمل"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo5" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc5" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate5" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator32" runat="server" ControlToValidate="txtIssueDate5"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate5" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator41" runat="server" ControlToValidate="txtExpDate5"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload5" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad5" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView5" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr28" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper6" runat="server" Width="80px" Text="حساب بنكي"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo6" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc6" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate6" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator33" runat="server" ControlToValidate="txtIssueDate6"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate6" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator42" runat="server" ControlToValidate="txtExpDate6"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload6" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad6" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView6" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr29" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper7" runat="server" Width="80px" Text="أستقالة"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo7" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc7" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate7" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator34" runat="server" ControlToValidate="txtIssueDate7"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate7" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator43" runat="server" ControlToValidate="txtExpDate7"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload7" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad7" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView7" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr30" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper8" runat="server" Width="80px" Text="مخالصة"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo8" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc8" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate8" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator35" runat="server" ControlToValidate="txtIssueDate8"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate8" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator44" runat="server" ControlToValidate="txtExpDate8"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload8" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad8" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView8" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr31" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper9" runat="server" Width="80px" Text="رخصة قيادة"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo9" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc9" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate9" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator36" runat="server" ControlToValidate="txtIssueDate9"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate9" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator45" runat="server" ControlToValidate="txtExpDate9"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload9" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad9" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView9" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr32" align="right">
                                                        <td style="width: 80px;">
                                                            <asp:Label ID="lblPaper10" runat="server" Width="80px" Text="مستند أخر"></asp:Label>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:TextBox ID="txtPaperNo10" MaxLength="20" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 125px">
                                                            <asp:DropDownList ID="ddlPaperLoc10" Width="125px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtIssueDate10" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator37" runat="server" ControlToValidate="txtIssueDate10"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 105px">
                                                            <asp:TextBox ID="txtExpDate10" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator46" runat="server" ControlToValidate="txtExpDate10"
                                                                CultureInvariantValues="true" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red"
                                                                Type="Date" ValidationGroup="1" Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:FileUpload ID="FileUpload10" Width="80px" runat="server" />
                                                            <asp:Button ID="BtnLoad10" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click" />
                                                            <asp:Button ID="BtnView10" Width="50px" runat="server" Text="عرض" OnClientClick="aspnetForm.target ='_blank';" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </center>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" BehaviorID="CollapsiblePanelExtender122"
                                        TargetControlID="Panel5" ExpandControlID="Panel4" CollapseControlID="Panel4"
                                        Collapsed="True" TextLabelID="Label34" AutoCollapse="false" AutoExpand="false"
                                        ImageControlID="Image2" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(أظهار التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </td>
                        </tr>
                        <tr id="tr33" align="right">
                            <td colspan="5">
                                <div class="myPanelSH" style="width: 99%; background-color: #FFFBD6">
                                    <asp:Panel ID="Panel1" runat="server" Height="30px" BackColor="#5D7B9D" Width="100%"
                                        Direction="RightToLeft" ForeColor="White" Font-Bold="False">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div id="div1" runat="server" style="float: right; text-align: right;">
                                                <asp:Label ID="Label35" runat="server" Text="بيانات المرتب"></asp:Label></div>
                                            <div id="div2" runat="server" style="float: left; vertical-align: middle;">
                                                <asp:Label ID="Label36" runat="server" Text="عرض التفاصيل"></asp:Label>
                                            </div>
                                            <div id="div3" runat="server" style="float: right; margin-right: 20px;">
                                                <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="..." />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server" Height="0" Width="100%">
                                        <center>
                                            <table id="box-table-a1" width="98%" cellpadding="2px" cellspacing="5px" style="color: Black">
                                                <thead>
                                                    <tr>
                                                        <th scope="col" colspan="2">
                                                            الاستحقاقات
                                                        </th>
                                                        <th scope="col" colspan="2">
                                                            الاستقطاعات
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr id="tr34" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblBasic" runat="server" Text="الراتب الأساسي"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtBasic" Width="120px" runat="server" MaxLength="50" AutoPostBack="True" ontextchanged="txtBasic_TextChanged"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtBasic"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed01" runat="server" Text="تأمينات"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed01" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator160" runat="server" ControlToValidate="txtDed01"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr35" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd01" runat="server" Text="بدل انتقال"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtAdd01" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="txtAdd01"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed02" runat="server" Text="غياب"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed02" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator17" runat="server" ControlToValidate="txtDed02"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr36" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd02" runat="server" Text="بدل السكن"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtAdd02" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtAdd02"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed04" runat="server" Text="سلف"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed04" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator19" runat="server" ControlToValidate="txtDed04"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr37" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd03" runat="server" Text="بدل طعام"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd03" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtAdd03"
                                                                ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency" ValidationGroup="1"
                                                                Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed03" runat="server" Text="جزاءات اخرى"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed03" Width="120px" runat="server" ReadOnly="true" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToValidate="txtDed03"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr38" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd04" runat="server" Text="بدلات أخرى"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd04" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="txtAdd04"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed05" runat="server" Text="أستقطاع 1"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed05" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator20" runat="server" ControlToValidate="txtDed05"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr39" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd05" runat="server" Text="بدل 1"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd05" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="txtAdd05"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed06" runat="server" Text="أستقطاع 2"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed06" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="txtDed06"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr40" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd06" runat="server" Text="بدل 2"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd06" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="txtAdd06"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed07" runat="server" Text="أستقطاع 3"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed07" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="txtDed07"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr41" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd07" runat="server" Text="بدل 3"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd07" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="txtAdd07"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed08" runat="server" Text="أستقطاع 4"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed08" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="txtDed08"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr42" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd08" runat="server" Text="بدل 4"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd08" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="txtAdd08"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed09" runat="server" Text="أستقطاع 5"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:TextBox ID="txtDed09" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator23" runat="server" ControlToValidate="txtDed09"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr43" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd09" runat="server" Text="بدل 5"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd09" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToValidate="txtAdd09"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed10" runat="server" Text="أستقطاع 6"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px;">
                                                            <asp:TextBox ID="txtDed10" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator24" runat="server" ControlToValidate="txtDed10"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr10" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd10" runat="server" Text="بدل 5"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd10" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator49" runat="server" ControlToValidate="txtAdd10"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed11" runat="server" Text="أستقطاع 6"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px;">
                                                            <asp:TextBox ID="txtDed11" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator50" runat="server" ControlToValidate="txtDed11"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr11" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd11" runat="server" Text="بدل 5"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd11" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator51" runat="server" ControlToValidate="txtAdd11"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed12" runat="server" Text="أستقطاع 6"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px;">
                                                            <asp:TextBox ID="txtDed12" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator52" runat="server" ControlToValidate="txtDed12"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr12" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd12" runat="server" Text="بدل 5"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd12" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator53" runat="server" ControlToValidate="txtAdd12"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed13" runat="server" Text="أستقطاع 6"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px;">
                                                            <asp:TextBox ID="txtDed13" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator54" runat="server" ControlToValidate="txtDed13"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr15" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd13" runat="server" Text="بدل 5"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd13" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator55" runat="server" ControlToValidate="txtAdd13"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed14" runat="server" Text="أستقطاع 6"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px;">
                                                            <asp:TextBox ID="txtDed14" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator56" runat="server" ControlToValidate="txtDed14"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr16" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd14" runat="server" Text="بدل 5"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd14" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator57" runat="server" ControlToValidate="txtAdd14"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDed15" runat="server" Text="أستقطاع 6"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px;">
                                                            <asp:TextBox ID="txtDed15" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator58" runat="server" ControlToValidate="txtDed15"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr57" align="right">
                                                        <td style="width: 120px;">
                                                            <asp:Label ID="lblAdd15" runat="server" Text="بدل 5"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtAdd15" Width="120px" runat="server" MaxLength="50"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator62" runat="server" ControlToValidate="txtAdd15"
                                                                Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                                                ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 150px;">
                                                        </td>
                                                        <td style="width: 200px;">
                                                        </td>
                                                    </tr>
                                                    <tr id="tr44" align="right">
                                                        <td style="width: 120px;" class="mytd">
                                                            <asp:Label ID="lblTAdd" runat="server" Text="اجمالي الاستحقاقات" Style="font-weight: 700"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px;">
                                                            <asp:TextBox ID="txtTAdd" ReadOnly="true" BackColor="LightGray" Width="120px" runat="server"
                                                                MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td class="mytd" style="width: 150px;">
                                                            <asp:Label ID="lblTDed" runat="server" Text="اجمالي الاستقطاعات" Style="font-weight: 700"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px;">
                                                            <asp:TextBox ID="txtTDed" ReadOnly="true" BackColor="LightGray" Width="120px" runat="server"
                                                                MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr45" align="right">
                                                        <td style="width: 120px;" class="mytd">
                                                            <asp:Label ID="lblNet" runat="server" Text="صافي المرتب" Style="font-weight: 700"></asp:Label>
                                                        </td>
                                                        <td style="width: 250px;">
                                                            <asp:TextBox ID="txtNet" ReadOnly="true" BackColor="LightGray" Width="120px" runat="server"
                                                                MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 200px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </center>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender10" runat="Server" BehaviorID="CollapsiblePanelExtender1220"
                                        TargetControlID="Panel2" ExpandControlID="Panel1" CollapseControlID="Panel1"
                                        Collapsed="True" TextLabelID="Label36" AutoCollapse="false" AutoExpand="false"
                                        ImageControlID="Image3" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(أظهار التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr align="right">
                            <td style="width: 120px;">
                                <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="285px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 70px;">
                            </td>
                            <td style="width: 300px;">
                            </td>
                        </tr>
                    </table>
                    <%-- *********************  *********************** --%>
                    <table width="98%" cellpadding="2">
                        <tr id="tr3" align="right">
                            <td style="width: 200px;">
                            </td>
                            <td style="width: 400px" align="center">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </td>
                            <td style="width: 200px;">
                            </td>
                        </tr>
                    </table>
                    <div class="DivButtons" style="width: 95%">
                        <table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                            <tr align="center">
                                <td style="width: 200px;">
                                    &nbsp;
                                </td>
                                <td style="width: 400px;">
                                    <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                        ImageUrl="~/images/insource_642.png" ToolTip="أضافة بيانات موظف جديد" ValidationGroup="1"
                                        OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الموظف؟")' OnClick="BtnNew_Click" />
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                        ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات موظف" Width="64px"
                                        ValidationGroup="1" OnClick="BtnEdit_Click" />
                                    <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                        ImageUrl="~/images/erasure_642.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                                    <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                        ImageUrl="~/images/cut_642.png" ToolTip="إلغاء بيانات موظف" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات الموظف؟")'
                                        OnClick="BtnDelete_Click" />
                                    <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                        ImageUrl="~/images/binoculars_642.png" ToolTip="البحث عن بيانات معاملة" OnClick="BtnSearch_Click" />
                                </td>
                                <td id="td1" runat="server" style="width: 200px; text-align: right">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </center>
                <br /><br />
                <div style="text-align: left; width: 50%; float: left;">
                    <asp:Panel ID="Panel20" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                        Direction="RightToLeft" ForeColor="#FFFF99">
                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                                مرفقات ملف الموظف</div>
                            <div style="float: right; margin-right: 20px;">
                                <asp:Label ID="Label340" runat="server">(عرض التفاصيل)</asp:Label>
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Panel10" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                        BorderColor="Maroon">
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" AllowPaging="false"
                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                            Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء الملف"
                                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء الملف؟")' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الملف" ItemStyle-HorizontalAlign="Center">
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
                                <td align="right">
                                    <asp:FileUpload ID="FileUpload11" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                          ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                        ValidationGroup="1" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel10"
                        ExpandControlID="Panel20" CollapseControlID="Panel20" Collapsed="True" TextLabelID="Label340"
                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                </div>
                <br /><br /><br /><br /><br /><br /><br />
         <div id="mdiv3" runat="server" class="Rounded4Corners div1" style="width:915px; height:2000px; float:right; border: thin solid #444444; overflow:hidden; overflow-x:hidden; overflow-y:auto;">
        <table width="100%">
            <tr>
                <td style="width:50px">
                    <asp:Label ID="Label58" runat="server" Text="النوع"></asp:Label>
                </td>
                <td style="width:150px">
                    <asp:DropDownList ID="ddlType2" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlMonth2_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="center" style="width:195px" >
                    <b><asp:Label ID="Label59" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ أرشيف المعاملات ]" meta:resourcekey="Label1"></asp:Label></b>
                </td>
                <td style="width:50px">
                    <asp:Label ID="Label60" runat="server" Text="الشهر"></asp:Label>
                </td>
                <td style="width:100px">
                    <asp:DropDownList ID="ddlMonth2" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlMonth2_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>                
        </table>

                <asp:GridView ID="grdTranHistory" CellPadding="4" 
                AutoGenerateColumns="False" runat="server" AllowPaging="true"
                ForeColor="#333333" GridLines="None" PageSize="20" DataKeyNames="DocNo" 
                Width="99.9%" onpageindexchanging="grdTranHistory_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="المعاملة" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                                <asp:HyperLink ID="lblName" Text='<%# Eval("Name2").ToString() + " " + Eval("DocNo").ToString()  %>' ToolTip="عرض المعاملة"
                                NavigateUrl='<%# Eval("FormName").ToString() + "?FNum=" + Eval("DocNo").ToString() + "&FLevel=" + Eval("Status").ToString()+"&FMode=0"  %>' Target="_blank" runat="server"></asp:HyperLink>            
                        </ItemTemplate>                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="التاريخ" SortExpression="DocDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDocDate" runat="server" Text='<%# Eval("DocDate")  %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="خط سير المعاملة" SortExpression="DocNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Literal ID="Literal122" Text='<%# Eval("MakeDiv") %>' runat="server"></asp:Literal>
                        </ItemTemplate>
                        <ControlStyle Width="650px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center"
                    Font-Bold="True" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="center" />
                <RowStyle BackColor="#EFF3FB" Font-Size="Medium"  />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>    
        <br /><br /><br /><br /><br /><br /><br />
            </fieldset>
        </div>
    </center>
</asp:Content>
