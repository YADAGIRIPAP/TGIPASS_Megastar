<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="DepartmentAbstractLatestNew.aspx.cs" Inherits="FrmUsers" Title="::TS-iPASS::" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript" src="../resources/scripts/PopUpCalenderLeft.js"></script>--%>

    <script language="javascript" type="text/javascript">

        function PrintPage() {
            window.print()
        }

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>

    <script language="javascript" type="text/javascript">

        function isValidDate(dateStr, textstr) {
            // Checks for the following valid date formats:
            // MM/DD/YY   MM/DD/YYYY   MM-DD-YY   MM-DD-YYYY
            // Also separates date into month, day, and year variables

            //var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{2}|\d{4})$/;
            var datePat = /^(\d{4})(\/|-)(\d{1,2})\2(\d{1,2})$/;

            // To require a 4 digit year entry, use this line instead:
            // var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{4})$/;

            var matchArray = dateStr.match(datePat); // is the format ok?
            if (matchArray == null) {
                alert("Date is not in a valid format.")
                return false;
            }
            day = matchArray[4]; // parse date into variables
            month = matchArray[3];
            year = matchArray[1];
            if (month < 1 || month > 12) { // check month range
                alert("Month must be between 1 and 12.");
                return false;
            }
            if (day < 1 || day > 31) {
                alert("Day must be between 1 and 31.");
                return false;
            }
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
                alert("Month " + month + " doesn't have 31 days!")
                return false
            }
            if (month == 2) { // check for february 29th
                var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if (day > 29 || (day == 29 && !isleap)) {
                    alert("February " + year + " doesn't have " + day + " days!");
                    return false;
                }
            }

            var sekhDate = new Date();
            sekhDate.setFullYear(year, month - 1, day);
            var sekhToday = new Date();

            if (sekhDate > sekhToday) {
                alert(textstr + "is Greater than Current Date");
                return false;
            }

            return true;  // date is valid

        }

        function txtFrom() {
            var trdat = document.getElementById("ctl00_ContentPlaceHolder1_txtFrom").value;
            if (trdat != "" || trdat != null || trdat != '') {
                var tranDate = isValidDate(document.getElementById("ctl00_ContentPlaceHolder1_txtFrom").value, 'From Date ');
                if (tranDate == false) {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtFrom").value = '';
                    document.getElementById("ctl00_ContentPlaceHolder1_txtFrom").focus();

                    //alert("Enter a Valid Date of Appeal");

                    return false;
                }
            }
        }


        function isValidActualDate1(dateStr, textstr, dateStr1, textstr1) {
            // Checks for the following valid date formats:
            // MM/DD/YY   MM/DD/YYYY   MM-DD-YY   MM-DD-YYYY
            // Also separates date into month, day, and year variables

            //var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{2}|\d{4})$/;
            //var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{4})$/;
            var datePat = /^(\d{4})(\/|-)(\d{1,2})\2(\d{1,2})$/;


            // To require a 4 digit year entry, use this line instead:
            // var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{4})$/;
            var ActualStartDate = dateStr1;
            var matchArray = dateStr.match(datePat); // is the format ok?
            if (matchArray == null) {
                alert(textstr + " is not in a valid format.(dd-MM-yyyy)")
                return false;
            }
            var matchArray1 = ActualStartDate.match(datePat); // is the format ok?
            if (matchArray1 == null) {
                alert(textstr1 + " is not in a valid format.(dd-MM-yyyy)")
                return false;
            }
            day = matchArray[4]; // parse date into variables
            month = matchArray[3];
            year = matchArray[1];
            day1 = matchArray1[4]; // parse date into variables
            month1 = matchArray1[3];
            year1 = matchArray1[1];
            if (month1 < 1 || month1 > 12) { // check month range
                alert("Month must be between 1 and 12.");
                return false;
            }
            if (day1 < 1 || day1 > 31) {
                alert("Day must be between 1 and 31.");
                return false;
            }
            if ((month1 == 4 || month1 == 6 || month1 == 9 || month1 == 11) && day1 == 31) {
                alert("Month " + month1 + " doesn't have 31 days!")
                return false
            }
            if (month1 == 2) { // check for february 29th
                var isleap1 = (year1 % 4 == 0 && (year1 % 100 != 0 || year1 % 400 == 0));
                if (day1 > 29 || (day1 == 29 && !isleap1)) {
                    alert("February " + year1 + " doesn't have " + day1 + " days!");
                    return false;
                }
            }

            var sekhDate = new Date();
            sekhDate.setFullYear(year1, month1 - 1, day1);
            var sekhToday = new Date();

            //if(  sekhToday < sekhDate)
            //{
            //alert( textstr1 + " must be less than "+textstr);
            //return false;
            //}
            // Year Start

            if (year > year1) {
                alert(textstr1 + " is Must be greater than " + textstr);
                return false;
            }
            else if (year < year1) {
                return true;
            }
            else if (year == year1) {

                //MOnth
                if (month == month1) {
                    if (day <= day1) {
                        return true;
                    }
                    else {
                        alert(textstr1 + " is Must be greater than " + textstr);
                        return false;
                    }
                }
                else if (month < month1) {
                    return true;
                }
                else {
                    alert(textstr1 + " is Must be greater than " + textstr);
                    return false;
                }
                // MOnth
            }

            //return true;

            //Year End

        }

        function txtTo() {

            var trdat1 = document.getElementById("ctl00_ContentPlaceHolder1_txtTo").value;
            if (trdat1 != "" || trdat1 != null || trdat1 != '') {
                var tranDate1 = isValidDate(document.getElementById("ctl00_ContentPlaceHolder1_txtTo").value, 'To Date ');
                if (tranDate1 == false) {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtTo").value = '';
                    document.getElementById("ctl00_ContentPlaceHolder1_txtTo").focus();
                    return false;
                }
            }
            var trdat2 = document.getElementById("ctl00_ContentPlaceHolder1_txtTo").value;
            if (trdat2 != "" || trdat2 != null || trdat2 != '') {
                var trdat = document.getElementById("ctl00_ContentPlaceHolder1_txtFrom").value;
                if (trdat != "" || trdat != null || trdat != '') {
                    var tranDate = isValidActualDate1(document.getElementById("ctl00_ContentPlaceHolder1_txtFrom").value, 'From Date', document.getElementById("ctl00_ContentPlaceHolder1_txtTo").value, 'To Date');
                    if (tranDate == false) {
                        document.getElementById("ctl00_ContentPlaceHolder1_txtTo").focus();
                        document.getElementById("ctl00_ContentPlaceHolder1_txtTo").value = '';
                    }
                }
            }
        }
    </script>
      <script language="javascript" type="text/javascript">
          function Panel1() {
              document.getElementById('<%=Button3.ClientID %>').style.display = "none";

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
    </script>

    <style>
        .GridviewScrollC1Header TH, .GridviewScrollC1Header TD
        {
            padding: 5px;
            font-weight: normal;
            white-space: nowrap;
            border-left: 1px solid #F0F0F0;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #286090;
            color: #FFFFFF;
            text-align: center;
            vertical-align: bottom;
        }

        .GridviewScrollC1HeaderWrap TH, .GridviewScrollC1HeaderWrap TD
        {
            padding: 5px;
            font-weight: normal; /*white-space: nowrap;*/
            border-left: 1px solid #F0F0F0;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #286090;
            color: #FFFFFF;
            text-align: center;
            vertical-align: bottom;
        }

        .GridviewScrollC1Item TD
        {
            padding: 5px; /* white-space: nowrap;*/
            border-left: 1px solid #F0F0F0;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #FFFFFF;
        }

        .GridviewScrollC1Item2 TD
        {
            padding: 5px; /* white-space: nowrap;*/
            border-left: 1px solid #E5E5E5;
            border-right: 1px solid #E5E5E5;
            border-bottom: 1px solid #E5E5E5;
            background-color: #FAFAFA;
        }

        .GridviewScrollC1Pager
        {
            border-top: 1px solid #AAAAAA;
            background-color: #FFFFFF;
        }

            .GridviewScrollC1Pager TD
            {
                padding-top: 3px;
                font-size: 14px;
                padding-left: 5px;
                padding-right: 5px;
            }

            .GridviewScrollC1Pager A
            {
                color: #666666;
            }

            .GridviewScrollC1Pager SPAN
            {
                font-size: 16px;
                font-weight: bold;
            }
    </style>
    <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
    <div>
        <br />
        <div class="panel panel-primary">
            <div class="panel-heading" style="text-align: center" align="center">
                <%--   <h3 class="panel-title" style="font-family: Verdana; font-size: 16px">R5.1: Department wise performance Tracker</h3>--%>
                <h3 class="panel-title" style="font-weight: bold;">
                    <asp:Label ID="lblHeading" runat="server" Text="R5.1: Department wise performance Tracker"></asp:Label>&nbsp; &nbsp;
                       <a id="Button2" href="#"  onserverclick="BtnPDF_Click"
                           runat="server">
                           <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                               alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                   <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                       alt="Excel" /></a></h3>
                <p class="panel-title" style="font-family: Verdana; font-size: 16px">
                    <asp:Button ID="BtnSave1" runat="server" BackColor="#9F4F87" CssClass="BUTTON" ForeColor="White"
                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Send SMS" ValidationGroup="group"
                        Width="90px" />
                    <asp:HiddenField ID="hdfsms" runat="server" />
                </p>
            </div>
            <div class="panel-body">
                <div align="center" style="font-family: Helvetica Neue,Helvetica,Arial,sans-serif; font-size: 14px">
                    <br />
                    <table align="center" cellpadding="10" cellspacing="5" style="width: 100%; font-family: 'Trebuchet MS'">
                        <tr>
                            <td style="text-align: left">
                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                    Text="<< Back">
                                </asp:HyperLink>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                <table width="80%">
                                    <tr align="center">
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    From Date
                                                </div>

                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">

                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    To Date
                                                </div>
                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" align="right">
                                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                Text="Submit" OnClick="BtnSave2_Click" />
                                        </td>
                                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%-- <table>
                       
                    </table>--%>
                    <table id="tbl1" CssClass="floatingTable" runat="server" border="1" bordercolor="#E5E5E5" style="margin: 3px; padding: 5px; color: black; width: 99%;">
                    </table>
                    <table runat="server" id="divPrint" border="1" bordercolor="#E5E5E5" style="color: black; font-family: Verdana; font-size: 12px;">
                        <tr >
                            <td>
                                <asp:GridView ID="GridView1"  runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    Visible="False" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" AutoGenerateColumns="False">
                                    <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Service" ReadOnly="True" Visible="False" />
                                        <asp:BoundField HeaderText="Department">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NoofapplicationsApplied" HeaderText="Total Received">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Rejected" HeaderText="Rejected">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr id="divExport" visible="false" runat="server">
                            <td align="center" style="text-align: center;" valign="top">
                                <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="true" ShowFooter="true">

                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <RowStyle Wrap="true" />
                                </asp:GridView>
                            </td>
                        </tr>

                    </table>
                    <%-- <input type="button" value="Print" width="61" height="21" onclick="PrintPage()" class="BTN_Login">--%>
                    <%-- <asp:Button runat="server" Text="Excel" Width="61" Height="21" OnClick="BtnSave2_Click1"
                        class="BTN_Login" />--%>
                    <asp:ValidationSummary ID="vg" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="group" />
                    <br />
                </div>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />

                <div id="success" runat="server" visible="false" class="alert alert-success">
                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                </div>
                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
