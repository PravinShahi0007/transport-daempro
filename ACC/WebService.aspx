<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" Culture="auto:ar-EG" UICulture="auto"
    CodeBehind="WebService.aspx.cs" Inherits="ACC.WebService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="col-md-12  col-sm-12 col-xs-12">
      <div class="card card-body">
                <h3 id="leg1" runat="server" align="<%$ Resources:Resource, dir2 %> center" ><b>
                <asp:Literal ID="Literal2" Text="<%$ Resources:Header %>" runat="server"></asp:Literal></b></h3>
              <!--By Ankur Kumar-->
                  <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCode" runat="server" Text="كود الخدمة*" meta:resourcekey="LblCode" ></asp:Label>
                          
                                <asp:TextBox ID="txtITCode" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                    ToolTip="<%$ Resources:SearchCode %>" OnClick="BtnFind_Click" />
                                <asp:RequiredFieldValidator ID="ValCode" runat="server" ControlToValidate="txtITCode"
                                    ErrorMessage="<%$ Resources:EnterCode %>" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                         </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="الاسم عربي" meta:resourcekey="Label2"></asp:Label>
                           
                                <asp:TextBox ID="txtITName1" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                        </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي" meta:resourcekey="Label3"></asp:Label>
                         
                                <asp:TextBox ID="txtITName2" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                        </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label5" runat="server" Text="حساب المصروف" meta:resourcekey="Label5"></asp:Label>
                        
                                <asp:DropDownList ID="ddlExpenses" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                        </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label6" runat="server" Text="حساب الايراد" meta:resourcekey="Label6"></asp:Label>
                       
                                <asp:DropDownList ID="ddlRevenue" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                         </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="الحد الادنى / ساعة" meta:resourcekey="Label1"></asp:Label>
                          
                                <asp:TextBox ID="txtLTime" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLTime"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:NumericValue %>" ForeColor="Red" Type="Double"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                       </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="الحد الاقصى / ساعة" meta:resourcekey="Label4"></asp:Label>
                        
                                <asp:TextBox ID="txtHTime" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtHTime"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:NumericValue %>" ForeColor="Red" Type="Double"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label26" runat="server" Text="السعر" meta:resourcekey="Label26"></asp:Label>
                     
                                <asp:TextBox ID="txtITSPrice1" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtITSPrice1"
                                    Display="Dynamic" ErrorMessage="<%$ Resources:NumericValue %>" ForeColor="Red" Type="Currency"
                                    ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                     </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label14" runat="server" Text="المستخدم" meta:resourcekey="Label14"></asp:Label>
                      
                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                        </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label15" runat="server" Text="بتاريخ" meta:resourcekey="Label15"></asp:Label>
                      
                                <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="* حقول الزامية" meta:resourcekey="Label27"></asp:Label>
                           
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                         </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                          
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="<%$ Resources:New %>" CommandName="New"
                                    ImageUrl="~/images/data add.png" CssClass="ops" ToolTip="<%$ Resources:NewTooltip %>"
                                    ValidationGroup="1" OnClientClick='<%$ Resources:NewConfirm %>'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="<%$ Resources:Edit %>" CommandName="Edit"
                                    ImageUrl="<%$ Resources:EditImage %>" CssClass="ops" ToolTip="<%$ Resources:EditTooltip %>"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="<%$ Resources:Clear %>" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png" CssClass="ops" ToolTip="<%$ Resources:ClearTooltip %>"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="<%$ Resources:Delete %>" CommandName="Delete"
                                    ImageUrl="<%$ Resources:DeleteImage %>" CssClass="ops" ToolTip="<%$ Resources:DeleteTooltip %>" OnClientClick='<%$ Resources:DeleteConfirm %>'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="<%$ Resources:Search %>" CommandName="Find"
                                    ImageUrl="~/images/data search.png" CssClass="ops" ToolTip="<%$ Resources:SearchTooltip %>"
                                    OnClick="BtnSearch_Click" />
                          </div></div></div></div></div></div>
             
           </div>
        </div>
  
</asp:Content>
