<%@ Page Title="" Language="C#" MasterPageFile="~/MySite.Master" AutoEventWireup="true"
    Culture="ar-EG" MaintainScrollPositionOnPostback="true" CodeBehind="WebSal.aspx.cs"
    Inherits="ACC.WebSal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD
 <div class="col-md-12  col-sm-12 col-xs-12">
        <div class="card card-body">
                <h3 align="center">
                    [ بيانات الرواتب ]</h3>
         
                    <div class="box box-info" align="right">
                <div class="body">
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label2" runat="server" Text="الشهر*"></asp:Label>
                         
=======
    <center dir="rtl">
        <div class="ColorRounded4Corners">
            <fieldset class="Rounded4CornersNoShadow" style="padding: 2px; margin: 2px; width: 98%;
                ">
                <legend align="right" style="font-size: 18px; color: #800000; text-align: center;"><b>
                    [ بيانات الرواتب ]</b></legend>
                <center>
                    <table id="Table1" dir="rtl" width="98%" cellpadding="2" style="color: Black">
                        <tr id="tr2" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label2" runat="server" Text="الشهر*"></asp:Label>
                            </td>
                            <td style="width: 300px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMonth"
                                    ErrorMessage="يجب أختيار الشهر" ForeColor="Red" SetFocusOnError="True" ValidationGroup="1"
                                    InitialValue="-1" Display="Dynamic">*</asp:RequiredFieldValidator>
<<<<<<< HEAD
                            </div></div></div>
                    
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                       <asp:Label ID="Label7" runat="server" Text="الاسم"></asp:Label>
                                        <asp:TextBox ID="txtCode" CssClass="form-control"  Placeholder="البحث باسم الموظف"  runat="server" 
                                             AutoPostBack="True" ontextchanged="txtCode_TextChanged" />
=======
                            </td>
                            <td style="width: 100px;">
                                &nbsp;</td>
                            <td style="width: 300px;">
                                <div style="text-align: center; color: Red; font-weight: bold">
                                        <asp:TextBox ID="txtCode" CssClass="form-control"  Placeholder="البحث باسم الموظف"  runat="server" 
                                            Width="250px" AutoPostBack="True" ontextchanged="txtCode_TextChanged" />
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                        <asp:ImageButton ID="BtnFind" runat="server" ImageUrl="~/images/zoom_16.png" OnClick="BtnFind_Click"
                                             ImageAlign="Top" ToolTip="البحث عن بيانات الموظف" style="height: 16px" />
                                
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender02" runat="server" TargetControlID="txtCode"
                                            ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionEMP" 
                                            MinimumPrefixLength="1" CompletionInterval="500" EnableCaching="true" CompletionSetCount="12"
                                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" />
                               </div></div></div>
                             <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="LblCode" runat="server" Text="كود الموظف*"></asp:Label>
<<<<<<< HEAD
                           
=======
                            </td>
                            <td style="width: 300px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:DropDownList ID="ddlEmpCode" CssClass="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlEmpCode_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ValEmpCode" runat="server" ControlToValidate="ddlEmpCode"
                                    InitialValue="-1" ErrorMessage="يجب إدخال كود الموظف" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1" Display="Dynamic">*</asp:RequiredFieldValidator>
                         </div></div></div>
                             <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                             
                     
                                <asp:Label ID="lblName" Width="300px" runat="server" Text=""></asp:Label>
                           
                                <asp:Label ID="Label6" runat="server" Text="القسم*"></asp:Label>
<<<<<<< HEAD
                          
=======
                            </td>
                            <td style="width: 300px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:DropDownList ID="ddlSection" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSection"
                                    InitialValue="-1" ErrorMessage="يجب اختيار القسم" ForeColor="Red" SetFocusOnError="True"
                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
<<<<<<< HEAD
                         </div></div></div>
                             <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label4" runat="server" Text="ملاحظات"></asp:Label>
                                               
                                <asp:TextBox ID="txtRemark" MaxLength="500" CssClass="form-control" runat="server"></asp:TextBox>                                
                          </div></div></div>
              <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
=======
                            </td>
                            
                        </tr>

                        <tr id="tr12" align="right">
                            <td style="width: 100px;">
                                <asp:Label ID="Label4" runat="server" Text="ملاحظات"></asp:Label>
                            </td>
                            <td  style="width: 25%">                                
                                <asp:TextBox ID="txtRemark" MaxLength="500" CssClass="form-control" runat="server"></asp:TextBox>                                
                            </td>
                        </tr>

                    </table>
                    <table id="box-table-a1"  width="98%" cellpadding="2px" cellspacing="5px" style="color: Black">
                        <thead>
                            <tr>
                                <th scope="col" colspan="3" align="right">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    الاستحقاقات
                            
                                    الاستقطاعات
                              </div></div></div>
                           <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblBasic" runat="server" Text="الراتب الأساسي"></asp:Label>
