<%@ Page Language="C#" MasterPageFile="INFMASTER.master" AutoEventWireup="true" CodeFile="IIPC_COIDASHBOARD.aspx.cs" Inherits="UI_TSiPASS_IIPC_COIDASHBOARD" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript">



        function OpenPopup() {

            window.open("Lookups/frmcjfslookup.aspx", "List", "scrollbars=yes,resizable=yes,width=550,height=320");

            return false;
        }



        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }

        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
        }


        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets,  and Characters  Only");
            }
        }

    </script>
    <style type="text/css">
        .copyright {
            clear: both;
            width: 100%;
            margin: 0px auto;
            padding: 0px;
            display: block;
            font-size: 12px;
            text-align: center;
        }

        .container {
            width: 1170px;
            margin: 0 auto;
        }

        .col-1 {
            float: left;
            text-align: left;
            width: 50%;
            color: #fff;
        }

        .col-2 {
            float: right;
            text-align: right;
            width: 50%;
            color: #fff;
        }

@keyframes blink {
           25% {
               opacity: 0.0;
           }

           50% {
               opacity: 1.0;
           }

           75% {
               opacity: 0.0
           }

           100% {
               opacity: 1.0;
           }
       }

       @-webkit-keyframes blink {
           50% {
               opacity: 1.0;
           }

           75% {
               opacity: 0.0
           }

           100% {
               opacity: 1.0;
           }
       }

       .blink12 {
           animation: blink 2s step-start 0s infinite;
           -webkit-animation: blink 2s step-start 0s infinite;
           color: Yellow;
           font-weight: bold;
           font-size: 14px;
       }

       .blink13 {
           animation: blink 5s step-start 0s infinite;
           -webkit-animation: blink 5s step-start 0s infinite;
           color: Red;
           font-weight: bold;
           font-size: 14px;
       }

    </style>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration1]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration2]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtsurveynum]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtExtent]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtCJFSBeneficiery]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });


    </script>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr runat="server" id="maintr">
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <table style="width: 100%" cellpadding="10" cellspacing="10">
                    <tr>
                        <td style="height: 30px">
                            <asp:Label ID="Label437" runat="server" Visible="false" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                Width="210px">IIPC COI Dashboard</asp:Label>
                        </td>
                        <td style="height: 30px">
                        </td>
                        <td style="height: 30px">
                        </td>
                    </tr>
                    <tr id="trgm" runat="server" visible="false" style="color: #ff4615;" class="blink12">
                        <td>
                            <div>
                                <span style="font-weight: bold">Note : The release proceedings are issued for the SCP
                                    and TSP on dt: 09.10.2020
                                    <br />
                                    <br />
                                    Vide release proceeding No: 39/1/2020/63428 dt: 09.10.2020 <a href="https://ipass.telangana.gov.in/GoCOIIncentiveAttachments/23/SCP%20Scan%20Proceedings%202020.pdf"
                                        target="_blank">Click here </a>
                                    <br />
                                    <br />
                                    Vide release proceeding No : 39/2/2020/63442 dt: 09.10.2020 <a href="https://ipass.telangana.gov.in/GoCOIIncentiveAttachments/35/TSP%20PROCEDDINGS%2009102020.pdf"
                                        target="_blank">Click here </a>
                                    <br />
                                    <br />
                                    The GM, DIC was requested to guide the applicant to upload the required documents
                                    on the portal within 21 days from the day of issue of the release proceedings. However,
                                    it is observed that many applicants are not uploaded the required documents. GM's
                                    are once again requested to guide the applicants to upload the documents on portal
                                    by dated: 13/11/2020, failing which the amount released to such units will be allocated
                                    to other units as per seriatim. </span>
                                <br />
                                <br />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;
                        </td>
                        <td align="center" style="text-align: center">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                         <td align="center" style="text-align: center">
                            <asp:Button ID="btnmsmedata" runat="server" CssClass="btn btn-danger" Height="91px"
                                OnClick="btnmsmedata_Click" TabIndex="10" Text="Speech Inputs" Font-Bold="True"
                                Width="268px" ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btspeech" runat="server" CssClass="btn btn-primary" Height="91px"
                                OnClick="btspeech_Click" TabIndex="10" Text="Speech Report" ValidationGroup="group"
                                Width="268px" Font-Bold="True" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                       
                        <td align="center" style="text-align: center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;
                        </td>
                        <td align="center" style="text-align: center">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;
                        </td>
                        <td align="center" style="text-align: center">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="trnewinc" runat="server" visible="true">
                        <td align="center" style="text-align: center">
                             &nbsp;</td>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                         <td>
                            &nbsp;
                        </td>
<%--                        <td align="center" style="text-align: center">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <%--<td align="center" style="text-align: center">
                            <asp:Button ID="btn_tourismagent" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="Travel Agent" ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" Visible="false" OnClick="btn_tourismagent_Click" />
                        </td>--%>
                         <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td align="center" style="text-align: center">                          
                        </td>
                       <td align="center" style="text-align: center">
                        </td>
                    </tr>
                <tr>
                    <td align="center" style="text-align: center">
                            &nbsp;</td>
                        <td align="center" style="text-align: center">
                            &nbsp;</td>
                        
                        <td align="center" style="text-align: center"></td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr align="center" runat="server" id="tr_gwcomdas" visible="false">
                         <%--  <td align="center" style="text-align: center"></td>--%>
                    <td align="center" style="text-align: center">
                           &nbsp;</td>
                        <%--<td align="center" style="text-align: center"></td>--%>
                        
                       
                    </tr>



        <tr runat="server" id="Tr1" visible="false">
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <table style="width: 100%" cellpadding="10" cellspacing="10">
                    <tr>
                        <td style="height: 30px">
                            &nbsp;</td>
                        <td style="height: 30px">
                        </td>
                        <td style="height: 30px">
                        </td>
                    </tr>
                    <tr id="tr2" runat="server" visible="true">
                        <td align="center" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

