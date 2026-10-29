<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="BilldeskUserCharges.aspx.cs" Inherits="UI_TSiPASS_BilldeskUserCharges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .tbl-primary {
            margin: 5px auto;
            position: relative;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
            display: table;
            border-collapse: collapse;
            width: 100%;
        }
            /*.tbl-primary th{
	background:linear-gradient(#49708f, #293f50);
	color:#fff;
	padding:4px 10px;
	text-align:center;
}*/
            .tbl-primary td {
                padding: 4px 10px;
                border: 1px solid #ccc;
            }

            .tbl-primary tr{
                background: #f7f7f7;
            }

        .mainheading {
            height: auto;
            width: auto;
            line-height: 20px;
            display: inline-block;
            color: #3a3a3a;
            margin: 0 auto;
            background: #fcfcfc;
            text-align: center;
            box-shadow: 5px 0 5px -5px #333, -5px 0 5px -5px #333;
            font-size: 21px;
            padding: 4px;
            font-family: TimesNewRoman;
            border: 1px solid #ccc;
            padding-left: 35px;
            padding-right: 35px;
            margin-bottom: 5px;
        }
        /*:nth-child(even)*/ 
    </style>
    <table class="tbl-primary">
                    <tr>
                        <td>
                            <center>
                                <div class="mainheading">Bill Desk Payment Gateway</div>
                            </center>
                            <table class="tbl-primary">
                                            <tr style="color: White; background-color: #1D9A5B; font-weight: bold; text-align: center; border: 1px solid black;">
                                               <%-- <td>
                                                    <table>
                                                        <tr>--%>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text="Service Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text="Transaction Fee"></asp:Label>
                                                            </td>
                                                 <%--       </tr>
                                                    </table>
                                                </td>--%>
      
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_if" runat="server" Text="Intigration effort (One time chargers Rs.10,000)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_ifdetails" runat="server" Text="Not Mentioned"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_am" runat="server" Text="Annual maintenence charges (Rs.3000 per annum)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_amdetais" runat="server" Text="Not Mentioned"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_ccards" runat="server" Text="Credit Cards"></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:Label ID="lbl_cdtails" runat="server" Text="1.00% on the transaction values"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_dcards" runat="server" Text="Debit Cards"></asp:Label></td>
                                                <td>
                                                    <table class="tbl-primary">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_valupto" runat="server" Text="For value upto Rs2000/-"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl_uptovalue" runat="server" Text="0.75% on the transaction values"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="For value Above Rs2000/-"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="1.00% on the transaction values"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_netbanking1" runat="server" Text="Internet Banking"></asp:Label>
                                                </td>
                                                <td>
                                                    <table class="tbl-primary">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text="SBI/ICICI/AXIS"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label26" runat="server" Text="Rs.8.00 on the transaction value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label27" runat="server" Text="All Banks"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label28" runat="server" Text="Rs.4.00 on the transaction value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label29" runat="server" Text="HDFC Banks"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label30" runat="server" Text="Rs.15.00 on the transaction value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" Text="NEFT/RTGS/IFT (Retail & Bulk)"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label32" runat="server" Text="Fecility not available"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_ep" runat="server" Text="Electronic Payments (API Intigration charges) Rs.1,00,000"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_epdetails" runat="server" Text="Fecility not available"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                 
                        </td>
                        <td>
                            <center>
                                <div class="mainheading">Kotak Bank Payment Gateway </div>
                            </center>
                            <table id="Table1" runat="server" class="tbl-primary">

                                                        <tr style="color: White; background-color: #1D9A5B; font-weight: bold; text-align: center; border: 1px solid black;">
                                               <%-- <td>
                                                    <table>
                                                        <tr>--%>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text="Service Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Transaction Fee"></asp:Label>
                                                            </td>
                                                 <%--       </tr>
                                                    </table>
                                                </td>--%>
      
                                            </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_kif" runat="server" Text="Intigration effort (One time chargers Rs.10,000)"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_kifdetails" runat="server" Text="WAIVED"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_kam" runat="server" Text="Annual maintenence charges (Rs.3000 per annum)"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_kamdetails" runat="server" Text="WAIVED"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text="Credit Cards"></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text="1.00% on the transaction values"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text="Debit Cards"></asp:Label></td>
                                                            <td>
                                                                <table class="tbl-primary">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label10" runat="server" Text="For value upto Rs2000/-"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label11" runat="server" Text="NILL"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label12" runat="server" Text="For value Above Rs2000/-"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label13" runat="server" Text="0.90% on the transaction values"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text="Internet Banking"></asp:Label>
                                                            </td>

                                                            <td>
                                                                <table class="tbl-primary">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label18" runat="server" Text="SBI/ICICI/AXIS"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label19" runat="server" Text="Rs.7.00 on the transaction value"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label20" runat="server" Text="All Banks"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label21" runat="server" Text="Rs.4.00 on the transaction value"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label24" runat="server" Text="HDFC Banks"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label25" runat="server" Text="Rs.7.00 on the transaction value"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label22" runat="server" Text="NEFT/RTGS/IFT (Retail & Bulk)"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label23" runat="server" Text="NILL"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl_kep" runat="server" Text="Electronic Payments (API Intigration charges) Rs.1,00,000"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_kepdetails" runat="server" Text="WAIVED"></asp:Label>
                                                            </td>
                                                        </tr>
                                        </table>
                        </td>
                    
                                </tr>
                    <tr style="color: White; background-color: #BE8C2F; font-weight: bold; text-align: center;">
                        <td colspan="2" style="text-underline-position: below">
                            <asp:Label ID="Label17" runat="server" Text="Service Tax at the applicable rate will be changed on the above"></asp:Label>
                        </td>
                    </tr>
                </table>
</asp:Content>


