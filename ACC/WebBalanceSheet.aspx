<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebBalanceSheet.aspx.cs" Inherits="ACC.WebBalanceSheet" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <fieldset class="card text-center">
                    <div class="form-group">
                        <h4 class="text-muted">
                          <asp:Literal ID="Literal90" Text="<%$ Resources:Title %>" runat="server"></asp:Literal>
                        </h4>
                    </div>
                   <hr />
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-2"></div>
                        <div class="form-group col-sm-2">
                            <asp:CheckBox ID="ChkPeriod" runat="server" CssClass="form-control" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" meta:resourcekey="ChkPeriod" />
                        </div>
                        
                        <div class="form-group col-sm-4"></div>
                        <div class="form-group col-sm-3">
                            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="<%$ Resources:Process %>" ValidationGroup="1"
                                    ImageUrl="~/images/setting.png" ToolTip="<%$ Resources:ReportPro %>" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="<%$ Resources:Print %>" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                    OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="<%$ Resources:Export %>" CommandName="Excel"
                                    ImageUrl="~/images/sheet.png" ToolTip="<%$ Resources:ExportReport %>" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                        </div>
                        
                    </div>

                    <div class="form-row">
<div class="form-group col-sm-2">
                            <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ" meta:resourcekey="LblFDate"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:DateValue %>" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ" meta:resourcekey="LblEDate"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                              <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:DateValue %>" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-2"></div>
                      
                    </div>
                 
                </fieldset>
    <hr /><br />
                <div class="form-check text-center">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="false" PageSize="200"
                        Width="100%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="<%$ Resources:NameCol %>" SortExpression="Name1" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:SR %>" SortExpression="FType" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <div class="form-group">
                                        <asp:HyperLink ID="lblFType" Text='<%# Bind("FType") %>' NavigateUrl='<%# Bind("FCode") %>' Target="_blank" runat="server"></asp:HyperLink>
                                    </div>
                                    
                                </ItemTemplate>
                             
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
    <div class="form-group">
        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
    </div>
                

</asp:Content>
