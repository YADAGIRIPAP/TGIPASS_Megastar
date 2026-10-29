<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CFOPrint.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: TS-iPASS ::</title>
    <style>
        .div3
        {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code
        {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code
        {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u
        {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px10px10px10px;
        }

        ol.v
        {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table
        {
            border-collapse: collapse;
            width: 100%;
        }

        th, td
        {
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
                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                </center>
                <h3>
                    TS-iPASS COMMON APPLICATION FORM (CFO)</h3>
            </div>
            <br />
            <div align="center">
                <div align="center">
                    <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                        <tr>
                            <td>
                                UID No:
                            </td>
                            <td>
                                <asp:Label ID="lblUidNo" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NAME OF INDUSTRIAL UNDERTAKING
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblNameOfUndertaker" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NAME OF PROMOTER
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblNameOfPromoter" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                S/o. D/o. W/o
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblSonOf" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Age
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblEntAge" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Occupation
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblEntOccupation" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                    <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">ADDRESS FOR COMMUNICATION</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Door No.
                                </td>
                                <td>
                                    <asp:Label ID="lblDoorNo" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                                <td>
                                    Street Name
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblStreetName" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Village/Town
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblvillage" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    State
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblState" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    District
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    &nbsp;Mandal
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cell No
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    PinCode
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPincode" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email-ID
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    Telephone
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Nature of Organisation
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblOrganisation" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    Fax
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFax" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Landmark
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLandMark" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    Differently abled
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDifferentlyABles" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Women entrepreneur
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblWomenEnterpren" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    Minority
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMinority" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div align="center">
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                <tr>
                                    <td colspan="4" style="font-size: large; text-align: center; background-color: #0066FF;
                                        color: #FFFFFF; font-weight: bold;">
                                        Registration Particulars
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Category Of Registration
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblRegistrationCategory" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>
                                        Type of Project
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblTypeOfProject" runat="server" DataFormatString="{0:dd-M-yyyy}"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Registration No
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblRegistration" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>
                                        Registration Expiry Date
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblExpiryDate" runat="server" DataFormatString="{0:dd-M-yyyy}"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Registration Date
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblRegistrationDate" runat="server" DataFormatString="{0:dd-M-yyyy}"></asp:Label>
                                        </span>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <br />
                        <div align="center">
                            <div align="center" id="trproposalexisting" runat="server" visible="false">
                                <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="lblIndustries2" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PROPOSAL</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Proposal For
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
                                        <td>
                                        </td>
                                        <td style="font-weight: bold">
                                            A) Existing Investment
                                        </td>
                                        <td style="font-weight: bold">
                                            B) Expansion Investment
                                        </td>
                                        <td style="font-weight: bold">
                                            Total Investment
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Land Value(in Lakhs)
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
                                        <td style="font-weight: bold">
                                            Building Value(in Lakhs)
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
                                        <td style="font-weight: bold">
                                            Plant and Machinery Value (in Lakhs)
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
                                        <td style="font-weight: bold">
                                            Total Value (in Lakhs)
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
                                </table>
                            </div>
                            <div align="center" id="trproposalNew" runat="server" visible="false">
                                <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PROPOSAL</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Proposal For
                                        </td>
                                        <td>
                                            <asp:Label ID="lblproposalnew" runat="server"></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <%--  <tr>

                                        <td>Building (in Lakhs.) </td>
                                        <td>&nbsp;</td>
                                        <td>Plant and Machinery(in Lakhs.)</td>
                                        <td>&nbsp;</td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="font-weight: bold">
                                            Propsed Investment
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Land Value(in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblland" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Building Value(in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblbuilding" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Plant and Machinery Value (in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblplant" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Total Value (in Lakhs)
                                        </td>
                                        <td>
                                            <asp:Label ID="lbltotalvalue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="center">
                                <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td colspan="3" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="lblIndustries3" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">EMPLOYMENT DETAILS</asp:Label>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;<td>
                                                <asp:Label ID="lblIndustries" runat="server" Font-Bold="True">Male</asp:Label>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="lblIndustries4" runat="server" Font-Bold="True">Female</asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Adults (above 18 Yrs)
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblMaleAbout18" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblFemaleAbove18" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Adolescents (15-18 Yrs)&nbsp;
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblMale15to18" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblFemale15to18" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Children (14-15 Yrs)
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblMale14to15" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblFemale14to15" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <div align="center">
                                <br />
                                <br />
                                <span>
                                    <asp:Label ID="lblRegistration0" runat="server" Font-Bold="True" ForeColor="Black">LINE 
                    OF MANUFACTURE</asp:Label>
                                </span>
                                <br />
                                <div align="center">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Manf_ItemName" HeaderText="Item">
                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Manf_Item_Quantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="Manf_Item_Quantity_In" HeaderText="Units" />
                                            <asp:BoundField DataField="Manf_Item_Quantity_Per" HeaderText="Quantity Per" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />
                                <br />
                                <span>
                                    <asp:Label ID="lblRegistration1" runat="server" Font-Bold="True"><span>RAW 
                    MATERIALS USED IN PROCESS</span></asp:Label>
                                </span>
                                <br />
                                <div align="center">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Raw_ItemName" HeaderText="Item">
                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Raw_Item_Quantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="Raw_Item_Quantity_In" HeaderText="Units" />
                                            <asp:BoundField DataField="Raw_Item_Quantity_Per" HeaderText="Quantity Per" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />
                                <br />
                                <div align="center">
                                    <br />
                                    <div align="center">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF;
                                                    color: #FFFFFF; font-weight: bold;">
                                                    Contracted Maximum Demand in KVA
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Already installed
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblAlreadyInstalled" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Proposed
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblProposed" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Total
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div align="center">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="4" style="text-align: center; background-color: #0066FF;">
                                                    <asp:Label ID="lblIndustries17" runat="server" Font-Bold="True" Font-Size="18px"
                                                        ForeColor="White">Connected Load in KW/HP</asp:Label>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Type of Connected Load
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblTypeOfConnectedLoad" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Already installed
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblAlreadyInstalledFW" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Proposed&nbsp;
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblProposedKW" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Total
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblTotalKW" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div align="center">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF;
                                                    color: #FFFFFF; font-weight: bold;">
                                                    Other Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Height of the building(in Meters)
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblBuildingheight" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Built up Area (Including Parking Cellars)
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblBuiltupArea" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div align="center">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF;
                                                    color: #FFFFFF; font-weight: bold;">
                                                    LOCATION
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Proposed Location of Factory
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
                                    <br />
                                    <div align="center">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td>
                                                    Survey No/Plot No
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    District
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblDistrict0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Village/Town
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblvillage0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Mandal
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblMandal0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Extent
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblExtentofSightArea" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    PinCode
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPincode0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date of Commencement of Production
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblDateOfProduction" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Telephone
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblTelephone0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Telephone(incl STD Code)
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblTPhone" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Street Name
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblProposedArea" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <div align="center" id="pcbnew" runat="server" visible="false">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;
                                                    color: #FFFFFF; font-size: large; font-weight: bold;">
                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PCB</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:HyperLink ID="hylinkpcb" runat="server" Visible="false">PCB OCMMS Common Application Form</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    Pollution Category of Industry
                                                </td>
                                                <td align="left" colspan="2" runat="server" id="tdpcbcategory">
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <div align="center" id="trfactory" runat="server" visible="false">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;
                                                    color: #FFFFFF; font-size: large; font-weight: bold;">
                                                    <asp:Label ID="lblIndustries5" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Factory Details</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nature of manufacturing process or processes
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNatureOfProcess" runat="server"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Full Name &amp; residential address of the Occupier
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblNameAddressOfOccupier" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Factory plan approval number
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblReferanceNo" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Date of occupation of the factory by the occupier
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblDateOfOccupation" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Approval date
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblReferanceDate" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    &nbsp;Full Name and residential address of Manager for the purpose of Act
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblNameAddress" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Full Name and Residential address of the Owner
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblNameAddressOfOwner" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Regular Hp
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblregularhp" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Standy Hp
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblstandyhp" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    License Year
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lbllicenseYear" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    &nbsp;<br />
                                    <div align="center" id="trPetroleumpremises" runat="server" visible="false">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="5" style="font-size: large; text-align: center; background-color: #0066FF;
                                                    color: #FFFFFF; font-weight: bold;">
                                                    Situation of the premises where Petroleum is to be storedhours:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    District
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblStoredDistrict" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td colspan="2">
                                                    Police Station
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblNearPoliceStation" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Village/Town
                                                </td>
                                                <td colspan="2">
                                                    <span>
                                                        <asp:Label ID="lblStoredVillage" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Nearest Railway Station
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblRailwayStation" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div align="center" id="trPetroleumproposed" runat="server" visible="false">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="4" style="text-align: center; background-color: #0066FF;">
                                                    <asp:Label ID="lblIndustries20" runat="server" Font-Bold="True" Font-Size="18px"
                                                        ForeColor="White">Quantity (In Ltrs.) of Petroleum proposed to be imported and stored.</asp:Label>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;<td align="center" style="text-align: center">
                                                        <asp:Label ID="lblIndustries21" runat="server" Font-Bold="True">In bulk (above 1000 Lts)</asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblIndustries22" runat="server" Font-Bold="True"> Not in bulk (less than 1000 Lts)</asp:Label>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblIndustries23" runat="server" Font-Bold="True">Total</asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Petroleum Class A/Naptha
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassAAbove1000" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassALessThan1000" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassA" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Petroleum Class B/Naptha&nbsp;
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassBAbove1000" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassBLessThan1000" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassB" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Petroleum Class C/Naptha
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassCAbove1000" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassCLessThan1000" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassC" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Total
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumTotalAbove1000" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumTotalLessThan1000" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassTotal" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div align="center" id="trPetroleumstored" runat="server" visible="false">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="4" style="text-align: center; background-color: #0066FF;">
                                                    <asp:Label ID="lblIndustries24" runat="server" Font-Bold="True" Font-Size="18px"
                                                        ForeColor="White">Quantity (in Ltrs) of Petroleum already stored in the premises.</asp:Label>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;<td align="center" style="text-align: center">
                                                        <asp:Label ID="lblIndustries25" runat="server" Font-Bold="True">In bulk (above 1000 Lts)</asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblIndustries26" runat="server" Font-Bold="True"> Not in bulk (less than 1000 Lts)</asp:Label>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblIndustries27" runat="server" Font-Bold="True">Total</asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Petroleum Class A/Naptha
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassAAbove1001" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassALessThan1001" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassA0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Petroleum Class B/Naptha&nbsp;
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassBAbove1001" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassBLessThan1001" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassB0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Petroleum Class C/Naptha
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassCAbove1001" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassCLessThan1001" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassC0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Total
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumTotalAbove1001" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumTotalLessThan1001" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPetroleumClassTotal0" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div align="center" id="trfactoryhorse" runat="server" visible="false">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td>
                                                    Sales Tax Registration Details
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblSalesTax" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Explosive Licence Details
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblExplosiveLicnce" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    Maximum Amount of Horse Power to be Installed
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Regualr
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblHPRegular" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    Stand By
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblHPStandBy" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <div align="center" id="trBoiler" runat="server" visible="false">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;
                                                    color: #FFFFFF; font-size: large; font-weight: bold;">
                                                    <asp:Label ID="lblIndustries6" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Boiler Details</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Registration Number of the Boiler
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBoilerRegDate" runat="server"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Description of Boiler and Age
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblBoilerAge" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Name of the Owner/Agent
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblNameOfAget" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Maker&#39;s Name
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblBoilerMaker" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Where situated
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblBoilerLocation" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Maker&#39;s Number
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblBoilerMakerNo" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date of Inspection desirable
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblDateOfInspection" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Type Of Boiler<br />
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblTypeOfBoiler" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Place of Manufature
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPlaceOfManuf" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Year of Manufature
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblYeayOfManufature" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Boiler Used for
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblBoilerUsedFor" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Allowed Maximum Pressure
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblMaxPressur" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Boiler Rating/Heating Surface
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblBoilerRating" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Economiser Maker&#39;s Number
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblEconomiserMake" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <b>Details of Boiler Erector</b>
                                                </td>
                                                <td>
                                                    Maximum Continous Evaporation
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblMaxEvaporation" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Class of Erector
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblErectorClass" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    &nbsp;Maximum Pressure of Economiser
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblPressurOfEconomiser" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Name of Erector
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblErectorName" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    Total Length of Steam PipeLine
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lbllengthOfSteamPipeline" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    State
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblErectorState" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <div align="center" id="trLabour" runat="server" visible="false">
                                        <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;"
                                            width="800">
                                            <tr>
                                                <td colspan="2" style="text-align: center; background-color: #0066FF; color: #FFFFFF;
                                                    font-size: large; font-weight: bold;">
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">Labour Department</asp:Label>
                                                </td>
                                            </tr>
                                            <%--     <tr>

                                                    <td>Postal address of the Establishment </td>
                                                    <td>
                                                        <asp:Label ID="lblpostalAddress" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td>Full name and Permanent Address of the establishment, if any&nbsp;&nbsp; </td>
                                                    <td>
                                                        <asp:Label ID="lblpermentAdd" runat="server"></asp:Label>
                                                    </td>
                                                </tr>--%>
                                            <tr>
                                                <td>
                                                    Classification of Establishment
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblClassification" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Category of Establishment
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-size: medium">
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Black">Address of the Manager or person responsible for the Supervision and control of the Establishment:</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Full name
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMangerName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Father's Name
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFatherName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Designation
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Age
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMgrAge" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Mobile
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMgrMobile" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Email
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMgrEmail" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    Address of the Manager
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAddressofManger" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nature of work / is to be carried on in the establishment
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblnatureofwork" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Estimated date of commencement of building or other construction work&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEstimatedComm" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Maximum number of building workers to be employed on any day
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMaximumWorkers" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Estimated date of completion of building or other construction work&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblconstructiondate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <%--    <tr>
                                                    <td colspan="2" style="font-weight: bold">Address of the Shop/Establishment</td>

                                                </tr>
                                                <tr>
                                                    <td>Door No.</td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Locality</td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>District</td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Mandal</td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Village</td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Pincode</td>
                                                    <td></td>
                                                </tr>--%>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Location of Office, Godown, Warehouse or workplace attached to the shop/establishment
                                                    but situated outside the premisis of it
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvGodown" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                        <Columns>
                                                            <asp:BoundField DataField="Work_Place" HeaderText="Work Place">
                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Door_No" HeaderText="Door No." />
                                                            <asp:BoundField DataField="Locality" HeaderText="Locality" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Residential address of the employer
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Door No.
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEmpDoorNo" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Locality
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEmpLocality" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    District
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEmpDistrict" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Mandal
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEmpMandal" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Village
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEmpVillage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Name and address of the Director / Partners (in case of companies/firm)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Full Name
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDirName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Door No.
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDirDoorNo" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    District
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDirDistrict" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Mandal
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDirMandal" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Village/Town
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDirVillage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Name of family members of employees family engaged in Shop / Establishment
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvFamily" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name of the Family member" DataField="Name">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="RelationShip" HeaderText="Relationship" />
                                                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                                                        <asp:BoundField DataField="Adult_Flag" HeaderText="Adult/Young Person" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Table ID="tblNoofEmployees" runat="server" CellPadding="1" CellSpacing="1" Font-Size="Medium"
                                                        GridLines="Both" Width="400">
                                                        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Style="font-weight: bold;">
                                                            <asp:TableHeaderCell Width="50px"></asp:TableHeaderCell>
                                                            <asp:TableHeaderCell Width="150px">Adults (18 years and above)</asp:TableHeaderCell>
                                                            <asp:TableHeaderCell Width="170px">Young Persons (From 14 years to Below 18 years)</asp:TableHeaderCell>
                                                        </asp:TableHeaderRow>
                                                        <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                            <asp:TableCell>MALE</asp:TableCell>
                                                            <asp:TableCell Height="29px">
                                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Male" Width="40px"></asp:TextBox>
                                                            </asp:TableCell>
                                                            <asp:TableCell Height="29px">
                                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18Male" Width="40px"></asp:TextBox>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                            <asp:TableCell Height="29px">FEMALE</asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Female" Width="40px"></asp:TextBox>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18FeMale" Width="40px"></asp:TextBox>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <%-- <asp:TableFooterRow ID="TableFooterRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                                <asp:TableCell Height="29px">Total</asp:TableCell>
                                                                <asp:TableCell>
                                                                    <asp:TextBox runat="server" ID="txtTotalAbove18" Width="40px" Enabled="false"></asp:TextBox>
                                                                </asp:TableCell>
                                                                <asp:TableCell>
                                                                    <asp:TextBox runat="server" ID="txtTotalBelow18" Width="40px" Enabled="false"></asp:TextBox>
                                                                </asp:TableCell>
                                                            </asp:TableFooterRow>--%>
                                                    </asp:Table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Name of Employees
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvEmpDtls" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Occupation" DataField="Occupation">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Particulars of Contractors and migrant workmen
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvContractor" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Contractor_Name" HeaderText="Name of the Contractor">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Contractor_Address" HeaderText="Address" />
                                                                        <asp:BoundField DataField="Contractor_MobileNo" HeaderText="Mobile No." />
                                                                        <asp:BoundField DataField="Contractor_Work_Nature" HeaderText="	Nature of Work" />
                                                                        <asp:BoundField DataField="Contractor_MaxWorkers" HeaderText="Maximum No. of Migrant/Contract Workmen" />
                                                                        <asp:BoundField DataField="Contractor_ManufacturingDepts" HeaderText="Details of Manufacturing Depts" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <div align="center" id="trLegal" runat="server" visible="false">
                                        <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;"
                                            width="800">
                                            <tr>
                                                <td colspan="2" style="text-align: center; background-color: #0066FF; color: #FFFFFF;
                                                    font-size: large; font-weight: bold;">
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">MANUFACTURER/PACKER/IMPORTER REGISTRATION FORM </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Application for Registration as a :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblLegalRegas" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date of Commencement of Pre-packing/Importing
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDateofPacking" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvLegalProp" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Director_Name" HeaderText="Partner/Director Name">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Director_DoorNo" HeaderText="House No/Door No." />
                                                                        <asp:BoundField DataField="Director_Districtcd" HeaderText="District" />
                                                                        <asp:BoundField DataField="Director_MandalCd" HeaderText="Mandal" />
                                                                        <asp:BoundField DataField="Director_VillageCd" HeaderText="Village" />
                                                                        <asp:BoundField DataField="Director_Pincode" HeaderText="Pincode" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Trade License of municipality or Gram Panchayat
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTradeLic" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Label Details
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblLabel" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    TIN Number (Issued by Sales Tax Department)
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTinNo" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Brand Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvBrand" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Brand Name" DataField="BrandName">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Commodity Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvCommodity" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Commodity Name" DataField="Commodity_Name">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="Net Quantity" DataField="Quantity">
                                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <div align="center" id="trDrug" runat="server" visible="false">
                                        <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;"
                                            width="800">
                                            <tr>
                                                <td colspan="2" style="text-align: center; background-color: #0066FF; color: #FFFFFF;
                                                    font-size: large; font-weight: bold;">
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">Drug control Authority Details </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    Constitution Details of the firm
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvDrugDir" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Name" HeaderText="Name of the proprietor/partners / directors">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Designation" HeaderText="Designation" />
                                                                        <asp:BoundField DataField="Address" HeaderText="Permanent Address" />
                                                                        <asp:BoundField DataField="IdProofNo" HeaderText="ID Proof Ref. No. (Aadhaar Card/ Passport No.)" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    DETAILS OF THE TECHNICAL STAFF
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvTechStaff" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name of the Staff member" DataField="Name">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                                                                        <asp:BoundField DataField="Designation" HeaderText="Designation" />
                                                                        <asp:BoundField DataField="Experience" HeaderText="Experience in relevant section (in years)" />
                                                                        <asp:BoundField DataField="Section" HeaderText="Section for which approval is sought" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">
                                                    LIST OF APPLIED DRUG PRODUCTS
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvDrugProducts" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name of the product (along with the strength and pharmacopoeial specifications)"
                                                                            DataField="Name">
                                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="Composition of the product" DataField="Composition">
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ExportDomestic" HeaderText="Export/ domestic" />
                                                                        <asp:BoundField DataField="BrandName" HeaderText="Brand name (if applicable in case of export only drugs)" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid;
                                        border-left: thin solid; border-bottom: thin solid" type="button" value="Print" /><br />
                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/UI/TSiPASS/HomeDashboard.aspx"
                                        ForeColor="#3366CC">Home</asp:HyperLink>
                                    <br />
                                </div>
                            </div>
                        </div>
    </form>
</body>
</html>
