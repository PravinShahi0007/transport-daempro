<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="WebEmpCodes.aspx.cs" Inherits="ACC.WebEmpCodes" Culture="ar-EG" UICulture="ar-EG"  MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        
            <div class="ColorRounded4Corners col-md-10 col-md-offset-1 col-sm-12 col-xs-12">
                
                     <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                    <asp:Label ID="Label1" runat="server" Font-Size="Larger" meta:resourcekey="Label1"
                        Text=" البند"></asp:Label>
                  
                    <asp:DropDownList ID="ddlFtype" runat="server" CssClass="form-control" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlFtype_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="1" Text="الجنسية"></asp:ListItem>
                        <asp:ListItem Value="2" Text="الوظيفة"></asp:ListItem>
                        <asp:ListItem Value="3" Text="القسم"></asp:ListItem>
                        <asp:ListItem Value="4" Text="المؤهل"></asp:ListItem>
                        <asp:ListItem Value="5" Text="محل أصدار "></asp:ListItem>
                        <asp:ListItem Value="6" Text="الديانة"></asp:ListItem>
                        <asp:ListItem Value="7" Text="مكان الميلاد"></asp:ListItem>
                        <asp:ListItem Value="8" Text="البنك"></asp:ListItem>
                        <asp:ListItem Value="9" Text="الكفيل"></asp:ListItem>
                        <asp:ListItem Value="10" Text="أنواع الاجازات"></asp:ListItem>
                        <asp:ListItem Value="19" Text="الإدارة"></asp:ListItem>
                        <asp:ListItem Value="20" Text="توقيتات الحضور و الانصراف"></asp:ListItem>
                        <asp:ListItem Value="30" Text="ملحقات الشاحنات"></asp:ListItem>
                    </asp:DropDownList>
         </div></div></div>
               <div class="table-responsive">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="Code" 
                        AllowPaging="True" Width="99.9%" OnRowUpdating="grdCodes_RowUpdating" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowCommand="grdCodes_RowCommand"
                        OnRowDeleting="grdCodes_RowDeleting" OnRowEditing="grdCodes_RowEditing" 
                        OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="اختيار البند"
                                        ImageUrl="~/images/arrow_undo.png" />
                                    <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="تعديل البند"
                                        ImageUrl="~/images/pencil.png" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="حفظ التعديلات"
                                        ImageUrl="~/images/accept.png"  onload="btnUpdate_Load" />
                                    <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="تجاهل التعديلات"
                                        ImageUrl="~/images/delete.png" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="اضافة بند جديد"
                                        ImageUrl="~/images/add.png" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="البيان عربي" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName1" MaxLength="50" Text='<%# Bind("Name1") %>' runat="server"
                                        Width="99%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName1" MaxLength="50" runat="server" Width="99%" />
                                </FooterTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="البيان أنجليزي" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName2" MaxLength="50" Text='<%# Bind("Name2") %>' runat="server"
                                        Width="99%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName2" MaxLength="50" runat="server" Width="99%" />
                                </FooterTemplate>
                                <ControlStyle Width="200px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الحمولة" SortExpression="FType2"  Visible="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFType" Text='<%# Bind("FType2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFType" MaxLength="50" Text='<%# Bind("FType2") %>' runat="server"
                                        Width="99%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFType" MaxLength="50" runat="server" Width="99%" />
                                </FooterTemplate>
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
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
               
            </div>
       
    </div></div></div>
</asp:Content>
