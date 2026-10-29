<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personal_Interaction_Page_New_Entrepreneurs_PrintPage.aspx.cs" Inherits="UI_TSiPASS_Personal_Interaction_Page_New_Entrepreneurs_PrintPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <style>
        @media print {
            @page {
                size: A4;
                margin: 0;
            }

            html {
                transform: scale(0.99);
            }

            body {
                margin: 0;
                padding: 0;
            }

            #printButton {
                display: none;
            }
        }

        /* Define landscape mode */
        @page {
            size: portrait;
        }

        /* Define page margins */
        body {
            margin: 5px;
        }

        /* Style for left and right columns */
        .column {
            float: left;
            width: 50%;
        }

        .left {
            width: 53%;
            margin-right: 5px;
        }

        .right {
            width: 45%;
            margin-left: 7px;
            //margin-right:0px;
        }
        /* Left Column */
        .left-column {
            width: 49%;
            margin-right: 5px;
        }

        /* Right Column */
        .right-column {
            width: 49%;
            margin-left: 5px;
        }

        /* Style for tables */
        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 5px;
            padding: 20px;
        }

        th, td {
            border: 1px solid #000;
            padding: 5px;
            text-align: left;
        }

        /* Style for image sections */
        .image-section {
            width: 50%;
            float: left;
            margin-top: 5px;
            margin-bottom: 5px;
        }

            .image-section img {
                max-width: 100%;
                height: auto;
                //shape-margin:5px;
            }

        .image {
            max-width: 200px;
            max-height: 200px;
            width: auto;
            height: auto;
        }

        .image1 {
            max-width: 1200px;
            max-height: 200px;
            width: auto;
            height: auto;
        }

        .primary {
            background-color: #007bff; /* Change to your preferred primary color */
            color: #fff; /* Text color */
            border: none; /* Remove the button border */
            padding: 10px 20px; /* Adjust padding as needed */
            cursor: pointer; /* Show a pointer cursor on hover */
            border-radius: 5px; /* Add some rounded corners */
            font-weight: bold; /* Make the text bold */
        }

            .primary:hover {
                background-color: #0056b3; /* Change to a darker shade on hover if desired */
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-decoration: underline; font-weight: bold; text-align: center; font-size: 20px;">PERSONAL INTERACTION - NEW ENTREPRENEURS</h1>
        <div>
            <table>
                <tr>
                    <th colspan="2" style="font-weight: bold; text-align: center;">Interaction Details</th>
                </tr>
                <tr>
                    <td>Mode of Interaction</td>
                    <td>
                        <asp:Label ID="modeofinteraction" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 310px;">Whether interaction took place at women cell</td>
                    <td>
                        <asp:Label ID="womencell" runat="server" /></td>
                </tr>
                <tr>
                    <td>Mandal</td>
                    <td>
                        <asp:Label ID="mandalname" runat="server" /></td>
                </tr>
                <tr>
                    <td>Date of Interaction</td>
                    <td>
                        <asp:Label ID="dateofinteraction" runat="server" /></td>
                </tr>
                <tr>
                    <td>Venue of Interaction</td>
                    <td>
                        <asp:Label ID="interactionvenue" runat="server" /></td>
                </tr>
            </table>
            <table>
                <tr>
                    <th colspan="2" style="font-weight: bold; text-align: center;">Candidate Details</th>
                </tr>
                <tr>
                    <td>Candidate's Name</td>
                    <td>
                        <asp:Label ID="candidatename" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 310px;">Contact Number</td>
                    <td>
                        <asp:Label ID="candidatenumber" runat="server" /></td>
                </tr>
                <tr>
                    <td>Email ID</td>
                    <td>
                        <asp:Label ID="candidatemail" runat="server" /></td>
                </tr>
                <tr>
                    <td>Candidate's Age</td>
                    <td>
                        <asp:Label ID="candidateage" runat="server" /></td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td>
                        <asp:Label ID="candidategender" runat="server" /></td>
                </tr>
                <tr>
                    <td>Social Category</td>
                    <td>
                        <asp:Label ID="socialcategory" runat="server" /></td>
                </tr>
                <tr>
                    <td>Physically Handicapped</td>
                    <td>
                        <asp:Label ID="phd" runat="server" /></td>
                </tr>
                <tr>
                    <td>Highest Qualification</td>
                    <td>
                        <asp:Label ID="qualification" runat="server" /></td>
                </tr>
            </table>
            <table>
                <tr>
                    <th colspan="2" style="font-weight: bold; text-align: center;">Sector Specific Details</th>
                </tr>
                <tr>
                    <td>Purpose of Visit</td>
                    <td>
                        <asp:Label ID="visitpurpose" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 310px;">Any Sector Specific Experience</td>
                    <td>
                        <asp:Label ID="sectorexperience" runat="server" /></td>
                </tr>
                <tr>
                    <td>Sector Name</td>
                    <td>
                        <asp:Label ID="sectorname" runat="server" /></td>
                </tr>
                <tr>
                    <td>Experience in Sector</td>
                    <td>
                        <asp:Label ID="experienceinsector" runat="server" /></td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <th colspan="5" style="text-align: center; font-weight: bold;">Scheme Details</th>
                </tr>
                <tr>
                    <td style="text-align: center" width="160px">Types of Interaction</td>
                    <td style="text-align: center">Interaction Schemes</td>
                    <td style="text-align: center" width="120px">Guidance Given</td>
                    <td style="text-align: center" width="120px">Unit Interested & Link Shared</td>
                    <td style="text-align: center" width="120px">Link Received</td>
                </tr>
                <tr>
                    <td rowspan="7">Schemes</td>
                    <td>PMEGP</td>
                    <td>
                        <asp:Label ID="pmegpproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="pmegpinterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>PMFME</td>
                    <td>
                        <asp:Label ID="pmfmeproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="pmfmeinterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>T-IDEA</td>
                    <td>
                        <asp:Label ID="t_ideaproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="t_ideainterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>T-PRIDE</td>
                    <td>
                        <asp:Label ID="t_prideproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="t_prideinterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>MUDRA</td>
                    <td>
                        <asp:Label ID="mudraproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="mudrainterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>CGTMSE</td>
                    <td>
                        <asp:Label ID="cgtmseproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="cgtmseinterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>DALITHA BANDHU</td>
                    <td>
                        <asp:Label ID="dalithabandhuproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="dalithabandhuinterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="2">Trainings</td>
                    <td>TASKS</td>
                    <td>
                        <asp:Label ID="tasksproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="tasksinterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>DEPARTMENT OF EMPLOYMENT & TRAINING</td>
                    <td>
                        <asp:Label ID="detproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="detinterested" runat="server" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Land</td>
                    <td>WHETHER INFORMATION ON VACANT PLOTS MANDATED TO WEAKER SECTION INFORMED</td>
                    <td>
                        <asp:Label ID="landproposed" runat="server" /></td>
                    <td>
                        <asp:Label ID="landinterested" runat="server" Enabled="false" /></td>
                    <td></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td width="160px">ANY OTHER ISSUES</td>
                    <td>
                        <asp:Label ID="otherissues" runat="server" /></td>
                </tr>
            </table>
            <div style="text-align: center;">
                <button id="printButton" class="primary">Print</button></div>
            <asp:Label ID="Interaction_ID" runat="server" Visible="false" />
        </div>
    </form>
    <script>
        document.getElementById('printButton').addEventListener('click', function () {
            window.print();
        });
    </script>
</body>
</html>
