<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebeServices.aspx.cs" Inherits="ACC.WebeServices" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
        .containerStep {
          width: 615px;
          margin: 6px auto;           
          z-index : 5;
        }
        .progressbar {
          margin: 0;
          padding: 0;
          counter-reset: step;
          z-index: 7;
        }
        .progressbar li {
          list-style-type: none;
          width: 15%;
          float: right;
          font-size: 12px;
          position: relative;
          text-align: center;
          color: #7d7d7d;
          z-index: 1;
        }
        .progressbar li:before {
          width: 30px;
          height: 30px;
          content: counter(step);
          counter-increment: step;
          line-height: 30px;
          border: 2px solid #7d7d7d;
          display: block;
          text-align: center;
          margin: 0 auto 6px auto;
          border-radius: 50%;
          background-color: white;
        }
        .progressbar li:after {
          width: 100%;
          height: 2px;
          content: '';
          position: absolute;
          background-color: #7d7d7d;
          top: 15px;
          right: -32%;        
          z-index: -1;
        }
        .progressbar li:first-child:after {
          content: none;
        }
        .progressbar li.active {
          color: green;
        }
        .progressbar li.active:before {
          border-color: #55b776;
        }
        .progressbar li.active + li:after {
          background-color: #55b776;
        }

        .progressbar li.current {
          color: blue;
        }
        .progressbar li.current:before {
          border-color: #55b776;
        }
        .progressbar li.refuse {
          color: red;
        }
        .progressbar li.refuse:before {
          border-color: #55b776;
        }
        .progressbar li.transfer {
          color:Orange;
        }
        .progressbar li.refuse:before {
          border-color: #55b776;
        }        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mdiv1" runat="server" class="Rounded4Corners div1" style="width:185px; height:500px; float:right; border: thin solid #444444; overflow:hidden; overflow-x:hidden; overflow-y:auto;">
        <center>
            <b>
                <asp:Label ID="Label1" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ أصدار معاملة جديدة ]"
                    meta:resourcekey="Label1"></asp:Label></b></center>
        <asp:BulletedList ID="BulletedList1" Target="_blank" Width="95%" DisplayMode="HyperLink"
            CssClass="Bullet" runat="server">
        </asp:BulletedList>
    </div>
    <span id="span1" runat="server" style="float:right;">&nbsp;&nbsp;&nbsp;</span>
    <div id="mdiv2" runat="server" class="Rounded4Corners div2" style="width:715px; height:500px; float:right; border: thin solid #444444; overflow:hidden; overflow-x:hidden; overflow-y:auto; z-index:-1;">
        <table width="100%">
            <tr>
                <td style="width:50px">
                    <asp:Label ID="Label3" runat="server" Text="النوع"></asp:Label>
                </td>
                <td style="width:200px">
                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="center" style="width:195px" >
                    <b><asp:Label ID="Label5" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ معاملات معلقة ]"></asp:Label></b>
                </td>
                <td style="width:50px">
                    <asp:Label ID="Label4" runat="server" Text="الشهر"></asp:Label>
                </td>
                <td style="width:100px">
                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="left" style="width:100px">
                    <i class="fa fa fa-wrench" ></i><a target="_blank" href='<%= string.Format("WebDealOut.aspx?AreaNo={0}&StoreNo={1}{2}",AreaNo,StoreNo,(Request.QueryString["Support"] != null ? "&Support=1" : "")) %>'><asp:Literal ID="Literal142" Text="أعدادات" runat="server"></asp:Literal></a>
                </td>
            </tr>                
        </table>
        <asp:GridView ID="grdActiveTran" CellPadding="4" AutoGenerateColumns="False" runat="server" AllowPaging="false"
                ForeColor="#333333" GridLines="None" PageSize="20" DataKeyNames="DocNo" Width="99.9%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="المعاملة" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                                <asp:HyperLink ID="lblName" Text='<%# Eval("Name2").ToString() + " " + Eval("DocNo").ToString()  %>' ToolTip="عرض المعاملة"
                                NavigateUrl='<%# Eval("FormName").ToString() + "?FNum=" + Eval("DocNo").ToString() + "&FLevel=" + Eval("Status").ToString()+"&FMode=0"  %>' Target="_blank" runat="server"></asp:HyperLink>            
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="خط سير المعاملة" SortExpression="DocNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Literal ID="Literal122" Text='<%# Eval("MakeDiv") %>' runat="server"></asp:Literal>
                        </ItemTemplate>
                        <ControlStyle Width="480px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center"
                    Font-Bold="True" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="center" />
                <RowStyle BackColor="#EFF3FB" Font-Size="Medium"  />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
      </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <div id="mdiv3" runat="server" class="Rounded4Corners div1" style="width:915px; height:2000px; float:right; border: thin solid #444444; overflow:hidden; overflow-x:hidden; overflow-y:auto;">
        <table width="100%">
            <tr>
                <td style="width:50px">
                    <asp:Label ID="Label6" runat="server" Text="النوع"></asp:Label>
                </td>
                <td style="width:150px">
                    <asp:DropDownList ID="ddlType2" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlMonth2_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="center" style="width:195px" >
                    <b><asp:Label ID="Label2" ForeColor="#800000" Font-Underline="true" runat="server" Text="[ أرشيف المعاملات ]" meta:resourcekey="Label1"></asp:Label></b>
                </td>
                <td style="width:50px">
                    <asp:Label ID="Label8" runat="server" Text="الشهر"></asp:Label>
                </td>
                <td style="width:100px">
                    <asp:DropDownList ID="ddlMonth2" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlMonth2_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>                
        </table>

                <asp:GridView ID="grdTranHistory" CellPadding="4" 
                AutoGenerateColumns="False" runat="server" AllowPaging="true"
                ForeColor="#333333" GridLines="None" PageSize="20" DataKeyNames="DocNo" 
                Width="99.9%" onpageindexchanging="grdTranHistory_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="المعاملة" SortExpression="Name2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                                <asp:HyperLink ID="lblName" Text='<%# Eval("Name2").ToString() + " " + Eval("DocNo").ToString()  %>' ToolTip="عرض المعاملة"
                                NavigateUrl='<%# Eval("FormName").ToString() + "?FNum=" + Eval("DocNo").ToString() + "&FLevel=" + Eval("Status").ToString()+"&FMode=0"  %>' Target="_blank" runat="server"></asp:HyperLink>            
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="التاريخ" SortExpression="DocDate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDocDate" runat="server" Text='<%# Eval("DocDate")  %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="خط سير المعاملة" SortExpression="DocNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Literal ID="Literal122" Text='<%# Eval("MakeDiv") %>' runat="server"></asp:Literal>
                        </ItemTemplate>
                        <ControlStyle Width="650px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center"
                    Font-Bold="True" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="center" />
                <RowStyle BackColor="#EFF3FB" Font-Size="Medium"  />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>    
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <asp:Label ID="LblCodesResult" runat="server" Text=""></asp:Label>
</asp:Content>
