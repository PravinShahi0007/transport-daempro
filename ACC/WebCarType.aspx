<%@ Page Title="أنواع المركبات" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCarType.aspx.cs" Inherits="ACC.WebCarType" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
<<<<<<< HEAD
         <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
                <h3 align="right" >
                    [ أنواع المركبات ]</h3>
=======
        <div class="Round4Courner div1 col-md-10 col-md-offset-1 col-sm-12 col-xs-12" >
            <fieldset class="Rounded4CornersNoShadow" >
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ أنواع المركبات ]</b></legend>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
           
                
                      <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
<<<<<<< HEAD
                        <!--editing by chanda -->
=======
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                  <asp:Label ID="LblCode" runat="server" Text="تسلسل"></asp:Label>
                                <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" MaxLength="5"></asp:TextBox>
<<<<<<< HEAD
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" style="margin:-17px" ImageUrl="~/images/search2.png"
=======
                                <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" style="margin:-17px" ImageUrl="~/images/zoom_16.png"
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    ToolTip="البحث عن نوع مركبة" OnClick="BtnSearch_Click" />
                                <asp:RequiredFieldValidator ID="ValCode" runat="server"  ControlToValidate="txtCode"
                                    ErrorMessage="يجب إدخال التسلسل" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                          </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                 <asp:Label ID="Label2" runat="server" Text="الاسم عربي"></asp:Label>
                                <asp:TextBox ID="txtName1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                           </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label3" runat="server" Text="الاسم أنجليزي"></asp:Label>
                                <asp:TextBox ID="txtName2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                         </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                                  <asp:Label ID="Label7" runat="server" Text="حساب المصروف"></asp:Label>
                                <asp:DropDownList ID="ddlExpAcc" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValExpAcc" runat="server" ControlToValidate="ddlExpAcc"
                                    InitialValue="-1" Display="Dynamic" ErrorMessage="يجب أختيار حساب مصاريف الاصلاح"
                                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                          
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                    ValidationGroup="1" EnableClientScript="true" ShowSummary="true" ShowMessageBox="true" />
                                </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                     
                                <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                    ImageUrl="~/images/data add.png"   ToolTip="أضافة نوع جديد"
                                    ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات النوع؟")'
                                    OnClick="BtnNew_Click" />
                                <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                    ImageUrl="~/images/edit2.png"   ToolTip="تعديل بيانات نوع"
                                    Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                    ImageUrl="~/images/clear all.png"   ToolTip="مسح خانات الشاشة"
                                    OnClick="BtnClear_Click" />
                                <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                    ImageUrl="~/images/delete2.png"   ToolTip="إلغاء بيانات نوع" OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات النوع؟")'
                                    OnClick="BtnDelete_Click" />
                                <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                    ImageUrl="~/images/data search.png"   ToolTip="البحث عن بيانات نوع"
                                    OnClick="BtnSearch_Click" />
                          </div></div></div>
<<<<<<< HEAD
                      <div class="table table-responsive text-center">
=======
                      <div class="table-responsive">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="Code" AllowPaging="True"
                            PageSize="20" Width="100%" EmptyDataText="لا توجد بيانات" OnPageIndexChanging="grdCodes_PageIndexChanging"
                            OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="عرض بيانات نوع المركبة"
                                            ImageUrl="~/images/arrow_undo.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="النوع عربي" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="300px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="النوع أنجليزي" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="300px" />
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
                  
             </div></div></div>
<<<<<<< HEAD
           
        </div></div>
=======
            </fieldset>
        </div>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
      
</asp:Content>