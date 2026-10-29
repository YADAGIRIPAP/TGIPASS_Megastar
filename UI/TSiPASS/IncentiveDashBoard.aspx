<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveDashBoard.aspx.cs" Inherits="UI_TSiPASS_RptYEARWISEPROGRESSNew" %>

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

        //        $(function () {

        //            $('#MstLftMenu').remove();

        //        });
    </script>

    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=divPrint.ClientID %>");
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



    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">R1.1 Incentive - Master Report</asp:Label>
                            &nbsp;<a id="A1" href="#"  onclick="javascript:return Panel1();"
                                                    runat="server">
                               
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>
                                            <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'">
                           
                            <tr>
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                           
                            <tr>
                                <td style="text-align: left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="left">
                                    <table width="80%">
                                        <tr runat="server" id="trBetweenDates" visible="true">
                                            <td style="padding: 5px; margin: 5px">From Date:   
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                              <%--  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">To Date:  
                                            
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                            </td>

                                             <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label352" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                data-balloon-pos="down" CssClass="LBLBLACK">District : </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="false" >
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
                            <tr>
                                <td align="left">
                                    <b>Srcutiny Stage</b>
                                </td>
                            </tr>
                            <tr id="div_Print" runat="server" style="width:900px;">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound"  OnPageIndexChanging="grdDetails_PageIndexChanging"
                                        ShowFooter="false" OnRowCreated="grdDetails_RowCreated">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" Width="120px"/>
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                             <asp:BoundField DataField="No of Units" HeaderText="No of Units" />
                                          <%--  <asp:HyperLinkField HeaderText="No of Units" DataTextField="No of Units">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>

                                            <asp:HyperLinkField HeaderText="Application received" DataTextField="Total Applications">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Scrutiny Pending Within Due Date" DataTextField="Pending Within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Scrutiny Pending Beyond Due Date" DataTextField="Pending Beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Scrutiny Pending" DataTextField="GM Pending Total">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Scrutiny Completed Within Due Date" DataTextField="Completed Within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Scrutiny Completed Beyond Due Date" DataTextField="Completed Beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Scrutiny Completed" DataTextField="GMCOMPLETEDTOTAL">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Query Raised" DataTextField="Query Raised">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Assigned for Inspection" DataTextField="Assigned for Inspection">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Not Required" DataTextField="Inspection Not Required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="GM Rejected" DataTextField="GMREJECTED">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField HeaderText="Approvals Required" DataTextField="Total deptl Approvals Required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals already taken by applicant" DataTextField="Deptl Approvals already taken by applicant">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Net Approvals required" DataTextField="Net Approvals required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <%--<asp:HyperLinkField HeaderText="Approvals Applied by applicant" DataTextField="Deptl Approvals Applied by applicant">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Query Raised" DataTextField="Query Raised">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals Pending" DataTextField="Deptl Approvals Pending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals Issued" DataTextField="Deptl Approvals Issued">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField Visible="false" HeaderText="TS-iPASS Approvals" DataTextField="TS-iPASS Approvals">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>Inspection Stage</b>
                                </td>
                            </tr>
                            <tr id="Tr1" runat="server">
                                <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="gvLevel2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="gvLevel2_RowDataBound" 
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Width="120px" Height="40px"  />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                            <asp:HyperLinkField HeaderText="Inspections not Yet Scheduled" DataTextField="Inspections not Yet Scheduled" HeaderStyle-Wrap="true" HeaderStyle-Width="50px">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspections Scheduled" DataTextField="Inspections Scheduled">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspections Scheduled Within Due Date" DataTextField="Inspections Scheduled Within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspections Scheduled Beyond Due Date" DataTextField="Inspections Scheduled Beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%-- <asp:HyperLinkField HeaderText="Total Inspected" DataTextField="Total Inspected">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Pending Within" DataTextField="Inspection Upload Pending Within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Pending Beyond" DataTextField="Inspection Upload Pending Beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Total Pending" DataTextField="Inspection Upload Total Pending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Within" DataTextField="Inspection Upload Within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Beyond" DataTextField="Inspection Upload Beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Inspections Uploaded" DataTextField="Total Upload">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Query Raised-Pending" DataTextField="Inspection Upload Total Query">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField HeaderText="Approvals Required" DataTextField="Total deptl Approvals Required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals already taken by applicant" DataTextField="Deptl Approvals already taken by applicant">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Net Approvals required" DataTextField="Net Approvals required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <%--<asp:HyperLinkField HeaderText="Approvals Applied by applicant" DataTextField="Deptl Approvals Applied by applicant">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Query Raised" DataTextField="Query Raised">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals Pending" DataTextField="Deptl Approvals Pending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals Issued" DataTextField="Deptl Approvals Issued">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField Visible="false" HeaderText="TS-iPASS Approvals" DataTextField="TS-iPASS Approvals">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>Referral Stage</b>
                                </td>
                            </tr>
                            <tr id="Tr2" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="gvLevel3" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                                        ShowFooter="false" OnRowDataBound="gvLevel3_RowDataBound">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                            <asp:HyperLinkField HeaderText="Pending to be Referred" DataTextField="Pending to be Reffered">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Referred to DIPC" DataTextField="Reffered to DIPC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Referred to COI Within Time" DataTextField="Referred to COI Within Time">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Referred to COI Beyond Time" DataTextField="Referred to COI Beyond Time">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Referred to COI" DataTextField="Total Reffered to COI">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Query Raised" DataTextField="Query Raised">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Rejected" DataTextField="Rejected GM after Insp">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField HeaderText="Pending after Insp Date" DataTextField="Pending after Inspection Date">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Within Due Date" DataTextField="Inspection Upload Within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Inspection Upload Beyond Due Date" DataTextField="Inspection Upload Beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Inspections Uploaded" DataTextField="Total Upload">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <%--<asp:HyperLinkField HeaderText="Approvals Required" DataTextField="Total deptl Approvals Required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals already taken by applicant" DataTextField="Deptl Approvals already taken by applicant">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Net Approvals required" DataTextField="Net Approvals required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <%--<asp:HyperLinkField HeaderText="Approvals Applied by applicant" DataTextField="Deptl Approvals Applied by applicant">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Query Raised" DataTextField="Query Raised">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals Pending" DataTextField="Deptl Approvals Pending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals Issued" DataTextField="Deptl Approvals Issued">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField Visible="false" HeaderText="TS-iPASS Approvals" DataTextField="TS-iPASS Approvals">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>DLC Approval Stage</b>
                                </td>
                            </tr>
                            <tr id="Tr3" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="gvLevel4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="gvLevel4_RowDataBound" 
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <%-- <asp:HyperLinkField HeaderText="Pending for Approval" DataTextField="Pending for Approval">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <asp:HyperLinkField HeaderText="DLC Approved Within" DataTextField="DLC Approved Within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="DLC Approved Beyond" DataTextField="DLC Approved Beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total DLC Approved" DataTextField="Total DLC Approved">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="DLC Pending Within" DataTextField="DLC Pending Within">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="DLC Pending Beyond" DataTextField="DLC Pending Beyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total DLC Pending" DataTextField="Total DLC Pending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                              <asp:HyperLinkField HeaderText="DLC Rejected" DataTextField="DIPCREJECTED">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-size: 16pt; font-weight: bold">
                                    <b>SLC Approval Stage</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-size: 12pt; font-weight: bold">
                                    <b>Applications at J.D Level</b>
                                </td>
                            </tr>
                            <tr id="Tr4" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                         OnRowDataBound="GridView1_RowDataBound"
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:HyperLinkField HeaderText="Total Applications Received from GM" DataTextField="No_Applns_Rcvd">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Within" DataTextField="scrutny_dne_wthn_tml">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Beyond" DataTextField="scrutny_dne_bynd_tml">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Approved" DataTextField="scrutny_dne_TOTAL">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Rejected" DataTextField="REJECTED">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Within" DataTextField="TotalPendingWithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Beyond" DataTextField="TotalPendingBeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Pending" DataTextField="TotalPending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Query Raised" DataTextField="Queries_Resp_pndg">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Abeyance Applications" DataTextField="HOLD">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr>
                                <td align="left" style="font-size: 12pt; font-weight: bold">
                                    <b>Applications at Additional Director - Pre SVC</b>
                                </td>
                            </tr>
                            <tr id="Tr5" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                         OnRowDataBound="GridView2_RowDataBound"
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:HyperLinkField HeaderText="Total Applications Received from JD" DataTextField="No_Applications_FromJd">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Within" DataTextField="pscwithincom">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Beyond" DataTextField="pscbeyondcom">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Approved" DataTextField="No_Applications_TOSVC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                           <%-- <asp:HyperLinkField HeaderText="Rejected" DataTextField="REJECTED">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <asp:HyperLinkField HeaderText="Pending Within" DataTextField="pscwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Beyond" DataTextField="pscbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Pending" DataTextField="psctotalpending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField HeaderText="Total Query Raised" DataTextField="Queries_Resp_pndg">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr>
                                <td align="left" style="font-size: 12pt; font-weight: bold">
                                    <b>Applications at Additional Director - SVC</b>
                                </td>
                            </tr>

                              <tr id="Tr6" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                       OnRowDataBound="GridView3_RowDataBound"
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:HyperLinkField HeaderText="Total Applications To SVC" DataTextField="No_Applications_TOSVC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Within" DataTextField="pscwithincomsvc">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Beyond" DataTextField="pscbeyondcomsvc">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Approved" DataTextField="NoofapplicationsrecvdSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Rejected" DataTextField="Rejectedsvc">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Within" DataTextField="TotalPendingSVCWIthin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Beyond" DataTextField="TotalPendingSVCBeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Pending" DataTextField="TotalpendingSVC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField HeaderText="Total Query Raised" DataTextField="Queries_Resp_pndg">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr>
                                <td align="left" style="font-size: 12pt; font-weight: bold">
                                    <b>Applications at Additional Director - SLC</b>
                                </td>
                            </tr>
                            <tr id="Tr7" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                         OnRowDataBound="GridView4_RowDataBound"
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:HyperLinkField HeaderText="Total Applications To SLC" DataTextField="NoofapplicationsrecvdSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Within" DataTextField="SCRwithinCOMSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Beyond" DataTextField="SCRBeyondCOMSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Approved" DataTextField="TotalApprovedSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Rejected" DataTextField="SCRRejectedCOMSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Within" DataTextField="TotalWithinPendingslc">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Beyond" DataTextField="TotalBeyondpendingslc">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Pending" DataTextField="TotalPendongSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField HeaderText="Total Query Raised" DataTextField="Queries_Resp_pndg">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>

                              <tr>
                                <td align="left" style="font-size: 12pt; font-weight: bold">
                                    <b>Overall SLC Applications Status(Time limit - 15 days from the COI recieved date)</b>
                                </td>
                            </tr>
                            <tr id="Tr8" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                         OnRowDataBound="GridView5_RowDataBound"
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                           <%-- <asp:HyperLinkField HeaderText="Total Applications To SLC" DataTextField="NoofapplicationsrecvdSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <asp:HyperLinkField HeaderText="Approved Within" DataTextField="SCRwithinCOMslcOve">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Beyond" DataTextField="SCRBeyondCOMSLCOve">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Approved" DataTextField="SCRBeyondCOMSLCOveTotal">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                           <%-- <asp:HyperLinkField HeaderText="Rejected" DataTextField="SCRRejectedCOMSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Within" DataTextField="TotalWithinPendingslc">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Pending Beyond" DataTextField="TotalBeyondpendingslc">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Pending" DataTextField="TotalPendongSLC">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField HeaderText="Total Query Raised" DataTextField="Queries_Resp_pndg">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                                <tr>
                                <td align="left" style="font-size: 12pt; font-weight: bold">
                                    <b>Overall Applications Status Sent to COI(Time limit - 15 days)</b>
                                </td>
                            </tr>
                            <tr id="Tr9" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="GridView6_RowDataBound"
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:HyperLinkField HeaderText="Sent to COI - Within" DataTextField="OveralSentToCoiwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Sent to COI - Beyond" DataTextField="OveralSentToCoibeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Sent to COI - Total" DataTextField="OveralSentToCoitOTAL">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                              <asp:HyperLinkField HeaderText="Sent to DIPC - Within" DataTextField="OveralSentToDIPCwithin">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Sent to DIPC - Beyond" DataTextField="OveralSentToDIPCbeyond">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Sent to DIPC - Total" DataTextField="OveralSentToDIPCOTAL">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
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
                                  <tr>
                                <td align="left" style="font-size: 12pt; font-weight: bold">
                                    <b>Overall Applications Status(Time limit - 30 days from Application filed to SLC Approved date)</b>
                                </td>
                            </tr>
                            <tr id="Tr10" runat="server">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                         OnRowDataBound="GridView7_RowDataBound"
                                        ShowFooter="false">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:HyperLinkField HeaderText="Approved Within" DataTextField="SCRwithinCOMslcOveApps">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approved Beyond" DataTextField="SCRBeyondCOMslcOveApps">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Approved" DataTextField="SCRCOMslcOveAppsTotal">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                            </tr>
                            <%-- <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>


