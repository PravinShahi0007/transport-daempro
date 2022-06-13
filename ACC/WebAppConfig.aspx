<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebAppConfig.aspx.cs" Inherits="ACC.WebAppConfig" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="Round4Courner div1 col-md-10 col-md-offset-1 col-sm-12 col-xs-12" >
            <fieldset class="Rounded4CornersNoShadow"
                ">
                <legend align="right" style=" text-align: center;"><h3>
                    [إعدادات التوقيت / التطبيق ]</h3></legend>
              
               <div class="box box-info" align="right">
     <div class="body">
                                    <div class="row">
                                          <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                  <asp:Label ID="Label10" runat="server" Text="وقت تحديث الموقع الحالي للسائق*"></asp:Label>
                           
                                <asp:TextBox ID="txttime1" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox> / ثانية
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttime1"
                                    Display="Dynamic" ErrorMessage="يجب تحديد الوقت" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txttime1"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                          </div></div></div>
            <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                  <asp:Label ID="Label4" runat="server" Text="وقت تحديث طلبات شحن سيارة/إكسبرس*"></asp:Label>
                            
                                <asp:TextBox ID="txttime2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox> / ثانية
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttime2"
                                    Display="Dynamic" ErrorMessage="يجب تحديد الوقت" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txttime2"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                         </div></div></div>
                      
                             <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                  <asp:Label ID="Label3" runat="server" Text="وقت تحديث طلبات طوارئ/مياه/غاز*"></asp:Label>
                         
                                <asp:TextBox ID="txttime3" CssClass="form-control" runat="server" MaxLength="50" ></asp:TextBox> / ثانية
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttime3"
                                    Display="Dynamic" ErrorMessage="يجب تحديد الوقت" ForeColor="Red"
                                    SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txttime3"
                                       ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                         </div></div></div>
                                          <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="Label5" runat="server" Text="المستخدم"></asp:Label>
                          
                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox></div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                               <asp:Label ID="Label8" runat="server" Text="تاريخ الادخال"></asp:Label>
                          
                                <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">    </asp:TextBox>
                                                    </div></div></div>
                                          <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                    <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                           </div></div></div>
                        

                       <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1"
                                    EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                           </div></div></div>
                         <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل إعدادات التوقيت" Width="64px"
                                    ValidationGroup="1" OnClick="BtnEdit_Click" Text="تعديل" />
                        </div>

               </div></div></div>
            </fieldset>

           
        </div>
        <br />

</asp:Content>
