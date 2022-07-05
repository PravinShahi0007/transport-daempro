<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebUsers.aspx.cs" Inherits="ACC.WebUsers" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD
    <script type="text/javascript" language="JavaScript">
        function ChangeState(state) {
            var chkBoxList = document.getElementById("ContentPlaceHolder1_ChkRoles");
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            for (var i = 0; i < chkBoxCount.length; i++) {
                chkBoxCount[i].checked = state;
            }
            var chkBranchList = document.getElementById("ContentPlaceHolder1_ChkBranch");
            var chkBranchCount = chkBranchList.getElementsByTagName("input");
            for (var i = 0; i < chkBranchCount.length; i++) {
                chkBranchCount[i].checked = state;
            }
            return false;
        }
    </script>

    <asp:Panel ID="Panel3" runat="server" CssClass="card">
        <div class="box box-info card-body" align="right">
            <div class="body">
                <div class="row">
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="LblCode" runat="server" Text="اسم المستخدم"></asp:Label>

                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValName" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="يجب إدخال اسم المستخدم" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label33" runat="server" Text="عضو بمجموعة"></asp:Label>


                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
                                    BorderColor="Maroon" Width="100%" Height="170px">
                                    <asp:RadioButtonList ID="ChkRoles" runat="server">
                                    </asp:RadioButtonList>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <img id="ImgPhoto" runat="server" src="images/123.jpg" alt="Photo" class="img-circle" />
                                <asp:FileUpload ID="FileUpload0" Width="80px" runat="server" />
                                <asp:Button ID="BtnLoad0" runat="server" Text="تحميل" OnClick="BtnLoad0_Click" />

                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="كلمة المرور"></asp:Label>


                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:CheckBox ID="ChkActive" runat="server" Text="نشط" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="تأكيد كلمة المرور"></asp:Label>


                                <asp:TextBox ID="txtPassword2" CssClass="form-control" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="الاسم بالكامل"></asp:Label>

                                <asp:TextBox ID="txtFName" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label8" runat="server" Text="الايميل"></asp:Label>

                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label35" runat="server" Text="الفرع الرئيسي"></asp:Label>

                                <asp:DropDownList ID="ddlMainBran" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label34" runat="server" Text="الفروع البديلة"></asp:Label>

                                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
                                    BorderColor="Maroon" Width="100%" Height="100px">
                                    <asp:CheckBoxList ID="ChkBranch" runat="server">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <img id="ImgPhoto0" runat="server" src="" alt="صورة التوقيع" class="img-circle" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label36" runat="server" Text="الصلاحية البديلة"></asp:Label>

                                <asp:DropDownList ID="ddlBranRoll" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label5" runat="server" Text="رقم التليفون"></asp:Label>

                                <asp:TextBox ID="txtTel" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">

                                <asp:Label ID="Label6" runat="server" Text="رقم الموبيل"></asp:Label>


                                <asp:TextBox ID="txtMobile" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label9" runat="server" Text="التوقيع الالكتروني"></asp:Label>


                                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                                <asp:Button ID="BtnSign" runat="server" Text="تحميل" OnClick="BtnSign_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label10" runat="server" Text="حسابات متاحة 1"></asp:Label>

                                <asp:DropDownList ID="ddlAccount1" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label12" runat="server" Text="حسابات متاحة 2"></asp:Label>


                                <asp:DropDownList ID="ddlAccount2" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label13" runat="server" Text="حسابات متاحة 3"></asp:Label>

                                <asp:DropDownList ID="ddlAccount3" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label14" runat="server" Text="حسابات متاحة 4"></asp:Label>

                                <asp:DropDownList ID="ddlAccount4" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label15" runat="server" Text="مدير حساب 1"></asp:Label>

                                <asp:DropDownList ID="ddlAccount5" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label16" runat="server" Text="مدير حساب 2"></asp:Label>

                                <asp:DropDownList ID="ddlAccount6" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="إدخلت بواسطة"></asp:Label>

                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label7" runat="server" Text="بتاريخ"></asp:Label>

                                <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>


                                <asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
                                    ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />


                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png" ToolTip="أضافة مستخدم جديد"
                                    ValidationGroup="1" OnClick="BtnNew_Click" OnClientClick='return confirm("هل أنت متاكد من حفظ البيانات؟")' />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات مستخدم"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" ToolTip="مسح بيانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" ValidationGroup="1" runat="server" AlternateText="الفاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png" ToolTip="الغاء بيانات مستخدم"
                                    OnClick="BtnDelete_Click" OnClientClick='return confirm("هل أنت متاكد من الغاء البيانات؟")' />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="مراجعة" CommandName="Find"
                                    ImageUrl="~/images/data search.png" ToolTip="مراجعة بيانات مستخدم"
                                    OnClick="BtnSearch_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group form-float">
                            <div class="form-line">
                                <asp:Label ID="Label11" runat="server" Text="بحث :"></asp:Label>
                                <asp:TextBox ID="txtSearch" MaxLength="200" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="table table-responsive table-hover text-center">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="UserName" AllowPaging="True"
                            PageSize="20" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات المستخدم"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم المستخدم" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الايميل" SortExpression="Email" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" Text='<%# Bind("Email") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم التليفون" SortExpression="Tel" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTel" Text='<%# Bind("Tel") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الجوال" SortExpression="Mobile" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobile" Text='<%# Bind("Mobile") %>' runat="server"></asp:Label>
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

                    <div class="table table-responsive table-hover text-center">
                        <asp:GridView ID="GrdGroup" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="UserName" AllowPaging="True"
                            PageSize="20" Width="100%" EmptyDataText="لا توجد بيانات"
                            OnPageIndexChanging="GrdGroup_PageIndexChanging"
                            OnSelectedIndexChanging="GrdGroup_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات المستخدم"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم المستخدم" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عضو في مجموعة" SortExpression="RoleName" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoleName" Text='<%# Bind("RoleName") %>' runat="server"></asp:Label>
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
                </div>
            </div>
        </div>
    </asp:Panel>

