<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaPavalavaddi.aspx.cs" Inherits="UI_TSiPASS_ProformaPavalavaddi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <title>Pavallavaddi Recommendation Letter</title>
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
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="Receipt" runat="server" style="border: 3px solid #000000; text-align: center;">
            <div style="padding-top: 14px">
            </div>
            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" style="width: 75px; height: 75px;" alt="" />

            <asp:Label ID="lblheadTPRIDE" Font-Bold="true" Font-Size="12pt" runat="server"> 
             <h3 style="color: #0000FF;">GOVERNMENT OF TELANGANA  <br /> DEPARTMENT OF INDUSTRIES</h3></asp:Label>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <span style="float: left;"><span style="float: left;"><b>From</b></span><br />
                            The General Manager,<br />
                            District Industries Centre,<br />
                            <asp:Label ID="lbldist1" runat="server"></asp:Label>.</span>
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
                <asp:Label ID="lblLetterNo" runat="server" CssClass="auto-style6"></asp:Label>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style6">Dated: </span>
                <asp:Label ID="lblLetterDate" CssClass="auto-style6" runat="server"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <span class="floatleft" style="font-weight: bold">Sir,</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; top: 0px; left: 0px;">
                <span class="floatleft auto-style3"><span style="font-weight:bold">Sub :-  </span>
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblIIPPScheme" runat="server"></asp:Label></span>&nbsp; Incentive Scheme – Claim application for sanction of Reimbursement of Interest Subsidy under Pavala Vaddi Scheme of &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails" runat="server"></asp:Label></span>&nbsp; Proposal – Recommended – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3"><span style="font-weight:bold">Ref :-</span>  TS-IPASS Application No : 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span>&nbsp; for the 
                    &nbsp;<span style="font-weight: bold"><asp:Label ID="lblFinancialYear1" runat="server"></asp:Label>.</span>
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <b>******* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <span class="floatleft auto-style3">Through the reference cited, &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2" runat="server"></asp:Label></span>&nbsp; 
                                have applied for sanction of Reimbursement of Interest Subsidy under Pavala Vaddi Scheme for the &nbsp;
                    <span style="font-weight: bold"><asp:Label ID="lblFinancialYear2" runat="server"></asp:Label></span>&nbsp; under  
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblIIPPScheme2" runat="server"></asp:Label></span>&nbsp; Scheme.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">In this regard, it is to submit that the unit has been inspected by
                                <asp:Label ID="lblInspectedOfficer" Font-Bold="true" runat="server"></asp:Label> on 
                               <span style="font-weight: bold">
                                   <asp:Label ID="lblinspecteddt" runat="server"></asp:Label></span>&nbsp; and 
                                found working at the time of inspection. The unit has obtained&nbsp;
                 <asp:Label ID="lbludyogaadharType" runat="server"></asp:Label>
                    &nbsp; vide Ack. No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEMPartNO" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEMPPartDate" runat="server"></asp:Label></span>&nbsp;  for the line of activity of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloa" runat="server"></asp:Label></span>&nbsp; with date of commencement of commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDateofCommencement" runat="server"></asp:Label></span>.
                </span>
            </div>
            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; display:none" >
                <span class="floatleft auto-style3">
                    <asp:Label ID="lbl1stOR2nd3" runat="server"> </asp:Label>
                    &nbsp;
                    <asp:Label ID="lblhlfyeartext3" runat="server" Text="Half year of"></asp:Label>
                    <asp:Label ID="lblFinancialYear4" runat="server"></asp:Label></span>&nbsp;
            </div>--%>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">The unit holder has paid an amount of Rs. &nbsp;<span style="font-weight: bold"><asp:Label ID="lblamountpaid1" runat="server"></asp:Label></span>&nbsp; for the <span style="font-weight: bold">&nbsp;<asp:Label ID="lblFinancialYear3" runat="server"></asp:Label></span>&nbsp; towards Interest. The eligible reimbursement of Interest Subsidy under Pavala Vaddi is calculated as under:
                    <span style="font-weight: bold"><asp:Label ID="lblIIPPScheme4" runat="server"></asp:Label>.</span>
                </span>
           
                 </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">The rate of interest as per the Bank certificate = 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblBankInterestPercent" runat="server"></asp:Label></span>
                    But as per G.O. Ms. No. 77, the minimum 3% interest per annum should be borne by the Enterprise. Over and above 3% interest per annum reimbursement will be done to the extent of  9% maximum. </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Therefore the eligible rate of interest for Pavala Vaddi is Rs.  <span style="font-weight: bold"><asp:Label ID="lblrecamount" runat="server"></asp:Label></span>.</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="tr1" runat="server" visible="false" style="padding-top: 14px">
                <span class="floatleft auto-style3">Eligible Pavala Vaddi&nbsp;= (<span style="font-weight: bold"><asp:Label ID="lblamountpaid2" runat="server"></asp:Label></span>&nbsp;* 9)/13.5 = &nbsp;<span style="font-weight: bold"><asp:Label ID="lblpvamount" runat="server"></asp:Label></span>&nbsp;</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="Div1" runat="server" style="padding-top: 14px">
                <span class="floatleft auto-style3">Therefore, I request the Commissioner of Industries, Telangana, Hyderabad kindly to consider the proposal of the captioned unit for sanction of Reimbursement of Interest subsidy under Pavala Vaddi Scheme for Rs. &nbsp; <span style="font-weight: bold">
                 <asp:Label ID="lblSTAmountPaid3" runat="server"></asp:Label></span>&nbsp;&nbsp;(<asp:Label ID="lblSanctionedAmtDesc" Font-Bold="true" runat="server"></asp:Label>&nbsp;<span style="font-weight:bold">Rupees only</span>), for the 
                 <span style="font-weight: bold"><asp:Label ID="lblFinancialYear5" runat="server"></asp:Label></span>&nbsp;under  &nbsp; <span style="font-weight: bold"><asp:Label ID="lblIIPPScheme3" runat="server"></asp:Label></span>&nbsp; Scheme.</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trRemarks" runat="server" visible="false" style="padding-top: 14px">
                <span class="floatleft auto-style3">Remarks:
                    <asp:Label runat="server" ID="lblRemarks"></asp:Label></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">I &nbsp;<asp:Label ID="lblDICName" Font-Bold="true" runat="server"></asp:Label>,&nbsp;<span style="font-weight:bold">General Manager, DIC</span>&nbsp;<asp:Label ID="lbldist2" Font-Bold="true" runat="server"></asp:Label>,&nbsp;hereby certify that the incentive application has been processed in accordance with the operational guidelines under
                <asp:Label ID="Tideaorpride" runat="server"></asp:Label>, if any deviation from guidelinesis foundout, i shall be held responsible for any action deemed fit.</span>
            </div>
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px" id="divVerify" runat="server" visible="false" >
                <span class="floatleft auto-style3"> This is to verify that there is no break in production since commencement of production</div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; padding-bottom: 3px; text-align:left">
                <span class=" pull-right"><span style="font-weight: bold">Yours faithfully,</span><br />
                    <asp:Label ID="lblGMname" runat="server"></asp:Label><br />
                    General Manager<br />
                    <asp:Label ID="lbldist3" runat="server"></asp:Label>
                </span>
                <span class=" pull-left">Encl : As above.  <strong></strong>
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
