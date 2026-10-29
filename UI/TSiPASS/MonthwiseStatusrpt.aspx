<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="MonthwiseStatusrpt.aspx.cs" Inherits="UI_TSiPASS_MonthwiseStatusrpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({
                width: 1090,
                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        }

    </script>--%>
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=btnGet.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";

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
        .algnCenter
        {
            text-align: right;
        }
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" align="center">
                <h2 class="panel-title" style="font-weight: bold;">
                    R1.5 Month wise Applications Received and Status of Implementation <a id="pdfPrint"
                        href="#" onclick="javascript:return Panel1();" runat="server">
                        <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                            style="float: right;" /></a> <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>
                </h2>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                Text="<< Back">
                            </asp:HyperLink>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="3">
                            <table style="width: 60%">
                                <tr>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                        Year
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="center">
                                        <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox"
                                            Height="33px" Width="180px">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="2019">2019</asp:ListItem>
                                            <asp:ListItem Value="2018">2018</asp:ListItem>
                                            <asp:ListItem Value="2017">2017</asp:ListItem>
                                            <asp:ListItem Value="2016">2016</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="padding: 5px; margin: 5px" colspan="2" align="left">
                                        <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                            Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td align="right">
                            <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                Text="Generate Pdf" OnClick="btnbdf_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="grdDetails_RowDataBound" Width="100%" ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %>
                                            <asp:Label ID="lblyear" runat="server" Text='<%# Eval("YEAR") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("MonthCode") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MONTH" HeaderText="Month"></asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="During the month"
                                        DataTextField="NOOFAPPLICATIONSDURING">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Upto the month"
                                        DataTextField="NOOFAPPLICATIONSUPTO">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="During the month"
                                        DataTextField="APROVALAAREGIVENDURING">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Upto the month"
                                        DataTextField="APROVALAAREGIVENUPTO">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Applications Pending"
                                        DataTextField="NoofApplicationsPending">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Applications Rejected"
                                        DataTextField="RejectedApplications">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Yet to Start"
                                        DataTextField="Yet_to_Start">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Initial Stage"
                                        DataTextField="Initial_Stage">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Advanced Stage"
                                        DataTextField="Advanced_Stage">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Commenced Operations"
                                        DataTextField="Commenced_Operations">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <%--<asp:BoundField DataField="NOOFAPPLICATIONSDURING" HeaderText="During the month"></asp:BoundField>
                                <asp:BoundField DataField="NOOFAPPLICATIONSUPTO" HeaderText="Upto the month"></asp:BoundField>
                                <asp:BoundField DataField="APROVALAAREGIVENDURING" HeaderText="During the month"></asp:BoundField>
                                <asp:BoundField DataField="APROVALAAREGIVENUPTO" HeaderText="Upto the month"></asp:BoundField>
                                <asp:BoundField DataField="NoofApplicationsPending" HeaderText="No of Applications Pending"></asp:BoundField>
                                <asp:BoundField DataField="RejectedApplications" HeaderText="No of Applications Rejected"></asp:BoundField>
                                <asp:BoundField DataField="Yet_to_Start" HeaderText="Yet to Start"></asp:BoundField>
                                <asp:BoundField DataField="Initial_Stage" HeaderText="Initial Stage"></asp:BoundField>
                                <asp:BoundField DataField="Advanced_Stage" HeaderText="Advanced Stage"></asp:BoundField>
                                <asp:BoundField DataField="Commenced_Operations" HeaderText="Commenced Operations"></asp:BoundField>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
