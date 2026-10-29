<%@ Page Language="C#" AutoEventWireup="true" CodeFile="links.aspx.cs" Inherits="Gallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en-gb" class="no-js">
<head>

    <meta http-equiv="content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>:: TS-iPASS ::</title>
    <meta name="description" content="">
    <meta name="author" content="">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/shortcodes.css" rel="stylesheet" type="text/css">
    <link href="css/responsive.css" rel="stylesheet" type="text/css">
    <link rel='stylesheet' href="css/layerslider.css" type='text/css' media='all' />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="skins/maroon/style.css" rel="stylesheet" media="all" />

    <link href='http://fonts.googleapis.com/css?family=Merriweather:400,900italic,900,700italic,700,400italic,300italic,300' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Domine:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Noto+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>
    <style>

            /*ul#menu-main-menu a {
    font-size: 70% !important;
    font-weight: 900;
}*/
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
    </style>
    <script src="js/modernizr-2.6.2.min.js"></script>
    <script>
        function UserDeleteConfirmation() {
            return confirm("This is external link. Are you sure you want to continue?");
        }
    </script>
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
                                <%--<li><a href="#" title="Facebook"><span class="fa fa-facebook"></span></a></li>
                                <li><a href="#" title="Google Plus"><span class="fa fa-google-plus"></span></a></li>
                                <li><a href="#" title="Youtube"><span class="fa fa-youtube"></span></a></li>--%>
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
                                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/Revanth Reddy CM.JPG" id="imgcm" runat="server">
                                            <h5 class="top-names">Sri. A.Revanth Reddy</h5>
                                            <p class="top-names1">
                                                Hon'ble Chief Minister
                                            </p>
                                        </div>
                                        <div class="top-img mr0">
                                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/IT Minister.JPG" id="imgitm" runat="server">
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
                                <li ><a href="TSHome.aspx">Home</a></li>
                                <li ><a href="about.aspx">About Us</a></li>
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
                                     <li class="current_page_item"><a href="links.aspx">Related Departments</a></li>
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
                        <h1>Related Departments </h1>
                        <div class="breadcrumb">
                            <a href="TSHome.aspx">Home </a>
                            <span class="current">Related Departments</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container">

                <%-- <h2 style="padding-bottom: 4px; border-bottom: 1px solid #ddd;">List of related Departments</h2>--%>

                <%--<table>
                <tr>
                    <th style="text-align: center;">
                        S.No.
                    </th>
                    <th>
                        Name of the Department
                    </th>
                    <th>
                        Address
                    </th>
                    <th>
                        Website Address
                    </th>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        1
                    </td>
                    <td>
                        Commissioner of Industries and Commerce
                    </td>
                    <td>
                        Commissioner of Industries,<br />
                        Chirag Ali Lane, Abids,<br />
                        Hyderabad - 500 001<br />
                        Phone : 91-040-23441666<br />
                        Fax : 91-040-23441611<br />
                        Help Line : 7306-600-600<br />
                        Email: ipass.telangana@gmail.com<br />
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="industries.telangana.gov.in">industries.telangana.gov.in</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        2
                    </td>
                    <td>
                        Boilers Department
                    </td>
                    <td>
                        Director of Boilers,
                        <br />
                        Shivam Road,
                        <br />
                        Hyderabad, Telangana 500007.
                        <br />
                        Email: dob_boilers@telangana.gov.in
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="tsboilers.cgg.gov.in">tsboilers.cgg.gov.in</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        3
                    </td>
                    <td>
                        Chief Commissioner of Land Administration (LA)
                    </td>
                    <td>
                        CCLA, Nampally Station Road Abids,<br />
                        Hyderabad, Telangana 500001.
                        <br />
                        Phone: 040 23200027.<br />
                        Email: ccla@telangana.gov.in
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="ccla.telangana.gov.in">ccla.telangana.gov.in</a><br />
                        <a style="color: Blue;" target="_blank" href="webland.telangana.gov.in">webland.telangana.gov.in</a><br />
                        <a style="color: Blue;" target="_blank" href="mabhoomi.telangana.gov.in">mabhoomi.telangana.gov.in</a><br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        4
                    </td>
                    <td>
                        Chief Electrical Inspector to Government (CEIG)
                    </td>
                    <td>
                        CEIG, Khairatabad, Hyderabad, Telangana 500004
                        <br />
                        Phone: 040-23450367
                        <br />
                        Email: ceig.telangana@gmail.com
                    </td>
                    <td>
                        --
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        5
                    </td>
                    <td>
                    Commercial Taxes Department
                    </td>
                    <td>
                        Commissioner Commercial Taxes,1st Floor,
                        <br />
                        Gagan Vihar, Gyan Bagh Colony, Goshamahal,
                        <br />
                        Nampally, Hyderabad, Telangana 500001<br />
                        Phone :
                        <br />
                        Email:
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="http://www.tgct.gov.in">tgct.gov.in</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        6
                    </td>
                    <td>
                        Mutation
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="docs/Mutation Document.pdf">Mutation Copy</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        7
                    </td>
                    <td>
                        Certificate of Incorporation
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="docs/CoI.pdf">Certificate of Incorporation</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        8
                    </td>
                    <td>
                        Flow Chart
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="docs/flowchart.pdf">Process Flow Chart</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        9
                    </td>
                    <td>
                        HMDA Enclosures
                    </td>
                    <td>
                        <a style="color: Blue;" href="docs/Additional Enclosures for HMDA.docx">HMDA Enclosures</a>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        10
                    </td>
                    <td>
                        C5 for Red category
                    </td>
                    <td>
                        <a style="color: Blue;" target="_blank" href="docs/C5.pdf">C5 for Red category</a>
                    </td>
                </tr>
            </table>--%>
                <table cellspacing="0" border="1">
                    <tr>
                        <td style="min-width: 50px; color: black; font-weight: bold">S.No.
                        </td>
                        <td style="min-width: 50px; color: black; font-weight: bold">Name of the Department
                        </td>
                        <td style="min-width: 50px; color: black; font-weight: bold">Address
                        </td>
                        <%--<td style=min-width:50px>Phone</td>
						<td style=min-width:50px>E-mail</td>--%>
                        <td style="min-width: 50px; color: black; font-weight: bold">Website Address
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">1
                        </td>
                        <td style="min-width: 50px; color: black;">Boilers Department
                        </td>
                        <td style="min-width: 50px; color: black;">Director of Boilers,
                        <br />
                            Shivam Road, Hyderabad, Telangana 500007.
                        <br />
                            <font color="Blue">Email: dob_boilers@telangana.gov.in</font><br />
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://tgboilers.cgg.gov.in/home.do">tgboilers.cgg.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">2
                        </td>
                        <td style="min-width: 50px; color: black;">Chief Commissioner of Land Administration (LA)
                        </td>
                        <td style="min-width: 50px; color: black;">CCLA,
                        <br />
                            Nampally Station Road Abids, Hyderabad, Telangana 500001.<br />
                            <font color="Blue">Phone: 040 23200027.
                            <br />
                                Email: ccla@telangana.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://ccla.telangana.gov.in/Welcome.do">ccla.telangana.gov.in</a>
                            <br />
                            <a style="color: Blue;" target="_blank" href="http://webland.telangana.gov.in/">webland.telangana.gov.in</a>
                            <br />
                            <a style="color: Blue;" target="_blank" href="http://mabhoomi.telangana.gov.in/">mabhoomi.telangana.gov.in</a>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">3
                        </td>
                        <td style="min-width: 50px; color: black;">Chief Electrical Inspector to Government (CEIG)
                        </td>
                        <td style="min-width: 50px; color: black;">CEIG,
                        <br />
                            Khairatabad, Hyderabad, Telangana 500004.<br />
                            <font color="Blue">Phone: 040-23450367.
                        <br />
                                Email: ceig.telangana@gmail.com</font>
                        </td>
                        <td style="min-width: 50px; color: black;">--
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">4
                        </td>
                        <td style="min-width: 50px; color: black;">Commercial Taxes Department
                        </td>
                        <td style="min-width: 50px; color: black;">Commissioner Commercial Taxes,<br />
                            1st Floor, Gagan Vihar, Opposite Gandhi Bhavan, Nampally,
                        Gyan Bagh Colony, Goshamahal, Nampally, Hyderabad, Telangana 500001<br />
                            <font color="Blue">Phone: 040-24732351<br />
                                Email: tg_cct@tgct.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="https://tgct.gov.in/tgportal/">tgct.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">5
                        </td>
                        <td style="min-width: 50px; color: black;">Commissioner & Director of Municipal Administration (CDMA)
                        </td>
                        <td style="min-width: 50px; color: black;">Commissioner & Director of Municipal Administration Department
                        <br />
                            640, AC Guards, MasabTank
                        Opp PTI Building Hyderabad 500 004.<br />
                            <font color="Blue">Phone: 040 23302150
                            <br />
                                Email: cdma@telangana.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://www.cdma.telangana.gov.in/">cdma.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">6
                        </td>
                        <td style="min-width: 50px; color: black;">Directorate of Town & Country Planning
                        </td>
                        <td style="min-width: 50px; color: black;">DTCP,
                        <br />
                            3rd to 5th Floors, 640, AC Guards, Opp: PTI Building, Hyderabad - 500004
                        <br />
                            <font color="Blue">Phone:
                        040 23314622
                            <br />
                                Email: dtcp@telangana.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://dtcp.telangana.gov.in">dtcp.telangana.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">7
                        </td>
                        <td style="min-width: 50px; color: black;">Drugs Control Administration (DCA)
                        </td>
                        <td style="min-width: 50px; color: black;">Director,Drugs Control Administration,
                        <br />
                            Vengalrao Nagar, Hyderabad - 500 038 
                        <font color="Blue">Phone: 040 23713563
                            <br />
                            Email: dg_dca@telangana.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://dca.telangana.gov.in">dca.telangana.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">8
                        </td>
                        <td style="min-width: 50px; color: black;">Factories Department
                        </td>
                        <td style="min-width: 50px; color: black;">Director of Factories,
                        <br />
                            5th floor, 'B' Block, B.R.K.R. Bhavan, Hyderabad - 500 063
                        <br />
                            <font color="Blue">Phone: 040 23261306
                            <br />
                                Email: jcifhyd-ts@gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="https://tgfactories.cgg.gov.in/home.do">tgfactories.cgg.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">9
                        </td>
                        <td style="min-width: 50px; color: black;">Forest Department
                        </td>
                        <td style="min-width: 50px; color: black;">PRL. CHIEF CONSERVATOR OF FORESTS (HoFF),<br />
                            Telangana, ARANYA BHAVAN, SAIFABAD, HYDERABAD.<br />
                            <font color="Blue">Phone: 040 23231538
                            <br />
                                Email: prlccf_hf_tsfd@telangana.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://forests.telangana.gov.in/">forest.telangana.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">10
                        </td>
                        <td style="min-width: 50px; color: black;">Greater Hyderabad Municipal Corporation
                        </td>
                        <td style="min-width: 50px; color: black;">Greater Hyderabad Municipal Corporation,
                        <br />
                            CC Complex Tank Bund Road, Lower Tank Bund Hyderabad: 500063<br />
                            <font color="Blue">Phone: 040-23224564<br />
                                Email: commissionerghmc2013@gmail.com</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://www.ghmc.gov.in">ghmc.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">11
                        </td>
                        <td style="min-width: 50px; color: black;">Ground Water Department (GW)
                        </td>
                        <td style="min-width: 50px; color: black;">GW Department,
                        <br />
                            Chintal, Hyderabad, Telangana 500004
                        </td>

                        <td style="min-width: 50px; color: black;">--
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">12
                        </td>
                        <td style="min-width: 50px; color: black;">Hyderabad Metropolitan Development Authority (HMDA)
                        </td>
                        <td style="min-width: 50px; color: black;">Metropolitan Commissioner,<br />
                            Block A, District commercial complex,, Tarnaka, Hyderabad,
                        Telangana 500007<br />
                            <font color="Blue">Phone: 040 27003313
                            <br />
                                Email: mc@hmda.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://www.hmda.gov.in">hmda.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">13
                        </td>
                        <td style="min-width: 50px; color: black;">Hyderabad Metropolitan Water Supply & Sewerage Board (HMWSSB)
                        </td>
                        <td style="min-width: 50px; color: black;">HMWSSB,<br />
                            Khairatabad, Hyderabad - 500004<br />
                            <font color="Blue">Phone: 040 23442844,100 / 101
                            <br />
                                Email: mdhmwssb@hyderabadwater.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://www.hyderabadwater.gov.in">hyderabadwater.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">14
                        </td>
                        <td style="min-width: 50px; color: black;">Irrigation Department
                        </td>
                        <td style="min-width: 50px; color: black;">Irrigation Department<br />
                            j Block, 6Th Floor, Room No :-623, Secretariat Road, Opp BRKR Building, Hyderabad,
                        Telangana 500022
                        <br />
                            <font color="Blue">Phone:040 2339 0411</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://irrigation.telangana.gov.in/icad/home">irrigation.telangana.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">15
                        </td>
                        <td style="min-width: 50px; color: black;">Kakatiya Urban Development Authority (KUDA)
                        </td>
                        <td style="min-width: 50px; color: black;">Kakatiya Urban Development Authority
                        <br />
                            Beside Ashoka Hotel, H.No: 6-1-240, Hanamkonda
                        Warangal- 506001
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://www.kuda.in">kuda.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">16
                        </td>
                        <td style="min-width: 50px; color: black;">Labour Department
                        </td>
                        <td style="min-width: 50px; color: black;">Labour Commissioner,
                        <br />
                            1-1-18/73, Anjaiah Sankshema Bhavan, RTC Cross Road, Hyderabad,
                        Telangana 500020<br />
                            <font color="Blue">Phone: 040 27611437
                            <br />
                                Email: col@telangana.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://labour.telangana.gov.in/">labour.telangana.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">17
                        </td>
                        <td style="min-width: 50px; color: black;">Law Department
                        </td>
                        <td style="min-width: 50px; color: black;">Secretary to Government,
                        <br />
                            Legal Affairs, Legislative Affairs and Justice, Law Department,
                        A-Block, III Floor, T.S. Secretariat Buildings, HYDERABAD 500 022
                        <br />
                            <font color="Blue">Phone: 040-23450476<br />
                                Email: ts.lawsecretary@gmail.com</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://law.telangana.gov.in/">law.telangana.gov.in</a><br />
                            <a style="color: Blue;" target="_blank" href="http://www.ecourts.gov.in/telangana">ecourts.gov.in/telangana</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">18
                        </td>
                        <td style="min-width: 50px; color: black;">Panchayati Raj & Rural Development (PR & RD)
                        </td>
                        <td style="min-width: 50px; color: black;">Commissioner of Panchayati Raj,
                        <br />
                            Himayat Nagar, Hyderabad<br />
                            <font color="Blue">Phone: 040 23226653</font>
                        </td>
                        <td style="min-width: 50px; color: black;">--
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">19
                        </td>
                        <td style="min-width: 50px; color: black;">Registrations & Stamps (R&S) Department
                        </td>
                        <td style="min-width: 50px; color: black;">Commissioner & Inspector General (Registration & Stamps),
                        <br />
                            Mallakunta, Hyderabad,
                        Telangana 500095
                        <br />
                            <font color="Blue">Phone: 040-23449157
                            <br />
                                Email: cig@igrs.telangana.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="https://registration.telangana.gov.in">registrations.telangana.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">20
                        </td>
                        <td style="min-width: 50px; color: black;">Telangana State Disaster Response and Fire Services Department
                        </td>
                        <td style="min-width: 50px; color: black;">Telangana State Disaster Response & Fire Services,
                        <br />
                            BRKR BHAVAN, 1st Floor, 'B' Block, Tank Bund,
                        Near GHMC, Hyderabad-500063.
                        <br />
                            <font color="Blue">Phone: 040 23442944 / 23442955<br />
                                Email: ts_firechief@yahoo.com</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://fire.telangana.gov.in/">tgfire.cgg.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">21
                        </td>
                        <td style="min-width: 50px; color: black;">Telangana State Industrial Infrastructure Corporation Limited
                        </td>
                        <td style="min-width: 50px; color: black;">Telangana State Industrial Infrastructure Corporation Limited<br />
                            6th Floor, Parisrama Bhavan, Fateh Maidan Road, Basheerbagh Hyderabad – 500 004
                        <br />
                            <font color="Blue">Phone: 040 23230234<br />
                                Email: vcmd@tsiic.telangana.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://www.tsiic.telangana.gov.in">tsiic.telangana.gov.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">22
                        </td>
                        <td style="min-width: 50px; color: black;">Telangana State Northern Power Distribution Company Limited (TSNPDCL)
                        </td>
                        <td style="min-width: 50px; color: black;">Managing Director, TSNPDCL,
                        <br />
                            H.No: 2-5-31/2, Corporate Office, Vidyut Bhavan, Nakkalgutta,
                        Hanamkonda, Warangal-506001<br />
                            <font color="Blue">Phone: 0870-2461501
                            <br />
                                Email: cmd@tsnpdcl.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://www.tsnpdcl.in">tsnpdcl.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">23
                        </td>
                        <td style="min-width: 50px; color: black;">Telangana State Pollution Control Board
                        </td>
                        <td style="min-width: 50px; color: black;">Telangana State Pollution Control Board<br />
                            Member Secretary, A-3, Paryavaran Bhavan, Sanath Nagar Rd, Sanath Nagar Industrial
                        Estate,Sanath Nagar, Hyderabad, Telangana 500018<br />
                            <font color="Blue">Phone: 040 23887500
                            <br />
                                Email: ts_ms@pcb.ap.gov.in</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="http://tspcb.cgg.gov.in">tspcb.cgg.gov.in</a><br />
                            <a style="color: Blue;" target="_blank" href="http://tsocmms.nic.in">tsocmms.nic.in</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; color: black;">24
                        </td>
                        <td style="min-width: 50px; color: black;">Telangana State Southern Power Distribution Company Limited (TSSPDCL)
                        </td>
                        <td style="min-width: 50px; color: black;">Managing Director, TSSPDCL,
                        <br />
                            Corporate Office : # 6-1-50, Mint Compound, HYDERABAD-500
                        063<br />
                            <font color="Blue">Phone: 040 23431018
                            <br />
                                Email: cmd@tssouthernpower.com</font>
                        </td>
                        <td style="min-width: 50px; color: black;">
                            <a style="color: Blue;" target="_blank" href="https://tgsouthernpower.org">tgsouthernpower.org</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;">25
                        </td>
                        <td style="min-width: 50px; color: black;">Commissioner of Industries and Commerce
                        </td>
                        <td style="min-width: 50px; color: black;">Commissioner of Industries,<br />
                            Chirag Ali Lane, Abids,<br />
                            Hyderabad - 500 001<br />
                            <font color="Blue">Phone : 91-040-23441666<br />
                                Fax : 91-040-23441611<br />
                                Help Line : 7306-600-600<br />
                                Email: ipass.telangana@gmail.com<br />
                            </font>
                        </td>
                        <td>
                            <a style="color: Blue;" target="_blank" href="http://industries.telangana.gov.in/">industries.telangana.gov.in</a>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="dt-sc-hr-invisible"></div>
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
