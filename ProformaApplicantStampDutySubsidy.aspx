<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaApplicantStampDutySubsidy.aspx.cs" Inherits="UI_TSiPASS_ProformaApplicantStampDutySubsidy" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
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
            document.getElementById("Div2").style.visibility = "hidden";
            window.print();
            document.getElementById("Div2").style.visibility = "visible";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="border: 3px solid #000000; text-align: center;">
            <div style="padding-top: 10px">
            </div>
            <img src="telanganalogo.png" style="width: 75px; height: 75px;" alt="" /><br />
            <asp:Label Font-Bold="true" Font-Size="Large" ID="lblheadTPRIDE" runat="server">GOVERNMENT OF TELANGANA</asp:Label>
            <br />
            <asp:Label Font-Bold="true" Font-Size="Large" ID="lblcoidipc" runat="server"></asp:Label><b> :: </b>
            <asp:Label Font-Bold="true" Font-Size="Large" ID="lblDistrict1" runat="server"></asp:Label>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                <div class="row">
                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12" style="text-align: left;">
                        <span style="float: left;"><span style="float: left;"><b>To,</b></span>
                            <br />
                            <asp:Label ID="lblEnterpreneurDetails1" runat="server" Width="200px"></asp:Label><br />
                        </span>
                    </div>
                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12"></div>
                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="padding-top: 6px; font-weight: bold">
                <span class="auto-style6"><u>Lr. No.&nbsp;<asp:Label ID="lblLetterNo" runat="server"></asp:Label>&nbsp;Dated:&nbsp;<asp:Label ID="lblLetterDate" runat="server"></asp:Label>.</u></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15">
                <span class="floatleft" style="font-weight: bold">Sir / Madam,</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <span class="floatleft auto-style3">Sub :- 
                    <asp:Label ID="lblTIdeaTPrideIIPP1" runat="server"></asp:Label>&nbsp; – Sanction   of Reimbursement of Stamp Duty and Land Cost to   
                                       <asp:Label ID="lblEnterpreneurDetails2" runat="server"></asp:Label>,                                                 
                                                    District - Intimation – Reg. 
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <span class="floatleft auto-style3">Ref :-  
                      <br />
                    1.
                                                    <asp:Label ID="lblScheme_GO_Details" runat="server"></asp:Label>.<br />
                    2.
                                                    The General  Manager, District Industries Centre,
                                                    <asp:Label ID="lblDistrict" runat="server"></asp:Label>.<br />
                    3. Minutes of the&nbsp;<asp:Label ID="lblSLCText" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblSLCNo" runat="server"></asp:Label>&nbsp;
                                                    meeting held on&nbsp;<asp:Label ID="lblSLCDate" runat="server"></asp:Label>.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 2px">
                <b>******* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="padding-top: 2px">
                <span class="floatleft auto-style3">With reference to the subject cited, we are pleased to inform you that you have been sanctioned the Reimbursement of
                    <asp:Label ID="lblStampDutyorMgage" runat="server"></asp:Label>
                    of Rs.
                                                    <asp:Label ID="lblStampDutyAmount" runat="server"></asp:Label>
                    &nbsp;(<asp:Label ID="lblStampDutyAmountDesc" runat="server"></asp:Label>)&nbsp<%--;and Mortgage Duty of Rs. &nbsp;<asp:Label ID="lblMortgageAmount" runat="server"></asp:Label>&nbsp;(<asp:Label ID="lblMortgageAmountDesc" runat="server"></asp:Label>)&nbsp;--%>
                                                    to the captioned under the scheme of &nbsp;&nbsp;<asp:Label ID="lblTIdeaTPrideIIPP2" runat="server"></asp:Label>&nbsp; vide reference 3rd cited.
                </span>
            </div>
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                 <span class="floatleft auto-style3">This amount will be released as and when your unit’s turn comes as per seriatim for disbursement of available funds.</span>
            </div>
            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <br />
                <span class=" pull-right">Yours faithfully,</span><br />

                <span id="addlDire" runat="server" visible="false" class="pull-right">
                    <asp:Label ID="lblAddlDir_Name" Visible="false" runat="server" Text="Additional Director Name"></asp:Label><br />

                </span>
                <span class="pull-right">
                    <asp:Label ID="lbldesignation" runat="server"></asp:Label>

                    <asp:Label ID="lblDistrict2" runat="server"></asp:Label></span>
            </div>--%>
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; text-align: left">
                <span class=" pull-right"><span style="font-weight: bold">Yours faithfully,</span><br />
                    <span id="addlDire" runat="server" class="pull-right">
                        <asp:Label ID="lblAddlDir_Name" runat="server" Text="Additional Director Name"></asp:Label><br />
                    </span>
                </span>
                <%-- <span class="pull-right">Additional Director<br />
                        O/o. Commissioner of Industries</span></span>--%>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <span class="floatleft auto-style3">
                    <b>Note:</b> 27/&nbsp;<asp:Label ID="lblTIdeaTPrideIIPP3" runat="server"></asp:Label>&nbsp;– Furnishing of Statement of Accounts / Information by eligible Industrial Enterprises. Industrial units, which obtain incentives under the scheme, shall furnish certified copy of audited accounts including Balance Sheet before 30th June of the succeeding year to the disbursing agencies. Such statement should be furnished for a period of minimum six (6) years.  Further, industrial units should also furnish details of production, sales employment, etc., in the proforma prescribed tot eh General Manager, District Industries Centre concerned as an Annual Return before 30th June of the succeeding year and obtain acknowledgement thereof”.  However, Enterprises which are released capital subsidy Rs. 100000 may furnish only the Annual Performance Report in the format prescribed to the General Manager, DIC concerned as an Annual Return before 30th June of the succeeding year and obtain acknowledgement thereof for a period of six (6) years after going into Commercial Production.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <span class="floatleft auto-style3">This is computer generated document it can be verified online by using Unique Id : 
                                        <asp:Label ID="lblIncentiVeID" Font-Bold="true" runat="server"></asp:Label>
                    in the Url: https://ipass.telangana.gov.in/UI/TSiPASS/frmIntimationIncentives.aspx
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px; font-weight: bold">
                *&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;&nbsp;*
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="padding-top: 6px">
               <span class="floatleft auto-style3"> <asp:Label ID="lbladdress" runat="server"></asp:Label>&nbsp;website: http://www.industries.telangana.gov.in </span>
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


