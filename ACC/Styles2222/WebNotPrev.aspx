<%@ Page Title="" Language="C#" MasterPageFile="~/MySiteNoMenu.Master" AutoEventWireup="true" CodeBehind="WebNotPrev.aspx.cs" Inherits="ACC.Styles.WebNotPrev"  Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true"  %>
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
<p>لا توجد لك صلاحية للدخول على الفرع</p>
<p>لقد تم تسجيل خروجك من النظام بنجاح</p>
<p>شكرا لإستخدامك النظام</p>
<p><a href="login.aspx">دخول جديد</a></p>
<br />
<br />
<br />
<br />
</asp:Panel>
</center>

</asp:Content>
