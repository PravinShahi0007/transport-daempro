<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebExcel.aspx.cs" Inherits="ACC.WebExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="apple-touch-icon" sizes="57x57" href="images/icon/apple-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="images/icon/apple-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="images/icon/apple-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="images/icon/apple-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/icon/apple-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="images/icon/apple-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="images/icon/apple-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="images/icon/apple-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="images/icon/apple-icon-180x180.png" />
    <link rel="icon" type="image/png" sizes="192x192" href="images/icon/android-icon-192x192.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="images/icon/favicon-32x32.png" />
    <link rel="icon" type="image/png" sizes="96x96" href="images/icon/favicon-96x96.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="images/icon/favicon-16x16.png" />
    <link rel="manifest" href="images/icon/manifest.json" />
    <meta name="msapplication-TileColor" content="#ffffff" />
    <meta name="msapplication-TileImage" content="images/icon/ms-icon-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
    <!--End Here-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" integrity="sha512-KfkfwYDsLkIlwQp6LFnl8zNdLGxu9YAA1QvwINks4PhcElQSvqcyVLLD9aMhXd13uQjoXtEKNosOWaZqXgel0g==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Script/css/style.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/navbar/css_ar/core.css" rel="stylesheet" type="text/css" />
    <link href="Styles/navbar/css_ar/Igray.css" rel="stylesheet" type="text/css" />
    <link href="Styles/navbar/css_ar/slide.css" rel="stylesheet" type="text/css" />
    <link href="Script/themes/blitzer/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="Styles/fonts/fontface.css" rel="stylesheet" type="text/css" />
    <link href="Styles/sticky.css" rel="stylesheet" type="text/css" />
    <link href="Script/datePickerHijri/css/smoothness.calendars.picker.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .cal .ajax__calendar_header {
            background-color: Silver;
        }


        .cal .ajax__calendar_container {
            background-color: Gray;
        }


        .alignCenter {
            text-align: center;
        }

        .Notybutton {
            color: white;
            display: inline-block; /* Inline elements with width and height. TL;DR they make the icon buttons stack from left-to-right instead of top-to-bottom */
            position: relative; /* All 'absolute'ly positioned elements are relative to this one */
            padding: 2px 5px; /* Add some padding so it looks nice */
        }

        /* Make the badge float in the top right corner of the button */
        .Notybutton__badge {
            background-color: #fa3e3e;
            border-radius: 6px;
            color: white;
            padding: 1px 3px;
            font-size: 10px;
            position: absolute;
            top: -5px;
            right: 0;
        }

        .ui-widget .ui-widget {
            font-size: 12px;
        }

        .ui-tabs {
            direction: rtl;
        }

            .ui-tabs .ui-tabs-nav li.ui-tabs-selected, .ui-tabs .ui-tabs-nav li.ui-state-default {
                float: right;
            }

            .ui-tabs .ui-tabs-nav li a {
                float: right;
            }

            .ui-tabs .ui-tabs-nav li a {
                font-size: 11pt !important;
            }
    </style>
    <title></title>

    <%-- New Template CSS --%>
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
    <link href="http://fonts.cdnfonts.com/css/sf-pro-display" rel="stylesheet" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- JQVMap -->
    <link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/adminlte.min.css" />
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
    <!-- Daterange picker -->
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css" />
    <!-- summernote -->
    <link rel="stylesheet" href="plugins/summernote/summernote-bs4.min.css" />
    <!-- custom css -->
    <link rel="stylesheet" href="dist/css/custom.css" />

</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-1 col-sm-12 col-xs-12"></div>
            <div class="col-md-10 col-sm-12 col-xs-12">
           
    <form id="form1" runat="server">
    <div class="card-body">
        
        <div class="form-row">
            <div class="form-group col-md-3 col-sm-12 col-xs-12">
                 
            </div>
            <div class="form-group col-md-3 col-sm-12 col-xs-12">
             <asp:DropDownList ID="ddlSheet" CssClass="form-control" runat="server">
            <asp:ListItem Selected="True" Value="[Sheet1$]">Sheet1</asp:ListItem>
            <asp:ListItem Value="[Sheet2$]">Sheet2</asp:ListItem>
            <asp:ListItem Value="[Sheet3$]">Sheet3</asp:ListItem>
            <asp:ListItem Value="[Sheet4$]">Sheet4</asp:ListItem>
            <asp:ListItem Value="[Sheet5$]">Sheet5</asp:ListItem>
            <asp:ListItem Value="[Sheet6$]">Sheet6</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;
            </div>
            <div class="form-group col-md-3 col-sm-12 col-xs-12">
              <asp:DropDownList ID="ddlAction" CssClass="form-control" runat="server">
            <asp:ListItem Selected="True" Value="0">سياسة التسعير</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;

            </div>
            <div class="form-group col-md-3 col-sm-12 col-xs-12">
                 
            </div>
            </div>
        <div class="form-row">
            <div class="col-md-3 col-sm-12 col-xs-12"></div>
            <div class="col-md-6 col-sm-12 col-xs-12">
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"/>&nbsp;&nbsp;
            </div>
            <div class="col-md-3 col-sm-12 col-xs-12"></div>
        </div>
        <br />
        <div class="form-row">
            <div class="col-md-3 col-sm-12 col-xs-12"></div>
            <div class="col-md-6 col-sm-12 col-xs-12 text-center">
                 <asp:Button ID="btnImport" runat="server" Text="استيراد البيانات" CssClass="btn btn-primary" OnClick="btnImport_Click" />
                            <br />
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
            </div>
            <div class="col-md-3 col-sm-12 col-xs-12"></div>
        </div>
        </div>
                        
        
        
       

            <div class="table table-responsive text-center">              

        <asp:GridView ID="grvExcelData" runat="server" CellPadding="4" ForeColor="#333333" 
                             GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
                </div>
    </div>
       
    </form>
                </div>
             <div class="col-md-1 col-sm-12 col-xs-12"></div>
            </div>
        </div>
</body>
</html>
