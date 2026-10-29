<%@ Page Title=":: TS-iPASS ::  " Language="C#" AutoEventWireup="true" CodeFile="RPTTSSPDCLforEntrep.aspx.cs"
    Inherits="TSTBDCReg1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .padding
        {
            margin: 10px 10px 10px 10px;
            padding-left: 10px;
        }
        .style1
        {
            height: 41px;
        }
        .bld
        {
        	font-weight:bold;
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
                        <table align="center" style="width: 70%; border-color: Black; font-family:Verdana; font-size:10pt;" border="1" 
                            cellpadding="1" cellspacing="1">
                            <tr>
                                <td colspan="4" align="center">
                                    <div class="panel-heading" align="center">
                                        <h3 class="panel-title">
                                            TSSPDCL Feasibility Report</h3>
                                    </div>
                                
                                    <br />
                                    <img src="telanganalogo.png" height="60px" width="60px" alt="TSiPASS" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    NAME OF SUBSTATION
                                </td>
                                <td>
                                    <asp:Label ID="lblNameofSubStation" runat="server" />
                                </td>
                                <td class="bld">
                                    EXIS PTR CAPACITY
                                </td>
                                <td>
                                    <asp:Label ID="lblExisPtrCapacity" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    MD REACHED
                                </td>
                                <td>
                                    <asp:Label ID="lblMDReached" runat="server" />
                                </td>
                                <td class="bld">
                                    PROLOAD PTR
                                </td>
                                <td>
                                    <asp:Label ID="lblProLoadPTR" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    TOTAL PTR
                                </td>
                                <td>
                                    <asp:Label ID="lblTOTPtr" runat="server" />
                                </td>
                                <td class="bld">
                                    FROM FEEDER
                                </td>
                                <td>
                                    <asp:Label ID="lblFromFeeder" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    PRESENT LOAD FEEDER
                                </td>
                                <td>
                                    <asp:Label ID="lblPresLoadFeeder" runat="server" />
                                </td>
                                <td class="bld">
                                    NOW PROPOSED FEEDER
                                </td>
                                <td>
                                    <asp:Label ID="lblNowPropFeeder" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    TOT FEEDER
                                </td>
                                <td>
                                    <asp:Label ID="lblTOTFeeder" runat="server" />
                                </td>
                                <td class="bld">
                                    DEDI FEEDER
                                </td>
                                <td>
                                    <asp:Label ID="lblDEDIFeeder" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    FROM TSTRANSCO
                                </td>
                                <td>
                                    <asp:Label ID="lblFromTSTransco" runat="server" />
                                </td>
                                <td class="bld">
                                    TF ISSUEDATE
                                </td>
                                <td>
                                    <asp:Label ID="lblIssueDate" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    DESIGNATED ISSUE OFFICER
                                </td>
                                <td>
                                    <asp:Label ID="lblDesgOfficer" runat="server" />
                                </td>
                                <td class="bld">
                                    ADE OPERATION
                                </td>
                                <td>
                                    <asp:Label ID="lblADEOperation" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    DE OPERATION
                                </td>
                                <td>
                                    <asp:Label ID="lblDEOperation" runat="server" />
                                </td>
                                <td class="bld">
                                    SE OPERATION
                                </td>
                                <td>
                                    <asp:Label ID="lblSEOperation" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bld">
                                    TSSPDCL HT NO
                                </td>
                                <td>
                                    <asp:Label ID="lblHTNO" runat="server" />
                                </td>
                                <td class="bld">
                                    TSSPDCL MOBILE NO
                                </td>
                                <td>
                                    <asp:Label ID="lblMobNo" runat="server" />
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
