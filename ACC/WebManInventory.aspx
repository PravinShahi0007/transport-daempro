<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebManInventory.aspx.cs" Inherits="ACC.WebManInventory" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="JavaScript">
        function pageLoad() {
            $("input[name*='grdCodes'],select[name*='grdCodes']").change(function (event) {
                var res = event.target.id.split("_");
                var ctrl = document.getElementById("ContentPlaceHolder1_grdCodes_txtAction_" + res[3]);
                ctrl.value = "123";
                $(this).addClass('ChangedText');
                $(this).ToolTip = '1';
            });
            SetMyStyle();
        }

        function CallMe(src, dest, no1) {
            var ctrl = document.getElementById(src);
            var dest1 = document.getElementById(dest);
            // call server side method
            PageMethods.GetDate(ctrl.value,dest1.innerHTML, CallSuccess, CallFailed, no1);
        }
        // set the destination textbox value with the ContactName
        function CallSuccess(res, no1) {
            var dest = document.getElementById(no1[0]);
            dest.innerHTML = res[0];

            var dest125 = document.getElementById(no1[1]);
            //alert(dest125.innerHTML);
            dest125.innerHTML = res[1];
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            alert(res.get_message());
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD
   <div class="col-md-12  col-sm-12 col-xs-12">
      <div class="card card-body">
            <h3 id="leg1" runat="server" align="<%$ Resources:Resource, dir2 %> center" ><b>
                    <asp:Literal ID="Literal2" Text="Manual Inventory Data Entry" runat="server"></asp:Literal>
                    <!-- [ بيانات الأصناف ] -->
                </b></h3>
=======
    <div class="ColorRounded4Corners col-md-12 col-sm-12 col-xs-12">
        <fieldset class="Rounded4CornersNoShadow" >
            <legend id="leg1" runat="server" align="<%$ Resources:Resource, dir2 %>" style="font-size: 18px;
                color: #800000; text-align: center;"><b>
                    <asp:Literal ID="Literal2" Text="Manual Inventory Data Entry" runat="server"></asp:Literal>
                    <!-- [ بيانات الأصناف ] -->
                </b></legend>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
        
                <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label22" runat="server" Text="Select Store:"></asp:Label>
                    
                            <asp:DropDownList ID="ddlStore" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                      </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label1" runat="server" Text="Inventory Date"></asp:Label>
                    
                            <asp:TextBox ID="txtFYear" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFYear"
                                Display="Dynamic" ErrorMessage="You Should Enter Inventory Date" ForeColor="Red" SetFocusOnError="True"
                                ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="1" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="Search for Manual Inventory" OnClick="BtnFind_Click" />
                                <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtFYear"
                                    CultureInvariantValues="true" Display="Dynamic" ErrorMessage="Note Date Should be Date Value"
                                    ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFYear" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                      </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label23" runat="server" Text="Type"></asp:Label>
                      
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="True"  ValidationGroup="1"
                                onselectedindexchanged="ddlType_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="1">Addition & Lost</asp:ListItem>
                                <asp:ListItem Value="2">Lost</asp:ListItem>
                                <asp:ListItem Value="3">Addition</asp:ListItem>
                            </asp:DropDownList>
                      </div></div></div>
<<<<<<< HEAD
              <div class="table-responsive table">
=======
              <div class="table-responsive">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="true" PageSize="50"
                        DataKeyNames="Code" Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Item Code" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description" SortExpression="ITName1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblITName1" Text='<%# Bind("ITName1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance" SortExpression="Bal" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBal" runat="server" Text='<%# Bind("Bal") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="65px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manual Bal." SortExpression="FBal" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFBal" Text='<%# Bind("FBal") %>' MaxLength="20" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="txtFBal"
                                        Display="Dynamic" ErrorMessage="You Should Enter Numeric Value" ForeColor="Red"
                                        Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="65px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost Price" SortExpression="Price" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrice" Text='<%# Bind("Price") %>' MaxLength="20" runat="server"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator207" runat="server" ControlToValidate="txtPrice"
                                        Display="Dynamic" ErrorMessage="You Should Enter Numeric Value" ForeColor="Red"
                                        Type="Currency" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="65px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="+" SortExpression="FAdd" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFAdd" runat="server" Text='<%# Bind("FAdd") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="-" SortExpression="FDed" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFDed" runat="server" Text='<%# Bind("FDed") %>'></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" SortExpression="FStatus" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlAction" runat="server" OnInit="ddlAction_Init"></asp:DropDownList>
                                    <asp:HiddenField ID="txtAction" Value="" runat="server" />
                                </ItemTemplate>
                                <ControlStyle Width="120px" />
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
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
            
              
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" CssClass="ops" ToolTip="Edit Stock Item Inventory"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnRefresh" runat="server" AlternateText="Refresh" CommandName="Refresh"
                                    ImageUrl="~/images/Refresh_642.png" CssClass="ops" ToolTip="Refresh Data For Stock Item Inventory"
                                    Width="64px" ValidationGroup="1" onclick="BtnRefresh_Click"/>
                                <asp:ImageButton ID="BtnPost" runat="server" Visible="false" AlternateText="ترحيل االقيد" ValidationGroup="1"
                                    ImageUrl="~/images/Process.png" ToolTip="ترحيل االقيد"  />
                                <asp:ImageButton ID="BtnPrint1" Visible="false" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print_641.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                                                    
                         
                                <asp:HyperLink ID="BtnAdd" target="_blank" Visible="false" runat="server" Text= "+ معالجة الزيادة"></asp:HyperLink>
                              
                                <asp:HyperLink ID="BtnDed" target="_blank" Visible="false"  runat="server" Text= "- معالجة النقص"></asp:HyperLink>
                       </div></div></div>
                </div>
               


                 <div class="col-md-12">
                     <div class="card">
                         <div class="card-head">
                             <h3 class="card-title">
                                 المرفقات
                                 <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                 <%--<div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                                            </div>--%>
                             </h3>
                             <!--Create by ankur kumar-->
                             <div class="card-tools">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                            <i class="fas fa-plus"></i>
                                        </button>
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="collapse">
                                            <i class="fas fa-minus"></i>
                                        </button>
                                    </div>
                         </div>
                         <div class="card-body" style="display:none;">
                             <asp:Panel ID="Panel2" runat="server">
                                    <asp:Panel ID="Panel1" runat="server">
                                        
                                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                                            ShowHeader="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="100%" OnRowDeleting="grdAttach_RowDeleting">
                                            <AlternatingRowStyle BackColor="White" />
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
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        </asp:GridView>
                                       
                                        <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
<<<<<<< HEAD
                                    </asp:Panel>
                                  <div class="form-row">
                                           
                                                <div class="form-group col-md-6 col-sm-12 col-xm-12">
                                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                                                </div>
                                                <div class="form-group col-md-6 col-sm-12 col-xm-12">
                                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </div>
                                         
                                        </div>
                            </asp:Panel>
                         </div>
                     </div>
                 </div>
 </div></div>
    </div></div>
=======
                                </div></div></div>
        </fieldset>
    </div>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
</asp:Content>
