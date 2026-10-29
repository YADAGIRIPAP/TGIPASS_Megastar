<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TSHome.aspx.cs" Inherits="TSHome" %>

<%--<%@ OutputCache Duration = "60" VaryByParam = "*" %>--%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en-gb" class="no-js">
<head id="Head1" runat="server">
    <meta http-equiv="content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>TG-iPASS</title>
    <meta name="description" content="TG-iPASS">
    <meta name="author" content="TG-iPASS">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/shortcodes.css" rel="stylesheet" type="text/css" />
    <link href="css/responsive.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/layerslider.css" type="text/css" media="all" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="skins/maroon/style.css" rel="stylesheet" media="all" />
    <link href='https://fonts.googleapis.com/css?family=Merriweather:400,900italic,900,700italic,700,400italic,300italic,300'
        rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Domine:400,700' rel='stylesheet'
        type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Noto+Serif:400,700,400italic,700italic'
        rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800'
        rel='stylesheet' type='text/css'>
    <script src="js/modernizr-2.6.2.min.js"></script>
    <script>
        function UserDeleteConfirmation() {
            return confirm("This is external link. Are you sure you want to continue?");
        }
    </script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"
        rel="stylesheet">
    <script src="https://code.jquery.com/jquery-2.2.1.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="js/jquery.font-accessibility.min.js"></script>
    <script>
        $(function () {
            /* Basic demo */
            $('#font-setting-basic').easyView({
                container: '#basic'
            });

            /* Custom buttons */
            $('#font-setting-buttons').easyView({
                container: '#buttons',
                increaseSelector: '.increase-me',
                decreaseSelector: '.decrease-me',
                normalSelector: '.reset-me',

            });

        });
    </script>
    <style>
        :lang(te) {
            font-size: 100%; /* Adjust as needed */

            #main-menu ul.menu li a

        {
            padding: 9px 5px 10px;
            font-size: 15px;
        }

        }

        .blink_text {
            animation: 1s blinker linear infinite;
            -webkit-animation: 1s blinker linear infinite;
            -moz-animation: 1s blinker linear infinite;
            color: white;
            background-color: red;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.5;
            }

            100% {
                opacity: 10.5;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.5;
            }

            100% {
                opacity: 10.5;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.5;
            }

            100% {
                opacity: 10.5;
            }
        }

        .btn {
            padding: 0px 10px !important;
        }

        header .dt-sc-contact-number {
            font-size: 14px !important;
        }


        #grdDetails tr, th, td {
            background:#f1f1f1 !important;
            color: #000 !important;
            font-weight: 600;
            border: 1px solid #000 !important;
            font-size: 12px;
            text-align: center;
        }
    </style>
    <style>
        img.ls-bg.ls-preloaded {
            margin-top: 0px !important;
            height: 450px !important;
        }

        div#layerslider_2 {
            width: 85% !important;
        }




        img.goog-te-gadget-icon {
            display: none;
        }

        div#\:0\.targetLanguage {
            border-radius: 6px;
            margin-top: -1px;
        }

        .VIpgJd-ZVi9od-aZ2wEe-wOHMyf.VIpgJd-ZVi9od-aZ2wEe-wOHMyf-ti6hGc {
            display: none;
        }

        iframe#\:2\.container {
            visibility: hidden;
            display: none;
            margin-top: -10px !important;
        }

        body {
            top: 0px !important;
        }
    </style>
     <!--chatboot css-->
    <style>
        button.btn.back {
            background: #9C27B0 !important;
            color: #fff !important;
            box-shadow: 1px 2px 3px #ccc;
        }

        .chatboothead {
            font-size: 20px;
            font-family: 'Roboto Condensed';
            font-weight: 700;
            text-align: center;
            color: green;
            border-bottom: 1px solid #ccc;
            text-shadow: 1px 2px 3px #ccc;
            position: fixed !important;
            background: #fff;
            width: 23%;
            margin-left: -19px;
            bottom: 55%;
            border-radius: 9px 9px 0px 0px;
        }

        div#chat {
            position: fixed;
            z-index: 99999;
            bottom: 0;
            right: 0;
            width: 25%;
            height: 60%;
        }

            div#chat button.btn {
                padding: 10px !important;
                margin: 5px 5px;
                display: block;
                background: #fff;
                border: 1px solid #065a30;
                color: #065a30;
            }

        body {
            font-family: Arial;
        }

        .chatbox {
            max-width: 600px;
            margin: auto;
            border: 1px solid #ccc;
            padding: 10px;
            border-radius: 10px;
        }

        .chat {
            margin: 10px 0;
        }

        .bot {
            background-color: #f0f0f0;
            padding: 10px;
            border-radius: 10px;
        }

        .user {
            text-align: right;
        }

        .options button {
            margin: 5px;
            padding: 8px 12px;
        }
    </style>
    <style>
        #chat {
            max-width: 600px;
            margin: 0px auto;
            border: 1px solid #ccc;
            border-radius: 10px;
            padding: 20px;
            background: #f9f9f9;
            font-family: Arial, sans-serif;
            height: 350px;
            overflow-y: auto;
        }

        .message {
            margin: 10px 0;
            padding: 10px;
            border-radius: 10px;
            max-width: 80%;
            word-wrap: break-word;
        }

        .bot {
            background-color: #e0e0e0;
            align-self: flex-start;
        }

        .user {
            background-color: #cce5ff;
            align-self: flex-end;
            margin-left: auto;
        }

        .btn {
            display: inline-block;
            margin: 5px 5px 0 0;
            padding: 8px 12px;
            border: none;
            background-color: #007bff;
            color: white;
            border-radius: 5px;
            cursor: pointer;
        }

            .btn:hover {
                background-color: #0056b3;
            }

        .options {
            margin-top: 10px;
        }

        button.btn.back {
            background: #1d9a5b !important;
            color: #fff !important;
            box-shadow: 1px 2px 3px #ccc;
        }
    </style>
    <style>
        .blink-text {
            color: red;
            font-weight: bold;
            animation: blink 1s infinite;
        }

        @keyframes blink {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 0;
            }

            100% {
                opacity: 1;
            }
        }

        .scroll-text {
            width: 100%;
            overflow: hidden;
            white-space: nowrap;
        }

            .scroll-text a {
                display: inline-block;
                color: red;
                font-weight: bold;
                animation: scroll-left 10s linear infinite;
            }

        @keyframes scroll-left {
            0% {
                transform: translateX(100%);
            }

            100% {
                transform: translateX(-100%);
            }
        }

        @keyframes blink {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 0;
            }

            100% {
                opacity: 1;
            }
        }
    </style>
    <style>
/* Table Layout & Centering */
.table-custom {
    width: 100% !important;
    max-width: 750px !important; /* Limits maximum width of table */
    margin: 20px auto !important; /* Centers grid horizontally */
    border-collapse: separate;
    border-spacing: 0;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    font-size: 14px;
    background-color: #ffffff;
    box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
    border-radius: 8px;
    overflow: hidden;
    border: 1px solid #e5e7eb;
}

