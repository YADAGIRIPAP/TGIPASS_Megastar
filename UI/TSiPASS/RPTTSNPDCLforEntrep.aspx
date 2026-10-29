<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RPTTSNPDCLforEntrep.aspx.cs" Inherits="UI_TSiPASS_RPTTSNPDCLforEntrep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .padding {
            margin: 10px 10px 10px 10px;
            padding-left: 10px;
        }

        .style1 {
            height: 41px;
        }

        .bld {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="row" align="left">
                <div class="col-lg-11">
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            <table align="center" style="width: 70%; border-color: Black; font-family: Verdana; font-size: 10pt;" border="1"
                                cellpadding="1" cellspacing="1">
                                <tr>
                                    <td colspan="4" align="center">
                                        <div class="panel-heading" align="center">
                                            <h3 class="panel-title">TSNPDCL Feasibility Report</h3>
                                        </div>

                                        <br />
                                        <img src="telanganalogo.png" height="60px" width="60px" alt="TSiPASS" />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bld">NAME OF SUBSTATION
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNameofSubStation" runat="server" />
                                    </td>
                                    <td class="bld">FROM FEEDER
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFromFeeder" runat="server" />
                                    </td>
                                </tr>
                               
                                <tr>
                                     <td class="bld">TF ISSUEDATE
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIssueDate" runat="server" />
                                    </td>
                                    <td class="bld">DESIGNATED ISSUE OFFICER
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDesgOfficer" runat="server" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="bld">DE OPERATION
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDEOperation" runat="server" />
                                    </td>
                                    <td class="bld">SE OPERATION
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSEOperation" runat="server" />
                                    </td>
                                </tr>
                                   <tr>
                                    
                                    <td class="bld">ADE OPERATION
                                    </td>
                                    <td>
                                        <asp:Label ID="lblADEOperation" runat="server" />
                                    </td>
                                    <td class="bld">TSNPDCL MOBILE NO
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMobNo" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bld">FEASIBLE-NON FEASIBLE
                                    </td>
                                    <td>
                                        <asp:Label ID="lblfeasible" runat="server" />
                                    </td>
                                    <td class="bld">REASON FOR NON FEASIBLE
                                    </td>
                                    <td>
                                        <asp:Label ID="lblreasonnonfeasible" runat="server" />
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
