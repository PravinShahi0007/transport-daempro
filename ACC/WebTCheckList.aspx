<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebTCheckList.aspx.cs" Inherits="ACC.WebTCheckList" Culture="en-GB"
    UICulture="en-GB" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function Plate_itemSelected(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtCarNo');
            //var ace2Value = $get('ContentPlaceHolder1_txtPlateNo');
            var x = e.get_value().split(' . ');
            ace1Value.value = x[0];
            //ace2Value.value = x[1];
            return false;
        }


        function CheckImg2(senderID) {
            var sender = document.getElementById(senderID);
            var HImgAccess = document.getElementById('<%=HImgS.ClientID %>');            
            var s = HImgAccess.value;
            var s1 = "";
            var pos = parseInt(senderID.replace("ContentPlaceHolder1_Img", "")) - 1;
            if (sender) {
                if (sender.src.indexOf("True2") >= 0) {
                    sender.src = sender.src.replace("True2", "False");
                    s1 = s.substring(0, pos) + "2" + s.substring(pos + 1, s.length);
                }
                else if (sender.src.indexOf("False") >= 0) {
                    sender.src = sender.src.replace("False", "Miss");
                    s1 = s.substring(0, pos) + "3" + s.substring(pos + 1, s.length);
                }
                else if (sender.src.indexOf("Miss") >= 0) {
                    sender.src = sender.src.replace("Miss", "True");
                    s1 = s.substring(0, pos) + "0" + s.substring(pos + 1, s.length);
                }
                else {
                    sender.src = sender.src.replace("True", "True2");
                    s1 = s.substring(0, pos) + "1" + s.substring(pos + 1, s.length);
                }
                HImgAccess.value = s1;
            }
        }

        function CheckImgS(senderID) {
            var sender = document.getElementById(senderID);
            var HImgAccess = document.getElementById('<%=HImgS.ClientID %>');           
            var s1 = "";
            for (i = 1; i < 10; i++) {
                var HImgAccess = document.getElementById('ContentPlaceHolder1_ImgS0' + i.toString());
                HImgAccess.src = sender.src;
                if (sender.src.indexOf("True2") >= 0) {
                    s1 = s1 + "1";
                }
                else if (sender.src.indexOf("False") >= 0) {
                    s1 = s1 + "2"; 
                }
                else if (sender.src.indexOf("Miss") >= 0) {
                    s1 = s1 + "3";
                }
                else {
                    s1 = s1 + "0";
                }
            }

            for (i = 10; i < 57; i++) {
                var HImgAccess = document.getElementById('ContentPlaceHolder1_ImgS' + i.toString());
                HImgAccess.src = sender.src;
                if (sender.src.indexOf("True2") >= 0) {
                    s1 = s1 + "1";
                }
                else if (sender.src.indexOf("False") >= 0) {
                    s1 = s1 + "2";
                }
                else if (sender.src.indexOf("Miss") >= 0) {
                    s1 = s1 + "3";
                }
                else {
                    s1 = s1 + "0";
                }
            }

            HImgAccess.value = s1;            
        }

        function CheckImg(senderID) {
            var sender = document.getElementById(senderID);
            var HImgAccess2 = document.getElementById('<%=HImgS.ClientID %>');
            var s1 = "";
            for (i = 1; i < 10; i++) {
                var HImgAccess = document.getElementById('ContentPlaceHolder1_Img0' + i.toString());
                HImgAccess.src = sender.src;
                if (sender.src.indexOf("True2") >= 0) {
                    s1 = s1 + "1";
                }
                else if (sender.src.indexOf("False") >= 0) {
                    s1 = s1 + "2";
                }
                else if (sender.src.indexOf("Miss") >= 0) {
                    s1 = s1 + "3";
                }
                else {
                    s1 = s1 + "0";
                }
            }

            for (i = 10; i < 57; i++) {
                var HImgAccess = document.getElementById('ContentPlaceHolder1_Img' + i.toString());
                HImgAccess.src = sender.src;
                if (sender.src.indexOf("True2") >= 0) {
                    s1 = s1 + "1";
                }
                else if (sender.src.indexOf("False") >= 0) {
                    s1 = s1 + "2";
                }
                else if (sender.src.indexOf("Miss") >= 0) {
                    s1 = s1 + "3";
                }
                else {
                    s1 = s1 + "0";
                }
            }
            HImgAccess2.value = s1;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                    <b>
                        <asp:Literal ID="lblHeader" runat="server" Text="[ Vehical Movement Check List ]"
                            meta:resourcekey="lblHeader"></asp:Literal></b></legend>
                <table width="99%" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="lblChNo" runat="server" Text="Check List No." meta:resourcekey="lblChNo"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                ToolTip="Search for Request No." OnClick="BtnFind_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVouNo"
                                Display="Dynamic" ErrorMessage="<%$ Resources:EnterCheckList %>" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="lblType" runat="server" Text="Type" meta:resourcekey="lblType"></asp:Label>
                            *
                        </td>
                        <td style="width: 35%;">
                            <asp:RadioButtonList ID="rdoType" runat="server" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="rdoType_SelectedIndexChanged"
                                RepeatColumns="3" Width="90%">
                                <asp:ListItem Selected="True" Value="1" Text="<%$ Resources:CheckType1 %>"></asp:ListItem>
                                <asp:ListItem Value="2" Text="<%$ Resources:CheckType2 %>"></asp:ListItem>
                                <asp:ListItem Value="3" Text="<%$ Resources:CheckType3 %>"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="lblDate" runat="server" Text="Date - Time" meta:resourcekey="lblDate"></asp:Label>
                            *
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                Display="Dynamic" ErrorMessage="<%$ Resources:EnterDate %>" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="<%$ Resources:CheckDate %>"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />
                            <asp:TextBox ID="txtInTime" runat="server" Text="00:00" MaxLength="8" Width="60px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtInTime"
                                Mask="99:99" MaskType="Time" CultureName="en-us" MessageValidatorTip="true" runat="server">
                            </ajaxToolkit:MaskedEditExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInTime"
                                Display="Dynamic" ErrorMessage="<%$ Resources:EnterTime %>" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="lblCode" runat="server" Text="Vehicle Type" meta:resourcekey="lblCode"></asp:Label>*
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlVehType" Width="250" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlVehType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="lblVNo" runat="server" Text="Vehicle/No." meta:resourcekey="lblVNo"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlVehicle" Width="200" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlVehicle_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtCarNo" MaxLength="15" Width="80px" autocomplete="off" runat="server"
                                AutoPostBack="True" OnTextChanged="txtCarNo_TextChanged"></asp:TextBox>
                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender03" runat="server" TargetControlID="txtCarNo"
                                ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars21" OnClientItemSelected="Plate_itemSelected"
                                MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="lblModel" runat="server" Text="Model" meta:resourcekey="lblModel"></asp:Label>*
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtModel" MaxLength="20" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label2" runat="server" Text="From" meta:resourcekey="lblIssuance"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlPCheck" Width="250" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlPCheck_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15%;">
                        </td>
                        <td style="width: 35%;">
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="lblFrom" runat="server" Text="From" meta:resourcekey="lblFrom"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlFrom" Width="250" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFrom_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="lblTo" runat="server" Text="To" meta:resourcekey="lblTo"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlTo" Width="250" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            &nbsp;
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtFrom2" MaxLength="50" Width="200px" Visible="false" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtTo2" MaxLength="50" Width="200px" Visible="false" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div id="Model1" runat="server">
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td style="width: 15%;">
                                <asp:Label ID="lbleType" runat="server" Text="Engine Type" meta:resourcekey="lbleType"></asp:Label>
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtEngineType" MaxLength="30" Width="200px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%;">
                                <asp:Label ID="lbleNo" runat="server" Text="Engine S.No." meta:resourcekey="lbleNo"></asp:Label>
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtEngineSNo" MaxLength="30" Width="200px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%;">
                                <asp:Label ID="lblGBox" runat="server" Text="Gear Box Type" meta:resourcekey="lblGBox"></asp:Label>
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtGearType" MaxLength="30" Width="200px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%;">
                                <asp:Label ID="lblGBoxNo" runat="server" Text="Gear Box S.No." meta:resourcekey="lblGBoxNo"></asp:Label>
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtGearSNo" MaxLength="30" Width="200px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%;">
                                <asp:Label ID="lblAcType" runat="server" Text="A.C. Type" meta:resourcekey="lblAcType"></asp:Label>
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtACType" MaxLength="30" Width="200px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%;">
                                <asp:Label ID="lblAcNo" runat="server" Text="A.C. S.No." meta:resourcekey="lblAcNo"></asp:Label>
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtACSNo" MaxLength="30" Width="200px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%;">
                                <asp:Label ID="lblPumpType" runat="server" Text="Injection Pump Type" meta:resourcekey="lblPumpType"></asp:Label>
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtIPType" MaxLength="30" Width="200px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%;">
                                <asp:Label ID="lblPumpNo" runat="server" Text="Injection Pump S.No." meta:resourcekey="lblPumpNo"></asp:Label>
                            </td>
                            <td style="width: 35%;">
                                <asp:TextBox ID="txtIPSNo" MaxLength="30" Width="200px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <table class="box-table-a" width="99.5%">
                    <tbody>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblSL" runat="server" Text="SL." meta:resourcekey="lblSL"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <strong>
                                    <asp:Label ID="lblDescr" runat="server" Text="Description" meta:resourcekey="lblDescr"></asp:Label></strong>
                            </td>
                            <td style="width: 180px">                        
                                <strong>
                                    <asp:Label ID="lblIssuance" runat="server" Text="Previous Check" meta:resourcekey="lblIssuance"></asp:Label></strong>
                            </td>
                            <td style="width: 20px">                        
                                 <asp:LinkButton ID="BtnSame" ToolTip="نفس الفحص السابق" Visible="false" 
                                     runat="server" onclick="BtnSame_Click" ><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img57" runat="server" src="~/images/True.gif" alt="True" onclick="Javascript:CheckImg(this.id);" />
                                <img id="Img61" runat="server" src="~/images/True2.gif" alt="Empty" onclick="Javascript:CheckImg(this.id);" />
                                <img id="Img62" runat="server" src="~/images/False.gif" alt="False" onclick="Javascript:CheckImg(this.id);" />
                                <img id="Img63" runat="server" src="~/images/Miss.gif" alt="Miss" onclick="Javascript:CheckImg(this.id);" />
                                <strong>
                                    <asp:Label ID="lblTurnOver" runat="server" Text="Current Check" meta:resourcekey="lblTurnOver"></asp:Label></strong>
                            </td>
                            <td style="width: 70px;">
                                <strong>
                                    <asp:Label ID="lblPhoto" runat="server" Text="Photo" meta:resourcekey="lblPhoto"></asp:Label></strong>
                            </td>
                            <td style="width: 50px;">
                                <strong>
                                    <asp:Label ID="lblUpload" runat="server" Text="Upload" meta:resourcekey="lblUpload"></asp:Label></strong>
                            </td>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblView" runat="server" Text="View" meta:resourcekey="lblView"></asp:Label></strong>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo01" runat="server" Text="1"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem01" runat="server" Text="K.M. READING" Width="175px" meta:resourcekey="lblSItem01"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS01" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem00" MaxLength="50" Width="70px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtSItem01" MaxLength="50" Width="70px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS01" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img01" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:DropDownList ID="ddlItem00" Width="87px" runat="server"></asp:DropDownList>
                                <asp:TextBox ID="txtItem01" MaxLength="50" Width="75px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld01" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad01" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView001" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo02" runat="server" Text="2"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem02" runat="server" Text="PLATES NUMBER" meta:resourcekey="lblSItem02"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS02" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem02" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS02" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img02" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem02" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld02" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad02" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView002" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo03" runat="server" Text="3"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem03" runat="server" Text="DOORS KEYS" meta:resourcekey="lblSItem03"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS03" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem03" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS03" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img03" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem03" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld03" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad03" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView003" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo04" runat="server" Text="4"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem04" runat="server" Text="ING. KEYS" meta:resourcekey="lblSItem04"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS04" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem04" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS04" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img04" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem04" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld04" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad04" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView004" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo05" runat="server" Text="5"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem05" runat="server" Text="TRUCK LICENCE" meta:resourcekey="lblSItem05"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS05" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem05" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS05" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img05" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem05" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld05" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad05" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView005" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo06" runat="server" Text="6"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem06" runat="server" Text="TRANSPORT PERMIT" meta:resourcekey="lblSItem06"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS06" runat="server" src="~/images/True.gif" alt="" class="MouseStop"/>
                                <asp:TextBox ID="txtSItem06" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS06" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img06" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem06" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld06" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad06" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView006" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo07" runat="server" Text="7"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem07" runat="server" Text="BODY" meta:resourcekey="lblSItem07"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS07" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem07" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS07" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img07" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem07" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld07" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad07" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView007" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo08" runat="server" Text="8"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem08" runat="server" Text="UPER WIND BLIZER" meta:resourcekey="lblSItem08"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS08" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem08" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS08" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img08" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem08" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld08" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad08" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView008" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo09" runat="server" Text="9"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem09" runat="server" Text="R/H SIDEN BLIZER" meta:resourcekey="lblSItem09"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS09" runat="server" src="~/images/True.gif" alt="" class="MouseStop"/>
                                <asp:TextBox ID="txtSItem09" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS09" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img09" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem09" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld09" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad09" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView009" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo10" runat="server" Text="10"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem10" runat="server" Text="L/H SIDEN BLIZER" meta:resourcekey="lblSItem10"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS10" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem10" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS10" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img10" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem10" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld10" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad10" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView010" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo11" runat="server" Text="11"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem11" runat="server" Text="WIND SHIELD" meta:resourcekey="lblSItem11"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS11" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem11" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS11" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img11" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem11" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld11" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad11" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView011" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo12" runat="server" Text="12"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem12" runat="server" Text="FRONT BUMBER UPER" meta:resourcekey="lblSItem12"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS12" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem12" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS12" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img12" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem12" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld12" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad12" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView012" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo13" runat="server" Text="13"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem13" runat="server" Text="FRONT BUMBER LOWER" meta:resourcekey="lblSItem13"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS13" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem13" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS13" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img13" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem13" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld13" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad13" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView013" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo14" runat="server" Text="14"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem14" runat="server" Text="R/H SIDE HEAD LIGHT" meta:resourcekey="lblSItem14"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS14" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem14" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS14" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img14" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem14" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld14" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad14" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView014" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo15" runat="server" Text="15"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem15" runat="server" Text="L/H SIDE HEAD LIGHT" meta:resourcekey="lblSItem15"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS15" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem15" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS15" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img15" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem15" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld15" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad15" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView015" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo16" runat="server" Text="16"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem16" runat="server" Text="FORNT GIEAL" meta:resourcekey="lblSItem16"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS16" runat="server" src="~/images/True.gif" alt="" class="MouseStop"/>
                                <asp:TextBox ID="txtSItem16" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS16" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img16" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem16" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld16" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad16" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView016" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo17" runat="server" Text="17"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem17" runat="server" Text="FRONT R/H SIDE SIGNAL" meta:resourcekey="lblSItem17"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS17" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem17" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS17" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img17" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem17" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld17" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad17" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView017" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo18" runat="server" Text="18"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem18" runat="server" Text="FRONT L/H SIDE SIGNAL" meta:resourcekey="lblSItem18"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS18" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem18" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS18" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img18" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem18" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld18" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad18" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView018" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo19" runat="server" Text="19"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem19" runat="server" Text="R/H SIDE DOOR" meta:resourcekey="lblSItem19"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS19" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem19" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS19" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img19" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem19" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld19" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad19" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView019" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo20" runat="server" Text="20"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem20" runat="server" Text="L/H SIDE DOOR" meta:resourcekey="lblSItem20"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS20" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem20" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop" ></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS20" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img20" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem20" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld20" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad20" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView020" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo21" runat="server" Text="21"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem21" runat="server" Text="R/H SIDE MIRROR" meta:resourcekey="lblSItem21"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS21" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem21" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS21" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img21" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem21" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld21" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad21" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView021" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo22" runat="server" Text="22"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem22" runat="server" Text="L/H SIDE MIRROR" meta:resourcekey="lblSItem22"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS22" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem22" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop" ></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS22" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img22" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem22" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld22" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad22" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView022" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo23" runat="server" Text="23"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem23" runat="server" Text="ADDITIONAL MIRROR DOOR" meta:resourcekey="lblSItem23"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS23" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem23" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS23" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img23" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem23" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld23" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad23" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView023" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo24" runat="server" Text="24"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem24" runat="server" Text="WIPER BALD R" meta:resourcekey="lblSItem24"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS24" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem24" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS24" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img24" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem24" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld24" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad24" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView024" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo25" runat="server" Text="25"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem25" runat="server" Text="WIPER BALD L" meta:resourcekey="lblSItem25"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS25" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem25" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS25" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img25" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem25" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld25" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad25" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView025" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo26" runat="server" Text="26"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem26" runat="server" Text="R HAND DOOR STEP LADER" meta:resourcekey="lblSItem26"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS26" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem26" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS26" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img26" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem26" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld26" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad26" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView026" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo27" runat="server" Text="27"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem27" runat="server" Text="L HAND DOOR STEP LADER" meta:resourcekey="lblSItem27"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS27" runat="server" src="~/images/True.gif" alt=""  class="MouseStop" />
                                <asp:TextBox ID="txtSItem27" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop" ></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS27" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img27" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem27" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld27" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad27" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView027" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo28" runat="server" Text="28"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem28" runat="server" Text="CABINT" meta:resourcekey="lblSItem28"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS28" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem28" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS28" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img28" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem28" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld28" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad28" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView028" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo29" runat="server" Text="29"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem29" runat="server" Text="RADIO & STERIO" meta:resourcekey="lblSItem29"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS29" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem29" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS29" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img29" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem29" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld29" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad29" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView029" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo30" runat="server" Text="30"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem30" runat="server" Text="CABINETR CURTAINS" meta:resourcekey="lblSItem30"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS30" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem30" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS30" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img30" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem30" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld30" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad30" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView030" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo31" runat="server" Text="31"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem31" runat="server" Text="BEDS & SEATS" meta:resourcekey="lblSItem31"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS31" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem31" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS31" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img31" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem31" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld31" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad31" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView031" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo32" runat="server" Text="32"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem32" runat="server" Text="AIR CONDITION UNIT" meta:resourcekey="lblSItem32"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS32" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem32" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS32" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img32" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem32" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld32" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad32" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView032" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo33" runat="server" Text="33"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem33" runat="server" Text="R/H SIDE TAIL LIGHTS" meta:resourcekey="lblSItem33"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS33" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem33" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS33" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img33" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem33" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld33" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad33" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView033" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo34" runat="server" Text="34"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem34" runat="server" Text="L/H SIDE TAIL LIGHTS" meta:resourcekey="lblSItem34"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS34" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem34" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS34" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img34" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem34" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld34" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad34" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView034" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo35" runat="server" Text="35"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem35" runat="server" Text="R/Rubber Mud Gurad" meta:resourcekey="lblSItem35"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS35" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem35" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS35" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img35" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem35" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld35" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad35" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView035" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo36" runat="server" Text="36"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem36" runat="server" Text="L/Rubber Mud Gurad" meta:resourcekey="lblSItem36"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS36" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem36" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS36" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img36" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem36" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld36" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad36" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView036" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo37" runat="server" Text="37"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem37" runat="server" Text="MAIN FUEL TANK" meta:resourcekey="lblSItem37"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS37" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem37" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop" ></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS37" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img37" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem37" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld37" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad37" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView037" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo38" runat="server" Text="38"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lbSlItem38" runat="server" Text="ADDITIONAL FUEL TANK" meta:resourcekey="lblSItem38"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS38" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem38" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS38" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img38" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem38" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld38" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad38" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView038" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px;">
                                <strong>
                                    <asp:Label ID="lblNo39" runat="server" Text="39"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem39" runat="server" Text="BATTERYS COVER" meta:resourcekey="lblSItem39"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS39" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem39" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS39" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img39" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem39" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld39" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad39" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView039" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo40" runat="server" Text="40"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem40" runat="server" Text="ELECTRIC CABLES" meta:resourcekey="lblSItem40"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS40" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem40" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS40" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img40" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem40" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld40" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad40" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView040" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo41" runat="server" Text="41"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem41" runat="server" Text="JACK" meta:resourcekey="lblSItem41"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS41" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem41" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS41" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img41" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem41" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld41" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad41" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView041" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo42" runat="server" Text="42"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem42" runat="server" Text="FIRE EXTINGUISHER" meta:resourcekey="lblSItem42"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS42" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem42" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS42" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img42" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem42" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld42" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad42" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView042" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo43" runat="server" Text="43"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem43" runat="server" Text="EARLY WARNING" meta:resourcekey="lblSItem43"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS43" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem43" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS43" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img43" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem43" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld43" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad43" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView043" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo44" runat="server" Text="44"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem44" runat="server" Text="SPARE TIERS" meta:resourcekey="lblSItem44"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS44" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem44" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS44" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img44" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem44" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld44" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad44" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView044" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo45" runat="server" Text="45"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem45" runat="server" Text="TOOLS" meta:resourcekey="lblSItem45"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS45" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem45" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS45" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img45" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem45" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld45" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad45" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView045" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo46" runat="server" Text="46"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem46" runat="server" Text="OTHER ACCESSORIES" meta:resourcekey="lblSItem46"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS46" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem46" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS46" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img46" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem46" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld46" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad46" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView046" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo47" runat="server" Text="47"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem47" runat="server" Text="REMARKS" meta:resourcekey="lblSItem47"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS47" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem47" MaxLength="50" Width="150px" runat="server" ReadOnly="true" CssClass="MouseStop"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS47" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img47" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem47" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld47" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad47" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView047" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo48" runat="server" Text="48"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem48" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem48"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS48" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem48" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS48" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img48" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem48" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld48" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad48" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView048" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo49" runat="server" Text="49"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem49" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem49"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS49" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem49" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS49" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img49" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem49" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld49" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad49" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView049" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo50" runat="server" Text="50"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem50" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem50"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS50" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem50" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS50" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img50" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem50" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld50" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad50" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView050" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo51" runat="server" Text="51"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem51" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem51"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS51" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem51" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS51" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img51" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem51" MaxLength="50" Width="160px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld51" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad51" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView051" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo52" runat="server" Text="52"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem52" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem52"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS52" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem52" Height="60px" TextMode="MultiLine" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS52" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img52" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem52" Height="60px" TextMode="MultiLine" MaxLength="50" Width="160px"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld52" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad52" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView052" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo53" runat="server" Text="53"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem53" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem53"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS53" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem53" Height="60px" TextMode="MultiLine" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS53" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img53" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem53" Height="60px" TextMode="MultiLine" MaxLength="50" Width="160px"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld53" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad53" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView053" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo54" runat="server" Text="54"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem54" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem54"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS54" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem54" Height="60px" TextMode="MultiLine" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS54" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img54" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem54" Height="60px" TextMode="MultiLine" MaxLength="50" Width="160px"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld54" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad54" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView054" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo55" runat="server" Text="55"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem55" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem55"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS55" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem55" Height="60px" TextMode="MultiLine" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS55" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>                                
                            </td>
                            <td style="width: 200px">
                                <img id="Img55" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem55" Height="60px" TextMode="MultiLine" MaxLength="50" Width="160px"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld55" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad55" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView055" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="lblNo56" runat="server" Text="56"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblSItem56" runat="server" Text="ATTACHMENTS" meta:resourcekey="lblSItem56"></asp:Label>
                            </td>
                            <td style="width: 180px">
                                <img id="ImgS56" runat="server" src="~/images/True.gif" alt="" class="MouseStop" />
                                <asp:TextBox ID="txtSItem56" Height="60px" TextMode="MultiLine" MaxLength="50" Width="150px" ReadOnly="true" CssClass="MouseStop"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 20px">
                                <asp:LinkButton ID="BtnViewS56" Visible="false" runat="server" OnClientClick="aspnetForm.target ='_blank';"><i class="fa fa-picture-o" ></i></asp:LinkButton>
                            </td>
                            <td style="width: 200px">
                                <img id="Img56" runat="server" src="~/images/True.gif" alt="" onclick="Javascript:CheckImg2(this.id);" />
                                <asp:TextBox ID="txtItem56" Height="60px" TextMode="MultiLine" MaxLength="50" Width="160px"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px;">
                                <asp:FileUpload ID="Fld56" Width="70px" runat="server" />
                            </td>
                            <td style="width: 50px;">
                                <asp:Button ID="BtnLoad56" Width="50px" runat="server" Text="تحميل" OnClick="BtnLoad1_Click"
                                    meta:resourcekey="BtnLoad01" />
                            </td>
                            <td style="width: 40px;">
                                <asp:LinkButton ID="BtnView056" Width="40px" Visible="false" runat="server" Text="عرض"
                                    OnClientClick="aspnetForm.target ='_blank';" meta:resourcekey="BtnView01" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                                <strong>
                                    <asp:Label ID="Label1" runat="server" Text="*"></asp:Label></strong>
                            </td>
                            <td style="width: 175px;">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks" meta:resourcekey="lblRemarks"></asp:Label>
                            </td>
                            <td style="width: 560px" colspan="5">
                                <asp:TextBox ID="txtRemarks" Height="100px" TextMode="MultiLine" MaxLength="500"
                                    Width="560px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table width="99%" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="lblUserName" runat="server" Text="User Name" meta:resourcekey="lblUserName"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtUserName" Width="300px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="lblUserDate" runat="server" Text="Date" meta:resourcekey="lblUserDate"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtUserDate" Width="100px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                Enabled="false">                                                               
                            </asp:TextBox>
                            <asp:Label ID="lblFields" runat="server" Text="* Required Fields" meta:resourcekey="lblFields"></asp:Label>
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
                        <asp:ImageButton ID="BtnNew" runat="server" AlternateText="New" CommandName="New"
                            ImageUrl="<%$ Resources:NewImage %>" CssClass="ops" ToolTip="<%$ Resources:NewToolTip %>"
                            ValidationGroup="1" OnClientClick='<%$ Resources:NewConfirm %>' OnClick="BtnNew_Click" />
                        <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                            ImageUrl="<%$ Resources:EditImage %>" CssClass="ops" ToolTip="<%$ Resources:EditToolTip %>"
                            Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                        <asp:ImageButton ID="BtnClear" runat="server" AlternateText="Clear" CommandName="Clear"
                            ImageUrl="<%$ Resources:ClearImage %>" CssClass="ops" ToolTip="<%$ Resources:ClearToolTip %>"
                            OnClick="BtnClear_Click" />
                        <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="Delete" CommandName="Delete"
                            ImageUrl="<%$ Resources:DeleteImage %>" CssClass="ops" ToolTip="<%$ Resources:DeleteToolTip %>"
                            OnClientClick='<%$ Resources:DeleteConfirm %>' OnClick="BtnDelete_Click" />
                        <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="Find" CommandName="Find"
                            ImageUrl="<%$ Resources:SearchImage %>" CssClass="ops" ToolTip="<%$ Resources:SearchToolTip %>"
                            OnClick="BtnSearch_Click" />
                        <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="Print" CommandName="Print"
                            ImageUrl="<%$ Resources:PrintImage %>" ValidationGroup="1" CssClass="ops" ToolTip="<%$ Resources:PrintToolTip %>"
                            OnClick="BtnPrint_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="VouNo,VouType" AllowPaging="True"
                    PageSize="20" Width="99.9%" EmptyDataText="<%$ Resources:NoData %>" OnPageIndexChanging="grdCodes_PageIndexChanging"
                    OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات بيان التسليم والاستلام"
                                    ImageUrl="~/images/arrow_undo.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:lblChNo.Text %>" SortExpression="VouNo"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVouNo" Text='<%# Bind("VouNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:lblUserDate.Text %>" SortExpression="VouDate"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVoudate" Text='<%# Bind("VouDate") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:lblType.Text %>" SortExpression="VouType2"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbVouType2" Text='<%# Bind("VouType2") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="250px" />
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
            <div style="text-align: right; width: 50%;">
                <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                    Direction="LeftToRight" ForeColor="#FFFF99">
                    <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left;">
                            <asp:Label ID="lblAttach" runat="server" Text="Attach Files" meta:resourcekey="lblAttach"></asp:Label>
                        </div>
                        <div style="float: left; margin-right: 20px;">
                            <asp:Label ID="Label34" runat="server" Text="<%$ Resources:ShowDetails %>"></asp:Label>
                        </div>
                        <div style="float: right; vertical-align: middle;">
                            <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="<%$ Resources:ShowDetails %>" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#5D7B9D" Width="99.3%"
                    BorderColor="Maroon">
                    <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowHeader="False"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="<%$ Resources:DeleteFileToolTip %>"
                                        ImageUrl="~/images/cross.png" OnClientClick='<%$ Resources:DeleteFileConfirm %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:File %>" ItemStyle-HorizontalAlign="Center">
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
                                    CssClass="ops" ImageUrl="<%$ Resources:AttachImage %>" ToolTip="<%$ Resources:AttachToolTip %>"
                                    ValidationGroup="1" OnClick="BtnAttach_Click" />
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
    <asp:HiddenField ID="HImgS" Value="000000000000000000000000000000000000000000000000000000000000" runat="server" />
</asp:Content>
