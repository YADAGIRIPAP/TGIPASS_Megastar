<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionnaireForm.aspx.cs" Inherits="UI_TSiPASS_QuestionnaireForm" %>

<!DOCTYPE html>

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





        .GRD {
            width: 200px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            padding: 10px;
            text-transform: capitalize;
        }

        * {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
            text-align: center;
        }

        .GRDHEADER {
            border: 1px solid #ffffff;
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            BACKGROUND-IMAGE: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px;
            /*text-decoration:none;*/
            /*border-color:#013161;*/
            /*border-style:solid;*/
            text-transform: uppercase;
            /*border-width:1px;*/
            /*height:23px;*/
            /*text-indent:5px;*/
            /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        a {
            color: #337ab7;
            text-decoration: none;
        }

        a {
            background-color: transparent;
        }

        .style2 {
            color: #FF0000;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <table align="center"
            style="border: 1px solid #000000; font-family: Verdana; font-size: 12px; text-align: center; width: 800px;">
            <tr>
                <td align="center" style="padding: 0px; margin: 0px; text-align: center">
                    <img src="telanganalogo.png"
                        width="45px" height="45px" />
                </td>
            </tr>
            <tr style="padding: 0px; margin: 0px; border: 1px solid #000000; font-family: Verdana; font-size: 18px;">
                <td align="center" style="text-align: center; font-family: Verdana; font-weight: bold; font-size: 18px; border: 1px solid #000000;">TS-iPASS COMMON APPLICATION FORM</td>
            </tr>

            <tr style="padding: 0px; margin: 0px; border: 1px solid #000000;">
                <td align="center"
                    style="text-align: center; font-weight: bold; font-size: 16px; border: 1px solid #000000;">Questionnaire Form</td>
            </tr>
            <tr>
                <td align="center">




                    <table bgcolor="White" width="900" border="2px" cellpadding="22"
                        style="font-family: Verdana; font-size: 14px;">
                        <tr>

                            <td>Name of Unit</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtTreesToBeFelled0" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr style="background-color: #6699FF">

                            <th>
                                <b><span>Sector of Enterprise</span></b></th>
                            <th>
                                <asp:Label ID="LblSectionofExterprise" runat="server"></asp:Label>
                            </th>
                        </tr>
                        <tr>

                            <td>Total Extent of Land(in Sq mtrs)</td>
                            <td>
                                <span></span>
                                <asp:Label ID="txtExtant" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>

                            <td colspan="2" style="background-color: #CCFFFF"><b>Project Cost Details :</b></td>

                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GvProjectdtls" runat="server"
                                    CellPadding="4" ForeColor="#333333"
                                    Height="62px" PageSize="15" Width="100%"
                                    BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                                    Font-Bold="False" Font-Names="Verdana" Font-Size="14px" OnRowDataBound="GvProjectdtls_RowDataBound">
                                    <%-- <FooterStyle Font-Bold="True" ForeColor="Black" />--%>
                                    <RowStyle HorizontalAlign="Left"
                                        VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="70px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle Font-Bold="True"
                                        ForeColor="Black" />
                                    <EditRowStyle BackColor="#B9D684" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>

                        <%-- <tr>
                            <td>a.Value of Land (in Rs. Lakhs) *</td>
                            <td>
                                <span></span>
                                <asp:Label ID="txtValueOfLand" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>b.Value of Building(in Rs. Lakhs) * </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtValueOfBulding" runat="server"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>

                            <td>c.Value of Plant & Machinery(in Rs. Lakhs) *</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtValueOfPlant" runat="server"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>

                            <td>
                                <b>Total Project Cost (in Rs. Lakhs) :</b></td>
                            <td>
                                <b><span>
                                    <asp:Label ID="txtTotalValue" runat="server"></asp:Label>
                                </span></b></td>
                        </tr>--%>
                        <tr>

                            <td>Your enterprise is</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtEnterprisesName" runat="server" Font-Bold="True"
                                        ForeColor="Black"></asp:Label>
                                </span></td>
                        </tr>





                        <!--///-->


                        <tr>

                            <td>Line of Activity*</td>
                            <td>
                                <asp:Label ID="txtActivity" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td>Pollution Category of Enterprise</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtPolutionCategory" runat="server" Font-Bold="True"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>
                            <td>Proposed Employment</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtProposedEmployement" runat="server"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>
                            <td>Power requirement (in HP)</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtPowerRequierement" runat="server"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>
                            <td>Location of the unit</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtLocationofUnit" runat="server" Font-Bold="True"
                                        ForeColor="Black"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>
                            <td>Application Type</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtApplicationType" runat="server"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>
                            <td>Water required from</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtWaterRequiredFrom" runat="server"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>

                            <td>Water Required per day( in KLD) </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtWaterRequiredPerDay" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>

                        <tr>

                            <td>Do you store Rectified Spirit/Kerosene/Naptha</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtSpirit" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>

                        <tr>

                            <td>Constitution of the unit</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtConsitutionOfUnit" runat="server"></asp:Label>
                                </span></td>
                        </tr>



                        <tr>
                            <td>Generator Requirement </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtGeneratorRequirement" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>

                        <tr>
                            <td>Height of the Building.(In Meters)</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtHightOfBulding" runat="server"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>

                            <td>Built up Area(Including Parking Cellars)
Square Meters
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtBuiltUpArea" runat="server"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>

                            <td>Area Type </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtAreaType" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>

                        <tr>

                            <td>Is there any need to Fell trees in Proposed Site
(Non-Exempted trees List)</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtFellTrees" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>

                        <tr>

                            <td>Number of trees to be felled</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtTreesToBeFelled" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>





                    </table>

                </td>
            </tr>

            <tr>
                <td align="center" style="text-align: center">
                    <asp:GridView ID="grdDetails" runat="server"
                        AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333"
                        Height="62px" PageSize="15" Width="100%"
                        OnRowDataBound="grdDetails_RowDataBound"
                        ShowFooter="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="False" Font-Names="Verdana" Font-Size="14px"
                        OnSelectedIndexChanged="grdDetails_SelectedIndexChanged">
                        <FooterStyle Font-Bold="True" ForeColor="Black" />
                        <RowStyle HorizontalAlign="Left"
                            VerticalAlign="Middle" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required ">
                                <ItemStyle Width="450px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dept_Full_name" HeaderText="Department">
                                <ItemStyle Width="180px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fees" HeaderText="Fees (Rs.)" DataFormatString="{0:0}">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle Font-Bold="True"
                            ForeColor="Black" />
                        <EditRowStyle BackColor="#B9D684" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>

            <tr>
                <td align="center" class="style2" style="text-align: center">Note: For 
        any other clearances from Government of India, applicant shall apply directly to 
        the concerned department.</td>
            </tr>

            <tr>
                <td align="center" class="style2" style="text-align: center">
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                </td>
            </tr>

        </table>

    </form>
</body>
</html>
