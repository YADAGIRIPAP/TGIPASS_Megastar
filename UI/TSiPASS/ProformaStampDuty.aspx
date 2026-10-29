<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaStampDuty.aspx.cs" Inherits="UI_TSiPASS_ProformaStampDuty" %>

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
            document.getElementById("Div1").style.visibility = "hidden";
            //$("#Button2").hide();
            window.print();
            // $("#Button2").show();
            document.getElementById("Div1").style.visibility = "visible";
        }
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
        function printDiv() {

            var divToPrint = document.getElementById('Receipt');

            var newWin = window.open('', 'Print-Window');

            newWin.document.open();

            newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

            newWin.document.close();

            setTimeout(function () { newWin.close(); }, 10);

        }
    </script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="Receipt" runat="server" style="border: 3px solid #000000; text-align: center;">
            <div style="padding-top: 14px">
            </div>
            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" style="width: 75px; height: 75px;" />
            <asp:Label Font-Bold="true" Font-Size="14pt" runat="server"> <h3 style="color: #0000FF;">GOVERNMENT OF TELANGANA <br /> DEPARTMENT OF INDUSTRIES</h3></asp:Label>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" style="text-align: left">
                        <p style="float: left;">
                            <b>From,</b><br />
                            The General Manager,<br />
                            District Industries Centre,<br />
                            <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"></div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" style="text-align: left">
                        <span style="float: right;"><span style="float: left;"><b>To,</b></span>
                            <br />
                            The Commissioner of Industries,<br />
                            Government of Telangana,<br />
                            Chirag Ali Lane, Abids,<br />
                            Hyderabad.</span>

                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <div class="row">
                    <span class="auto-style6">Letter No : </span>
                    <asp:Label ID="lblLetterNo" runat="server" CssClass="auto-style6"></asp:Label>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style6">Dated
                                            : </span>
                    <asp:Label ID="lblLetterDate" runat="server" CssClass="auto-style6"></asp:Label>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15">
                <span class="floatleft" style="font-weight: bold">Sir,</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <span class="floatleft auto-style3">Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1" runat="server"></asp:Label></span>&nbsp; for Reimbursement of 
                                    <asp:Label ID="Label1" runat="server" Text="Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s"></asp:Label>
                    under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <span class="floatleft auto-style3">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span>&nbsp; of the unit holder.</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:6px">
                <b>******* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <span class="floatleft auto-style3">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2" runat="server"></asp:Label></span>&nbsp; have applied for Reimbursement of
                    <asp:Label ID="Label3" runat="server" Text="Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s"></asp:Label>
                    under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2" runat="server"></asp:Label></span>&nbsp; Scheme.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <span class="floatleft auto-style3">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddt" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloa" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharno" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardate" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCP" runat="server"></asp:Label>.</span></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <span class="floatleft auto-style3">The eligible reimbursement of
                    <asp:Label ID="Label4" runat="server" Text="Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s"></asp:Label>
                    under  is calculated. <%--as under :---%></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 leftalign" style="display: none">
                <asp:Label ID="lbl1st2nd1" runat="server"></asp:Label>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2" runat="server"></asp:Label>&nbsp;
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <span class="floatleft auto-style3">As per form - A the
                    <asp:Label ID="Label5" runat="server" Text="Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s"></asp:Label>
                    paid  &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2" runat="server" Visible="false"></asp:Label></span>
                        <asp:Label ID="lblFinancialYear3" runat="server" Visible="false"></asp:Label></span>&nbsp;Rs. &nbsp; <span style="font-weight: bold">
                            <asp:Label ID="lblSTAmountPaid" runat="server"></asp:Label>.</span></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trStamptransferDuty" runat="server" visible="false" style="padding-top:14px">
                <span class="floatleft auto-style3">The eligible reimbursement of Stamp/Transfer Duty  @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                    <asp:Label ID="lblStampTransferDutyPaid" runat="server"></asp:Label>.</span></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trMortgageDutyPaid" runat="server" visible="false" style="padding-top:14px">
               
                <span class="floatleft auto-style3">The eligible reimbursement of Mortgage Duty  @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                    <asp:Label ID="lblMortgageDutyPaid" runat="server"></asp:Label>.</span></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trLandConversionCharges" runat="server" visible="false" style="padding-top:14px">
               
                <span class="floatleft auto-style3">The eligible reimbursement of Land Conversion Charges  @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                    <asp:Label ID="lblLandConversionCharges" runat="server"></asp:Label>.</span></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trlblLandCostPurchased" runat="server" visible="false" style="padding-top:14px">
                <span class="floatleft auto-style3">The eligible reimbursement of  Land Cost Purchased in IE/IDA/IP’s  @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                    <asp:Label ID="lblLandCostPurchased" runat="server"></asp:Label>.</span></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <span class="floatleft auto-style3">The eligible reimbursement of
                    <asp:Label ID="Label6" runat="server" Text="Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost"></asp:Label>
                    = Rs. &nbsp; <span style="font-weight: bold">
                        <asp:Label ID="lblFinalStampduty" runat="server"></asp:Label>.</span></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top:14px">
                <span class="floatleft auto-style3">Hence the unit case is recommended for sanction of 100% Reimbursement of 
                    <asp:Label ID="Label7" runat="server" Text="Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s"></asp:Label>
                    of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3" runat="server"></asp:Label></span>&nbsp;
                               
                                    &nbsp;(<asp:Label ID="lblSanctionedAmtDesc" runat="server"></asp:Label>
                    &nbsp;Rupees only), 
                               <%-- for the--%> <span style="font-weight: bold">
                                   <asp:Label ID="lbl1st2nd3" runat="server" Visible="false"></asp:Label></span><%--&nbsp;  Half year of &nbsp;--%>
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblFinancialYear4" runat="server" Visible="false"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3" runat="server"></asp:Label></span>&nbsp; Scheme.</span>
            </div>
            <div class="col-lg-11 col-md-12 col-sm-12 col-xs-12" style="padding-top:25px; padding-bottom:30px">
                <span class=" pull-right"><span style="font-weight: bold">Yours faithfully,</span><br />
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </span><br />
                <span class=" pull-left">Encl : As above.  
                </span>
            </div>
            <div class="col-lg-1 col-md-12 col-sm-12 col-xs-12">
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"></div>
        </div>

        <div class="container" id="Div1" runat="server" style="text-align: center; vertical-align: bottom">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
            </div>
        </div>
    </form>
</body>
</html>
