<%@ Page Title="مواقع الفروع" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebBranchLoc.aspx.cs" Inherits="ACC.WebBranchLoc" Culture="auto:ar-EG" UICulture="auto"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="DivInfo2" runat="server" class="Rounded4Corners div1" style="<%$ Resources: mDivInfo %>">
        <center>               
             <table cellpadding="3px" cellspacing="3px" class="Infotable">
                <thead>
                    <tr>
                        <th colspan="3" align="center">
                            <asp:Literal ID="Literal3" Text="<%$ Resources:BranchDescr %>" runat="server"></asp:Literal>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Literal ID="Literal1" Text="<%$ Resources:Branch %>" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="Literal2" Text="<%$ Resources:Loc %>" runat="server"></asp:Literal>
                        </th>
                    </tr>
                </thead>
                <tbody>
                     <%=getStartData(6)%>                     
                </tbody>
            </table>                        
        </center>
     </asp:Panel>

    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />
</asp:Content>