/* Header Style */
.table-custom th,
.GridviewScrollC1Header {
    background-color: #009688 !important;
    color: #ffffff !important;
    font-weight: 600;
    text-transform: uppercase;
    letter-spacing: 0.5px;
    padding: 10px 12px !important; /* Compact header padding */
    text-align: center;
    border: none !important;
}

/* Cell Padding and Alignment */
.table-custom td {
    padding: 8px 12px !important; /* Compact row cell padding */
    color: #374151;
    border-bottom: 1px solid #f3f4f6;
    border-right: none !important;
    text-align: center;
}

/* Modern Zebra Striping */
.table-custom tr:nth-child(even),
.GridviewScrollC1Item2 {
    background-color: #f9fafb !important;
}

.table-custom tr:nth-child(odd),
.GridviewScrollC1Item {
    background-color: #ffffff !important;
}

/* Hover Effect */
.table-custom tr:hover {
    background-color: #f0fdf4 !important;
    transition: background-color 0.2s ease-in-out;
}

/* Footer Style */
.table-custom tr:last-child td,
.GridviewScrollC1Footer {
    background-color: #00796b !important;
    color: #ffffff !important;
    font-weight: 700;
    font-size: 14px;
    padding: 10px 12px !important;
    border-top: 2px solid #004d40 !important;
    border-bottom: none !important;
    text-align: center;
}

.GridviewScrollC1Footer:hover {
    background-color: #00695c !important;
}
    </style>
</head>
<body id="buttons">
     <form runat="server" id="f1">
    <div class="wrapper">
        <div class="inner-wrapper">
            <header>
                <div class="top-bar">
                    <div class="container">
                        <span id="clock" style="font-size: 12px;"></span>
                        <div id="font-setting-buttons" style="float: right;padding-left: 40px;">
                            <div class="btn-group">
                                <a class="btn btn-default decrease-me" href="javascript:void(0)" id="minus" title="Decrease Font Size">
                                    <i class="fa fa-font size1">
                                        <i class="fa fa-minus minus"></i>
                                    </i>
                                </a>
                                <a class="btn btn-default reset-me" href="javascript:void(0)" id="actual" title="Actual Font Size">
                                    <i class="fa fa-font size1"></i>
                                </a>
                                <a class="btn btn-default increase-me" href="javascript:void(0)" id="plus" title="Increase Font Size">
                                    <i class="fa fa-font size1">
                                        <i class="fa fa-plus plus"></i>
                                    </i>
                                </a>
                            </div>
                        </div>
                        <div class="dt-sc-contact-number">
                            <ul class="dt-sc-social-icons">
                                <li><i class="fa fa-phone"><b>Call us: 040 - 23441636</b></i></li>
                                <li><a href="https://www.facebook.com/profile.php?id=100011131938859" target="_blank" title="Facebook"><span class="fa fa-facebook"></span></a></li>
                                <li><a href="#" title="Google Plus"><span class="fa fa-google-plus"></span></a></li>
                                <li><a href="#" title="Youtube"><span class="fa fa-youtube"></span></a></li>
                                <li><div class="translate d-flex mt-1 rounded"><div id="google_translate_element"></div></div></li>
                            </ul>

                        </div>
                    </div>
                </div>

                <div class="container">
                    <div class="logo">
                        <a href="TSHOME.ASPX">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/logo.jpg" alt="Tsipass Logo"/></a>
                    </div>
                    <div class="top-head" >
                                        <div class="top-img">
                                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/Revanth Reddy CM.JPG">
                                            <h5 class="top-names">Sri. A.Revanth Reddy</h5>
                                            <p class="top-names1">
                                                Hon'ble Chief Minister
                                            </p>
                                        </div>
                                        <div class="top-img mr0">
                                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/IT Minister.JPG">
                                            <h5 class="top-names">Sri. D.Sridhar Babu</h5>
                                            <p class="top-names1">
                                                Hon'ble Minister for Industries
                                            </p>
                                        </div>
                                    </div>
               
                </div>

                <div id="menu-container">
                    <div class="container">
                        <nav id="main-menu">
                            <div class="dt-menu-toggle" id="dt-menu-toggle">Menu<span class="dt-menu-toggle-icon"></span></div>
                            <ul id="menu-main-menu" class="menu">
                                <li class="current_page_item"><a href="TSHome.aspx">Home</a></li>
                                <li><a href="about.aspx">About Us</a></li>
                                <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">Services</a>
                                    <ul class="sub-menu">
                                      <%--  <li><a target="_blank" href="UI/TSiPASS/AmmendamentUserRegistration.aspx">Inspection</a></li>--%>
                                        <li><a target="_blank" href="UI/TSiPASS/frmCFEcertificateProcess.aspx">TG-iPass Certificate Verification</a></li>
                                        <%--<li><a target="_blank" href="UI/TSiPASS/AddNewInspectionUser.aspx">Inspection</a></li>--%>
                                        <li class="menu-item-simple-parent menu-item-depth-0"><a target="_blank" href="IncentiveRegistrationViewDocsNew.aspx">Incentive</a></li>
                                        <%-- <li class="menu-item-simple-parent menu-item-depth-0"><a target="_blank" href="#">Incentive</a>
                                                <ul class="sub-menu">
                                                    <li><a target="_blank" href="IncentiveRegistrationViewDocs.aspx">Incentive Check</a></li>
                                                    <li><a target="_blank" href="IpassLogin.aspx">Apply For Incentive</a></li>
                                                </ul>
                                            </li>--%>
                                        <li><a target="_blank" href="http://industries.telangana.gov.in/">Raw Material Allocation</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/GuestGrievance.aspx">Grievance/Feedback/Suggestions</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/IFCHomepage.aspx">Investor Facilitation Cell</a></li>
                                        <%--<li><a target="_blank" href="UI/TSiPASS/GuestInsturction.aspx">Bank Loan Application</a></li>--%>
                                        <li><a target="_blank" onclick="if ( ! UserDeleteConfirmation()) return false;" href="https://udyamregistration.gov.in">Udyam Registration</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/CISDashboard.aspx">Central Inspection System</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/MisreportDashboard.aspx">EODB Reports</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/frmcapturemsmenew.aspx">MSME Catelogue</a></li>
                                         <li><a target="_blank" href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Best Practices in Telangana.pdf">Best Practices in Telangana</a></li>
<%--                                         <li><a target="_blank" href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Third Party inspecting authorities.pdf">Third Party inspecting authorities</a></li>--%>
                                        <%--<li><a href="ClusterAbstractReportPublic.aspx">Central Inspection Report</a></li>--%>
                                    </ul>
                                </li>
                                <li><a href="links.aspx">Related Departments</a></li>
                                <li><a href="Information.aspx">Information Wizard</a></li>

