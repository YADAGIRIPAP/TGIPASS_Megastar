<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClusterPrint.aspx.cs" Inherits="UI_TSiPASS_ClusterPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
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
            padding: 10px 10px 10px 10px;
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

                    <h3>TS-iPASS CLUSTER INFORMATION</h3>

                </div>



                <br />
                <div align="center">
                    <br />
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px"
                            style="font-family: Verdana; font-size: small;">
                            <tr>

                                <td colspan="2"
                                    style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">LOCATION DETAILS</td>
                            </tr>
                            <tr>

                                <td>Mandal Name</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMandalName" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                            <tr>

                                <td>Village Name</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblVillageName" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                            <tr>
                                <td>Line of Activity</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLineofActivity" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                        </table>
                    </div>
                    <br />
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px"
                            style="font-family: Verdana; font-size: small;">
                            <tr>

                                <td colspan="2"
                                    style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">INFRASTRUCTURE AVAILABILITY</td>
                            </tr>
                            <tr>

                                <td>Substation Name</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblSubStationName" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                            <tr>

                                <td>Capacity of Substation</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCapacity" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>

                                <td>Details of Training facilities</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTrainingFacility" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>

                                <td>Raw Material Source</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblRawMater" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>

                                <td>Major Markets</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMajorMarkets" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>



                        </table>
                    </div>
                    <br />

                    <div align="center">


                        <div align="center">

                            <div align="center">

                                <div align="center">


                                    <span>
                                        <asp:Label ID="lblRegistration0" runat="server" Font-Bold="True" ForeColor="Black">UNIT DETAILS</asp:Label>
                                    </span>
                                    <br />
                                    <div align="center">
                                        <asp:GridView ID="gvUnitDetails" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Unit_Type" HeaderText="Unit Type">
                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="No_Units" HeaderText="No of Units" />
                                                <asp:BoundField DataField="Investment" HeaderText="Investment (Rs. in Lakhs)" />
                                                <asp:BoundField DataField="Employment" HeaderText="Employment" />
                                                <asp:BoundField DataField="TurnOver" HeaderText="Turnover (Rs. in Lakhs)" />

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <br />
                                    <br />
                                    <span>
                                        <asp:Label ID="lblRegistration1" runat="server" Font-Bold="True"><span>DETAILS OF COMMON FACILITY CENTERS</span></asp:Label>
                                    </span>
                                    <br />
                                    <div align="center">
                                        <asp:GridView ID="gvCommonFacility" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TypeDesc" HeaderText="Common Facility Center Type">
                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Details" HeaderText="Details" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <br />
                                    <br />

                                    <span>
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True"><span>EXPORT DETAILS</span></asp:Label>
                                    </span>
                                    <br />
                                    <div align="center">
                                        <asp:GridView ID="gvExports" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Nameof_Unit" HeaderText="Name of the Unit">
                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Product_Exported" HeaderText="Product Exported" />
                                                <asp:BoundField DataField="Country_Exported" HeaderText="Country's Product Exported" />

                                                <asp:BoundField DataField="QUANTUMQTY" HeaderText="Quantum of Exports" />
                                                <asp:BoundField DataField="ValueofExports" HeaderText="Value of Exports" />

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <br />
                                    <br />

                                    <span>
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True"><span>LIST OF INDUSTRIES</span></asp:Label>
                                    </span>
                                    <br />
                                    <div align="center">
                                        <asp:GridView ID="gvIndustriesList" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="NameofIndustry" HeaderText="Name of the Industry">
                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LineofActivity" HeaderText="Line of Activity" />
                                                <asp:BoundField DataField="Investment" HeaderText="Investment (Rs. in Lakhs)" />

                                                <asp:BoundField DataField="Employment" HeaderText="Employment" />

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div align="center">
                                        <br />

                                        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                            type="button" value="Print" />
                                        &nbsp;&nbsp;&nbsp;

                                       

                                    </div>
                                </div>
                            </div>
    </form>
</body>
</html>

