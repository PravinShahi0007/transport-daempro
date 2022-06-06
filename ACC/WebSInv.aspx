<%@ Page Title="أتفاقية شحن - فاتورة" Language="C#" MasterPageFile="~/SupportSite.Master" AutoEventWireup="true" CodeBehind="WebSInv.aspx.cs" Inherits="ACC.WebSInv" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">

    function CheckImg(senderID) {
        var sender = document.getElementById(senderID);
        var HImgAccess = document.getElementById('<%=HImgAccess.ClientID %>');
        var s = HImgAccess.value;
        var s1 = "";
        var pos = parseInt(senderID.replace("ContentPlaceHolder1_ImgAccess", "")) - 1;
        if (sender) {
            if (sender.src.indexOf("True") >= 0) {
                sender.src = sender.src.replace("True", "False");
                s1 = s.substring(0, pos) + "0" + s.substring(pos + 1, s.length);
            }
            else {
                sender.src = sender.src.replace("False", "True");
                s1 = s.substring(0, pos) + "1" + s.substring(pos + 1, s.length);
            }
            HImgAccess.value = s1;
        }
    }

    function CheckImg2(senderID) {
        var sender = document.getElementById(senderID);
        var HImgAccess = document.getElementById('<%=HImgS.ClientID %>');
        var s = HImgAccess.value;
        var s1 = "";
        var pos = parseInt(senderID.replace("ContentPlaceHolder1_ImgS", "")) - 1;
        if (sender) {
            if (sender.src.indexOf("True") >= 0) {
                sender.src = sender.src.replace("True", "False");
                s1 = s.substring(0, pos) + "0" + s.substring(pos + 1, s.length);
            }
            else {
                sender.src = sender.src.replace("False", "True");
                s1 = s.substring(0, pos) + "1" + s.substring(pos + 1, s.length);
            }
            HImgAccess.value = s1;
        }
    }

    function MakeJSum(sender, args) {
        var total = document.getElementById('<%=txtTotal.ClientID %>');
        var discount = document.getElementById('<%=txtDiscount.ClientID %>');
        var Price0 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_0');
        var Price1 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_1');
        var Price2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_2');
        var Price3 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_3');
        var Price4 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_4');
        var Price5 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_5');
        var Price6 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_6');
        var Price7 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_7');
        var Price8 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_8');
        var Price9 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_9');

        var Price20 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price21 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price22 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price23 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price24 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price25 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price26 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price27 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price28 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Price29 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');

        if (total) {
            total.value = '0';
            if (Price0 && Price20) {
                if (Price20.value == '') {
                    Price0.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price0.value)).toString();
            }
            if (Price1 && Price21) {
                if (Price21.value == '') {
                    Price1.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price1.value)).toString();
            }
            if (Price2 && Price22) {
                if (Price22.value == '') {
                    Price2.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price2.value)).toString();
            }
            if (Price3 && Price23) {
                if (Price23.value == '') {
                    Price3.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price3.value)).toString();
            }
            if (Price4 && Price24) {
                if (Price24.value == '') {
                    Price4.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price4.value)).toString();
            }
            if (Price5 && Price25) {
                if (Price25.value == '') {
                    Price5.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price5.value)).toString();
            }
            if (Price6 && Price26) {
                if (Price26.value == '') {
                    Price6.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price6.value)).toString();
            }
            if (Price7 && Price27) {
                if (Price27.value == '') {
                    Price7.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price7.value)).toString();
            }
            if (Price8 && Price28) {
                if (Price28.value == '') {
                    Price8.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price8.value)).toString();
            }
            if (Price9 && Price29) {
                if (Price29.value == '') {
                    Price9.value = '0';
                }
                total.value = (parseFloat(total.value) + parseFloat(Price9.value)).toString();
            }
            if (discount) {
                if (discount.value == '') {
                    discount.value = '0';
                }
                total.value = (parseFloat(total.value) - parseFloat(discount.value)).toString();
            }
        }
        return false;
    }


    function CheckItemO(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_0');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO0(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_0');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_0');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO1(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_1');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_1');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO2(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_2');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_2');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO3(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_3');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_3');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO4(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_4');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_4');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO5(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_5');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_5');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO6(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_6');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_6');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO7(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_7');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_7');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO8(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_8');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_8');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItemO9(sender, args) {
        var Amount2 = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice2_9');
        var Amount = document.getElementById('ContentPlaceHolder1_grdCodes_txtPrice_9');
        args.IsValid = false;
        if (Amount && Amount2) {
            if (parseFloat(Amount2.value) != 0 && parseFloat(Amount.value) < parseFloat(Amount2.value)) {
                return
            }
        }
        args.IsValid = true;
        return
    }

    function CheckItem1(sender, args) {
        var CashAmount = document.getElementById('<%=txtCashAmount.ClientID %>');
        var SiteAmount = document.getElementById('<%=txtSiteAmount.ClientID %>');
        var CustomerAmount = document.getElementById('<%=txtCustomerAmount.ClientID %>');
        var Amount = document.getElementById('<%=txtTotal.ClientID %>');
        args.IsValid = false;
        if (Amount && CashAmount && SiteAmount && CustomerAmount) {
            if (!CashAmount.value) CashAmount.value = '0';
            if (!SiteAmount.value) SiteAmount.value = '0';
            if (!CustomerAmount.value) CustomerAmount.value = '0';
            if (!Amount.value) Amount.value = '0';
            if (parseFloat(SiteAmount.value) != 0 && parseFloat(Amount.value) > parseFloat(CashAmount.value) + parseFloat(SiteAmount.value) + parseFloat(CustomerAmount.value)) {
                return
            }

        }
        args.IsValid = true;
        return
    }

    function CheckItem2(sender, args) {
        var CashAmount = document.getElementById('<%=txtCashAmount.ClientID %>');
        var SiteAmount = document.getElementById('<%=txtSiteAmount.ClientID %>');
        var CustomerAmount = document.getElementById('<%=txtCustomerAmount.ClientID %>');
        var Amount = document.getElementById('<%=txtTotal.ClientID %>');
        args.IsValid = false;
        if (Amount && CashAmount && CustomerAmount && SiteAmount) {
            if (!CashAmount.value) CashAmount.value = '0';
            if (!SiteAmount.value) SiteAmount.value = '0';
            if (!CustomerAmount.value) CustomerAmount.value = '0';
            if (!Amount.value) Amount.value = '0';
            if (parseFloat(CustomerAmount.value) != 0 && parseFloat(Amount.value) > parseFloat(CashAmount.value) + parseFloat(CustomerAmount.value) + parseFloat(SiteAmount.value)) {
                return
            }

        }
        args.IsValid = true;
        return
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center>
        <div class="ColorRounded4Corners" style="width: 99.9%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.8%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ أتفاقية شحن - فاتورة ]"></asp:Label>
                </b></legend>
                <center>
                 <table width="99.9%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 150px">
                            </td>
                            <td align="right" style="width: 300px">
                            </td>
                            <td align="right" colspan="2">
                            </td>
                            <td colspan="2" align="left">
                                <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server" ></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="البحث عن بيانات فاتورة شحن" OnClick="BtnFind_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="Label1" runat="server" Visible="false" Text="رقم الفاتورة"></asp:Label>                                
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtVouNo" Visible="false" MaxLength="10" runat="server" CssClass="MouseStop"></asp:TextBox>
                                <asp:Label ID="lblBranch" Visible="false" runat="server" Text="Label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVouNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم الفاتورة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="right" colspan="2">
                                <asp:RadioButtonList ID="rdoVouType" runat="server" RepeatColumns="2" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="ddlPlaceofLoading_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">ذهاب</asp:ListItem>
                                    <asp:ListItem Value="1">ذهاب وعوده</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td colspan="2" align="right">
                                <asp:CheckBox ID="ChkReturnInv" runat="server" AutoPostBack="True" Visible = "false"
                                    oncheckedchanged="ChkReturnInv_CheckedChanged" Text="عوده" />
                                &nbsp;&nbsp;
                                <asp:TextBox ID="txtOVouNo" Visible="false" MaxLength="20" placeholder="فاتورة الذهاب" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind2" runat="server" ValidationGroup="55" 
                                    ImageUrl="~/images/zoom_16.png" Visible="false"
                                    ToolTip="البحث عن بيانات فاتورة شحن" OnClick="BtnFind2_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:Label ID="Label4" runat="server" Text="التاريخ"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtHDate" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label7" runat="server" Text="الموافق"></asp:Label>
                                *
                            </td>
                            <td align="right" style="width: 300px;" colspan="3">
                                <asp:TextBox ID="txtGDate" MaxLength="10" runat="server" AutoPostBack="True" 
                                    ontextchanged="txtGDate_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtGDate"
                                    Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>م&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="txtGDate" ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$" runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                                <asp:Label ID="LblFTime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>                        
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:Label ID="Label6" runat="server" Text="أسم المرسل"></asp:Label>
                                *
                                <asp:CheckBox ID="ChkCust" runat="server" AutoPostBack="True" oncheckedchanged="ChkCust_CheckedChanged" Text="عملاء" />
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtName" MaxLength="100" runat="server" Width="275px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="يجب إدخال أسم المرسل" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddlCust" Width="280" runat="server" AutoPostBack="True" Visible="false"
                                    OnSelectedIndexChanged="ddlCust_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label9" runat="server" Text="رقم الهوية"></asp:Label>
                            </td>
                            <td align="right" colspan="2">
                                <asp:TextBox ID="txtIDNo" MaxLength="15" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:RadioButtonList ID="rdoIDType" runat="server" RepeatColumns="2">
                                    <asp:ListItem Selected="True" Value="0">هوية مقيم</asp:ListItem>
                                    <asp:ListItem Value="1">هوية وطنية</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:Label ID="Label10" runat="server" Text="مصدرها"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtIDFrom" MaxLength="50" runat="server" Width="275px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label11" runat="server" Text="تاريخها"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="3">
                                <asp:TextBox ID="txtIdDate" MaxLength="10" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtIdDate"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:Label ID="Label3" runat="server" Text="العنوان"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtAddress" MaxLength="200" runat="server" Width="275px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label28" runat="server"  Text="رقم الجوال"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="3">
                                <asp:TextBox ID="txtMobileNo" Width="100px" MaxLength="20" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtMail" Width="150px" Placeholder="الايميل" MaxLength="50" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="chkbPlaceFrom" runat="server" Text="استلام من موقع المرسل" OnCheckedChanged="chkbPlaceFrom_CheckedChanged" AutoPostBack="True" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink ID="lnkDispFrom" Target="_blank" NavigateUrl="WebGetMap.aspx" Visible="false"
                                runat="server">تحديد الموقع</asp:HyperLink>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Button ID="btnFrom" runat="server" Text="حفظ الموقع" Visible="False" OnClick="btnFrom_Click" />                                
                            </td>
                            <td style="width: 300px;" colspan="3">
                                <asp:HyperLink ID="lnkFrom" Target="_blank" Visible="false" runat="server">عرض الموقع</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:Label ID="Label2" runat="server" Text="مكان الشحن"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:DropDownList ID="ddlPlaceofLoading" Width="280" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlPlaceofLoading_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label13" runat="server" Text="جهة الترحيل"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="3">
                                <asp:DropDownList ID="ddlDestination" Width="280" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlPlaceofLoading_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="Label33" runat="server" Text="أسم المستلم"></asp:Label></td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtRecName" Width="275px" MaxLength="100" runat="server"></asp:TextBox></td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label5" runat="server" Text="عنوان المستلم"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="3">
                                <asp:TextBox ID="txtRecAddress" Width="275px" MaxLength="100" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="chkbTo" runat="server" Text="التسليم موقع المستلم" OnCheckedChanged="chkbTo_CheckedChanged" AutoPostBack="True" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink ID="lnkDispTo" Target="_blank" NavigateUrl="WebGetMap.aspx" Visible="false" runat="server">تحديد الموقع</asp:HyperLink>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Button ID="btnPlaceTo" runat="server" Text="حفظ الموقع" Visible="False" OnClick="btnPlaceTo_Click" />
                            </td>
                            <td style="width: 300px;" colspan="3">
                               <asp:HyperLink ID="lnkTo" Target="_blank" Visible="false" runat="server">عرض الموقع</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="lblChqNo" runat="server" Text="رقم الجوال"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtRecMobileNo" MaxLength="20" Width="100px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRecMobileNo"
                                    Display="Dynamic" ErrorMessage="يجب أختيار رقم جوال المستلم" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtRecMail" Width="150px" Placeholder="الايميل" MaxLength="50" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 175px;">
                            </td>
                            <td align="right" style="width: 300px;" colspan="3">
                           
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="Label8" runat="server" Text="نوع الشحن"></asp:Label>*
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:RadioButtonList ID="rdoShipType2" Width="250px" runat="server" RepeatColumns="2" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="rdoShipType2_SelectedIndexChanged" >
                                    <asp:ListItem Selected="True" Value="0">شحن عادي</asp:ListItem>
                                    <asp:ListItem Value="1">شحن أكسبريس</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="right" style="width: 175px;">
                                <asp:DropDownList ID="ddlShipType2" runat="server" Visible="false" 
                                    AutoPostBack="True" onselectedindexchanged="ddlShipType2_SelectedIndexChanged" >
                                    <asp:ListItem Value="1">سطحة عادية</asp:ListItem>
                                    <asp:ListItem Value="2">سطحة هيدلوريك</asp:ListItem>
                                    <asp:ListItem Value="3">سطحة هيدلوريك مغطى</asp:ListItem>
                                </asp:DropDownList>                                
                            </td>
                            <td align="left" style="width: 300px;" colspan="3">
                                <asp:Label ID="Label31" runat="server" Text="عدد السيارات"></asp:Label>&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlQty" Width="50px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQty_SelectedIndexChanged">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>&nbsp;&nbsp;
                                <asp:Button ID="BtnCopy" runat="server" Text="نسـخ" onclick="BtnCopy_Click" />
                            
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" 
                        Width="99.9%" EmptyDataText="لا توجد بيانات">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="نوع السيارة" SortExpression="CarType" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlCarType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCarType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ControlStyle Width="100px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الطراز" SortExpression="Model" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlModel" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ControlStyle Width="180px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الموديل" SortExpression="Brand" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBrand" Text='<%# Bind("Brand") %>' MaxLength="11" runat="server"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم اللوحه" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPlateNo" Text='<%# Bind("PlateNo") %>' MaxLength="10" runat="server"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم الهيكل" SortExpression="ChassisNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtChassisNo" Text='<%# Bind("ChassisNo") %>' MaxLength="15" runat="server"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="اللون" SortExpression="Color" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtColor" Text='<%# Bind("Color") %>' MaxLength="15" runat="server"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100px"></ControlStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="السعر" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrice" Text='<%# Bind("Price") %>' MaxLength="15" runat="server"
                                    AutoPostBack="True" ontextchanged="txtPrice_TextChanged"></asp:TextBox>
                                    <asp:HiddenField ID="txtPrice2" runat="server" />
                                <asp:RequiredFieldValidator ID="ValAmount1" runat="server" ControlToValidate="txtPrice"
                                    Display="Dynamic" ErrorMessage="يجب أدخال قيمة الشحن" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="ValAmount2" runat="server" ClientValidationFunction="CheckItemO"
                                    ControlToValidate="txtPrice" ErrorMessage="لقد تجاوزت الحد الادنى للسعر" ForeColor="Red"
                                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="1" 
                                        onservervalidate="ValAmount2_ServerValidate">تجاوزت</asp:CustomValidator>
                                <asp:CompareValidator ID="ValAmount3" runat="server" ControlToValidate="txtPrice"
                                    ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" Type="Currency" ValidationGroup="1" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="100px"></ControlStyle>
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
                        <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>
                        <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>
                        <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>
                        <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                    <table width="99.9%" cellpadding="3" cellspacing="0">                     
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:Label ID="Label16" runat="server" Text="كود الخصم"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;">
                                 <asp:TextBox ID="txtDiscountTerm" MaxLength="20" runat="server"></asp:TextBox>
                                   <asp:ImageButton ID="BtnDiscountTerm" runat="server" ValidationGroup="550" ImageUrl="~/images/zoom_16.png"
                                                ToolTip="البحث عن بيانات كود الخصم" 
                                     onclick="BtnDiscountTerm_Click" />
                                            <asp:Label ID="lblErrDiscountTerm" runat="server" ForeColor="Red" Text=" "></asp:Label>

                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label12" runat="server" Text="قيمة الخصم"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="2">                             
                                <asp:TextBox ID="txtDiscount" MaxLength="15" ReadOnly="false" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDiscount"
                                    ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" Type="Currency" ValidationGroup="1" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                            </td>
                            <td align="right" style="width: 300px;">
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label18" runat="server" Text="الصافي"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="2">                             
                                <asp:TextBox ID="txtTotal" ReadOnly="true" MaxLength="15" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                            </td>
                            <td align="right" style="width: 300px;">
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="LblTax" runat="server" Text="5% الضريبة"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="2">                             
                                <asp:TextBox ID="txtTax" ReadOnly="true" MaxLength="15" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:DropDownList ID="ddlPayment" Width="100px" Visible = "false" runat="server">
                                    <asp:ListItem Value="0">نقداً بمبلغ</asp:ListItem>
                                    <asp:ListItem Value="2">شبكة بمبلغ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:TextBox ID="txtCashAmount" MaxLength="15" Visible="false" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="ValCashAmount2" Enabled="false"  runat="server" ControlToValidate="txtCashAmount"
                                    ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" Type="Currency" ValidationGroup="1" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label32" runat="server" Text="الاجمالي"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="2">                             
                                <asp:TextBox ID="txtTotNet" ReadOnly="true" MaxLength="15" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:Label ID="Label17" runat="server" Text="فرع الشحن"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:DropDownList ID="ddlSite" Width="275" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label23" runat="server" Text="المبلغ"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="2">
                                <asp:TextBox ID="txtSiteAmount" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:CustomValidator ID="ValSiteAmount1" runat="server" ClientValidationFunction="CheckItem1"
                                    ControlToValidate="txtSiteAmount" ErrorMessage="المبلغ لا يغطي قيمة الشحن" ForeColor="Red"
                                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="1">المبلغ غير كاف</asp:CustomValidator>
                                <asp:CompareValidator ID="ValSiteAmount2" runat="server" ControlToValidate="txtSiteAmount"
                                    ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" Type="Currency" ValidationGroup="1" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px;">
                                <asp:Label ID="Label24" runat="server" Text="على حساب العميل"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;">
                                <asp:DropDownList ID="ddlCustomers" Width="275" runat="server" AutoPostBack="True" onselectedindexchanged="ddlCustomers_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 175px;">
                                <asp:Label ID="Label25" runat="server" Text="المبلغ"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px;" colspan="2">
                                <asp:TextBox ID="txtCustomerAmount" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:CustomValidator ID="ValCustomerAmount1" runat="server" ClientValidationFunction="CheckItem2"
                                    ControlToValidate="txtCustomerAmount" ErrorMessage="المبلغ لا يغطي قيمة الشحن"
                                    ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ValidationGroup="1">المبلغ غير كاف</asp:CustomValidator>
                                <asp:CompareValidator ID="ValCustomerAmount2" runat="server" ControlToValidate="txtCustomerAmount"
                                    ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                                    Display="Dynamic" Type="Currency" ValidationGroup="1" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </td>
                        </tr>
                    </table>          
                    <table width="99.9%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="Label22" runat="server" Text="ملاحظات أخرى"></asp:Label>
                            </td>
                            <td align="right" style="width: 300px">
                                <asp:TextBox ID="txtRemark1" MaxLength="100" runat="server" Width="275px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 150px">
                            </td>
                            <td align="right" style="width: 300px">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 150px">
                                <asp:Label ID="Label29" runat="server" Text="المرفقات"></asp:Label>
                            </td>
                            <td align="right" colspan="3">
                                <asp:TextBox ID="txtAttached" MaxLength="200" runat="server" Width="735px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table id="Table2" width="100%" cellpadding="0" cellspacing="0">
                        <tr align="right">
                            <td style="width: 120px;">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtUserName" Width="285px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ"></asp:Label>
                            </td>
                            <td style="width: 250px;">
                                <asp:TextBox ID="txtUserDate" Width="150px" runat="server" MaxLength="50" BackColor="#E8E8E8" CssClass="MouseStop"
                                    Enabled="false"> </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                            </td>
                        </tr>
                        <tr align="right">
                            <td style="width: 120px;">
                                <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtReason" Width="285px" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 70px;">
                            </td>
                            <td style="width: 250px;">
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <div style="text-align: left; padding-left: 10px">
                                    <asp:LinkButton ID="BtnPrint2" runat="server" OnClick="BtnPrint2_Click">طباعة الشروط</asp:LinkButton>
                                </div>
                            </td>
                        </tr>
                        <tr align="right">
                            <td colspan="4" style="text-align: center">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4" style="width: 100%;">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/insource_642.png"   ToolTip="أضافة سند جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات السند؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات السند"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/erasure_642.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/cut_642.png"   ToolTip="إلغاء بيانات السند" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات السند؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/binoculars_642.png"   ToolTip="البحث عن بيانات السند"
                                    OnClick="BtnSearch_Click" />
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print_64A.png" ValidationGroup="1"   ToolTip="طباعة السند"
                                    OnClick="BtnPrint_Click" />
                                <asp:CheckBox ID="ChkDoubleSide" Text="طباعة وجهين" Checked="true" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </center>
                <div style="text-align: left; width: 50%; float: left;">
                    <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                        Direction="RightToLeft" ForeColor="#FFFF99">
                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                                المرفقات</div>
                            <div style="float: right; margin-right: 20px;">
                                <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
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
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                          ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                        ValidationGroup="1" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                        SuppressPostBack="true" />
                </div>
            </fieldset>
        </div>
        <asp:HiddenField ID="HImgAccess" Value = "111111111111111111" runat="server" />
        <asp:HiddenField ID="HImgS" Value = "11111111111111111111111111111111111111" runat="server" />
    </center>
</asp:Content>
