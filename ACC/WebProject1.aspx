<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebProject1.aspx.cs" Inherits="ACC.WebProject1" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ مشروع ديوان المظالم - المرحلة الاولى]"></asp:Label>
                </b></legend>
                <center>
                    <table width="99%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label3" runat="server" Text="المرحلة"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">

                                <asp:RadioButtonList ID="rdoStep" Width="300px" runat="server" 
                                    RepeatColumns="2" AutoPostBack="True" 
                                    onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                    <asp:ListItem Value="0">المرحلة الاولى</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="1">المرحلة الثانية</asp:ListItem>
                                </asp:RadioButtonList>

                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                            </td>
                            <td align="right">
                            </td>
                        </tr>

                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label1" runat="server" Text="أختار الموقع"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="1">الإدارية بالرياض</asp:ListItem>
                                    <asp:ListItem Value="2">استئناف الرياض</asp:ListItem>
                                    <asp:ListItem Value="3">الإدارية بجدة</asp:ListItem>
                                    <asp:ListItem Value="4">استئناف مكة بجدة</asp:ListItem>
                                    <asp:ListItem Value="5">الإدارية بمكة</asp:ListItem>
                                    <asp:ListItem Value="6">الإدارية بالدمام</asp:ListItem>
                                    <asp:ListItem Value="7">استئناف الشرقية</asp:ListItem>
                                    <asp:ListItem Value="8">الإدارية بالمدينة</asp:ListItem>
                                    <asp:ListItem Value="9">استئناف المدينة</asp:ListItem>
                                    <asp:ListItem Value="10">الإدارية ببريدة</asp:ListItem>
                                    <asp:ListItem Value="11">الإدارية حائل</asp:ListItem>
                                    <asp:ListItem Value="12">الإدارية بأبها</asp:ListItem>
                                    <asp:ListItem Value="13">استئناف أبها</asp:ListItem>
                                    <asp:ListItem Value="14">الإدارية بتبوك</asp:ListItem>
                                    <asp:ListItem Value="15">الإدارية بسكاكا</asp:ListItem>
                                    <asp:ListItem Value="16">الإدارية بعرعر</asp:ListItem>
                                    <asp:ListItem Value="17">الإدارية بنجران</asp:ListItem>
                                    <asp:ListItem Value="18">الإدارية بجازان</asp:ListItem>
                                    <asp:ListItem Value="19">الإدارية بالباحة</asp:ListItem>
                                    <asp:ListItem Value="20">ديوان المظالم</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:HyperLink ID="BtnMyLoc" Target="_blank" NavigateUrl="" runat="server">عرض الموقع</asp:HyperLink>
                            </td>
                            <td align="right">
                                <asp:Button ID="BtnSendSMS" runat="server" style="text-align: center" 
                                    Text="إرسال الموقع على جوال المشرف" onclick="BtnSendSMS_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                أسم المشرف</td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtSponsor" ReadOnly="true" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="Label11" runat="server" Text="أسم المساعد"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txtSponsor2" ReadOnly="true" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label12" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblChqDate" runat="server" Text="وسيلة النقل"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:TextBox ID="txtCar" Width="300px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label2" runat="server" Text="عدد الصناديق"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtBoxNo" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="BtnBarCode" runat="server" Text="طباعة الباركود" 
                                    onclick="BtnBarCode_Click" />
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:Button ID="BtnBarCode0" runat="server" Text="طباعة النماذج" 
                                    onclick="BtnBarCode0_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                &nbsp;</td>
                            <td align="right" style="width: 35%;">
                                &nbsp;</td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                &nbsp;</td>
                            <td align="right" style="width: 34%;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="Label35" runat="server" Text="أسم رئيس الديوان"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtPerson" MaxLength="50" ReadOnly="true" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblBankName" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:TextBox ID="txtPMobileNo" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblPerson1" runat="server" Text="أسم عضو الديوان"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtPerson1" MaxLength="50" ReadOnly="true" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblPMobileNo1" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:TextBox ID="txtPMobileNo1" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblPerson2" runat="server" Text="أسم عضو الديوان"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtPerson2" MaxLength="50" ReadOnly="true" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblPMobileNo2" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:TextBox ID="txtPMobileNo2" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblPerson3" runat="server" Text="أسم عضو الديوان"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtPerson3" MaxLength="50" ReadOnly="true" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblPMobileNo3" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:TextBox ID="txtPMobileNo3" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblPerson4" runat="server" Text="أسم عضو الديوان"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtPerson4" MaxLength="50" ReadOnly="true" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblPMobileNo4" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:TextBox ID="txtPMobileNo4" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:Label ID="lblPerson5" runat="server" Text="أسم عضو الديوان"></asp:Label>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:TextBox ID="txtPerson5" MaxLength="50" ReadOnly="true" Width="300px" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Label ID="lblPMobileNo5" runat="server" Text="رقم الجوال"></asp:Label>
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:TextBox ID="txtPMobileNo5" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                            </td>
                        </tr>                  
                        <tr>
                            <td align="right" style="width: 15%;">
                                <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl="images/الصندوق%20رقم%201%20الجانب%201.jpg" runat="server">صندوق 1 جانب 1</asp:HyperLink>
                            </td>
                            <td align="right" style="width: 35%;">
                                <asp:HyperLink ID="HyperLink2" Target="_blank" NavigateUrl="images/الصندوق%20رقم%201%20الجانب%202.jpg" runat="server">صندوق 1 جانب 2</asp:HyperLink>
                            </td>
                            <td align="right" style="width: 1%;">
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:HyperLink ID="HyperLink3" Target="_blank" NavigateUrl="images/الصندوق%20رقم%201%20الجانب%203.jpg" runat="server">صندوق 1 جانب 3</asp:HyperLink>
                            </td>
                            <td align="right" style="width: 34%;">
                                <asp:HyperLink ID="HyperLink4" Target="_blank" NavigateUrl="images/الصندوق%20رقم%201%20الجانب%204.jpg" runat="server">صندوق 1 جانب 4</asp:HyperLink>
                            </td>
                        </tr>                  
                    </table>
                    <br />
               <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </center>
                <div style="text-align: left; width: 50%; float: left;">
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
                        <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                            ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                            Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                                    <ControlStyle Width="300px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
            </fieldset>
        </div>
    </center>
</asp:Content>
