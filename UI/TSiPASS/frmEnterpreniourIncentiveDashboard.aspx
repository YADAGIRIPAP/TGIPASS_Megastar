<%@ Page Title=":: TSiPASS : Works wise Report " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmEnterpreniourIncentiveDashboard.aspx.cs" Inherits="Dashboard" %>

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
                                <h3 class="panel-title">Incentive Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            
                                            <div class="panel panel-default">
                            <div class="panel-body" align="center">
                            
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="font-size: 16px; text-align: center;" colspan="3" >
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" 
                                                NavigateUrl="~/UI/TSiPASS/frmDepartementIncentiveDashboard.aspx">Back</asp:HyperLink>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="width: 395px" valign="top">
                                             <div class="list-group">
                                          
                                           
                                            
                                             <a  class="list-group-item">
                                      
                                        <i class="fa fa-fw fa-check"></i> <b>Incentive (Application Stage)</b>
                                    </a>
                                              <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="lblAppl" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Applications Applied
                                    </a>
                                    
                                     <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=2"><span class="badge">
                                                <asp:Label ID="lblPending" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Incentives Applied</a>
                                           
                                           <a href="IncentiveStatusDetails.aspx?Stg=3" class="list-group-item">
                                        <span class="badge"  style=" background-color:#d9534f;">
                                            <asp:Label ID="lblApproved" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Yet to be assigned
                                    </a>
                                    <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=4"><span class="badge" >
                                                <asp:Label ID="Label8" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Inspection scheduled Incentives </a>
                                              
                                                
                                                   <a class="list-group-item" href="CommIncentiveStatusDetails.aspx?Stg=5"><span class="badge" >
                                                <asp:Label ID="Label15" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Listed Shortfalls</a>
                                                
                                                
                                                <a class="list-group-item" href="CommIncentiveStatusDetails.aspx?Stg=6"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label16" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Inspection Incentives report uploaded </a>
                                                
                                                
                                             
                                                
                                            
                                                
                                                
                                                
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td valign="top" style="width: 395px">
                                        
                                        <div class="list-group">
                                          
                                          
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=7"><span class="badge" >
                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Inspection Incentives report not uploaded </a>
                                                
                                                
                                             
                                            
                                                  <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=9"><span class="badge" >
                                                <asp:Label ID="Label17" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>GM certificate uploaded </a>
                                                
                                            
                                                
                                                  <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=10"><span class="badge" >
                                                <asp:Label ID="Label18" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Recommanded to DIPC/COI </a>
                                                
                                                 
                                                
                                             
                                            
                                             <a class="list-group-item">
                                     
                                        <i class="fa fa-fw fa-check"></i> <b>Fund Released Stage</b>
                                    </a>
                                    
                                      <a href="IncentiveStatusDetails.aspx?Stg=12" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label5" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Sanctioned Incentives
                                    </a>
                                              <a href="IncentiveStatusDetails.aspx?Stg=13" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label2" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Certificate Generated
                                    </a>
                                    
                                    
                                    
                                    <%-- <a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Assigned Incentives to inspecting officer</a>
                                                
                                                 <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge" style=" background-color:#d9534f;">
                                            <asp:Label ID="Label4" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Yet to be assigned Appl
                                    </a>
                                           
                                           <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge" style=" background-color:#d9534f;">
                                            <asp:Label ID="Label20" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Yet to be assigned Incentives
                                    </a>
                                           
                                             <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label21" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Inspection scheduled </a>
                                                
                                                <a class="list-group-item"> <i class="fa fa-fw fa-check"></i>Inspection report uploaded </a>
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label23" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>
                                                
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label24" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond in 48 hrs </a>
                                                
                                                <a class="list-group-item" ><i class="fa fa-fw fa-check"></i>Inspection report not uploaded</a>
                                                
                                                   <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label26" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>
                                                
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label27" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond in 48 hrs </a>
                                                
                                                
                                                  <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label28" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>GM certificate attached </a>
                                                
                                                  <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label29" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Recommanded Incentives for Fund Released to DIPC </a>
                                                
                                                
                                                   <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label30" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Recommanded Incentives for Fund Released to COI</a>--%>
                                                
                                            </div>
                                                  
                                        </td>
                                    </tr>
                                  
                                </table>
                               
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

