<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintADMGappl.aspx.cs" Inherits="UI_TSiPASS_PrintADMGappl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            font-size: 13px;
            padding: 10px10px10px10px;
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
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>ADM&G APPLICATION FORM</h3>
                </div>
                <br />
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td>ADM&G Application No:
                                </td>
                                <td>
                                    <asp:Label ID="lblApplNo" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>NAME OF Mineral
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblNameOfMineral" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Total Extent in Hectors</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblExtHctors" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>District
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                         
                            <tr>
                                <td>Mandal
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Village<br />
                                    (Multiple Villages may Present)</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblVillage" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Survey No.<br />
                                    (Multiple Survey Nos may Present)</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Individual Extent<br />
                                    (For above Survey Nos )</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPartExtent" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Mobile No.</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Email</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                              <tr>
                                <td>Aadhar</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblAadhar" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                               
                        </table>
                    </div>
                   
                   
                       <div align="center">                           
                            <div align="center">                               
                                <div align="center">
                                    <div style="padding-top: 25px;" align="center">                                        
                                        
                                        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                            type="button" value="Print" /><br />
                                    </div>
                                </div>
                            </div>
                        </div>
    </form>
</body>
</html>
