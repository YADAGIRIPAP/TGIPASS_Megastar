<%@ Page Title=":: TSiPASS : MIS Reports " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="EODBDashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">




    </script>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">EODB Dashboard</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 style="font-family: Cambria;" class="panel-title">
                                    EODB Dashboard</h3>
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
                                                                <b>EODB Dashboard</b>
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
                                                                        <li id="Li2" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>E1: Application Progress Report</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptEODBReport.aspx?Dept=boilers&status=1">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E1.1:
                                                                                    Boilers Department</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptEODBReport.aspx?Dept=factories&status=1">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E1.2:
                                                                                    Factories Department</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptEODBReport.aspx?Dept=forest&status=1">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E1.3:
                                                                                    Forest Department</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptEODBReport.aspx?Dept=labour&status=1">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E1.4:
                                                                                    Labour Department</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptEODBReport.aspx?Dept=fire&status=1">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E1.5:
                                                                                    Fire and Safety Department</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div id='DashBoardmenu' style="font-weight: bold; font-family: Cambria; font-size: 16px;
                                                                    width: 100%">
                                                                    <ul>
                                                                        <li id="Masters" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>E2: Inspection Progress Report</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="InspectionProgressReport.aspx?Dept=BOILERS DEPARTMENT&status=2">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E2.1:
                                                                                    Boilers Department</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="InspectionProgressReport.aspx?Dept=FACTORIES DEPARTMENT&status=2">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E2.2:
                                                                                    Factories Department</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="InspectionProgressReport.aspx?Dept=PCB&status=2">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E2.3:
                                                                                    PCB Department</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="InspectionProgressReport.aspx?Dept=LABOUR DEPARTMENT&status=2">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E2.4:
                                                                                    Labour Department</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="InspectionProgressReport.aspx?Dept=FIRE&status=2">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E2.5:
                                                                                    Fire and Safety Department</a> </li>
                                                                                    
                                                                                      <li><a style="text-decoration: none;" target="_blank" href="InspectionProgressReport.aspx?Dept=INDUSTRIES&status=2">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;E2.6:
                                                                                    Industries Department</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
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
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
