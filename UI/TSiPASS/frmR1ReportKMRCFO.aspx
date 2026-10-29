<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="frmR1ReportKMRCFO.aspx.cs"
    Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
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

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=divprint.ClientID %>");
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
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("rptR1PrintCFO.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
      <%--Added datepicker on 18/01/2019--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
           
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index:9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>

    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
     <script type="text/javascript">
         function pageLoad() {
             var date = new Date();
             var yrRange = "2015:" + (date.getFullYear() + 1);

             var currentMonth = date.getMonth();
             var currentDate = date.getDate();
             var currentYear = date.getFullYear();

             $("input[id$='txtFromDate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
             $("input[id$='txtTodate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
         }
         $(function () {
             var date = new Date();
             var yrRange = "2015:" + (date.getFullYear() + 1);
             var currentMonth = date.getMonth();
             var currentDate = date.getDate();
             var currentYear = date.getFullYear();
             $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
             $("input[id$='txtTodate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
         });
    </script>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label>
                            &nbsp;<a id="A1" href="#" onclick="javascript:return OpenPopup()" runat="server">
                                <%--onserverclick="btnExport_Click"--%>
                                <%--<img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                     />--%></a>
                            &nbsp;&nbsp;&nbsp; <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                                    <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                         <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                            <%-- <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">
                                                    <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                        Height="33px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged"
                                                        Width="180px" Visible="False">
                                                        <asp:ListItem>--District--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding: 5px; margin: 5px; text-align: right; vertical-align: top;"
                                                    valign="top">
                                                    <asp:ImageButton ID="Image4" Visible="false" runat="server" Height="40px" ImageUrl="~/images/pdf-icon4.jpg"
                                                        OnClientClick="window.print();return false" Width="40px" />
                                                    &nbsp;&nbsp; <a onclick="javascript:return OpenPopup()">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/images/printimage.jpg"
                                                            Width="40px" /></a> &nbsp;
                                                </td>
                                            </tr>--%>
                            <tr>
                                <td>
                                    <div id="PrintPDF" runat="server">
                                        <table width="100%" id="divprint" runat="server">
                                            <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: right;" valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table width="90%">

                                                        <tr>
                                                             <td style="padding: 5px; margin: 5px" align="right">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardCFO.aspx" Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>
                                               
                                                            <td style="padding: 5px; margin: 5px">From Date:   
                                                
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">To Date:  
                                            
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                             <td style="padding: 5px; margin: 5px" colspan="4" align="left">
                                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                                            </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            
                                                            <td style="padding: 5px; margin: 5px" align="right" colspan="8">
                                                                 <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                            </asp:TemplateField>
                                                            <asp:HyperLinkField DataTextField="No of Application" HeaderText="No of Applications"
                                                                NavigateUrl="frmstatus.aspx?status=A">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center"/>
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="No of Approvals Required" HeaderText="Approvals required as per Questionnaire">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center"/>
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="No of Approvals Taken offline" HeaderText="Approvals already obtained">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Net Approvals required" HeaderText="Department Approvals required(Net)">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="No of Approvals Applied for" HeaderText="Approvals Applied">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:Label ID="LblProjCost" Font-Size="14px" runat="server" CssClass="LBLBLACK">Total Capital Investment (Rs. in Crores)</asp:Label>
                                                    <asp:HyperLink Font-Underline="false" ID="lbtProjCost" runat="server" Font-Size="14px"
                                                        NavigateUrl="frmstatus1CFO.aspx" Target="_blank"></asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:Label ID="Label482" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="621px">PRESCRUTINY STAGE : STATUS</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails0" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails0_RowDataBound" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid0" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid0" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                <ItemStyle Width="150px" />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="No Query but Pending" HeaderText="Pending">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Query Raised" HeaderText="Query Raised">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Completed" HeaderText="Completed">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:GridView ID="grdDetails3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails3_RowDataBound" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid3" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid3" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                <ItemStyle HorizontalAlign="Right" Width="220px" />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="Completed" HeaderText="Completed">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Query Raised" HeaderText="Query Raised">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:Label ID="Label483" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="400px">APPROVAL STAGE : STATUS</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails1_RowDataBound" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid1" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid1" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                <ItemStyle HorizontalAlign="Left" Width="220px" />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="Approved" HeaderText="Approved">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Under Process" HeaderText="Under Process">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Rejected" HeaderText="Rejected">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label484" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="400px">TS-iPASS APPROVAL : UNIT WISE STATUS</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails2_RowDataBound"
                                                        PageSize="15" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid2" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid2" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                <ItemStyle HorizontalAlign="Right" Width="220px" />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="Total Appliacations Fully Paid" HeaderText="Units">
                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Total Appliacations Approved with in Time Limits"
                                                                HeaderText="% Approvals within time limits">
                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="TotalAppliacationsApprovedbeyondTimeLimits" HeaderText="% Approvals beyond time limits">
                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Grand Total" HeaderText="Total">
                                                                <ItemStyle Width="180px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
