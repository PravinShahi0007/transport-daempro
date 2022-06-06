<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    CodeBehind="set_imap_pop3.aspx.cs" Inherits="ACC.set_imap_pop3" Culture="auto:ar-EG"
    UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    <asp:Label ID="lblHead" runat="server" Text="[ إعدادات البريد الالكتروني]"></asp:Label>
                </b></legend>
                <div>
                    <a href='<%= string.Format("WebInboxMail.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Inbox" src="images/Inbox_A.png" /></a>
                    <a><img alt="Outbox" src="images/OutBox_A.png" /></a>
                    <a href='<%= string.Format("WebInboxMail.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Refresh" src="images/Refresh_642.png" /></a>
                    <a><img alt="Create" src="images/Create_A.png" /></a>
                    <a><img alt="Trash" src="images/Trash_642.png" /></a>
                    <a><img alt="Spam" src="images/Spam_642.png" /></a>
                    <a href='<%= string.Format("set_imap_pop3.aspx?AreaNo={0}&StoreNo={1}",AreaNo,StoreNo) %>'><img alt="Setting" src="images/Setting_642.png" /></a>

                    <br />
                    <br />
                    <div id="Div1" runat="server" visible="false">
                        <hr />
                        <p class="small_heading">
                            License key settings (not required if the license key is already in web.config or
                            registry)</p>
                        <p>
                            <span class="label">License key</span>
                            <asp:TextBox ID="tbLicenseKey" runat="server" Columns="50"></asp:TextBox></p>
                        <p>
                            The license key, if specified, must be in this format: MN100-0123456789ABCDEF-0123
                            (MN100 stands for MailBee.NET v10.0).</p>
                        <p>
                            License status check:
                            <asp:Label ID="lImapKeyStatus" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lPop3KeyStatus" runat="server" Text=""></asp:Label></p>
                        <p>
                            OK means the component is licensed and the key, if specified, is correct.<br />
                            USABLE means the specified key is incorrect but the component is already unlocked
                            (e.g. there is another key elsewhere, such as in web.config).<br />
                            N/A is "not available" (no key or wrong key specified, product isn't covered by
                            your license, trial expired, etc).
                        </p>
                        <hr />
                        <p class="small_heading">
                            IMAP/POP3 host</p>
                        <p>
                            <span class="label">IMAP/POP3 host</span>
                            <asp:TextBox ID="tbHost" runat="server"></asp:TextBox>
                            <asp:RadioButton ID="rbImap" runat="server" GroupName="Protocol" Checked="True" />IMAP
                            (recommended) /
                            <asp:RadioButton ID="rbPop3" runat="server" GroupName="Protocol" />POP3<br />
                        </p>
                        <p>
                            <span class="label">IMAP/POP3 port</span>
                            <asp:TextBox ID="tbPort" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;If blank, uses default ports for unknown servers. For Gmail, uses
                            SSL ports (imap.gmail.com:993 and pop.gmail.com:995).</p>
                        <p>
                            To enable IMAP via SSL, specify port 993, or 995 for POP3 via SSL.</p>
                        <hr />
                    </div>
                    <p>
                        <span class="label">الإيميل</span>
                        <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span class="label">كلمة المرور</span>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox></p>
                    <hr />
                    <p>
                        <asp:Button ID="btnTest" runat="server" Text="حفظ الإعدادات" PostBackUrl="~/set_imap_pop3.aspx"
                            OnClick="btnTest_Click" />
                    </p>
                    <br />
                    <p>
                        <a href="inbox_list.aspx"  style="visibility:hidden" target="new">عرض صندوق الوارد</a></p>
                    <br />
                    <p>
                        <asp:Label ID="lResult" runat="server" Text=""></asp:Label></p>
                    <pre>
                        <asp:Label Visible="false" ID="lLog" runat="server" Text=""></asp:Label></pre>
                </div>
            </fieldset>
        </div>
    </center>
</asp:Content>
