<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="Home2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en-gb" class="no-js">
<head>

    <meta http-equiv="content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>About us:: TG-iPASS ::</title>
    <meta name="description" content="">
    <meta name="author" content="">
    <link id="default-css" href="css/style.css" rel="stylesheet" type="text/css">
    <link id="shortcodes-css" href="css/shortcodes.css" rel="stylesheet" type="text/css">
    <link href="css/responsive.css" rel="stylesheet" type="text/css">
    <link rel='stylesheet' id='layerslider-css' href="css/layerslider.css" type='text/css' media='all' />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link id="skin-css" href="skins/maroon/style.css" rel="stylesheet" media="all" />

    <link href='http://fonts.googleapis.com/css?family=Merriweather:400,900italic,900,700italic,700,400italic,300italic,300' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Domine:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Noto+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>

    <script src="js/modernizr-2.6.2.min.js"></script>
    <style>
                                                      :lang(te) {
    font-size: 100%;  /* Adjust as needed */
   
                        #main-menu ul.menu  li a {
    padding: 9px 5px 10px;
    font-size: 15px;
}
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

        #primary.page-with-sidebar {
            width: 1110px;
            margin: 70px 30px 0px 0px;
        }
    </style>
</head>
<body>
    <div class="wrapper">
        <div class="inner-wrapper">
            <header>
                <div class="top-bar">
                    <div class="container" >
                        <span id="clock" style="font-size: 12px;"></span>

                        <div class="dt-sc-contact-number">
                            <ul class="dt-sc-social-icons">
                                <li><span class="fa fa-phone"></span>Call us: 040-23441636</li>
                               <%-- <li><a href="https://www.facebook.com/profile.php?id=100011131938859" target="_blank" title="Facebook"><span class="fa fa-facebook"></span></a></li>
                                <li><a href="#" title="Google Plus"><span class="fa fa-google-plus"></span></a></li>
                                <li><a href="#" title="Youtube"><span class="fa fa-youtube"></span></a></li>--%>
                                <li><div class="translate d-flex mt-1 rounded"><div id="google_translate_element"></div></div></li>
                            </ul>

                        </div>
                    </div>
                </div>

                <div class="container">
                    <div class="logo">
                        <a href="index.html">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/logo.jpg" alt="Tsipass Logo"></a>
                    </div>
                    <div class="top-head" >
                        <div class="top-img" style="display:none">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/Revanth Reddy CM.JPG" id="imgcm" runat="server">
                             
                            <h5 class="top-names">Sri. A.Revanth Reddy</h5>
                            <p class="top-names1">Hon'ble Chief Minister</p>
                        </div>
                        <div class="top-img mr0" style="display:none">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/IT Minister.JPG" id="imgitm" runat="server" >
                           
                            <h5 class="top-names">Sri. D.Sridhar Babu</h5>
                            <p class="top-names1">Hon'ble Minister for Industries</p>
                        </div>
                    </div>
                </div>

                <div id="menu-container">
                    <div class="container">
                        <nav id="main-menu">
                            <div class="dt-menu-toggle" id="dt-menu-toggle">Menu<span class="dt-menu-toggle-icon"></span></div>
                            <ul id="menu-main-menu" class="menu">
                                <li ><a href="TSHome.aspx">Home</a></li>
                                <li class="current_page_item"><a href="about.aspx">About Us</a></li>
                                <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">Services</a>
                                    <ul class="sub-menu">
                                          <li><a target="_blank" href="UI/TSiPASS/frmCFEcertificateProcess.aspx">TS-iPass Certificate Verification</a></li>
                                        <%--<li><a target="_blank" href="UI/TSiPASS/AddNewInspectionUser.aspx">Inspection</a></li>--%>
                                        <li><a target="_blank" href="IncentiveRegistrationViewDocsNew.aspx">Incentive</a></li>
                                        <li><a target="_blank" href="UI/TSIPASS/RawMatirialLink.aspx">Raw Material Allocation</a></li>
                                         <li><a target="_blank" href="UI/TSiPASS/GuestGrievance.aspx">Grievance/Feedback</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/IFCHomepage.aspx">Investor Facilitation Cell</a></li>
                                        <%--<li><a target="_blank" href="UI/TSiPASS/GuestInsturction.aspx">Bank Loan Application</a></li>--%>
                                        <li><a target="_blank" onclick="if ( ! UserDeleteConfirmation()) return false;" href="http://udyogaadhaar.gov.in/">Udyog Aadhaar</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/MisreportDashboard.aspx">Mis Reports</a></li>
                                    </ul>
                                </li>
                                <li><a href="links.aspx">Related Departments</a></li>
                                    <li ><a href="Information.aspx">Information Wizard</a></li>
                                    <li><a href="Downloads.aspx">Repository of Regulations</a></li>
                                <li><a href="UseCommentsOnAmmendments.aspx">Business Regulations</a></li>
                                 <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">NSWS</a>
                                    <ul class="sub-menu">
                                        <li><a target="_blank" href="docs/NSWS_Note.pdf">About NSWS</a></li>
                                        <li><a target="_blank" href="docs/Approvals_Covered.pdf">Approvals List</a></li>
                                        <li><a target="_blank" href="https://www.nsws.gov.in/">Login</a></li>
                                    </ul>
                                </li>
                                    <li><a href="Contacts.aspx">Contact us</a></li>
                                 <%-- <li><a href="#x">Related Departments</a></li>
                                <li><a href="#x">Testimonials</a></li>
                                <li><a href="#x">Latest News</a></li>
                                <li><a href="#x">Contact Us</a></li>--%>

                                 <li><a href="IpassLogin.aspx"><i class="fa fa-lock"></i>Login</a></li>
                                <%--<li><a href="UI/TSiPASS/AddnewuserRegistration.aspx"><i class="fa fa-pencil"></i>Register</a></li>--%>
                            </ul>
                        </nav>
                    </div>
                </div>
                <div class="clearfix"></div>
            </header>

            <div id="main">
                <div class="breadcrumb-section">
                    <div class="container">
                        <h1>About Us </h1>
                        <div class="breadcrumb">
                           <span>You are here </span> <a href="TSHome.aspx">Home </a>
                            <span class="current">About Us </span>
                        </div>
                    </div>
                </div>


                <div class="container">
                    <section id="primary" class="page-with-sidebar with-right-sidebar">
                        <h3>TSiPASS : The “Telangana Industrial Project Approval<br>
                            and Self- Certification System (TG-iPASS) Act, 2014” (Act 3 of 2014)</h3>
                        <p>The Telangana Government has enacted the “Telangana State Industrial Project Approval and Self-Certification System (TS-iPASS) Act, 2014” (Act No.3 of 2014) for speedy processing of applications for issue of various clearances required for setting up of industries at a single point based on the self-certificate provided by the entrepreneur and also to create investor friendly environment in the State of Telangana. </p>
                        <div class="dt-sc-hr-invisible-very-small"></div>
                        <h4>The Salient features of the TS-iPASS are: </h4>

                        <div class="column">
                            <ul class="dt-sc-fancy-list chocolate check-circle">
                                <li><span>All departments connected for establishing and operation of an Enterprise brought under purview of TS-iPASS.</span></li>
                                <li><span>Time Limits set for each approval varying from 1 day to a maximum of 30 days depending upon on the complexity of the approval.</span></li>
                                <li><span>Pre-Scrutiny of the applications at State Level and District Level to assist the entrepreneurs in a proper submission of applications and to avoid delay in processing the files by the departments.</span></li>
                                <li><span>Making mandatory for the Competent Authorities to seek shortfall/additional information required, if any, only once, within three days from receipt of the application.</span></li>
                                <li><span>Empowering the Entrepreneurs with Right to clearances under TS-iPASS, to know the reasons for delay if any in getting the clearance within time limits and penalizing the officers responsible for the delay.</span></li>
                            </ul>
                        </div>
                        <div class="dt-sc-hr-invisible-very-small"></div>
                    </section>

                    <%--<section id="secondary" class="type2">
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

                    <div class="dt-sc-hr-invisible"></div>
                </div>

            </div>

            <footer>
                <div class="copyright">
                    <div class="container">
                        <div class="col-1 white">
                            <script type="text/javascript">                                document.write("&copy; " + new Date().getFullYear() + ". Copyright " + new Date().getFullYear() + " Government of Telangana. all rights reserved by Industries Chasing Cell..");</script>
                        </div>
                        <div class="col-1 white">
                            <a href="Contacts.aspx" title="Contact Us" target="_blank">Contact Us</a> |
                            <a href="UI/TSIPASS/TermsConditions.aspx" title="Terms of Use" target="_blank">Terms of Use</a> |
                            <a href="UI/TSIPASS/Privacypolicy.aspx" title="Privacy Policy" target="_blank">Privacy</a> |
                            <a href="UI/TSIPASS/IpassSitemap.aspx" title="Privacy Policy" target="_blank">Site Map</a>
                        </div>
                        <div class="col-2 white">
                            <span style="font-weight: bold"><asp:Label ID="lbllastupdat" runat="server" Text=""></asp:Label></span>
                            <%--Designed By <a href="http://www.bitranet.com/" title="Website Designed by BitraNet Pvt. Ltd.," target="_blank">BitraNet</a>--%>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </div>
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-114319492-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-114319492-1');
    </script>
    <script>
        function UserDeleteConfirmation() {
            return confirm("This is external link. Are you sure you want to continue?");
        }
    </script>
    <a href="#" title="Go to Top" class="back-to-top"><span class="fa fa-angle-up"></span></a>
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

    <script type="text/javascript">var lsjQuery = jQuery;</script>
    <script type="text/javascript"> lsjQuery(document).ready(function () { if (typeof lsjQuery.fn.layerSlider == "undefined") { lsShowNotice('layerslider_2', 'jquery'); } else { lsjQuery("#layerslider_2").layerSlider({ responsiveUnder: 1240, layersContainer: 1170, skinsPath: 'js/layerslider/skins/' }) } }); </script>
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
   
</body>
</html>
