<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CFEPopupDept.aspx.cs" Inherits="Default2"
    Title="CFE-Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                    <table bgcolor="White" width="100%" border="2px" 
                        style="font-family: Verdana; font-size: small; visibility: hidden; display:none">
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
                        <table bgcolor="White" width="100%" border="2px" 
                            style="font-family: Verdana; font-size: small; visibility: hidden; display: none;">
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
                    <div align="center">
                        <asp:GridView ID="grdDetails" runat="server" 
                                                AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" 
                           OnRowDataBound="grdDetails_RowDataBound" Height="62px" PageSize="15" Width="100%" 
                        ShowFooter="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                        Font-Bold="False" Font-Names="Verdana" Font-Size="14px" 
                        >
                            <footerstyle font-bold="True" forecolor="Black" />
                            <rowstyle horizontalalign="Left" 
                                                    verticalalign="Middle" />
                            <columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required " >
                                </asp:BoundField>
                                <asp:BoundField DataField="Dept_Full_name" HeaderText="Department" >
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="OfflineApproval" HeaderText="Approval already obtained offline" >
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="ApprovalsAplied" HeaderText="Approval Applied" >
                                </asp:BoundField>
                                <asp:BoundField DataField="PreScrutiny" HeaderText="Pre-Scrutiny" >
                                </asp:BoundField>
                                <asp:BoundField DataField="QueryRaised" HeaderText="Query Raised (Days)" >
                                </asp:BoundField>
                                <asp:BoundField DataField="Payments" HeaderText="Payment">
                                </asp:BoundField>
                                <asp:BoundField DataField="Approval" HeaderText="Approval">
                                </asp:BoundField>
                            </columns>
                            <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                            <selectedrowstyle font-bold="True" forecolor="#333333" />
                            <headerstyle font-bold="True" 
                                                    forecolor="Black" />
                            <editrowstyle backcolor="#B9D684" />
                            <alternatingrowstyle backcolor="White" />
                        </asp:GridView>
                        <br />
                        <br />
                        
                         <a onClick="window.print();return false"> <asp:Image ID="Image4" runat="server" Height="40px" 
                                                ImageUrl="~/images/printimage.jpg" Width="40px" /></a>
                        </div>
                    </div>
                    </form>
</body>
</html>
