<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmIPOIncentiveDashboardNew.aspx.cs" Inherits="UI_TSiPASS_frmIPOIncentiveDashboardNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">




    </script>


    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="#">Assistant Director / Deputy Director / IPO Dashboard</a>
                            </li>


                </ol>
            </div>

            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Assistant Director / Deputy Director / Inspection Officer Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">

                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">

                                                    <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small"
                                                                    NavigateUrl="~/UI/TSiPASS/frmIPOIncentiveDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">




                                                                    <a href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=1" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblAppl" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Assigned by GM
                                                                    </a>



                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection Scheduled</a>

                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=2"><span class="badge">
                                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days </a>

                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=3"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days </a>

                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection Not Yet Scheduled</a>

                                                                    <a href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=4" class="list-group-item">
                                                                        <span class="badge" >
                                                                            <asp:Label ID="lblApproved" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Within 3 Days
                                                                    </a>

                                                                    <a href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=5" class="list-group-item">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label2" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Beyond 3 Days
                                                                    </a>

                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection report uploaded</a>

                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=6"><span class="badge">
                                                                        <asp:Label ID="Label15" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>


                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=7"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="Label16" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond in 48 hrs </a>







                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;</td>
                                                            <td valign="top" style="width: 395px">

                                                                <div class="list-group">


                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection report Pending </a>

                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=8"><span class="badge">
                                                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>


                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=9"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond in 48 hrs </a>

                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Query Details</b></a>

                                                                      <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=16"><span class="badge">
                                                                        <asp:Label ID="lblAfrerInspection" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Total - Query Responded</a>

                                                                     <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=17"><span class="badge">
                                                                        <asp:Label ID="lblAfrerInspectionwithin" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</a>

                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=18"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="lblAfrerInspectionbeyond" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</a>

                                                                <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=15"><span class="badge">
                                                                        <asp:Label ID="lblAfrerInspectionawaiting" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>No of Applications Awaiting Query Response</a>

                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=10"><span class="badge">
                                                                        <asp:Label ID="Label18" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Recommended to GM </a>
                                                                      <a id="trRollbackGM" runat="server" visible="false" class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=121"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="lblRollbackedfromGM" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Rollbacked from GM</a>


                                                                   <%-- <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Query Details </a>
                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=11"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Raised</a>--%>

                                                                    <%--  <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                     
                                        <i class="fa fa-fw fa-check"></i> <b>Fund Released Stage</b>
                                    </a>
                                    
                                      <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label5" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Sanctioned Cases by GM
                                    </a>
                                              <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label2" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Sanctioned Incentives by GM
                                    </a>
                                    
                                     
                                           
                                         
                                           
                                             <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label21" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Inspection scheduled </a>
                                                
                                                  <a href="IncentiveStatusDetails.aspx?Stg=1" class="list-group-item">
                                        <span class="badge" style=" background-color:#d9534f;">
                                            <asp:Label ID="Label20" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i>Inspection not yet scheduled
                                    </a>
                                                
                                                <a class="list-group-item"> <i class="fa fa-fw fa-check"></i>Inspection report uploaded </a>
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label23" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>
                                                
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label24" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond in 48 hrs </a>
                                                
                                                <a class="list-group-item" ><i class="fa fa-fw fa-check"></i>Inspection report Pending</a>
                                                
                                                   <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label26" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>
                                                
                                                
                                                <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label27" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond in 48 hrs </a>
                                                
                                                
                                                 
                                                
                                                  <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label29" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Recommanded Incentives for Fund Released to GM </a>
                                                
                                                
                                                   <a class="list-group-item" href="IncentiveStatusDetails.aspx?Stg=1"><span class="badge" >
                                                <asp:Label ID="Label30" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Recommanded Incentives for Fund Released to GM</a>--%>
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
                                                    <td style="width: 417px; display:none">
                                                        <a href="IPO Login.doc" target="_blank">User Manual of IPO/DD/AD</a>  </td>
                                        </td>
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

