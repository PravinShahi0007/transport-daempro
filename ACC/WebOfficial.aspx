<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebOfficial.aspx.cs" Inherits="ACC.WebOfficial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="card">
            <div class="form-row">
                <div class="form-group  col-md-12 col-sm-12 col-xm-12">

               
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                RepeatColumns="3" CssClass="form-control">
                <asp:ListItem Selected="True" Value="0">أوراق رسمية</asp:ListItem>
                <asp:ListItem Value="1">عقود أيجار</asp:ListItem>
                <asp:ListItem Value="2">عقود عملاء</asp:ListItem>
            </asp:RadioButtonList>
                     </div>
            </div>
            <!--editing by chanda verma-->
             <div class="form-row">
                 <div class="form-group  col-md-12 col-sm-12 col-xm-12">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">المرفقات
                                    <asp:Label ID="Label34" runat="server">(عرض التفاصيل)</asp:Label>
                    </h4>
                    <div class="card-tools">
                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
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
                                    <ControlStyle Width="800px" />
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
                        <%--<table width="100%">
                                            <tr>
                                                <td align="right">
                                                    
                                                </td>
                                                <td align="left">
                                                    
                                                </td>
                                            </tr>
                                        </table>--%>
                    </asp:Panel>
                    <div class="form-row">
                        <div class="col-sm-6">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                        <div class="col-sm-6">
                            <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="مرفقات" CommandName="Attach"
                                ImageUrl="~/images/attach2.png" OnClick="BtnAttach_Click" ToolTip="المرفقات"
                                ValidationGroup="1" />
                        </div>
                    </div>
                </asp:Panel>
                </div>
                    <!--editing by chanda verma-->

            </div>
            </div>
            </div>
            </div>
            
            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
           
  
</asp:Content>
