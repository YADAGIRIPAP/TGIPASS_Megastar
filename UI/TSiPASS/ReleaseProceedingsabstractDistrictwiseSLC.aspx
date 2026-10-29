<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ReleaseProceedingsabstractDistrictwiseSLC.aspx.cs" Inherits="UI_TSIPASS_ReleaseProceedingsabstractDistrictwiseSLC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" type="text/javascript">
         function Panel1() {
             document.getElementById('<%=btnGet.ClientID %>').style.display = "none";
           

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }

        $(function () {

            $('#MstLftMenu').remove();

        });

    </script>

    <style>
        .algnCenter {
            text-align: right;
        }

        .yellow {
            background-color: yellow !important;
        }

        .green {
            background-color: #ceffee !important;
        }
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <h2 class="panel-title" style="font-weight: bold;">R2.2 Release Proceedings Abstarct - District Wise - SLC
                                <%-- <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">--%>
                               
                                <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a> </h2>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:hyperlink cssclass="btn btn-link" id="HyperLink1" runat="server" navigateurl="~/UI/TSiPASS/IncentiveReportsDashboard.aspx" text="<< Back">
                        </asp:hyperlink>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="3">
                        <table style="width: 80%">
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <table style="width: 100%">
                                        <tr id="trappstype" runat="server" visible="true">
                                            <td align="center" style="text-align: left; width: 100px" valign="middle">District
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <asp:dropdownlist id="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                    height="33px" width="180px" tabindex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:dropdownlist>
                                            </td>

                                        </tr>

                                        <tr style="height: 60px">
                                            <td colspan="10" align="center" valign="bottom">
                                                <asp:button id="btnGet" runat="server" cssclass="btn btn-primary" height="32px" tabindex="10" text="Generate Report" width="180px" onclick="btnGet_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" align="center">
                                                <asp:label id="lblMsg0" runat="server" font-bold="True" font-names="verdana" font-size="13px"
                                                    forecolor="#006600"></asp:label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>


                </tr>
                <tr style="height: 30px">

                    <td align="right">
                        <asp:button id="btnbdf" runat="server" cssclass="btn btn-primary" height="32px" tabindex="10" text="Generate Pdf" onclick="btnbdf_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>

                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                        <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="False" cellpadding="4"
                            onrowdatabound="grdDetails_RowDataBound" width="100%" cssclass="floatingTable"
                            showfooter="True" onrowcreated="grdDetails_RowCreated">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <asp:Label ID="lblReleaseProceedingNo" runat="server" Text='<%# Eval("ReleaseProceedingNo") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblDistId" runat="server" Text='<%# Eval("DistId") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="DistName" HeaderText="District Name"></asp:BoundField>
                                 <asp:BoundField DataField="ReleaseProceedingNo" HeaderText="Release Proceeding No"></asp:BoundField>
                                 <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No. of Units"
                                    DataTextField="NOofunits">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="amount" HeaderText="Amount"></asp:BoundField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Working Units"
                                    DataTextField="NOofunitsW">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Closed Units"
                                    DataTextField="NOofunitsWC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="UC Not Updated"
                                    DataTextField="NOofunitsNt">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:gridview>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

