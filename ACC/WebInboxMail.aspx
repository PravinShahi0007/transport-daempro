<%@ Page Title="صندوق الوارد , عرض قائمة الرسائل" Language="C#" MasterPageFile="~/MySite.Master"
    AutoEventWireup="true" CodeBehind="WebInboxMail.aspx.cs" Inherits="ACC.WebInboxMail"
    Culture="auto:ar-EG" UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<%@ Import Namespace="MailBee.Mime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ صندوق الوارد]"></asp:Label>                     
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="2" 
                        AutoPostBack="True" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">IMAP4</asp:ListItem>
                        <asp:ListItem Value="1">POP3</asp:ListItem>
                    </asp:RadioButtonList>

                </b></legend>
                <div>
                    <a href='<%= string.Format("WebInboxMail.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Inbox" src="images/Inbox_A.png" /></a>
                    <a><img alt="Outbox" src="images/OutBox_A.png" /></a>
                    <a href='<%= string.Format("WebInboxMail.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Refresh" src="images/Refresh_642.png" /></a>
                    <a><img alt="Create" src="images/Create_A.png" /></a>
                    <a><img alt="Trash" src="images/Trash_642.png" /></a>
                    <a><img alt="Spam" src="images/Spam_642.png" /></a>
                    <a href='<%= string.Format("set_imap_pop3.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Setting" src="images/Setting_642.png" /></a>
                    
                    <asp:Panel ID="pGmailPop3Comment" runat="server">
                        <p>
                            With Gmail/POP3, you may see weird behaviour of a different e-mail being shown each
                            time you reload the page. This happens because Gmail may delete the e-mail from
                            POP3 once it has been read (you can still access it via web interface, though).</p>
                        <hr />
                    </asp:Panel>
                    <asp:Panel ID="pConfigureImapPop3AccessAlert" runat="server">
                        <p>
                            <a href='<%= string.Format("set_imap_pop3.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'>أعدادات البريد</a></p>
                        <hr />
                    </asp:Panel>
                    <!-- style="color: #333333; width: 100%; border-collapse: collapse;" -->
                    <!-- tr style="color: White; background-color: #5D7B9D; font-weight: bold;" -->
                    <!-- style="color: #333333; background-color: #F7F6F3;" -->
                    <table cellspacing="0" cellpadding="4" rules="cols" border="1" id="tMessageList"
                        class="responstable">
                        <tr>
                            <th scope="col" align="center">
                                #
                            </th>
                            <th scope="col" align="center">
                                من
                            </th>
                            <%--			<th scope="col" align="center">
					إلى
				</th>--%>
                            <th scope="col" align="center">
                                الموضوع
                            </th>
                            <th scope="col" align="center">
                                التاريخ
                            </th>
                        </tr>
                        <%
                            if (_msgs != null)
                            {
                                foreach (MailMessage msg in _msgs)
                                {
                        %>
                        <tr>
                            <td style="width: 5%;" align="center">
                                <% =msg.IndexOnServer.ToString()%>
                            </td>
                            <td style="width: 35%;" align="center">
                                <% =MakeLink(msg.From.ToString(), msg.UidOnServer.ToString(), PageSize) %>
                            </td>
                            <%--				<td style="width: 25%;" align="center">
					<% =MakeLink(msg.To.ToString(), msg.UidOnServer.ToString(), PageSize) %>
				</td>
                            --%>
                            <td style="width: 45%;" align="center">
                                <% =MakeLink(msg.Subject, msg.UidOnServer.ToString(), PageSize) %>
                            </td>
                            <td style="width: 15%;" align="center">
                                <% =msg.Date.ToString() %>
                            </td>
                        </tr>
                        <%
                    }
                }
                else
                {
                    // Display empty row in case if no records available.
                        %>
                        <tr style="color: #333333; background-color: #F7F6F3;">
                            <td style="width: 5%;">
                                &nbsp;
                            </td>
                            <td style="width: 35%;">
                                &nbsp;
                            </td>
                            <%--				<td style="width: 25%;">
					&nbsp;
				</td>
                            --%>
                            <td style="width: 45%;">
                                &nbsp;
                            </td>
                            <td style="width: 15%;">
                                &nbsp;
                            </td>
                        </tr>
                        <%
                }
                if (_pageCount > 1)
                {
                    // Display pager if more than one page available.
                        %>
                        <tr align="center" style="color: White; background-color: #284775;">
                            <td colspan="5" align="center">
                                <table>
                                    <tr>
                                        <%
                    for (int i = 0; i < _pageCount; i++)
                    {%>
                                        <td align="center">
                                            <span>
                                                <%
                                    if (i == _curPage)
                                    {
                                        // Current page is not a link.
                                        Response.Write((i + 1).ToString());
                                    }
                                    else
                                    {
											// Other pages are links.
                                                %><a href='<%= string.Format("WebInboxMail.aspx?AreaNo={0}&StoreNo={1}&page={2}",AreaNo,StoreNo,i.ToString()) %>' style="color: White;"><% = (i + 1).ToString()%></a><%
                                        }
                                                %>
                                            </span>
                                        </td>
                                        <% } %>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%
                }
                        %>
                    </table>
                </div>
            </fieldset>
        </div>
    </center>
</asp:Content>
