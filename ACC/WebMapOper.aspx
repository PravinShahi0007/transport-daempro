<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMapOper.aspx.cs" Inherits="ACC.WebMapOper"  Culture="ar-EG" UICulture="ar-EG" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="initial-scale=1.0" />
    <meta charset="utf-8" />
    <link href="Bootstrap/css/bootstrap-arabic.min.css" rel="stylesheet" type="text/css" />
    <link href="Bootstrap/css/bootstrap-arabic-theme.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html, body
        {            
            height: 100%;
            margin: 0;
            padding: 0;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 16px;
        }
        .lstbox
        {
            border: thin #000000 solid;
            width:200px;
        }
        #map111
        {
            width: 97%;
            height: 515px;
        }
        .MapBtnDiv
        {
            padding-top: 5px;
            border: 1px solid gray;
        }
        .Notybutton
        {
            color: white;
            display: inline-block; /* Inline elements with width and height. TL;DR they make the icon buttons stack from left-to-right instead of top-to-bottom */
            position: relative; /* All 'absolute'ly positioned elements are relative to this one */
            padding: 2px 5px; /* Add some padding so it looks nice */
        }
        .Notybutton__badge
        {
            background-color: #fa3e3e;
            border-radius: 6px;
            color: white;
            padding: 1px 3px;
            font-size: 10px;
            position: absolute;
            top: -5px;
            right: 0;
        }
        .panel-resizable
        {
            resize: vertical;
            min-height: 515px;
            overflow: auto;
        }
        pre {
          tab-size: 8;
        }      
      }        
        .centerHeaderText th {
            text-align: center;
        }
    </style>
