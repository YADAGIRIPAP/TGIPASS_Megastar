<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaPowerTariff.aspx.cs" Inherits="UI_TSiPASS_ProformaPowerTariff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <title>DraftPrint</title>
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

         .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
            border: 1px solid #000000 !important;
            padding: 2px !important;
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
                <h3 style="color: #0000FF;">GOVERNMENT OF TELANGANA <br /> DEPARTMENT OF INDUSTRIES</h3>

            </asp:Label>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <span style="float: left;"><span style="float: left;"><b>From</b></span><br />
                            The General Manager<br />
                            District Industries Centre,<br />
                            <asp:Label ID="lbldist1" runat="server"></asp:Label></span>
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
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style6">Dated: </span>
                <asp:Label ID="lblLetterDate" CssClass="auto-style6" runat="server"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15">
                <span class="floatleft" style="font-weight: bold">Sir,</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3"><span style="font-weight: bold">Sub :-</span> <asp:Label ID="lblIIPScheme" Font-Bold="true" runat="server"></asp:Label>  Incentives scheme - Claim 
                                 Application for sanction of Reimbursement of Power Tariff of <asp:Label ID="lblEnterpreneurDetails1" Font-Bold="true" runat="server"></asp:Label>&nbsp; 
                                Proposal – Recommended – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span>&nbsp;for the <asp:Label ID="lblFinancialYear5" Font-Bold="true" runat="server"></asp:Label>..
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <b>******* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <span class="floatleft auto-style3">In the reference cited, &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of Power Tariff for the Period of &nbsp;
                                <span style="font-weight: bold"><asp:Label ID="lblFinancialYear1" runat="server"></asp:Label></span>&nbsp; under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblIIPPYearScheme1" runat="server"></asp:Label></span>&nbsp; Scheme.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">In this connection, it is to submit that the unit has been inspected by the  
                                            <asp:Label ID="lblInspectedOfficer" Font-Bold="true" runat="server"></asp:Label>
                    on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddt" Font-Bold="true" runat="server"></asp:Label></span>&nbsp; and 
                                found working at the time of Inspection. The unit has obtained <asp:Label ID="lbludyogaadharType" runat="server"></asp:Label>. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEMPartNO" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEMPPartDate" runat="server"></asp:Label></span>&nbsp;  for the line of activity of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloa" runat="server"></asp:Label></span> with date of commencement of commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDateofCommencement" runat="server"></asp:Label></span>.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px">
                <span class="floatleft auto-style3"><b>The Power consumption of the unit is as follows :</b>
                </span>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" style="padding-top: 10px">
                <asp:GridView ID="gvpwtariff" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" CssClass="table table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl. No">
                            <ItemTemplate>
                                <asp:Label ID="lblslno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FirstOrSecondHalfYearVisible" HeaderText="Period" />
                        <asp:BoundField DataField="TotalUnitsConsumed" HeaderText="Units" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display: none; padding-top: px">
                <span class="floatleft auto-style3">Rate eligible per unit :
                        <asp:Label ID="lblRateEligiblePerUnit" runat="server"></asp:Label>
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px;">
                <span class="floatleft auto-style3">Amount eligible in Rs.
                        <asp:Label ID="lblEligibleAmount" Font-Bold="true" runat="server"></asp:Label>
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px">
                <span class="floatleft auto-style3">Therefore, I request the Commissioner of Industries, Telangana, Hyderabad kindly to consider the 
                                            proposal of the captioned unit for sanction of Reimbursement of Power Cost Reimbursement Scheme for Rs. 
                                                <asp:Label ID="lblPWAmount2" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                             &nbsp;(<asp:Label ID="lblSanctionedAmtDesc" Font-Bold="true" runat="server"></asp:Label>&nbsp;Rupees only)
                                            for the  period of
                                  <b>
                                      <asp:Label ID="lblFinancialYear3" runat="server"></asp:Label></b>&nbsp; under  &nbsp; <span style="font-weight: bold">
                                          <asp:Label ID="lblIIPPYearScheme2" runat="server"></asp:Label></span>&nbsp; Scheme.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trRemarks" runat="server" visible="false" style="padding-top: 14px">
                <span class="floatleft auto-style3">Remarks: 
                        <asp:Label runat="server" ID="lblRemarks"></asp:Label>
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">I
                                            <asp:Label Font-Bold="true" ID="lblDICName" runat="server"></asp:Label>,
                                            &nbsp;<span style="font-weight:bold">General Manager, DIC</span>&nbsp;<asp:Label ID="lbldist2" Font-Bold="true" runat="server"></asp:Label>,&nbsp;hereby certify that the incentive application has been processed in accordance with the operational guidelines under
                                            <asp:Label ID="Tideaorpride" runat="server"></asp:Label>, if any deviation from guidelinesis foundout, i shall be held responsible for any action deemed fit.
                </span>
            </div>
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px" id="divVerify" runat="server" visible="false" >
                <span class="floatleft auto-style3"> This is to verify that there is no break in production since commencement of production</div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 25px; padding-bottom: 10px; text-align:left">
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