<<<<<<< HEAD
                              
=======
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtBasic" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtBasic"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                       </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsBasic" Placeholder="ملاحظات" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                                 </div></div></div>
                             <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed01" runat="server" Text="تأمينات"></asp:Label>
                       
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsBasic" Placeholder="ملاحظات" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed01" runat="server" Text="تأمينات"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed01" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToValidate="txtDed01"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                            </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed01" Placeholder="ملاحظات" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                             <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd01" runat="server" Text="بدل انتقال"></asp:Label>
                           
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed01" Placeholder="ملاحظات" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr16" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd01" runat="server" Text="بدل انتقال"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd01" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtAdd01"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                               
                                    <asp:TextBox ID="txtsAdd01" Placeholder="ملاحظات" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                             <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed02" runat="server" Text="غياب"></asp:Label>
                            
                                    <asp:TextBox ID="txtDed02" CssClass="form-control" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                  </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtDed021"  Placeholder="يوم" CssClass="removesp form-control" 
                                        runat="server" MaxLength="10" AutoPostBack="True" 
                                        ontextchanged="txtDed021_TextChanged" ></asp:TextBox></div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd01" Placeholder="ملاحظات" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed02" runat="server" Text="غياب"></asp:Label>
                                </td>
                                <td style="width: 120px">
                                    <asp:TextBox ID="txtDed02" CssClass="form-control" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox ID="txtDed021"  Placeholder="يوم" CssClass="removesp form-control" 
                                        runat="server" MaxLength="10" AutoPostBack="True" 
                                        ontextchanged="txtDed021_TextChanged" ></asp:TextBox>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed022"  Placeholder="س" runat="server" 
                                        CssClass="removesp form-control" MaxLength="10" AutoPostBack="True" 
                                        ontextchanged="txtDed021_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator17" runat="server" ControlToValidate="txtDed021"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator31" runat="server" ControlToValidate="txtDed022"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                          </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed02" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                       </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd02" runat="server" Text="بدل السكن"></asp:Label>
                           
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed02" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr17" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd02" runat="server" Text="بدل السكن"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd02" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtAdd02"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                               </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd02" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                            </div></div></div>
                                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed03" runat="server" Text="سلف"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd02" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed03" runat="server" Text="سلف"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed03" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator19" runat="server" ControlToValidate="txtDed03"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                           </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed03" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                         <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd03" runat="server" Text="بدل طعام"></asp:Label>
                              
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed03" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr18" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd03" runat="server" Text="بدل طعام"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd03" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="txtAdd03"
                                        ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency" ValidationGroup="1"
                                        Display="Dynamic" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                            </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd03" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">

                                    <asp:Label ID="lblDed04" runat="server" Text="جزاءات اخرى"></asp:Label>
                          
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd03" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed04" runat="server" Text="جزاءات اخرى"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed04" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToValidate="txtDed04"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed04" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd04" runat="server" Text="بدلات أخرى"></asp:Label>
                           
                                    <asp:TextBox ID="txtAdd04" CssClass="form-control" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                  </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtAdd041"  Placeholder="يوم" runat="server" 
                                        CssClass="removesp form-control" MaxLength="10" AutoPostBack="True" 
                                        ontextchanged="txtAdd041_TextChanged"></asp:TextBox>
                                  </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed04" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr19" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd04" runat="server" Text="بدلات أخرى"></asp:Label>
                                </td>
                                <td style="width: 120px">
                                    <asp:TextBox ID="txtAdd04" CssClass="form-control" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox ID="txtAdd041"  Placeholder="يوم" runat="server" 
                                        CssClass="removesp form-control" MaxLength="10" AutoPostBack="True" 
                                        ontextchanged="txtAdd041_TextChanged"></asp:TextBox>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd042"  Placeholder="س" runat="server" 
                                        CssClass="removesp form-control" MaxLength="10" AutoPostBack="True" 
                                        ontextchanged="txtAdd041_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtAdd041"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator32" runat="server" ControlToValidate="txtAdd042"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd04" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                             </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed09" runat="server" Text="أستقطاع 5" ></asp:Label>
                             
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd04" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>

                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed09" runat="server" Text="أستقطاع 5" ></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed09" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator23" runat="server" ControlToValidate="txtDed09"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                           </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed09" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd05" runat="server" Text="بدل 1"></asp:Label>
                            
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed09" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr22" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd05" runat="server" Text="بدل 1"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd05" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtAdd05"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                                                               </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">

                                    <asp:TextBox ID="txtsAdd05" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed10" runat="server" Text="أستقطاع 6"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd05" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed10" runat="server" Text="أستقطاع 6"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed10" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator24" runat="server" ControlToValidate="txtDed10"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed10" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd06" runat="server" Text="بدل 2"></asp:Label>
                       
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed10" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr31" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd06" runat="server" Text="بدل 2"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd06" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="txtAdd06"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd06" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed11" runat="server" Text="أستقطاع 6"></asp:Label>
                              
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd06" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed11" runat="server" Text="أستقطاع 6"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed11" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtDed11"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                               </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed11" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                            </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd07" runat="server" Text="بدل 3"></asp:Label>
                              
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed11" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr32" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd07" runat="server" Text="بدل 3"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd07" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="txtAdd07"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                               </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd07" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed12" runat="server" Text="أستقطاع 6"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd07" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed12" runat="server" Text="أستقطاع 6"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed12" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="txtDed12"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                                </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed12" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd15" runat="server" Text="بدل 3"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed12" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr34" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd15" runat="server" Text="بدل 3"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd15" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator33" runat="server" ControlToValidate="txtAdd15"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                            </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd15" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed13" runat="server" Text="أستقطاع 6"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd15" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed13" runat="server" Text="أستقطاع 6"></asp:Label>
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed13" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator26" runat="server" ControlToValidate="txtDed13"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed13" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd08" runat="server" Text="بدل 4"></asp:Label>
                             
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed13" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr33" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd08" runat="server" Text="بدل 4"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd08" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="txtAdd08"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                              </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd08" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                             </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed14" runat="server" Text="أستقطاع 6"></asp:Label>
                             
                                    <asp:TextBox ID="txtDed14" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                   </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd08" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed14" runat="server" Text="أستقطاع 6"></asp:Label>
                                </td>
                                <td style="width: 120px">
                                    <asp:TextBox ID="txtDed14" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed014"  Placeholder="يوم" CssClass="removesp form-control" 
                                        runat="server" MaxLength="10" AutoPostBack="True" 
                                        ontextchanged="txtDed014_TextChanged"></asp:TextBox>
                                   
                                   
                                    <asp:CompareValidator ID="CompareValidator28" runat="server" ControlToValidate="txtDed14"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                                 </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed14" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd12" runat="server" Text="بدل 5"></asp:Label>
                              
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed14" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr5" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd12" runat="server" Text="بدل 5"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd12" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator25" runat="server" ControlToValidate="txtAdd12"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd12" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                             </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed15" runat="server" Text="أستقطاع 6"></asp:Label>
                          
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd12" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed15" runat="server" Text="أستقطاع 6"></asp:Label>
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed15" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator30" runat="server" ControlToValidate="txtDed15"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
                            </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed15" MaxLength="50" Placeholder="ملاحظات" Width="120px" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd13" runat="server" Text="بدل 5"></asp:Label>
