<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IPOReportPrintPage.aspx.cs" Inherits="Default2"
    Title="CFE-Print" %>

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
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="100px" height="100px" />
                    </center>
                    <%--<h3>TS-iPASS INCENTIVE APPLICATION FORM</h3>--%>
                </div>
                <br />
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td>Name of the Officer
                                </td>
                                <td>
                                    <asp:Label ID="lblNameofOfficer" runat="server"></asp:Label>
                                    &nbsp;(<asp:Label ID="lbldesignation" runat="server"></asp:Label>)
                                </td>
                            </tr>
                            <tr>
                                <td>District
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDistrictOffcr" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Year
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Month
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblMonth" runat="server"></asp:Label>
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
                                    <table bgcolor="White" width="900" border="0px" style="font-family: Verdana; font-size: small;">
                                        <tr runat="server" visible="false" id="GridView1d">
                                            <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Report 1:Stressed asset bank wise report

                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="1000px" OnRowDataBound="GridView1_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                        <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                        <asp:BoundField DataField="BANKNAME" HeaderText="Bank Name" />
                                                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />            
                                                         <asp:BoundField DataField="TypeName" HeaderText="Type" />  
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />  
                                                        <asp:TemplateField HeaderText="Uploaded Doc" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" NavigateUrl='<%# Eval("FilePath") %>'
                                                                    Text='View' Visible="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                     <asp:BoundField DataField="TIHCL" HeaderText="Whether send to TIHCL" />  
                                                        <asp:BoundField DataField="reason" HeaderText="Reason" /> 
                                                                         
                                                         
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>


                                    </table>
                                </div>
                                <br />

                            </div>

                             <div align="center">
                                <div align="center">
                                    <table bgcolor="White" width="900" border="0px" style="font-family: Verdana; font-size: small;">
                                        <tr  runat="server" visible="false" id="GridBankvisitReptd">
                                            <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Report 2:BANK VISIT REPORT(Loan Sanctioned Report)


                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridBankvisitRept" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="1000px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        
                                                         <asp:BoundField DataField="nameofunit" HeaderText="Name of Unit" />
                                                         <asp:BoundField DataField="unitaddress" HeaderText="Address" />
                                                        <asp:BoundField DataField="intBankid" HeaderText="Bank Name" />
                                                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                                                        <asp:BoundField DataField="intNatureofLoan" HeaderText="NatureofLoan" />
                                                        <asp:BoundField DataField="PromoterName" HeaderText="Promoter Name" />
                                                        <asp:BoundField DataField="intLineofActivityid" HeaderText="Line of Activity" />
                                                        <asp:BoundField DataField="LoanAmount" HeaderText="Loan Amount" />
                                                        <asp:BoundField DataField="DateofSanction" HeaderText="Date of Sanction" />
                                                          <asp:BoundField DataField="Totalinvestment" HeaderText="Total Investment" />

                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>


                                    </table>
                                </div>
                                <br />

                            </div>

                              <div align="center">
                                <div align="center">
                                    <table bgcolor="White" width="900" border="0px" style="font-family: Verdana; font-size: small;">
                                        <tr runat="server" visible="false" id="GridVehicleInspctnd">
                                            <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Report 3: VEHICLE INSPECTION	

                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridVehicleInspctn" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="1000px" OnRowDataBound="GridVehicleInspctn_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        
                                                        <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                        <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                        <asp:BoundField DataField="DetailsofVehicle" HeaderText="Details of Vehicle" />
                                                         <asp:BoundField DataField="DateofInspection" HeaderText="Date of Inspection" />
                                                        <asp:BoundField DataField="TypeofIncentive" HeaderText="Type of  Incentive" />
                                                        <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" />
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                         <asp:TemplateField HeaderText="Uploaded Doc" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" NavigateUrl='<%# Eval("FilePath") %>'
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

                            </div>

                              <div align="center">
                                <div align="center">
                                    <table bgcolor="White" width="900" border="0px" style="font-family: Verdana; font-size: small;">
                                        <tr runat="server" visible="false" id="GridClosedUnitsd">
                                            <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">REPORT 4: CLOSED UNITS


                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridClosedUnits" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="1000px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                       <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                        <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                         <asp:BoundField DataField="HTLT" HeaderText="HT or LT" />
                                                        <asp:BoundField DataField="DateofCloser" HeaderText="Date of Closure of the Unit" />
                                                         <asp:BoundField DataField="dateofclosedunitsfirst" HeaderText="Date of Closure Reported for the first time" />
                                                        <asp:BoundField DataField="intLineofActivityid" HeaderText="Line of Acitivity"/>
                                                        <asp:BoundField DataField="BriefReason" HeaderText="Brief Reason for Closer" />
                                                        <asp:BoundField DataField="OtherRemarks" HeaderText="Remarks" />
                                                       <asp:BoundField DataField="TIHCL" HeaderText="Whether send to TIHCL" />  
                                                        <asp:BoundField DataField="reason" HeaderText="Reason" />
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>


                                    </table>
                                </div>
                                <br />

                            </div>

                              <div align="center">
                                <div align="center">
                                    <table bgcolor="White" width="900" border="0px" style="font-family: Verdana; font-size: small;">
                                        <tr runat="server" visible="false" id="GridAdvanceSubsidyd">
                                            <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">REPORT 5:ADVANCE SUBSIDY	

                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridAdvanceSubsidy" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="1000px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NameofUnit" HeaderText="Beneficiary Name" />
                                                        <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                        <asp:BoundField DataField="DateofReleaseFirstInstalment" HeaderText="Date of Release First Instalment" />
                                                        <asp:BoundField DataField="FirstInstalment" HeaderText="First Instalment(Rs)" />
                                                        <asp:BoundField DataField="DateofReleaseSecondInstalment" HeaderText="Date of Release Second Instalment" />
                                                        <asp:BoundField DataField="SecondInstalment" HeaderText="Second Instalment(Rs)" />
                                                        <asp:BoundField DataField="CurrentStatus" HeaderText="CurrentStatus" />
                                                        <asp:BoundField DataField="intLineofActivityid" HeaderText="Line of Acitivity"/>
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                       
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>


                                    </table>
                                </div>
                                <br />

                            </div>

                              <div align="center">
                                <div align="center">
                                    <table bgcolor="White" width="900" border="0px" style="font-family: Verdana; font-size: small;">
                                        <tr runat="server" visible="false" id="GridIndCatelogd">
                                            <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">REPORT 6:INDUSTRIAL CATELOGUE


                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridIndCatelog" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="1000px" OnRowDataBound="GridIndCatelog_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                       
                                                        <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                        <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                        <asp:BoundField DataField="intLineofActivityid" HeaderText="Line of Activity" />
                                                         <asp:BoundField DataField="DateofVisited" HeaderText="Date of Visited" />
                                                        <asp:BoundField DataField="CurrentStatus" HeaderText="CurrentStatus" />
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" /> 
                                                         <asp:TemplateField HeaderText="Uploaded Doc" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" NavigateUrl='<%# Eval("FilePath") %>'
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

                            </div>

                              <div align="center">
                                <div align="center">
                                    <table bgcolor="White" width="900" border="0px" style="font-family: Verdana; font-size: small;">
                                        <tr runat="server" visible="false" id="GridTsipassd">
                                            <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Report:7 TS-IPASS	

                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridTsipass" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="1000px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                         <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                         <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                        <asp:BoundField DataField="DateofApproval" HeaderText="DateofApproval" />
                                                        <asp:BoundField DataField="CurrentStatus" HeaderText="CurrentStatus" />
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                         
                                                         
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>


                                    </table>
                                </div>
                                <br />

                            </div>

                              <div align="center">
                                <div align="center">
                                    <table bgcolor="White" width="900" border="0px" style="font-family: Verdana; font-size: small;">
                                        <tr runat="server" visible="false" id="GridMudraRegd">
                                            <td colspan="2" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Report 8: PMEGP & MUDRA REGISTRATION


                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridMudraReg" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="1000px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                         <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                        <asp:BoundField DataField="intBankid" HeaderText="Bank Name" />
                                                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                                                        <asp:BoundField DataField="ProjectCost" HeaderText="Project Cost" />
                                                         <asp:BoundField DataField="AmountSanctioned" HeaderText="Amount Sanctioned" />
                                                        <asp:BoundField DataField="Type_of_loan" HeaderText="Type_of_loan" />
                                                        <asp:BoundField DataField="CurrentStatus" HeaderText="CurrentStatus" />
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                         <asp:BoundField DataField="groundeddate" HeaderText="Grounded Date" />

                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>


                                    </table>
                                </div>
                                 <br />
                                  
                                        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                            type="button" value="Print" /><br />
                                    

                            </div>
            </div>
        </div>
                </div>
                </div>
            </div>
    </form>
</body>
</html>
