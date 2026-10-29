<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexNew.aspx.cs" Inherits="Default3"
    EnableEventValidation="true" Title=":: TS-iPASS Govenrnment of Telengana :: Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>:: TSiPASS Online Management System ::</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="RURALSKILLS,SKILLS,INDIA,HARDSHELL,MRIGS,HARDSHELL TECHNOLOGIES PVT LTD" />
    <meta name="author" content="HSTPL" />
    <!-- Bootstrap Core CSS -->
    <!-- Bootstrap Core CSS -->
    <link href="Resource/Styles/css/bootstrap.min.css" rel="stylesheet">
    <!-- MetisMenu CSS -->
    <link href="Resource/Styles/css/metisMenu.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="Resource/Styles/css/sb-admin-2.css" rel="stylesheet">
    <!-- Custom Fonts -->
    <link href="Resource/Styles/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css">

    <script type="text/javascript">
        (function(i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function() {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
        ga('create', 'UA-73402997-1', 'auto');
        ga('send', 'pageview');
    </script>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <div id="wrapper">
        <!-- Navigation -->
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 10px">
            <%--<div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>--%>
            <!-- /.navbar-header -->
            <div style="width:100%;" >
               
                    <img class="img-responsive" src="Resource/Images/bgheader.jpg" alt="TS-iPASS" title="TS-iPASS" width="100%" />
               </div>
            <!-- /.navbar-top-links -->
              <%--<div class="navbar-default sidebar" role="navigation">
              <div class="sidebar-nav navbar-collapse">
                    <div class="col-lg-6 col-md-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-home fa-fw fa-3x"></i>
                                    </div>
                                </div>
                            </div>
                            <a href="Index.html" title="Rural Skills" target="_self">
                                <div class="panel-footer">Home</div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-12">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comment fa-sign-in fa-3x"></i>
                                    </div>
                                </div>
                            </div>
                            <a href="Home.aspx" title="MRIGS" target="_self">
                                <div class="panel-footer">Login</div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-12">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-align-center fa-dashboard fa-fw fa-3x"></i>
                                    </div>
                                </div>
                            </div>
                            <a href="Statistics.aspx" title="Rural Skills" target="_blank">
                                <div class="panel-footer">Statistics</div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-12">
                        <div class="panel panel-yellow">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-info-circle fa-fw fa-3x"></i>
                                    </div>
                                </div>
                            </div>
                            <a href="About.html" title="About MRIGS" target="_self">
                                <div class="panel-footer">About</div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 align-center">
                        <div class="panel panel-primary box5">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-2">
                                        <a href="http://52.25.37.223:4040/trac/MrigsSSP" title="Online Ticketing System" target="_blank">
                                            <i class="fa fa-3x"><img src="/Images/mrigs-trac-mini.png" alt="MRIGS-SSP" title="Online Ticketing" height="45" /></i>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <a href="http://52.25.37.223:4040/trac/MrigsSSP" title="Online Ticketing System" target="_blank">
                                <div class="panel-footer">Click Here</div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 align-center">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-th-list fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">MIS</div>
                                    </div>
                                </div>
                            </div>
                            <a href="MisReports.html" title="MIS Reports" target="_blank">
                                <div class="panel-footer">
                                    Click Here
                                </div>
                            </a>
                        </div>
                    </div>
                    <!--<div class="col-lg-6 col-md-12 align-center">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-2 align-center">
                                        <a href="http://www.nird.org.in/" title="NIRD & PR" target="_blank">
                                            <i class="fa fa-3x"><img src="/Images/nird.png" alt="NIRD & PR" title="NIRD & PR" height="65" /></i>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-12 align-center">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-2 align-center">
                                        <a href="http://www.nabcons.com/" title="NABCONS" target="_blank">
                                            <i class="fa fa-3x"><img src="/Images/nabcons.gif" alt="NABCONS" title="NABCONS" height="65" /></i>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>-->
                </div>--%>
                <!-- /.sidebar-collapse 
            </div>-->
            <!-- /.navbar-static-side -->
        </nav>
        <div class="panel panel-heading">
            <div class="row" id="divRowMsg" style="display: none">
                <div class="col-lg-12">
                    <div class="panel panel-warning">
                        <div class="panel-heading" id="divMsg">
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8">
                    <div class="row">
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-check-circle-o fa-3x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <asp:Label runat="server" class="huge" id="lblApplications">
                                                -</asp:Label>
                                            <div>
                                                Total Applications</div>
                                        </div>
                                    </div>
                                </div>
                                <a href="#">
                                    <div class="panel-footer">
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-green">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-list-alt fa-3x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <asp:Label runat="server" class="huge" id="lblApprovals">
                                                -</asp:Label>
                                            <div>
                                               Department Approvals</div>
                                        </div>
                                    </div>
                                </div>
                                <a href="#">
                                    <div class="panel-footer">
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-yellow">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-inr fa-3x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                             <asp:Label runat="server" class="huge" id="lblInvestment">
                                                -</asp:Label>
                                            <div>
                                                Total Investment(Rs. in Crs)</div>
                                        </div>
                                    </div>
                                </div>
                                <a href="#">
                                    <div class="panel-footer">
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-clone fa-3x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                           <asp:Label runat="server" class="huge" id="lblIncentives">
                                                -</asp:Label>
                                            <div>
                                               Incentives Applied </div>
                                        </div>
                                    </div>
                                </div>
                                <a href="#">
                                    <div class="panel-footer">
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-green">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-wpforms fa-3x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="huge" id="divTrained">
                                                -</div>
                                            <div>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                                <a href="#">
                                    <div class="panel-footer">
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-red">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-users fa-3x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="huge" id="divAssessed">
                                                -</div>
                                            <div>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                                <a href="#">
                                    <div class="panel-footer">
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <i class="fa fa-user fa-fw"></i>Login Panel
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="list-group">
                                <form id="Form1" runat="server">
                                <table>
                                    <tr >
                                        <td class="col-lg-3">
                                            <asp:Label ID="Label385" runat="server" CssClass="LBLBLACK" Font-Names="Verdana"
                                                Font-Size="12px">Username:</asp:Label>
                                        </td>
                                        <td class="col-lg-5">
                                            <asp:TextBox ID="txtUserId" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="15" TabIndex="1" ValidationGroup="group" Width="80%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col-lg-3">
                                            <br />
                                            <asp:Label ID="Label382" runat="server" CssClass="LBLBLACK" Font-Names="Verdana"
                                                Font-Size="12px">Password:</asp:Label>
                                        </td>
                                        <td class="col-lg-5">
                                            <br />
                                            <asp:TextBox ID="txtPwd" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="15" TabIndex="1" TextMode="Password" ValidationGroup="group" Width="80%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center;" colspan="2">
                                            <br />
                                            &nbsp;&nbsp;<asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-primary"
                                                Height="28px" OnClick="btnSignIn_Click" TabIndex="10" Text="Login" ValidationGroup="group"
                                                Width="70px" Font-Names="Verdana" Font-Bold="True" Font-Size="12px" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-primary" Height="28px"
                                                OnClick="BtnSave4_Click" TabIndex="10" Text="Cancel" ValidationGroup="group"
                                                Width="70px" Font-Names="Verdana" Font-Bold="True" Font-Size="12px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="lblmsg" runat="server" CssClass="LBLSTATUS" Font-Size="Small" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                </form>
                            </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                </div>
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            TS-iPASS</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-31 col-md-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <div class="row">
                                                <div class="col-xs-3">
                                                    <i class="fa fa-external-link fa-fw fa-3x"></i>
                                                </div>
                                                <div class="col-xs-9 text-right">
                                                    <div style="font-size:18px; vertical-align:middle;" >
                                                        APPROVALS</div>
                                                </div>
                                            </div>
                                        </div>
                                        <a href="docs/CFE and CFO Clearances_Revised.pdf" title="APPROVALS" target="_blank">
                                            <div class="panel-footer">
                                                Click Here</div>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-lg-31 col-md-12">
                                    <div class="panel panel-red">
                                        <div class="panel-heading">
                                            <div class="row">
                                                <div class="col-xs-3">
                                                    <i class="fa fa-comment fa-external-link fa-3x"></i>
                                                </div>
                                                <div class="col-xs-9 text-right">
                                                    <div style="font-size:18px; vertical-align:middle;" >
                                                        INCENTIVES</div>
                                                </div>
                                            </div>
                                        </div>
                                        <a href="IncentiveRegistrationViewDocs.aspx" title="INCENTIVES" target="_blank">
                                            <div class="panel-footer">
                                               Click Here</div>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-lg-31 col-md-12">
                                    <div class="panel panel-green">
                                        <div class="panel-heading">
                                            <div class="row">
                                                <div class="col-xs-3">
                                                    <i class="fa fa-align-center fa-external-link fa-fw fa-3x"></i>
                                                </div>
                                                <div class="col-xs-9 text-right">
                                                    <div style="font-size:18px; vertical-align:middle;" >
                                                        GRIEVANCES</div>
                                                </div>
                                            </div>
                                        </div>
                                        <a href="UI/TSiPASS/GuestGrievance.aspx" title="GRIEVANCES" target="_blank">
                                            <div class="panel-footer">
                                               Click Here</div>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-lg-31 col-md-12">
                                    <div class="panel panel-yellow">
                                        <div class="panel-heading">
                                            <div class="row">
                                                <div class="col-xs-3">
                                                    <i class="fa fa-external-link fa-fw fa-3x"></i>
                                                </div>
                                                <div class="col-xs-9 text-right">
                                                    <div style="font-size:18px; vertical-align:middle;" >
                                                        INSPECTION</div>
                                                </div>
                                            </div>
                                        </div>
                                        <a href="UI/TSiPASS/AddNewInspectionUser.aspx" title="INSPECTION" target="_blank">
                                            <div class="panel-footer">
                                               Click Here</div>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-lg-31 col-md-12">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <div class="row">
                                                <div class="col-xs-3">
                                                    <i class="fa fa-external-link fa-fw fa-3x"></i>
                                                </div>
                                                <div class="col-xs-9 text-right">
                                                    <div style="font-size:18px; vertical-align:middle;" >
                                                        RAW MATERIAL</div>
                                                </div>
                                            </div>
                                        </div>
                                        <a href="UI/TSiPASS/AddnewuserRegistration.aspx" title="RAW MATERIAL" target="_blank">
                                            <div class="panel-footer">
                                               Click Here</div>
                                        </a>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel">
                    <div class="col-lg-12 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <center>
                                    Designed, Developed & Hosted by Commissionerate of Industries,TS-iPASS Cell, © Copyrights and
                                    all rights reserved by TS-iPASS, Govt. of Telangana.</center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /#page-wrapper -->
        </div>
    </div>
    <!-- /#wrapper -->
  
    

</body>
</html>
