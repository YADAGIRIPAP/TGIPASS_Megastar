<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AcknowledgementPrint.aspx.cs" Inherits="AcknowledgementPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 170px;
        }

        .auto-style2 {
            height: 50px;
        }

        .auto-style3 {
            height: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" style="width: 80%">
                <tr>
                    <td class="auto-style1">
                        <center>
                    <img src="telanganalogo.png" width="75px" height="75px" />
                </center>
                    </td>
                    <td class="auto-style1">
                        <h3>Telangana State Industrial Project Approval
                            <br />
                            & Self Certification System ( TSiPASS )
                        <br />
                            GOVERNMENT OF TELANGANA</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center" class="auto-style2">
                        <h3>ACKNOWLEDGEMENT</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;UID No :<asp:Label ID="lbluidno" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This is to acknowledge the receipt of application of M/s.
                        <asp:Label ID="lblunitname" runat="server"></asp:Label>, 
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;Sy.No.
                        <asp:Label ID="lbladdress" runat="server"></asp:Label>, (v),
                        <asp:Label ID="lblvillage" runat="server"></asp:Label>, (m),
                        <asp:Label ID="lblmandal" runat="server"></asp:Label>, district for following approvals.</td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <%--<td colspan="2" align="center" style="width: 100%">
                        <table style="width: 90%">
                            <tr>
                                <td>Sl.No.</td>
                                <td>Name of the approval</td>
                                <td>Department Name</td>
                                <td>Payment Received</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Label ID="lblNameofApproval" runat="server"></asp:Label></td>
                                <td><asp:Label ID="lblDepartmntnm" runat="server"></asp:Label></td>
                                <td><asp:Label ID="lblpaymntrecev" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </td>--%>
                    <td colspan="2" align="center">
                        <asp:GridView ID="gvdata" runat="server"></asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Label ID="lblproff" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Label ID="lblcity" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
