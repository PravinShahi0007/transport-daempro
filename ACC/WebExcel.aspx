<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebExcel.aspx.cs" Inherits="ACC.WebExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                         <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSheet" Width="100px" runat="server">
            <asp:ListItem Selected="True" Value="[Sheet1$]">Sheet1</asp:ListItem>
            <asp:ListItem Value="[Sheet2$]">Sheet2</asp:ListItem>
            <asp:ListItem Value="[Sheet3$]">Sheet3</asp:ListItem>
            <asp:ListItem Value="[Sheet4$]">Sheet4</asp:ListItem>
            <asp:ListItem Value="[Sheet5$]">Sheet5</asp:ListItem>
            <asp:ListItem Value="[Sheet6$]">Sheet6</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;
        <asp:DropDownList ID="ddlAction" Width="100px" runat="server">
            <asp:ListItem Selected="True" Value="0">سياسة التسعير</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;

                            <asp:Button ID="btnImport" runat="server" Text="استيراد البيانات" OnClick="btnImport_Click" />
                            <br />
                            <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>

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
    </form>
</body>
</html>
