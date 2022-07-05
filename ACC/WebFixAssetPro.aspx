<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebFixAssetPro.aspx.cs" Inherits="ACC.WebFixAssetPro" Culture="ar-EG"
    UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="">
        <div class="form-group">
            <h4 class="text-center panel panel-heading">
                [ تشغيل اهلاكات الاصول الثابتة ]
            </h4>
            <br />
        </div>
     <div class="form-row">
         <div class="form-group col-sm-1">
             <asp:Label ID="Label2" runat="server" Text="من تاريخ"></asp:Label>
         </div>
         <div class="form-group col-sm-3">
             <asp:TextBox ID="txtFDate" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="ValFDate" runat="server" ControlToValidate="txtFDate" CultureInvariantValues="true"
                            Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                            ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                            TargetControlID="txtFDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                            PopupPosition="BottomLeft" />
                        <asp:RequiredFieldValidator ID="ValSType2" runat="server" ControlToValidate="txtFDate"
                            ForeColor="Red" InitialValue="0" SetFocusOnError="True" Display="Dynamic" ErrorMessage='يجب أختيار تاريخ بداية الفترة'
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
         </div>
         <div class="form-group col-sm-1">
             <asp:Label ID="LblEDate" runat="server" Text="إلى تاريخ"></asp:Label>
         </div>
         <div class="form-group col-sm-3">
             <asp:TextBox ID="txtEDate" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="ValEDate" runat="server" ControlToValidate="txtEDate" CultureInvariantValues="true"
                            Display="Dynamic" ErrorMessage="يجب أن تكون القيمة تاريخ" ForeColor="Red" Type="Date"
                            ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                            TargetControlID="txtEDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                            PopupPosition="BottomLeft" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEDate"
                            ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ErrorMessage='يجب أختيار تاريخ نهاية الفترة'
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
         </div>
         <div class="form-group col-sm-1">
             <asp:Label ID="Label1" runat="server" Text="بداية القيود"></asp:Label>
         </div>
         <div class="form-group col-sm-3">
             <asp:TextBox ID="txtStart" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStart"
                            ForeColor="Red" SetFocusOnError="True" Display="Dynamic" ErrorMessage='يجب أدخل تاريخ بداية تسلسل قيود الاهلاك'
                            ValidationGroup="1">*</asp:RequiredFieldValidator>
         </div>
     </div>
        <br />
        <div class="form-row">
            <div class="form-group col-sm-2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                EnableClientScript="true" ShowSummary="true" />
            </div>
            <div class="form-group col-sm-2">
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
            </div>
            <div class="form-group col-sm-2"> </div>
            <div class="form-group col-sm-2">
                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"
                  ImageUrl="~/images/reload2.png" ToolTip="تشغيل" OnClick="BtnProcess_Click" />
            </div>
            
            <div class="form-group col-sm-2">
                <asp:ImageButton ID="BtnPost" runat="server" Visible="false" AlternateText="ترحيل االقيد" ValidationGroup="1"
                  ImageUrl="~/images/Process.png" ToolTip="ترحيل االقيد" OnClick="BtnPost_Click" />
            </div>
            <div class="form-group col-sm-2"></div>
        </div>
      <div class="form">
            <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="true"
                GridLines="None" AutoGenerateColumns="False" AllowPaging="false"
                EmptyDataText="لا توجد بيانات">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="الحساب" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="form-group">
                                <asp:Label ID="lblCode" Text='<%# Bind("Code") %>' runat="server"></asp:Label>
                            </div>
                            
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="من تاريخ" SortExpression="FDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="form-group">
                                <asp:Label ID="lblFDate" Text='<%# Eval("fDate","{0:d}") %>' runat="server"></asp:Label>
                            </div>
                            
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="إلى تاريخ" SortExpression="TDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="form-group">
                                <asp:Label ID="lblTDate" Text='<%# Eval("TDate","{0:d}") %>' runat="server"></asp:Label>
                            </div>
                            
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="قيمة الاصل/الاضافة " SortExpression="Amount" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="form-group">
                                <asp:Label ID="lblAmount" Text='<%# Eval("Amount","{0:N2}") %>' runat="server"></asp:Label>
                            </div>
                            
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="النسبة" SortExpression="Per" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="form-group">
                                <asp:Label ID="lblPer" Text='<%# Bind("Per") %>' runat="server"></asp:Label>
                            </div>
                            
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الاهلاك" SortExpression="Total2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="form-group">
                                 <asp:Label ID="lblTotal" Text='<%# Eval("Total","{0:N2}") %>' runat="server"></asp:Label>
                            </div>
                           
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="form-group">
                                <asp:Label ID="lblTot" Text='<%# Tot %>' runat="server"></asp:Label>
                            </div>
                            
                        </FooterTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="صافي الاصل" SortExpression="Net2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="form-group">
                                <asp:Label ID="lblNet2" Text='<%# Eval("Net2","{0:N2}") %>' runat="server"></asp:Label>
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
            
    </fieldset>
</asp:Content>
