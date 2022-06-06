<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebCheckList.aspx.cs" Inherits="ACC.WebCheckList" Culture="en-GB"
    UICulture="en-GB" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="ColorRounded4Corners" style="width: 99.8%">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 99.5%;
                border: solid 2px #800000">
                <legend align="center" style="font-size: 18px; color: #800000; text-align: center;">
                    <b><asp:Literal ID="lblHeader" runat="server" Text="[ Repair Vehical Received Check List ]"></asp:Literal></b></legend>
                <table width="99%" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label11" runat="server" Text="Check List No."></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtVouNo" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:Label ID="lblBranch" runat="server" Text="Label"></asp:Label>
                            <asp:ImageButton ID="BtnFind" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                ToolTip="Search for Request No." OnClick="BtnFind_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVouNo"
                                Display="Dynamic" ErrorMessage="You should Enter Check List No." ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label1" runat="server" Text="Request No."></asp:Label>
                            *
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtRepairReqNo" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="BtnFind2" runat="server" ValidationGroup="55" ImageUrl="~/images/zoom_16.png"
                                ToolTip="Search for Request No." OnClick="BtnFind2_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRepairReqNo"
                                Display="Dynamic" ErrorMessage="You should Enter Request No." ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label2" runat="server" Text="Date - Time In "></asp:Label>
                            *
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtVouDate" MaxLength="10" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVouDate"
                                Display="Dynamic" ErrorMessage="You Should Select Date in" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="ValBirthDate2" runat="server" ControlToValidate="txtVouDate"
                                CultureInvariantValues="true" Display="Dynamic" ErrorMessage="Request Date Should be Date Value"
                                ForeColor="Red" Type="Date" ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                TargetControlID="txtVouDate" Format="dd/MM/yyyy" Animated="true" FirstDayOfWeek="Saturday"
                                PopupPosition="BottomLeft" />
                            <asp:TextBox ID="txtInTime" runat="server" Text="00:00" MaxLength="8" Width="60px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtInTime"
                                Mask="99:99" MaskType="Time" CultureName="en-us" MessageValidatorTip="true"
                                runat="server">
                            </ajaxToolkit:MaskedEditExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInTime"
                                Display="Dynamic" ErrorMessage="You Should Enter In Time" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="LblCode" runat="server" Text="Vehicle Type"></asp:Label>*
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlVehType" Width="250" runat="server" 
                                AutoPostBack="True" onselectedindexchanged="ddlVehType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label10" runat="server" Text="Vehicle/No."></asp:Label>                            
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlVehicle" Width="200" runat="server">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtCarNo" MaxLength="15" Width="80px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label3" runat="server" Text="Model"></asp:Label>*
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtModel" MaxLength="20" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label6" runat="server" Text="Branch"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlBranch" Width="250" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label4" runat="server" Text="Employee Name"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlDriver" Width="250" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDriver"
                                InitialValue="-1" Display="Dynamic" ErrorMessage="You Should Driver" ForeColor="Red"
                                SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label5" runat="server" Text="Job Title"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlJob" Width="250" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15%;">
                        </td>
                        <td style="width: 35%;">
                        </td>
                    </tr>
                </table>
                <div id="Model1" runat="server">
                    <table width="99%" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label7" runat="server" Text="Engine Type"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtEngineType" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label130" runat="server" Text="Engine S.No."></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtEngineSNo" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label16" runat="server" Text="Gear Box Type"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtGearType" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label17" runat="server" Text="Gear Box S.No."></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtGearSNo" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label18" runat="server" Text="A.C. Type"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtACType" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label19" runat="server" Text="A.C. S.No."></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtACSNo" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label22" runat="server" Text="Injection Pump Type"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtIPType" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label23" runat="server" Text="Injection Pump S.No."></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtIPSNo" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                </div>
                <table class="box-table-a" width="99.5%">
                    <tbody>
                           <tr>
                                <td style="width: 50px;">
                                  <strong>SL.</strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <strong>Description</strong>                                  
                                </td>
                                <td style="width: 100px">
                                   <strong>Issurance</strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <strong>Turn Over</strong>                                  
                                </td>
                                <td style="width: 50px">
                                    <strong>SL.</strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <strong>Description</strong>                                  
                                </td>
                                <td style="width: 100px">
                                    <strong>Issurance</strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <strong>Turn Over</strong>                                  
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo01" runat="server" Text="1"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem01" runat="server" Text="License"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem01" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem01" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo16" runat="server" Text="1"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem16" runat="server" Text="Side Mirrors"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem16" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem16" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                            <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo02" runat="server" Text="2"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem02"  runat="server" Text="MVPI Document"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem02" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem02" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo17" runat="server" Text="2"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem17" runat="server" Text="Internal Mirrors"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem17" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem17" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                            <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo03" runat="server" Text="3"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem03" runat="server" Text="Front Glass"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem03" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem03" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo18" runat="server" Text="3"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem18" runat="server" Text="Seats"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem18" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem18" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                            <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo04" runat="server" Text="4"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem04" runat="server" Text="Back Glass"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem04" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem04" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo19" runat="server" Text="4"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem19" runat="server" Text="AC Unit"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem19" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem19" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                            <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo05" runat="server" Text="5"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem05" runat="server" Text="Front Doors"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem05" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem05" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo20" runat="server" Text="5"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem20" runat="server" Text="Radio & Sterio"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem20" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem20" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo06" runat="server" Text="6"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem06" runat="server" Text="Back Doors"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem06" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem06" MaxLength="30"  Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo21" runat="server" Text="6"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem21" runat="server"  Text="Spare Tires"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem21" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem21" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo07" runat="server" Text="7"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem07" runat="server" Text="Front Shield"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem07" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem07" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo22" runat="server" Text="7"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem22" runat="server" Text="Tools & Jack"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem22" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem22" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo08" runat="server" Text="8"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem08" runat="server" Text="Back Shield"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem08" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem08" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo23" runat="server" Text="8"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem23" runat="server" Text="Plates"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem23" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem23" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo9" runat="server" Text="9"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem09" runat="server" Text="Front Lights"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem09" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem09" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo24" runat="server" Text="9"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem24" runat="server"  Text="K.M. Reading"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem24" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem24" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo10" runat="server" Text="10"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem10" runat="server" Text="Back Lights"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem10" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem10" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo25" runat="server" Text="10"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem25" runat="server" Text="Others"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem25" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem25" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo11" runat="server" Text="11"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem11" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem11" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem11" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo26" runat="server" Text="11"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem26" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem26" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem26" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo12" runat="server" Text="12"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem12" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem12" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem12" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo27" runat="server" Text="12"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem27" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem27" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem27" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo13" runat="server" Text="13"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem13" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem13" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem13" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo28" runat="server" Text="13"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem28" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem28" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem28" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo14" runat="server" Text="14"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem14" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem14" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem14" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo29" runat="server" Text="14"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem29" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem29" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem29" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                           <tr>
                                <td style="width: 50px;">
                                  <strong><asp:Label ID="lblSNo15" runat="server" Text="15"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                    <asp:Label ID="lblItem15" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtItem15" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="txtSItem15" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 50px">
                                    <strong><asp:Label ID="lblSNo30" runat="server" Text="15"></asp:Label></strong>                                  
                                </td>
                                <td style="width: 100px;">
                                   <asp:Label ID="lblItem30" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width: 100px">
                                   <asp:TextBox ID="txtItem30" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                   <asp:TextBox ID="txtSItem30" MaxLength="30" Width="100px" runat="server"></asp:TextBox>
                                </td>
                           </tr>
                        </tbody>
                    </table>
                <table width="99%" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label8" runat="server" Text="Remark 1"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtRemark1" MaxLength="100" Width="250px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label35" runat="server" Text="Remark 2"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtRemark2" MaxLength="100" Width="250px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label9" runat="server" Text="Remark 3"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtRemark3" MaxLength="100" Width="250px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                            <asp:Label ID="Label20" runat="server" Text="Remark 4"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtRemark4" MaxLength="100" Width="250px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label21" runat="server" Text="Remark 5"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtRemark5" MaxLength="100" Width="250px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                        </td>
                        <td style="width: 35%;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label14" runat="server" Text="User Name"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                        <asp:TextBox ID="txtUserName" Width="300px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                            Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 15%;">
                        <asp:Label ID="Label15" runat="server" Text="Date"></asp:Label>
                        </td>
                        <td style="width: 35%;">
                        <asp:TextBox ID="txtUserDate" Width="100px" runat="server" MaxLength="50" BackColor="#E8E8E8"
                            Enabled="false">                                                               
                        </asp:TextBox>
                        <asp:Label ID="Label27" runat="server" Text="* Required Fields"></asp:Label>
                        </td>
                    </tr>

                </table>
            </fieldset>
            <table id="Table2" width="100%" cellpadding="0" cellspacing="0">              
                <tr align="center">
                    <td colspan="4">
                        <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4" style="width: 100%;">
                        <asp:ImageButton ID="BtnNew" runat="server" AlternateText="New" CommandName="New"
                            ImageUrl="~/images/insource_641.png" CssClass="ops" ToolTip="Add New Repair Request"
                            ValidationGroup="1" OnClientClick='return confirm("Adding New Repair Request...Are You Sure?")'
                            OnClick="BtnNew_Click" />
                        <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="Edit" CommandName="Edit"
                            ImageUrl="~/images/draw_pen_641.png" CssClass="ops" ToolTip="Edit Repair Request"
                            Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                        <asp:ImageButton ID="BtnClear" runat="server" AlternateText="Clear" CommandName="Clear"
                            ImageUrl="~/images/erasure_641.png" CssClass="ops" ToolTip="Clear Form Fields"
                            OnClick="BtnClear_Click" />
                        <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="Delete" CommandName="Delete"
                            ImageUrl="~/images/cut_641.png" CssClass="ops" ToolTip="Delete Repair Request"
                            OnClientClick='return confirm("Delete This Repair Request...Are You Sure?")'
                            OnClick="BtnDelete_Click" />
                        <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="Find" CommandName="Find"
                            ImageUrl="~/images/binoculars_641.png" CssClass="ops" ToolTip="Search for Repair Request"
                            OnClick="BtnSearch_Click" />
                        <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="Print" CommandName="Print"
                            ImageUrl="~/images/print_641.png" ValidationGroup="1" CssClass="ops" ToolTip="Print Repair Request"
                            />
                    </td>
                </tr>
            </table>
            <div style="text-align: right; width: 50%;">
                <asp:Panel ID="Panel2" runat="server" Height="30px" BackColor="#5D7B9D" Width="99.5%"
                    Direction="LeftToRight" ForeColor="#FFFF99">
                    <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left;">
                            Attach Files</div>
                        <div style="float: left; margin-right: 20px;">
                            <asp:Label ID="Label34" runat="server">(Show Details...)</asp:Label>
                        </div>
                        <div style="float: right; vertical-align: middle;">
                            <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Height="0" BackColor="#5D7B9D" Width="99.3%"
                    BorderColor="Maroon">
                    <asp:GridView ID="grdAttach" runat="server" CellPadding="4" ForeColor="#333333"
                        ShowHeader="False" GridLines="None" AutoGenerateColumns="False" DataKeyNames="FNo"
                        Width="99%" OnRowDeleting="grdAttach_RowDeleting">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="Delete File"
                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("Delete tis File ... Are you Sure?")' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lblFileName" Text='<%# Bind("FileName") %>' NavigateUrl='<%# Bind("FileName2") %>'
                                        Target="_blank" runat="server"></asp:HyperLink>
                                </ItemTemplate>
                                <ControlStyle Width="300px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
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
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td align="right">
                                <asp:ImageButton ID="BtnAttach" runat="server" AlternateText="Attach" CommandName="Attach"
                                    CssClass="ops" ImageUrl="~/images/attach1.png" ToolTip="Attach File" ValidationGroup="1"
                                    OnClick="BtnAttach_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajax:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                    ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label13"
                    ImageControlID="Image1" ExpandedText="(Hide Details)" CollapsedText="(Show Details)"
                    ExpandDirection="Vertical" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                    SuppressPostBack="true" />
            </div>
        </div>
    </center>
</asp:Content>
