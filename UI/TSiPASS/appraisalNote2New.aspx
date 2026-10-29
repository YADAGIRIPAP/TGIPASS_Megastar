<%@ Page Language="C#" AutoEventWireup="true" CodeFile="appraisalNote2New.aspx.cs" Inherits="UI_TSiPASS_appraisalNote2New" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Dynamic Print Forms</title>
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
        <div id="divDynPrint" runat="server">
        </div>


        <table>
            <tr>
                <td>
                    <asp:GridView ID='gvInstalledCap' runat='server' AutoGenerateColumns='False' BorderColor='#003399'
                        BorderStyle='Solid' BorderWidth='1px' CellPadding='4'
                        GridLines='Both' Width='90%'>
                        <Columns>
                            <asp:TemplateField HeaderText='Sl.No'>
                                <ItemTemplate>
                                    <asp:Label ID='Slno' runat='server' Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField='Column1' HeaderText='Line Of Activity' />
                            <asp:BoundField DataField='Column3' HeaderText='Installed Capacity' />
                            <asp:BoundField DataField='Column2' HeaderText='Unit' />
                            <asp:BoundField DataField='Column4' HeaderText='Value (in Rs.)' />
                            <asp:BoundField DataField='Created_by' HeaderText='Created By' Visible='false' />
                            <asp:BoundField DataField='IncentiveId' HeaderText='Incentive Id' Visible='false' />

                        </Columns>



                        <RowStyle ForeColor='#333333' Font-Names='Arial' Font-Size='12px'
                            HorizontalAlign='Center' />
                        <SelectedRowStyle BackColor='#E2DED6' Font-Bold='True' ForeColor='#333333' />
                        <FooterStyle HorizontalAlign='Center' BackColor='#5D7B9D' Font-Bold='True' ForeColor='White'
                            Font-Names='Arial' Font-Size='9px' />
                    </asp:GridView>
                </td>
            </tr>
        </table>



        <%--   <table><tr><td> <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                                                    GridLines="Both" Width="90%" 
                                                                                 >
                                                                                   
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                        
                                                                                    </Columns>
                                                                                 
                                                                                    
                                                                                    
                                                                                    <RowStyle  ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                        HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                        Font-Names="Arial" Font-Size="9px" />
                                                                                </asp:GridView>
</td></tr></table>--%>
    </form>
</body>
</html>
