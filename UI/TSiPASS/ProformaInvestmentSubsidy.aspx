<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaInvestmentSubsidy.aspx.cs"
    Inherits="UI_TSiPASS_ProformaInvestmentSubsidy" %>

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

        .auto-style6 {
            text-decoration: underline;
        }

        .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
            border: 1px solid #000000 !important;
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
            <div style="padding-top: 6px">
            </div>
            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" style="width: 75px; height: 75px;" />
            <asp:Label Font-Bold="true" Font-Size="12pt" runat="server">
            <h3 style="color: #0000FF;">GOVERNMENT OF TELANGANA <br /> DEPARTMENT OF INDUSTRIES</h3></asp:Label>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <span style="float: left;"><span style="float: left;"><b>From</b></span><br />
                            The General Manager,<br />
                            District Industries Centre,<br />
                            <asp:Label ID="lblletterFrom" runat="server"></asp:Label>.</span>
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
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; font-weight: bold">
                <span class="auto-style6">Letter No : </span>
                <asp:Label ID="lblLetterNo" runat="server" CssClass="auto-style6"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style6">Dated: </span>
                <asp:Label ID="lblLetterDate" runat="server" CssClass="auto-style6"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15">
                <span class="floatleft" style="font-weight: bold">Sir,</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px">
                <span class="floatleft auto-style3"><span style="font-weight: bold">Sub :-  </span>
                    <asp:Label ID="lblTIdeaTPride" Font-Bold="true" runat="server"></asp:Label>
                    Incentives Scheme – Claim application for Sanction of Investment Subsidy of
                    <asp:Label ID="lblEnterpreneurDetails" Font-Bold="true" runat="server"></asp:Label>
                    – Proposal - Recommended – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 11px">
                <span class="floatleft auto-style3">Ref :- TS-IPASS Application No. &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;, dt: &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span></span>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 2px">
                <b>******* </b>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <span class="floatleft auto-style3">In the reference cited,&nbsp;<asp:Label ID="lblEnterpreneurDetails2" Font-Bold="true" runat="server"></asp:Label>&nbsp;have applied for the sanction of Investment Subsidy under <b>
                    <asp:Label ID="lblTIdeaTPride2" Font-Bold="true" runat="server"></asp:Label></b> Scheme.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 11px">
                <span class="floatleft auto-style3">In this regard it is to submit that the
                    <asp:Label ID="lblUnitOrVeh" runat="server"></asp:Label>
                    is registered vide
                    <asp:Label ID="lblUdyogNoOrVehNO" runat="server"></asp:Label>
                    No.&nbsp;<asp:Label ID="lblUdyogAadhaarNoDate" Font-Bold="true" runat="server"></asp:Label>&nbsp; with the D.C.P.
                    <asp:Label ID="lblDCP" Font-Bold="true" runat="server"></asp:Label>&nbsp;for the line of activity&nbsp;<asp:Label ID="lblLineofActivity" Font-Bold="true" runat="server"></asp:Label>.&nbsp;The above line of activity is <asp:Label ID="lblloanotlist" runat="server"></asp:Label> included in the list of <asp:Label ID="lblineligible" Text="ineligible" runat="server"></asp:Label> list of industrial enterprises. The unit holder has filed the claim application on
                    <asp:Label ID="lblClaimApplicationDate" Font-Bold="true" runat="server"></asp:Label>.
                    &nbsp;<%--Hence there is no delay in filing the claim application.--%></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 11px">
                <span class="floatleft auto-style3">The
                    <asp:Label ID="lblUnitOrVeh2" Font-Bold="true" runat="server"></asp:Label>
                    has been inspected by
                    <asp:Label ID="lblInspectedOfficer" Font-Bold="true" runat="server"></asp:Label>
                    on
                    <asp:Label ID="lblInspectedDate" Font-Bold="true" runat="server"></asp:Label>
                    and found working. The claim application together with verification report, statement of accounts and required documents are enclosed here with.</span>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" style="padding-top: 11px">
                <b>The computed cost of the unit is as follows:-</b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" style="padding-top: 11px">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>Land (in Rs.)</th>
                            <th>Building (in Rs.)</th>
                            <th>Plant and Machinery (in Rs.)</th>
                            <th>Total (in Rs.)</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblLandCost" runat="server"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblBuildingCost" runat="server"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPlantMachCost" runat="server"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <asp:Label ID="lbl" runat="server"></asp:Label>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" id="tr" runat="server" visible="false" style="padding-top: 11px">
                The
                                        <asp:Label ID="lblUnitOrVeh3" runat="server"></asp:Label>
                is eligible for Investment subsidy &nbsp;
                                        <asp:Label ID="lblpercentage" runat="server"> </asp:Label>
                &nbsp; of the computed cost of Rs. &nbsp;(
                                        <asp:Label ID="lblComputedCost" runat="server">
                                        </asp:Label>*<asp:Label ID="lblpercentage2" runat="server"> </asp:Label>
                )/100= Rs.<asp:Label ID="lblComputedCost2" runat="server">
                </asp:Label>/-
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" style="padding-top: 5px">
                <b>Amount eligible in Rs.</b>
                <asp:Label ID="lbleligibleamount" Font-Bold="true" runat="server"></asp:Label>/- 
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" style="padding-top: 11px">
                Therefore
                                        it is requested the Commissioner of Industries, Telangana, Hyderabad kindly to consider
                                        the proposal for sanction Investment subsidy of Rs.&nbsp;
                                        <asp:Label ID="lblAMount" Font-Bold="true" runat="server"></asp:Label>
                (<asp:Label ID="lblApplcationDate" Font-Bold="true" runat="server"></asp:Label>) under
                                        &nbsp;<asp:Label ID="lblTIdeaTPride3" Font-Bold="true" runat="server"></asp:Label>
                Scheme.
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" id="trRemarks" runat="server" visible="false" style="padding-top: 11px">
                <span style="font-weight: bold">Remarks:</span>
                <asp:Label runat="server" ID="lblRemarks"> </asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" style="padding-top: 11px">
                I
                                        <asp:Label ID="lblDICName" Font-Bold="true" runat="server"></asp:Label>, &nbsp;hereby certify that
                                        the incentive application has been processed in accordance with the operational
                                        guidelines under
                                        <asp:Label ID="Tideaorpride"  Font-Bold="true" runat="server"></asp:Label>, if any deviation from
                                        guidelinesis foundout, i shall be held responsible for any action deemed fit.</div>
               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px" id="divVerify" runat="server" visible="false" >
                <span class="floatleft auto-style3"> This is to verify that there is no break in production since commencement of production</div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; padding-bottom: 5px; text-align: left">
                <span class=" pull-right"><span style="font-weight: bold">Yours faithfully,</span><br />
                    <asp:Label ID="lblGMname" runat="server"></asp:Label><br />
                    General Manager<br />
                    <asp:Label ID="lbldist3" runat="server"></asp:Label>
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
