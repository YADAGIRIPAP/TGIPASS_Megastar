<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="InteractionDashboard.aspx.cs" Inherits="UI_TSiPASS_InteractionDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        

    </style>
    <div style="padding-left: 50px;">
        <table>
            <tr>
                <td>
                    <p style="font-size: 25px; text-align: center;">Personal Interaction</p>
                    <div style="text-align: center;">
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/HandshakeLogo.png" alt="Image Description" style="width: 150px; height: 150px; object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                    </div>
                    <ul>
                        <li><a href="https://ipass.telangana.gov.in/UI/TSiPASS/Personal_Interaction_Page_New_Entrepreneurs.aspx" target="_blank" style="font-size: 15px; text-align: left">New Entrepreneurs</a></li>
                        <li><a href="https://ipass.telangana.gov.in/UI/TSiPASS/Personal_Interaction_Page_EXISTING_Entrepreneursnew.aspx" target="_blank" style="font-size: 15px; text-align: left">Existing Entrepreneurs</a></li>

                    </ul>
                </td>
                <td style="width: 150px;"></td>
                <td style="padding-bottom: 50px;">
                    <p style="font-size: 25px; text-align: center; padding-top: 30px;">Reports</p>
                    <div style="text-align: center;">
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/Reports.png" alt="Image Description" style="width: 150px; height: 150px; object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                    </div>
                    <ul>
                        <li><a href="https://ipass.telangana.gov.in/UI/TSiPASS/InteractionsReportsDashBoard.aspx" target="_blank" style="font-size: 15px; text-align: left">Reports</a></li>

                    </ul>
                </td>
                <td style="width: 150px;"></td>
                <td style="padding-bottom: 50px;">
                    <p style="font-size: 25px; text-align: center; padding-top: 30px;">Knowledge Sharing</p>
                    <div style="text-align: center;">
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/KnowledgeSharing.png" alt="Image Description" style="width: 150px; height: 150px; object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                    </div>
                    <ul>
                        <li><a href="frmknowledgingsharing.aspx" target="_blank" style="font-size: 15px; text-align: left">Knowledge Sharing</a></li>
                    </ul>
                </td>
            </tr>
        </table>
    </div>
    <div style="padding-left: 50px;">
        <table>
            <tr id="gmupdatelinks" runat="server" visible="false">
                <td>
                    <p style="font-size: 25px; text-align: center;">Camps Conducted</p>
                    <div style="text-align: center;">
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/Camps.png" alt="Image Description" style="width: 150px; height: 150px; object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                    </div>
                    <ul>
                        <li><a href="https://ipass.telangana.gov.in/UI/TSiPASS/CAMPS_CONDUCTED.aspx" target="_blank" style="font-size: 15px; text-align: left">Camps Conducted</a></li>

                    </ul>
                </td>
                <td style="width: 150px;"></td>
                <td style="padding-bottom: 50px;">
                    <p style="font-size: 25px; text-align: center;">Update Pages</p>
                    <div style="text-align: center;">
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/UpdateLogo.png" alt="Image Description" style="width: 150px; height: 150px; object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                    </div>
                </td>
                <td >
                    <ul>
                        <li>PMEGP - [ <a href="https://ipass.telangana.gov.in/UI/TSiPASS/PMEGPSuccessPage.aspx" target="_blank" style="font-size: 15px; text-align: left">Success Stories</a> , <a href="https://ipass.telangana.gov.in/UI/TSiPASS/PMEGPPENDINGAPPLICATIONANALYSIS.aspx" target="_blank" style="font-size: 15px; text-align: left">Rejected Application Analysis</a> ]</li>
                        <%--<li></li>--%>
                        <li>Women Cell Constitution - [ <a href="https://ipass.telangana.gov.in/UI/TSiPASS/frmConstofWomencell_DistrictLevel.aspx" target="_blank" style="font-size: 15px; text-align: left">District</a> , <a href="https://ipass.telangana.gov.in/UI/TSiPASS/frmConstofWomencell_MandalLevel.aspx" target="_blank" style="font-size: 15px; text-align: left">Mandal</a> ]</li>
                        <%--<li></li>--%>
                        <li><a href="https://ipass.telangana.gov.in/UI/TSiPASS/Weaker_Section.aspx" target="_blank" style="font-size: 15px; text-align: left">I.E's Data - [Weaker Section]</a></li>
                        <li><a href="https://ipass.telangana.gov.in/UI/TSiPASS/UpdateMajorIndustries.aspx" target="_blank" style="font-size: 15px; text-align: left">Major Industries Officer Allocation</a></li>
                    </ul>
                </td>


            </tr>
        </table>
    </div>

    <script type="text/javascript">

</script>
</asp:Content>