<%--<li><a href="Downloads.aspx">Act & Rules</a></li>--%>
<%--                                <li><a href="Downloads.aspx">Repository of Regulations</a></li>--%>
                                <li><a href="Downloads.aspx">Repository of Regulations</a></li>
                                <li><a href="UseCommentsOnAmmendments.aspx" >Business Regulations</a> </li>
                                <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">NSWS</a>
                                    <ul class="sub-menu">
                                        <li><a target="_blank" href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/NSWS_Note.pdf">About NSWS</a></li>
                                        <li><a target="_blank" href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Approvals_Covered.pdf">Approvals List</a></li>
                                        <li><a target="_blank" href="https://www.nsws.gov.in/">Login</a></li>
                                    </ul>
                                </li>


                                <li><a href="Contacts.aspx">Contact us</a></li>
                                <li><a href="IpassLogin.aspx"><i class="fa fa-lock"></i>Login</a></li>
                                <%-- <li><a href="#x">Related Departments</a></li>
                                <li><a href="#x">Testimonials</a></li>
                                <li><a href="#x">Latest News</a></li>
                                <li><a href="#x">Contact Us</a></li>
                                
                                 <li style="display: flex; align-items: center; gap: 10px;margin-top:15px;" >    
                                    <a href="https://ipass.telangana.gov.in/Industries/Home.aspx" target="_blank"> Industries Portal</a>
                                     </li>

                                    <li>
                                <a  href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/TelanganaRising 2047.pdf" target="_blank">
                                    Telangana Rising 2047
                                </a>  </li>

                                <li><a href="UI/TSiPASS/AddnewuserRegistration.aspx"><i class="fa fa-pencil"></i>Register</a></li>--%>
                            </ul>
                        </nav>
                    </div>
                </div>
                <div class="clearfix"></div>
            </header>
            <div id="main">
                <div id="slider">
                    <div id="layerslider_2" class="ls-wp-container" style="width: 100%; height: 400px;
                        margin: 0 auto; margin-bottom: 0px;" runat="server">                      
                        <div runat="server" visible="false" class="ls-slide" data-ls=" transition2d: all;">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/NewHomeImg.jpg" class="ls-bg" />
                            <h2 class="ls-l caption-1" style="top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px;
                                white-space: nowrap;" data-ls="offsetxin:-80;delayin:1000;skewxin:-80;">
                                Welcome to TG-iPass
                            </h2>
                        </div>
                        <%--    <div class="ls-slide" data-ls=" transition2d: all;">
                            <img src="images/SHRE2149.JPG" class="ls-bg" />
                            <h2 class="ls-l caption-1" style="top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px;
                                white-space: nowrap;" data-ls="offsetxin:-80;delayin:1000;skewxin:-80;">
                                Welcome to TS-iPass
                            </h2>
                        </div>
                        <div class="ls-slide" data-ls=" transition2d: all;">
                            <img src="images/SHRE2274.JPG" class="ls-bg" />
                            <h2 class="ls-l caption-1" style="top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px;
                                white-space: nowrap;" data-ls="offsetxin:-80;delayin:1000;skewxin:-80;">
                                Welcome to TS-iPass
                            </h2>
                        </div>
                        <div class="ls-slide" data-ls=" transition2d: all;">
                            <img src="images/SHRE7209.JPG" class="ls-bg" />
                            <h2 class="ls-l caption-1" style="top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px;
                                white-space: nowrap;" data-ls="offsetxin:-80;delayin:1000;skewxin:-80;">
                                Welcome to TS-iPass
                            </h2>
                        </div>
                        <div class="ls-slide" data-ls=" transition2d: all;">
                            <img src="images/SHRE7328.JPG" class="ls-bg" style="margin-top: -75px !important;" />
                            <h2 class="ls-l caption-1" style="top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px;
                                white-space: nowrap;" data-ls="offsetxin:-80;delayin:1000;skewxin:-80;">
                                Welcome to TS-iPass
                            </h2>
                        </div>--%>
                        <%--<div class="ls-slide" data-ls=" transition2d: all;">
                            <img src="images/banner3.jpg" class="ls-bg" />
                            <h2 class="ls-l caption-1" style="top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px; white-space: nowrap;" data-ls="offsetxin:-80;delayin:1000;skewxin:-80;">Get Industrial Project Approvals by a single click </h2>
                            <p class="ls-l caption-1" style="top: 300px; left: 7px; font-weight: 400; font-size: 16px; padding: 15px 50px 15px 25px; line-height: 27px; white-space: nowrap;" data-ls="delayin:2000;skewxin:80;">

                                <a href="IpassLogin.aspx" class="dt-sc-bordered-button small">Login </a><a href="UI/TSiPASS/AddnewuserRegistration.aspx" class="dt-sc-bordered-button small">Register </a>
                            </p>
                        </div>--%>
                        <%--<div class="ls-slide" data-ls=" transition2d: all;">
                            <img src="images/ts-ipass1.jpg" class="ls-bg" />
                            <h2 class="ls-l caption-1" style="top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px; white-space: nowrap;" data-ls="offsetxin:-80;delayin:1000;skewxin:-80;">Welcome to TS-iPass </h2>
                            <p class="ls-l caption-1" style="top: 300px; left: 7px; font-weight: 400; font-size: 16px; padding: 15px 50px 15px 25px; line-height: 27px; white-space: nowrap;" data-ls="delayin:2000;skewxin:80;">
                                Telangana State Industrial Project Approval<br>
                                and Self-Certification System (TS-iPASS) Act, 2014
                            </p>
                        </div>--%>
                    </div>
                    <div class="container-fluid news-wrap">
                        <div class="container pr">
                            <div class="newsheading">
                                Announcements</div>
                            <div class="marque" style="margin-left: 180px;" id="divNews" runat="server">
                               
   <marquee><b>Telangana State Recognized as a Top Achiever in Ease of Doing Business Reforms (BRAP-2024) in the sectors – Business Entry – Construction Permit Enablers – Service sector – Land Administration.</b></marquee>