<<<<<<< HEAD
                           
=======
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd13" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="txtAdd13"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd13" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed07" runat="server" Visible="False" Text="أستقطاع 3"></asp:Label>
                           
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd13" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed07" runat="server" Visible="False" Text="أستقطاع 3"></asp:Label>
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed07" CssClass="form-control" runat="server" MaxLength="50" Visible="False" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator21" runat="server" Enabled="false" ControlToValidate="txtDed07"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                           </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed07" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd14" runat="server" Text="بدل 5"></asp:Label>
                             
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed07" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr7" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd14" runat="server" Text="بدل 5"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd14" CssClass="form-control" runat="server" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator29" runat="server" ControlToValidate="txtAdd14"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd14" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed08" runat="server" Text="أستقطاع 4" Visible="False"></asp:Label>
                            
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd14" MaxLength="50" Placeholder="ملاحظات" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed08" runat="server" Text="أستقطاع 4" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed08" CssClass="form-control" runat="server" Visible="False" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator22" runat="server" Enabled="False" ControlToValidate="txtDed08"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                             </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed08" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd09" runat="server" Text="بدل 5" Visible="False"></asp:Label>
                             
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed08" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr10" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd09" runat="server" Text="بدل 5" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd09" CssClass="form-control" runat="server" MaxLength="50" Visible="False" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator13" runat="server" Enabled="false" ControlToValidate="txtAdd09"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                              </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd09" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed05" runat="server" Text="أستقطاع 1" Visible="False"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd09" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed05" runat="server" Text="أستقطاع 1" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed05" CssClass="form-control" runat="server" Visible="False" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator20" runat="server" Enabled="false" ControlToValidate="txtDed05"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                           </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed05" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                            </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd10" runat="server" Text="بدل 5" Visible="False"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed05" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr11" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd10" runat="server" Text="بدل 5" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd10" CssClass="form-control" runat="server" Visible="False" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" Enabled="false" ControlToValidate="txtAdd10"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                               </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd10" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                              </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblDed06" runat="server" Text="أستقطاع 2" Visible="False"></asp:Label>
                             
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd10" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="lblDed06" runat="server" Text="أستقطاع 2" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtDed06" CssClass="form-control" runat="server" Visible="False" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Enabled="false" ControlToValidate="txtDed06"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                              </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsDed06" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblAdd11" runat="server" Text="بدل 5" Visible="False"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsDed06" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                            <tr id="tr14" align="right">
                                <td style="width: 120px;">
                                    <asp:Label ID="lblAdd11" runat="server" Text="بدل 5" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 120px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtAdd11" CssClass="form-control" runat="server" Visible="False" MaxLength="50" AutoPostBack="true"
                                        OnTextChanged="txtBasic_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator14" runat="server" Enabled="false" ControlToValidate="txtAdd11"
                                        Display="Dynamic" ErrorMessage="يجب أن تكون القيمة رقمية" ForeColor="Red" Type="Currency"
                                        ValidationGroup="1" SetFocusOnError="True" Operator="DataTypeCheck">*</asp:CompareValidator>
