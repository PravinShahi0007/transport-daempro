<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebTaxRep.aspx.cs" Inherits="ACC.WebTaxRep" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRound4Courner">
            <div style="text-align: right; float: right; display: block;">
            </div>
            <center>
                <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                    border: solid 2px #800000">
                    <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                        الاقرار  الضريبي</legend>
                    <table width="99%">
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label3" runat="server" Text="الفترة"></asp:Label>
                            </td>
                            <td colspan="2" align="right" style="width:200px" >
                                <asp:DropDownList ID="ddlMonth" Width="200px" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td rowspan="3" style="text-align: center">
                                <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"   
                                    ImageUrl="~/images/Process.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print_64A.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" />                                    
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td colspan="2" align="right" >
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="text-align: right;">
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <div style="width: 100%; height:500px; overflow:none; overflow-x:auto ;border: 1px solid #800000;">
                    <table id="box-table-a1" width="98%" cellpadding="2px" cellspacing="5px" border="1px" style="color: Black; border-color: Black; border-style: solid;">
                        <tr>
                            <td style="width: 150px">
                                <asp:Label ID="Label1" runat="server" Text="أجمالي المبيعات"></asp:Label>
                            </td>
                            <td style="width: 150px">
                                <asp:Label ID="lblTotSales" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 150px">
                                <asp:Label ID="Label4" runat="server" Text="القيمة المضافة"></asp:Label>
                            </td>
                            <td style="width: 150px">
                                <asp:Label ID="lblTotSTax" runat="server" Text=""></asp:Label>
                            </td>                        
                        </tr>                                                            
                        <tr>
                            <td style="width: 150px">
                                <asp:Label ID="Label2" runat="server" Text="المشتريات"></asp:Label>
                            </td>
                            <td style="width: 150px">
                                <asp:Label ID="lblTotPurchases" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 150px">
                                <asp:Label ID="Label6" runat="server" Text="القيمة المضافة"></asp:Label>
                            </td>
                            <td style="width: 150px">
                                <asp:Label ID="lblTotPTax" runat="server" Text=""></asp:Label>
                            </td>                        
                        </tr>                                                            
                        <tr>
                            <td style="width: 150px">
                            </td>
                            <td style="width: 150px">
                            </td>
                            <td style="width: 150px">
                                <asp:Label ID="Label10" runat="server" Text="صافي القيمة المضافة"></asp:Label>
                            </td>
                            <td style="width: 150px" bgcolor="#FFFFCC">
                                <asp:Label ID="lblNetTax" runat="server" Text=""></asp:Label>
                            </td>                        
                        </tr>                                                            
                    </table>                    
                </div>
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                <br />
            </center>
        </div>
    </center>
</asp:Content>
