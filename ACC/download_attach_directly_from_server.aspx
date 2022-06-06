<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="download_attach_directly_from_server.aspx.cs" Inherits="Mail1.download_attach_directly_from_server" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Download attachment directly from e-mail server, no temp files used</title>
		<style type="text/css">
		div
		{
			font-family: Arial;
			font-size: 9pt;
		}
		p
		{
			margin-top: 5pt;
			margin-bottom: 5pt;
		}
		.small_heading
		{
			font-size: 11pt;
			font-weight: bold;
			margin-bottom: 7pt;
		}
		.label
		{
			width: 100px;
			display: inline-block;
			font-weight: bold;
		}
	</style>
</head>
<body>
	<form id="form1" runat="server" dir="rtl">
	<div>
<%
		if (Request.QueryString["external"] == null)
		{
%>
		
		<hr />
<%
		}
%>
		<asp:Panel ID="pGmailPop3Comment" runat="server">
			<p>
				With Gmail/POP3, you may see weird behaviour of a different e-mail being shown each
				time you reload the page. This happens because Gmail may delete the e-mail from
				POP3 once it has been read (you can still access it via web interface, though).</p>
			<hr />
		</asp:Panel>
		<p class="small_heading">Downloaded e-mail details</p>
		<p>
			<span class="label">Operation result:</span>
			<asp:Label ID="lStatus" runat="server"></asp:Label></p>
		<p>
			<span class="label">UID (Unique-ID):</span>
			<asp:Label ID="lUid" runat="server"></asp:Label></p>
		<p>
			<span class="label">From:</span>
			<asp:Label ID="lFrom" runat="server"></asp:Label></p>
		<p>
			<span class="label">To:</span>
			<asp:Label ID="lTo" runat="server"></asp:Label></p>
		<p>
			<span class="label">CC:</span>
			<asp:Label ID="lCc" runat="server"></asp:Label></p>
		<p>
			<span class="label">Subject:</span>
			<asp:Label ID="lSubject" runat="server"></asp:Label></p>
		<p>
			<span class="label">Date:</span>
			<asp:Label ID="lDate" runat="server"></asp:Label></p>
		<p>
			<span class="label">Size:</span>
			<asp:Label ID="lSize" runat="server"></asp:Label></p>
		<p>
			<span class="label">Attachments:</span>
			<asp:Label ID="lAttachs" runat="server"></asp:Label></p>
		<p>
			<asp:CheckBox ID="cbIncludeInline" runat="server" Checked="True" AutoPostBack="True"
				Text="Include linked resources like inline images, in attachments list" /><br />
			<asp:CheckBox ID="cbForceSaveFile" runat="server" Checked="True" AutoPostBack="True"
				Text="Do not open attachments, show Save File dialog instead" />
		</p>
		<hr />
	</div>
	</form>
</body>
</html>