</head>
<body dir="rtl">
    <form id="form11" runat="server">
  <%--  <nav class="navbar navbar-default navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">التحكم بالاسطول</a>
        </div>     
        <div id="Div1" class="navbar-collapse collapse">
          <ul class="nav navbar-nav">
            <li class="active"><a href="#">الرئيسية</a></li>
            <li><a href="#about">About</a></li>
            <li><a href="#contact">Contact</a></li>
            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">النشاط<span class="caret"></span></a>
              <ul class="dropdown-menu">
                <li><a href="#">Action</a></li>
                <li><a href="#">Another action</a></li>
                <li><a href="#">Something else here</a></li>
                <li role="separator" class="divider"></li>
                <li class="dropdown-header">Nav header</li>
                <li><a href="#">Separated link</a></li>
                <li><a href="#">One more separated link</a></li>
              </ul>
            </li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>
    <br />
    <br />
    <br />--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="36000">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div id="tools" style="width: 3%; float: right; height: 515px; background-color: white;
                    text-align: center;">
                    <div id="divCars1" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Truck.png" title="شاحنات جاهزة للتحميل" onclick="CallMe('1');" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblFreeCar" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divCars2" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Truck1.png" title="شاحنات في الصيانة" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblDamageCar" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divCars3" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Truck2.png" title="شاحنات في الطريق" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblBusyCar" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divCar1" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Cars.png" title="سيارات معتمدة" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblCarInv" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divCar2" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Cars1.png" title="سيارات معلقة" onclick="CallMe('2');" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblCarOnLine" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divCar3" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Cars2.png" title="سيارات تم نقلها" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblCarDone" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divExpress1" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Express.png" title="شحنات معتمدة" onclick="CallMe('6');" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblShipInv" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divExpress2" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Express1.png" title="شحنات معلقة" onclick="CallMe('7');" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblShipOnLine" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divExpress3" runat="server"  style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Express2.png" title="شحنات تم نقلها" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblShipDone" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divWater1" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Water.png" title="فواتير مياة معتمدة" onclick="CallMe('4');" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblWaterInv" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divWater2" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Water1.png" title="فواتير مياة معلقة" onclick="CallMe('3');" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblWaterOnLine" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="divWater3" runat="server"  style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Water2.png" title="فواتير مياة تم نقلها" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblWaterDone" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="diver1" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Emer.png" title="خدمات طريق معتمدة" onclick="CallMe('8');" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblEmergInv" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="diver2" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Emer1.png" title="خدمات طريق معلقة" onclick="CallMe('9');" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblEmergOnLine" runat="server" Text=""></asp:Label></span></a></div>
                    <div id="diver3" runat="server" style="padding-top: 5px;">
                        <a class="Notybutton">
                            <img src="images/Emer2.png" title="خدمات طريق تم تنفيذها" style="cursor: pointer;" /><span
                                class="Notybutton__badge"><asp:Label ID="lblEmergDone" runat="server" Text=""></asp:Label></span></a></div>
                </div>
                <asp:Timer ID="Timer1" Interval="30000" runat="server" Enabled="true" OnTick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="panel panel-default">
            <div id="map" class="panel-body panel-resizable" style="width: 97%; height: 515px;">
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional">        <%--ChildrenAsTriggers="false" --%>
        <ContentTemplate>
            <div style="padding-right:10px;" >
                <asp:DropDownList ID="ddlTrip" Width="300px" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlTrip_SelectedIndexChanged">
                </asp:DropDownList>
                <button onclick="calcRoute2();" class="btn btn-warning">
                    تتبع الرحلة</button>
                <button onclick="calcRoute();" class="btn btn-info">
                    مسار الرحلة</button>
                <button onclick="clearMarkers();" class="btn btn-danger">
                    مسح العلامات</button>
                &nbsp;&nbsp;<asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
            </div>
              <table style="padding-right:10px;">
    <tr>
        <td style="width:100px;">
            <asp:Label ID="Label1" runat="server" Text="المدينة"></asp:Label>
        </td>
        <td style="width:100px;">
             <asp:DropDownList ID="ddlCity" runat="server">
                <asp:ListItem>الرياض</asp:ListItem>
                <asp:ListItem>جده</asp:ListItem>
                <asp:ListItem>الدمام</asp:ListItem>
                <asp:ListItem>القريات</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width:150px;">
            <input id="btn" type="button" class="btn btn-primary" value="عرض المدينة" onclick="btnClick();" />
        </td>
        <td style="width:100px;">
            <asp:Label ID="Label20" runat="server" Text="النشاط"></asp:Label>
        </td>
        <td style="width:500px;">
            <asp:CheckBoxList ID="ChkType" Width="100%" runat="server" RepeatColumns="5" 
                AutoPostBack="True" onselectedindexchanged="ChkType_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True">شحن سيارات</asp:ListItem>
                <asp:ListItem Value="1" Selected="True">شحن طرود</asp:ListItem>
                <asp:ListItem Value="2" Selected="True">خدمات طريق</asp:ListItem>
                <asp:ListItem Value="3" Selected="True">مياه</asp:ListItem>
                <asp:ListItem Value="4" Selected="True">غاز</asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    </table>
        <table width="100%" cellpadding="2px" cellspacing="2px">
        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblCar1" runat="server" Text="فواتير سيارات معتمدة"></asp:Label>
            </td>
            <td style="width: 20%">
                <div id="div0Car1" runat="server">
                    <a class="Notybutton"><img src="images/Cars.png" title="سيارات معتمدة" style="cursor: pointer;" /><span
                     class="Notybutton__badge"><asp:Label ID="lblCarInv2" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlCar1" Width="80px" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlCar1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkCar1" style="color: Blue; cursor: pointer;"></i>
                    <asp:HyperLink ID="HlnkViewCar1" Visible="false" ToolTip="عرض الفاتورة" Target="_blank" runat="server"><i class="fa fa-eye  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
                    <asp:LinkButton ID="BtnCCar1" Visible="false" ToolTip="تجميع الفاتورة" 
                        runat="server" onclick="BtnCCar1_Click"><i class="fa fa-link  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
                    <asp:LinkButton ID="BtnDCar1" Visible="false" ToolTip="توزيع الفاتورة" runat="server"><i class="fa fa-chain-broken  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
                </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblCar2" runat="server" Text="فواتير سيارات معلقة"></asp:Label>
            </td>
            <td style="width: 20%">
                <div id="div0Car2" runat="server">
                    <a class="Notybutton"><img src="images/Cars1.png" title="سيارات معلقة" onclick="CallMe('2');" style="cursor: pointer;" /><span
                                    class="Notybutton__badge"><asp:Label ID="lblCarOnLine2" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlCar2" Width="80px" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlCar2_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkCar2" style="color: Red; cursor: pointer;" onclick="DrawMe('2',document.getElementById('<%=ddlCar2.ClientID%>').options[document.getElementById('<%=ddlCar2.ClientID%>').selectedIndex].value);"></i>
                    <asp:HyperLink ID="hlnkCar" Visible="false" ToolTip="أعتماد الفاتورة" Target="_blank" runat="server"><i class="fa fa-thumbs-up  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
                </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblCar3" runat="server" Text="فواتير سيارات تم نقلها"></asp:Label>
            </td>
            <td style="width: 20%">
                <div id="div0Car3" runat="server">
                    <a class="Notybutton">
                        <img src="images/Cars2.png" title="سيارات تم نقلها" style="cursor: pointer;" /><span
                            class="Notybutton__badge"><asp:Label ID="lblCarDone2" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlCar3" Width="80px" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlCar3_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkCar3" style="color: Green; cursor: pointer;"></i>
                    <asp:HyperLink ID="HlnkViewCar3" Visible="false" ToolTip="عرض الفاتورة" Target="_blank" runat="server"><i class="fa fa-eye  fa-2x" style="color: Green; cursor: pointer;"></i></asp:HyperLink>
                </div>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblExpress1" runat="server" Text="فواتير شحن معتمدة"></asp:Label>
            </td>
            <td style="width: 20%">
              <div id="div0Express1" runat="server">
                    <a class="Notybutton">
                        <img src="images/Express.png" title="شحنات معتمدة" onclick="CallMe('6');" style="cursor: pointer;" /><span
                            class="Notybutton__badge"><asp:Label ID="lblShipInv2" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlShip1" Width="80px" runat="server" AutoPostBack="True"  
                        onselectedindexchanged="ddlShip1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkExpress1" style="color: Blue; cursor: pointer;" onclick="DrawMe('6',document.getElementById('<%=ddlShip1.ClientID%>').options[document.getElementById('<%=ddlShip1.ClientID%>').selectedIndex].value);"></i>
                    <asp:HyperLink ID="HlnkViewExpress1" visible="false" Target="_blank" ToolTip="عرض الفاتورة" runat="server"><i class="fa fa-eye  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
                    <asp:LinkButton ID="BtnCExpress1" visible="false" ToolTip="تجميع الفاتورة" 
                        runat="server" onclick="BtnCExpress1_Click"><i class="fa fa-link  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
                    <asp:LinkButton ID="BtnDExpress1" visible="false" ToolTip="توزيع الفاتورة" runat="server"><i class="fa fa-chain-broken  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
                </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblExpress2" runat="server" Text="فواتير شحن معلقة"></asp:Label>
            </td>
            <td style="width: 20%">
              <div id="div0Express2" runat="server">
                <a class="Notybutton">
                    <img src="images/Express1.png" title="شحنات معلقة" onclick="CallMe('7');" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblShipOnLine2" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlShip2" Width="80px" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="ddlShip2_SelectedIndexChanged">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkExpress2" style="color: Red; cursor: pointer;" onclick="DrawMe('7',document.getElementById('<%=ddlShip2.ClientID%>').options[document.getElementById('<%=ddlShip2.ClientID%>').selectedIndex].value);"></i>
                <asp:HyperLink ID="HlnkExpress" visible="false" Target="_blank" ToolTip="أعتماد الفاتورة" runat="server"><i class="fa fa-thumbs-up  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
              </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblExpress3" runat="server" Text="فواتير شحن تم نقلها"></asp:Label>
            </td>
            <td style="width: 20%">
              <div id="div0Express3" runat="server">
                    <a class="Notybutton">
                        <img src="images/Express2.png" title="شحنات تم نقلها" style="cursor: pointer;" /><span
                            class="Notybutton__badge"><asp:Label ID="lblShipDone2" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlShip3" Width="80px" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlShip3_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkExpress3" style="color: Green; cursor: pointer;"></i>
                    <asp:HyperLink ID="HlnkViewExpress3" visible="false" Target="_blank" ToolTip="عرض الفاتورة" runat="server"><i class="fa fa-eye  fa-2x" style="color: Green; cursor: pointer;"></i></asp:HyperLink>
              </div>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblWater1" runat="server" Text="فواتير مياه معتمدة"></asp:Label>
            </td>
            <td style="width: 25%">
                <div id="div0Water1" runat="server">
                    <a class="Notybutton">
                        <img src="images/Water.png" title="فواتير مياة معتمدة" onclick="CallMe('4');" style="cursor: pointer;" /><span
                            class="Notybutton__badge"><asp:Label ID="lblWaterInv2" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlWater1" Width="80px" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlWater1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkWater1" style="color: Blue; cursor: pointer;" onclick="DrawMe('4',document.getElementById('<%=ddlWater1.ClientID%>').options[document.getElementById('<%=ddlWater1.ClientID%>').selectedIndex].value);"></i>
                    <asp:HyperLink ID="HlnkViewWater1" Visible="false" Target="_blank" ToolTip="عرض الفاتورة" runat="server"><i class="fa fa-eye  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
                    <asp:LinkButton ID="BtnCWater1" Visible="false" ToolTip="تجميع الفاتورة" runat="server"><i class="fa fa-link  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
                    <asp:LinkButton ID="BtnDWater1" Visible="false" ToolTip="توزيع الفاتورة" runat="server"><i class="fa fa-chain-broken  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
                </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblWater2" runat="server" Text="فواتير مياه معلقة"></asp:Label>
            </td>
            <td style="width: 25%">
              <div id="div0Water2" runat="server">
                <a class="Notybutton">
                    <img src="images/Water1.png" title="فواتير مياة معلقة" onclick="CallMe('3');" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblWaterOnLine2" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlWater2" Width="80px" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="ddlWater2_SelectedIndexChanged">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkWater2"  style="color: Red; cursor: pointer;" onclick="DrawMe('3',document.getElementById('<%=ddlWater2.ClientID%>').options[document.getElementById('<%=ddlWater2.ClientID%>').selectedIndex].value);"></i>
                <asp:HyperLink ID="HlnkWater" Target="_blank" visible="false" ToolTip="أعتماد الفاتورة" runat="server"><i class="fa fa-thumbs-up  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
               </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblWater3" runat="server" Text="فواتير مياه تم نقلها"></asp:Label>
            </td>
            <td style="width: 20%">
              <div id="div0Water3" runat="server">
                <a class="Notybutton">
                    <img src="images/Water2.png" title="فواتير مياة تم نقلها" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblWaterDone2" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlWater3" Width="80px" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="ddlWater3_SelectedIndexChanged">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkWater3"   style="color: Green; cursor: pointer;"></i>
                 <asp:HyperLink ID="HlnkViewWater3" Visible="false" Target="_blank" ToolTip="عرض الفاتورة" runat="server"><i class="fa fa-eye  fa-2x" style="color: Green; cursor: pointer;"></i></asp:HyperLink>
               </div>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblEr1" runat="server" Text="خدمات طريق معتمدة"></asp:Label>
            </td>
            <td style="width: 25%">
              <div id="div0Er1" runat="server">
                    <a class="Notybutton">
                        <img src="images/Emer.png" title="خدمات طريق معتمدة" onclick="CallMe('8');" style="cursor: pointer;" /><span
                            class="Notybutton__badge"><asp:Label ID="lblEmergInv2" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlService1" Width="80px" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="ddlService1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkEr1" style="color: Blue; cursor: pointer;" onclick="DrawMe('8',document.getElementById('<%=ddlService1.ClientID%>').options[document.getElementById('<%=ddlService1.ClientID%>').selectedIndex].value);"></i>
                    <asp:HyperLink ID="HlnkViewEr1" Visible="false" Target="_blank" ToolTip="عرض الفاتورة" runat="server"><i class="fa fa-eye  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
                    <asp:LinkButton ID="BtnCEr1" Visible="false" ToolTip="تجميع الفاتورة" runat="server"><i class="fa fa-link  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
                    <asp:LinkButton ID="BtnDEr1" Visible="false" ToolTip="توزيع الفاتورة" runat="server"><i class="fa fa-chain-broken  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
              </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblEr2" runat="server" Text="خدمات طريق معلقة"></asp:Label>
            </td>
            <td style="width: 25%">
              <div id="div0Er2" runat="server">
                    <a class="Notybutton">
                        <img src="images/Emer1.png" title="خدمات طريق معلقة" onclick="CallMe('9');" style="cursor: pointer;" /><span
                            class="Notybutton__badge"><asp:Label ID="lblEmergOnLine2" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlService2" Width="80px" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="ddlService2_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkEr2"  style="color: Red; cursor: pointer;" onclick="DrawMe('9',document.getElementById('<%=ddlService2.ClientID%>').options[document.getElementById('<%=ddlService2.ClientID%>').selectedIndex].value);"></i>
                    <asp:HyperLink ID="HlnkEr" Visible="false" Target="_blank" ToolTip="أعتماد الفاتورة" runat="server"><i class="fa fa-thumbs-up  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
               </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblEr3" runat="server" Text="خدمات طريق تم نقلها"></asp:Label>
            </td>
            <td style="width: 20%">
              <div id="div0Er3" runat="server">
                <a class="Notybutton">
                    <img src="images/Emer2.png" title="خدمات طريق تم تنفيذها" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblEmergDone2" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlService3" Width="80px" runat="server" 
                      AutoPostBack="True" onselectedindexchanged="ddlService3_SelectedIndexChanged">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkEr3"  style="color: Green; cursor: pointer;"></i>
                 <asp:HyperLink ID="HlnkViewEr3" Target="_blank" Visible="false"  ToolTip="عرض الفاتورة" runat="server"><i class="fa fa-eye  fa-2x" style="color: Green; cursor: pointer;"></i></asp:HyperLink>
               </div>
            </td>
        </tr>

         <tr>
            <td style="width: 10%">
                <asp:Label ID="lblGas1" runat="server" Text="فواتير غاز معتمده"></asp:Label>
            </td>
            <td style="width: 25%">
               <div id="div0Gas1" runat="server">
                    <a class="Notybutton">
                        <img src="images/Gas.png" title="فواتير غاز معتمده" onclick="CallMe('10');" style="cursor: pointer;" /><span
                            class="Notybutton__badge"><asp:Label ID="lblGasInv1" runat="server" Text=""></asp:Label></span></a>
                    <asp:DropDownList ID="ddlGas1" Width="80px" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlGas1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkGas1"  style="color: Blue; cursor: pointer;" onclick="DrawMe('10',document.getElementById('<%=ddlGas1.ClientID%>').options[document.getElementById('<%=ddlGas1.ClientID%>').selectedIndex].value);"></i>
                    <asp:HyperLink ID="HlnkViewGas1" Visible="false" Target="_blank" ToolTip="عرض الفاتورة" runat="server"><i class="fa fa-eye  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
                    <asp:LinkButton ID="BtnCGas1" Visible="false" ToolTip="تجميع الفاتورة" runat="server"><i class="fa fa-link  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
                    <asp:LinkButton ID="BtnDGas1" Visible="false" ToolTip="توزيع الفاتورة" runat="server"><i class="fa fa-chain-broken  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:LinkButton>
               </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblGas2" runat="server" Text="فواتير غاز معلقة"></asp:Label>
            </td>
            <td style="width: 25%">
               <div id="div0Gas2" runat="server">
                <a class="Notybutton">
                    <img src="images/Gas1.png" title="فواتير غاز معلقة" onclick="CallMe('11');" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblGasInv2" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlGas2" Width="80px" runat="server" AutoPostBack="True" 
                       onselectedindexchanged="ddlGas2_SelectedIndexChanged">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkGas2"  style="color: Red; cursor: pointer;" onclick="DrawMe('11',document.getElementById('<%=ddlGas2.ClientID%>').options[document.getElementById('<%=ddlGas2.ClientID%>').selectedIndex].value);"></i>
                <asp:HyperLink ID="HlnkGas" Visible="false" Target="_blank" ToolTip="أعتماد الفاتورة" runat="server"><i class="fa fa-thumbs-up  fa-2x" style="color: Blue; cursor: pointer;"></i></asp:HyperLink>
               </div>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblGas3" runat="server" Text="فواتير غاز تم نقلها"></asp:Label>
            </td>
            <td style="width: 20%">
               <div id="div0Gas3" runat="server">
                <a class="Notybutton">
                    <img src="images/Gas2.png" title="فواتير غاز تم نقلها" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblGasInv3" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlGas3" Width="80px" runat="server" AutoPostBack="True" 
                       onselectedindexchanged="ddlGas3_SelectedIndexChanged">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" runat="server" visible="false" id="MarkGas3" style="color: Green; cursor: pointer;"></i>
                 <asp:HyperLink ID="HlnkViewGas3" Visible="false" Target="_blank" ToolTip="عرض الفاتورة" runat="server"><i class="fa fa-eye  fa-2x" style="color: Green; cursor: pointer;"></i></asp:HyperLink>
               </div>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label ID="Label14" runat="server" Text="شاحنات جاهزة للتحميل"></asp:Label>
            </td>
            <td style="width: 20%">
                <a class="Notybutton">
                    <img src="images/Truck.png" title="شاحنات جاهزة للتحميل" onclick="CallMe('1');" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblFreeCar2" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlTruck1" Width="80px" runat="server">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" style="color: Blue; cursor: pointer;"></i>
            </td>
            <td style="width: 10%">
                <asp:Label ID="Label15" runat="server" Text="شاحنات في الصيانة"></asp:Label>
            </td>
            <td style="width: 20%">
                <a class="Notybutton">
                    <img src="images/Truck1.png" title="شاحنات في الصيانة" onclick="CallMe('13');" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblDamageCar2" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlTruck2" Width="80px" runat="server">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" style="color: Red; cursor: pointer;"></i>
            </td>
            <td style="width: 10%">
                <asp:Label ID="Label16" runat="server" Text="شاحنات في الطريق"></asp:Label>
            </td>
            <td style="width: 20%">
                <a class="Notybutton">
                    <img src="images/Truck2.png" title="شاحنات في الطريق" onclick="CallMe('14');" style="cursor: pointer;" /><span
                        class="Notybutton__badge"><asp:Label ID="lblBusyCar2" runat="server" Text=""></asp:Label></span></a>
                <asp:DropDownList ID="ddlTruck3" Width="80px" runat="server">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" style="color: Green; cursor: pointer;"></i>
            </td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:Label ID="Label17" runat="server" Text="سائق أون لاين"></asp:Label>
            </td>
            <td style="width: 20%">
                <asp:DropDownList ID="ddlDriverOnLine" Width="80px" runat="server">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" style="color: Green;"></i>
            </td>
            <td style="width: 10%">
                <asp:Label ID="Label18" runat="server" Text="سائق غير متاح"></asp:Label>
            </td>
            <td style="width: 20%">
                <asp:DropDownList ID="ddlDriver2" Width="80px" runat="server">
                </asp:DropDownList>
                <i class="fa fa-map-marker fa-2x" style="color: Red;"></i>
            </td>
            <td style="width: 10%">
            </td>
            <td style="width: 20%">
            </td>
            <td style="width: 10%">
            </td>
        </tr>
        <tr>
            <td style="width: 10%">                
                <button class="btn btn-warning">بيان التجميـع</button>
            </td>
            <td style="width: 20%">
                <asp:ListBox ID="lstCollect" CssClass="lstbox" runat="server"></asp:ListBox><br />
                <asp:Button ID="BtnClear1" runat="server" Text="مسح الفواتير" 
                    class="btn btn-danger" onclick="BtnClear1_Click"/>
            </td>
            <td style="width: 10%">
                <button class="btn btn-info">بيان التوزيـع</button>

            </td>
            <td style="width: 20%">
                <asp:ListBox ID="lstDist" CssClass="lstbox" runat="server"></asp:ListBox><br />
                <asp:Button ID="BtnClear2" runat="server" Text="مسح الفواتير" 
                    class="btn btn-danger" onclick="BtnClear2_Click"/>
             </td>
            <td style="width: 10%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 10%">                
                <asp:Label ID="Label2" runat="server" Text="التاريخ"></asp:Label>
            </td>
            <td style="width: 20%">
                <asp:DropDownList ID="ddlFDate" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlFDate_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="width: 10%">
                &nbsp;
            </td>
            <td style="width: 20%">
                &nbsp;
             </td>
            <td style="width: 10%">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 10%">
                &nbsp;</td>
        </tr>
    </table>

                        <asp:GridView ID="grdCodes" runat="server" CellPadding="4" 
                Width="50%" ForeColor="#333333" ViewStateMode="Enabled" GridLines="None" 
                AutoGenerateColumns="False" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="المستند" SortExpression="Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber" Text='<%# Eval("Number") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="النوع" SortExpression="FType" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFType" Text='<%# Eval("FType") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="السائق" SortExpression="DriverId" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDriverId" Text='<%# Eval("DriverId") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الوقت" SortExpression="FDateTime" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFDateTime" Text='<%# Eval("FDateTime") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الحدث" SortExpression="ActType" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActType" Text='<%# Eval("ActType") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                                HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  HorizontalAlign="Center" VerticalAlign="Middle" CssClass="centerHeaderText"  />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

            <asp:ListBox ID="ListWayPoints" runat="server"></asp:ListBox>
        
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
            <asp:AsyncPostBackTrigger ControlID="ddlTrip"/>   
        </Triggers>
    </asp:UpdatePanel>  
    </form>
    <script src="Bootstrap/js/bootstrap-arabic.min.js" type="text/javascript"></script>
    <script src="https://maps.googleapis.com/maps/api/js?region=SA&language=ar&key=AIzaSyBiZRfD5bZzvAJccC4ZWge89JW6qdlBL9s&libraries=places&callback=InitializeMap"
        async defer></script>
    <script type="text/javascript">

        var map;
        var markers = [];
        var myPos = { lat: 24.7092, lng: 46.672601 };
        var glat = 24.7092;
        var glng = 46.672601;
        //var glatlng = new google.maps.LatLng(24.7092, 46.672601);
        var marker;
        var directionsDisplay;
        var directionsService = new google.maps.DirectionsService();
        var testArray = [];

        function InitializeMap() {
            directionsDisplay = new google.maps.DirectionsRenderer();
            var myOptions = { zoom: 14,
                center: new google.maps.LatLng(glat, glng),
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                mapTypeControl: true,
                mapTypeControlOptions:
                                {
                                    style: google.maps.MapTypeControlStyle.DROPDOWN_MENU,
                                    poistion: google.maps.ControlPosition.TOP_RIGHT,
                                    mapTypeIds: [google.maps.MapTypeId.ROADMAP,
                                      google.maps.MapTypeId.TERRAIN,
                                      google.maps.MapTypeId.HYBRID,
                                      google.maps.MapTypeId.SATELLITE]
                                },
                navigationControl: true,
                navigationControlOptions:
                                {
                                    style: google.maps.NavigationControlStyle.ZOOM_PAN
                                },
                scaleControl: true,
                disableDoubleClickZoom: true,
                draggable: true,
                streetViewControl: true,
                draggableCursor: 'move'
            };
            map = new google.maps.Map(document.getElementById("map"), myOptions);
            var rendererOptions = { map: map };
            directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions);
            directionsDisplay.setMap(map);

            google.maps.event.addListener(map, 'zoom_changed', function () {
                zoomLevel = map.getZoom();
                setMapRefresh(map)
                //alert(zoomLevel);

                //                if (zoomLevel >= minFTZoomLevel) {
                //                    FTlayer.setMap(map);
                //                } else {
                //                    FTlayer.setMap(null);
                //                }
            });
        }

        function btnClick() {
            var ddlCity2 = document.getElementById("<%=ddlCity.ClientID%>");

            var Text = ddlCity2.options[ddlCity2.selectedIndex].text;
            var Value = ddlCity2.options[ddlCity2.selectedIndex].value;

            var geocoder = new google.maps.Geocoder();
            if (Text == 'دبي') {
                geocoder.geocode({ 'address': Text + ',الامارات' }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        glat = results[0].geometry.location.lat();
                        glng = results[0].geometry.location.lng();
                        // alert("location : " + results[0].geometry.location.lat() + " " + results[0].geometry.location.lng());
                        map.setCenter(new google.maps.LatLng(glat, glng));
                    } else {
                        alert("Something got wrong " + status);
                    }
                });
            }
            else {
                geocoder.geocode({ 'address': Text + ',السعودية' }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        glat = results[0].geometry.location.lat();
                        glng = results[0].geometry.location.lng();
                        // alert("location : " + results[0].geometry.location.lat() + " " + results[0].geometry.location.lng());
                        map.setCenter(new google.maps.LatLng(glat, glng));
                    } else {
                        alert("Something got wrong " + status);
                    }
                });
            }
        }

        function calcRoute() {
            // var start = document.getElementById('startvalue').value;
            // var end = document.getElementById('endvalue').value;
            //alert('اضغط لعرض مسار الرحلة');
            var sel = document.getElementById("<%=ListWayPoints.ClientID%>");
            var listLength = sel.options.length;
            var res = sel.options[0].value.split('#');
            var org = new google.maps.LatLng(res[0], res[1]);
            var res = sel.options[listLength - 1].value.split('#');
            var dest = new google.maps.LatLng(res[0], res[1]);


            //var org = new google.maps.LatLng(24.689981, 46.672623);
            //var dest = new google.maps.LatLng(24.680961, 46.666532);
            var request = {
                origin: org,
                destination: dest,
                travelMode: google.maps.DirectionsTravelMode.DRIVING
            };
            directionsService = new google.maps.DirectionsService();
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                }
                else alert('failed to get directions');
            });
        }

        function addMarker2(location, map, myLabel, src) {
            // Add the marker at the clicked location, and add the next-available label
            // from the array of alphabetical characters.
            var image = 'images/water.png';
            zoomLevel = map.getZoom();
            if (src == '1') {
                image = 'images/Truck.png';
                if (zoomLevel < 7) {
                    image = 'images/TruckR01.png';
                }
                else if (zoomLevel > 6 &&  zoomLevel < 13) {
                    image = 'images/TruckR02.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/TruckR03.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/TruckR04.png';
                }
                else if (zoomLevel > 18 ) {
                    image = 'images/TruckR05.png';
                }
            }
            else if (src == '2') {
                image = 'images/Cars1.png';
                if (zoomLevel < 7) {
                    image = 'images/Cars11.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Cars12.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Cars13.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Cars14.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Cars15.png';
                }
            }
            else if (src == '3') {
                image = 'images/Water1.png';
                if (zoomLevel < 7) {
                    image = 'images/Water11.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Water12.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Water13.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Water14.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Water15.png';
                }
            }
            else if (src == '4') {
                image = 'images/Water.png';
                if (zoomLevel < 7) {
                    image = 'images/Water01.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Water02.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Water03.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Water04.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Water05.png';
                }
            }
            else if (src == '5') {
                image = 'images/Cars.png';
                if (zoomLevel < 7) {
                    image = 'images/Cars01.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Cars02.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Cars03.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Cars04.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Cars05.png';
                }
            }
            else if (src == '6') {
                image = 'images/Express.png';
                if (zoomLevel < 7) {
                    image = 'images/Express01.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Express02.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Express03.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Express04.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Express05.png';
                }
            }
            else if (src == '7') {
                image = 'images/Express1.png';
                if (zoomLevel < 7) {
                    image = 'images/Express11.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Express12.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Express13.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Express14.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Express15.png';
                }
            }
            else if (src == '8') {
                image = 'images/Emer.png';
                if (zoomLevel < 7) {
                    image = 'images/Emer01.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Emer02.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Emer03.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Emer04.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Emer05.png';
                }
            }
            else if (src == '9') {
                image = 'images/Emer1.png';
                if (zoomLevel < 7) {
                    image = 'images/Emer11.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Emer12.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Emer13.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Emer14.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Emer15.png';
                }
            }
            else if (src == '10') {
                image = 'images/Gas.png';
                if (zoomLevel < 7) {
                    image = 'images/Gas01.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Gas02.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Gas03.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Gas04.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Gas05.png';
                }
            }
            else if (src == '11') {
                image = 'images/Gas1.png';
                if (zoomLevel < 7) {
                    image = 'images/Gas11.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Gas12.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Gas13.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Gas14.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Gas15.png';
                }
            }
            else if (src == '12') {
                image = 'images/Gas2.png';
                if (zoomLevel < 7) {
                    image = 'images/Gas21.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/Gas22.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/Gas23.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/Gas24.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/Gas25.png';
                }
            }
            else if (src == '13') {
                image = 'images/Truck1.png';
                if (zoomLevel < 7) {
                    image = 'images/TruckR11.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/TruckR12.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/TruckR13.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/TruckR14.png';
                }                
                else if (zoomLevel > 18) {
                    image = 'images/TruckR15.png';
                }
            }
            else if (src == '14') {
                image = 'images/Truck2.png';
                if (zoomLevel < 7) {
                    image = 'images/TruckR21.png';
                }
                else if (zoomLevel > 6 && zoomLevel < 13) {
                    image = 'images/TruckR22.png';
                }
                else if (zoomLevel > 12 && zoomLevel < 16) {
                    image = 'images/TruckR23.png';
                }
                else if (zoomLevel > 15 && zoomLevel < 19) {
                    image = 'images/TruckR24.png';
                }
                else if (zoomLevel > 18) {
                    image = 'images/TruckR25.png';
                }
            }


            var marker = new google.maps.Marker({
                position: location,
                //label: myLabel,
                map: map,
                icon: image
            });

            if (src == '14') {
                marker.setAnimation(google.maps.Animation.BOUNCE);
            }

            var infowindow = new google.maps.InfoWindow({
                content: '' + myLabel,
                position: location

            });
            //infoWindow.setPosition(location);
            google.maps.event.addListener(marker, 'click', function () {
                // Calling the open method of the infoWindow 
                infowindow.open(map, marker);
            });
            markers.push(marker);
            //infoWindow.setContent('' + myLabel);
            map.setCenter(location);
        }

        // Sets the map on all markers in the array.
        function setMapRefresh(map) {
            zoomLevel = map.getZoom();
            for (var i = 0; i < markers.length; i++) {
                if (markers[i].icon.includes("TruckR")) {
                    if (markers[i].icon.substring(13, 14) == "0") {
                        image = 'images/Truck.png';
                        if (zoomLevel < 7) {
                            image = 'images/TruckR01.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/TruckR02.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/TruckR03.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/TruckR04.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/TruckR05.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(13, 14) == "1") {
                        image = 'images/Truck1.png';
                        if (zoomLevel < 7) {
                            image = 'images/TruckR11.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/TruckR12.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/TruckR13.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/TruckR14.png';
                        }                
                        else if (zoomLevel > 18) {
                            image = 'images/TruckR15.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(13, 14) == "2") {
                        image = 'images/Truck2.png';
                        if (zoomLevel < 7) {
                            image = 'images/TruckR21.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/TruckR22.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/TruckR23.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/TruckR24.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/TruckR25.png';
                        }
                        markers[i].setIcon(image);
                        markers[i].setAnimation(google.maps.Animation.BOUNCE);
                    }
                } 

                if (markers[i].icon.includes("TruckL")) {
                    if (markers[i].icon.substring(13, 14) == "0") {
                        image = 'images/Truck.png';
                        if (zoomLevel < 7) {
                            image = 'images/TruckL01.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/TruckL02.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/TruckL03.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/TruckL04.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/TruckL05.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(13, 14) == "1") {
                        image = 'images/Truck1.png';
                        if (zoomLevel < 7) {
                            image = 'images/TruckL11.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/TruckL12.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/TruckL13.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/TruckL14.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/TruckL15.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(13, 14) == "2") {
                        image = 'images/Truck2.png';
                        if (zoomLevel < 7) {
                            image = 'images/TruckL21.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/TruckL22.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/TruckL23.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/TruckL24.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/TruckL25.png';
                        }
                        markers[i].setIcon(image);
                        markers[i].setAnimation(google.maps.Animation.BOUNCE);
                    }
                }

                if (markers[i].icon.includes("Cars")) {
                    if (markers[i].icon.substring(11, 12) == "0") {
                        image = 'images/Cars.png';
                        if (zoomLevel < 7) {
                            image = 'images/Cars01.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Cars02.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Cars03.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Cars04.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Cars05.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(11, 12) == "1") {
                        image = 'images/Cars1.png';
                        if (zoomLevel < 7) {
                            image = 'images/Cars11.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Cars12.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Cars13.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Cars14.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Cars15.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(11, 12) == "2") {
                        image = 'images/Cars2.png';
                        if (zoomLevel < 7) {
                            image = 'images/Cars21.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Cars22.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Cars23.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Cars24.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Cars25.png';
                        }
                        markers[i].setIcon(image);
                    }
                }


                if (markers[i].icon.includes("Water")) {
                    if (markers[i].icon.substring(12, 13) == "0") {
                        image = 'images/Water.png';
                        if (zoomLevel < 7) {
                            image = 'images/Water01.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Water02.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Water03.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Water04.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Water05.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(12, 13) == "1") {
                        image = 'images/Water1.png';
                        if (zoomLevel < 7) {
                            image = 'images/Water11.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Water12.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Water13.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Water14.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Water15.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(12, 13) == "2") {
                        image = 'images/Water2.png';
                        if (zoomLevel < 7) {
                            image = 'images/Water21.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Water22.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Water23.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Water24.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Water25.png';
                        }
                        markers[i].setIcon(image);
                    }
                }

                if (markers[i].icon.includes("Gas")) {
                    if (markers[i].icon.substring(10, 11) == "0") {
                        image = 'images/Gas.png';
                        if (zoomLevel < 7) {
                            image = 'images/Gas01.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Gas02.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Gas03.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Gas04.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Gas05.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(10, 11) == "1") {
                        image = 'images/Gas1.png';
                        if (zoomLevel < 7) {
                            image = 'images/Gas11.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Gas12.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Gas13.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Gas14.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Gas15.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(10, 11) == "2") {
                        image = 'images/Gas2.png';
                        if (zoomLevel < 7) {
                            image = 'images/Gas21.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Gas22.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Gas23.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Gas24.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Gas25.png';
                        }
                        markers[i].setIcon(image);
                    }
                }

                if (markers[i].icon.includes("Express")) {
                    if (markers[i].icon.substring(14, 15) == "0") {
                        image = 'images/Express.png';
                        if (zoomLevel < 7) {
                            image = 'images/Express01.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Express02.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Express03.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Express04.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Express05.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(14, 15) == "1") {
                        image = 'images/Express1.png';
                        if (zoomLevel < 7) {
                            image = 'images/Express11.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Express12.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Express13.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Express14.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Express15.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(14, 15) == "2") {
                        image = 'images/Express2.png';
                        if (zoomLevel < 7) {
                            image = 'images/Express21.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Express22.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Express23.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Express24.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Express25.png';
                        }
                        markers[i].setIcon(image);
                    }
                }

                if (markers[i].icon.includes("Emer")) {
                    if (markers[i].icon.substring(11, 12) == "0") {
                        image = 'images/Emer.png';
                        if (zoomLevel < 7) {
                            image = 'images/Emer01.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Emer02.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Emer03.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Emer04.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Emer05.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(11, 12) == "1") {
                        image = 'images/Emer1.png';
                        if (zoomLevel < 7) {
                            image = 'images/Emer11.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Emer12.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Emer13.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Emer14.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Emer15.png';
                        }
                        markers[i].setIcon(image);
                    }
                    else if (markers[i].icon.substring(11, 12) == "2") {
                        image = 'images/Emer2.png';
                        if (zoomLevel < 7) {
                            image = 'images/Emer21.png';
                        }
                        else if (zoomLevel > 6 && zoomLevel < 13) {
                            image = 'images/Emer22.png';
                        }
                        else if (zoomLevel > 12 && zoomLevel < 16) {
                            image = 'images/Emer23.png';
                        }
                        else if (zoomLevel > 15 && zoomLevel < 19) {
                            image = 'images/Emer24.png';
                        }
                        else if (zoomLevel > 18) {
                            image = 'images/Emer25.png';
                        }
                        markers[i].setIcon(image);
                    }
                }

            }
        }


        // Sets the map on all markers in the array.
        function setMapOnAll(map) {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(map);
            }
        }

        // Removes the markers from the map, but keeps them in the array.
        function clearMarkers() {
            setMapOnAll(null);
            markers = [];
        }


        function AddMarker() {
            marker = new google.maps.Marker({ position: new google.maps.LatLng(24.7092, 46.672601),
                map: map,
                title: 'Click me'
            });
            var infowindow = new google.maps.InfoWindow({
                content: 'Location info:'
            });
            google.maps.event.addListener(marker, 'click', function () {
                // Calling the open method of the infoWindow 
                infowindow.open(map, marker);
            });
        }

        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }

        function DrawMe(src, loc) {
            if (loc != '0') {
                clearMarkers();
                var mylat = parseFloat(loc.split('#')[0]);
                var mylng = parseFloat(loc.split('#')[1]);
                labels = loc.split('#')[2];                
                myPos = {
                    lat: mylat,
                    lng: mylng
                };
                addMarker2(myPos, map, labels, src);
            }
        }

        function CallMe(src) {
            //var ctrl = document.getElementById(src);
            // call server side method
            PageMethods.GetDate(src, CallSuccess, CallFailed, src);
        }

        // set the destination textbox value with the ContactName
        function CallSuccess(res, src) {
            res.forEach(function (entry) {
                var mylat = parseFloat(entry.split('#')[0]);
                var mylng = parseFloat(entry.split('#')[1]);
                labels = entry.split('#')[2];

                myPos = {
                    lat: mylat,
                    lng: mylng
                };
                addMarker2(myPos, map, labels, src);
            });
        }

        // alert message on some failure
        function CallFailed(res, destCtrl) {
            alert(res.get_message());
        }

        function calcRoute2() {
            var directionsService = new google.maps.DirectionsService();
            alert('اضغط لتحديد تتبع الرحلة');
            var waypts = [];

            var sel = document.getElementById("<%=ListWayPoints.ClientID%>");
            var listLength = sel.options.length;
            for (var i = 0; i < listLength; i++) {
                var res = sel.options[i].value.split('#');
                
                stop = new google.maps.LatLng(res[0], res[1]);
                if (i < 20) {
                    waypts.push({
                        location: stop
                    });
                }
                else if (i == listLength-1){
                    waypts.push({
                        location: stop
                    });
                }                
            }


            var res = sel.options[0].value.split('#');
            start = new google.maps.LatLng(res[0], res[1]);

            var res = sel.options[listLength-1].value.split('#');
            end = new google.maps.LatLng(res[0], res[1]);

            var request = {
                origin: start,
                destination: end,
                waypoints: waypts,
                optimizeWaypoints: true,
                travelMode: google.maps.DirectionsTravelMode.DRIVING
            };

//            directionsService.route(request, function (response, status) {
//                if (status == google.maps.DirectionsStatus.OK) {
//                    directionsDisplay.setDirections(response);
//                }
//                else alert('failed to get directions ' + status);
//            });

            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                    var route = response.routes[0];
                }
                else alert('failed to get directions');
            });
        }
        window.onload = InitializeMap;
    </script>
</body>
</html>
