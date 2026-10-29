<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlotAllotmentDeptPopup.aspx.cs" Inherits="UI_TSiPASS_PlotAllotmentDeptPopup" %>

<!DOCTYPE html>

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
            padding: 10px10px10px10px;
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

        
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td>UID No:
                                </td>
                                <td>
                                    <asp:Label ID="lblUidNo" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>District
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbl_District" runat="server"></asp:Label>
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
                                <td>Industrial Park
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbl_indusrtialpark" runat="server"></asp:Label>
                                    </span>
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
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UIDNo" HeaderText="Department"></asp:BoundField>
                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required "></asp:BoundField>
                                    <asp:BoundField DataField="Dept_Name" HeaderText="Department"></asp:BoundField>
                                     <asp:BoundField DataField="District_Name" HeaderText="District"></asp:BoundField>

                                    <asp:BoundField DataField="IndustrialParkId" HeaderText="Industrial Park"></asp:BoundField>
                                    <asp:BoundField DataField="DateofSubmittion" HeaderText="Application Applied On"></asp:BoundField>
                                    <asp:BoundField DataField="PaymentDate" HeaderText="Payment Made On"></asp:BoundField>
                                     <asp:BoundField DataField="StageName" HeaderText="Current Status"></asp:BoundField>
                                    
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Deffered
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <th>Date</th>
                                                    <th>Time Taken</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <%#Eval("Dept_Deffered_date")%>
                                                        <td>
                                                            <%#Eval("DefferedDayCout")%>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Approval
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <th>Date</th>
                                                    <th>Time Taken</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <%#Eval("Approval_date")%>
                                                        <td>
                                                            <%#Eval("ApprovalDayCount")%>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Rejected
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <th>Date</th>
                                                    <th>Time Taken</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <%#Eval("Dept_Rejected_date")%>
                                                        <td>
                                                            <%#Eval("RejectDayCount")%>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <HeaderTemplate>
                                            Query Raise
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <th>Date</th>
                                                    <th>Time Taken</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <%#Eval("Query_RaiseDate")%>
                                                        <td>
                                                            <%#Eval("QueryRaiseDayCount")%>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <HeaderTemplate>
                                            Query Responded
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <th>Date</th>
                                                    <th>Time Taken</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <%#Eval("Query_ResponedDate")%>
                                                        <td>
                                                            <%#Eval("QueryRespondedCount")%>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    							

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
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
