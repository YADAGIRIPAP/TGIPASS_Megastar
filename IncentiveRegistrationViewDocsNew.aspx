<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncentiveRegistrationViewDocsNew.aspx.cs" Inherits="IncentiveRegistrationViewDocsNew" %>

<!DOCTYPE html>

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
    </style>
    <script src="js/modernizr-2.6.2.min.js"></script>

    <%-- <script>
        $(document).ready(function () {
            $("#ddd").click(function () {
                $('html, body').animate({
                    scrollTop: $("#vvvvv").offset().top
                }, 2000);
            });
        });
    </script>--%>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="wrapper">
            <div class="inner-wrapper">
                <header>
                    <div class="top-bar">
                        <div class="container">
                            <span id="clock" style="font-size: 12px;"></span>

                            <div class="dt-sc-contact-number">
                                <ul class="dt-sc-social-icons">
                                    <li><span class="fa fa-phone"></span>Call us: 040-23441636</li>
                                    <%--<li><a href="https://www.facebook.com/profile.php?id=100011131938859" target="_blank" title="Facebook"><span class="fa fa-facebook"></span></a></li>
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
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/logo.jpg"></a>
                        </div>
                        <div class="top-head" >
                            <div class="top-img"  style="display:none">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/Revanth Reddy CM.JPG" id="imgcm" runat="server">

                                <h5 class="top-names">Sri. A.Revanth Reddy</h5>
                                <p class="top-names1">Hon'ble Chief Minister</p>
                            </div>
                            <div class="top-img mr0" style="display:none">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/IT Minister.JPG" id="imgitm" runat="server">

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
                                    <li><a href="TSHome.aspx">Home</a></li>
                                    <li><a href="about.aspx">About Us</a></li>
                                    <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">Services</a>
                                        <ul class="sub-menu">
                                            <%--<li><a target="_blank" href="UI/TSiPASS/AmmendamentUserRegistration.aspx">Inspection</a></li>--%>
                                            <li><a target="_blank" href="UI/TSiPASS/frmCFEcertificateProcess.aspx">TS-iPass Verification</a></li>
                                            <%--<li><a target="_blank" href="UI/TSiPASS/AddNewInspectionUser.aspx">Inspection</a></li>--%>
                                           <%-- <li class="menu-item-simple-parent menu-item-depth-0"><a target="_blank" href="#">Incentive</a>
                                                <ul class="sub-menu">
                                                    <li><a target="_blank" href="IncentiveRegistrationViewDocs.aspx">Incentive Check</a></li>
                                                    <li><a target="_blank" href="IpassLogin.aspx">Apply For Incentive</a></li>
                                                </ul>
                                            </li>--%>
                                            <li class="menu-item-simple-parent menu-item-depth-0"><a target="_blank" href="IncentiveRegistrationViewDocsNew.aspx">Incentive</a></li>
                                            <li><a target="_blank" href="UI/TSIPASS/RawMatirialLink.aspx">Raw Material Allocation</a></li>
                                            <li><a target="_blank" href="UI/TSiPASS/GuestGrievance.aspx">Grievance/Feedback</a></li>
                                            <li><a target="_blank" href="UI/TSiPASS/IFCHomepage.aspx">Investor Facilitation Cell</a></li>
                                           <%-- <li><a target="_blank" href="UI/TSiPASS/GuestInsturction.aspx">Bank Loan Application</a></li>--%>
                                            <li><a target="_blank" href="http://udyogaadhaar.gov.in/">Udyog Aadhaar</a></li>
                                            <li><a target="_blank" href="UI/TSiPASS/MisreportDashboard.aspx">Mis Reports</a></li>
                                            <%--<li><a href="ClusterAbstractReportPublic.aspx">Central Inspection Report</a></li>--%>
                                        </ul>
                                    </li>
                                    <li><a href="links.aspx">Related Departments</a></li>
                                    <li ><a href="Information.aspx">Information Wizard</a></li>
                                    <li><a href="Downloads.aspx">Repository of Regulations</a></li>
                                    <li><a href="UseCommentsOnAmmendments.aspx" class="blink_text">Business Regulations</a> </li>
                                     <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">NSWS</a>
                                    <ul class="sub-menu">
                                        <li><a target="_blank" href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/NSWS_Note.pdf">About NSWS</a></li>
                                        <li><a target="_blank" href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Approvals_Covered.pdf">Approvals List</a></li>
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
                
                    <div class="container">
                      <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i></i><a href="Home.aspx">Home</a></li>
                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                    <li class="active"><i ></i>Incentive
                    </li>
                </ol>
            </div>
                        <section id="primary" class="page-with-sidebar with-right-sidebar" style="width: 105%">

                            <%-- <h3>Important Links</h3>--%>
                            <div class="panel-group" id="accordion">

                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h1 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#Div1">General Information</a>
                                        </h1>
                                    </div>
                                    <div id="Div1" class="panel-collapse collapse" style="height: auto;">
                                        <div class="panel-body">
                                            <div class="container">
                                                <section id="primary2" class="page-with-sidebar with-right-sidebar">
                                                    <h4>Note:</h4>

                                                    <div class="dt-sc-hr-invisible-very-small"></div>

                                                    <div class="column">
                                                        <ul class="dt-sc-fancy-list chocolate check-circle">
                                                            <li><span>Large Industries are not Eligible for Land Conversion Incentive</span></li>
                                                            <li><span>Projects Proposed to be set up under T-PRIDE in Municipal Corporation limits of
                                                                                    Greater Hyderabad shall obtain pollution clearances where ever neccessary</span></li>
                                                            <li><span>Textile Units other than Large industries may select Sector type as Manufacture
                                                                                    for applying eligible Incentives</span></li>
                                                            <li><span>For service sector enter Equipment Value, for others enter Plant & Machinery Value</span></li>
                                                        </ul>
                                                       
                                                     <h4>The limit for investment in plant and machinery/equipment for manufacturing / service
                                                                            enterprises are as under:</h4>
                                                    </div>
                                                    
                                                </section>
                                                <table>
                                                    <tr>
                                                        <td align="center" style="padding: 5px; margin: 5px" colspan="3">
                                                            <div>
                                                                <table style="width: 100%; padding: 5px;" cellpadding="2" cellspacing="4">
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <table style="width: 100%; padding: 5px;" cellpadding="3" cellspacing="4" border="1">
                                                                                <tr>
                                                                                    <th class="paddingleft">Enterprises
                                                                                    </th>
                                                                                    <th class="paddingleft">Type
                                                                                    </th>
                                                                                    <th class="paddingleft">Investment in plant & machinery/equipment
                                                                                    </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Micro Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">Does not exceed 25 lakh rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">Does not exceed 10 lakh rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Small Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 25 lakh rupees but does not exceed 5 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 10 lakh rupees but does not exceed 2 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Medium Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 5 crore rupees but does not exceed 10 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 2 crore rupees but does not exceed 5 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Large Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 10 crore rupees but does not exceed 200 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">-
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Mega Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 200 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">-
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseTWNTYNine" class="collapsed">View Eligible incentive for your business /industry</a>
                                        </h4>
                                    </div>
                                    <div id="collapseTWNTYNine" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <div class="container">
                                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px">1
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label376" runat="server" CssClass="LBLBLACK" Width="165px">Caste<font color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                        <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" Height="32px"
                                                                            Width="180px" TabIndex="1">
                                                                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                                                                            <asp:ListItem Value="1">General</asp:ListItem>
                                                                            <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                            <asp:ListItem Value="3">SC</asp:ListItem>
                                                                            <asp:ListItem Value="4">ST</asp:ListItem>
                                                                            <asp:ListItem Value="5">Others</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                                                            ControlToValidate="ddlCaste" Display="None" InitialValue="-- SELECT --"
                                                                            ErrorMessage="Please Select Caste" ValidationGroup="group">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px">3
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Type of Sector<font color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                        <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" Height="32px"
                                                                            Width="180px" TabIndex="3">
                                                                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                                                                            <asp:ListItem Value="1">Service</asp:ListItem>
                                                                            <asp:ListItem Value="2" Selected="True">Manufacture</asp:ListItem>
                                                                            <asp:ListItem Value="3">Textiles</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSector"
                                                                            Display="None" ErrorMessage="Please Select Sector" ValidationGroup="group" InitialValue="-- SELECT --"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px">5
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Is Physically Handicapped</asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:CheckBox ID="cbphysicalHandicapped" runat="server" Text="Yes" TabIndex="5" />
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">I) Services</asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RadioButtonList ID="rblVehicleIncetive" runat="server" TabIndex="7" >
                                                                            <asp:ListItem Value="1">Transport allied activities</asp:ListItem>
                                                                            <asp:ListItem Value="0" Selected="True">Other Service Sector</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 27px">
                                                            <span style="padding: 10px;"></span>
                                                        </td>
                                                        <td valign="top" align="center">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px" class="style5">2
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="165px">Category
 <font color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 192px;" colspan="2">
                                                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="32px"
                                                                            Width="200px" TabIndex="2">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlCategory"
                                                                            Display="None" ErrorMessage="Please Select Category" ValidationGroup="group"
                                                                            InitialValue="-- SELECT --"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px" class="style5">4
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="165px">Entreprenuer Type</asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px" colspan="2">
                                                                        <asp:RadioButtonList ID="rblSelection" runat="server" Width="260px" CellPadding="0"
                                                                            CellSpacing="0" TabIndex="4">
                                                                            <asp:ListItem Value="1" Selected="True">New / Existing</asp:ListItem>
                                                                            <asp:ListItem Value="2">Expansion / Diversification</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="style5">6
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Municipal Corporation</asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px" colspan="2">
                                                                        <asp:RadioButtonList ID="rblGHMC" runat="server" TabIndex="6">
                                                                            <asp:ListItem Value="0" Selected="True">GHMC & Other municipal corporations in the state</asp:ListItem>
                                                                            <asp:ListItem Value="1">Other areas in the state</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                            <%--<asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary"
                                                                OnClick="btnSubmit_Click" TabIndex="8" OnClientClick="ShowIncentiveGrid();" Text="Show Eligible Incentives" ValidationGroup="group"
                                                                 />--%>
                                                            <input type ="button" class="btn btn-primary" style="padding: 17px 25px;border: 1px solid #FFFFFF;font-weight: 600;text-transform: uppercase;-webkit-box-shadow: 0px 0px 0px 2px #8d1812;box-shadow: 0px 0px 0px 2px #8d1812;" onclick="ShowIncentiveGrid();" tabindex="8" id="btnClick" value="Show Eligible Incentives" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                           <%-- <asp:Button ID="btnApplyIncentives" runat="server" Height="45px"
                                                                TabIndex="8" Text="Apply For Incentives" PostBackUrl="~/IpassLogin.aspx" class="blink_text"
                                                                Width="180px" />--%>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <br />
                                                            
                                                            <br />

                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" visible="false">
                                                        <td align="center" colspan="3"
                                                            style="padding: 5px; margin: 5px; text-align: center;">
                                                            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/UI/TSiPASS/SanctionedIncentives.aspx" runat="server" Font-Size="Large" Target="_blank">Industry wise Incentives Sanctioned by SLC</asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr id="trdipc" runat="server" visible="false">
                                                        <td align="center" colspan="3"
                                                            style="padding: 5px; margin: 5px; text-align: center;">
                                                            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/TSiPASS/SanctionedIncentivesDCIP.aspx" runat="server" Font-Size="Large" Target="_blank">Industry wise Incentives Sanctioned by DIPC</asp:HyperLink></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True" ShowSummary="true"
                                                                ValidationGroup="group" HeaderText="Please select Mandatory fields." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;"
                                                            valign="top">
                                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                                                CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                                Width="100%" OnRowDataBound="grdDetails_RowDataBound" BorderColor="Black">
                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="IncentiveType" HeaderText="Incentive Type" />
                                                                    <asp:BoundField DataField="IncentiveName" HeaderText="Eligible Incentive" />
                                                                    <asp:TemplateField HeaderText="Documents to be filled">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="lbt" runat="server" Text='<%# Eval("DocName") %>' NavigateUrl='<%# Eval("FilePath") %>'
                                                                                Target="_blank" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                <EditRowStyle BackColor="#B9D684" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="3">
                                                            <div id="IncentiveGrid">

                                                            </div>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default" runat="server" visible="false">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <%--  <a data-toggle="collapse" data-parent="#accordion" href="#Div2" class="collapsed">User Manual</a>--%>
                                            <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Incentivesmanual.pdf" target="_blank">User Manual</a>
                                            <%--<asp:HyperLink ID="HyperLink2" NavigateUrl="~/docs/Incentivesmanual.pdf" ForeColor="Green" Font-Bold="true" runat="server" Font-Size="Large" Target="_blank">Incentives User Manual</asp:HyperLink>--%>
                                        </h4>
                                    </div>
                                    <div id="Div2" class="panel-collapse collapse">
                                        <div class="panel-body">
                                            <div class="container">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a href="IpassLogin.aspx" target="_blank">Apply for incentives</a>
                                        </h4>
                                    </div>
                                </div>
                                <div class="dt-sc-hr-invisible-very-small"></div>
                        </section>
                        <div class="dt-sc-hr-invisible">
                        </div>
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
                            <a href="UI/TSIPASS/Privacypolicy.aspx" title="Privacy Policy" target="_blank">Privacy</a>
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
    </form>
    <script src="UI/TSIPASS/assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="UI/TSIPASS/assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="UI/TSIPASS/assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="UI/TSIPASS/assets/js/custom.js"></script>
    <link href="UI/TSIPASS/assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="UI/TSIPASS/assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="UI/TSIPASS/assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="UI/TSIPASS/assets/css/custom.css" rel="stylesheet" />
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

    <script type="text/javascript">

        //added by chinna
           $("#Label4,#rblVehicleIncetive").css("display", "none"); $("#ddlCaste").change(function () { changeValue(); }); $("#ddlSector").change(function () { changeValue(); }); $("#cbphysicalHandicapped").change(function () { changeValue(); }); function changeValue() {
               $("#Label4,#rblVehicleIncetive").css("display", "none"); if (($("#ddlCaste").val() == "3" || $("#ddlCaste").val() == "4" || $("#cbphysicalHandicapped").is(":checked")) && $("#ddlSector").val() == "1")
               { $("#Label4,#rblVehicleIncetive").css("display", "block"); }
           }
           function ShowIncentiveGrid() {
               var caste = $("#ddlCaste").val(); var sector = $("#ddlSector").val(); var category = $("#ddlCategory").val(); var message = ""; if (caste == 0 && sector == 0 && category == "-- SELECT --")
               { var message = "Please Select Caste \nPlease Select Category \nPlease Select Type of Sector"; } else
                   if (caste == 0 && sector == 0) { var message = "Please Select Caste \nPlease Select Category"; } else
                       if (caste == 0 && category == "-- SELECT --") { var message = "Please Select Caste  \nPlease Select Type of Sector"; } else
                           if (sector == 0 && category == "-- SELECT --") { var message = "Please Select Category \nPlease Select Type of Sector"; } else
                               if (caste == 0) { var message = "Please Select Caste"; } else
                                   if (sector == 0) { var message = "Please Select Type of Sector"; } else
                                       if (category == "-- SELECT --") { var message = "Please Select Type of Sector"; }
               if (message != "") { alert(message); return false; }
               else {
                   var rblGHMC = $("[id$=rblGHMC] input:checked"); var rblSelection = $("[id$=rblSelection] input:checked"); var rblVehicleIncetive = $("[id$=rblVehicleIncetive] input:checked"); var strData = JSON.stringify({ "caste": $("#ddlCaste").val(), "sector": $("#ddlSector").val(), "rblGHMC": rblGHMC.val() == "0" ? true : false, "rblSelection": rblSelection.val(), "Category": $("#ddlCategory").val(), "IsCheck": $("#cbphysicalHandicapped").is(":checked") ? true : false, "rblVechicleInc": rblVehicleIncetive.val() == "1" ? true : false })
                   $('#IncentiveGrid').html(''); $.ajax({
                       type: "POST", contentType: "application/json; charset=utf-8", url: "IncentiveRegistrationViewDocsNew.aspx/GetDetails", dataType: "json", data: strData, success: function (data) {
                           if (data.d.length > 0) {
                               var count = data.d.length; var table = $('<table id="tblGrid" colspan="3" style="color:#333333;border-color:Black; height:62px;width:100 %;border-collapse:collapse;"></table>'); var th = $('<tr class="GRDHEADER" style= "color:White;background-color:#013161;font-weight:bold;" > <th scope="col">Incentive Type</th> <th scope="col" style="text-align:center;">Eligible Incentive</th> <th scope="col">Documents to be filled</th></tr >'); table.append(th); for (var i = 0; i < count; i += 1) { var tr = $('<tr class="GRDHEADER"><td style="border-right-color: rgb(204, 204, 204);border-right-style: solid;border-right-width: 1px;border-left-color: rgb(204, 204, 204);border-left-style: solid;border-left-width: 1px;">' + data.d[i]["IncentiveType"] + '</td><td style="border-right-color: rgb(204, 204, 204);border-right-style: solid;border-right-width: 1px;border-left-color: rgb(204, 204, 204);border-left-style: solid;border-left-width: 1px;">' + data.d[i]["IncentiveName"] + '</td><td style="border-right-color: rgb(204, 204, 204);border-right-style: solid;border-right-width: 1px;border-left-color: rgb(204, 204, 204);border-left-style: solid;border-left-width: 1px;"><a style="color:#428bca;" id="grdDetails_ctl02_lbt" href=' + data.d[i]["FilePath"] + ' target="_blank">' + data.d[i]["DocName"] + '</a></td></tr>'); table.append(tr); }
                               $('#IncentiveGrid').append(table); MergeCommonRows($('#tblGrid'));
                           } else { var table = "<table><tr><td style='background-color:#FEF8B6; font-weight:bold; color:Black;'>Incentives are not available for this criteria.</td></tr></table>"; $('#IncentiveGrid').append(table); }
                           return false;
                       }, error: function (e)
                       { console.log(e); }
                   });
               }
           }
        function MergeCommonRows(table) { var firstColumnBrakes = []; for (var i = 1; i <= table.find('th').length; i++) { var previous = null, cellToExtend = null, rowspan = 1; table.find("td:nth-child(" + i + ")").each(function (index, e) { var jthis = $(this), content = jthis.text(); if (previous == content && content !== "" && $.inArray(index, firstColumnBrakes) === -1) { jthis.addClass('hidden'); cellToExtend.attr("rowspan", (rowspan = rowspan + 1)); } else { if (i === 1) firstColumnBrakes.push(index); rowspan = 1; previous = content; cellToExtend = jthis; } }); } $('td.hidden').remove();}
       
    </script>
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


    <script type="text/javascript">        var lsjQuery = jQuery;</script>
    <script type="text/javascript">        lsjQuery(document).ready(function () { if (typeof lsjQuery.fn.layerSlider == "undefined") { lsShowNotice('layerslider_2', 'jquery'); } else { lsjQuery("#layerslider_2").layerSlider({ responsiveUnder: 1240, layersContainer: 1170, skinsPath: 'js/layerslider/skins/' }) } }); </script>
    <a href="#" title="Go to Top" class="back-to-top"><span class="fa fa-angle-up"></span>
    </a>
    <!-- GOOGLE FONTS-->
</body>
</html>
