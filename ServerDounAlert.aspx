<%@ page language="C#" autoeventwireup="true" codefile="ServerDounAlert.aspx.cs" inherits="ServerDounAlert" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
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

        }

        .auto-style1 {
            width: 874px;
        }

        .auto-style2 {
            height: 226px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">


                <div align="center">
                    <div align="center" id="trproporalexisting" runat="server">
                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;" class="auto-style2">
                            <tr>
                                <td align="center" colspan="4" style="text-align: center; background-color: white;" class="auto-style1">
                                    <asp:Label ID="lblIndustries2" runat="server" Font-Bold="True" Font-Size="50px" ForeColor="red" Width="100%">
                                        <h5 style="font: bold; font-size: larger">Attention:
                                            Server up-gradation is under process. The downtime would be from 9th to 11th September 2023, 6:00 am.  Regret the inconvenience caused.</h5>
                                    </asp:Label>
                                </td>
                            </tr>


                        </table>
                    </div>

                </div>
            </div>
        </div>


    </form>
</body>
</html>