<<<<<<< HEAD
                              </div></div></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:TextBox ID="txtsAdd11" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblTAdd" runat="server" Text="اجمالي الاستحقاقات" Style="font-weight: 700"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtsAdd11" MaxLength="50" Placeholder="ملاحظات" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                </td>
                                <td style="width: 120px;">
                                </td>
                                <td style="width: 120px;">
                                </td>
                            </tr>

                            <tr id="tr8" align="right">
                                <td style="width: 120px;" class="mytd">
                                    <asp:Label ID="lblTAdd" runat="server" Text="اجمالي الاستحقاقات" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtTAdd" ReadOnly="true" BackColor="LightGray" CssClass="form-control" runat="server"
                                        MaxLength="50"></asp:TextBox>
                          </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblTDed" runat="server" Text="اجمالي الاستقطاعات" Style="font-weight: 700"></asp:Label>
<<<<<<< HEAD
                             
=======
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:TextBox ID="txtTDed" ReadOnly="true" BackColor="LightGray" CssClass="form-control" runat="server"
                                        MaxLength="50"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <asp:Label ID="lblNet" runat="server" Text="صافي المرتب" Style="font-weight: 700"></asp:Label>
<<<<<<< HEAD
                             
                                    <asp:TextBox ID="txtNet" ReadOnly="true" BackColor="LightGray" CssClass="form-control" runat="server"
                                        MaxLength="50"></asp:TextBox>
                               </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                     <asp:Label ID="lblDays" runat="server" Text="أيام العمل الفعلية"></asp:Label>
                               
=======
                                </td>
                                <td style="width: 120px;">
                                    <asp:TextBox ID="txtNet" ReadOnly="true" BackColor="LightGray" CssClass="form-control" runat="server"
                                        MaxLength="50"></asp:TextBox>
                                </td>
                                <td style="width: 120px;">
                                </td>
                                <td style="width: 120px;">
                                    <asp:Label ID="Label5" runat="server" Text="عدد الايام" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td style="width: 120px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:DropDownList ID="ddlNoDays" runat="server" AutoPostBack="True" CssClass="form-control"
                                        onselectedindexchanged="ddlNoDays_SelectedIndexChanged">
                                        <asp:ListItem Value="0">0</asp:ListItem>
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                        <asp:ListItem Value="4">4</asp:ListItem>
                                        <asp:ListItem Value="5">5</asp:ListItem>
                                        <asp:ListItem Value="6">6</asp:ListItem>
                                        <asp:ListItem Value="7">7</asp:ListItem>
                                        <asp:ListItem Value="8">8</asp:ListItem>
                                        <asp:ListItem Value="9">9</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="11">11</asp:ListItem>
                                        <asp:ListItem Value="12">12</asp:ListItem>
                                        <asp:ListItem Value="13">13</asp:ListItem>
                                        <asp:ListItem Value="14">14</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="16">16</asp:ListItem>
                                        <asp:ListItem Value="17">17</asp:ListItem>
                                        <asp:ListItem Value="18">18</asp:ListItem>
                                        <asp:ListItem Value="19">19</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="21">21</asp:ListItem>
                                        <asp:ListItem Value="22">22</asp:ListItem>
                                        <asp:ListItem Value="23">23</asp:ListItem>
                                        <asp:ListItem Value="24">24</asp:ListItem>
                                        <asp:ListItem Value="25">25</asp:ListItem>
                                        <asp:ListItem Value="26">26</asp:ListItem>
                                        <asp:ListItem Value="27">27</asp:ListItem>
                                        <asp:ListItem Value="28">28</asp:ListItem>
                                        <asp:ListItem Value="29">29</asp:ListItem>
                                        <asp:ListItem Value="30">30</asp:ListItem>
                                    </asp:DropDownList>
                               
                                   
                                </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label1" runat="server" Text="المستخدم"></asp:Label>
