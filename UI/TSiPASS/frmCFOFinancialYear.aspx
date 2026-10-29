<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmCFOFinancialYear.aspx.cs" Inherits="UI_TSiPASS_frmCFOFinancialYear" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }

    </script>

    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";


            var panel = document.getElementById("<%=div_Print.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');

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



    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">R6. TS-iPASS CFO Abstract -Financial Year wise</asp:Label>
                            &nbsp;<a id="A1" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>
                                    
<a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                                     <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'" width="50%">

                            <tr>
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trFilternew" runat="server" visible="false">
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>


                            <tr>
                                <td style="padding: 5px; margin: 5px" align="left">
                                   <b>
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                </td>
                                <td style="padding: 5px; margin: 5px" align="right" colspan="7">
                                    <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>

                            </tr>
                            <tr id="div_Print" runat="server">
                                <td align="center" colspan="10" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                        ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Year" DataTextField="FinYear" />
                                            <asp:HyperLinkField HeaderText="No Of Industries" DataTextField="Total Application received">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Investments (Rs Crores)" DataTextField="Total Investments">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                             <asp:HyperLinkField HeaderText="Total Empolyment" DataTextField="Total Empolyment">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Micro" DataTextField="ManufacturingMicro">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Small" DataTextField="ManufacturingSmall">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Medium" DataTextField="ManufacturingMedium">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Large" DataTextField="ManufacturingLarge">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Mega" DataTextField="ManufacturingMega">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Micro" DataTextField="ServiceMicro">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Small" DataTextField="ServiceSmall">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Medium" DataTextField="ServiceMedium">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Large" DataTextField="ServiceLarge">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Mega" DataTextField="ServiceMega">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="YearCD" DataTextField="FinYearCD" Visible="false" />
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">

                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>

                            </tr>
                            <%-- <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>--%>
                        </table>

                        <div>
                            <div id="barchat" style="width: 1000px; height: 500px;"></div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>



    <script type="text/javascript" src="../../js/googleapi.js"></script>
    <script type="text/javascript">
        var table = "";
        var newrows = [];
        var griddata = [];
        var count = 0;
        count = $("#ctl00_ContentPlaceHolder1_grdDetails tr:not(:last-child,:first-child)").length;
        $("#ctl00_ContentPlaceHolder1_grdDetails").each(function () {
            var $this = $(this);
            $this.find("tr:not(:last-child)").each(function () {
                var i = 0;
                $(this).find("td, th").each(function () {
                    i++;
                    if (newrows[i] === undefined) { newrows[i] = new Array(); }
                    if (i == 1)
                        newrows[i].push($(this).text());
                    else {
                        var d = $(this).text();
                        if (!isNaN(d)) {
                            d = parseInt(d);
                        }
                        newrows[i].push(d);
                    }
                });
            });
        });
        for (var i = 2; i <= newrows.length - 1; i++) {
            if (i != 4) {
                griddata.push(newrows[i]);
            }
        }
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {

            var data = google.visualization.arrayToDataTable(griddata);


            var options = {
                width: 1000,
                height: 550,
                vAxis: { format: '' },
                legend: { position: 'bottom', maxLines: 3, textStyle: { color: 'black', fontSize: 16 } },
                bar: { groupWidth: '75%' },
                bars: 'vertical',
                colors: ['#3366cc', '#ff9900', '#dc3912'],
                title: 'Finacial Year Wise Comparsion',
                titleTextStyle: { fontSize: 18, bold: true },
                //                chartArea: {
                //                 left: "10%",
                //                 top: "3%",
                //                 height: "80%",
                //                 width: "100%"
                //                },

            };


            var totalColumns = count;
            var view = new google.visualization.DataView(data);
            var columns = [];
            for (var i = 0; i <= totalColumns; i++) {
                if (i > 0) {
                    columns.push(i);
                    columns.push({
                        sourceColumn: i,
                        role: "annotation"
                    });

                } else {
                    columns.push(i);
                }
            }

            view.setColumns(columns);

            var chart = new google.visualization.ColumnChart(document.getElementById('barchat'));
            chart.draw(view, options);

        }

    </script>





</asp:Content>