<%--                                <marquee><b>Telangana declared the No.1 state for Industry and Commerce</b> in the Good Governance Report given by Department of Administrative Reforms and Public Grievances, Govt of India for the year 2020-21</marquee>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <section id="primary" class="content-full-width">
                    <div class="container">
                       <%-- <h3 class="aligncenter no-transform">TSiPASS : The �Telangana State Industrial Project Approval<br>
                            and Self- Certification System (TS-iPASS) Act, 2014� (Act 3 of 2014)</h3>--%>
                        <div class="dt-sc-hr-invisible-very-small"></div>
                        <%--<p class="aligncenter" style="font-size: 16px;">The Telangana Government has enacted the �Telangana State Industrial Project Approval and Self-Certification System (TS-iPASS) Act, 2014� (Act No.3 of 2014) for speedy processing of applications for issue of various clearances required for setting up of industries at a single point based on the self-certificate provided by the entrepreneur and also to create investor friendly environment in the State of Telangana. </p>--%>

                        <div class="dt-sc-hr-invisible-very-small"></div>

                        <div class="dt-sc-hr-image"></div>

                      <%--  <div class="dt-sc-hr-invisible"></div>--%>


                        <%--  <h2 align="center">Our Services </h2>
                        <div class="dt-sc-one-fourth column first">
                            <div class="dt-sc-ico-content type1">
                                <div class="icon">
                                    <a href="UI/TSiPASS/frmCFEcertificateProcess.aspx" target="_blank">
                                        <img src="images/practice_icon4.png"></a>
                                </div>
                                <h5><a href="UI/TSiPASS/frmCFEcertificateProcess.aspx" target="_blank">TS-iPass Verification</a></h5>
                            </div>
                        </div>

                        <div class="dt-sc-one-fourth column">
                            <div class="dt-sc-ico-content type1">
                                <div class="icon">
                                    <a href="UI/TSiPASS/AddNewInspectionUser.aspx" target="_blank">
                                        <img src="images/practice_icon4.png"></a>
                                </div>
                                <h5><a href="UI/TSiPASS/AddNewInspectionUser.aspx" target="_blank">Inspection</a></h5>
                            </div>
                        </div>

                        <div class="dt-sc-one-fourth column">
                            <div class="dt-sc-ico-content type1">
                                <div class="icon">
                                    <a href="IncentiveRegistrationViewDocs.aspx" target="_blank">
                                        <img src="images/practice_icon4.png"></a>
                                </div>
                                <h5><a href="IncentiveRegistrationViewDocs.aspx" target="_blank">Incentive Check</a></h5>
                            </div>
                        </div>

                        <div class="dt-sc-one-fourth column">
                            <div class="dt-sc-ico-content type1">
                                <div class="icon">
                                    <a href="http://udyogaadhaar.gov.in/UA/UAM_Registration.aspx" target="_blank">
                                        <img src="images/practice_icon4.png"></a>
                                </div>
                                <h5><a href="http://udyogaadhaar.gov.in/UA/UAM_Registration.aspx" target="_blank">Udyog Aadhaar</a></h5>
                            </div>
                        </div>


                        <div class="dt-sc-hr-invisible"></div>
                        <div class="dt-sc-clear"></div>

                        <div class="dt-sc-one-fourth column first">
                            <div class="dt-sc-ico-content type1">
                                <div class="icon">
                                    <a href="UI/TSiPASS/GuestGrievance.aspx" target="_blank">
                                        <img src="images/practice_icon4.png"></a>
                                </div>
                                <h5><a href="UI/TSiPASS/GuestGrievance.aspx" target="_blank">Grievance Registration</a></h5>
                            </div>
                        </div>
                        <div class="dt-sc-one-fourth column">
                            <div class="dt-sc-ico-content type1">
                                <div class="icon">
                                    <a href="UI/TSiPASS/AddnewuserRegistration.aspx" target="_blank">
                                        <img src="images/practice_icon4.png"></a>
                                </div>
                                <h5><a href="UI/TSiPASS/AddnewuserRegistration.aspx" target="_blank">Raw Material Allocation</a></h5>
                            </div>
                        </div>
                        <div class="dt-sc-one-fourth column">
                            <div class="dt-sc-ico-content type1">
                                <div class="icon">
                                    <a href="UI/TSiPASS/GuestInsturction.aspx" target="_blank">
                                        <img src="images/practice_icon4.png"></a>
                                </div>
                                <h5><a href="UI/TSiPASS/GuestInsturction.aspx" target="_blank">Bank Loan Application</a></h5>
                            </div>
                        </div>

                        <div class="dt-sc-one-fourth column">
                            <div class="dt-sc-ico-content type1">
                                <div class="icon">
                                    <a href="#">
                                        <img src="images/practice_icon4.png"></a>
                                </div>
                                <h5><a href="#">List of Related Departments</a></h5>
                            </div>
                        </div>--%>
                        <div class="dt-sc-clear"></div>

                    </div>
                </section>
                <div  >
                    <div class="container" runat="server" visible="false">
                        <div class="row">
                            <section id="primary1" class="page-with-sidebar with-right-sidebar" style="width: 1140px">
                            <h1><b><a href="howtoapply.aspx">How to apply for Clearance in TG-iPASS</a>   </b></h1>
                                </section>
                        </div>
                        <div class="row">
                        </div>
                    </div>
                    <div class="container">
                            <h3><b><a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Incentives guidelines-Final Version.pdf" target="_blank">Incentives guidelines-Final Version <img src="docs/newimg.gif"></a>   </b></h3>
                        </div>
                        <div class="container" >
                            <h3><b><a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/MSME operational guidelines.pdf" target="_blank">MSME operational guidelines <img src="docs\newimg.gif"> </a>   </b></h3>
                        </div>
                </div>
                <div class="container">
                    <section id="primary" class="page-with-sidebar with-right-sidebar" style="width: 1140px">
                        <div class="dt-sc-one-column dt-sc-three-sixth" style="width:225px">
                            <a href="https://ipass.telangana.gov.in/Industries/Home.aspx"  target="_blank">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/Industriesimg.png" alt="Commissioner of Industries" style="border: thin solid !important;width:275px;height:165px"></a>
                        </div>
                       <div class="dt-sc-one-column dt-sc-three-sixth" style="width:225px">
                            <a href="https://udyamregistration.gov.in/" onclick="return confirm('You are being redirected to an external link.');" target="_blank">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/UDYAM REG FINAL.png" alt="Telangana State Portla" style="border-style: solid; border-color: inherit; border-width: thin;width:275px;height:165px" ></a>
                        </div>
                        <div class="dt-sc-one-column dt-sc-three-sixth" style="width:225px">
                            <a href="http://www.telangana.gov.in/" onclick="return confirm('You are being redirected to an external link.');" target="_blank">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/Telangana State Portal.png" alt="Telangana State Portla" style="border: thin solid !important;width:275px;height:165px""></a>
                        </div>
                        
                       <div class="dt-sc-one-column dt-sc-three-sixth" style="width:225px">
                            <a href="http://www.nsws.gov.in/" onclick="return confirm('You are being redirected to an external link.');" target="_blank">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/NSWS_Logo.png" alt="NSWS" style="border-style: solid; border-color: inherit; border-width: thin;width:275px;height:165px" ></a>
                        </div>
                         <div class="dt-sc-one-column dt-sc-three-sixth" style="width:225px">
                            <a href="https://xhtmlreviews.com/udyam/" onclick="return confirm('You are being redirected to an external link.');" target="_blank">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/Udyamika.jpeg" alt="Udyamika" style="border: thin solid !important;width:275px;height:165px""></a>
                        </div>
                      <%--  <div class="dt-sc-one-column dt-sc-three-sixth">
                            <a href="http://harithaharam.telangana.gov.in/">
                                <img src="images/1.jpg"></a>
                        </div>
                        <div class="dt-sc-one-column dt-sc-three-sixth">
                            <a href="http://www.telangana.gov.in/news/2016/05/06/harvest-rainwater">
                                <img src="images/2.jpg"></a>
                        </div>
                        <div class="dt-sc-one-column dt-sc-three-sixth">
                            <a href="http://missionkakatiya.cgg.gov.in/">
                                <img src="images/3.jpg"></a>
                        </div>
                        <div class="dt-sc-one-column dt-sc-three-sixth">
                            <a href="http://www.it.telangana.gov.in/investor-info/it-policy/">
                                <img src="images/4.jpg"></a>
                        </div>--%>
                    </section>
                    <%--   <section id="primary" class="page-with-sidebar with-right-sidebar">
                        <div class="dt-sc-one-column dt-sc-three-sixth">
                            <a href="http://harithaharam.telangana.gov.in/">
                                <img src="images/1.jpg"></a>
                        </div>
                        <div class="dt-sc-one-column dt-sc-three-sixth">
                            <a href="http://www.telangana.gov.in/news/2016/05/06/harvest-rainwater">
                                <img src="images/2.jpg"></a>
                        </div>
                        <div class="dt-sc-one-column dt-sc-three-sixth">
                            <a href="http://missionkakatiya.cgg.gov.in/">
                                <img src="images/3.jpg"></a>
                        </div>
                        <div class="dt-sc-one-column dt-sc-three-sixth">
                            <a href="http://www.it.telangana.gov.in/investor-info/it-policy/">
                                <img src="images/4.jpg"></a>
                        </div>
                    </section>

                    <section id="secondary" class="type2">
                        <aside class="widget widget_categories">
                            <h3 class="widgettitle"><span class="fa fa-download"></span>Downloads</h3>
                            <ul class="dt-sc-fancy-list caret">
                                <li><a href="docs/TS-iPASS.pdf" target="_blank">TS-iPass ACT </a></li>
                                <li><a target="_blank" href="docs/TS-iPassupdated.pdf">TS-iPass Guidelines </a></li>
                                <li><a target="_blank" href="docs/TimeLines.pdf">Timelines / Clearances </a></li>
                                <li><a target="_blank" href="docs/How to apply for clearances under TS.pdf">How to Apply </a></li>
                                <li><a target="_blank" href="Checklist.aspx">Checklist for Application </a></li>
                                <li><a target="_blank" href="HMDAChecklist.aspx">Checklist for Building Plan Approval </a></li>
                                <li><a target="_blank" href="HMDAChecklistCLU.aspx">Checklist for HMDA CLU </a></li>
                                <li><a target="_blank" href="Gallery.aspx">Videos Manuals Online Applications </a></li>
                            </ul>
                        </aside>
                    </section>--%>
                    <div class="dt-sc-hr-invisible">
                    </div>
                </div>
                <div>
    <div class="container">
        <div class="row justify-content-center">
            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdDetails_RowDataBound" 
                CssClass="table-custom" GridLines="None" ShowFooter="True">
                
                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="20px" CssClass="GridviewScrollC1Header" />
                <RowStyle Height="20px" CssClass="GridviewScrollC1Item" />
                <PagerStyle CssClass="GridviewScrollC1Pager" />
                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="20px" CssClass="GridviewScrollC1Footer" />
                <AlternatingRowStyle Height="20px" CssClass="GridviewScrollC1Item2" />
                
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="8%" ItemStyle-Width="8%">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="FinYear" HeaderText="Financial Year" HeaderStyle-Width="23%" ItemStyle-Width="23%" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Total_Application_received" HeaderText="No of Units" HeaderStyle-Width="23%" ItemStyle-Width="23%" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Total_Investments" HeaderText="Investment (Cr.)" HeaderStyle-Width="23%" ItemStyle-Width="23%" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Total_Empolyment" HeaderText="Employment" HeaderStyle-Width="23%" ItemStyle-Width="23%" HeaderStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
                <div class="sticky-container">
                    <ul class="sticky">
                        <li class="Regnnew"><a href="UI/TSIPASS/AddnewuserRegistration.aspx" target="_blank">
                            <img width="32" height="32" title="" alt="" src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/new_userNew.png" />
                            <p>
                                Registration</p>
                        </a></li>
                        <li class="Newlogn"><a href="IpassLogin.aspx" target="_blank">
                            <img width="32" height="32" title="" alt="" src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/Loginnew.jpg" />
                            <p>
                                Login</p>
                        </a></li>
                        <li class="facebook"><a href="https://www.facebook.com/profile.php?id=100011131938859"
                            target="_blank">
                            <img width="32" height="32" title="" alt="" src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/FacebookNew.png" />
                            <p>
                                Facebook</p>
                        </a></li>
                    </ul>
                </div>
            </div>
            <%-- <footer>
                <div class="copyright">
                    <div class="container">
                        <div class="col-1 white">
                            <script type="text/javascript">                                document.write("&copy; " + new Date().getFullYear() + ". Copyright " + new Date().getFullYear() + " Government of Telangana. all rights reserved by Industries Chasing Cell..");</script>
                        </div>
                        <div class="col-2 white">
                        <span style="font-weight:bold"> Last Update: 11-05-2018</span>
                         
                        </div>
                    </div>
                </div>
            </footer>--%>
            <footer>
                <div class="copyright">
                    <div class="container">
                        
                        <div class="col-1 white">
                            <a href="Contacts.aspx" title="Contact Us" target="_blank">Contact Us</a> |
                            <a href="UI/TSIPASS/TermsConditions.aspx" title="Terms of Use" target="_blank">Terms of Use</a> |
                            <a href="UI/TSIPASS/Privacypolicy.aspx" title="Privacy Policy" target="_blank">Privacy</a> |
                             <a href="UI/TSIPASS/IpassSitemap.aspx" title="Privacy Policy" target="_blank">Site Map</a> |
                           <%-- <div id="count">View Counts: 0</div>--%>
                             <%--<div id="count" runat="server" clientidmode="Static"></div>--%>
                           <asp:Label ID="lblClickCount" runat="server" Text="Chatbot View Count:"></asp:Label>
                        </div>
                        <div class="col-2 white">
                             <span style="font-weight: bold"><asp:Label ID="lbllastupdat" runat="server" Text=""></asp:Label></span>
                            <%--Designed By <a href="http://www.bitranet.com/" title="Website Designed by BitraNet Pvt. Ltd.," target="_blank">BitraNet</a>--%>
                        </div>
                    </div>
                </div>
            </footer>
            <footer style="background: linear-gradient(45deg, #021331, #044a8c);border: none !important;">
    <div class="copyright">
        <div class="container">
            <div class="col-1 white" style="width: 60% !important;margin-top: 2px;">
                <script type="text/javascript">  document.write("&copy; " + new Date().getFullYear() + ". Copyright " + new Date().getFullYear() + " Government of Telangana. all rights reserved by Industries Chasing Cell..");</script>
            </div>
            
            <div class="col-2 white" style="width: 40% !important;">
                 <span style="font-weight: 500;">Design and Developed by : <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/cmslogo.png" alt="CMS logo" style="width: 16%;margin-top: -5px;"/></span>
                <%--Designed By <a href="http://www.bitranet.com/" title="Website Designed by BitraNet Pvt. Ltd.," target="_blank">BitraNet</a>--%>
            </div>
        </div>
    </div>
