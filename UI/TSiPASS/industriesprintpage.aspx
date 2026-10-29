<%@ Page Language="C#" AutoEventWireup="true" CodeFile="industriesprintpage.aspx.cs" Inherits="UI_TSiPASS_industriesprintpage" %>

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
        .pull-right {
    float: right !important;
    text-align: center !important;
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
            <div style="padding-top: 14px">
            </div>
            <img src="telanganalogo.png" style="width: 75px; height: 75px;" alt="" /><br />
            <asp:Label Font-Bold="true" Font-Size="Large" ID="lblheadTPRIDE" runat="server">GOVERNMENT OF TELANGANA</asp:Label>
            <br />
            <asp:Label ID="lblCoiDipcHead" Font-Bold="true" Font-Size="Large" runat="server"
                Text="OFFICE OF THE COMMISSIONER OF INDUSTRIES"></asp:Label>::<asp:Label ID="lblCoiDipcDist" Font-Bold="true" Font-Size="Large" runat="server" Text="HYDERABAD"></asp:Label>

            <br />
            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; font-weight: bold">
                <span class="auto-style6"><u>Show Cause Notice</u></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; font-weight: bold">
                <span class="auto-style6"><u>MemNo.&nbsp;<asp:Label ID="lbl_memno" runat="server"></asp:Label> T-IDEA/T-PRIDE Scheme, </u><u>Dated:&nbsp;<asp:Label
                    ID="lbl_menodate" runat="server"></asp:Label>.</u></span>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Sub :-</b>  Sanction of Incentives to industrial Enterprises under IIPP/T-IDEA/T-PRIDE Schemes-Online Module- Deviation of Timelines-Show Cause Notice issued-Reg.                       
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ref :-  
                    1)Circular No.20/1/2014/2323/T-IDEA/EODB Dated:
                                                <asp:Label ID="lblrefdate" Text="02/08/2017" runat="server" Visible="true" Font-Bold="true"></asp:Label><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2)Circular No. 30/1/2323/T-IDEA Guidelines, Dated: 
                                                <asp:Label ID="Label1" Text="18/03/2021" runat="server" Visible="true" Font-Bold="true"></asp:Label><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 3)Application of  
                    <asp:Label ID="lbl_industryname" runat="server" Text="M/s. Shine Industries" Font-Bold="true"></asp:Label>
                    for sanction of 
                    <asp:Label ID="lbl_incentives" runat="server" Text="Incentive name" Font-Bold="true"></asp:Label>
                    Application No <asp:Label ID="lbl_refapplicationdate" Text="23/07/2020" runat="server" Font-Bold="true"></asp:Label><br />


                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <b>*&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;&nbsp;* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    In the reference 1st cited, instructions were issued to process the incentives claim applications through TS-iPASS online module within the prescribed time limits and it was also instructed to strictly adhere to the timelines. The time limit prescribed for verification by the GM/DIC and Issue of Acknowledgement of accepting the online application and assign for inspection in case of full shape (or) raise query in case of shortfall is (7) days.
                    <%--In the reference cited,instructions were issued to process the incentives applications through online TS-iPASS online modules within the prescribed time limits and it was instructed to strictly adhere to the timelines.
                    The time limit for verfication by the GM and Issue of Acknowledgement of accepting the online application and assign for inspection (or) raise shortfall query is 7 days.     --%>              
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Inspite of clear cut instructions, the GM, <asp:Label ID="lbldistrictname" runat="server" Text="dicname" Font-Bold="true"></asp:Label>
                    failed to adhere to the timelines  prescribed in processing online claim for incentives received from 
                     <asp:Label ID="lbl_applicationindustries" runat="server" Text="M/s Shine Industries" Font-Bold="true"></asp:Label>
                    has filed for incentive application 
                      <asp:Label ID="lbl_incentiveapplicationtype" Text="IS/PV/PT" runat="server" Font-Bold="true"></asp:Label>
                    i.e., (7) working days, thus violated the guideline. 
                   <%-- <asp:Label ID="lbl_incentiveappdate" runat="server" Text="23/07/2020" Font-Bold="true"></asp:Label>
                    .However,query has been raised on the same on
                      <asp:Label ID="lbl_queryraisedate" runat="server" Text="03/03/2021" Font-Bold="true"></asp:Label>
                    .There is a time lapse of 
                    <asp:Label ID="lbl_timelapse" runat="server" Text="More than 7 Months" Font-Bold="true"></asp:Label>
                    in intial processing of the application inspite of strict instructions on processing of applications.--%>
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   In view of the above and as per the orders issued in circular vide ref. 2nd cited, General Manager, District Industries Centre,
                    <asp:Label ID="lbl_District" runat="server" Text="Medak" Font-Bold="true"></asp:Label>
                    is directed to show cause for the delay in processing the claim application and submit explanation as to why action should not be initiated against the GM for violating the guidelines.
                    
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   The explanation should reach this office within 10 days from the date of receipt of this notice and if not received, it would be construed that there is no explanation to offer and disciplinary action will be initiated as per CCA rules.
                </span>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 25px; padding-bottom: 10px; text-align: left">
                
                <span class="pull-right">
                <span style="font-weight: bold;text-align: center;">
                <asp:Label ID="lbl_coIaddress" runat="server" Text="" Font-Bold="true" style="text-align: center;"></asp:Label>
                
                <br />
                Additional Director of Industries
                </span><br />
                    <br />

                </span>

            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <span style="float: left;"><span style="float: left;"><b>To,</b></span><br />
                            <asp:Label ID="lbl_toapplicationname" Text="The General mangers" runat="server" Font-Bold="true"></asp:Label>,<br />
                            <asp:Label ID="lbl_toindustryname" runat="server" Text="District Industries Centre" Font-Bold="true"></asp:Label>,<br />
                            <asp:Label ID="lbl_todistrictname" runat="server" Text="Medak" Font-Bold="true"></asp:Label><br />
                        </span>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"></div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"></div>
                </div>
            </div>
            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="tr1" runat="server" visible="false">
                <span class="floatleft auto-style3">Copy to the General Manager, District Industries Centre,&nbsp;<asp:Label ID="lblDistrict1" runat="server" Font-Bold="true"></asp:Label>
                    &nbsp;District for information. Copy to the Branch Manager,
                                        &nbsp;<asp:Label ID="lblBankDtls" runat="server" Font-Bold="true"></asp:Label>
                    &nbsp;Branch, for  information.
                </span>
            </div>--%>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <br />
                <span class="floatleft auto-style3">This is computer generated document no signature required.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; font-weight: bold">
                *&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;&nbsp;*
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <asp:Label ID="lblFooter" runat="server" Text="Chirag Ali Lane, Abids, Hyderabad – 500 001, Phone No.040-23441600 website: http://www.industries.telangana.gov.in"></asp:Label>
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
