<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaQueryRaiseShortFallLetterGMtoApplicantApproval.aspx.cs"
    Inherits="UI_TSiPASS_ProformaQueryRaiseShortFallLetterGMtoApplicantApproval" %>

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
         .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
         border:1px solid #000000 !important;
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
    </script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="Receipt" runat="server" style="border: 3px solid #000000; text-align: center;">
            <div style="padding-top: 14px">
            </div>
            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" style="width: 75px; height: 75px;" alt="" />
            <h3 style="color: #0000FF;">
                <asp:Label Font-Bold="true" Font-Size="14pt" ID="Label1" runat="server">GOVERNMENT OF TELANGANA <br />O/o GM, DIC :: </asp:Label>
                <asp:Label Font-Bold="true" Font-Size="14pt" ID="lblhead2" runat="server"></asp:Label>
            </h3>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px;">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" style="text-align: left;">
                        <span style="float: left;"><span style="float: left;"><b>From,</b></span><br />
                            The General Manager,<br />
                            District Industries Centre,<br />
                            <asp:Label ID="lblletterFrom" runat="server"></asp:Label>
                        </span>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"></div>
                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5" style="text-align: left;">
                        <span style="float: right;"><span style="float: left;"><b>To,</b></span>
                            <br />
                            <asp:Label ID="lblEnterpreneurDetails1" runat="server"></asp:Label></span>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; font-weight:bold">
                <span class="auto-style6">Letter No :</span>
                                            <asp:Label ID="lblLetterNo" CssClass="auto-style6" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style6">Dated :</span>
                                            <asp:Label ID="lblLetterDate" CssClass="auto-style6" runat="server"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15">
                <span class="floatleft" style="font-weight: bold">Sir,</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Sub:- Incentives
                                        - &nbsp;
                                        <asp:Label ID="lblTIdeaTPride" runat="server"></asp:Label>&nbsp; - Application of
                                        &nbsp;<asp:Label ID="lblEnterpreneurDetails" runat="server"></asp:Label>&nbsp;
                                        <asp:Label ID="lblEntDist" runat="server"></asp:Label>&nbsp; District – Reimbursement
                                        Scheme – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Your Application
                                        No.
                                        <asp:Label ID="lblRefLetterNo" runat="server"></asp:Label>
                    &nbsp; Dated:&nbsp;<asp:Label ID="lblRefLetterDate" runat="server"></asp:Label>&nbsp;
                                        of the G.M., DIC,&nbsp;<asp:Label ID="lblEntDist1" runat="server"></asp:Label>&nbsp;
                                        &nbsp;District.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="padding-top: 14px">
                <b>******* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="padding-top: 14px">
                <span class="floatleft auto-style3">With reference
                                        to your applications cited, it is to inform that on scrutiny / verification of your
                                        claim application, the following shortfalls are noticed.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="padding-top: 20px">
                <asp:GridView ID="gvShortfalls" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" GridLines="Both" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.No">
                            <ItemTemplate>
                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IncentiveName" HeaderText="Type of incetive" />
                        <asp:BoundField DataField="QueryDescription" HeaderText="Shortfalls" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 20px">
                <span class="floatleft auto-style3">Therefore,
                                        You are requested to submit the above document immediately to enable us to take
                                        necesary action on your claim application the document should reach the undersign
                                        within a week from the date of receipt of this letter.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 20px">
                <strong><span class=" pull-right">Yours faithfully,<br />
                    
                        <asp:Label ID="lblName" runat="server"></asp:Label><br />

                </span></strong>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 20px; padding-bottom: 20px">
                <span class="floatleft auto-style3">Copy
                                        to Concerned Inspecting Officer for necessary action.
                </span>
            </div>
        </div>
        <div class="container" id="Div1" runat="server" style="text-align: center; vertical-align: bottom;">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
            </div>
        </div>
    </form>
</body>
</html>
