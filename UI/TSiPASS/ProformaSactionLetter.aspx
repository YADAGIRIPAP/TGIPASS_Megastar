<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaSactionLetter.aspx.cs" Inherits="UI_TSiPASS_ProformaSactionLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DraftPrint</title>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript">
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
    </script>
    <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            border: 2px solid ActiveCaptionText;
            padding: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="font-size: large">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <br />
                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="lblheadTPRIDE" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                    <br />
                    <br />
                </div>
                <div align="center" id="Receipt" runat="server">
                    <table style="width: 1000px">
                        <tr>
                            <td style="vertical-align: top; width: 400px">From<br />
                                The General Manager,<br />
                                District Industries Centre,<br />
                                <asp:Label ID="lblletterFrom" runat="server"></asp:Label></td>
                            <td style="vertical-align: top; width: 400px">To<br />
                                The Commissioner of Industries,<br />
                                Government of Telangana,<br />
                                Chirag Ali Lane, Abids,<br />
                                Hyderabad.</td>
                        </tr>
                        <tr>
                            <td style="text-align: center">Letter No :
                                <asp:Label ID="lblLetterNo" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center">Dated :
                                <asp:Label ID="lblLetterDate" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">Sir,</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- 
                                <span style="font-weight: bold">
                                    <asp:Label ID="lblTIdeaTPride1" runat="server"></asp:Label></span>&nbsp; scheme - Sanction of  Investment Subsidy to
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1" runat="server"></asp:Label></span>&nbsp;– Intimation - Regarding.</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ref : - 1.  G.O.Ms.No. 29, Inds & Com [IP] Dept, dt.&nbsp;<span style="font-weight: bold">29.11.2014</span>&nbsp; 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                2. G.O.Ms.No.78, Inds & Com [IP & INF] Dept, dt. &nbsp;<span style="font-weight: bold"> 09.10.2015</span>.
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                3. Your application filed in this office on dated. &nbsp;<span style="font-weight: bold">29.05.2015</span>.
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 4. DIPC meeting held on  &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDICMeetingDate" runat="server"></asp:Label></span>.
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">********</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">With reference to your claim application 3rd cited, it is to inform that your unit has been sanctioned 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblIncentiveType1" runat="server"></asp:Label></span>&nbsp;Rs.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblAmountSanc" runat="server"></asp:Label></span>&nbsp; under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIDEATPRIDE" runat="server"></asp:Label></span>&nbsp;
                                Scheme.
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">The Investment Subsidy will be released as and when your unit’s turn comes as per seriatim for disbursement of available funds. 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: center">
                                <br />
                                Yours faithfully,
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left"></td>
                            <td style="text-align: center"><strong>General Manager</strong></td>
                        </tr>
                    </table>
                    <table style="width: 1000px">
                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="text-align: center">
                                <asp:Button ID="Button1" runat="server" Height="32px" Width="90px" CssClass="btn btn-warning" Text=" Print " OnClientClick="javascript:CallPrint('Receipt')" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