</footer>
        </div>
    </div>
    <a href="#" title="Go to Top" class="back-to-top"><span class="fa fa-angle-up"></span>
    </a>

      <!--kalyanaddedboostrappopup-->
    <!-- Chatbot Icon -->
<div id="chatbotIcon" onclick="toggleChat()" style="
    position: fixed;
    bottom: 65px;
    right: 20px;
    width: 90px;
    height: 90px;
    background-color: #007bff;
    border-radius: 50%;
    cursor: pointer;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    z-index: 1000;
    display: flex;
    justify-content: center;
    align-items: center;
">
     <asp:ImageButton runat="server" id="lnkChat" OnClientClick="setTimeout(toggleChat, 500); return true;" OnClick="lnkChat_Click" ImageUrl="images/chatbot.gif" alt="Chat" style="width: 90px; height: 90px;"/>
  <%--  <img id="myImage" src="images/chatbot.gif" alt="Chat" style="width: 90px; height: 90px;"/>--%>
</div>
   
    <div id="chatWindow" style="display: none;">
        <div id="chat" class="chatboot"> </div>
    </div>

      <%--   <script>
             const img = document.getElementById("myImage");
             const countDisplay = document.getElementById("count");

             // Load existing count from localStorage (per user/browser)
             let count = parseInt(localStorage.getItem("imageViewCount")) || 0;
             countDisplay.textContent = "Chat Boat View Counts: " + 55 + count;

             // Increase count every time image is clicked or viewed
             img.addEventListener("click", () => {
                 count++;
                 localStorage.setItem("imageViewCount", count);
                 countDisplay.textContent = "Chat Boat View Counts: " + 55 + count;
             });
         </script>--%>
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-114319492-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-114319492-1');
    </script>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/jquery-migrate.min.js"></script>
    <script type="text/javascript" src="js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="js/jquery-easing-1.3.js"></script>
    <script type="text/javascript" src="js/jquery.sticky.js"></script>
    <script type="text/javascript" src="js/jquery.nicescroll.min.js"></script>
    <script type="text/javascript" src="js/jquery.smartresize.js"></script>
    <script type="text/javascript" src="js/shortcodes.js"></script>
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
    <script type="text/javascript" src="js/date.js"></script>
    <script type="text/javascript" src="js/jquery-transit-modified.js"></script>
    <script type="text/javascript" src="js/layerslider.kreaturamedia.jquery.js"></script>
    <script type='text/javascript' src="js/greensock.js"></script>
    <script type='text/javascript' src="js/layerslider.transitions.js"></script>
    <script type="text/javascript">        var lsjQuery = jQuery;</script>
    <script type="text/javascript">        lsjQuery(document).ready(function () { if (typeof lsjQuery.fn.layerSlider == "undefined") { lsShowNotice('layerslider_2', 'jquery'); } else { lsjQuery("#layerslider_2").layerSlider({ responsiveUnder: 1240, layersContainer: 1170, skinsPath: 'js/layerslider/skins/' }) } }); </script>
    <style>
        .sticky-container {
            /*background-color: #333;*/
            padding: 0px;
            margin: 0px;
            position: fixed;
            right: -154px;
            top: 48px;
            width: 200px;
            z-index: 9999;
        }

        .sticky li {
            list-style-type: none;
            background-color: #333;
            color: #efefef;
            height: 43px;
            padding: 0px;
            margin: 0px 0px 1px 0px;
            -webkit-transition: all 0.25s ease-in-out;
            -moz-transition: all 0.25s ease-in-out;
            -o-transition: all 0.25s ease-in-out;
            transition: all 0.25s ease-in-out;
            cursor: pointer;
            filter: url("data:image/svg+xml;utf8,<svg xmlns=\'http://www.w3.org/2000/svg\'><filter id=\'grayscale\'><feColorMatrix type=\'matrix\' values=\'0.3333 0.3333 0.3333 0 0 0.3333 0.3333 0.3333 0 0 0.3333 0.3333 0.3333 0 0 0 0 0 1 0\'/></filter></svg>#grayscale");
            filter: gray;
            -webkit-filter: grayscale(100%);
        }

            .sticky li:hover {
                margin-left: -115px; /*-webkit-transform: translateX(-115px);
		-moz-transform: translateX(-115px);
		-o-transform: translateX(-115px);
		-ms-transform: translateX(-115px);
		transform:translateX(-115px);*/ /*background-color: #8e44ad;*/
                filter: url("data:image/svg+xml;utf8,<svg xmlns=\'http://www.w3.org/2000/svg\'><filter id=\'grayscale\'><feColorMatrix type=\'matrix\' values=\'1 0 0 0 0, 0 1 0 0 0, 0 0 1 0 0, 0 0 0 1 0\'/></filter></svg>#grayscale");
                -webkit-filter: grayscale(0%);
            }

            .sticky li img {
                float: left;
                margin: 5px 5px;
                margin-right: 10px;
            }

            .sticky li p {
                padding: 0px;
                margin: 0px;
                text-transform: uppercase;
                line-height: 43px;
            }

            .sticky li a p {
                color: #fff;
            }

        .facebook {
            background: #3B5998 !important;
            color: white !important;
            background-color: #3B5998;
        }

        .Newlogn {
            background: #32bda5 !important;
            color: white !important;
            background-color: #32bda5;
        }

        .Regnnew {
            background: #157dc3 !important;
            color: white !important;
            background-color: #157dc3;
        }
    </style>
                <script type="text/javascript">
                    function googleTranslateElementInit() {
                        new google.translate.TranslateElement({
                            pageLanguage: 'en',
                            includedLanguages: 'te,en', // Telugu
                            layout: google.translate.TranslateElement.InlineLayout.SIMPLE
                        }, 'google_translate_element');
                    }
