<%@ Page Title="سياسة التسعير" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true" CodeBehind="WebNewPrices.aspx.cs" Inherits="ACC.WebNewPrices" Culture="ar-EG" UICulture="ar-EG"
    MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                  <div class="ColorRounded4Corners col-md-12 col-sm-12 col-xs-12">
              
                    <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Blue"
                        Text="سياسة التسعير"></asp:Label>
              <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">

                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label4" runat="server" Text="العميل"></asp:Label>
                  
                            <asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server" 
                                AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                            </asp:DropDownList>
                    </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label3" runat="server" Text="مستوى التسعير"></asp:Label>
                     
                            <asp:DropDownList ID="ddlLevel" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                       </div></div></div>
                          <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                            <asp:Label ID="Label2" runat="server" Text="المدينة"></asp:Label>
                    
                            <asp:DropDownList ID="ddlCity" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                      </div></div></div>
             <div class="table-responsive">
                    <asp:GridView ID="grdCodes" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="False"
                        GridLines="None" AutoGenerateColumns="False" DataKeyNames="FromCode,ToCode" AllowPaging="True"
                        PageSize="10" Width="99.9%" OnRowUpdating="grdCodes_RowUpdating" OnPageIndexChanging="grdCodes_PageIndexChanging"
                        OnRowCancelingEdit="grdCodes_RowCancelingEdit" OnRowDeleting="grdCodes_RowDeleting" OnRowEditing="grdCodes_RowEditing" OnSelectedIndexChanging="grdCodes_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="الغاء البند"
                                        ImageUrl="~/images/cross.png" OnClientClick='return confirm("هل أنت متاكد من الغاء هذا البند؟")' />
                                    <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="تعديل بيانات البند"
                                        ImageUrl="~/images/pencil.png" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="حفظ التعديلات"
                                        ImageUrl="~/images/accept.png" onload="btnUpdate_Load" />
                                    <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="تجاهل التعديلات"
                                        ImageUrl="~/images/delete.png" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="اضافة سعر مسار جديد"
                                        ImageUrl="~/images/add.png" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="من / فرع التجميع / نظاق الفرع" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFromCode2" Text='<%# Bind("FromCode2") %>' runat="server"></asp:Label><br />
                                    <asp:Label ID="lblCollectBran2" Text='<%# Bind("CollectBran2") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblBranRange" Text='<%# Bind("BranRange") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="70px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="إلى" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblToCode2" Text='<%# Bind("ToCode2") %>' runat="server"></asp:Label><br />
                                    <asp:Label ID="lblDisBran2" Text='<%# Bind("DisBran2") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblBranRange2" Text='<%# Bind("BranRange2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="70px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المسافة كم" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblKMeter" Text='<%# Eval("KMeter","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtKMeter" Text='<%# Bind("KMeter") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValKMeter" runat="server" ControlToValidate="txtKMeter"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                         
                            <asp:TemplateField HeaderText="معيار السعر" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" Text='<%# Bind("Price") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPrice" Text='<%# Bind("Price") %>' ReadOnly="true" runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValPrice" runat="server" ControlToValidate="txtPrice"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="فرق السعر" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblPriceDiff" Text='<%# Bind("PriceDiff") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPriceDiff" Text='<%# Bind("PriceDiff") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValPriceDiff" runat="server" ControlToValidate="txtPriceDiff"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سعر التجميع" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCollectPrice" Text='<%# Bind("CollectPrice") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblCollectPrice2" Text='<%# Bind("CollectPrice2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCollectPrice" Text='<%# Bind("CollectPrice") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValCollectPrice" runat="server" ControlToValidate="txtCollectPrice"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtCollectPrice2" Text='<%# Bind("CollectPrice2") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValCollectPrice2" runat="server" ControlToValidate="txtCollectPrice2"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سعر التوزيع" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisPrice" Text='<%# Bind("DisPrice") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblDisPrice2" Text='<%# Bind("DisPrice2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDisPrice" Text='<%# Bind("DisPrice") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValDisPrice" runat="server" ControlToValidate="txtDisPrice"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtDisPrice2" Text='<%# Bind("DisPrice2") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValDisPrice2" runat="server" ControlToValidate="txtDisPrice2"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سعر الخدمة" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblXPrice1" Text='<%# Bind("XPrice1") %>' ReadOnly="true" runat="server"></asp:Label>
                                    <asp:Label ID="lblXPrice2" Text='<%# Bind("XPrice2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtXPrice1" Text='<%# Bind("XPrice1") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValXPrice1" runat="server" ControlToValidate="txtXPrice1"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtXPrice2" Text='<%# Bind("XPrice2") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValXPrice2" runat="server" ControlToValidate="txtXPrice2"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ذهاب وآياب" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblHTwoWay" Text='<%# Bind("HTwoWay") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblLTwoWay" Text='<%# Bind("LTwoWay") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtHTwoWay" Text='<%# Bind("HTwoWay") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValHTwoWay" runat="server" ControlToValidate="txtHTwoWay"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtLTwoWay" Text='<%# Bind("LTwoWay") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValLTwoWay" runat="server" ControlToValidate="txtLTwoWay"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حموله دور واحد" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTruckPrice" Text='<%# Bind("TruckPrice") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblTruckPrice2" Text='<%# Bind("TruckPrice2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTruckPrice" Text='<%# Bind("TruckPrice") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValTruckPrice" runat="server" ControlToValidate="txtTruckPrice"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtTruckPrice2" Text='<%# Bind("TruckPrice2") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValTruckPrice2" runat="server" ControlToValidate="txtTruckPrice2"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حموله دورين" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTruck2Price" Text='<%# Bind("Truck2Price") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblTruck2Price2" Text='<%# Bind("Truck2Price2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTruck2Price" Text='<%# Bind("Truck2Price") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValTruck2Price" runat="server" ControlToValidate="txtTruck2Price"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtTruck2Price2" Text='<%# Bind("Truck2Price2") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValTruck2Price2" runat="server" ControlToValidate="txtTruck2Price2"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="زمن الشحن العادي" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFTime" Text='<%# Bind("FTime") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFTime" Text='<%# Bind("FTime") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValFTime" runat="server" ControlToValidate="txtFTime"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="60px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                         
                            <asp:TemplateField HeaderText="مصروف الطريق العادي" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCostAmount" Text='<%# Eval("CostAmount","{0:N0}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCostAmount" Text='<%# Bind("CostAmount") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValCostAmount" runat="server" ControlToValidate="txtCostAmount"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="معيار الشحن السريع" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblHOneWay" Text='<%# Bind("HOneWay") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtHOneWay" Text='<%# Bind("HOneWay") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValHOneWay" runat="server" ControlToValidate="txtHOneWay"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="فرق سعر الخدمة" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblLOneWay" Text='<%# Bind("LOneWay") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLOneWay" Text='<%# Bind("LOneWay") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValLOneWay" runat="server" ControlToValidate="txtLOneWay"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="سطحه عادي" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExPrice1" Text='<%# Bind("ExPrice1") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblExPrice01" Text='<%# Bind("ExPrice01") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExPrice1" Text='<%# Bind("ExPrice1") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice1" runat="server" ControlToValidate="txtExPrice1"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtExPrice01" Text='<%# Bind("ExPrice01") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice01" runat="server" ControlToValidate="txtExPrice01"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ذهاب وآياب" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExPrice12" Text='<%# Bind("ExPrice12") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblExPrice012" Text='<%# Bind("ExPrice012") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExPrice12" Text='<%# Bind("ExPrice12") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice12" runat="server" ControlToValidate="txtExPrice12"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtExPrice012" Text='<%# Bind("ExPrice012") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice012" runat="server" ControlToValidate="txtExPrice012"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نص هيدلوريك" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExPrice4" Text='<%# Bind("ExPrice4") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblExPrice04" Text='<%# Bind("ExPrice04") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExPrice4" Text='<%# Bind("ExPrice4") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice4" runat="server" ControlToValidate="txtExPrice4"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtExPrice04" Text='<%# Bind("ExPrice04") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice04" runat="server" ControlToValidate="txtExPrice04"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ذهاب وآياب" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExPrice42" Text='<%# Bind("ExPrice42") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblExPrice042" Text='<%# Bind("ExPrice042") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExPrice42" Text='<%# Bind("ExPrice42") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice42" runat="server" ControlToValidate="txtExPrice42"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtExPrice042" Text='<%# Bind("ExPrice042") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice042" runat="server" ControlToValidate="txtExPrice042"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="هيدلوريك كامل" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExPrice2" Text='<%# Bind("ExPrice2") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblExPrice02" Text='<%# Bind("ExPrice02") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExPrice2" Text='<%# Bind("ExPrice2") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice2" runat="server" ControlToValidate="txtExPrice2"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtExPrice02" Text='<%# Bind("ExPrice02") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice02" runat="server" ControlToValidate="txtExPrice02"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ذهاب وآياب" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExPrice22" Text='<%# Bind("ExPrice22") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblExPrice022" Text='<%# Bind("ExPrice022") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExPrice22" Text='<%# Bind("ExPrice22") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice22" runat="server" ControlToValidate="txtExPrice22"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtExPrice022" Text='<%# Bind("ExPrice022") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice022" runat="server" ControlToValidate="txtExPrice022"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مغطاه حاوبة" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExPrice3" Text='<%# Bind("ExPrice3") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblExPrice03" Text='<%# Bind("ExPrice03") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExPrice3" Text='<%# Bind("ExPrice3") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice3" runat="server" ControlToValidate="txtExPrice3"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtExPrice03" Text='<%# Bind("ExPrice03") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice03" runat="server" ControlToValidate="txtExPrice03"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ذهاب وآياب" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExPrice32" Text='<%# Bind("ExPrice32") %>' runat="server"></asp:Label>
                                    <asp:Label ID="lblExPrice032" Text='<%# Bind("ExPrice032") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtExPrice32" Text='<%# Bind("ExPrice32") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice32" runat="server" ControlToValidate="txtExPrice32"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                    <asp:TextBox ID="txtExPrice032" Text='<%# Bind("ExPrice032") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValExPrice032" runat="server" ControlToValidate="txtExPrice032"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="زمن الشحن السريع" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFTime2" Text='<%# Bind("FTime2") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFTime2" Text='<%# Bind("FTime2") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValFTime2" runat="server" ControlToValidate="txtFTime2"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                         
                            <asp:TemplateField HeaderText="مصروف التجميع" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblXPrice3" Text='<%# Bind("XPrice3") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtXPrice3" Text='<%# Bind("XPrice3") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValXPrice3" runat="server" ControlToValidate="txtXPrice3"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                         
                            <asp:TemplateField HeaderText="مصروف التوزيع" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblXPrice4" Text='<%# Bind("XPrice4") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtXPrice4" Text='<%# Bind("XPrice4") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValXPrice4" runat="server" ControlToValidate="txtXPrice4"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                         
                            <asp:TemplateField HeaderText="مصروف الشحن السريع" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblXPrice5" Text='<%# Bind("XPrice5") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtXPrice5" Text='<%# Bind("XPrice5") %>' runat="server" Width="95%" />
                                    <asp:CompareValidator ID="ValXPrice5" runat="server" ControlToValidate="txtXPrice5"
                                        Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" Operator="DataTypeCheck"
                                        Type="Currency">*</asp:CompareValidator>
                                </EditItemTemplate>
                                <ControlStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>                         

                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
                            HorizontalAlign="Center" />
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
                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
             
            </div></div></div></div>
       
</asp:Content>
