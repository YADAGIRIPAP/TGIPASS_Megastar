<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelAgentAdminPopup.aspx.cs" Inherits="UI_TSiPASS_TravelAgentAdminPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Untitled Page</title>
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
            list-style-type: none; ;font-size:13px;padding:10px10px10px10px;}
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
        }</style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
        <div align="center" style="text-align: center">
            <div align="center">
                <div align="center">
                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
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
                    </table>
                </div>
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
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
                                    Address
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDistrict0" runat="server"></asp:Label>
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
                        </table>
                    </div>
                    <div align="center">
                        <table bgcolor="White" width="100%" border="2px"  style="font-family: Verdana; padding:10px; font-size: x-small;">
                            <tr>
                                <td style="width:20px; height:20px; background-color:White;">
                                    
                                </td>
                               
                                <td>
                                    InProgress of  Pre-Scrutiny / Approval / Payment
                                </td>
                                <td style="width:20px; height:20px; background-color:Green;">
                                    
                                </td>
                               
                                <td>
                                     Completed Pre-Scrutiny / Approval / Payment With in Time Limits
                                </td>
                                <td style="width:20px; height:20px; background-color:#ffa500;">
                                    
                                </td>
                            
                                <td>
                                    Offline Approvals
                                </td>
                                <td style="width:20px; height:20px; background-color:Red;">
                                    
                                </td>
                                <td>
                                    Completed Pre-Scrutiny / Approval / Payment Beyond Time Limits / Rejected
                                </td>
                                
                            </tr>
                        </table>
                    </div>
                    <div align="center">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" OnRowDataBound="grdDetails_RowDataBound" Height="62px" PageSize="15"
                            Width="100%" ShowFooter="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                            Font-Bold="False" Font-Names="Verdana" Font-Size="12px">
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required "></asp:BoundField>
                                <asp:BoundField DataField="Dept_Full_name" HeaderText="Department"></asp:BoundField>
                                <asp:BoundField DataField="OfflineApproval" HeaderText="Approval already obtained offline">
                                </asp:BoundField>
                                <asp:BoundField DataField="ApprovalsAplied" HeaderText="Approval Applied"></asp:BoundField>
                                <asp:BoundField DataField="PreScrutiny" HeaderText="Pre-Scrutiny"></asp:BoundField>
                                <asp:BoundField DataField="QueryRaised" HeaderText="Query Raised (Days)"></asp:BoundField>
                                <asp:BoundField DataField="Payments" HeaderText="Payment"></asp:BoundField>
                                <asp:BoundField DataField="Approval" HeaderText="Approval"></asp:BoundField>
                                 <asp:BoundField DataField="Rejected" HeaderText="Rejected"></asp:BoundField>
                                <asp:BoundField DataField="DeptSubmitdate" HeaderText="Date Applied"></asp:BoundField>
                            </Columns>
                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                            <EditRowStyle BackColor="#B9D684" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <br />
                        <br />
                        <a onclick="window.print();return false">
                            <asp:Image ID="Image4" runat="server" Height="40px" ImageUrl="~/images/printimage.jpg"
                                Width="40px" /></a>
                    </div>
    </form>
</body>
</html>