<<<<<<< HEAD
                         
=======
                            </td>
                            <td style="width: 300px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false"></asp:TextBox>
                           </div></div></div>
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                <asp:Label ID="Label3" runat="server" Text="بتاريخ"></asp:Label>
<<<<<<< HEAD
                       
=======
                            </td>
                            <td style="width: 300px">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                <asp:TextBox ID="txtUserDate" CssClass="form-control" runat="server" MaxLength="50" BackColor="#E8E8E8"
                                    Enabled="false">                                                               
                                </asp:TextBox> 
                                     <asp:Label ID="Label27" runat="server" Text="* حقول الزامية"></asp:Label>
                                </div></div></div>


                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="form-group">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
                                <asp:Label ID="LblCodesResult" runat="server" ForeColor="#FF0066"></asp:Label>
                            </div>
                        </div>

                                     <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                               
                         
                                
                   
                    <%-- *********************  *********************** --%>
<<<<<<< HEAD
                 
=======
                    <br />
               
                        <table id="Table2" dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                            <tr align="center">
                                <td style="width: 150px;">
                                    &nbsp;
                                </td>
                                <td style="width: 400px;">
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
                                    <asp:ImageButton ID="BtnNew" runat="server" AlternateText="جديد" CommandName="New"
                                        ImageUrl="~/images/data add.png" ToolTip="أضافة بيانات رواتب موظف"
                                        ValidationGroup="1" OnClientClick='return confirm("هل أنت متاكد من حفظ بيانات الموظف؟")'
                                        OnClick="BtnNew_Click" />
                                    <asp:ImageButton ID="BtnEdit" runat="server" AlternateText="تعديل" CommandName="Edit"
                                        ImageUrl="~/images/edit2.png" ToolTip="تعديل بيانات رواتب موظف"
                                        Width="64px" ValidationGroup="1" OnClick="BtnEdit_Click" />
                                    <asp:ImageButton ID="BtnClear" runat="server" AlternateText="مسح" CommandName="Clear"
                                        ImageUrl="~/images/clear all.png" ToolTip="مسح خانات الشاشة"
                                        OnClick="BtnClear_Click" />
                                    <asp:ImageButton ID="BtnDelete" runat="server" AlternateText="إلغاء" CommandName="Delete"
                                        ImageUrl="~/images/delete2.png" ToolTip="إلغاء بيانات رواتب موظف"
                                        OnClientClick='return confirm("هل أنت متاكد من الغاء بيانات رواتب الموظف؟")'
                                        OnClick="BtnDelete_Click" />
                                    <asp:ImageButton ID="BtnSearch" runat="server" AlternateText="بحث" CommandName="Find"
                                        ImageUrl="~/images/data search.png" ToolTip="البحث عن بيانات رواتب موظف" />
                                    <asp:ImageButton ID="BtnPrint" runat="server" AlternateText="طباعة" CommandName="Print"
                                        ImageUrl="~/images/print.png"   ToolTip="'طباعة بيانات راتب موظف"
                                        OnClick="BtnPrint_Click" OnClientClick="target ='blank';" />
<<<<<<< HEAD
                            </div></div></div>
=======
                                </td>
                                <td id="td1" runat="server" style="width: 200px; text-align: right">
                                    <br />
                                    &nbsp;
                                    </td>
                            </tr>
                        </table>
                  
                    <br />
                </center>
            </fieldset>
>>>>>>> f7d6e6644e253f5297713e7f0e965f9863598ce7
        </div>
 </div></div></div></div>
</asp:Content>
