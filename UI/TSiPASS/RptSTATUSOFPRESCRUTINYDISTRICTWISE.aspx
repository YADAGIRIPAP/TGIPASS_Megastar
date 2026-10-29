<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="RptSTATUSOFPRESCRUTINYDISTRICTWISE.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

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
                            R3.1 : TS-iPASS APPROVALS - DISTRICT WISE</h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                            <tr>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">
                <table width="20%">
                    <tr>
                        <td style="width: 22%; padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                            vertical-align: top; padding-top: 5px; text-align: left;" __designer:mapid="133"
                            align="right">
                            <asp:Label ID="lblSector0" runat="server" CssClass="LBLBLACK" Text="Category"
                                Width="110px" Height="16px"></asp:Label>
                        </td>
                        <td width="20%" style="width: 3%; padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                            vertical-align: top; padding-top: 5px; text-align: left;" __designer:mapid="135"
                            align="left">
                            <asp:Label ID="Label91" runat="server" CssClass="LBLBLACK" Text=":"></asp:Label>
                        </td>
                        <td align="left" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                            vertical-align: top; width: 22%; padding-top: 5px; text-align: left">
                                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">MEGA</asp:ListItem>
                                                            <asp:ListItem Value="2">LARGE</asp:ListItem>
                                                            <asp:ListItem  Value="3" >MEDIUM</asp:ListItem>
                                                             <asp:ListItem Value="4">SMALL</asp:ListItem>
                                                            <asp:ListItem  Value="5" >MICRO</asp:ListItem>
                                                        </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" 
                                        Font-Size="13px" ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" 
                                    style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                        Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Search" 
                                        Width="90px" />
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                        CssClass="btn btn-warning" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" ForeColor="#333333" 
                                        GridLines="Both" Height="62px" 
                                        onpageindexchanging="grdDetails_PageIndexChanging" 
                                        onrowdatabound="grdDetails_RowDataBound" PageSize="15" Width="100%" 
                                        onrowcreated="grdDetails_RowCreated" ShowFooter="True">
                                        <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                        <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                            verticalalign="Middle" />
                                        <columns>
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                   <ItemTemplate  >
                                                                       <%# Container.DataItemIndex +1 %>
                                                                   </ItemTemplate>
                                                                   <HeaderStyle HorizontalAlign="Center" />
                                                                   <ItemStyle Width="20px" />
                                                                      </asp:TemplateField>
                                                                       <asp:BoundField  HeaderText="District Name"  DataField="DistrictName" />
                                             
                                               <asp:HyperLinkField HeaderText="Applications fully paid" DataTextField="NumberOfApplicationsFullyPaid" />
                                               <asp:HyperLinkField HeaderText="Completed" DataTextField="Approved" />
                                               <asp:HyperLinkField HeaderText="Under Process" DataTextField="UnderProcess" />
                                               <asp:HyperLinkField HeaderText="Rejected" DataTextField="Rejected" />
                                               
                                                <asp:BoundField  HeaderText="Average number of days taken for processing"  DataField="AverageNumberOfDaysTakenForProcessing" />
                                              
                                        </columns>
                                        <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                        <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                        <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                            forecolor="White" BorderWidth="1px" BorderStyle="Solid" />
                                        <editrowstyle backcolor="#B9D684" />
                                        <alternatingrowstyle backcolor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>

