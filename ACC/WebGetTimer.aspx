<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebGetTimer.aspx.cs" Inherits="ACC.WebGetTimer" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="ColorRounded4Corners col-md-10 col-md-offset-1 col-sm-12 col-xs-12">
                <fieldset class="Rounded4CornersNoShadow" >
                    <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                        أستيراد بيانات الحضور و الانصراف</legend>
                       <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                    <asp:FileUpload ID="Fp1" runat="server" CssClass="form-control" />
                                    </div></div></div>
                         <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                
                    <asp:RadioButtonList ID="rdoTimers" runat="server">
                    </asp:RadioButtonList>
                    <asp:Button ID="btnConnect" runat="server"  Visible="false" Text="Connect" 
                        onclick="btnConnect_Click" /> 
                     
                    <asp:Button ID="Button2" runat="server"  Visible="false" Text="عدد السجلات" 
                        onclick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server"  Visible="false" Text="استيراد البيانات" 
                        onclick="Button1_Click" />
                    <asp:Button ID="Button3" runat="server"  Visible="false" Text="مسح البيانات" 
                        onclick="Button3_Click"  /></div></div></div>
                    
                                      <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div class="form-group form-float">
                                <div class="form-line">
                    <asp:Button ID="btnImportFromFile" runat="server"  CssClass="btn btn-primary"
                        onclick="btnImportFromFile_Click" Text="استيراد من ملف" />
                  
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label></div>     </div></div>
    <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" GridLines="None" AllowPaging="False" 
        PageSize="200" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="رقم الموظف">
                        <ItemTemplate>                            
                            <asp:Label ID="Lblstep" runat="server" Text='<%# Bind("EmpCode") %>'></asp:Label>                            
                        </ItemTemplate>
                        <ControlStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>     
                    
                   <asp:TemplateField HeaderText="اسم الموظف">
                        <ItemTemplate>                            
                            <asp:Label ID="Lblstep" runat="server" Text='<%# Bind("Name") %>'></asp:Label>                            
                        </ItemTemplate>
                        <ControlStyle Width="250px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                 

                    <asp:TemplateField HeaderText="التاريخ">
                        <ItemTemplate>                            
                            <asp:Label ID="Lblstep" runat="server" Text='<%# Bind("FDate") %>'></asp:Label>
                            
                        </ItemTemplate>
                        <ControlStyle Width="200px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>   
                
                <asp:TemplateField HeaderText="وقت الحضور">
                        <ItemTemplate>                            
                            <asp:Label ID="Lblstep" runat="server" Text='<%# Bind("STime") %>'></asp:Label>
                            
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>   

                <asp:TemplateField HeaderText="وقت الإنصراف">
                        <ItemTemplate>                            
                            <asp:Label ID="Lblstep" runat="server" Text='<%# Bind("ETime") %>'></asp:Label>
                            
                        </ItemTemplate>
                        <ControlStyle Width="150px" />
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
            </asp:GridView></div></div></div></div>
        </fieldset>
    </div>           
</asp:Content>
