<%@ page language="C#" autoeventwireup="true" codefile="CFEPrint.aspx.cs" inherits="Default2"
    title="CFE-Print" %>

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
    </style>

    <style>
        /*.survyno {
    width: 52%;
    overflow-x: auto;
}*/

.survyno table {
    /*width: 100% !important;*/
    table-layout: fixed;
    border-collapse: collapse;
}

.survyno td {
    padding: 8px;
    vertical-align: middle;
    word-wrap: break-word;
    overflow-wrap: break-word;
    word-break: break-word;
}

.survyno td:nth-child(1),
.survyno td:nth-child(3) {
    width: 15%;
    font-weight: 500;
}

.survyno td:nth-child(2),
.survyno td:nth-child(4) {
    width: 35%;
}

@media (max-width: 768px) {
    .survyno table {
        font-size: 13px;
    }

    .survyno td {
        padding: 6px;
    }
}
.survyno td,
.survyno span,
.survyno label {
   white-space: normal !important;
    word-break: break-all;
    font-weight: 700;
    font-family: system-ui;
    font-size: 14px;
}
td span {
    font-family: system-ui;
    font-weight: 700;
}
table {
    border-collapse: collapse !important;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center" runat="server" id="DIVlogo">
                    <center>
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>
                        <%--TS-iPASS COMMON APPLICATION FORM--%>
                        <asp:Label ID="lblipass" runat="server" Text="TS-iPASS COMMON APPLICATION FORM"></asp:Label>
                    </h3>
                </div>
                <b>
                    <asp:Label ID="lblannexure" runat="server" Visible="false" Text="ANNEXURE-II"></asp:Label>
                </b>
                <br />
               
                <b>
                    <asp:Label ID="LBLGO" runat="server" Visible="false" Text="(To G.O.Ms.No.3, YAT & C(T&PMU) Department, Dated:12-12-2020)"></asp:Label>
                </b>
                <br />
               
                <b>
                    <asp:Label ID="lblTEXT" runat="server" Visible="false" Text="COMBINED APPLICATION FORM FOR ESTABLISHMENT(HOTEL)"></asp:Label>
                </b>
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td>UID No:
                                </td>
                                <td>
                                    <asp:Label ID="lblUidNo" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>NAME OF INDUSTRIAL UNDERTAKING
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblNameOfUndertaker" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>NAME OF PROMOTER
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblNameOfPromoter" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>S/o. D/o. W/o
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblSonOf" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div align="center">
                        <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">PROPOSED LOCATION OF UNIT ADDRESS
                                </td>
                            </tr>
                            <tr>
                                <td>Location of Factory
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblProposedLocation" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div align="center" class="survyno">
                        <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td>Survey No
                                </td>
                                <td>
                                    <asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                                <td>Name of District </br> Grampanchayat/IE/</br>IDA/SEZ
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblNameofGp" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Village/Town
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblvillage0" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Mandal
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMandal0" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>District
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDistrict0" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>PinCode
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPincode0" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Email-ID
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblEmail0" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Telephone
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTelephone0" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Total extent of site </br>area as per document(in Sq.mts)
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblExtentofSightArea" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Proposed area for </br>development</br>(in Sq mts)
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblProposedArea" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Total built-up area</br>(in Sq.mts)
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblBultupArea" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Existing width of </br>approach road</br>(in feet)
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbWidthToRoad" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Type of Approach </br> Road
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofRoad" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Land comes under
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandComesUnder" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Case type
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCaseType" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Category of Industry
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCategoryOfIndustry" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Caste
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCastes" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Building Approval
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblBuildingApproval" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Differently Abled
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbldiffabled" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Height of the </br>building(in mtrs.)
                                </td>
                                <td>
                                    <asp:Label ID="lblbuildingheight_new" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Type of Building
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="LBLTYPEOFBUILDING" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Is land part of
                                </td>
                                <td>
                                    <asp:Label ID="LBLISLANPARTOF" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
    <td>Women Entrepreneur
    </td>
    <td>
        <span>
            <asp:Label ID="LBLWOMENENT" runat="server"></asp:Label>
        </span>
    </td>
    <td>Minority
    </td>
    <td>
        <asp:Label ID="LBLMINORITY" runat="server"></asp:Label>
    </td>
</tr>
                                                        <tr>
    <td>Category of </br>Registration
    </td>
    <td>
        <span>
            <asp:Label ID="LBLCATOFREG" runat="server"></asp:Label>
        </span>
    </td>
    <td>Registration No
    </td>
    <td>
        <asp:Label ID="LBLREGNO" runat="server"></asp:Label>
    </td>
</tr>
                                                                                    <tr>
    <td>Registration Date
    </td>
    <td>
        <span>
            <asp:Label ID="LBLREGDATE" runat="server"></asp:Label>
        </span>
    </td>
    <td>Type of Factories
    </td>
    <td>
        <asp:Label ID="LBLTYPEOFFACTORY" runat="server"></asp:Label>
    </td>
</tr>
                             <tr>
     <td><asp:Label ID="lbllanusemastrplantext" runat="server" Text="Land Use as per Master Plan"> </asp:Label>
     </td>
     <td>
         <span>
             <asp:Label ID="LBLLANDUSEMASTERPLAN" runat="server"></asp:Label>
         </span>
     </td>
     <td>Affected in </br>Road Widening
     </td>
     <td>
         <asp:Label ID="LBLAFFECTEDROADWIDENING" runat="server"></asp:Label><br />
       

         
     </td>
 </tr>
                            <tr>
     <td>Land Conversion to
     </td>
     <td>
         <span>
             <asp:Label ID="lbllandconversionto" runat="server"></asp:Label>
         </span>
     </td>
     <td>
     </td>
     <td>
       

         
     </td>
 </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div align="center">
                        <div align="center">
                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                <tr>
                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                        <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">ADDRESS OF THE ENTREPRENUER</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Door No.
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDoorNo" runat="server"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>Street Name
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblStreetName" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Village/Town
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblvillage" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>State
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblState" runat="server"></asp:Label>
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
                                    <td>PinCode
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblPincode" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cell No
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Mandal
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Email-ID
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Telephone
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div align="center">
                            <div align="center" id="trproporalexisting" runat="server">
                                <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="lblIndustries2" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PROPOSAL</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Proposal For
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProposalFor" runat="server"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <%--Land (in Lakhs.)--%>
                                        </td>
                                        <td>
                                            <span></span>
                                        </td>
                                    </tr>
                                    <%--  <tr>

                                        <td>Building (in Lakhs.) </td>
                                        <td>&nbsp;</td>
                                        <td>Plant and Machinery(in Lakhs.)</td>
                                        <td>&nbsp;</td>
                                    </tr>--%>
                                    <tr>
                                        <td></td>
                                        <td style="font-weight: bold">A) Existing Investment
                                        </td>
                                        <td style="font-weight: bold">B) Expansion Investment
                                        </td>
                                        <td style="font-weight: bold">Total Investment
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">Land Value(in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLandCost" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblExpInvestLandValue" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalLandValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">Building Value(in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBuldingCost" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblExpInvestBuildingValue" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalBuilding" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">Plant and Machinery Value (in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPlantCost" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblExpInvestPlantlValue" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblToalPlantValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">Total Value (in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotExistingInvest" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblExpInvestTotalValue" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalInvestment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trTurnover1" runat="server" visible="false">
                                        <td style="font-weight: bold">Annual Turnover(in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblturnOver" Text="0" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTurnoverExp" Text="0" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalTurnover" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <br />
                            <div>
                                <div align="center" id="TRPROPOSALNEW" runat="server">
                                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                                <asp:Label ID="lblproposalnew" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PROPOSAL</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Proposal For
                                            </td>
                                            <td>
                                                <asp:Label ID="lblproposal" runat="server"></asp:Label>
                                                &nbsp;
                                            </td>

                                        </tr>

                                        <tr>
                                            <td></td>
                                            <td style="font-weight: bold">Proposed Investment
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold">Land Value(in Lakhs)
                                            </td>
                                            <td>
                                                <asp:Label ID="lblland" runat="server"></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold">Building Value(in Lakhs)
                                            </td>
                                            <td>
                                                <asp:Label ID="lblbuilding" runat="server"></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold">Plant and Machinery Value (in Lakhs)
                                            </td>
                                            <td>
                                                <asp:Label ID="lblplant" runat="server"></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold">Total Value (in Lakhs)
                                            </td>
                                            <td>
                                                <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                            </td>

                                        </tr>
                                        <tr id="trTurnover" runat="server" visible="false">
                                            <td style="font-weight: bold">Annual Turnover(in Lakhs)
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewTurnover" Text="0" runat="server"></asp:Label>
                                            </td>


                                        </tr>

                                    </table>
                                </div>
                            </div>
                            <br />
                            <br />
                        </div>
                        <div align="center">
                            <div align="center">
                                <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td colspan="3" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="lblIndustries3" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PROBABLE EMPLOYMENT POTENTIAL(In NO. of persons to be 
                                employed)</asp:Label>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;<td>
                                            <asp:Label ID="lblIndustries" runat="server" Font-Bold="True">Male</asp:Label>
                                            &nbsp;
                                        </td>
                                            <td>
                                                <asp:Label ID="lblIndustries4" runat="server" Font-Bold="True">Female</asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>DIRECT
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblMaleDirect" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblFemaleDirect" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>INDIRECT
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblMaleIndirect" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblFemaleIndirect" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>TOTAL
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblMaleTotal" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblFemaleTotal" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <div align="center">
                                <div align="center" runat="server" visible="false">
                                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td colspan="4" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Category of Registration :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Registration No
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblRegistration" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            <td>Date
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblDate" runat="server" DataFormatString="{0:dd-M-yyyy}"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                                <%--<div align="center" runat="server" id="divHotel" visible="false">
                                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td colspan="4" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">HOTEL APPROVAL
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Land is
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblTourismLandis" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                           
                                        </tr>
                                        <tr> <td>No. of Lettable rooms
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblRooms" runat="server"></asp:Label>
                                                </span>
                                            </td> 
                                        </tr>
                                        <tr>
                                            <td>No. of Outlets
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblOutlets" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            
                                        </tr>
                                        <tr> <td>No. of Banquets
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblBanquets" runat="server"></asp:Label>
                                                </span>
                                            </td> </tr>
                                        <tr>
                                            <td>Police NOC for Construction of Unit in terms of Parking and Traffic
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblPoliceNOC" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                             
                                        </tr>
                                        <tr runat="server" id="trPoliceParkingCond" visible="false">
                                            <td>Total parking area proposed in the Building Plan i.e. (25% of the built up area as per the norms is available or not? 
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblPoliceParkingCond" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                             
                                        </tr>
                                        <tr runat="server" id="trPoliceStorageConstructionCond" visible="false">
                                            <td>Whether sufficient measures have been taken for storage of construction material and 
movement of construction vehicles without hindering the flow of traffic. 
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblPoliceStorageConstructionCond" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>Do you require excavation works
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblexcavationWorks" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                             
                                        </tr>
                                    </table>
                                </div>--%>
                                <br />
                                <div align="center">
                                    <div align="center">
                                        <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">LINE OF ACTIVITY
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Line of Activity
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblLineofActiivity" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">LINE OF MANUFACTURE
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                        <columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <itemtemplate>
                                                                    <%# Container.DataItemIndex +1 %>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle width="20px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Manf_ItemName" HeaderText="Item">
                                                                <itemstyle horizontalalign="Left" width="200px" />
                                                                <headerstyle horizontalalign="Left" width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Manf_Item_Quantity" HeaderText="Quantity" />
                                                            <asp:BoundField DataField="Manf_Item_Quantity_In" HeaderText="Units" />
                                                            <asp:BoundField DataField="Manf_Item_Quantity_Per" HeaderText="Quantity Per" />
                                                        </columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">RAW MATERIALS USED IN PROCESS
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                        <columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <itemtemplate>
                                                                    <%# Container.DataItemIndex +1 %>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle width="20px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Raw_ItemName" HeaderText="Item">
                                                                <itemstyle horizontalalign="Left" width="200px" />
                                                                <headerstyle horizontalalign="Left" width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Raw_Item_Quantity" HeaderText="Quantity" />
                                                            <asp:BoundField DataField="Raw_Item_Quantity_In" HeaderText="Units" />
                                                            <asp:BoundField DataField="Raw_Item_Quantity_Per" HeaderText="Quantity Per" />
                                                        </columns>
                                                    </asp:GridView>
                                        </table>
                                    </div>
                                    <br />
                                    <div align="center">
                                        <div align="center">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="lblIndustries5" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Power</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Contracted maximum demand in KVA :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMaxDemand" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>Connected load in KW/HP:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblConnectedLoad" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Aggregate Installed Capacity OF The&nbsp; transformer to be installed by the Entreprenuer:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblTransformerCapacity" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>Required Voltage Level:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblRequiredVoltage" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        &nbsp;<div align="center">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td>Any other services existing in the same premises:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblOtherServiceExisting" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <div align="center">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td colspan="4" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Proposed maximum working hours:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Per day
                                                    </td>
                                                    <td colspan="2">
                                                        <span>
                                                            <asp:Label ID="lblHoursPerDay" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Per month
                                                    </td>
                                                    <td colspan="2">
                                                        <span>
                                                            <asp:Label ID="lblHoursPerMonth" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Expected month and year of trial production:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblTrailProduction" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>Probable date of requirement of power supply:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblPowerSupplyPerDate" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <div align="center">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="lblIndustries6" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Water</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Water supply from :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblWaterSupplyDate" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>Water requirement
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblWaterRequirement" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Drinking water ( in KL/Day ):
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblDrinkingwater" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>Water for processing(Industrial use)&nbsp;&nbsp; ( in KL/Day ):
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblProcessingWater" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Source of water:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblSourseOfWater" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>Requirement of water (in KL/Day):
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblRequirementOfWaterInKLPerDay" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Quantity of water&nbsp; water required for&nbsp; consumptive use (in KL/Day)
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblConsumptiveWater" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>Quantity of required for non-consumptive use (in KL/Day):<br />
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblNonConsumptiveWater" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>

                                                <tr id="trMissionBhagiratha" runat="server" visible="false">
                                                    <td>Water quantity required (in KLD) towards 
                                                        RWS - Feasibility(Mission Bhagiratha)</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblMissionQty" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <br />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <%--//sowjanya--%>
                                                <tr id="trIrrigation1" runat="server" visible="false">
                                                    <td>Geo Coordinates of Proposed Intake Point</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblIntakeCordinates" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>Geo Coordinates of Proposed Storage Point/ Utilisation poit
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblStorageCordinates" runat="server"></asp:Label>
                                                        </span></td>
                                                </tr>
                                                <tr id="trIrrigation2" runat="server" visible="false">
                                                    <td>Minimum Water requirements ( mcft) per annum</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblMinWaterReq" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>Maximum Water requirement ( mcft) per annum 
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblMaxWaterReq" runat="server"></asp:Label>
                                                        </span></td>
                                                </tr>
                                                <%--//sowjanya--%>
                                            </table>
                                        </div>
                                        <br />
                                        <div align="center" id="pcbnew" runat="server" visible="false">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PCB</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:HyperLink ID="hylinkpcb" runat="server" Visible="false">PCB OCMMS Common Application Form</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div align="center" id="trpcb" runat="server" visible="false">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="lblIndustries7" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PCB</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lblIndustries8" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="Black">Waste water generation in KLD</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>a Process:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblProcess" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>b Washings:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblWashings" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>c Boiler blow down:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblBoilerBlowDown" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>d Cooling tower bleed off:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblCoolingTowerBleed" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>e Domestic:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblDomestic" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>f Total:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblTotalWasteWater" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div align="center" id="trpcb1" runat="server" visible="false">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="lblIndustries9" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Air Pollution</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lblIndustries10" runat="server" Font-Bold="True" Font-Size="15px"
                                                            ForeColor="Black">I DG SET/Boiler/Thermic Fluid Heater</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;a Capacity :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCapacityOfDGSet" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>Fuel consumption per day :
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblFuelConsumptionPerDay" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>c Fuel storage details:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblFuelStorageDetails" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>d Stack height &amp;Dia(mts):
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblStackHeight" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Air Pollution Control Equipement Details::
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblAirPolutionControlEquipement" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                        <div align="center" id="trpcb2" runat="server" visible="false">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="6" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="lblIndustries11" runat="server" Font-Bold="True" Font-Size="18px"
                                                            ForeColor="White">Process</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>a Emission Characteristics and Source details:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEmissionCharacteristtics" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>b.Quantity of emissions:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblQuwntityOfEmission" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td>&nbsp;c Control equipment/system:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblControlSystem" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                        <div align="center" id="trpcb3" runat="server" visible="false">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td>Is the Project requires Generator
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblGeneratorRequred" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                            <span>
                                                <asp:Label ID="lblRegistration3" runat="server" Font-Bold="True">
                                                Solid and hazardous
                                                waste</span></asp:Label> </span>
                                            <br />
                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                <columns>
                                                    <asp:BoundField DataField="NameofWaste" HeaderText="WasteName">
                                                        <itemstyle horizontalalign="Left" width="200px" />
                                                        <headerstyle horizontalalign="Left" width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Category" HeaderText="Category" />
                                                    <asp:BoundField DataField="Qunt_Generated" HeaderText="Quantity" />
                                                    <asp:BoundField DataField="Storage_Treatment" HeaderText="Storage" />
                                                    <asp:BoundField DataField="Disposal" HeaderText="Disposal" />
                                                </columns>
                                            </asp:GridView>
                                        </div>
                                        <br />
                                        <div align="center" id="trfire" runat="server" visible="false">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="lblIndustries12" runat="server" Font-Bold="True" Font-Size="15px"
                                                            ForeColor="White">FIRE</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Height of the building (in mtrs.)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblHeightOfBulding" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>Height of each floor (in mtrs.)
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblHeightOfEachFloor" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label ID="lblIndustries13" runat="server" Font-Bold="True" Font-Size="15px"
                                                            ForeColor="Black">Means of Escape</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Intrnal Stair Case
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblInternaiStaircase" runat="server"></asp:Label>
                                                    </td>
                                                    <td>External Stair Case
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblExternalStairCase" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Width of Stair Case((min 1)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblWidthOfStairCase" runat="server"></asp:Label>
                                                    </td>
                                                    <td>No Of Exits
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoOfExits" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Width of each exit (in mts.)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblWidthOfEachExists" runat="server"></asp:Label>
                                                    </td>
                                                    <td>Width of Stair Case((min 1.5 mtrs)
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblWidthOfStairCase15" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label ID="lblIndustries14" runat="server" Font-Bold="True" Font-Size="15px"
                                                            ForeColor="Black">Open spaces all around the building: (in mts)</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>East
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSpaceInEast" runat="server"></asp:Label>
                                                    </td>
                                                    <td>West
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSpaceInWest" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>North
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSpaceInNorth" runat="server"></asp:Label>
                                                    </td>
                                                    <td>South
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSpaceInSouth" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Level of the ground
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblLevelOfGround" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Fire Detection System (Automatic)
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblFireDetectionSystem" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Fire Alarm System
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblFireAlarmSystem" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: medium">
                                                        <asp:Label ID="lblIndustries15" runat="server" Font-Bold="True" Font-Size="15px"
                                                            ForeColor="Black">Automatic Fire Fighting System:</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Sprinkler
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblSprinkler" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Foam
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblFoam" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">CO2
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblCO2" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">DCP
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblDCP" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Fire service inlet: One - 4 way
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblFireServiceInlet" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Under ground static&nbsp; water tank capacity (in hydrants lts.)
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblUnderGrounDtank"></asp:Label>
                                                    </td>
                                                    <td>Number of Court yard
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoOfCouryYard" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Fire pumps - Electrical&nbsp; 15 mtrs. To 30 mtrs. Ht.
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFirePumpElectricity" runat="server"></asp:Label>
                                                    </td>
                                                    <td>Fire pumps - Diesel
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDiesel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Fire pumps - Electrical 30 mtrs. To 45 mtrs. Ht.
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblCO7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                        <div align="center" id="trfire1" runat="server" visible="false">
                                            <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;"
                                                width="1000">
                                                <tr>
                                                    <td colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="lblIndustries16" runat="server" Font-Bold="True" Font-Size="15px"
                                                            ForeColor="White">Transformer protection measures:</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">45 Ltrs. From Trolley *
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblTrolly" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Fencing
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblFencing" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Soak pit
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblSoakPit" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Lightening protection
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lbllighteningProtectin" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Control Room
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblControlRoom" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Whether the Hydraulic Platform can be moved all around the bldg
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblHydralicPlatform" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                        <div align="center" runat="server" visible="false" id="trlabour">
                                            <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;"
                                                width="1000">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">Labour Department</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: medium">
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Black">Address of the Manager or person responsible for the Supervision and control of the Establishment:</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Category of Establishment
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Full name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMangerName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Father's Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFatherName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Designation
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">Address of the Manager
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAddressofManger" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Nature of work / is to be carried on in the establishment
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblnatureofwork" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Estimated date of commencement of building or other construction work&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEstimatedComm" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Maximum number of building workers to be employed on any day
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMaximumWorkers" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Estimated date of completion of building or other construction work&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblconstructiondate" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="font-weight: bold">Full name and address of the Principal Employer:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPriName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Father's Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPriPGName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Designation
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPriDesgn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Age
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPriAge" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Email
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPriEmail" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Mobile No
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPriMobileNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Address
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPriAddress" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="font-weight: bold">Name and address of the Director / Partners (in case of companies/firm)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Full Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDirName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Door No.
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDirDoorNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>District
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDirDistrict" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Mandal
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDirMandal" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Village/Town
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDirVillage" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="font-weight: bold">&nbsp;Particulars of Contractors and migrant workmen
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvContractor" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                        <columns>
                                                                            <asp:BoundField DataField="Contractor_Name" HeaderText="Name of the Contractor">
                                                                                <itemstyle horizontalalign="Left" width="200px" />
                                                                                <headerstyle horizontalalign="Left" width="100px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Contractor_Address" HeaderText="Address" />
                                                                            <asp:BoundField DataField="Contractor_MobileNo" HeaderText="Mobile No." />
                                                                            <asp:BoundField DataField="Contractor_Work_Nature" HeaderText="	Nature of Work" />
                                                                            <asp:BoundField DataField="Contractor_MaxWorkers" HeaderText="Maximum No. of Migrant/Contract Workmen" />
                                                                            <asp:BoundField DataField="Contractor_ManufacturingDepts" HeaderText="Details of Manufacturing Depts" />
                                                                        </columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <div align="center" id="trforest" runat="server" visible="false">
                                            <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="2" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Forest Details</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="font-weight: bold">A. Forest
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:GridView ID="gvForestCertificate" runat="server" AutoGenerateColumns="False"
                                                            BorderWidth="1px" CellPadding="4" Width="100%" DataKeyNames="intCFEForestBulkid">
                                                            <rowstyle backcolor="#ffffff" />
                                                            <columns>
                                                                <asp:BoundField DataField="Species" HeaderText="Species" />
                                                                <asp:BoundField DataField="Est_Len_Timber" HeaderText="Timber Length" />
                                                                <asp:BoundField DataField="Est_Vol_Timber" HeaderText="Timber Volume" />
                                                                <asp:BoundField DataField="Girth" HeaderText="Timber Girth" />
                                                                <asp:BoundField DataField="Est_FireWood" HeaderText="Estimated Firewood" />
                                                                <asp:BoundField DataField="Forest_Pole" HeaderText="Pole" />
                                                            </columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="font-weight: bold">B. Boundary Description
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>North
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNorth" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>East
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEast" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>West
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblWest" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>South
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSouth" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                            type="button" value="Print" />
                                        &nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx">HOME</a>
                                    </div>
                                </div>
                            </div>
    </form>
</body>
</html>
