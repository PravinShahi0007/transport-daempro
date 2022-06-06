<%@ Page Title="" Language="C#" MasterPageFile="~/MySiteNoMenu.Master" AutoEventWireup="true" CodeBehind="GeneralServerError.aspx.cs" Inherits="ACC.GeneralServerError" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<br />
<center>
<table cellpadding="0" cellspacing="0">
<tr>
<td style="width:300px"></td><td><img src="images/delete.png" /></td><td>&nbsp; &nbsp;</td><td><h2><asp:Literal ID="lblMyError" Text="لقد حدث خطأ في النظام" runat="server" meta:resourcekey="lblMyError"></asp:Literal></h2></td><td></td><td>
    &nbsp;</td><td style="width:200px" ></td><td><a href="login.aspx?ReturnUrl=default.aspx"><asp:Literal ID="lblLogin" Text="دخول جديد" runat="server" meta:resourcekey="lblLogin"></asp:Literal></a></td>
</tr>
</table>
    
    <asp:Literal ID="lblError" runat="server"></asp:Literal>
<br /><br />
</center>
</asp:Content>
