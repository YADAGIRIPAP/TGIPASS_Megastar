<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EncloserList.aspx.cs" Inherits="UI_TSiPASS_EncloserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!--WIZARD STYLES-->
    <link href="assets/css/wizard/normalize.css" rel="stylesheet" />
    <link href="assets/css/wizard/wizardMain.css" rel="stylesheet" />
    <link href="assets/css/wizard/jquery.steps.css" rel="stylesheet" />

    <!--CUSTOM BASIC STYLES-->
    <link href="assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
       
            <div id="page-inner">
         <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Enclousers List
                        </div>
                        <div class="panel-body" >
                           <div class="col-xs-6 downloads">
                            <h3 class="widget-heading">Downloads</h3>
                            <div class="list-group" style="width:100%">

                                <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/CommonEnclosures.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/pdf.png">
                                    COMMON ENCLOSURES</a>

                                <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/self certification.docx.doc" target="_blank" class="list-group-item" style="background-color: white">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/pdf.png">
                                    Self Certification</a>

                                <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Mutation Document.pdf" target="_blank" class="list-group-item" style="background-color: white">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/pdf.png">
                                    Mutation Copy</a>

                                <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/buildingplan.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/pdf.png">
                                    Detailed Building Plan</a>

                                <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Combined Site Plan.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/pdf.png">
                                    Combined Site Plan</a>

                                <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/flowchart.pdf" class="list-group-item" target="_blank" style="background-color: white">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/pdf.png">
                                    Process Flow Chart</a>

                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
       
            </div>
            <!-- /. PAGE INNER  -->
     
    </form>
</body>
</html>
