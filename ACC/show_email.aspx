<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="show_email.aspx.cs" Inherits="ACC.show_email" Culture="auto:ar-EG" UICulture="auto" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
	    function resizeIframeToFitContent(iframe) {
	        var doc = document.getElementById(iframe.id).contentDocument;
	        if (doc == null) {
	            // IE version
	            doc = document.getElementById(iframe.id).contentWindow.document;
	        }

	        if (doc != null) {
	            iframe.height = doc.body.scrollHeight;
	            iframe.scrolling = "no";
	        } else {
	            // Should never go this way but let's have it just in case.
	            iframe.height = 300;
	        }
	    }
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ عرض الرسالة ]"></asp:Label>
                </b></legend>
	<div>
        <center>

		            <a href='<%= string.Format("WebInboxMail.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Inbox" src="images/Inbox_A.png" /></a>
                    <a><img alt="Outbox" src="images/OutBox_A.png" /></a>
                    <a href='<%= string.Format("WebInboxMail.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Refresh" src="images/Refresh_642.png" /></a>
                    <a><img alt="Create" src="images/Create_A.png" /></a>
                    <a><img alt="Trash" src="images/Trash_642.png" /></a>
                    <a><img alt="Spam" src="images/Spam_642.png" /></a>
                    <a href='<%= string.Format("set_imap_pop3.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Setting" src="images/Setting_642.png" /></a>

		<hr />
			    <%
				    string backToListSupport = string.Empty;
				    if (_page != null)
				    {
					    backToListSupport = "&back=" + Request.QueryString["back"] + "&page_size=" + Request.QueryString["page_size"];
					} 
                %>

                    <% if (_newerUid != null)
				    { %><a  href="show_email.aspx?uid=<% =_newerUid + backToListSupport%>"><%} %><% if (_newerUid != null)
				    { %><img src="images/Next_a.png" /></a><%} %>
                    <a><img src="images/Reply_A.png" /></a>
                    <a><img src="images/Forward_A.png" /></a>
                    <% if (_olderUid != null)
				    { %><a href="show_email.aspx?uid=<% =_olderUid + backToListSupport%>"><%} %><% if (_olderUid != null)
				    { %><img src="images/Previous_a.png" /></a><%} %>
        </center>
		<hr />
		<asp:Panel ID="pGmailPop3Comment" runat="server">
		</asp:Panel>
		<p>
			<span class="label">من:</span>
			<asp:Label ID="lFrom" runat="server"></asp:Label></p>
		<p>
			<span class="label">إلى:</span>
			<asp:Label ID="lTo" runat="server"></asp:Label></p>
		<p>
			<span class="label">نسخة إلى:</span>
			<asp:Label ID="lCc" runat="server"></asp:Label></p>
       
		<p>
			<span class="label">الموضوع:</span>
			<asp:Label ID="lSubject" runat="server"></asp:Label></p>
		<p>
			<span class="label">التاريخ:</span>
			<asp:Label ID="lDate" runat="server"></asp:Label></p>
		<p>
			<span class="label">الحجم:</span>
			<asp:Label ID="lSize" runat="server"></asp:Label></p>
		<hr />
		<p>
			<span class="label">المرفقات</span>
			<asp:Label ID="lAttachs" runat="server"></asp:Label></p>
	<% if (_displayIframe)
	{ %>
	<iframe id="htmlBodyIFrame" width="100%" height="0" scrolling="auto" frameborder="0" src="show_html_body.aspx?uid=<% =_uid%>&part_id=<% =_partID%>" onload="resizeIframeToFitContent(this)">
	</iframe>
	<%}
	else
	{%>
	<asp:Label ID="lBodyText" runat="server"></asp:Label>
	<%}%>
            <div style="visibility:hidden" >
			    <asp:CheckBox ID="cbIncludeInline" runat="server" Checked="True" AutoPostBack="True"
				    Text="Include linked resources like inline images, in attachments list" />
			    <span style="visibility:hidden" class="label">Body Format:</span>
		    <asp:Label ID="lBodyFormat" Visible="false" runat="server"></asp:Label>
			    <asp:RadioButton Visible="false" ID="rbHtmlAsPlainText" runat="server" GroupName="Protocol" Checked="True" AutoPostBack="True" />Show HTML as plain-text
			    <asp:RadioButton  Visible="false" ID="rbHtmlAsIs" runat="server" GroupName="Protocol" AutoPostBack="True" />Show HTML as-is (HTML content, if it redefines styles, can break styles of your page)
			    <asp:RadioButton  Visible="false" ID="rbHtmlInIframe" runat="server" GroupName="Protocol" Checked="False" AutoPostBack="True" />Render HTML in IFRAME (displays cleaner but requires separate connection)
			<span class="label">Operation result:</span>
			<asp:Label ID="lStatus" runat="server"></asp:Label>
			<span class="label">UID (Unique-ID):</span>
			<asp:Label ID="lUid" runat="server"></asp:Label>

		<ul>
			<li>
					<a href="download_attach_directly_from_server.aspx?external=yes<%
			if (Request.QueryString["uid"] != null) Response.Write("&uid=" + Server.HtmlEncode(Request.QueryString["uid"]));
			%>" target="_blank">Download attachments (use download.aspx script)</a>
			</li>
		
		</ul>


        </div>

	</div>
    </fieldset>
    </div>
</asp:Content>
