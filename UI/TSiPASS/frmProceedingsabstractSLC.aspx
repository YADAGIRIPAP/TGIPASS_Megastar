<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmProceedingsabstractSLC.aspx.cs" Inherits="UI_TSIPASS_frmProceedingsabstractSLC" %>

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
            background-color:yellow !important;
        }

        .green {
            background-color:#ceffee !important;
        }
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <h2 class="panel-title" style="font-weight: bold;"> R2.4 : Release Proceedings Wise Abstarct - SLC
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
                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveReportsDashboard.aspx" Text="<< Back">
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="3">
                         <table style="width: 80%">
                                       <tr runat="server" visible="false">
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <table style="width: 100%">
                                        <tr id="trappstype" runat="server" visible="true">
                                             <td align="center" style="text-align: left ; width:100px" valign="middle">
                                                District
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                     
                                        <tr style="height:60px">
                                            <td colspan="10" align="center" valign="bottom">
                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                            </td>
                                        </tr>
                                           <tr>
                                            <td colspan="10" align="center">
                                                <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                    ForeColor="#006600"></asp:Label>
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
                        <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>

                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowDataBound="grdDetails_RowDataBound" Width="100%" CssClass="floatingTable"
                            ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
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
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
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
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

