<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="frmImplstatuspendencyDrill.aspx.cs" Inherits="UI_TSIPASS_frmImplstatuspendencyDrill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <%-- <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>
    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>
    <script language="javascript" type="text/javascript">
        function Panel1() {




            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body style="width: 100%;text-align: center;">');
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
    </script>
    <script type="text/javascript">

        //        function pageLoad() {

        //            $('#<%=grdDetails.ClientID%>').gridviewScroll({
        //                width: "100%",
        //                height: "100%",
        //                arrowsize: 30,
        //                varrowtopimg: "../../images/arrowvt.png",
        //                varrowbottomimg: "../../images/arrowvb.png",
        //                harrowleftimg: "../../images/arrowhl.png",
        //                harrowrightimg: "../../images/arrowhr.png"
        //            });
        //        }


        function GridHeaderFixed() {
            var scroll = $(window).scrollTop();
            var anchor_top = $('#<%=grdDetails.ClientID%>').offset().top;
            var anchor_bottom = $("#bottom_anchor").offset().top;
            if (scroll > anchor_top && scroll < anchor_bottom) {
                clone_table = $("#clone1");
                if (clone_table.length == 0) {
                    clone_table = $('#<%=grdDetails.ClientID%>').clone().find('tr+tr+tr').remove().end();
                    clone_table.attr('id', 'clone1');
                    clone_table.css({
                        position: 'fixed',
                        'pointer-events': 'none',
                        top: 0
                    });
                    clone_table.width($('#<%=grdDetails.ClientID%>').width());
                    $("#table-container").append(clone_table);
                    $("#clone1").css({ visibility: 'hidden' });
                    if ($("#clone1 tbody tr:first").has('th')) {
                        $("#clone1 tbody tr:first").css({ visibility: 'visible' });
                    } else { $("#clone1 thead").css({ visibility: 'visible' }); }

                    //nth-child(2)
                    $.each($('#<%=grdDetails.ClientID%> tr:first th'), function (i, v) {
                        console.log($(v).width());
                        $("#clone1").find("tr td").eq(i).width($(v).width()); //.addClass('GridviewScrollC1HeaderWrap');
                    });
                }
            } else {
                $("#clone1").remove();
            }
        }


        //  $(window).scroll(GridHeaderFixed);


        $(function () {

            $('#MstLftMenu').remove();

        });



    </script>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#"></a></li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label>&nbsp;&nbsp; <a id="A2" href="#"
                                onserverclick="BtnSave2_Click1" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a><a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%; font-family: 'Trebuchet MS'">
                            <%--<tr>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmR1ReportKMR.aspx"
                                    Text="Back">
                                </asp:HyperLink>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/frmImplstatuspendency.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="divPrint" runat="server">
                                            <td align="center" style="padding: 5px; margin: 5px; width: 100%; text-align: center;"
                                                valign="top">
                                                <div id="grid-table-container">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false"
                                                        CellPadding="5" ShowFooter="false" Width="100%" OnRowDataBound="grdDetails_RowDataBound">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <%-- <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />--%>
                                                            <asp:TemplateField HeaderText="Unit Name">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLink2" Target="_blank" runat="server" NavigateUrl='<%# Eval("intQuessionaireid", "ApplicationTrakerDetailed.aspx?ID={0}") %>'
                                                                        Text='<%# Eval("UnitName") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="UID No">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" NavigateUrl='<%# Eval("intCFEEnterpidnew", "ViewCFEPrint.aspx?Id={0}") %>'
                                                                        Text='<%# Eval("UID_No") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="UID_No" HeaderText="UID No" />--%>
                                                            <asp:BoundField DataField="Mno" HeaderText="Mobile Number" />
                                                            <asp:BoundField DataField="lineofActivity" HeaderText="line of Activity" />
                                                            <asp:BoundField DataField="District" HeaderText="District" />
                                                            <asp:BoundField DataField="Manda_lName" HeaderText="Mandal" />
                                                            <asp:BoundField DataField="Investment" HeaderText="Investment(Rs. in Crs)" />
                                                            <asp:BoundField DataField="NoofEmployee" HeaderText="No of Employee" />
                                                            <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="LastUpdateddate" HeaderText="Last Updated Date" />
                                                            <asp:BoundField DataField="Progress" HeaderText="Progress" />
                                                            <asp:BoundField DataField="RemarksStatus" HeaderText="Remarks" />
                                                            <asp:TemplateField HeaderText="Images">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLink5" Target="_blank" runat="server" NavigateUrl='<%# Eval("ImageLink") %>'
                                                                        Text="Images" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <div id="bottom_anchor">
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="divExport" visible="false" runat="server">
                                            <td align="center" style="text-align: center;" valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                        &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                        Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                   <%-- <asp:HyperLink CssClass="btn btn-link" ID="HyperLink3" runat="server" NavigateUrl="~/UI/TSiPASS/frmImplstatuspendency.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>--%>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
