<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebBackup.aspx.cs" Inherits="ACC.WebBackup" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="files" runat="server" class="Rounded4Corners" style="background-color:#FFFFCC; width:900px; height:400px; float:right; border: thin solid #800000; overflow:hidden; overflow-x:hidden; overflow-y:auto; text-align:center;">
    <asp:CheckBoxList ID="chkBackup" runat="server" Width="100%" RepeatColumns="4">
    </asp:CheckBoxList>
</div><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<center>
    <asp:Button ID="BtnRestore" Text="تحميل النسخة الاحتياطية" runat="server" OnClientClick='return confirm("هل أنت متاكد؟")'
        onclick="BtnRestore_Click" />
        </center>
</asp:Content>
