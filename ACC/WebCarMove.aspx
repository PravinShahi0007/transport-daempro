<%@ Page Title="بيان الترحيل" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebCarMove.aspx.cs" Inherits="ACC.WebCarMove" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?region=SA&language=ar&key=AIzaSyA9M8YZRpuxDNFZepVCOQ1wjGmMofe1MVA&libraries=places&callback=initAutocomplete" async defer></script>

    <script type="text/javascript">
        //        function pageLoad(sender, args) {
        //            var serviceDistance = new google.maps.DistanceMatrixService;
        //            alert("111111");
        //            var origin2 = new google.maps.LatLng(46.8044106,24.7262807);  //'Greenwich, England';
        //            alert("");
        //            var destinationB = new google.maps.LatLng(39.009165,26.396809);   // 'Stockholm, Sweden';
        //            alert("check2");
        //            serviceDistance.getDistanceMatrix({
        //                origins: [origin2],
        //                destinations: [destinationB],
        //                travelMode: google.maps.TravelMode.DRIVING,
        //                unitSystem: google.maps.UnitSystem.METRIC,
        //                avoidHighways: false,
        //                avoidTolls: false
        //            }, callback);
        //        }
        //            
        //   
        //        function callback (response, status) {
        //                if (status === google.maps.DistanceMatrixStatus.OK) {
        //                    //var results = response.rows[1].elements;
        //                    var mydist = response.rows[0].elements[0].distance.text;
        //                    var mytime = response.rows[0].elements[0].duration.text;
        //                    alert(mydist + " " + mytime);
        //                }
        //                else { alert('444444444444444444444444444444'); }
        //            };



        function ace1_itemSelectedCars(sender, e) {
            var ace1Value = $get('ContentPlaceHolder1_txtSearch2');
            ace1Value.value = e.get_value();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <fieldset class="card">
        <div class="card-header">
            <h4>[ بيان الترحيل ]</h4>
        </div>

        <br />
        <div class="card-body">
            <div class="form-row">

                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Button ID="Button1" runat="server" Text="Button" Visible="false" OnClick="Button1_Click" />
                    <asp:TextBox ID="txtSearch" MaxLength="10" Width="100px" placeholder="بحث" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                        ToolTip="البحث عن بيانات بيان الترحيل" OnClick="BtnFind_Click" />



                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:CheckBox ID="ChkRent" runat="server" Text="شاحنة مستاجرة"
                        AutoPostBack="True" OnCheckedChanged="ChkRent_CheckedChanged" />

                    &nbsp;&nbsp;&nbsp;
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" CssClass="MouseStop form-control"></asp:TextBox>
                    <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="LblCode" runat="server" Text="رقم البيان*"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                        Display="Dynamic" ErrorMessage="يجب أختيار رقم بيان الترحيل" ForeColor="Red"
                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label2" runat="server" Text="التاريخ*"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtHDate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHDate"
                        Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="1">*</asp:RequiredFieldValidator>هـ
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label3" runat="server" Text="الموافق*"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtGDate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtGDate"
                        Display="Dynamic" ErrorMessage="يجب أختيار تاريخ الفاتورة" ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGDate"
                        CultureInvariantValues="true" Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ"
                        ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>م&nbsp;
                                <asp:Label ID="LblFTime" runat="server" Text=""></asp:Label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtGDate"
                        ValidationGroup="1" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$"
                        runat="server" ErrorMessage="يجب أن تكون القيمة تاريخ">*</asp:RegularExpressionValidator>
                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                        TargetControlID="txtGDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                        PopupPosition="BottomLeft" />
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label7" runat="server" Text="من*"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:DropDownList ID="ddlFrom" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ValFrom" runat="server" ControlToValidate="ddlFrom"
                        InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الجهة من" ForeColor="Red"
                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label9" runat="server" Text="إلى*"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:DropDownList ID="ddlTo" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ChkAll_CheckedChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ValTo" runat="server" ControlToValidate="ddlTo" InitialValue="-1"
                        Display="Dynamic" ErrorMessage="يجب أختيار الجهة من" ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:CheckBox ID="ChkAll" Text="عرض الجميع" runat="server" AutoPostBack="True" OnCheckedChanged="ChkAll_CheckedChanged" />

                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label11" runat="server" Text="رقم الباب"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtCarNo" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="BtnFind2" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                        ToolTip="البحث عن بيانات الشاحنة" OnClick="BtnFind2_Click" />
                    <asp:TextBox ID="txtSearch2" placeholder='البحث برقم اللوحة' runat="server" CssClass="form-control"
                        AutoPostBack="True" OnTextChanged="txtSearch2_TextChanged"></asp:TextBox>
                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearch2"
                        ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionCars" OnClientItemSelected="ace1_itemSelectedCars"
                        MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                        CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                    <asp:TextBox ID="txtRentPlateNo" Visible="false" MaxLength="15" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValRentPlateNo" runat="server" ControlToValidate="txtRentPlateNo"
                        InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أدخال رقم اللوحه" ForeColor="Red"
                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>

                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="lblRentValue" Visible="false" runat="server" Text="قيمة الأيجار"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtRentValue" Visible="false" MaxLength="15" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValRentValue" runat="server" ControlToValidate="txtRentValue"
                        InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أدخال قيمة الأيجار" ForeColor="Red"
                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="ValRentValue2" runat="server" ControlToValidate="txtRentValue"
                        ErrorMessage="يجب ان تكون القيمة رقمية" ForeColor="Red" SetFocusOnError="True"
                        Display="Dynamic" Type="Currency" ValidationGroup="1" Operator="DataTypeCheck">*</asp:CompareValidator>

                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label4" runat="server" Text="الناقلة*"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:DropDownList ID="ddlCar" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCar_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ValCar" runat="server" ControlToValidate="ddlCar"
                        InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار الناقلة" ForeColor="Red"
                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtRentMobileNo" Visible="false" MaxLength="15" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label1" runat="server" Text="السائق*"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:DropDownList ID="ddlDriver" CssClass="form-control" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlDriver_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ValDriver" runat="server" ControlToValidate="ddlDriver"
                        InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار السائق" ForeColor="Red"
                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtRentDriver" Visible="false" CssClass="form-control" MaxLength="100" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValRentDriver" runat="server" ControlToValidate="txtRentDriver"
                        InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أدخال السائق" ForeColor="Red"
                        SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label12" runat="server" Text="المرفقات"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                    <asp:DropDownList ID="ddlRemark" CssClass="form-control" runat="server">
                        <asp:ListItem>تريلا سطحه</asp:ListItem>
                        <asp:ListItem>تريلا جوانب</asp:ListItem>
                        <asp:ListItem>دينا عادي</asp:ListItem>
                        <asp:ListItem>دينا جامبو</asp:ListItem>
                        <asp:ListItem>لوري</asp:ListItem>
                        <asp:ListItem>لوبد</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:CheckBox ID="ChkNoCost" runat="server" Text="بدون مصروف طريق" />
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:LinkButton ID="BtnLines" runat="server" ValidationGroup="1" OnClick="BtnLines_Click">خط سير الرحلة</asp:LinkButton>

                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label6" runat="server" Text="ملحقات الناقلة"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtFType2" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                        Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label10" runat="server" Text="الحمولة"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtCap" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                        Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label013" runat="server" Text="نوع الحمولة"></asp:Label>
                </div>
                <div class="form-group col-md-8 col-sm-12 col-xm-12">
                    <asp:CheckBoxList ID="ChkInvType" runat="server" RepeatColumns="4" AutoPostBack="True"
                        OnSelectedIndexChanged="ChkInvType_SelectedIndexChanged">
                        <asp:ListItem Value="0">شحن سيارات</asp:ListItem>
                        <asp:ListItem Value="1">شحن بضاعة</asp:ListItem>
                        <asp:ListItem Value="2">شحن طرود</asp:ListItem>
                        <asp:ListItem Value="3">حاويات</asp:ListItem>
                    </asp:CheckBoxList>
                </div>

                <div class="form-group col-md-1 col-sm-12 col-xm-12"></div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                        Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="Label8" runat="server" Text="تاريخ الادخال"></asp:Label>
                </div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                        Enabled="false">                                                               
                    </asp:TextBox>
                    <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12">
                    <asp:Label ID="lblReason" Visible="false" runat="server" Text="سبب التعديل/الغاء"></asp:Label>
                </div>
                <div class="form-group col-md-4 col-sm-12 col-xm-12">
                    <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                        ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic"
                        SetFocusOnError="True" ValidationGroup="10">*</asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-md-2 col-sm-12 col-xm-12"></div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-12 col-sm-12 col-xm-12">
                    <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                        EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                </div>

            </div>
            <div class="form-row text-center">
                <div class="form-group col-md-12 col-sm-12 col-xm-12">
                    <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                        ImageUrl="~/images/data add.png" ToolTip="أضافة بيان ترحيل جديد" ValidationGroup="1"
                        OnClientClick='return confirm("هل أنت متاكد من حفظ بيان الترحيل؟")' OnClick="BtnNew_Click" />
                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                        ImageUrl="~/images/edit2.png" ToolTip="تعديل بيان ترحيل" Width="64px"
                        ValidationGroup="1" OnClick="BtnEdit_Click" />
                    <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                        ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة" OnClick="BtnClear_Click" />
                    <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                        ImageUrl="~/images/delete.png" ToolTip="إلغاء بيان الترحيل" OnClientClick='return confirm("هل أنت متاكد من الغاء بيان الترحيل؟")'
                        OnClick="BtnDelete_Click" />
                    <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                        ImageUrl="~/images/data search.png" ToolTip="البحث عن بيان الترحيل" OnClick="BtnSearch_Click" />
                    <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                        ImageUrl="~/images/print.png" ValidationGroup="1" ToolTip="طباعة السند" OnClick="BtnPrint_Click" />

                </div>

            </div>
            <div class="form-row">
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
                <div class="form-group col-md-3 col-sm-12 col-xm-12"></div>
            </div>

            <!--Editing by chanda verma-->

                <div class="form-row">
                    <div class="form-group col-md-12 col-sm-12 col-xm-12">
                        <div class="card">
                            <div class="card-header text-center">
                                <h4 class="card-title">المرفقات
                                   <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                </h4>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <!--start-->
                            <div class="card-body" style="display: none;">
                                <asp:Panel ID="Panel2" runat="server">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowHeader="False"
                                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo" Width="100%" OnRowDeleting="grdAttach_RowDeleting">
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
                                        <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                            ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                            ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                            ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                            SuppressPostBack="true" />

                                    </asp:Panel>
                                    <div class="form-row">
                                        <div class="col-sm-6">
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                                ValidationGroup="1" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                                   </div>
            </div>
       <!--end here-->


                        <!--Editing by chanda verma-->
                        <%--<div style="text-align: left; width: 50%; float: left;">
                   
                       <%-- <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                            <div style="float: right;">
                               </div>
                            <div style="float: right; margin-right: 20px;">
                                
                            </div>
                            <div style="float: left; vertical-align: middle;">
                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                            </div>
                        </div>
            </div>
                        --%>
                        <br />
                        <div id="CarAlert" runat="server" visible="false">
                            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%; border: solid 2px #800000">
                                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;">
                                    <b>[ مستندات الشاحنة ]</b></legend>
                                <asp:GridView ID="grdCarAlert" runat="server" CellPadding="4" ForeColor="Black"
                                    GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Code" Width="99.9%"
                                    EmptyDataText="لا توجد بيانات" BackColor="White" BorderColor="#DEDFDE"
                                    BorderStyle="None" BorderWidth="1px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="م" SortExpression="WorkShopCode" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNo" Text='<%# Bind("WorkShopCode") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="40px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الرقم" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lblCarNo" Text='<%# Eval("Code") %>' NavigateUrl='<%# UrlHelper("110" ,Eval("Code"),"110")%>' ToolTip="عرض السيارة" Target="_blank" runat="server"></asp:HyperLink>
                                            </ItemTemplate>
                                            <ControlStyle Width="80px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="85px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الاستمارة" SortExpression="strDate1" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrDate1" Text='<%# Bind("strDate1") %>' ToolTip='<%# Bind("PLoc1") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="التامين" SortExpression="strDate2" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrDate2" Text='<%# Bind("strDate2") %>' ToolTip='<%# Bind("PLoc2") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="بطاقة التشغيل" SortExpression="strDate3" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrDate3" Text='<%# Bind("strDate3") %>' ToolTip='<%# Bind("PLoc3") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الفحص الدوري" SortExpression="strDate4" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrDate4" Text='<%# Bind("strDate4") %>' ToolTip='<%# Bind("PLoc4") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" VerticalAlign="Middle"
                                        HorizontalAlign="Center" />
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
                        </div>
                    </div>

     

        <br />
    </fieldset>

    <div id="divGrd" runat="server" style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            AutoGenerateColumns="False" DataKeyNames="VouNo" Width="99.9%" EmptyDataText="لا توجد بيانات">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="" HeaderStyle-Width="20px">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkStatus" runat="server" Checked='<%# Bind("Status") %>' ToolTip="أختيار او عدم اختيار الفاتورة" />
                    </ItemTemplate>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="مرسل السيارة" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="200px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="رقم الفاتورة" SortExpression="VouNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblVouNo" Text='<%# Eval("Flag") + int.Parse(Eval("InvoiceVouLoc").ToString()).ToString() + "/" + Eval("VouNo") %>'
                            NavigateUrl='<%# UrlHelper(Eval("VouNo"),Eval("InvoiceVouLoc"),Eval("Flag"))%>' Target="_blank"
                            runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="نوع السيارة" SortExpression="CarType" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCarType" Text='<%# Bind("CarType") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="150px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="رقم اللوحة أو الهيكل" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="150px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="الطراز" SortExpression="Model" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblModel" Text='<%# Bind("Model") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="150px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="مستلم السيارة" SortExpression="RecName" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRecName" Text='<%# Bind("RecName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="200px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="جهة الترحيل" SortExpression="DestinationName1" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDestinationName" Text='<%# Bind("DestinationName1") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="150px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <%--   <asp:TemplateField HeaderText="المبلغ" SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
 // Safari Scroll Problem                               
 #galleryscroller {
  overflow: none;
  overflow-x: auto;
  display: block;
  height: 138px;
  width: 360px;
  white-space: nowrap;
}
                                
                --%>
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

</asp:Content>
