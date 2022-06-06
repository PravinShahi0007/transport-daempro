<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebGetTimer.aspx.cs" Inherits="ACC.WebGetTimer" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="ColorRound4Courner">
                <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                    border: solid 2px #800000">
                    <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                        أستيراد بيانات الحضور و الانصراف</legend>
                    <asp:RadioButtonList ID="rdoTimers" runat="server">
                    </asp:RadioButtonList>
                    <asp:Button ID="btnConnect" runat="server" Visible="false" Text="Connect" 
                        onclick="btnConnect_Click" /> 
                        <br /> 
                    <asp:Button ID="Button2" runat="server" Visible="false" Text="عدد السجلات" 
                        onclick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" Visible="false" Text="استيراد البيانات" 
                        onclick="Button1_Click" />
                    <asp:Button ID="Button3" runat="server" Visible="false" Text="مسح البيانات" 
                        onclick="Button3_Click"  />
                    <br /><br />
                    <asp:FileUpload ID="Fp1" runat="server" />
                    <asp:Button ID="btnImportFromFile" runat="server" 
                        onclick="btnImportFromFile_Click" Text="استيراد من ملف" />
                    <br />



                    <br />
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label><br /> <br />       
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
            </asp:GridView>
        </fieldset>
    </div>           
</asp:Content>
