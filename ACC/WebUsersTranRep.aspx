<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebUsersTranRep.aspx.cs" Inherits="ACC.WebUsersTranRep" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="form">
                <fieldset class="form-check text-center">
                    <div class="form-group">
                        <h4 class="text-center text-muted">
                            كشف متابعة المستخدمين
                        </h4>
                        <hr />
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label5" runat="server" Text="اليوم"></asp:Label>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                                    BorderColor="#3366CC" BorderWidth="1px" DayNameFormat="Shortest"
                                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" 
                                    style="text-align: right" Width="220px" 
                                    FirstDayOfWeek="Saturday" 
                                    onselectionchanged="Calendar1_SelectionChanged" CellPadding="1" >
                                    <DayHeaderStyle BackColor="#99CCCC" Height="1px" ForeColor="#336666" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#CCCCFF" BorderColor="#3366CC" BorderWidth="1px" 
                                        Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                        </div>
                        <div class="form-group col-sm-1"></div>
                        <div class="form-group col-sm-7">
                            <div class="form-row">
                                <div class="form-group col-sm-2">
                                    <asp:Label ID="Label1" runat="server" Text="المستخدم"></asp:Label>
                                </div>
                                <div class="form-group col-sm-4">
                                    <asp:DropDownList ID="ddlUserName" CssClass="form-control" runat="server" 
                                             AutoPostBack="True" onselectedindexchanged="ddlUserName_SelectedIndexChanged">
                                         </asp:DropDownList>
                                </div>
                                <div class="form-group col-sm-6"></div>
                                
                            </div>
                            <div class="form-row">
                                <div class="form-group col-sm-2">
                                    <asp:Label ID="Label2" runat="server" Text="الصفحة"></asp:Label> 
                                </div>
                            <div class="form-group col-sm-4">
                                <asp:DropDownList ID="ddlFormName" CssClass="form-control" runat="server" 
                                             AutoPostBack="True" onselectedindexchanged="ddlFormName_SelectedIndexChanged">
                                         </asp:DropDownList>
                            </div>
                                <div class="form-group col-sm-6"></div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-sm-2">
                                    <asp:Label ID="Label3" runat="server" Text="الحدث"></asp:Label>  
                                </div>
                            <div class="form-group col-sm-4">
                                <asp:DropDownList ID="ddlFormAction" CssClass="form-control" runat="server" 
                                             AutoPostBack="True" onselectedindexchanged="ddlFormAction_SelectedIndexChanged">
                                         </asp:DropDownList>
                            </div>
                                <div class="form-group col-sm-6"></div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-sm-2">
                                    <asp:Label ID="lblRecordsNo" Text='عدد السجلات' runat="server"></asp:Label>
                                </div>
                            <div class="form-group col-sm-4">
                                <asp:DropDownList ID="ddlRecordsPerPage" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="10000">10000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                                <div class="form-group col-sm-6">
                                    <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" 
                                    onclick="BtnProcess_Click" />
                                
                                <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                    ImageUrl="~/images/print.png" ToolTip="'طباعة بيانات التقرير" 
                                    OnClientClick="aspnetForm.target ='_blank';" onclick="BtnPrint_Click" />
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"
                                    ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" 
                                    OnClientClick="aspnetForm.target ='_blank';" onclick="BtnExcel_Click" />
                                </div>
                            </div>
                            
                        </div>
                    </div>
                   
                </fieldset>
                <hr />
                <br />
                <div class="form">
                <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                    GridLines="None" AutoGenerateColumns="False" AllowPaging="True"  DataKeyNames="TranDate"
                    EmptyDataText="لا توجد بيانات" Width="100%"  
                        onpageindexchanging="grdCodes_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="التاريخ" SortExpression="TranDate" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblTranDate" Text='<%# Bind("TranDate") %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الوقت" SortExpression="TranTime" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblTranTime" Text='<%# Bind("TranTime") %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="المستخدم" SortExpression="UserName" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblUserName" Text='<%# Bind("UserName") %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="البيان" SortExpression="Description" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblDescription" Text='<%# Bind("Description") %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="السبب" SortExpression="Reason" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                     <asp:Label ID="lblReason" Text='<%# Bind("Reason") %>' runat="server"></asp:Label>
                                </div>
                               
                            </ItemTemplate>
                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IP" SortExpression="IP" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label ID="lblIP" Text='<%# Bind("IP") %>' runat="server"></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                      
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الموقع" SortExpression="Lat" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:HyperLink ID="lbllat" Text='<%# Eval("lat2") %>' NavigateUrl='<%# string.Format("~/WebMap.aspx?lat={0}&lng={1}",Eval("lat"),Eval("lng")) %>' Target="_blank" runat="server"></asp:HyperLink>
                                </div>
                                   
                            </ItemTemplate>
                       
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
                </asp:GridView>
                </div>
                <br />
                <div class="form-row">
                    <div class="form-group col-sm-4"></div>
                    <div class="form-group col-sm-4">
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                    </div>
                    <div class="form-group col-sm-4"></div>
                </div>

        </div>
</asp:Content>