</script>

<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
    
     <script type="text/javascript">
         const chatData = {
             "User Registration & Login": {
                 "Register on TG-iPASS Portal ": "The link to register on TG-iPASS can be accessed <a href='https://ipass.telangana.gov.in/Note_TsIPass.aspx' target='_blank'>here</a>.",
                 "Forgot login password ": "No worries! Click on the 'Forgot Password' link on the login page. Access it <a href='https://ipass.telangana.gov.in/forgotpwd.aspx' target='_blank'>here</a>.",
                 "Log-in issues": "Here are a few checks:<br>• Ensure username/password is correct<br>• Check internet connection<br>• Try another browser<br>• Or call Help Desk: 040-23441636"
             },
             "Approvals": {
                 "Approval required to set up business in Telangana": "A project typically needs land and building approvals, electricity connection, water connection, etc.Please fill in the 'Know your Approvals' module to understand the approvals applicable to your business. The link can be accessed: <a href='https://ipass.telangana.gov.in/UI/TSiPASS/frmQuestionnaireCFE.aspx' target='_blank'>here</a>",
                 "List of statutory documents,fees and timelines for approvals": "Visit the TG-iPASS Information Wizard to identify necessary approvals based on your business type and location: The link can be accessed<a href='https://ipass.telangana.gov.in/Information.aspx' target='_blank'>here</a>",
                 "How long does it take to get approvals through TG- iPASS ?": "Depending on the approval, between 1 day to 30 days as per the TG- iPASS Act.",
                 "Is there any processing fee or user charges to apply for approvals via TG- iPASS": "To provide best services to the entrepreneurs a nominal user fee is levied.The charges can be accessed via <a href='https://ipass.telangana.gov.in/viewpdf.aspx?enc=olSBrXl6rl1gh1Zl/gAtCIkxOo/1mEK3ZEGdedYO3dbgHlf+VSWFL6LVs+mm8Rg6nTRHe7ixLA1Uzvt6vtEOd7yNOlXTsEGt9qK4Uv6FedmRutwljTBe0FN+NA4ZvXJyZeHAE71P8b9aF51O2B1hto6ngJexb4Ued6b8Luj1YyU=' target='_blank'>here</a>",
                 "What is the maximum timeline for approval under TG- iPASS ?": "Approval is granted within a maximum of 30 days from the date of receipt of application.",
                 "How do I apply for Building permission": "A unified portal to apply for Building Permission. It can be accessed <a href='https://tgbpass.telangana.gov.in/' target='_blank'>here</a>",
                 "What documents are needed for building permission?": "The checklist can be accessed <a href='https://tgbpass.telangana.gov.in/others/checklist' target='_blank'>here</a>",
                 "Can I apply for multiple clearances in one go?": "Yes, TG-iPASS allows bundled applications for multiple approvals. ",
                 "Do I need to visit any office physically after applying online?": "No, TG-iPASS is a fully digital platform unless a physical inspection is required.",
                 "Is there a dashboard on TG-iPASS ?": "Yes. There are various dashboards on TG-iPASS. It can be accessed <a href='https://ipass.telangana.gov.in/UI/TSiPASS/MisreportDashboard.aspx' target='_blank'>here</a>",
                 "Track my application": "Enter the application number to get the current status of your application",
                 "Is the portal available in Telugu as well?": "Yes, the TG-iPASS portal is available in Telugu as well"
             },
             "Fire Safety NOC ": {
                 "Are there departments with empaneled third- party agencies?": "The list of departments who have empaneled third party agencies -<br/><a href='https://tgpcb.cgg.gov.in/Industry/GetFileUploads?menuid=1058&menu_name=Third+Party+Certification+of+Industries' target='_blank'>1.TGPCB</a><br/> <a href='https://labour.telangana.gov.in/ThirdPartyAuditors.do' target='_blank'>2.Labour</a><br/> <a href='https://tgfactories.cgg.gov.in/goViewPage.do' target='_blank'>3.Factories</a><br/> <a href='https://tgboilers.cgg.gov.in/home.do' target='_blank'>4.Boilers</a><br/> <a href='https://fire.telangana.gov.in/(S(euiqk0haweduupbf0pnpvlt0))/WebSite/Downloads/go/Thirdpartyaudit.pdf' target='_blank'>5.Fire</a><br/> <a href='https://tgsouthernpower.org/resources/PDF/EODB/REFORM%20178%20EXTERNAL%20INSTALLATION%20CIRCULAR.pdf' target='_blank'>6.TGSPDCL</a><br/> <a href='https://tgnpdcl.com/Utilites/COML/178_eodb_reform.pdf' target='_blank'>7.TGNPDCL</a>"
             },
             "Industrial Land Bank Details": {
                 "Where can I find details about available industrial land banks?": "Explore available industrial lands through TGIIC portal. It can be accessed <a href='https://www.tgiic.telangana.gov.in/' target='_blank'>here</a>",
                 "How can I access the Environmental Clearance order obtained for various Industrial Parks under TGIIC": "The link can be accessed <a href='https://tgiic.telangana.gov.in/showView?div_id=33' target='_blank'>here</a>",
                 "Industrial Park Land rates": "The link can be accessed <a href='https://tgiic.telangana.gov.in/showView?div_id=20' target='_blank'>here</a>",
                 "What is the process for land allotment ?": "The procedure, checklist, timelines and other details can be accessed <a href='https://tgiic.telangana.gov.in/showView?div_id=37' target='_blank'>here</a>"

             },
             "Incentives for Investors": {
                 "What are the eligible incentives applicable to my business?": "Check the incentives eligible for your business under 'Information Wizard' and click on 'View eligible industry applicable for your business / industry'.The link can be accessed <a href='https://ipass.telangana.gov.in/Information.aspx' target='_blank'>here</a>",
                 "What are the industrial incentives in Telangana": "Check industrial incentives in Telangana under 'Information Wizard' and click on 'Industries Department(INCENTIVES)'. The link can be accessed <a href='https://ipass.telangana.gov.in/Information.aspx' target='_blank'>here</a>",
                 "How can I apply for incentives?": "Applications for incentives can be submitted through the TG- iPASS portal"
             },
             "Grievance Redressal and Feedback": {
                 "How do I register my grievance on TG- iPASS ?": "The grievances can be registered on TG-iPASS <a href='https://ipass.telangana.gov.in/UI/TSiPASS/GuestGrievance.aspx' target='_blank'>here</a>",
                 "Can I provide feedback on TG-iPASS ? ": "Yes, you can provide your feedback <a href='https://ipass.telangana.gov.in/UI/TSiPASS/GuestGrievance.aspx' target='_blank'>here</a>",
                 "How long does it take to resolve a grievance?": "Grievances are resolved within 7 – 15 working days. ",
                 "How can I raise grievance regarding approvals?": "Grievances can be raised through the TG-iPASS portal or by contacting the Investor Facilitation Cell.The link to raise a grievance can be accessed <a href='https://ipass.telangana.gov.in/UI/TSiPASS/GuestGeneralQuery.aspx' target='_blank'>here</a>"
             },
             "Trademark Registration": {
                 "Do you wish to file for Trademarks ?": "The link to online filing of Trademark can be accessed <a href='https://ipindiaonline.gov.in/trademarkefiling/user/frmloginnew.aspx' target='_blank'>here</a>",
                 "Do you wish to file for patents? ": "The link to the New Registration Form can be accessed <a href='https://ipronline.ipindia.gov.in/epatentfiling/user/NewUserRegistration.aspx' target='_blank'>here</a>",
                 "Are you facing an issues related to IP? ": "The link to register issues related to IP can be accessed <a href='https://iprsearch.ipindia.gov.in/openhousehelpdesk/Login/Login' target='_blank'>here</a>"
             },
             "Information related to MSMEs": {
                 "Is there any policy for MSMEs in Telangana ": "Yes. The policy can be accessed <a href='https://industries.telangana.gov.in/Library/MSME%20Policy%20Booklet%20English1.pdf' target='_blank'>here</a>",
                 "How do I apply for Udyam Registration": "The link to register can be accessed <a href='https://udyamregistration.gov.in/Government-India/Ministry-MSME-registration.htm' target='_blank'>here</a>"
             },
             "One District One Product(ODOP) ": {
                 "List of ODOP products in Telangana": "The list of ODOP products can be accessed <a href='https://industries.telangana.gov.in/Library/TG_ODOP%20List_Dec%202024.pdf' target='_blank'>here</a>",
                 "ODOP Seller list in Telangana ": "The ODOP seller list can be accessed <a href='https://industries.telangana.gov.in/Library/TG_ODOP%20Sellers%20list.pdf' target='_blank'>here</a>"
             },
             "Application Tracker": {
                 "Track my Application": "<a href='https://ipass.telangana.gov.in/UI/TSiPASS/frmCFEcertificateProcess.aspx' target='_blank'>Click here</a>"
             },
             "Start-Ups": {
                 "How do I register my Start-up in Telangana ?": "The link to register your Start-up can be accessed <a href='' target='_blank'>here</a>",
                 "Are there institutions specifically to foster women entrepreneurship": "Yes. WE-Hub is India’s First State-led Nodal Organization for Women Entrepreneurs.You can visit their website via - https://wehub.telangana.gov.in/ ",
                 "Are there any institutes which foster Innovation and Entrepreneurship in Telangana across various sectors": "Yes. The following are the agencies along with their website links - <br/> <a href='https://t-hub.co/' target='_blank'>1.T-Hub</a> <br/> <a href='https://teamtsic.telangana.gov.in/' target='_blank'>2.TGIC</a><br/><a href='https://wehub.telangana.gov.in/' target='_blank'>3.WE-Hub</a><br/><a href='https://tworks.telangana.gov.in/' target='_blank'>4.T-Works</a><br/><a href='https://rich.telangana.gov.in/' target='_blank'>5.RICH</a>"
             },
             "Skilling": {
                 "Are there any skill institutes in the State": "Telangana Academy for Skill and Knowledge (TASK) works with the primary aim of skilling youth and making them more employable and hence, curbing the unemployment rate in the State.<br/>The website can be accessed <a href='https://task.telangana.gov.in/' target='_blank'>here</a>"

             },
             "Policy related information": {
                 "How can I access to various Government Orders issued by the State ": "The link can be accessed  <a href='https://goir.telangana.gov.in/Default.aspx' target='_blank'>here</a>",
                 "Is the TG-iPASS governed by any Act": "Yes. It is governed by the TG-iPASS Act. The copy of the Act can be accessed <a href='https://ipass.telangana.gov.in/viewpdf.aspx?enc=olSBrXl6rl1gh1Zl/gAtCIkxOo/1mEK3ZEGdedYO3dbgHlf+VSWFL6LVs+mm8Rg6nTRHe7ixLA1Uzvt6vtEOd8w7QkBEYKnD38GK4bJO3qGCrsCJ6IRuWyNxt57AkRNk' target='_blank'>here</a>"
             },
             "Contact us": {
                 "Where can I get information about sectoral directors? ": "The information on sectoral directors can be accessed <a href='https://ipass.telangana.gov.in/viewpdf.aspx?enc=olSBrXl6rl1gh1Zl/gAtCIkxOo/1mEK3ZEGdedYO3dbgHlf+VSWFL6LVs+mm8Rg6nTRHe7ixLA1Uzvt6vtEOd4mYfhDFWkB480qihQTvmV1ibKDc5vBgCvoRL7mZtQWntgSnwKrTxcbykWxrJzR3jES6iMsrXsrNugQazzQzaVdTLnwNPH7ad7nYFHeTW5o3' target='_blank'>here</a>",
                 "How can I reach out to the Commissionerate of Industries?": "Visit the 'Contact us' page on TG-iPASS. The link can be accessed <a href='https://ipass.telangana.gov.in/Contacts.aspx' target='_blank'>here</a>",
                 "What is the role of sectoral directors ?": "Sectoral directors are responsible for promoting and facilitating investment in specific sectors within Telangana."
             },

         };

         const chatBox = document.getElementById('chat');
         let currentLevel = 'main';
         let previousCategory = '';

         function addMessage(text, sender) {
             const msg = document.createElement('div');
             msg.className = 'message ' + sender;
             msg.innerHTML = text;
             chatBox.appendChild(msg);
             chatBox.scrollTop = chatBox.scrollHeight;
         }

         function showOptions(options, callback, showBack = false) {
             const optionDiv = document.createElement('div');
             optionDiv.className = 'options';

             Object.keys(options).forEach(key => {
                 const btn = document.createElement('button');
                 btn.className = 'btn';
                 btn.innerText = key;
                 btn.onclick = () => {
                     addMessage(key, 'user');
                     optionDiv.remove();
                     callback(key);
                 };
                 optionDiv.appendChild(btn);
             });

             if (showBack) {
                 const backBtn = document.createElement('button');
                 backBtn.className = 'btn back';
                 //backBtn.innerText = '"<img src="images/back.gif" alt="backicon"/>" Back';
                 backBtn.innerHTML = '<img src="images/back.gif" alt="backicon" style="width:25%"/> Back';
                 backBtn.onclick = () => {
                     optionDiv.remove();
                     if (currentLevel === 'questions') {
                         currentLevel = 'main';
                         startChat();
                     } else if (currentLevel === 'answer') {
                         currentLevel = 'questions';
                         showCategory(previousCategory);
                     }
                 };
                 optionDiv.appendChild(backBtn);
             }

             chatBox.appendChild(optionDiv);
             chatBox.scrollTop = chatBox.scrollHeight;
         }

         function showCategory(category) {
             previousCategory = category;
             currentLevel = 'questions';
             addMessage("Here are some common questions:", 'bot');
             showOptions(chatData[category], showQuestion, true);
         }

         function showQuestion(question) {
             const answer = chatData[previousCategory][question];
             currentLevel = 'answer';
             addMessage(answer, 'bot');
             showOptions({}, () => { }, true);
         }

         function startChat() {
             chatBox.innerHTML = `
        <div class="chatboothead" style="position: relative;">
            Welcome to TG-iPASS
            <span onclick="closeChat()" style="
                position: absolute;
                top: 5px;
                right: 10px;
                cursor: pointer;
                font-weight: bold;
                font-size: 18px;
            ">×</span>
        </div>
         <div id="chatMessages"></div>       
    `;

             //  addMessage("Welcome! Please choose a topic:", 'bot');
             chatMessages = document.getElementById('chatMessages');
             addMessage("Welcome! Please choose a topic:", 'bot');
             //chatBox.innerHTML = '<div class="chatboothead">Welcome to TGIPASS</div>';
             //addMessage("Welcome! Please choose a topic:", 'bot');
             showOptions(chatData, showCategory);
         }

         startChat();
     </script>
    <script>
        function toggleChat() {
            var chatWindow = document.getElementById("chatWindow");
            if (chatWindow.style.display === "none" || chatWindow.style.display === "") {
                chatWindow.style.display = "block";
            } else {
                chatWindow.style.display = "none";
            }
        }
        function closeChat() {
            document.getElementById("chatWindow").style.display = "none";
        }
        window.addEventListener('pointerdown', function (event) {
            const chatWindow = document.getElementById('chatWindow');
            const chatbotIcon = document.getElementById('chatbotIcon');

            const isVisible = window.getComputedStyle(chatWindow).display !== 'none';

            setTimeout(() => {
                if (
                    isVisible &&
                    !chatWindow.contains(event.target) &&
                    !chatbotIcon.contains(event.target)
                ) {
                    closeChat();
                }
            }, 10);
        });
    </script>

                           <%--  <div class="input-area" style="margin-top:10px; display:flex; gap:5px;">
            <input type="text" id="userInput" placeholder="Type your message..." style="flex: 1; padding: 8px;" />
            <button onclick="handleUserInput()" style="padding: 8px 12px;">Send</button>
        </div>--%>

     </form>
</body>
</html>
