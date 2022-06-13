<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebProfile.aspx.cs" Inherits="ACC.WebProfile" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Styles/PrevCheckList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" runat="server" CssClass="ColorRounded4Corners col-md-10 col-md-offset-1 col-sm-12 col-xs-12" >
      <div class="box box-info" align="right">
     <div class="body">
                                    <div class="row">
   
     <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
           
                            <asp:Label ID="LblCode" runat="server" Text="اسم المستخدم"></asp:Label>
                   
                        <asp:TextBox ID="txtName" ReadOnly="true" runat="server" CssClass="MouseStop form-control"
                            MaxLength="20"></asp:TextBox>
                    </div>
               </div></div>
               <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                          <asp:Label ID="Label33" runat="server" Text="عضو بمجموعة"></asp:Label>
                  
                        <asp:TextBox ID="txtRole" ReadOnly="true"  runat="server" CssClass="MouseStop form-control"
                            MaxLength="20"></asp:TextBox>
                    </div></div></div>

        <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                   
                        <img id="ImgPhoto" runat="server" src="images/123.jpg" alt="Photo" class="img-circle" />
                     <asp:FileUpload ID="FileUpload0" Width="167px" runat="server" />
                        </div>
              </div></div>
 
                
                    <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
            
                           <asp:Label ID="Label3" runat="server" Text="الاسم بالكامل"></asp:Label>
                    
                        <asp:TextBox ID="txtFName"  runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                    </div></div></div>
              
                    <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                         <asp:Label ID="Label36" runat="server" Text="الصلاحية البديلة"></asp:Label>                        
                   
                        <asp:TextBox ID="txtBranRoll" ReadOnly="true" CssClass="MouseStop form-control" 
                            runat="server" MaxLength="50"></asp:TextBox>
                   
                </div></div></div>
                
             
                   <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                          <asp:Label ID="Label35" runat="server" Text="الفرع الرئيسي"></asp:Label>
                  
                        <asp:TextBox ID="txtMainBran" ReadOnly="true" CssClass="MouseStop form-control" 
                            runat="server" MaxLength="50"></asp:TextBox>
                    </div></div></div>
               
                 <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                            <asp:Label ID="Label34" runat="server" Text="الفروع البديلة"></asp:Label>
                  
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1"
                            BorderColor="Maroon" Width="100%" Height="175px">
                            <asp:CheckBoxList ID="ChkBranch" runat="server" Enabled="false" CssClass="MouseStop form-control">
                            </asp:CheckBoxList>
                        </asp:Panel>
                  
                </div></div></div>
              
               
                   <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                          <asp:Label ID="Label8" runat="server" Text="الايميل"></asp:Label>    
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                    
                   
                </div>
               </div></div>
                
                    <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                           <asp:Label ID="Label5" runat="server" Text="رقم التليفون"></asp:Label>
                    
                        <asp:TextBox ID="txtTel" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                  
                  
                </div></div></div>
              
                  
                   <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                          <asp:Label ID="Label6" runat="server" Text="رقم الموبيل"></asp:Label>
                 
                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                   
                </div></div></div>
               
                    <div class="col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-float">
                                                <div class="form-line">
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" 
                                        CommandName="Edit" ValidationGroup="1"
                                        ImageUrl="~/images/draw_pen_642.png" ToolTip="تعديل بيانات أعدادات النظام"
                                        Width="64px" onclick="BtnEdit_Click"   />
                    </div></div></div>
                  
                   <div class="col-md-2 col-sm-12 col-xs-12 text-center">
                        <asp:Button ID="BtnLoad0" runat="server" CssClass="btn btn-primary" Text="تحميل الصورة" OnClick="BtnLoad0_Click" />                        
                  
                </div>
             
       
               </div>
         </div>
              <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                <asp:CheckBoxList ID="ChkPass" Width="60%" runat="server" Enabled="false" CssClass="chicklist MouseStop"
                    CellPadding="2" CellSpacing="2">
                </asp:CheckBoxList>
         
            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label></div>
         </div>
    </asp:Panel>
</asp:Content>
