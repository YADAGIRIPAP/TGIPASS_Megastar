<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveDisbursmentMISPendencyReport.aspx.cs" Inherits="UI_TSiPASS_IncentiveClaimsReport" %>


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
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>newTable</title>');

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

    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({

                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        } 
           
    </script>--%>

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">INCENTIVE MIS PENDENCY REPORT (DISBURSEMENT) - DISTRICT WISE</asp:Label>&nbsp; <a id="A1" href="#"
                                onserverclick="BtnPDF_Click" runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>
                            <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 95%; font-family: 'Trebuchet MS'">
                            <%--<tr id="trFilter" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr align="center">
                                            <td colspan="5">
                                                <table>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" colspan="2">
                                                            <div class="input-group">
                                                                <div class="input-group-addon">
                                                                    From Date
                                                                </div>

                                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                                </cc1:CalendarExtender>
                                                            </div>
                                                        </td>
                                                        <td style="width: 5px"></td>
                                                        <td style="padding: 5px; margin: 5px" colspan="2" >

                                                            <div class="input-group">
                                                                <div class="input-group-addon">
                                                                    To Date
                                                                </div>
                                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                                </cc1:CalendarExtender>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="center" colspan="6">
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave1_Click" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="6">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                            <td style="padding: 5px; margin: 5px" align="left" colspan="4"></td>
                                            <td></td>

                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>--%>
                            <%--<tr visible="false" id="trBtns" runat="server">
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button Visible="false" ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" Height="32px"
                                        TabIndex="10" Text="Print" Width="90px" OnClientClick="return Panel1();" />
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="text-align: left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>
                                </td>
                            </tr>
                            <tr id="div_Print" runat="server">
                                <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" Width="110%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                        ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                            <asp:BoundField DataField="DistId" HeaderText="DistId" Visible="false" />
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Approved for Releasing" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLinkSLC" runat="server" Text='<%#Eval("NOofApplicationsApproved") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Issued Release Proceeding" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("NOofunitsReleased") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Released Amount" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%#Eval("amount") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="UC Updated - Working" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink3" runat="server" Text='<%#Eval("NOofunitsW") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="UC Updated - Close" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink4" runat="server" Text='<%#Eval("NOofunitsC") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="UC Not Updated" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink5" runat="server" Text='<%#Eval("NOofunitsNt") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Approved Within" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink6" runat="server" Text='<%#Eval("ApprovedWithin") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Approved Beyond" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink7" runat="server" Text='<%#Eval("ApprovedBeyond") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>


    <script type="text/javascript">


        function NumberToIndianRupees(x) {
            x = x.toString();
            var afterPoint = '';
            if (x.indexOf('.') > 0)
                afterPoint = x.substring(x.indexOf('.'), x.length);
            x = Math.floor(x);
            x = x.toString();
            var lastThree = x.substring(x.length - 3);
            var otherNumbers = x.substring(0, x.length - 3);
            if (otherNumbers != '')
                lastThree = ',' + lastThree;
            var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree + afterPoint;
            return res;
        }


        $(function () {


            var result = [];
            $('table tr').each(function () {
                $('td', this).each(function (index, val) {
                    if (!result[index]) result[index] = 0;
                    result[index] += parseInt($(val).text());
                });
            });

            console.log(result);

            //                $('table').append('<tr></tr>');
            //                $(result).each(function () {
            //                    $('table tr').last().append('<td>' + this + '</td>')
            //                });

        });

    
    </script>
</asp:Content>

