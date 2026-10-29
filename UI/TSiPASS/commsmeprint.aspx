<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commsmeprint.aspx.cs" Inherits="UI_TSiPASS_commsmeprint" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>TS-iPASS MSME  Details</h3>
                </div>
                <br />
                <div align="center">
                   
                    <br />
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">UNIT DETAILS
                                </td>
                            </tr>
                            <%--<tr>
                                <td>Location of Factory
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblProposedLocation" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                    <%--<br />--%>
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            
                            <tr>
                                <td>Unit Name</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>UAM / IEM / IL ID
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUAM" runat="server"></asp:Label>
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
                                <td>Mandal
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMandal0" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Complete Unit Address
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUnitAddress" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Investment (in Crore)
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblinvestment" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Employment
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblEmployment" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Whether the unit is in IE/Not
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUnitIE" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <%--<td>Date of Capture
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDateofCapture" runat="server"></asp:Label>
                                    </span>
                                </td>--%>
                                <td>Present Status
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPresentstatus" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Type Of Industry
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofIndustry" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Date Of Commencement of Production
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDateofCommencement" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Category by PCB
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCategoryPCB" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Type Of Connection
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofConnection" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Does Unit Export
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUnitExport" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <%--<td>Building Approval
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblBuildingApproval" runat="server"></asp:Label>
                                    </span>
                                </td>--%>
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
                                        <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">ENTREPRENEUR DETAILS</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Name of Entrepreneur
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEntrepreneur" runat="server"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>Mobile No
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Email
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Social Status
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblSocialStatus" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Is Promoter Differently Abled
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblPromoterDiffAbled" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Is Promoter Women
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblPromoterWomen" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                               
                            </table>
                        </div>
                        <br />
                        
                       
                        <div align="center">
                            
                            <br />
                            <div align="center">
                                <div align="center">
                                    <div align="center">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">PRODUCT DETAILS
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Sector
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblSector" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Line of Activity
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblLineofActivity" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td>Product Specification(if any)
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblProductSpecification" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold">ITEMS MANUFACTURED</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana" OnRowDataBound="GridView1_RowDataBound"
                                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex +1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="20px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="MANF_ITEM_NAME" HeaderText="Item">
                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MANF_QUANTITY_PER_ANNUM" HeaderText="Quantity Per Annum" />
                                                            <asp:BoundField DataField="MANF_PRODUCTIONS_IN" HeaderText="Production In Units" />
                                                            <%--<asp:BoundField DataField="Manf_Item_Quantity_Per" HeaderText="Photo" />
                                                            <asp:BoundField DataField="Manf_Item_Quantity_Per" HeaderText="Other Product Related Details" />--%>
                                                            <asp:TemplateField HeaderText="Uploaded Doc" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" NavigateUrl='<%# Eval("MANF_UNIT_PHOTO") %>'
                                                                    Text='View' Visible="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            
                                            
                                        </table>
                                    </div>
                                    <br />
                                    <br/>
                                    <div align="center">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Raw Materials used For Manufacturing other than Coal,Ethanol etc
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Raw Materials is Procurred From
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblrawprocured" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Location Details
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-weight: bold"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
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
                                                            <asp:BoundField DataField="RAW_ITEM_NAME" HeaderText="Item">
                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RAW_QUANTITY_PER_ANNUM" HeaderText="Quantity Per Annum" />
                                                            <asp:BoundField DataField="RAW_PRODUCCTION_IN" HeaderText="Production In Units" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            
                                            
                                        </table>
                                    </div>
                                    <br/>
                                    <div align="center">
                                        <br />
                                        <br />
                                        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                            type="button" value="Print" />
                                        <%--&nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx">HOME</a>--%>
                                    </div>
                                </div>
                            </div>
    </form>
</body>
</html>
