<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveStatusUpdate.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>



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
                            Incentive Status Update </h3>
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
                                            <td align="left" style="text-align:left; height: 47px; width: 263px;" 
                                                valign="middle">
                                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" 
                                                    Width="200px">District</asp:Label>
                                                            </td>
                                            <td style="height: 47px">
                                                :</td>
                                            <td style="height: 47px; width: 232px;">
                                                                <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" TabIndex="1">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>ADILABAD</asp:ListItem>
                                                                    <asp:ListItem>HYDERABAD</asp:ListItem>
                                                                    <asp:ListItem>KARIMNAGAR</asp:ListItem>
                                                                    <asp:ListItem>KHAMMAM</asp:ListItem>
                                                                    <asp:ListItem>MAHBUBNAGAR</asp:ListItem>
                                                                    <asp:ListItem>MEDAK</asp:ListItem>
                                                                    <asp:ListItem>NALGONDA</asp:ListItem>
                                                                    <asp:ListItem>NIZAMABAD</asp:ListItem>
                                                                    <asp:ListItem>RANGAREDDY1</asp:ListItem>
                                                                    <asp:ListItem>RANGAREDDY 2</asp:ListItem>
                                                                    <asp:ListItem>WARANGAL</asp:ListItem>
                                                                    
                                                                </asp:DropDownList>
                                                            </td>
                                            <td style="height: 47px">
                                                            &nbsp; &nbsp;</td>
                                            <td style="height: 47px">
                                                            &nbsp;</td>
                                            <td style="height: 47px">
                                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" 
                                                    Width="200px">EntrePriseName</asp:Label>
                                                            </td>
                                            <td style="height: 47px">
                                                                :</td>
                                            <td style="height: 47px">
                                                                <asp:TextBox ID="txtEname" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="80" TabIndex="2" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                            </td>
                                            <td style="height: 47px">
                                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 40px; width: 263px">
                                                                <asp:Label ID="Label453" runat="server" CssClass="LBLBLACK" 
                                                    Width="200px">Status</asp:Label>
                                                            </td>
                                            <td style="height: 40px">
                                                :</td>
                                            <td style="height: 40px; width: 232px;">
                                                                
                                                            
                                                    
                                                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" TabIndex="1">
                                                                    <asp:ListItem >--Select--</asp:ListItem>
                                                                    <asp:ListItem >Assigned to IPO</asp:ListItem>
                                                                    <asp:ListItem >Inspection Completed</asp:ListItem>
                                                                    <asp:ListItem >Inspection Report Submited</asp:ListItem>
                                                                    <asp:ListItem >Gm Certificate Uploaded</asp:ListItem>
                                                                    <asp:ListItem >Recommended to DIPC/COI</asp:ListItem>
                                                                    <asp:ListItem >Rejected</asp:ListItem>
                                                                    <asp:ListItem >Received</asp:ListItem>
                                                                    <asp:ListItem >Received from Meeseva</asp:ListItem>
                                                                    <asp:ListItem >Pre-Scrutiny Completed</asp:ListItem>
                                                                    <asp:ListItem >Query Raised</asp:ListItem>
                                                                    <asp:ListItem >Inspection Completed</asp:ListItem>
                                                                   
                                                                </asp:DropDownList>
                                                                
                                                            
                                                    
                                                                </td>
                                            <td style="height: 40px">
                                                </td>
                                            <td style="height: 40px">
                                                &nbsp;</td>
                                            <td style="height: 40px">
                                                                <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" 
                                                    Width="200px">ApplNo</asp:Label>
                                                            </td>
                                            <td style="height: 40px">
                                                :</td>
                                            <td style="height: 40px">
                                                        <asp:TextBox ID="txtApplno" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40"  TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            
                                                                </td>
                                            <td style="height: 40px">
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
                                <asp:Panel ID="panelnew" runat="server" Width="1000px" Height="600px" ScrollBars="Both" >
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
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                   <ItemTemplate  >
                                                                       <%# Container.DataItemIndex +1 %>
                                                                   </ItemTemplate>
                                                                   <HeaderStyle HorizontalAlign="Center" />
                                                                   <ItemStyle Width="20px" />
                                                                      </asp:TemplateField>
                                               <asp:BoundField DataField="ApplNo" HeaderText="Appl No" />
                                               <asp:BoundField DataField="Applicantname" HeaderText="Applicantname" />
                                               <asp:BoundField DataField="EntrePriseName" HeaderText="EntrePrise Name" />
                                               <asp:BoundField DataField="Mandal" HeaderText="Mandal" />
                                             
                                               <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                               <asp:BoundField DataField="Category" HeaderText="Category" />
                                               <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date"  DataFormatString="{0:dd/MM/yyyy}"  />
    <asp:BoundField DataField="DateofCommencement" HeaderText="Date of Commencement"  DataFormatString="{0:dd/MM/yyyy}"  />
                                               <asp:BoundField DataField="CapacityDesc" HeaderText="Capacity Desc"  />
                                               <asp:BoundField DataField="SocialStatus" HeaderText="Social Status" />
                                               
                                               <asp:BoundField DataField="natureofEntreprise" HeaderText="Nature of Entreprise"  />
                                               <asp:BoundField DataField="NoOfEmployees" HeaderText="No Of Employees" />
                                               <asp:BoundField DataField="TypeofEnterprise" HeaderText="Type of Enterprise"  />
                                               <asp:BoundField DataField="IncentiveAppliedfor" HeaderText="IncentiveAppliedfor" />
                                               
                                               
                                                <asp:BoundField DataField="LocationofEnterprise" HeaderText="Location of Enterprise"  />
                                               <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                               <asp:BoundField DataField="District" HeaderText="District"  />
                                               <asp:BoundField DataField="IncentiveAppliedfor" HeaderText="IncentiveAppliedfor" />
                                                 <asp:BoundField DataField="Status" HeaderText="Status" />
                                                <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                 <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                                 <tr>
                                                                 <td style="width: 132px; height: 29px">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" Width="120px" 
                                                                    CssClass="DROPDOWN" AutoPostBack="True" >
                                                                    <asp:ListItem >--Select--</asp:ListItem>
                                                                    <asp:ListItem >Assigned to IPO</asp:ListItem>
                                                                    <asp:ListItem >Inspection Completed</asp:ListItem>
                                                                    <asp:ListItem >Inspection Report Submited</asp:ListItem>
                                                                    <asp:ListItem >Gm Certificate Uploaded</asp:ListItem>
                                                                    <asp:ListItem >Recommended to DIPC/COI</asp:ListItem>
                                                                    <asp:ListItem >Rejected</asp:ListItem>                                                                                                                                       <asp:ListItem >Received from Meeseva</asp:ListItem>
                                                                    <asp:ListItem >Pre-Scrutiny Completed</asp:ListItem>
                                                                    <asp:ListItem >Query Raised</asp:ListItem>
                                                                    
                                                                    
                                                                    
                                                                    
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
                                    </asp:Panel>
                                    <br />
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


