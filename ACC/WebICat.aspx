<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebICat.aspx.cs" Inherits="ACC.WebICat" Culture="auto:ar-EG" UICulture="auto"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <div class="Round4Courner" style="width: 98%">
                <asp:LinkButton ID="LbtnLevel1" runat="server" CommandName="1" Text="<%$ Resources:ItemCat %>"
                    Visible="true" OnCommand="LbtnLevel1_Command" Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel2" runat="server" CommandName="2" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel3" runat="server" CommandName="3" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel4" runat="server" CommandName="4" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <asp:LinkButton ID="LbtnLevel5" runat="server" CommandName="5" Visible="false" OnCommand="LbtnLevel1_Command"
                    Font-Size="Larger" />
                <div style="width: 100%; overflow:none; overflow-x:auto ; border: 1px solid #800000;">                
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="True"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FCode;Code" 
                        AllowPaging="True" Width="99.8%" OnRowUpdating="grdCodes_RowUpdating" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowCommand="grdCodes_RowCommand"
                        OnRowDeleting="grdCodes_RowDeleting" OnRowEditing="grdCodes_RowEditing" 
                        OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="<%$ Resources:DeleteItem %>"
                                        ImageUrl="~/images/cross.png" OnClientClick='<%$ Resources:SureDelete %>' /> 
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ToolTip="<%$ Resources:SelectItem %>"
                                        ImageUrl="~/images/arrow_undo.png" /> 
                                    <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="<%$ Resources:UpdateItem %>"
                                        ImageUrl="~/images/pencil.png" /> 
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="<%$ Resources:Save %>"
                                        ImageUrl="~/images/accept.png" onload="btnUpdate_Load" />
                                    <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="<%$ Resources:CancelUpdate %>"
                                        ImageUrl="~/images/delete.png" /> 
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="<%$ Resources:AddNewItem %>"
                                        ImageUrl="~/images/add.png" /> 
                                </FooterTemplate>             
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:ArabDscr %>" SortExpression="Name1" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" Text='<%# Bind("Name1") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName1" Text='<%# Bind("Name1") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName1" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:EngDscr %>" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblName2" Text='<%# Bind("Name2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName2" Text='<%# Bind("Name2") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtName2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="<%$ Resources:CSal_Acc %>" SortExpression="CSal_Acc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCSal_Acc" Text='<%# Bind("CSal_Acc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCSal_Acc" Text='<%# Bind("CSal_Acc") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCSal_Acc2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:CRSal_Acc %>" SortExpression="CRSal_Acc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCRSal_Acc" Text='<%# Bind("CRSal_Acc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCRSal_Acc" Text='<%# Bind("CRSal_Acc") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCRSal_Acc2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:RCSal_Acc %>" SortExpression="RCSal_Acc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRCSal_Acc" Text='<%# Bind("RCSal_Acc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRCSal_Acc" Text='<%# Bind("RCSal_Acc") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtRCSal_Acc2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:RCRSal_Acc %>" SortExpression="RCRSal_Acc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRCRSal_Acc" Text='<%# Bind("RCRSal_Acc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRCRSal_Acc" Text='<%# Bind("RCRSal_Acc") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtRCRSal_Acc2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:CPur_Acc %>" SortExpression="CPur_Acc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCPur_Acc" Text='<%# Bind("CPur_Acc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCPur_Acc" Text='<%# Bind("CPur_Acc") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCPur_Acc2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:CRPur_Acc %>" SortExpression="CRPur_Acc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCRPur_Acc" Text='<%# Bind("CRPur_Acc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCRPur_Acc" Text='<%# Bind("CRPur_Acc") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCRPur_Acc2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:RCPur_Acc %>" SortExpression="RCPur_Acc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRCPur_Acc" Text='<%# Bind("RCPur_Acc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRCPur_Acc" Text='<%# Bind("RCPur_Acc") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtRCPur_Acc2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:RCRPur_Acc %>" SortExpression="RCRPur_Acc" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRCRPur_Acc" Text='<%# Bind("RCRPur_Acc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRCRPur_Acc" Text='<%# Bind("RCRPur_Acc") %>' runat="server" Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtRCRPur_Acc2" runat="server" Width="100%" />
                                </FooterTemplate>
                                <ControlStyle Width="80px" />
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
        </center>
    </div>
</asp:Content>
