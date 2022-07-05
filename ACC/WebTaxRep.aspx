<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebTaxRep.aspx.cs" Inherits="ACC.WebTaxRep" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
                <fieldset class="card text-center">
                    <div class="form-group">
                        <h4 class="text-muted">
                            الاقرار  الضريبي
                        </h4>
                    </div>
                <hr />
                    <br />
                    <div class="form-row">
                        <div class="form-group col-sm-2">
                            <asp:Label ID="Label3" runat="server" Text="الفترة"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-4"></div>
                        <div class="form-group col-sm-3">
                            <asp:ImageButton ID="BtnProcess" runat="server" AlternateText="تشغيل" ValidationGroup="1"   
                                    ImageUrl="~/images/setting.png" ToolTip="تشغيل التقرير" OnClick="BtnProcess_Click" />
                                <asp:ImageButton ID="BtnPrint1" ToolTip="Print" CommandName="1" runat="server" ImageUrl="~/images/print.png"
                                      OnCommand="BtnPrint1_Command" OnClientClick="aspnetForm.target ='_blank';" /> 
                        </div>
                    </div>
                    
                </fieldset>
    <hr />
    <br />
                <div id="box-table-a1">
                    <div class="form-row">
                        <div class="form-group col-sm-3">
                            <asp:Label ID="Label1" runat="server" CssClass="form-control" Text="أجمالي المبيعات"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="lblTotSales" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="Label4" runat="server" CssClass="form-control" Text="القيمة المضافة"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="lblTotSTax" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-sm-3">
                            <asp:Label ID="Label2" runat="server" CssClass="form-control" Text="المشتريات"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="lblTotPurchases" CssClass="form-control" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="Label6" runat="server" CssClass="form-control" Text="القيمة المضافة"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="lblTotPTax" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group form-control col-sm-3">
                            
                        </div>
                        <div class="form-group col-sm-3 form-control">
                            
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="Label10" runat="server" CssClass="form-control" Text="صافي القيمة المضافة"></asp:Label>
                        </div>
                        <div class="form-group col-sm-3">
                            <asp:Label ID="lblNetTax" runat="server" CssClass="form-control" Text=""></asp:Label>
                        </div>
                    </div>
                                   
                </div>
    <div class="form-group">
        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
    </div>

 </div>
</asp:Content>
