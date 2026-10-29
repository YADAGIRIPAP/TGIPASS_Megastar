<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DepartmentAbstractLatestREN.aspx.cs" Inherits="UI_TSiPASS_DepartmentAbstractLatestREN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript">


function isValidDate(dateStr) {
// Checks for the following valid date formats:
// MM/DD/YY   MM/DD/YYYY   MM-DD-YY   MM-DD-YYYY
// Also separates date into month, day, and year variables

//var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{2}|\d{4})$/;
var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{4})$/;

// To require a 4 digit year entry, use this line instead:
// var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{4})$/;

var matchArray = dateStr.match(datePat); // is the format ok?
if (matchArray == null) {
alert("Date is not in a valid format.")
return false;
}
day = matchArray[1]; // parse date into variables
month = matchArray[3];
year = matchArray[4];
if (month < 1 || month > 12) { // check month range
alert("Month must be between 1 and 12.");
return false;
}
if (day < 1 || day > 31) {
alert("Day must be between 1 and 31.");
return false;
}
if ((month==4 || month==6 || month==9 || month==11) && day==31) {
alert("Month "+month+" doesn't have 31 days!")
return false
}
if (month == 2) { // check for february 29th
var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
if (day>29 || (day==29 && !isleap)) {
alert("February " + year + " doesn't have " + day + " days!");
return false;
   }
}

var sekhDate = new Date();
sekhDate.setFullYear(year,month-1,day);
var sekhToday = new Date();

if(sekhDate > sekhToday)
{
alert("Chalana Date is Greater than Current Date");
return false;
}

return true;  // date is valid


}

 function CheckFromDate()
    {
    var vdate = isValidDate(document.getElementById("ctl00_ContentPlaceHolder1_txtFrom").value);
        
        if(vdate == false)
        {
        alert("Enter a Valid Date");
        return false;
        }
         //document.forms[0].submit();
     } 
     function CheckToDate()
    {
    var vdate = isValidDate(document.getElementById("ctl00_ContentPlaceHolder1_txtTo").value);
        
        if(vdate == false)
        {
        alert("Enter a Valid Date");
        return false;
        }
         //document.forms[0].submit();
     }     
//  End -->
</script>--%>

    <script language="javascript" type="text/javascript">

        function PrintPage() {
            window.print()
        }
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
                alert(textstr + " is not in a valid format.(yyyy-mm-dd)")
                return false;
            }
            var matchArray1 = ActualStartDate.match(datePat); // is the format ok?
            if (matchArray1 == null) {
                alert(textstr1 + " is not in a valid format.(yyyy-mm-dd)")
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

    <style>
        .GridviewScrollC1Header TH, .GridviewScrollC1Header TD {
            padding: 5px;
            font-weight: normal;
            white-space: nowrap;
            border-left: 1px solid #F0F0F0;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #009688;
            color: #FFFFFF;
            text-align: center;
            vertical-align: bottom;
        }

        .GridviewScrollC1HeaderWrap TH, .GridviewScrollC1HeaderWrap TD {
            padding: 5px;
            font-weight: normal; /*white-space: nowrap;*/
            border-left: 1px solid #F0F0F0;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #009688;
            color: #FFFFFF;
            text-align: center;
            vertical-align: bottom;
        }

        .GridviewScrollC1Item TD {
            padding: 5px; /* white-space: nowrap;*/
            border-left: 1px solid #F0F0F0;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #FFFFFF;
        }

        .GridviewScrollC1Item2 TD {
            padding: 5px; /* white-space: nowrap;*/
            border-left: 1px solid #E5E5E5;
            border-right: 1px solid #E5E5E5;
            border-bottom: 1px solid #E5E5E5;
            background-color: #FAFAFA;
        }

        .GridviewScrollC1Pager {
            border-top: 1px solid #AAAAAA;
            background-color: #FFFFFF;
        }

            .GridviewScrollC1Pager TD {
                padding-top: 3px;
                font-size: 14px;
                padding-left: 5px;
                padding-right: 5px;
            }

            .GridviewScrollC1Pager A {
                color: #666666;
            }

            .GridviewScrollC1Pager SPAN {
                font-size: 16px;
                font-weight: bold;
            }
    </style>
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
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=pdfPrint.ClientID %>').style.display = "none";
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
    <%--<script type="text/javascript" src="../resources/scripts/PopUpCalenderLeft.js"></script>--%>
    <div>
        <br />
        <div class="panel panel-primary">
            <div class="panel-heading" style="text-align: center" align="center">
                <h3 class="panel-title" style="font-family: Verdana; font-size: 16px">RENEWAL : Department wise performance Tracker
                      <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                          runat="server">
                          <%--<img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                              alt="PDF" />--%></a>
                    <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                            alt="Excel" /></a>
                            <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                </h3>
                <p class="panel-title" style="font-family: Verdana; font-size: 16px">
                    <asp:Button ID="BtnSave1" runat="server" BackColor="#9F4F87" CssClass="BUTTON" ForeColor="White"
                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Send SMS" ValidationGroup="group"
                        Width="90px" />
                </p>
                <asp:HiddenField ID="hdfsms" runat="server" />
            </div>
            <div class="panel-body">
                <div align="center" style="font-family: Helvetica Neue,Helvetica,Arial,sans-serif; font-size: 14px">
                    <br />
                    <table align="center" cellpadding="10" cellspacing="5" style="width: 100%; font-family: 'Trebuchet MS'">
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
                                              <%--  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                            </div>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">

                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    To Date
                                                </div>
                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
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
                        <tr style="height: 30px">

                            <td align="right">
                                <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>

                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    OnRowDataBound="grdDetails_RowDataBound" Width="100%"
                                    ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                    <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                                <%-- <asp:Label ID="lblyear" runat="server" Text='<%# Eval("YEAR") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("MonthCode") %>' Visible="false"></asp:Label>--%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Department Name" HeaderText="Department Name"></asp:BoundField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Approvals Applied"
                                            DataTextField="NoofapplicationsApplied">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised"
                                            DataTextField="QueryRaised">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Before Due Date"
                                            DataTextField="Pending Less than 3 Days">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="After Due Date"
                                            DataTextField="Pending More than 3 Days">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pre-Scrutiny-Completed & Payment Pending"
                                            DataTextField="Number of payment received for">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pre-Scrutiny-Completed"
                                            DataTextField="Completed">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Before Due Date"
                                            DataTextField="CompletedWithinDays">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="After Due Date"
                                            DataTextField="CompletedBeyondDays">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Department-Approved"
                                            DataTextField="Approved">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Rejected"
                                            DataTextField="Rejected">
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
                    <br />
                    <%--   <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
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
                    </asp:GridView>--%>
                    <table id="tbl1" runat="server" border="1" bordercolor="#E5E5E5" style="margin: 3px; padding: 5px; color: black; width: 99%;">
                    </table>
                    <table id="Table1" runat="server" border="1" bordercolor="#E5E5E5" style="color: black; font-family: Verdana; font-size: 12px;">
                        <tr id="divExport" visible="false" runat="server">
                            <td align="center" style="text-align: center;" valign="top">
                                <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="true" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            HeaderText="S.No">
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

                    <asp:ValidationSummary ID="vg" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="group" />
                    <br />
                </div>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
