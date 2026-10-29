<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveMISPendencyReport1.aspx.cs" Inherits="UI_TSiPASS_IncentiveMISPendencyReport1" %>

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
                                    <asp:Label ID="lblHeading" runat="server">INCENTIVE MIS PENDENCY REPORT (INTENT LETTER) - DISTRICT WISE</asp:Label>&nbsp;
                                    <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 99%; font-family: 'Trebuchet MS'">
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px;width:100px" >
                                            <asp:Label ID="Label352" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                data-balloon-pos="down" CssClass="LBLBLACK">District : </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width:200px" >
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="false">
                                                <asp:ListItem Value="%">--ALL--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width:150px" >
                                            <asp:Button ID="btnSearch" Width="70px" runat="server" CssClass="btn btn-primary"  TabIndex="10"
                                                Text="Search" OnClick="btnSearch_Click" />
                                        </td>
                                        <td></td><td></td><td></td>
                                    </tr>

                                    <tr id="div_Print" runat="server">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                            <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False"
                                                CellPadding="4" OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                                ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" HorizontalAlign="Center" />
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
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="No. of Claims Filed">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplNoofClaimsFiled" runat="server" Text='<%#Eval("NoofClaimsFiled") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblNoofClaimsFiled" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Timelimits">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplGMInspPendingWithin" runat="server" Text='<%#Eval("GMInspPendingWithin") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblGMInspPendingWithin" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Timelimits">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplGMInspPendingBeyond" ForeColor="Red" runat="server" Text='<%#Eval("GMInspPendingBeyond") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblGMInspPendingBeyond" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Timelimits">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplInspAssignDateWithin" runat="server" Text='<%#Eval("InspAssignDateWithin") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblInspAssignDateWithin" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Timelimits">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplInspAssignDateBeyond" ForeColor="Red" runat="server" Text='<%#Eval("InspAssignDateBeyond") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblInspAssignDateBeyond" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Timelimits">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplInspUploadWithin" runat="server" Text='<%#Eval("InspUploadWithin") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblInspUploadWithin" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Timelimits">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplInspUploadBeyond"  ForeColor="Red" runat="server" Text='<%#Eval("InspUploadBeyond") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblInspUploadBeyond" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Timelimits">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplGMtoCOIWithin" runat="server" Text='<%#Eval("GMtoCOIWithin") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblGMtoCOIWithin" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Timelimits">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplGMtoCOIBeyond" ForeColor="Red" runat="server" Text='<%#Eval("GMtoCOIBeyond") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblGMtoCOIBeyond" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Pending">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplWITHINPENDING" runat="server" Text='<%#Eval("WITHINPENDING") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblWITHINPENDING" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Beyond Pending">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplBEYONDPENDING" ForeColor="Red" runat="server" Text='<%#Eval("BEYONDPENDING") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblBEYONDPENDING" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total Pending">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplWITHINANDBEYONDTOTAL" runat="server" Text='<%#Eval("WITHINANDBEYONDTOTAL") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblWITHINANDBEYONDTOTAL" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Query Raised by IPO Pending at GM">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplIPOqryRaisedbtGMnoaction" runat="server" Text='<%#Eval("IPOqryRaisedbtGMnoaction") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblIPOqryRaisedbtGMnoaction" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="IPO Query Responded by Applicant and Pending at GM">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplApplrespondedtoIPOqrybtGMNoaction" runat="server" Text='<%#Eval("ApplrespondedtoIPOqrybtGMNoaction") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblApplrespondedtoIPOqrybtGMNoaction" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="JD Query Responded by Applicant and pending at GM">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplApplrespondedtoJDqrybtGMNoaction" runat="server" Text='<%#Eval("ApplrespondedtoJDqrybtGMNoaction") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblApplrespondedtoJDqrybtGMNoaction" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total Queries Pending">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplTotalPending" runat="server" Text='<%#Eval("TotalQueryPending") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalPending" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Query Pending at Applicant" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplQueryPending" runat="server" Text='<%#Eval("QueryPendingatApplicant") %>'>HyperLink</asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblQueryPending" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DistCd" HeaderText="DistCd" Visible="false" />
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
        </div>
    </div>
</asp:Content>
