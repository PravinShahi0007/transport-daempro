<%@ Page Title="" Language="C#" MasterPageFile="~/SupportSite.Master" AutoEventWireup="true" CodeBehind="Default_Support.aspx.cs" Inherits="ACC.Default_Support" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="mdiv2" runat="server" class="Rounded4Corners div2" style="<%$ Resources: mDiv1 %>">
        <center>
            <b>
                <asp:Label ID="Label5" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ فواتير معلقة ]"></asp:Label></b></center>
        <asp:GridView ID="grdInv" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false"
            AllowPaging="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="False"
            DataKeyNames="InvNo,Area,Code" Width="90%" EmptyDataText="لا توجد بيانات" OnRowDeleting="grdInv_RowDeleting">
            <Columns>
                <asp:TemplateField SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <i class="fa fa-eye" style='cursor: pointer;' runat="server" id="bbView"  onclick='<%# Eval("UserName") %>'></i>
                    </ItemTemplate>
                    <ControlStyle Width="30px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="تسلسل" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lblFNo" Text='<%# Bind("Name1") %>' ToolTip='<%# Bind("City") %>'
                            runat="server"></asp:HyperLink>
                    </ItemTemplate>
                    <ControlStyle Width="120px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                            ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <span id="span3" runat="server" style="<%$ Resources: float %>">&nbsp;&nbsp;&nbsp;</span>
    <div id="DivHold" class="Rounded4Corners div4" style="width: 235px; height: 300px;
        float: right; border: thin solid #444444; overflow: hidden; overflow-x: hidden;
        overflow-y: auto;">
        <center>
            <b>
                <asp:Label ID="Label2" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ طلبات معلقة ]"
                    meta:resourcekey="Label2"></asp:Label></b></center>
        <div style="width: 100%; text-align: left">
            <asp:DropDownList ID="ddlDays" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDays_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <asp:BulletedList ID="bllPO" Target="_blank" Width="95%" DisplayMode="HyperLink"
            CssClass="Bullet" runat="server">
        </asp:BulletedList>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
   <div id="DivInfo" runat="server" class="Rounded4Corners div1" style="<%$ Resources: mDivInfo %>">
        <center>      
            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th>
                            الوظيفة
                        </th>
                        <th>
                            الاسم
                        </th>
                        <th>
                            رقم الجوال
                        </th>
                        <th>
                            رقم الهاتف
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(5)%>                      
                </tbody>
            </table>
            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th colspan="3" align="center">
                            أرقام بنوك الناقلات البرية
                        </th>
                    </tr>
                    <tr>
                        <th>
                            البنك
                        </th>
                        <th>
                            رقم الحساب
                        </th>
                        <th>
                            الايبان
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(1)%>                       
                </tbody>
            </table>
            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th>
                            حسابات الإدارة
                        </th>
                        <th>
                            القسم
                        </th>
                        <th>
                            البنك
                        </th>
                        <th>
                            رقم الحساب
                        </th>
                        <th>
                            الايبان
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(2)%>                           
                </tbody>
            </table>
                  <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th>
                            حسابات مراقبي الفروع
                        </th>
                        <th>
                            الفرع
                        </th>
                        <th>
                            البنك
                        </th>
                        <th>
                            رقم الحساب
                        </th>
                        <th>
                            الايبان
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(3)%>                         
                </tbody>
            </table>
            <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th>
                            حسابات الموردين
                        </th>
                        <th>
                            البنك
                        </th>
                        <th>
                            رقم الحساب
                        </th>
                        <th>
                            الايبان
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(4)%>                    
                </tbody>
            </table>

             <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th colspan="3" align="center">
                            وصف مواقع فروع الناقلات البرية
                        </th>
                    </tr>
                    <tr>
                        <th>
                            الفرع
                        </th>
                        <th>
                            الموقع
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%=getStartData(6)%>                      
                </tbody>
            </table>
        </center>
    </div>
    &nbsp;
    <br />
    <br />    

      <a name="7"></a>
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ تنبيهات الشاحنات ]</b></legend>

            <asp:GridView ID="grdCarAlert" runat="server" CellPadding="4" ForeColor="Black"
                GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Code" Width="99.9%"
                EmptyDataText="لا توجد بيانات" BackColor="White" BorderColor="#DEDFDE" 
                BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>                
                    <asp:TemplateField HeaderText="م" SortExpression="WorkShopCode" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" Text='<%# Bind("WorkShopCode") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="الرقم" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarNo" Text='<%# Eval("Code") %>'  NavigateUrl='<%# UrlHelper("110" ,Eval("Code"))%>' ToolTip='<%# Bind("PLoc") %>' Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="85px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الاستمارة" SortExpression="strDate1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate1" Text='<%# Bind("strDate1") %>' ToolTip='<%# Bind("PLoc1") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="التامين" SortExpression="strDate2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate2" Text='<%# Bind("strDate2") %>' ToolTip='<%# Bind("PLoc2") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="بطاقة التشغيل" SortExpression="strDate3" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate3" Text='<%# Bind("strDate3") %>' ToolTip='<%# Bind("PLoc3") %>' runat="server"></asp:Label>
                       </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الفحص الدوري" SortExpression="strDate4" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate4" Text='<%# Bind("strDate4") %>' ToolTip='<%# Bind("PLoc4") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تامين حمولة" SortExpression="strDate5" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate5" Text='<%# Bind("strDate5") %>' ToolTip='<%# Bind("PLoc5") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" VerticalAlign="Middle"
                    HorizontalAlign="Center" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </fieldset>
        <br />
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ تنبيهات السيارات - الفروع ]</b></legend>

            <asp:GridView ID="grdCarAlert2" runat="server" CellPadding="4" ForeColor="Black"
                GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Code" Width="99.9%"
                EmptyDataText="لا توجد بيانات" BackColor="White" BorderColor="#DEDFDE" 
                BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>                
                    <asp:TemplateField HeaderText="م" SortExpression="WorkShopCode" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" Text='<%# Bind("WorkShopCode") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="الرقم" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarNo" Text='<%# Eval("Code") %>'  NavigateUrl='<%# UrlHelper("110" ,Eval("Code"))%>' ToolTip="عرض السيارة" Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="اللوحة" SortExpression="PlateNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPlateNo" Text='<%# Bind("PlateNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الاستمارة" SortExpression="strDate1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate1" Text='<%# Bind("strDate1") %>' ToolTip='<%# Bind("PLoc1") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="التامين" SortExpression="strDate2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate2" Text='<%# Bind("strDate2") %>' ToolTip='<%# Bind("PLoc2") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الفحص الدوري" SortExpression="strDate4" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate4" Text='<%# Bind("strDate4") %>' ToolTip='<%# Bind("PLoc4") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="موقع السيارة" SortExpression="PLoc" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPLoc" Text='<%# Bind("PLoc") %>'  runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" VerticalAlign="Middle"
                    HorizontalAlign="Center" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </fieldset>
        <br />
        <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99%;
            border: solid 2px #800000">
            <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                <b>[ تنبيهات الوثائق الشخصية للموظفين ]</b></legend>

            <asp:GridView ID="grdPaperAlert" runat="server" CellPadding="4" ForeColor="Black"
                GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Code" Width="99.9%"
                EmptyDataText="لا توجد بيانات" BackColor="White" BorderColor="#DEDFDE" 
                BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>                
                    <asp:TemplateField HeaderText="م" SortExpression="InvNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" Text='<%# Bind("InvNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="الرقم" SortExpression="Code" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lblCarNo" Text='<%# Eval("Code") %>'  NavigateUrl='<%# UrlHelper("222" ,Eval("Code"))%>' ToolTip="عرض بيانات الموظف" Target="_blank" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الاسم" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPlateNo" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="200px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الهوية" SortExpression="SiteAcc" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate1" Text='<%# Bind("SiteAcc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="جواز السفر" SortExpression="TripAcc" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblstrDate2" Text='<%# Bind("TripAcc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="125px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" VerticalAlign="Middle"
                    HorizontalAlign="Center" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </fieldset>
        <br />
        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
</asp:Content>
