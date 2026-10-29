<%@ Page Language="C#" AutoEventWireup="true" CodeFile="waltaform4.aspx.cs" Inherits="UI_TSiPASS_waltaform4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Form-4</title>
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
                                     <h2>FROM–4<br />
Rejection Order of the Designated Officer
</h2> 
                                    </center>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="1000px" style="text-align: center">

                                        <b>Subject:</b>Rejection Order for
                                    Permission of digging a new well for 
                                     <asp:Label ID="lbl_typeofappl" runat="server"></asp:Label>
                                    <%--agriculture / drinking water--%> 
                                    </td>
                                </tr>
                                <tr>
                                    <td width="900px">
                                        <p style="height: 208px; width: 993px">
                                            Sri <b>
                                                <asp:Label ID="lbl_nameofapplicant" runat="server"></asp:Label></b> your application for digging a new well for 
                                             <%--   agriculture / drinking water --%>
                                                 <b>
                                             <asp:Label ID="lbl_depthofwater" runat="server"></asp:Label></b>
                                              purpose
                                        Sy. No <b>
                                             <asp:Label ID="lbl_location" runat="server"></asp:Label>
                                         
                                        </b>Village / Town
                                              <asp:Label ID="lbl_address" runat="server"></asp:Label>
                                            is hereby rejection.
                                        <br />
                                            <br />

                                            Reasons for rejection <b>
                                                <asp:Label ID="lbl_rejectedreason" runat="server"></asp:Label></b>
                                            <br />
                                            <br />
                                            (1)	TS TRANSCO expressed inability for power connection.
                                          <br />
                                            <br />
                                            (2)	Rejection by Ground Water Department (survey report of geologist is enclosed)
                                         
                                        </p>
                                        <br />
                                        <br />


                                        <p style="text-align: left; height: 48px; width: 1009px;">
                                            <br />
                                            <br />
                                            <b>Place:</b>
                                            <asp:Label runat="server" ID="lbl_place"></asp:Label>
                                            <br />
                                            <b>Date:</b>
                                                
                                                    <b><asp:Label runat="server" ID="lbl_currentdate"></asp:Label></b>
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
                                        <asp:Button ID="btn_print" BackColor="Green" runat="server" Height="32px" Width="100px" CssClass="btn btn-warning"
                                            Text="Download print" OnClientClick="javascript:CallPrint('Receipt')" />
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

