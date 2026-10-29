<%@ Page Language="C#"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"   AutoEventWireup="true" CodeFile="IncentiveMISPendencyReport_GMCONFERENCE_OOFICERWISE.aspx.cs" Inherits="UI_TSiPASS_IncentiveMISPendencyReport_GMCONFERENCE_OOFICERWISE" %>


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
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server">INCENTIVE MIS PENDENCY REPORT (INTENT LETTER) - WITH OFFICER NAMES</asp:Label>&nbsp;
                                    <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveReportsDashboard_GMCONFERENCE.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label352" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                data-balloon-pos="down" CssClass="LBLBLACK">District : </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="false">
                                                <asp:ListItem Value="%">--ALL--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    
                                    
                                    <tr id="div_Print" runat="server">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                            <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="True"  OnRowDataBound="grdDetails_RowDataBound"
                                                  Width="100%" ShowFooter="True">
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
                                                   <%-- <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                                    <asp:BoundField DataField="DistCd" HeaderText="DistCd" Visible="false" />
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="No. of Claims Filed"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyNoofClaimsFiled" runat="server" Text='<%#Eval("NoofClaimsFiled") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Timelimits"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink2" runat="server" Text='<%#Eval("GMInspPendingWithin") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Timelimits"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink3" runat="server" Text='<%#Eval("GMInspPendingBeyond") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Center" HeaderText="About to Breach (90% of Within Time Lines)"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink10" runat="server" Text='<%#Eval("GMInspPending90") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Timelimits"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink5" runat="server" Text='<%#Eval("InspAssignDateWithin") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Timelimits"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink6" runat="server" Text='<%#Eval("InspAssignDateBeyond") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Center" HeaderText="About to Breach (90% of Within Time Lines)"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink11" runat="server" Text='<%#Eval("InspAssignDate90") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Timelimits"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink4" runat="server" Text='<%#Eval("InspUploadWithin") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Timelimits"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink7" runat="server" Text='<%#Eval("InspUploadBeyond") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Center" HeaderText="About to Breach (90% of Within Time Lines)"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink12" runat="server" Text='<%#Eval("InspUpload90") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Timelimits"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink8" runat="server" Text='<%#Eval("GMtoCOIWithin") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Timelimits"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink9" runat="server" Text='<%#Eval("GMtoCOIBeyond") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Center" HeaderText="About to Breach (90% of Within Time Lines)"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink13" runat="server" Text='<%#Eval("GMtoCOI90") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Query Pending"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink14" runat="server" Text='<%#Eval("QueryPending") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Query Not Responded Status Need to Reapply" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink17" runat="server" Text='<%#Eval("Deemed") %>'>HyperLink</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total Pending"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink15" runat="server" Text='<%#Eval("TotalPending") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Center" HeaderText="About to Breach (90% of Within Time Lines)"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink16" runat="server" Text='<%#Eval("Total90") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                    ×</a> <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
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
        </div>
    </div>
</asp:Content>


