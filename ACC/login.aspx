<%@ Page Title="" Language="C#" MasterPageFile="~/MySiteNoMenu.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ACC.login" Culture="auto:ar-EG" UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="apple-touch-icon" sizes="57x57" href="images/icon/apple-icon-57x57.png">
    <link rel="apple-touch-icon" sizes="60x60" href="images/icon/apple-icon-60x60.png">
    <link rel="apple-touch-icon" sizes="72x72" href="images/icon/apple-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="76x76" href="images/icon/apple-icon-76x76.png">
    <link rel="apple-touch-icon" sizes="114x114" href="images/icon/apple-icon-114x114.png">
    <link rel="apple-touch-icon" sizes="120x120" href="images/icon/apple-icon-120x120.png">
    <link rel="apple-touch-icon" sizes="144x144" href="images/icon/apple-icon-144x144.png">
    <link rel="apple-touch-icon" sizes="152x152" href="images/icon/apple-icon-152x152.png">
    <link rel="apple-touch-icon" sizes="180x180" href="images/icon/apple-icon-180x180.png">
    <link rel="icon" type="image/png" sizes="192x192" href="images/icon/android-icon-192x192.png">
    <link rel="icon" type="image/png" sizes="32x32" href="images/icon/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="96x96" href="images/icon/favicon-96x96.png">
    <link rel="icon" type="image/png" sizes="16x16" href="images/icon/favicon-16x16.png">
    <link rel="manifest" href="images/icon/manifest.json">
    <meta name="msapplication-TileColor" content="#ffffff">
    <meta name="msapplication-TileImage" content="images/icon/ms-icon-144x144.png">
    <meta name="theme-color" content="#ffffff">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-box">
        <div class="row">
            <div class="col-md-6">
                <div class="login_col">
                    <div class="card-body login-card-body">
                        <div class="login_page_logo">
                            <img src="dist/img/logo.png" alt="" />
                        </div>
                        <div action="#" method="post">
                            <div class="input-group mb-3">
                                <label style="font-size: 20px; font-weight: bold; color: #beb9b9;">E-mail</label>
                                <asp:TextBox ID="TxtUserName" MaxLength="50" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="1" ID="ValUserName" runat="server"
                                    ForeColor="Red" ControlToValidate="TxtUserName" ErrorMessage="<%$ Resources:EnterUserName %>">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="input-group mb-3">
                                <label style="font-size: 20px; font-weight: bold; color: #beb9b9;">Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="10" ID="ValPassword" runat="server"
                                    ForeColor="Red" ControlToValidate="txtPassword" ErrorMessage="<%$ Resources:EnterPassword %>">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="row submit_row">
                                <div class="col-12">
                                    <asp:Label ID="LblError" runat="server"></asp:Label>
                                </div>
                                <div class="col-12">
                                    <asp:LinkButton ID="lnkLogin" runat="server"
                                        CssClass="btn btn-primary sub" OnClick="lnkLogin_Click" Text="Login" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                </div>
                <div class="col-sm-6 back">
                </div>
            </div>
            <div class="col-md-6" style="background: url('dist/img/login_left_img.png'); min-height: 100vh; background-size: cover; background-position: center; margin: 0px; padding: 0px;">
                <div class="silde_img">
                </div>
            </div>
        </div>
        <div style="text-align: left; width: 100%; display: none;">
            <asp:Label ID="lbldata" runat="server" Text="مجال البيانات" meta:resourcekey="lbldata"></asp:Label>
            <asp:DropDownList ID="ddlCnn" runat="server">
                <asp:ListItem Selected="True" Value="MyCnn">2014-15-16-17</asp:ListItem>
                <asp:ListItem Value="MyCnn2014">2014</asp:ListItem>
                <asp:ListItem Value="MyCnn2015">2015</asp:ListItem>
                <asp:ListItem Value="MyCnn20177">2017 nd</asp:ListItem>
                <asp:ListItem Value="MyCnnBackup" Text="<%$ Resources:Backup %>"></asp:ListItem>
                <asp:ListItem Value="MyCnnTrain" Text="<%$ Resources:Training %>"></asp:ListItem>
            </asp:DropDownList>
            <asp:CheckBox ID="ChkFast" Text="دخول سريع" runat="server" meta:resourcekey="ChkFast" />
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentBottom" runat="server">
    <script type="te/javascript">   
     function Validate() {
         var isValid = false;
         isValid = Page_ClientValidate('1');
         if (isValid) {
             isValid = Page_ClientValidate('10');
         }
         return isValid;
     }
    </script>
    <style>
        form{
            width: -webkit-fill-available;
        }
    </style>
    </asp:Content>