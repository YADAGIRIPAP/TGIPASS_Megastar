<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDepartementIncentiveDashboardNew.aspx.cs" Inherits="UI_TSiPASS_frmDepartementIncentiveDashboardNew" %>


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
                                <i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a>
                            </li>


                </ol>
            </div>

            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
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
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small"
                                                                    NavigateUrl="~/UI/TSiPASS/frmDepartementIncentiveDashboardNew.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">



                                                                    <a class="list-group-item">

                                                                        <i class="fa fa-fw fa-check"></i><b>Incentive (Application Stage)</b>
                                                                    </a>
                                                                    <a href="IncentiveStatusDetailsNew.aspx?Stg=1" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblAppl" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Applications received
                                                                    </a>

                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=2"><span class="badge">
                                                                        <asp:Label ID="lblPending" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Assigned to inspecting officer</a>

                                                                    <a href="IncentiveStatusDetailsNew.aspx?Stg=3" class="list-group-item">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lblApproved" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Yet to be assigned
                                                                    </a>

                                                                    <a href="IncentiveStatusDetailsNew.aspx?Stg=99" class="list-group-item">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lblAssigned" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total assigned
                                                                    </a>

                                                                    <a href="IncentiveDeptUploadCertficateDetails.aspx?Stg=17" class="list-group-item">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="LblReptiveApplications" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Repetitive Applications
                                                                    </a>
                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=4"><span class="badge">
                                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Inspection scheduled </a>
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection report uploaded</a>

                                                                    <a class="list-group-item" href="IncentiveDeptUploadCertficateDetails.aspx?Stg=5"><span class="badge">
                                                                        <asp:Label ID="Label15" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>


                                                                    <a class="list-group-item" href="IncentiveDeptUploadCertficateDetails.aspx?Stg=6"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="Label16" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond 48 hrs </a>








                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;</td>
                                                            <td valign="top" style="width: 395px">

                                                                <div class="list-group">

                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection report not uploaded </a>

                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=7"><span class="badge">
                                                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>


                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=8"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond 48 hrs </a>


                                                                    <a class="list-group-item" href="IncentiveStatusDetailsNew.aspx?Stg=9"><span class="badge">
                                                                        <asp:Label ID="Label17" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>GM certificate uploaded </a>



                                                                    <a class="list-group-item" href="CommissionerIncentiveUpdation.aspx?Stg=10"><span class="badge">
                                                                        <asp:Label ID="Label18" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Recommanded to DIPC </a>



                                                                    <a class="list-group-item" href="CommissionerIncentiveUpdation.aspx?Stg=11"><span class="badge">
                                                                        <asp:Label ID="Label19" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Recommanded to COI </a>

                                                                    <a class="list-group-item">

                                                                        <i class="fa fa-fw fa-check"></i><b>Fund Released Stage</b>
                                                                    </a>

                                                                    <a href="#" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label5" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Sanctioned Cases
                                                                    </a>
                                                                    <a href="#" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label2" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Sanctioned Incentives
                                                                    </a>

                                                                    <a href="IncentiveStatusDetailsRejected.aspx?Stg=16" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label1" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>GM Rejected Incentives
                                                                    </a>

                                                                    <a href="IncentiveNotHavePowerDetails.aspx?Stg=20" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label3" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Not having Power Connection Applications
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
                                                    <br />

                                                    <table runat="server" id="trGmDashboard" cellpadding="3" cellspacing="5" style="width: 100%">


                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>GM Inspection Process</b>
                                                                </a>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;</td>
                                                            <td valign="top" style="width: 395px">&nbsp;</td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=1">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Assigned to GM</a>
                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=3">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label4" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Inspection yet to be scheduled </a>
                                                                    <a class="list-group-item" href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=4">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label10" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Inspection scheduled </a>
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection report 
                                                 uploaded</a> <a class="list-group-item"
                                                     href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=4"><span class="badge">
                                                         <asp:Label ID="Label13" runat="server"></asp:Label>
                                                     </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>
                                                                    <a class="list-group-item"
                                                                        href="IncentiveStatusInspectionDateDetailsNew.aspx?Stg=5"><span class="badge"
                                                                            style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label14" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 48 hrs </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;</td>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i>Inspection report 
                                                 not uploaded </a><a class="list-group-item"
                                                     href="IncentiveStatusInspectionUploadDetailsNew.aspx?Stg=6"><span class="badge">
                                                         <asp:Label ID="Label20" runat="server"></asp:Label>
                                                     </span><i class="fa fa-fw fa-calendar"></i>With in 48 hrs </a>
                                                                    <a class="list-group-item" href="IncentiveStatusInspectionUploadDetailsNew.aspx?Stg=7">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label21" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 48 hrs </a>


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
                                                        <a href="DIC Login Incentive.doc" target="_blank">User Manual of DIC</a>  </td>
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
