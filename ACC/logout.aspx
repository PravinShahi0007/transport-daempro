<%@ Page Title="" Language="C#" MasterPageFile="~/MySiteNoMenu.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="ACC.logout" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<center>
<asp:Panel ID="Panel1" runat="server" ForeColor="Black"  CssClass="ColorRounded4Corners"  >
<br />
<br />
<br />
<br />
<p><asp:Literal ID="Literal3" Text="لقد تم تسجيل خروجك من النظام بنجاح" runat="server" meta:resourcekey="Literal3"></asp:Literal></p>
<p><asp:Literal ID="Literal1" Text="شكرا لإستخدامك النظام" runat="server" meta:resourcekey="Literal1"></asp:Literal></p>
<p><a href="login.aspx"><asp:Literal ID="Literal2" Text="دخول جديد" runat="server" meta:resourcekey="Literal2"></asp:Literal></a></p>
<br />
<br />
<br />
<br />
</asp:Panel>
</center>

</asp:Content>
