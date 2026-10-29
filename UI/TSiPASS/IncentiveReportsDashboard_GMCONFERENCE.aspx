<%@ Page Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveReportsDashboard_GMCONFERENCE.aspx.cs" Inherits="UI_TSiPASS_IncentiveReportsDashboard_GMCONFERENCE" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">




    </script>

    <asp:updatepanel id="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 style="font-family: Cambria;" class="panel-title">
                                    MIS Incentive Reports Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <%--<tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/Home.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td colspan="3" style="width: 100%; color: #337ab7; text-align: center; font-family: Cambria;
                                                                font-size: 18px;">
                                                                <b>Incentive Reports</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div id='DashBoardmenu' style="font-weight: bold; font-family: Cambria; font-size: 16px;
                                                                    width: 100%">
                                                                      <ul>
                                                                          <%--<li id="lir1" runat="server" visible="false" style="color: #337ab7;"><a id="A2" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="frmdipcmeetings.aspx"><i class="fa fa-fw fa-database"  style="text-indent: 20px">
                                                                            </i>&nbsp;&nbsp;&nbsp;&nbsp;R1:  DIPC Meetings - Abstarct</a> </li>--%>
                                                                         
                                                                         <li  id="lir1" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank"
                                                                                    href="DIPCmeetingsPendencyWise.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R1: DIPC Meetings - Abstarct</a> </li>

                                                                          <li id="lir2" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveMISPendencyReport_GMCONFERENCE.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2:
                                                                                     Incentive - MIS GM Pendency</a> </li>
                                                                           <li  id="lir3" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmIncentiveProceedingabstract_GMCONFERENCE.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R3:
                                                                                    UC's Not Updated</a> </li>
                                                                          <li  id="lir4" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank"
                                                                                    href="frmImplstatuspendency.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R4: Status of Implementation - Pendency</a> </li>

                                                                                    <li  id="lir5" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank"
                                                                                    href="IncentiveMISPendencyReport_GMCONFERENCE_OOFICERWISE.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R5: Incentive - MIS GM Pendency with officer names</a> </li>

                                                                                    <li  id="li6" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank"
                                                                                    href="frmImplstatuspendency_BETWEENRANGE.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6: Status of Implementation - Pendency</a> </li>

                                                                           <li  id="li7" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank"
                                                                           href="IncentiveMISPendencyReport_GMCONFERENCE_OOFICERWISE_WITHIN.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                             </i>&nbsp;&nbsp;&nbsp;&nbsp;R7: Incentive - MIS GM Pendency with officer names(Within Time)</a> </li>

                                                                           <li  id="li8" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank"
                                                                            href="IncentiveMISPendencyReport_GMCONFERENCE_OOFICERWISE_BEYOND.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                            </i>&nbsp;&nbsp;&nbsp;&nbsp;R8: Incentive - MIS GM Pendency with officer names(Beyond Time)</a> </li>

                                                                           <li  id="li9" runat="server" visible="false" style="color: #337ab7;"><a style="text-decoration: none;" target="_blank"
  href="IncentiveMISPendencyReport1.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
  </i>&nbsp;&nbsp;&nbsp;&nbsp;R9: INCENTIVE MIS PENDENCY REPORT STAGE WISE</a> </li>

                                                                       
                                                                        
                                                                         
                                                                         
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                             
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                </div>
                                            </div>
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
    </asp:updatepanel>

</asp:Content>


