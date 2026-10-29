<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="InteractionsReportsDashBoard.aspx.cs" Inherits="UI_TSiPASS_InteractionsReportsDashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .col-lg-10 {
            width: 1050px;
        }
    </style>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
             <%--<div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a> </li>
                </ol>
            </div>--%>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-10">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title" style="text-align: center;">
                                    <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="500px">ENTREPRENEUR INTERACTIONS REPORTS</asp:Label>
                                </h3>
                            </div>
                            <div class="panel-body" style="font-size: 20px;">

                                <ul>
                                    <li>1. <a href="SupporttoExistingEntrepreneurs.aspx" target="_blank" style="text-decoration: none;">Support to Existing Entrepreneurs</a></li>
                                    <li>2. <a href="SupporttoWomenExistingEntrepreneurs.aspx" target="_blank">Support to Women Existing Entrepreneurs</a></li>

                                    <li id="rpt3" class='has-sub' runat="server">3. <a href='#'><i>Support to New Entrepreneurs</i></a>
                                        <ul>
                                            <li>3a. <a href="SupporttoNewEntrepreneurs.aspx" target="_blank">Support to New Entrepreneurs (Camps)</a></li>
                                            <li>3b. <a target="_blank" href="SupporttoNewbyInteraction.aspx" >Support to New Entrepreneurs (Interaction)</a></li>
                                        </ul>
                                    </li>

                                    <li>4. <a href="SupporttoODOPEntrepreneurs.aspx" target="_blank">Support to ODOP Entrepreneurs</a></li>
                                    <li>5. <a href="SupporttoSICKEntrepreneurs.aspx" target="_blank">Support to SICK Entrepreneurs</a></li>
                                    <li id="rpt6" class='has-sub' runat="server">6. <a href='#'><i>Women Cell</i></a>
                                        <ul>
                                            <li>6a. <a href="frmDistwomencell.aspx" target="_blank">Constitution of Women Cell District Level /Mandal Level</a></li>
                                            <li>6b. <a href="reportoninteractionwithexistent.aspx" target="_blank">Interactions through Women Cell</a></li>
                                        </ul>
                                    </li>
                                    <li>7. <a href="SupporttoWeakerSectionEntrepreneurs.aspx" target="_blank">Support to Entrepreneurs Belonging to Weaker Sections</a></li>
                                    <li id="rpt8" class='has-sub' runat="server">8. <a href='#'><i>Major Industries</i></a>
                                        <ul>
                                            <li>8a. <a href="ReportonMajorUnitsandAllottedOfficers.aspx" target="_blank">Report on Officers allotted to Major Industries</a></li>
                                            <li>8b. <a href="MajorIndustries_Report.aspx" target="_blank">Support to Major Industries</a></li>
                                        </ul>
                                    </li>
                                    <li>9. <a href="ReportOnFacilataionofMSME.aspx" target="_blank">Support to MSME Through E-Commerce Platforms</a></li>
                                    <li id="rpt10" class='has-sub' runat="server">10. <a href='#'><i>PMEGP</i></a>
                                        <ul>
                                            <li>10a. <a href="ReportOnPMEGPSuccessStories.aspx" target="_blank">PMEGP Success Stories</a></li>
                                            <li>10b. <a href="frmPMEGPReport.aspx" target="_blank">Analysis and Resolution on PMEGP Rejections</a></li>
                                        </ul>
                                    </li>
                                    <li>11. <a href="ReportOnMSEFCawarenessCamps.aspx" target="_blank">MSEFC Awareness Camps</a></li>
                                    <%-- <li><a href="Page9.aspx" target="_blank"></a></li>
                            <li><a href="Page10.aspx" target="_blank"></a></li>
                            <li><a href="Page11.aspx" target="_blank"></a></li>
                            <li><a href="Page12.aspx" target="_blank"></a></li>
                            <li><a href="Page13.aspx" target="_blank"></a></li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
</script>
</asp:Content>
