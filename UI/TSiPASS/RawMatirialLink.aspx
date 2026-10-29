<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="RawMatirialLink.aspx.cs" Inherits="RawMatirialLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <meta http-equiv="content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>TS-iPASS</title>
    <meta name="description" content="">
    <meta name="author" content="">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/shortcodes.css" rel="stylesheet" type="text/css" />
    <link href="css/responsive.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/layerslider.css" type="text/css" media="all" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="skins/maroon/style.css" rel="stylesheet" media="all" />

    <link href='http://fonts.googleapis.com/css?family=Merriweather:400,900italic,900,700italic,700,400italic,300italic,300' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Domine:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Noto+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>

    <script src="js/modernizr-2.6.2.min.js"></script>
    <style>
        .blink_text {

    animation:1s blinker linear infinite;
    -webkit-animation:1s blinker linear infinite;
    -moz-animation:1s blinker linear infinite;

     color: white;
     background-color: red;
    }

    @-moz-keyframes blinker {  
     0% { opacity: 1.0; }
     50% { opacity: 0.5; }
     100% { opacity: 10.5; }
     }

    @-webkit-keyframes blinker {  
     0% { opacity: 1.0; }
     50% { opacity: 0.5; }
     100% { opacity: 10.5; }
     }

    @keyframes blinker {  
     0% { opacity: 1.0; }
     50% { opacity: 0.5; }
     100% { opacity: 10.5; }
     }
    </style>
     <div id="main">
               <%-- <div class="breadcrumb-section">
                    <div class="container">
                        <h1>Raw Material Allocation</h1>
                        <div class="breadcrumb">
                           <span>You are here </span> <a href="TSHome.aspx">Home </a>
                            <span class="current">Raw Material Allocation</span>
                        </div>
                    </div>
                </div>--%>
                <div class="container" align="left">
                    <section id="primary" class="page-with-sidebar with-right-sidebar">
                        <h3>New Registration</h3>
                        <div>
                            <asp:ImageButton ID="btnnewregistration"   ImageUrl="/images/registernow.jpg" PostBackUrl="~/UI/TSiPASS/AddnewuserRegistration.aspx" runat="server" Width="178px" />
                        </div>
                        <h3>Already have an account in TG-Ipass</h3>
                        <div>
                            <asp:ImageButton ID="ImageButtonlogin" ImageUrl="~/Click_here_to_Login_Button.png" PostBackUrl="~/IpassLogin.aspx" runat="server" Width="179px" Height="50px" />
                        </div>
                        <div class="dt-sc-hr-invisible-very-small"></div>
                    </section>
                    <div class="dt-sc-hr-invisible"></div>
                </div>

            </div>
</asp:Content>

