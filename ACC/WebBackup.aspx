<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebBackup.aspx.cs" Inherits="ACC.WebBackup" Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
<div id="files" runat="server" class="card-header">

    <asp:CheckBoxList ID="chkBackup" runat="server" CssClass="form-control" RepeatColumns="4">
    </asp:CheckBoxList>
</div>
<center>
    <div class="card-body">
    <asp:Button ID="BtnRestore" Text="تحميل النسخة الاحتياطية" CssClass="btn btn-primary" runat="server" OnClientClick='return confirm("هل أنت متاكد؟")'
        onclick="BtnRestore_Click" /></div>
        </center>
        </div>
</asp:Content>
