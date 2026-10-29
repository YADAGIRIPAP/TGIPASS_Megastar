<%@ Page Title="Single Window Dashboard" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="frmSingleWindowDashboard.aspx.cs" Inherits="UI_TSiPASS_frmSingleWindowDashboard" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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

    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter {
            text-align: center;
        }

        .auto-style1 {
            width: 50%;
        }

        .auto-style2 {
            width: 99%;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2020:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    minDate: new Date(2020, 11 - 1, 1)

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
            var yrRange = "2020:" + (date.getFullYear() + 1);
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
                    yearRange: yrRange,
                    minDate: new Date(2020, 11 - 1, 1)
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
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../../images/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>


    <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server">Online Single Window System Dashboard</asp:Label>&nbsp;
                                    <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'" class="auto-style1">
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">
                                            <b>
                                                <asp:Label ID="lblHeadingText" runat="server"></asp:Label></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="left">
                                            <table class="auto-style2">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">From Date:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                            Width="125px"></asp:TextBox>

                                                        <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">To Date:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                            Width="125px"></asp:TextBox>
                                                        <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                                    </td>

                                                </tr>
                                                <tr id="trDistrict" runat="server" visible="false">
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
                                                <tr align="center">
                                                    <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                        <%--<asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />--%>
                                                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                            Text="Submit" OnClick="BtnSave1_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>



                                    <tr id="div_Print" runat="server">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px;">
                                            <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False" DataKeyNames="deptid"
                                                CellPadding="4" OnRowDataBound="grdDetails_RowDataBound" Width="130%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                                ShowFooter="True">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText=" ">
                                                        <ItemTemplate>

                                                            <%--<img alt="" style="cursor: pointer; width: 40px;" src="../../images/plus.png" />--%>
                                                            <img alt="" style="cursor: pointer ; width:80px;" src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/plus.png" />
                                                            <asp:Panel ID="pnlSub" runat="server" Style="display: none">
                                                                <asp:GridView ID="gvSub" runat="server" AutoGenerateColumns="false" CssClass="floatingTable" OnRowDataBound="gvSub_RowDataBound">
                                                                    <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />

                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.NO ">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex +1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Department" HeaderText="Department" Visible="false" />
                                                                        <asp:BoundField DataField="Approval" HeaderText="Approval" />
                                                                        <asp:BoundField DataField="Timelimit" HeaderText="Time limit prescribed as per the Public Service Guarantee Act or Equivalent Act" />
                                                                        <%--   <asp:BoundField DataField="TotalApplicationsReceived" HeaderText="Total Number of Applications Received" />--%>
                                                                      <%--  <asp:TemplateField HeaderText="No Of Approvals">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="hypTotalApplications1" runat="server" Text='<%#Eval("TotalApplicationsReceived")%>'
                                                                                    NavigateUrl='<%# "~/UI/TSiPASS/CFEAllapprovalsIssuedwithFeedetails.aspx?ID=" + Eval("ApprovalID") %>'></asp:HyperLink>
                                                                                <itemstyle horizontalalign="Center" width="140px" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Total No Of Approvals Applied">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="hypTotalApplications" runat="server" Text='<%#Eval("TotalApplicationsReceived")%>' Target="_blank">
                                                                                </asp:HyperLink>
                                                                                <itemstyle horizontalalign="Center" width="140px" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Totalapplicationsprocessed" HeaderText="Total Number of applications processed" />
                                                                        <asp:BoundField DataField="Averagetimetakengrantapproval" HeaderText="Average time taken to grant approval" />
                                                                        <asp:BoundField DataField="Mediantimetakentograntapproval" HeaderText="Median time taken to grant approval" />
                                                                         <asp:BoundField DataField="Mintimetakentograntapproval" HeaderText="Minimum time taken to grant approval" />
                                                                        <asp:BoundField DataField="Maxtimetakentograntapproval" HeaderText="Maximum time taken to grant approval" />                                                                        
                                                                      
                                                                        <asp:BoundField DataField="AVERAGEFEE" HeaderText="Average Fee for Application" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldeptid" runat="server" Text='<%# Eval("deptid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.NO">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Dept_Full_name" HeaderText="Department" />
                                                    <asp:BoundField DataField="TotalApplicationsReceived" HeaderText="Total Applications Received" />
                                                    <asp:BoundField DataField="Totalapplicationsprocessed" HeaderText="Total Applications Processed" />
                                                    <%--<asp:BoundField DataField="ApprovalName" HeaderText="Approval" />--%>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                            <div id="DIVUPDATEDDATE" runat="server" class="alert alert-success">
                                                <asp:Label ID="LBLDATETEXT" runat="server" Text="The data in the dashboard is updated on a real time basis. Last update:"></asp:Label><asp:Label ID="LBLDATETIME" runat="server"></asp:Label>
                                            </div>

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

