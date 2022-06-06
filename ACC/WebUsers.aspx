<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebUsers.aspx.cs" Inherits="ACC.WebUsers" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
	<center>
		<asp:Panel ID="Panel3" runat="server" CssClass="ColorRounded4Corners">
			<center id="center1" style="direction: rtl">
				<table id="Table1" dir="rtl" width="98%" style="color: Black">
					<tr id="tr1" align="right">
						<td style="width: 100px;">
							<asp:Label ID="LblCode" runat="server" Text="اسم المستخدم"></asp:Label>
						</td>
						<td style="width: 250px">
							<asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
							<asp:RequiredFieldValidator ID="ValName" runat="server" ControlToValidate="txtName"
								ErrorMessage="يجب إدخال اسم المستخدم" ForeColor="Red" SetFocusOnError="True"
								ValidationGroup="1">*</asp:RequiredFieldValidator>
						</td>
						<td style="width: 75px;">
							<asp:Label ID="Label33" runat="server" Text="عضو بمجموعة"></asp:Label>
						</td>
						<td style="width: 170px;" rowspan="5">
							<table width="100%">
								<tr>
									<td style="width: 170px">
										<asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
											BorderColor="Maroon" Width="100%" Height="170px">
											<asp:RadioButtonList ID="ChkRoles" runat="server">
											</asp:RadioButtonList>
										</asp:Panel>
									</td>
								</tr>
							</table>
						</td>
						<td align="left" rowspan="5" style="width: 120px;">
							<img id="ImgPhoto" runat="server" src="images/123.jpg" alt="Photo" class="img-circle" />
							<asp:FileUpload ID="FileUpload0" Width="80px" runat="server" />
							 <asp:Button ID="BtnLoad0" runat="server" Text="تحميل" OnClick="BtnLoad0_Click" />

						</td>
					</tr>
					<tr id="tr2" align="right">
						<td style="width: 100px;">
							<asp:Label ID="Label2" runat="server"  Text="كلمة المرور"></asp:Label>
						</td>
						<td style="width: 250px;">
							<asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
						</td>
						<td style="width: 75px;">
							&nbsp;
							<asp:CheckBox ID="ChkActive" runat="server" Text="نشط" />
						</td>
					</tr>
					<tr id="tr3" align="right">
						<td style="width: 100px;">
							<asp:Label ID="Label1"  runat="server" Text="تأكيد كلمة المرور"></asp:Label>
						</td>
						<td style="width: 250px;">
							<asp:TextBox ID="txtPassword2" CssClass="form-control" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
						</td>
						<td style="width: 75px;">
							&nbsp;
						</td>
					</tr>
					<tr id="tr6" align="right">
						<td style="width: 100px;">
							<asp:Label ID="Label3" runat="server" Text="الاسم بالكامل"></asp:Label>
						</td>
						<td style="width: 250px;">
							<asp:TextBox ID="txtFName" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
						</td>
						<td style="width: 75px;">
							&nbsp;
						</td>
					</tr>
					<tr id="tr4" align="right">
						<td style="width: 100px;">
							<asp:Label ID="Label8" runat="server" Text="الايميل"></asp:Label>
						</td>
						<td style="width: 250px;">
							<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
						</td>
						<td style="width: 75px;">
							&nbsp;
						</td>
					</tr>
					<tr id="tr7" align="right">
						<td style="width: 100px;">
							<asp:Label ID="Label35" runat="server" Text="الفرع الرئيسي"></asp:Label>
						</td>
						<td style="width: 250px;">
							<asp:DropDownList ID="ddlMainBran" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</td>
						<td style="width: 75px;">
							<asp:Label ID="Label34" runat="server" Text="الفروع البديلة"></asp:Label>
						</td>
						<td style="width: 125px;" rowspan="4">
									<asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
											BorderColor="Maroon" Width="100%" Height="100px">
										<asp:CheckBoxList ID="ChkBranch" runat="server">
										</asp:CheckBoxList>
								 </asp:Panel>
						</td>
						<td style="width: 125px;" rowspan="4">
									<img id="ImgPhoto0" runat="server" src="" alt="صورة التوقيع" class="img-circle" />
						</td>
					</tr>
					 <tr id="tr9" align="right">
						<td style="width: 100px;">
							<asp:Label ID="Label36" runat="server" Text="الصلاحية البديلة"></asp:Label>
						</td>
						<td style="width: 250px;">
							<asp:DropDownList ID="ddlBranRoll" CssClass="form-control" runat="server">
							</asp:DropDownList>
						 </td>
						<td style="width: 75px;">
						</td>
					</tr>
					<tr id="tr8" align="right">
						<td style="width: 100px;">
							<asp:Label ID="Label5" runat="server" Text="رقم التليفون"></asp:Label>
						</td>
						<td style="width: 250px">
							<asp:TextBox ID="txtTel" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
						</td>
						<td style="width: 75px;">
						</td>
					</tr>
					<tr id="tr10" align="right">
						<td style="width: 100px;">
							
							<asp:Label ID="Label6" runat="server" Text="رقم الموبيل"></asp:Label>
							
						</td>
						<td style="width: 250px">
							<asp:TextBox ID="txtMobile" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
						</td>
						<td style="width: 75px;">
						</td>
					</tr>
					<tr id="tr12" align="right">
						<td style="width: 100px;">
						</td>
						<td style="width: 250px;">
						</td>
						<td style="width: 75px;">
                        <asp:Label ID="Label9" runat="server" Text="التوقيع الالكتروني"></asp:Label>
						</td>
						<td style="width: 250px;" colspan="2">
							<asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
						    <asp:Button ID="BtnSign" runat="server" Text="تحميل" OnClick="BtnSign_Click" />
						</td>
					</tr>
					<tr id="tr13" align="right">
						<td style="width: 100px;">							
							<asp:Label ID="Label10" runat="server" Text="حسابات متاحة 1"></asp:Label>							
						</td>
						<td style="width: 250px">
							<asp:DropDownList ID="ddlAccount1" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</td>
						<td style="width: 75px;">
                           <asp:Label ID="Label12" runat="server" Text="حسابات متاحة 2"></asp:Label>							
						</td>
						<td style="width: 250px;" colspan="2">
							<asp:DropDownList ID="ddlAccount2" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</td>
					</tr>
					<tr id="tr14" align="right">
						<td style="width: 100px;">							
							<asp:Label ID="Label13" runat="server" Text="حسابات متاحة 3"></asp:Label>							
						</td>
						<td style="width: 250px">
							<asp:DropDownList ID="ddlAccount3" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</td>
						<td style="width: 75px;">
                           <asp:Label ID="Label14" runat="server" Text="حسابات متاحة 4"></asp:Label>							
						</td>
						<td style="width: 250px;" colspan="2">
							<asp:DropDownList ID="ddlAccount4" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</td>
					</tr>
					<tr id="tr15" align="right">
						<td style="width: 100px;">							
							<asp:Label ID="Label15" runat="server" Text="مدير حساب 1"></asp:Label>							
						</td>
						<td style="width: 250px">
							<asp:DropDownList ID="ddlAccount5" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</td>
						<td style="width: 75px;">
                           <asp:Label ID="Label16" runat="server" Text="مدير حساب 2"></asp:Label>							
						</td>
						<td style="width: 250px;" colspan="2">
							<asp:DropDownList ID="ddlAccount6" CssClass="form-control" runat="server">
							</asp:DropDownList>
						</td>
					</tr>
					<tr id="tr11" align="right">
						<td style="width: 100px;">
							<asp:Label ID="Label4" runat="server" Text="إدخلت بواسطة"></asp:Label>
						</td>
						<td style="width: 250px;">
							<asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
								Enabled="false"></asp:TextBox>
						</td>
						<td style="width: 75px;">
							<asp:Label ID="Label7" runat="server" Text="بتاريخ"></asp:Label>
						</td>
						<td style="width: 250px;" colspan="2">
							<asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
								Enabled="false"></asp:TextBox>
						</td>
					</tr>
					 <tr align="right">
						 <td style="width: 100px;">
								<asp:Label ID="lblReason" runat="server" Visible="false" Text="سبب التعديل/الغاء"></asp:Label>
						 </td>
							<td style="width: 250px;">
								<asp:TextBox ID="txtReason" CssClass="form-control" Visible="false" runat="server" MaxLength="100"></asp:TextBox>
								<asp:RequiredFieldValidator ID="ValReason" Enabled="false" runat="server" ControlToValidate="txtReason"
									ErrorMessage="يجب إدخال سبب التعديل/الالغاء" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
									ValidationGroup="1">*</asp:RequiredFieldValidator>
							</td>
							<td style="width: 75px;">
							</td>
							<td style="width: 250px;" colspan="2">
							</td>
						</tr>

					<tr id="tr5" align="right">
						<td style="width: 100px;">
						</td>
						<td style="width: 250px;">
							<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
						</td>
						<td style="width: 75px;">
						</td>
						<td style="width: 250px;" colspan="2">
							<asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
						</td>
					</tr>
				</table>
				<table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
					<tr align="center">
						<td style="width: 200px;">
						</td>
						<td style="width: 350px;">
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
						</td>
						<td id="td1" runat="server" style="width: 200px; text-align: right">
							<asp:Label ID="Label11" runat="server" Text="بحث :"></asp:Label>
							<asp:TextBox ID="txtSearch" MaxLength="200" CssClass="form-control" runat="server"></asp:TextBox>
						</td>
					</tr>
				</table>
				<br />
				<div style="width: 100%; overflow:none; overflow-x:auto ; border: 1px solid #800000;">
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
				<br />
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
				<br />
			</center>
		</asp:Panel>
	</center>
</asp:Content>

