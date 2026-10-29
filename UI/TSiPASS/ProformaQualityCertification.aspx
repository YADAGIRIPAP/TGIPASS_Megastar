<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaQualityCertification.aspx.cs" Inherits="UI_TSiPASS_ProformaQualityCertification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .leftalign {
            text-align: left;
        }

        .rightalign {
            text-align: right;
        }

        .floatleft {
            float: left;
        }

        body {
            background-color: #ffffff;
        }
    </style>
    <style type="text/css">
        .auto-style3 {
            text-align: justify;
        }

        .auto-style4 {
            text-align: left;
        }

        .auto-style5 {
            text-align: center;
        }

        .auto-style6 {
            text-decoration: underline;
        }
    </style>
    <script type="text/javascript">

        function myFunction() {
            //document.getElementById("Div2").style.visibility = "hidden";
            document.getElementById("Div2").style.display = "none";
            //$("#Button2").hide();
            window.print();
            // $("#Button2").show();
            document.getElementById("Div2").style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="Receipt" runat="server" style="border: 3px solid #000000; text-align: center;">
            <div style="padding-top: 14px">
            </div>
            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" style="width: 75px; height: 75px;" alt="" />
            <asp:Label Font-Bold="true" Font-Size="14pt" ID="lblheadTPRIDE" runat="server">
                     <h3 style="color: #0000FF;">GOVERNMENT OF TELANGANA <br /> DEPARTMENT OF INDUSTRIES</h3>
            </asp:Label>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <span style="float: left;"><span style="float: left;"><b>From</b></span><br />
                            The General Manager,<br />
                            District Industries Centre,<br />
                            <asp:Label ID="lblDistrict" runat="server"></asp:Label></span>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"></div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <span style="float: right;"><span style="float: left;"><b>To</b></span>
                            <br />
                            The Commissioner of Industries,<br />
                            Government of Telangana,<br />
                            Chirag Ali Lane, Abids,<br />
                            Hyderabad.</span>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; font-weight: bold">
                <span class="auto-style6">Letter No : </span>
                <asp:Label ID="lblLetterNo" CssClass="auto-style6" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style6">Dated
                                            : </span>
                <asp:Label ID="lblLetterDate" CssClass="auto-style6" runat="server"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15">
                <span class="floatleft" style="font-weight: bold">Sir,</span>
            </div>
            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1" runat="server"></asp:Label></span>&nbsp; for Reimbursement of Quality Certification&nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.
                </span>
            </div>--%>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; top: 0px; left: 0px;">
                <span class="floatleft auto-style3"><span style="font-weight:bold">Sub :-  </span>
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1"  Font-Bold="true" runat="server"></asp:Label></span>&nbsp; Incentive Scheme – Claim application for sanction of Reimbursement of all expenses incurred for Quality Certification/Patent Registration of &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1"  Font-Bold="true" runat="server"></asp:Label></span>&nbsp; Proposal – Recommended – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <b>******* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <span class="floatleft auto-style3">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2" Font-Bold="true" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of all expenses incurred for Quality Certification/Patent Registration under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2" runat="server"></asp:Label></span>&nbsp; Scheme.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">

                <span class="floatleft auto-style3">In this connection, i submit that the unit has been inspected by  <asp:Label ID="lblInspectedOfficer" Font-Bold="true" runat="server"></asp:Label> on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddt" runat="server"></asp:Label></span>&nbsp; and 
                                found working at the time of inspection.
                                The unit has obtained  <asp:Label ID="lbludyogaadharType" runat="server"></asp:Label>.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharno" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardate" runat="server"></asp:Label></span> for the line of activity of 
                               <span style="font-weight: bold"><asp:Label ID="lblloa" runat="server"></asp:Label></span> 
                                with date of commencement of commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCP" runat="server"></asp:Label></span>.
                </span>
            </div>
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">The unit holder has paid for Reimbursement of all expenses incurred for Quality Certification/Patent Registration an amount of Rs.
                                     <asp:Label ID="lblSTAmountPaid" Font-Bold="true" runat="server"></asp:Label>
                                 </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="tr1" runat="server" style="padding-top: 14px">
                <span class="floatleft auto-style3">The eligible Reimbursement of all expenses incurred for Quality Certification/Patent Registration @ 50% = Rs. &nbsp; <span style="font-weight: bold">
                    <asp:Label ID="lblSTAmountPaid1" runat="server"></asp:Label></span>
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Therefore, I request the Commissioner of Industries, Telangana, Hyderabad kindly to consider the proposal of the captioned unit for sanction of 50% Reimbursement of all expenses incurred for Quality Certification/Patent Registration of Rs.
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3" runat="server"></asp:Label>&nbsp;
                                  &nbsp;(<asp:Label ID="lblSanctionedAmtDesc" runat="server"></asp:Label>
                    &nbsp;Rupees only) </span>
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3" runat="server"></asp:Label></span>&nbsp; Scheme.
                </span>
            </div>
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trRemarks" runat="server" visible="false" style="padding-top: 14px">
                <span class="floatleft auto-style3"><span style="font-weight: bold">Remarks:</span>
                    <asp:Label runat="server" ID="lblRemarks"></asp:Label></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">I &nbsp;<asp:Label ID="lblDICName" Font-Bold="true" runat="server"></asp:Label>,&nbsp;<span style="font-weight:bold">General Manager, DIC</span>&nbsp;<asp:Label ID="lbldist2" Font-Bold="true" runat="server"></asp:Label>,&nbsp;hereby certify that the incentive application has been processed in accordance with the operational guidelines under
                <asp:Label ID="Tideaorpride" runat="server"></asp:Label>, if any deviation from guidelinesis foundout, i shall be held responsible for any action deemed fit.</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 25px; padding-bottom: 10px; text-align:left">
                <span class=" pull-right"><span style="font-weight: bold">Yours faithfully,</span><br />
                    <asp:Label ID="lblGMname" runat="server"></asp:Label><br />
                    General Manager<br />
                    <asp:Label ID="lbldist3" runat="server" ></asp:Label>
                </span>
                <span class=" pull-left">Encl : As above.  
                </span>
            </div>
        </div>
        <div class="container" id="Div2" runat="server" style="text-align: center; vertical-align: bottom">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
            </div>
        </div>

    </form>
</body>
</html>