=======
	<script type="text/javascript" language="JavaScript">
		function ChangeState(state) {
			var chkBoxList = document.getElementById("ContentPlaceHolder1_ChkRoles");
			var chkBoxCount = chkBoxList.getElementsByTagName("input");
			for (var i = 0; i < chkBoxCount.length; i++) {
				chkBoxCount[i].checked = state;
			}
			var chkBranchList = document.getElementById("ContentPlaceHolder1_ChkBranch");
			var chkBranchCount = chkBranchList.getElementsByTagName("input");
			for (var i = 0; i < chkBranchCount.length; i++) {
					chkBranchCount[i].checked = state;
			}
			return false;
		}
	</script>
	
		<asp:Panel ID="Panel3" runat="server" CssClass="ColorRounded4Corners  col-md-10 col-md-offset-1 col-sm-12 col-xs-12">
			  <div class="box box-info" align="right">
     <div class="body">
                                    <div class="row">
				  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="LblCode" runat="server" Text="اسم المستخدم"></asp:Label>
					
							<asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
							<asp:RequiredFieldValidator ID="ValName" runat="server" ControlToValidate="txtName"
								ErrorMessage="يجب إدخال اسم المستخدم" ForeColor="Red" SetFocusOnError="True"
								ValidationGroup="1">*</asp:RequiredFieldValidator>
					</div></div></div>
						  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label33" runat="server" Text="عضو بمجموعة"></asp:Label>
						
				
										<asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
											BorderColor="Maroon" Width="100%" Height="170px">
											<asp:RadioButtonList ID="ChkRoles" runat="server">
											</asp:RadioButtonList>
										</asp:Panel>
								</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<img id="ImgPhoto" runat="server" src="images/123.jpg" alt="Photo" class="img-circle" />
							<asp:FileUpload ID="FileUpload0" Width="80px" runat="server" />
							 <asp:Button ID="BtnLoad0" runat="server" Text="تحميل" OnClick="BtnLoad0_Click" />

					</div></div></div>
				
				  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label2" runat="server"  Text="كلمة المرور"></asp:Label>
					
					
							<asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
						
					</div></div></div>
										  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:CheckBox ID="ChkActive" runat="server" Text="نشط" />
						</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label1"  runat="server" Text="تأكيد كلمة المرور"></asp:Label>
					
					
							<asp:TextBox ID="txtPassword2" CssClass="form-control" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
						</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label3" runat="server" Text="الاسم بالكامل"></asp:Label>
					
							<asp:TextBox ID="txtFName" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
						</div></div></div>
				  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label8" runat="server" Text="الايميل"></asp:Label>
					
							<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
					</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label35" runat="server" Text="الفرع الرئيسي"></asp:Label>
						
							<asp:DropDownList ID="ddlMainBran" CssClass="form-control" runat="server">
							</asp:DropDownList>
					</div></div></div>
						  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label34" runat="server" Text="الفروع البديلة"></asp:Label>
						
									<asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
											BorderColor="Maroon" Width="100%" Height="100px">
										<asp:CheckBoxList ID="ChkBranch" runat="server">
										</asp:CheckBoxList>
								 </asp:Panel>
						</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
									<img id="ImgPhoto0" runat="server" src="" alt="صورة التوقيع" class="img-circle" />
						</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label36" runat="server" Text="الصلاحية البديلة"></asp:Label>
					
							<asp:DropDownList ID="ddlBranRoll" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label5" runat="server" Text="رقم التليفون"></asp:Label>
						
							<asp:TextBox ID="txtTel" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
					</div></div></div>
				  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							
							<asp:Label ID="Label6" runat="server" Text="رقم الموبيل"></asp:Label>
							
						
							<asp:TextBox ID="txtMobile" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
					</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                        <asp:Label ID="Label9" runat="server" Text="التوقيع الالكتروني"></asp:Label>
					
					
							<asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
						    <asp:Button ID="BtnSign" runat="server" Text="تحميل" OnClick="BtnSign_Click" />
						</div></div></div>
				  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">					
							<asp:Label ID="Label10" runat="server" Text="حسابات متاحة 1"></asp:Label>							
						
							<asp:DropDownList ID="ddlAccount1" CssClass="form-control" runat="server">
							</asp:DropDownList>
					</div></div></div>
										  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                           <asp:Label ID="Label12" runat="server" Text="حسابات متاحة 2"></asp:Label>							
					
					
							<asp:DropDownList ID="ddlAccount2" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</div></div></div>
				  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">					
							<asp:Label ID="Label13" runat="server" Text="حسابات متاحة 3"></asp:Label>							
					
							<asp:DropDownList ID="ddlAccount3" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</div></div></div>
										  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                           <asp:Label ID="Label14" runat="server" Text="حسابات متاحة 4"></asp:Label>							
					
							<asp:DropDownList ID="ddlAccount4" CssClass="form-control" runat="server">
							</asp:DropDownList>
					</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">						
							<asp:Label ID="Label15" runat="server" Text="مدير حساب 1"></asp:Label>							
					
							<asp:DropDownList ID="ddlAccount5" CssClass="form-control" runat="server">
							</asp:DropDownList>
					</div></div></div>
						  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                           <asp:Label ID="Label16" runat="server" Text="مدير حساب 2"></asp:Label>							
				
							<asp:DropDownList ID="ddlAccount6" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</div></div></div>
				  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label4" runat="server" Text="إدخلت بواسطة"></asp:Label>
					
							<asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
								Enabled="false"></asp:TextBox>
					</div></div></div>
						  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label7" runat="server" Text="بتاريخ"></asp:Label>
					
							<asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
								Enabled="false"></asp:TextBox>
					</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
								<asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>
					
						
								<asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
								<asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
									ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
									ValidationGroup="1">*</asp:RequiredFieldValidator>
						</div></div></div>

					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
					
						
							<asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
						</div></div></div>
			
			  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
								ImageUrl="~/images/insource_642.png"   ToolTip="أضافة مستخدم جديد"
								ValidationGroup="1" OnClick="BtnNew_Click" OnClientClick='return confirm("هل أنت متاكد من حفظ البيانات؟")' />
							<asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
								ImageUrl="~/images/draw_pen_642.png"   ToolTip="تعديل بيانات مستخدم"
								Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
							<asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
								ImageUrl="~/images/erasure_642.png"   ToolTip="مسح بيانات الشاشة"
								OnClick="BtnClear_Click" />
							<asp:ImageButton ID="BtnDelete" ValidationGroup="1" runat="server" AlternateText="الفاء" CommandName="Delete"
								ImageUrl="~/images/cut_642.png"   ToolTip="الغاء بيانات مستخدم"
								OnClick="BtnDelete_Click" OnClientClick='return confirm("هل أنت متاكد من الغاء البيانات؟")' />
							<asp:ImageButton ID="BtnSearch" runat="server" AlternateText="مراجعة" CommandName="Find"
								ImageUrl="~/images/binoculars_642.png"   ToolTip="مراجعة بيانات مستخدم"
								OnClick="BtnSearch_Click" />
						</div></div></div>
					  <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
							<asp:Label ID="Label11" runat="server" Text="بحث :"></asp:Label>
							<asp:TextBox ID="txtSearch" MaxLength="200" CssClass="form-control" runat="server"></asp:TextBox>
					</div></div></div>
			
			   <div class="table-responsive">
					<asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
						GridLines="None" AutoGenerateColumns="False" DataKeyNames="UserName" AllowPaging="True"
						PageSize="20" Width="99.9%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
						OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
						<Columns>
							<asp:TemplateField>
								<ItemTemplate>
									<asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات المستخدم"
										ImageUrl="~/images/arrow_undo.png" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="اسم المستخدم" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
								<ItemTemplate>
									<asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
								</ItemTemplate>
								<ControlStyle Width="150px" />
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="الايميل" SortExpression="Email" ItemStyle-HorizontalAlign="Center">
								<ItemTemplate>
									<asp:Label ID="lblEmail" Text='<%# Bind("Email") %>' runat="server"></asp:Label>
								</ItemTemplate>
								<ControlStyle Width="200px" />
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="رقم التليفون" SortExpression="Tel" ItemStyle-HorizontalAlign="Center">
								<ItemTemplate>
									<asp:Label ID="lblTel" Text='<%# Bind("Tel") %>' runat="server"></asp:Label>
								</ItemTemplate>
								<ControlStyle Width="120px" />
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="الجوال" SortExpression="Mobile" ItemStyle-HorizontalAlign="Center">
								<ItemTemplate>
									<asp:Label ID="lblMobile" Text='<%# Bind("Mobile") %>' runat="server"></asp:Label>
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
				
                	<div style="width: 100%; overflow:none; overflow-x:auto ; border: 1px solid #800000;">
					<asp:GridView ID="GrdGroup" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
						GridLines="None" AutoGenerateColumns="False" DataKeyNames="UserName" AllowPaging="True"
						PageSize="20" Width="99.9%" EmptyDataText="لا توجد بيانات" 
                            onpageindexchanging="GrdGroup_PageIndexChanging" 
                            onselectedindexchanging="GrdGroup_SelectedIndexChanging">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
						<Columns>
							<asp:TemplateField>
								<ItemTemplate>
									<asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات المستخدم"
										ImageUrl="~/images/arrow_undo.png" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="اسم المستخدم" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
								<ItemTemplate>
									<asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
								</ItemTemplate>
								<ControlStyle Width="150px" />
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="عضو في مجموعة" SortExpression="RoleName" ItemStyle-HorizontalAlign="Center">
								<ItemTemplate>
									<asp:Label ID="lblRoleName" Text='<%# Bind("RoleName") %>' runat="server"></asp:Label>
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
			</div></div></div>
		</asp:Panel>

>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
</asp:Content>

