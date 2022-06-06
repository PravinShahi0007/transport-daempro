<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebBarCode.aspx.cs" Inherits="ACC.WebBarCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <br />
    <asp:Panel ID="Panel1" runat="server" BackColor="#F9C591" Width="98%" CssClass="Rounded4Corners div1" >
   <center>
            <table width="100%">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:ImageButton ID="BtnPrint" runat="server" ImageUrl="~/images/print_48.png" ValidationGroup="10"
                            ToolTip="طباعة الباركود" CssClass="ops" OnClick="BtnPrint_Click" OnClientClick="aspnetForm.target ='_blank';" />
                        <asp:ImageButton ID="BtnClear" runat="server" ImageUrl="~/images/erasure_48.png"
                            ToolTip="مسح البيانات" CssClass="ops" OnClick="BtnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:RadioButtonList ID="rdoDesign" runat="server" RepeatColumns="2">
                            <asp:ListItem Value="1">Design 1</asp:ListItem>
                            <asp:ListItem Selected="True" Value="2">Design 2</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
   <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblNo1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate1" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint1" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate2" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint2" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo3" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate3" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint3" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo4" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate4" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint4" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo5" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate5" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint5" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo6" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate6" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint6" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo7" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate7" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint7" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo8" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate8" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint8" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo9" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate9" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint9" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo10" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate10" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint10" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo11" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate11" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint11" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo12" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate12" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint12" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo13" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate13" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint13" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo14" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate14" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint14" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo15" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate15" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint15" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo16" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate16" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint16" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo17" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate17" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint17" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo18" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate18" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint18" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo19" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate19" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint19" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo20" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate20" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint20" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo21" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate21" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint21" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo22" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate22" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint22" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo23" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate23" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint23" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo24" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate24" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint24" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo25" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate25" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint25" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo26" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate26" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint26" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo27" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate27" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint27" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo28" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate28" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint28" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo29" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate29" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint29" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo30" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate30" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint30" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo31" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate31" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint31" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo32" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate32" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint32" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo33" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate33" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint33" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo34" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate34" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint34" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo35" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate35" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint35" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo36" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate36" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint36" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo37" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate37" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint37" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo38" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate38" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint38" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo39" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate39" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint39" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo40" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate40" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint40" Checked="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNo41" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate41" runat="server" Visible="false"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint41" runat="server" Visible="false" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo42" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate42" runat="server" Visible="false"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint42" runat="server" Visible="false" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo43" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate43" runat="server" Visible="false"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint43" runat="server" Visible="false" />
                    </td>
                    <td>
                        <asp:Label ID="lblNo44" runat="server" Text="" Visible="false" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate44" runat="server" Visible="false"></asp:TextBox>
                        <asp:CheckBox ID="ChkPrint44" runat="server" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        <asp:Label ID="LblError" runat="server" ForeColor="#FF0066"></asp:Label>
                    </td>
                </tr>
            </table>
            </center>
        </asp:Panel>
</asp:Content>
