<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChecklistNew.aspx.cs" Inherits="ChecklistNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>:: TS-iPASS ::</title>
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

    <script type="text/javascript">
        $(document).ready(function() {
            $(".menu_trigger").click(function() {
                $(".nav>ul").slideToggle();
            });


            $(".submenu1").click(function() {
                $(".submenu1 ul").slideToggle();
            });

            $(".submenu2").click(function() {
                $(".submenu2 ul").slideToggle();
            });

            $(".submenu3").click(function() {
                $(".submenu3 ul").slideToggle();
            });


            $(".submenu4").click(function() {
                $(".submenu4 ul").slideToggle();
            });

            $(".submenu5").click(function() {
                $(".submenu5 ul").slideToggle();
            });


        });
    </script>

    <style>
        table, td, th
        {
            border: 1px solid #ddd;
            text-align: left;
            font-size:14px;
        }
        table
        {
            border-collapse: collapse;
            width: 100%;
            font-size:14px;
        }
        th, td
        {
            padding: 15px;
            font-size:14px;
        }
    </style>
</head>
<body>
  <div class="wrapper">
        <div class="inner-wrapper">
             <header>
                <div class="top-bar">
                    <div class="container">
                        <span id="clock" style="font-size: 12px;"></span>

                        <div class="dt-sc-contact-number">
                            <ul class="dt-sc-social-icons">
                                <li><span class="fa fa-phone"></span>Call us: 040-23441636</li>
                                <li><a href="#" title="Facebook"><span class="fa fa-facebook"></span></a></li>
                                <li><a href="#" title="Google Plus"><span class="fa fa-google-plus"></span></a></li>
                                <li><a href="#" title="Youtube"><span class="fa fa-youtube"></span></a></li>
                            </ul>

                        </div>
                    </div>
                </div>

                <div class="container">
                    <div class="logo">
                        <a href="index.html">
                            <img src="images/logo.jpg"></a>
                    </div>
                    <div class="top-head">
                        <div class="top-img">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/Revanth Reddy CM.JPG" id="imgcm" runat="server">
                             
                            <h5 class="top-names">Sri. A.Revanth Reddy</h5>
                            <p class="top-names1">Hon'ble Chief Minister</p>
                        </div>
                        <div class="top-img mr0">
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
                                <li class="current_page_item"><a href="TSHome.aspx">Home</a></li>
                                <li><a href="about.aspx">About Us</a></li>
                                <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">Services</a>
                                    <ul class="sub-menu">
                                        <li><a target="_blank" href="UI/TSiPASS/frmCFEcertificateProcess.aspx">TS-iPass Verification</a></li>
                                        <%--<li><a target="_blank" href="UI/TSiPASS/AddNewInspectionUser.aspx">Inspection</a></li>--%>
                                        <li><a target="_blank" href="IncentiveRegistrationViewDocs.aspx">Incentive Check</a></li>
                                        <li><a target="_blank" href="IpassLogin.aspx">Raw Material Allocation</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/GuestGrievance.aspx">Grievance Registration</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/GuestInsturction.aspx">Bank Loan Application</a></li>
                                        <li><a target="_blank" href="http://udyogaadhaar.gov.in/">Udyog Aadhaar</a></li>
                                    </ul>
                                </li>
                                <li><a href="links.aspx">Related Departments</a></li>
                                <li><a href="Information.aspx">Information</a></li>

                                <li><a href="Downloads.aspx">Downloads</a></li>
                                <li><a href="UseCommentsOnAmmendments.aspx">Business Regulations</a></li>
                                <li><a href="Contacts.aspx">Contact us</a></li>
                                <%-- <li><a href="#x">Related Departments</a></li>
                                <li><a href="#x">Testimonials</a></li>
                                <li><a href="#x">Latest News</a></li>
                                <li><a href="#x">Contact Us</a></li>--%>
                                <li><a href="IpassLogin.aspx"><i class="fa fa-lock"></i>Login</a></li>
                                <li><a href="UI/TSiPASS/AddnewuserRegistration.aspx"><i class="fa fa-pencil"></i>Register</a></li>
                            </ul>
                        </nav>
                    </div>
                </div>
                <div class="clearfix"></div>
            </header>

            <div id="main">
                <div class="breadcrumb-section">
                    <div class="container">
                        <h1>Check List </h1>
                        <div class="breadcrumb">
                            <a href="TSHome.aspx">Home </a>
                            <span class="current">Checklist for Application</span>
                        </div>
                    </div>
                </div>


                <div class="container">
                  <div style="width: 95%;margin: auto;">
            <h2 style="padding-bottom: 4px; border-bottom: 1px solid #ddd;">
                Check List For TS-iPASS Approvals</h2>
            <p style="font-size:14px; color:black; font-weight:bold">
                Required Documents to Get Approvals from TS-iPASS.</p>
            <table>
                <tr>
                    <th style="text-align: center; ">
                        S.No.
                    </th>
                    <th>
                        Document Type
                    </th>
                    <th>
                        Document Link
                    </th>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        1
                    </td>
                    <td style="color:black;">
                        Common Enclosures
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="docs/CommonEnclosures.pdf">COMMON
                            ENCLOSURES</a></br>
                        <a style="color: Blue;" target="_blank" href="docs/self certification.docx.doc">Self
                            Certification</a></br>
                        <a style="color: Blue;" target="_blank" href="docs/Combined Site Plan.pdf">Combined Site Plan</a></br>
                        <a style="color: Blue;" target="_blank" href="docs/buildingplan.pdf">Detailed Building Plan</a></br>
                        <a style="color: Blue;" target="_blank" href="docs/Mutation Document.pdf">Mutation Copy</a></br>
                        <a style="color: Blue;" target="_blank" href="docs/CoI.pdf">Certificate of Incorporation</a></br>
                        <a style="color: Blue;" target="_blank" href="docs/flowchart.pdf">Process Flow Chart</a>
                    </td>
                </tr>
                <%--<tr>
                    <td style="text-align: center; color:black;">
                        2
                    </td>
                    <td>
                        Common Application Form
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="docs/CAF.pdf">Common Application Form</a>
                    </td>
                </tr>--%>
                <tr>
                    <td style="text-align: center; color:black;">
                        2
                    </td>
                    <td style="color:black;">
                        Self Certification
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="docs/self certification.docx.doc">Self
                            Certification</a>
                    </td>
                </tr>
                <%--<tr>
                    <td style="text-align: center; color:black;">
                        3
                    </td>
                    <td style="color:black;">
                        Grama Panchayat NOC
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="docs/NoC from Gram Panchayat.docx">Grama Panchayat NOC</a>
                    </td>
                </tr>--%>
               
                <tr>
                    <td style="text-align: center; color:black;">
                        2
                    </td>
                    <td style="color:black;">
                        HMDA Enclosures
                    </td>
                    <td>
                        <a style="color: Blue;" href="docs/Additional Enclosures for HMDA.docx">HMDA Enclosures</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        3
                    </td>
                    <td style="color:black;">
                        C5 for Red category
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/C5.pdf">C5 for Red category</a>
                    </td>
                </tr>
                
                <tr>
                    <td style="text-align: center; color:black;">
                        4
                    </td>
                    <td style="color:black;">
                        Comman Application From(CAF)
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/CAF.pdf">Common Application From</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        5
                    </td>
                    <td style="color:black;">
                        HAZARDOUS WASTE FORM
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/form-I for hazardous waste authorisation (1).doc">HAZARDOUS WASTE FORM</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        6
                    </td>
                    <td style="color:black;">
                        TSPCB - B1 Form  ( <span style="color:red">only for red category</span> )
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/Consent for Emissin (Air) Form II - Part B1.pdf">TSPCB - B1 Form</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        7
                    </td>
                    <td style="color:black;">
                        TSPCB - B2 Form ( <span style="color:red">only for red category</span> )
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/Consent for Discharge (Water) Form II - Part B2.pdf">TSPCB - B2 Form</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        8
                    </td>
                    <td style="color:black;">
                        Environment Clearance
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="http://tspcb.cgg.gov.in/Pages/Envclearance.aspx">Environment Clearance</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        9
                    </td>
                    <td style="color:black;">
                        The Shops & Establishments Act - Registration
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/Shops&Establishments-Registraions-CheckList.pdf"> The Shops & Establishments Act - Registration</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        10
                    </td>
                    <td style="color:black;">
                        The Shops & Establishments Act - Renewal
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/Shops&Establishments-Renewal-CheckList.pdf">The Shops & Establishments Act - Renewal</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        11
                    </td>
                    <td style="color:black;">
                        The Building & Other Construction Workers Act
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/BuildingAndOtherConstructionWorkersAct.pdf">The Building & Other Construction Workers Act</a>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align: center; color:black;">
                        12
                    </td>
                    <td style="color:black;">
                        PrincipalEmployerUnderContractLabourAct-Registration
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/BuildingAndOtherConstructionWorkersAct.pdf">PrincipalEmployerUnderContractLabourAct-Registration</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; color:black;">
                        13
                    </td>
                    <td style="color:black;">
                        Principal Employer Registration under<br />Interstate Migrant Workman Act
                    </td>
                    <td>
                       <a style="color: Blue;" target="_blank" href="docs/InterstateMigrant-Principal-Employer_checklist">Principal Employer Registration under<br />Interstate Migrant Workman Act</a>
                    </td>
                </tr>
            </table>
        </div>

                    <div class="dt-sc-hr-invisible"></div>
                </div>

            </div>

            <footer>
                <div class="copyright">
                    <div class="container">
                        <div class="col-1 white">
                            <script type="text/javascript">document.write("&copy; " + new Date().getFullYear() + ". Copyright 2017 Government of Telangana. all rights reserved by Industries Chasing Cell..");</script>
                        </div>
                        <div class="col-2 white">
                          <%--  Designed By <a href="http://www.bitranet.com/" title="Website Designed by BitraNet Pvt. Ltd.," target="_blank">BitraNet</a>--%>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </div>
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

</body>
</html>
