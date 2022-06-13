<%@ Page Title="بيانات الفنيين" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebTechno.aspx.cs" Inherits="ACC.WebTechno" MaintainScrollPositionOnPostback="true"  Culture="auto:ar-EG" UICulture="auto"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
         <div class="ColorRounded4Corners col-md-10 col-md-offset-1 col-sm-12 col-xs-12">
            <fieldset class="Rounded4CornersNoShadow" >
                <legend id="leg1" runat="server" align="<%$ Resources:Resource, dir2 %>" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Literal ID="Literal2" Text="<%$ Resources:Header %>" runat="server"></asp:Literal></b></legend>
                  <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCode" runat="server" Text="رقم الفني" meta:resourcekey="LblCode"></asp:Label>
                          
                                <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="<%$ Resources:SearchTech %>" OnClick="BtnSearch_Click" />
                                <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtCode"
                                    ErrorMessage="<%$ Resources:EnterTech %>" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ValKMeter" runat="server" ControlToValidate="txtCode"
                                 Display="Dynamic" ErrorMessage="<%$ Resources:EnterNumeric %>" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                 Type="Integer">*</asp:CompareValidator>
                       </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="اسم c عربي" meta:resourcekey="Label2"></asp:Label>
                        
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label13" runat="server" Text="الحساب" meta:resourcekey="Label13"></asp:Label>
                        
                                <asp:DropDownList ID="ddlAccAccount" CssClass="form-control" runat="server">
                                </asp:DropDownList>                                
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="اسم الفني أنجليزي" meta:resourcekey="Label4"></asp:Label>
                         
                                <asp:TextBox ID="txtName2" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="الوظيفة" meta:resourcekey="Label3"></asp:Label>
                          
                                <asp:DropDownList ID="ddlJob" CssClass="form-control" runat="server">
                                </asp:DropDownList>                                
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label7" runat="server" Text="سعر الساعة" meta:resourcekey="Label7"></asp:Label>
                          
                                <asp:TextBox ID="txtHourRate" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtHourRate"
                                 Display="Dynamic" ErrorMessage="<%$ Resources:EnterNumeric %>" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                 Type="Double">*</asp:CompareValidator>
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="الموبيل" meta:resourcekey="Label1"></asp:Label>
                          
                                <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                        </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label5" runat="server" Text="ملاحظات" meta:resourcekey="Label5"></asp:Label>
                         
                                <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                           
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                    ValidationGroup="1" EnableClientScript="true" ShowSummary="true"/>
                          </div></div></div>
                       
                            <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                      
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="<%$ Resources:AddTechImage %>" CssClass="ops" ToolTip="<%$ Resources:AddTechToolTip %>"
                                    ValidationGroup="1" OnClientClick='<%$ Resources:AddTechConfirm %>'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="<%$ Resources:EditTechImage %>" CssClass="ops" ToolTip="<%$ Resources:EditTechToolTip %>"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="<%$ Resources:ClearTechImage %>" CssClass="ops" ToolTip="<%$ Resources:ClearTechToolTip %>"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="<%$ Resources:DeleteTechImage %>" CssClass="ops" ToolTip="<%$ Resources:DeleteTechToolTip %>" OnClientClick='<%$ Resources:DeleteTechConfirm %>'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="<%$ Resources:SearchTechImage %>" CssClass="ops" ToolTip="<%$ Resources:SearchTechToolTip %>"
                                    OnClick="BtnSearch_Click" />
                          </div></div></div>
                   <div class="table-responsive">
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="Code" AllowPaging="True"
                            PageSize="20" Width="99.9%" EmptyDataText="<%$ Resources:NoData %>" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="<%$ Resources:SelectToolTip %>"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TechNo %>" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TechName %>" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TechName2 %>" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TechMobileNo %>" SortExpression="MobileNo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobileNo" Text='<%# Bind("MobileNo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
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
            </fieldset>
        </div>
       
</asp:Content>
