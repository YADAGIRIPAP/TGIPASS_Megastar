<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Waltform16A.aspx.cs" EnableEventValidation="false" Inherits="UI_TSiPASS_Waltform16A" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proceedings Letters</title>
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
    <style type="text/css">
        .div3 {
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
    <form id="form1" runat="server">
       <div runat="server" id="employeelistDiv">
        <div align="center">
            <div align="center" style="text-align: center">
                <div style="text-align: center">
                    <div align="center">
                    </div>
                    <div align="center" id="Receipt" runat="server">
                        <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small; width: 1000px;">
                            <tr>
                                <td>
                                    <br />
                                    <center>
                                     <h2>FORM – 16<br />
(See Rule 17) <br /> Registration of Rigs / Hand boring sets
</h2> 
                                    </center>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td width="1000px" style="text-align: center">

                                    <b>Subject:</b>Approval for
                                    <asp:Label ID="lbl_applicationtype" runat="server"></asp:Label>
                                    Registration of Rigs / Hand boring sets 
                                    for the Applicant <b>
                                        <asp:Label runat="server" ID="lbl_applicant"></asp:Label></b> at
                                    <b>
                                        <asp:Label runat="server" ID="lbl_RTODistrict"></asp:Label>
                                    </b>
                                    District.
                                </td>
                            </tr>
                            <tr>
                                <td width="900px">
                                    <p style="height: 208px; width: 993px">
                                        The vehicle bearing number/hand boring set
                                        <b><asp:Label ID="lbl_Registrationvehiclenumber" runat="server"></asp:Label></b>
                                        belonging to sri
                                        <b><asp:Label ID="lbl_nameofapplicant" runat="server"></asp:Label></b>
                                        of
                                        <b><asp:Label ID="lbl_address" runat="server"></asp:Label></b>
                                        (Address) is registered with the water,Land and Trees Authority of Telangana State as a rig / hand boring set for operation with in the territorial area of Telangana.
                                      
                                       <br />
                                        <br />
                                        This registration is valid up to 
                                        <b><asp:Label ID="lbl_validitydate" runat="server"></asp:Label></b>
                                        <br />
                                        <br />
                                        This registration does not convey any endorsement of the vehicle for its performance and does not amount to recommendation for employing the rig but only conveys that the rig / hand boring set is permitted to operate with in the territorial jurisdiction of Telangana State subject to all other conditions as per the law and rules in force.

                                        <br /><br />
                                        The rig shall not be used for drilling of bore well without the valid permission under TSWALTA. Failing which it is liable for confiscation.
                                        <br />

                                        <br />

                                    </p>
                                    <br />
                                    <p style="text-align: left; height: 48px; width: 1009px;">
                                        <b>Place:</b>
                                        <asp:Label runat="server" ID="lbl_place"></asp:Label>
                                        <br />
                                        <b>Date:<br />
                                            <b>
                                                <asp:Label runat="server" ID="lbl_currentdate"></asp:Label></b>
                                    </p>
                                    <p style="text-align: right; height: 48px; width: 1016px;">
                                        Designated Officer,<br />
                                        Water, Land and Tree Authority<br />
                                        (with Seal)<br />
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Button ID="btn_print" runat="server" Height="32px" Width="90px" CssClass="btn btn-warning"
                                        Text="Download print" OnClientClick="javascript:CallPrint('Receipt')" />

                                      <asp:Button ID="btn_pdf" runat="server" Visible="false" Height="32px" Width="90px" CssClass="btn btn-warning" OnClick="btn_pdf_Click"
                                        Text="Download PDF"/>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: center; color: red">
                                    <asp:Label ID="lblerrormsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
          </div>
    </form>
</body>
</html>
