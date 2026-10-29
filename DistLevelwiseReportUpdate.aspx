<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DistLevelwiseReportUpdate.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                          District level Report </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" 
                                        Font-Size="13px" ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" style="text-align:right" valign="middle">
                                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" 
                                                    Width="200px">District</asp:Label>
                                                            </td>
                                            <td>
                                                :</td>
                                            <td>
                                                                <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" TabIndex="1">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                   
                                                                    
                                                                </asp:DropDownList>
                                                            </td>
                                            <td>
                                                                &nbsp;&nbsp; &nbsp;</td>
                                            <td>
                                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" 
                                                    Width="200px">Unit name</asp:Label>
                                                            </td>
                                            <td>
                                                                &nbsp;</td>
                                            <td>
                                                                <asp:TextBox ID="txtUnitname" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="80" TabIndex="2" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                            </td>
                                            <td>
                                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="center">
                                    <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" Font-Names="verdana" 
                                        Font-Size="13px" ForeColor="#006600"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" 
                                        CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave1_Click" TabIndex="10" Text="Search" ValidationGroup="group" 
                                                        Width="90px" />
                                                    &nbsp; 
                                                    <asp:Button ID="BtnClear" runat="server" 
                                        CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                                        Width="90px" onclick="BtnClear_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" 
                                        AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" 
                                        ForeColor="#333333" Height="62px" 
                                        onrowdatabound="grdDetails_RowDataBound" PageSize="40" Width="100%" 
                                        onpageindexchanging="grdDetails_PageIndexChanging" ShowFooter="True" 
                                        onrowcreated="grdDetails_RowCreated" 
                                        onselectedindexchanged="grdDetails_SelectedIndexChanged" 
                                        AllowPaging="True">
                                        <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                        <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                            verticalalign="Middle" />
                                        <columns> 
                                               <asp:BoundField DataField="SLNo" HeaderText="SLNo" />
                                               <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                               <asp:BoundField DataField="Address" HeaderText="Address" />
                                               <asp:BoundField DataField="lineofActivity" HeaderText="line of Activity" />
                                               <asp:BoundField DataField="District" HeaderText="District" />
                                               <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                               <asp:BoundField DataField="Investment" HeaderText="Investment(crs)" />
                                               <asp:BoundField DataField="NoofEmployee" HeaderText="No of Employee" />
                                               <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date"   />
                                               <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date"   />
                                               <asp:BoundField DataField="Progress" HeaderText="Progress" />
                                               <asp:BoundField DataField="Status" HeaderText="Status" />
                                                 <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                 <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                                 <tr>
                                                                 <td style="width: 132px; height: 29px">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" Width="120px" 
                                                                    CssClass="DROPDOWN" AutoPostBack="True" >
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                     <asp:ListItem>COMMENCED OPERATIONS</asp:ListItem>
                                                                      <asp:ListItem>ADVANCED STAGE</asp:ListItem>
                                                                       <asp:ListItem>TRIAL PRODUCATION</asp:ListItem>
                                                                        <asp:ListItem>INITITAL STAGE</asp:ListItem>
                                                                         <asp:ListItem>YET TO COMMENCE </asp:ListItem>
                                                                       <asp:ListItem>CONSRUCTION</asp:ListItem>
                                                                </asp:DropDownList>
                                                                </td>
                                                                </tr>
                                                                 <tr>
                                                            <td colspan="4" align="center">
                                                                 <asp:Button ID="BtnSaveg" runat="server" CssClass="BUTTON" Height="20px" 
                                                                                     TabIndex="10" Text="Submit" ValidationGroup="group" 
                                                                                    Width="61px" onclick="BtnSaveg_Click" />
                                                                                <asp:HiddenField ID="HdfintApplicationid" runat="server" /></td>
                                                        </tr>
                                                        </table>
                                                                  
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                              
                                        </columns>
                                        <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                        <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                        <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                            forecolor="White" />
                                        <editrowstyle backcolor="#B9D684" />
                                        <alternatingrowstyle backcolor="White" />
                                    </asp:GridView>
                                                                <asp:Label ID="lblresult" runat="server" CssClass="LBLBLACK" 
                                                    Width="200px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>

