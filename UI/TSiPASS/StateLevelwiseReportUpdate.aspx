<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="StateLevelwiseReportUpdate.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
   function GetRowValue(val)
    {   
    if(val != '&nbsp;')
    {   
    val1 = 0;
    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

    }
    window.opener.document.forms[0].submit();
    self.close();
   
    }
    
    </script>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            State level Report<a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="left" style="text-align: left; height: 47px; width: 263px;" valign="middle">
                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">District</asp:Label>
                                            </td>
                                            <td style="height: 47px">
                                                :
                                            </td>
                                            <td style="height: 47px; width: 232px;">
                                                <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>ADILABAD</asp:ListItem>
                                                    <asp:ListItem>HYDERABAD</asp:ListItem>
                                                    <asp:ListItem>KARIMNAGAR</asp:ListItem>
                                                    <asp:ListItem>KHAMMAM</asp:ListItem>
                                                    <asp:ListItem>MAHABOOBNAGAR</asp:ListItem>
                                                    <asp:ListItem>MEDAK</asp:ListItem>
                                                    <asp:ListItem>NALGONDA</asp:ListItem>
                                                    <asp:ListItem>NIZAMABAD</asp:ListItem>
                                                    <asp:ListItem>RANGA REDDY</asp:ListItem>
                                                    <asp:ListItem>WARANGAL</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 47px">
                                                &nbsp; &nbsp;
                                            </td>
                                            <td style="height: 47px">
                                                &nbsp;
                                            </td>
                                            <td style="height: 47px">
                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px">Unit name</asp:Label>
                                            </td>
                                            <td style="height: 47px">
                                                :
                                            </td>
                                            <td style="height: 47px">
                                                <asp:TextBox ID="txtUnitname" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="80" TabIndex="2" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="height: 47px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 40px; width: 263px">
                                                <asp:Label ID="Label453" runat="server" CssClass="LBLBLACK" Width="200px">Applcation From Date </asp:Label>
                                            </td>
                                            <td style="height: 40px">
                                                :
                                            </td>
                                            <td style="height: 40px; width: 232px;">
                                                <asp:TextBox ID="txtFromdate" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromdate"
                                                    PopupButtonID="txtFromdate">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td style="height: 40px">
                                            </td>
                                            <td style="height: 40px">
                                                &nbsp;
                                            </td>
                                            <td style="height: 40px">
                                                <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="200px">Application To Date</asp:Label>
                                            </td>
                                            <td style="height: 40px">
                                                :
                                            </td>
                                            <td style="height: 40px">
                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtTodate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                    TargetControlID="txtTodate" PopupButtonID="txtTodate">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td style="height: 40px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave1_Click" TabIndex="10" Text="Search" ValidationGroup="group"
                                        Width="90px" />
                                    &nbsp;
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="90px"
                                        OnClick="BtnClear_Click" />
                                </td>
                            </tr>
                             <tr>
                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                <b>Note : DIC has to upload Undertaking form from the unit holder, describe that they have dropped the project</b>
                                </td>
                                </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                         Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging" PageSize="40"
                                        ShowFooter="True" OnRowCreated="grdDetails_RowCreated" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged"
                                        AllowPaging="true">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                            <asp:TemplateField HeaderText="UID No">
                                                <ItemTemplate>
                                                  <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" NavigateUrl='<%# Eval("intCFEEnterpidnew", "ViewCFEPrint.aspx?Id={0}") %>' Text='<%# Eval("UID_No") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Mno" HeaderText="Mobile Number" />
                                            <%--<asp:BoundField DataField="Address" HeaderText="Address" />--%>
                                            <asp:BoundField DataField="lineofActivity" HeaderText="line of Activity" />
                                            <asp:BoundField DataField="District" HeaderText="District" />
                                            <%--<asp:BoundField DataField="Sector" HeaderText="Sector" />--%>
                                            <asp:BoundField DataField="Investment" HeaderText="Investment(Rs. in Crs)" />
                                            <asp:BoundField DataField="NoofEmployee" HeaderText="No of Employee" />
                                            <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" />
                                            <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" />
                                            <asp:BoundField DataField="Progress" HeaderText="Progress" />
                                            <%--<asp:BoundField DataField="Status" HeaderText="Status" />--%>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                        <tr>
                                                            <td style="width: 132px; height: 29px">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" Width="120px" CssClass="DROPDOWN"
                                                                    AutoPostBack="True">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>COMMENCED OPERATIONS</asp:ListItem>
                                                                    <asp:ListItem>YET TO START CONSTRUCTION</asp:ListItem>
                                                                    <asp:ListItem>ADVANCED STAGE</asp:ListItem>
                                                                    <asp:ListItem>INITIAL STAGE</asp:ListItem>
                                                                    <asp:ListItem>DROPPED</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                            <td style="width: 132px; height: 29px">
                                                            <b>Remarks For Status Change :</b>
                                                               <asp:TextBox ID="txtreasonschange" TextMode="MultiLine" Height="80px" Width="180px" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                            <td>
                                                                Upload Document
                                                                 <div style="float: left">
                                                                    <asp:FileUpload ID="fluPrincipalEmployersRegistrationCertificate" Width="220px" runat="server" Height="28px" />
                                                                    <asp:Label ForeColor="Blue" runat="server" ID="Label6new"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Button ID="BtnSaveg" runat="server" CssClass="BUTTON" Height="20px" TabIndex="10"
                                                                    Text="Submit" ValidationGroup="group" Width="61px" OnClick="BtnSaveg_Click" />
                                                                <asp:HiddenField ID="HdfintApplicationid" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#B9D684" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="lblresult" runat="server" CssClass="LBLBLACK" Width="200px"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="GridExport" runat="server" AutoGenerateColumns="False" >
                                        
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:BoundField DataField="lineofActivity" HeaderText="line of Activity" />
                                            <asp:BoundField DataField="District" HeaderText="District" />
                                            <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                            <asp:BoundField DataField="Investment" HeaderText="Investment(Rs. in Crs)" />
                                            <asp:BoundField DataField="NoofEmployee" HeaderText="No of Employee" />
                                            <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" />
                                            <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" />
                                            <asp:BoundField DataField="Progress" HeaderText="Progress" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                           
                                        </Columns>
                                        
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
