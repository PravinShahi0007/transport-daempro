<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebOfficial.aspx.cs" Inherits="ACC.WebOfficial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
  <div style="text-align: left; width: 99%; float: left;">
      <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
          onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
          RepeatColumns="3" Width="400px">
          <asp:ListItem Selected="True" Value="0">أوراق رسمية</asp:ListItem>
          <asp:ListItem Value="1">عقود أيجار</asp:ListItem>
          <asp:ListItem Value="2">عقود عملاء</asp:ListItem>
      </asp:RadioButtonList>


                                    <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                                        Direction="RightToLeft" ForeColor="#FFFF99">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: right;">
                                                المرفقات</div>
                                            <div style="float: right; margin-right: 20px;">
                                                <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                                            </div>
                                            <div style="float: left; vertical-align: middle;">
                                                <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#FFFFCC" Width="99.3%"
                                        BorderColor="Maroon">
                                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
                                            ShowHeader="false" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                                            Width="99%" OnRowDeleting="grdAttach_RowDeleting">
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
                                                    <ControlStyle Width="800px" />
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        </asp:GridView>
                                        <table width="100%">
                                            <tr>
                                                <td align="right">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                                        ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                                        ValidationGroup="1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                                        ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label34"
                                        ImageControlID="Image1" ExpandedText="(أخفاء التفاصيل)" CollapsedText="(عرض التفاصيل)"
                                        ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        SuppressPostBack="true" />
                                </div>
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
</center>
</asp:Content>
