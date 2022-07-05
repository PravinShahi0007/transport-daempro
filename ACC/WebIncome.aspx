<%@ Page Title="قائمة الدخل" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebIncome.aspx.cs" Inherits="ACC.WebIncome" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
        <div class="form text-center">
                <fieldset>
                    <div class="form-group">
                        <h4 class="text-muted">
                            قائمة الدخل
                        </h4>
                    </div>
                    <hr />
                    <br />
                   
                    <div class="form-row">
                        <div class="form-group col-sm-2"></div>
                        <div class="form-group col-sm-2">
                            <asp:CheckBox ID="ChkPeriod" CssClass="form-control" runat="server" Checked="True" Text="جميع الفترات" AutoPostBack="True"
                                    OnCheckedChanged="ChkPeriod_CheckedChanged" />
                        </div>
                        
                        <div class="form-group col-sm-5">
                           
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                    OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />
                                <asp:ImageButton ID="BtnExcel" runat="server" AlternateText="تصدير للإكسل" CommandName="Excel"
                                    ImageUrl="~/images/sheet.png" ToolTip="'طباعة بيانات التقرير" OnClientClick="aspnetForm.target ='_blank';"
                                    OnClick="BtnExcel_Click" />
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="LblEDate" runat="server" Visible="false" Text="إلى تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                             <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtEDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
<div class="form-group col-sm-2">
                            <asp:Label ID="LblFDate" runat="server" Visible="false" Text="من تاريخ"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" Visible="false" 
                                    runat="server" AutoPostBack="True" ontextchanged="txtFDate_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate" CultureInvariantValues="true"
                                    Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                    PopupPosition="BottomLeft" />
                        </div>
                        <div class="form-group col-sm-2"></div>
                     
                    </div>
                 <!--+++++++++++++++++++++++++++++++ Ankur kumar +++++++++++++++++++++++++++++++++++-->
                </fieldset>
            <hr />
            <br />
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="false" PageSize="200"
                        Width="100%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="البيان" SortExpression="Name1" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <div class="form-group">.
                                        <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                    </div>
                                    
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ريال سعودي" SortExpression="FType" ItemStyle-HorizontalAlign="Right">
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
    
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                <br />
           
        </div>
   
</asp:Content>
