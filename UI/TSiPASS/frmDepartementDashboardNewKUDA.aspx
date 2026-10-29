<%@ Page Title=":: TSiPASS : Works wise Report " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDepartementDashboardNewKUDA.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript">




    </script>
    

    <asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx">Dashboard</a>
                            </li>
                            
                           
                        </ol>
     </div>
    
<div align="center">
<div class="row" align="center">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Department Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            
                                            <div class="panel panel-default">
                            <div class="panel-body" align="center">
                            
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;" >
                                            <b>Consent for Establishment</b></td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td valign="top" style="width: 395px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            &nbsp;</td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td style="width: 395px" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <b>KUDA Dashboard</b></td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td style="width: 395px" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px" valign="top">
                                             <div class="list-group">
                                             
                                               <a href="#" class="list-group-item">
                                        
                                        <i class="fa fa-fw fa-check"></i> <b>Pre-Scrutiny Stage </b>
                                    </a>
                                           
                                            
                                              <a href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=1" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label4" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> No of Application Received
                                    </a>
                                            
                                              <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i> <b>Pre-Scrutiny-Completed</b> </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=2"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label12" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Within 3 Days</a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=3"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label18" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=4"><span class="badge">
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Total </a>
                                                
                                                <a class="list-group-item" href="#">
                                             <i class="fa fa-fw fa-check"></i> <b>Pre-Scrutiny-Pending</b> </a>
                                                
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=5"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label21" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=6"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label22" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                             
                                               <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=7"><span class="badge" >
                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Total </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=8">
                                                <span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label8" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Applications Awaiting Query Response</a>
                                               
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=12"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Approvals Awaiting Payment </a>
                                                
                                                
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td valign="top" style="width: 395px">
                                        
                                          <div class="list-group">
                                            
                                             
                                            
                                              <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Stages</b></a>
                                              
                                              
                                                  <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Under Process</b></a>
                                              
                                                <a class="list-group-item" href="frmCFEDepartmentsApprovalProcessKUDA.aspx?stg=1&lbl=Approval Under Process Within Time Limits"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Within Time Limits </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsApprovalProcessKUDA.aspx?stg=2&lbl=Approval Under Process Beyond Time Limits"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Beyond Time Limits</a>
                                                
                                                
                                                
                                                   <a class="list-group-item" href="#"><span class="badge">
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Total</a>
                                                
                                                 
                                                
                                               <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b> Approval Issued</b></a>
                                               
                                             
                                                
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=13"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Within Time Limits </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=14"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Beyond Time Limits</a>
                                                
                                                   <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=15"><span class="badge">
                                                <asp:Label ID="Label10" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Total</a>
                                               
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=16"><span class="badge">
                                                <asp:Label ID="Label17" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Applications Rejected </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA.aspx?Stg=17"><span class="badge">
                                                <asp:Label ID="Label13" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Applications appeal against Rejection </a>
                                                
                                               
                                            </div>
                                                  
                                        </td>
                                    </tr>
                                    
                                    
                                    
                                    
                                    <tr>
                                        <td style="width: 395px">
                                            &nbsp;</td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    
                                     <tr id="lld" runat="server" visible="false">
                                        <td style="width: 395px; font-size: 16px;">
                                            <b>Building Application</b></td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td style="width: 395px" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr id="newss" runat="server" visible="false">
                                        <td style="width: 395px" valign="top">
                                             <div class="list-group">
                                             
                                               <a href="#" class="list-group-item">
                                        
                                        <i class="fa fa-fw fa-check"></i> <b>Pre-Scrutiny Stage </b>
                                    </a>
                                           
                                            
                                              <a href="frmCFEDepartmentsViewApplKUDA2.aspx" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label14" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> No of Application Received
                                    </a>
                                            
                                              <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i> <b>Pre-Scrutiny-Completed</b> </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=2"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label15" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Within 3 Days</a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=3"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label16" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=4"><span class="badge">
                                                <asp:Label ID="Label19" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Total </a>
                                                
                                                <a class="list-group-item" href="#">
                                             <i class="fa fa-fw fa-check"></i> <b>Pre-Scrutiny-Pending</b> </a>
                                                
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=5"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label20" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=6"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label23" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                             
                                               <a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=7"><span class="badge" >
                                                <asp:Label ID="Label24" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Total </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=8">
                                                <span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label25" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Applications Awaiting Query Response</a>
                                               
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=12"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label26" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Approvals Awaiting Payment </a>
                                                
                                                
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td valign="top" style="width: 395px">
                                        
                                          <div class="list-group">
                                            
                                             
                                            
                                              <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Stages</b></a>
                                              
                                              
                                                  <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Under Process</b></a>
                                              
                                                <a class="list-group-item" href="frmCFEDepartmentsApprovalProcessHmda2.aspx?stg=1&lbl=Approval Under Process Within Time Limits"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label27" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Within Time Limits </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsApprovalProcessHmda2.aspx?stg=2&lbl=Approval Under Process Beyond Time Limits"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label28" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Beyond Time Limits</a>
                                                
                                                
                                                   <a class="list-group-item" href="#"><span class="badge">
                                                <asp:Label ID="Label29" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Total</a>
                                                
                                                 
                                                
                                               <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b> Approval Issued</b></a>
                                               
                                             
                                                
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=13"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label30" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Within Time Limits </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=14"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label31" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Beyond Time Limits</a>
                                                
                                                   <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=15"><span class="badge">
                                                <asp:Label ID="Label32" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Total</a>
                                               
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=16"><span class="badge">
                                                <asp:Label ID="Label33" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Applications Rejected </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplKUDA2.aspx?Stg=17"><span class="badge">
                                                <asp:Label ID="Label34" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Applications appeal against Rejection </a>
                                                
                                               
                                            </div>
                                                  
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;
                                <div class="text-right">
                                    <a href="#">View All Activity <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                                            
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <table cellpadding="2" style="width: 100%">
                                                <tr>
                                                    <td style="width: 417px">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            <asp:GridView ID="grdDetails" runat="server" 
                                                AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" 
                                                ForeColor="#333333" Height="62px" PageSize="15" Width="100%" 
                                                Visible="False">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No" 
                                                                Visible="True">
                                                                    <ItemTemplate >
                                                                        <%# Container.DataItemIndex +1 %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                    <asp:BoundField DataField="IPName" HeaderText="IP Name" />
                                                    <asp:BoundField DataField="TotalWorkProposed" HeaderText="Total Works Proposed" />
                                                    <asp:BoundField DataField="TotalApproved" HeaderText="Total Approved" />
                                                    <asp:BoundField DataField="TotalInProgress" HeaderText="Total InProgress" />
                                                    <asp:BoundField DataField="TotalCompleted" HeaderText="Total Completed" />
                                                    
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

    </div>
              
                 
          <br />
          <br />
          <br />
          
                       
  </ContentTemplate>
  </asp:UpdatePanel>
 <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

