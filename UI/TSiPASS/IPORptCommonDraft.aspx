<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IPORptCommonDraft.aspx.cs"
    Inherits="UI_TSiPASS_IPORptCommonDraft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Power Tariff</title>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <style type="text/css">
        .div3 {
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div style="text-align: center">
                    <div align="center">
                    </div>
                    <div align="center" id="Receipt" runat="server">
                        <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small; width: 1000px;">
                            <tr>
                                <td colspan="4">
                                    <br />
                                    <center>
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                                    </center>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td width="1000px" style="text-align: center" colspan="4">
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="lblheadTPRIDE" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="1000px" style="text-align: center" colspan="4">
                                    <br />
                                    <span style="font-weight: bold; font-size: large;"><u>
                                        <asp:Label ID="lblsubsidytype" runat="server"></asp:Label></u></span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">1.
                                </td>
                                <td style="text-align: left; width: 350px;">Applicant No.
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblapplicantno" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">2.
                                </td>
                                <td style="text-align: left; width: 350px;">Applicant Name.
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblapplicantname" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">3.
                                </td>
                                <td style="text-align: left; width: 350px;">Unit Name.
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblunitname" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">4.
                                </td>
                                <td style="text-align: left; width: 350px;">Amount claimed in Rs.
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblamountclamed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">5.
                                </td>
                                <td style="text-align: left; width: 350px;">Amount recommended in Rs.
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblamountrecommended" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">6.
                                </td>
                                <td style="text-align: left; width: 350px;">Remarks
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblremarks" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">7.
                                </td>
                                <td style="text-align: left; width: 350px;">Is DLC Or SLC
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblslcdlc" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trfinyear" runat="server" visible="false">
                                <td style="width: 10px; text-align: center">8.
                                </td>
                                <td style="text-align: left; width: 350px;">Claimed Financial Year details:
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblclaimedfinyeardtls" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="width: 10px; text-align: center">1.
                                </td>
                                <td style="text-align: left; width: 350px;">Amount claimed in Rs.
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblamountclamed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">2.
                                </td>
                                <td style="text-align: left; width: 350px;">Amount recommended in Rs.
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblamountrecommended" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">3.
                                </td>
                                <td style="text-align: left; width: 350px;">Remarks
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblremarks" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; text-align: center">4.
                                </td>
                                <td style="text-align: left; width: 350px;">Is DLC Or SLC
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblslcdlc" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trfinyear" runat="server" visible="false">
                                <td style="width: 10px; text-align: center">5.
                                </td>
                                <td style="text-align: left; width: 350px;">Claimed Financial Year details:
                                </td>
                                <td style="width: 1px; text-align: center">:
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblclaimedfinyeardtls" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="text-align: center; height: 5px" colspan="4"></td>
                            </tr>
                            <tr id="trinspattach" runat="server" visible="false">
                                <td style="padding: 10px; margin: 5px;" colspan="12">Inspection Report attachments:
                                </td>
                            </tr>
                            <tr id="trinspattachgrid" runat="server" visible="false">
                                <td style="padding: 10px; margin: 5px;" colspan="12">
                                    <asp:GridView ID="GridView3att" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView3att_RowDataBound"
                                        Width="90%" HorizontalAlign="Left" ShowHeader="true">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Attachments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathNew")%>' Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Attachments" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblatchid" runat="server" Text='<%# Eval("AttachmentId")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attachment" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("LINKNEW") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <p>
                                        The claim application of the captioned Enterprise/Industry is verified as per the
                                    operational guidelines. The Enterprise/Industry is eligible for availing incentives
                                    under
                                        <asp:Label ID="lblSchemesCheck" runat="server"></asp:Label>. The Enterprise/Industry did not add or removed any Plant & Machinery
                                    and there is no change of line of activity and capacity. Further, the Enterprise/Industry
                                    is in continuous operation, there is no break-in-production (if so the details of
                                    the breakin- production) and I recommend the above incentives to the captioned Enterprise/Industry.
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 80px" colspan="2"></td>
                                <td style="text-align: center; height: 80px" colspan="2" valign="bottom">
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; height: 5px" colspan="4">
                                    <u><b>Remarks of the General Manager:</b></u>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <p>
                                        The applicant Enterprise/Industry is eligible for above incentives and the claim
                                    is in order. The computation of capital cost has been done as per the provisions
                                    under the scheme. I recommend for sanction of above incentives.
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 80px" colspan="2"></td>
                                <td style="text-align: center; height: 80px" colspan="2" valign="bottom">Signature of General Manager with Office Seal.
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 5px" colspan="4"></td>
                            </tr>
                            <tr>
                                <td style="text-align: center;" colspan="4">
                                    <asp:Button ID="Button2" runat="server" Height="32px" Width="90px" CssClass="btn btn-warning"
                                        Text=" Print " OnClientClick="javascript:CallPrint('Receipt')" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: center; color: red" colspan="4">
                                    <asp:Label ID="lblerrormsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
