<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="Interaction_Dashboard.aspx.cs" Inherits="UI_TSiPASS_InteractionDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .circle-button-container {
            display: inline-block;
            position: relative;
            cursor: pointer;
        }

        .circle-button {
            width: 150px;
            height: 150px;
            overflow: hidden;
            border-radius: 50%;
            transition: all 0.2s;
        }

            .circle-button img {
                width: 100%;
                height: 100%;
                object-fit: cover;
                border-radius: 50%;
            }

            .circle-button:hover {
                transform: scale(1.1);
            }

        .hyperlinks {
            display: block;
            position: absolute;
            top: 50%;
            left: -100px; /* Adjust the distance from the button */
            transform: translateY(-50%);
            transition: all 0.2s;
            opacity: 0;
        }

        .circle-button-container:hover .hyperlinks {
            left: 160px; /* Adjust the distance to slide the hyperlinks to the right side of the button */
            opacity: 1;
        }

        .hyperlinks a {
            display: block;
            text-align: center;
            padding: 5px;
            background-color: #009688;
            color: #fff;
            border-radius: 5px;
            width: auto;
            text-decoration: none;
            transition: transform 0.2s;
        }

            .hyperlinks a:hover {
                transform: scale(1.25);
            }

        .magnify {
            display: inline;
            margin-right: 2px;
            transition: transform 0.2s;
        }

            .magnify:hover {
                transform: scale(1.25);
            }

        .custom-div a {
            display: block; /* Ensures each hyperlink is on a new line */
            margin-bottom: 5px; /* Adds space between the hyperlinks */
        }
    </style>

    <div style="padding-left: 50px;">
        <table>
            <tr>
                <td>
                    <p style="font-size: 25px; text-align: center;">Personal Interaction</p>
                    <div style="text-align: center;">
                        <div class="circle-button-container">
                            <div class="circle-button">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/HandshakeLogo.png" alt="Image Description" style="object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                            </div>
                            <div class="hyperlinks custom-div" style="width: 200px;">
                                <a href="https://ipass.telangana.gov.in/UI/TSiPASS/Personal_Interaction_Page_New_Entrepreneurs.aspx" target="_blank" style="font-size: 18px; text-align: left;">New Entrepreneurs</a>
                                <a href="https://ipass.telangana.gov.in/UI/TSiPASS/Personal_Interaction_Page_EXISTING_Entrepreneurs.aspx" target="_blank" style="font-size: 18px; text-align: left;">Existing Entrepreneurs</a>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="width: 250px;"></td>
                <td>
                    <p style="font-size: 25px; text-align: center;">Update Pages</p>
                    <div class="circle-button-container">
                        <div class="circle-button">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/UpdateLogo.png" alt="Image Description" style="object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                        </div>
                        <div class="hyperlinks">
                            <p>
                                PMEGP -
                                    <a class="magnify" href="https://ipass.telangana.gov.in/UI/TSiPASS/PMEGPSuccessPage.aspx" target="_blank" style="display: inline-block; margin-right: 10px; transition: transform 0.2s;">Success Stories</a>& 
                                    <a class="magnify" href="https://ipass.telangana.gov.in/UI/TSiPASS/PMEGPPENDINGAPPLICATIONANALYSIS.aspx" target="_blank" style="display: inline-block; margin-right: 10px; transition: transform 0.2s;">Rejected Application Analysis</a>
                            </p>
                            <p style="width: 400px;">
                                Women Cell Constitution -
                            <a class="magnify" href="https://ipass.telangana.gov.in/UI/TSiPASS/frmConstofWomencell_DistrictLevel.aspx" target="_blank" style="display: inline-block; margin-right: 10px; transition: transform 0.2s;">District</a>& 
                            <a class="magnify" href="https://ipass.telangana.gov.in/UI/TSiPASS/frmConstofWomencell_MandalLevel.aspx" target="_blank" style="display: inline-block; margin-right: 10px; transition: transform 0.2s;">Mandal</a>
                            </p>
                            <div style="width: 250px;" class="custom-div">
                                <a href="https://ipass.telangana.gov.in/UI/TSiPASS/frmSupportToWeakerSection.aspx" target="_blank">I.E's Data - [Weaker Section]</a>
                                <a href="https://ipass.telangana.gov.in/UI/TSiPASS/UpdateMajorIndustries.aspx" target="_blank">Major Industries Officer Allocation</a>
                            </div>
                        </div>
                    </div>
                </td>

            </tr>
        </table>
    </div>
    <div style="padding-left: 30px; padding-top: 45px;">
        <table>
            <tr>
                <td>
                    <p style="font-size: 25px; text-align: center;">Camps Conducted</p>
                    <div style="text-align: center;">
                        <div class="circle-button-container">
                            <div class="circle-button">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/Camps.png" alt="Image Description" style="object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                            </div>
                            <div class="hyperlinks custom-div" style="width: 150px;">
                                <a href="https://ipass.telangana.gov.in/UI/TSiPASS/CAMPS_CONDUCTED.aspx" target="_blank" style="font-size: 20px; text-align: left">Camps Conducted</a>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="width: 170px;"></td>
                <td>
                    <p style="font-size: 25px; text-align: center;">Reports</p>
                    <div style="text-align: center;">
                        <div class="circle-button-container">
                            <div class="circle-button">
                                <img src="../../images/reports.png" alt="Image Description" style="object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                            </div>
                            <div class="hyperlinks custom-div" style="width: 150px;">
                                <a href="https://ipass.telangana.gov.in/UI/TSiPASS/InteractionsReportsDashBoard.aspx" target="_blank" style="font-size: 20px; text-align: left">Reports</a>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="width: 170px;"></td>
                <td>
                    <p style="font-size: 25px; text-align: center;">Knowledge Sharing</p>
                    <div style="text-align: center;">
                        <div class="circle-button-container">
                            <div class="circle-button">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/KnowledgeSharing.png" alt="Image Description" style="object-fit: cover; border-radius: 50%; border: 2px solid black;" />
                            </div>
                            <div class="hyperlinks custom-div" style="width: 150px;">
                                <a href="https://ipass.telangana.gov.in/UI/TSiPASS/CAMPS_CONDUCTED.aspx" target="_blank" style="font-size: 20px; text-align: left">Knowledge Sharing</a>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function showHyperlinks() {
            document.getElementById('hyperlinks').style.left = '0';
        }

        function hideHyperlinks() {
            document.getElementById('hyperlinks').style.left = '100%';
        }

    </script>
</asp:Content>
