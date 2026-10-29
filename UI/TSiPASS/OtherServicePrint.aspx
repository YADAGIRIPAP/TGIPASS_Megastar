<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OtherServicePrint.aspx.cs" Inherits="UI_TSiPASS_OtherServicePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table bgcolor="White" width="100%" style="font-family: Verdana;">
                                    <tr>
                                        <td align="left" colspan="4" style="padding: 10px; margin: 5px; font-weight: bold;">A.
                                            <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px">COMMON DETAILS OF THE ENTREPRENUER</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">1. </td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">EM Part - II/IEM/IL No/Udyog Aadhar No</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <asp:Label ID="txtudyogAadharNo" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">2. </td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">Unit Name</td>

                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span>
                                                <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                            </span>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">3. </td>
                                        <td style="text-align: left; width: 250px; padding: 5px; margin: 5px">Name of the  Managing Director /Managing Partner / Proprietor</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span>
                                                <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">4. </td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">TIN/CST/GST</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <span>
                                                <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                            </span>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">5. </td>
                                        <td style="text-align: left; width: 250px; padding: 5px; margin: 5px">PAN Number of the  Managing Director /Managing Partner / Proprietor</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 5px; margin: 5px">
                                            <span>
                                                <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                            </span></td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">6. </td>
                                        <td style="padding: 5px; margin: 5px">Category</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="ddlCategory" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">7. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Type of Organization</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                       <%-- <td style="padding: 10px; margin: 5px; font-weight: bold; padding: 10px; margin: 5px;">8. </td>
                                        <td>Industry Status 
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;"><span>
                                            <asp:Label ID="ddlindustryStatus" runat="server">                                                      
                                            </asp:Label>
                                        </span>
                                        </td>--%>

                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">9. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Date of commencement for Production</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">10. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Social Status</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="rblCaste" runat="server"></asp:Label>
                                            </span>
                                        </td>

                                    </tr>

                                     <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">11. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;"> Uid Number</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                          <span>
                                                <asp:Label ID="lblcfeno" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <span runat="server" id="subcste" visible="false">
                                         <td style="padding: 10px; margin: 5px; font-weight: bold;">10a. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Sub Caste</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="ddlsubcaste" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                            </span>
                                        <%--<td style="padding: 10px; margin: 5px; font-weight: bold;">12. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">CFO Uid Number</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="lblcfono" runat="server"></asp:Label>
                                            </span>
                                        </td>--%>

                                    </tr>

                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">13. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Physically Handicapped</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="lblPhc" runat="server"></asp:Label>
                                            </span>
                                        </td>


                                    </tr>
                                    <tr id="trEmPartNo11" runat="server" visible="false">
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">11. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">EM Part - II/IEM/IL No:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="lblEMPartNo" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="4" style="padding: 10px; margin: 5px; font-weight: bold;">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                                ForeColor="Black">B. UNIT ADDRESS</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">1. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">District</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">2.</td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Survey No
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                            </span>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">3. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Mandal</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">4. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Street</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                            </span>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">5. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Village</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">6. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Mobile Number
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                            </span>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">7. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Email Id</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px; width: 250px">
                                            <span>
                                                <asp:Label ID="txtunitemailid" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;"></td>
                                        <td style="text-align: left;">&nbsp;</td>
                                        <td style="text-align: left;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="8" style="padding: 10px; margin: 5px; font-weight: bold;">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px"
                                                ForeColor="Black">C. OFFICE ADDRESS</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">1. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">District</td>

                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">2. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Survey No
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                            </span>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">3. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Mandal</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">4. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Street
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                            </span>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">5. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Village</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">6. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Mobile Number
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">
                                            <span>
                                                <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                            </span>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px; font-weight: bold;">7. </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px;">Email Id</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="text-align: left; padding: 10px; margin: 5px; width: 250px">
                                            <span>
                                                <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td style="text-align: left;"></td>
                                        <td style="text-align: left;">
                                            <span></span>

                                        </td>
                                    </tr>


                                </table>
    </div>
    </form>
</body>
</html>
