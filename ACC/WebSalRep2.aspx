<%@ Page Title="كشف رواتب البنك" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebSalRep2.aspx.cs" Inherits="ACC.WebSalRep2"  Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="ColorRounded4Corners col-md-10 col-md-offset-1 col-sm-12 col-xs-12">
          
                <fieldset class="Rounded4CornersNoShadow" >
                    <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                        كشف رواتب البنك</legend>
                   <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                
                                <asp:Label ID="Label3" runat="server" Text="الشهر"></asp:Label>
                         
                                <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:RadioButtonList ID="rdotype" runat="server" Width="300px" CellPadding="2" 
                                    CellSpacing="2" RepeatColumns="3">
                                    <asp:ListItem Value="0">مسدد</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="1">غير مسدد</asp:ListItem>
                                    <asp:ListItem Value="2">الجميع</asp:ListItem>
                                </asp:RadioButtonList><br />
                                    </div></div></div>
                        <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="عرض السجلات"></asp:Label>
                           
                                <asp:DropDownList ID="ddlRecordsPerPage" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="-1">الكل</asp:ListItem>
                                </asp:DropDownList>
                         
                                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                                &nbsp;
                                <asp:Label ID="Label6" runat="server" Text="سجل"></asp:Label>
                          </div></div></div>
                         
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="القسم"></asp:Label>
                         
	                              <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
											BorderColor="Maroon" Width="100%" Height="150px">
                                    <asp:CheckBoxList ID="ChkSection" runat="server">
                                    </asp:CheckBoxList>
							     </asp:Panel>
                            
                                <asp:CheckBox ID="ChkDep" Text="جميع الاقسام" runat="server" AutoPostBack="True" 
                                      oncheckedchanged="ChkDep_CheckedChanged" />                                
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"   
                                    ImageUrl="~/images/Process.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print_64A.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                    
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"  
                                    ImageUrl="~/images/Excel.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                          </div></div></div>
              
              <div class="table-responsive">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                        Width="99.9%" OnPageIndexChanging="grdCodes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="م" SortExpression="FNo" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblFNo" Text='<%# Bind("FNo") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الرقم الوظيفي" SortExpression="EmpCode" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpCode" Text='<%# Bind("EmpCode") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lbltot" Text="الاجمالي" runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ATM" SortExpression="ATM" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblATM" Text='<%# Eval("ATM") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاسم" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" SortExpression="PaperNo1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPaperNo1" Text='<%# Eval("PaperNo1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الصافي" SortExpression="Net" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblNet" Text='<%# Eval("Net","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalNet" Text='<%# TotalNet %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OP" SortExpression="OP" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblOP" Text='<%# Eval("OP") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاساسي" SortExpression="Basic" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBasic" Text='<%# Eval("Basic","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalBasic" Text='<%# TotalBasic %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="بدل السكن" SortExpression="Add02" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdd02" Text='<%# Eval("Add02","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAdd02" Text='<%# TotalAdd02 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="أخرى" SortExpression="Add00" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdd00" Text='<%# Eval("Add00","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAdd00" Text='<%# TotalAdd00 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حسميات أخرى" SortExpression="Ded00" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDed00" Text='<%# Eval("Ded00","{0:N2}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalDed00" Text='<%# TotalDed00 %>' runat="server"></asp:Label>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                            HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
            </div></div></div>
             </fieldset>
        </div>
   
</asp:Content>
