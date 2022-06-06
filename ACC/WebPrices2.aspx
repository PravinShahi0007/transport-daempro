<%@ Page Title="سياسة التسعير المطور" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebPrices2.aspx.cs" Inherits="ACC.WebPrices2" Culture="ar-EG" UICulture="ar-EG"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="JavaScript">
    function pageLoad() {
        $("input[name*='grdCodes'],select[name*='grdCodes']").change(function (event) {
            var res = event.target.id.split("_");
            var ctrl = document.getElementById("ContentPlaceHolder1_grdCodes_txtAction_" + res[3]);
            ctrl.value = "123";
            $(this).addClass('ChangedText');
            $(this).ToolTip = '1';
        });
        SetMyStyle();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
        <center>
            <div class="Round4Courner" style="width: 99.9%">
                <center>
                    <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Blue"
                        Text="سياسة التسعير"></asp:Label>
                </center>
                <table cellpadding="5px" cellspacing="5px" width="100%" style="text-align:right; color:Black; ">
                    <tr>
                        <td style="width:120px;">
                            <asp:Label ID="Label4" runat="server" Text="العميل"></asp:Label>
                        </td>
                        <td style="width:300px;">
                            <asp:DropDownList ID="ddlCustomer" Width="180px" runat="server" 
                                AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width:120px;">
                        </td>
                        <td style="width:300px;">


                        </td>
                    </tr>
                    <tr>
                        <td style="width:120px;">
                            <asp:Label ID="Label3" runat="server" Text="مستوى التسعير"></asp:Label>
                        </td>
                        <td style="width:300px;">
                            <asp:DropDownList ID="ddlLevel" Width="180px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width:120px;">
                            <asp:Label ID="Label2" runat="server" Text="المدينة"></asp:Label>
                        </td>
                        <td style="width:300px;">
                            <asp:DropDownList ID="ddlCity" Width="200px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div style="width: 100%; overflow: none; overflow-x: auto; border: 1px solid #800000;">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" 
                        DataKeyNames="FromCode,ToCode" AllowPaging="true"
                        PageSize="1000" Width="99.9%" 
                        onselectedindexchanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="من" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFromCode2" Text='<%# Bind("FromCode2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="70px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="إلى" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblToCode2" Text='<%# Bind("ToCode2") %>' runat="server"></asp:Label>
                                    <asp:HiddenField ID="txtAction" Value="" runat="server" />
                                </ItemTemplate>
                                <ControlStyle Width="70px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المسافة كم" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtKMeter" Text='<%# Bind("KMeter") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValKMeter" runat="server" ControlToValidate="txtKMeter"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                         
                            <asp:TemplateField HeaderText="زمن الوصول" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFTime" Text='<%# Bind("FTime") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValFTime" runat="server" ControlToValidate="txtFTime"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="60px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                         
                            <asp:TemplateField HeaderText="سعر الذهاب" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHOneWay" Text='<%# Bind("HOneWay") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValHOneWay" runat="server" ControlToValidate="txtHOneWay"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الادنى للذهاب" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLOneWay" Text='<%# Bind("LOneWay") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValLOneWay" runat="server" ControlToValidate="txtLOneWay"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سعر ذهاب وعوده" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHTwoWay" Text='<%# Bind("HTwoWay") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValHTwoWay" runat="server" ControlToValidate="txtHTwoWay"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الادنى ذهاب وعوده" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLTwoWay" Text='<%# Bind("LTwoWay") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValLTwoWay" runat="server" ControlToValidate="txtLTwoWay"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سطحة عادي" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEPrice1" Text='<%# Bind("ExPrice1") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValEPrice1" runat="server" ControlToValidate="txtEPrice1"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="هيدروليك" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEPrice2" Text='<%# Bind("ExPrice2") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValEPrice2" runat="server" ControlToValidate="txtEPrice2"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>                                
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="هيدروليك مغطى" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEPrice3" Text='<%# Bind("ExPrice3") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValEPrice3" runat="server" ControlToValidate="txtEPrice3"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المصروف" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCostAmount" Text='<%# Bind("CostAmount") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValCostAmount" runat="server" ControlToValidate="txtCostAmount"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
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
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                <br />
            </div>
                            <br />
                <div id="divEdit" runat="server" class="DivButtons" style="width: 95%">
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" CssClass="ops" ToolTip="تعديل سياسة التسعير"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                </div>
                <br />

        </center>
    </div>
</asp:Content>
