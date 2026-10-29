<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/NewCCMaster.master" AutoEventWireup="true" CodeFile="DepartmentAbstract.aspx.cs" Inherits="FrmUsers" Title="::TS-iPASS::" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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


<%--<script type="text/javascript" src="../resources/scripts/PopUpCalenderLeft.js"></script>--%>
<div>
<br />
                        
    <asp:UpdatePanel ID="upd1" runat="server">
<ContentTemplate>

    
<div align="center">
<div class="row" align="center">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">R6: Department wise Performance</h3>
                            </div>
                            <div class="panel-body" >
                     
                    <div align="center" style="font-family: Verdana; font-size: 12px">
                        <br />
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" AutoGenerateColumns="False">
                                        <FooterStyle BackColor="#83BE00" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#E6EDF7" HorizontalAlign="Left" />
                                        <EditRowStyle BackColor="#B9D684" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#B9D684" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#83BE00" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                         <Columns>                                            
                                            <asp:BoundField HeaderText="Service" ReadOnly="True" 
                                                 Visible="False" />
                                             <asp:BoundField HeaderText="Department" >
                                                 <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                            <asp:BoundField DataField="NoofapplicationsApplied" HeaderText="Total Received" >
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>                                            
                                            
                                            <asp:BoundField DataField="Rejected" HeaderText="Rejected" >
                                              <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <table id="tbl1" runat="server" border="1" bordercolor="#54503A" 
                            style="margin: 5px; padding: 5px; color: black; width: 99%;">
                                          
                    </table>
                     <table id="Table1" runat="server" border="1" bordercolor="#54503A" style="color: black; font-family: Verdana; font-size: 12px;">
                                        
                    </table>
                    <input type="button" value="Print" width="61" height="21"onclick="PrintPage()" 
                            class="BTN_Login">
                      
                        <asp:ValidationSummary ID="vg" runat="server" ShowMessageBox="True" 
                            ShowSummary="False" ValidationGroup="group" />
                        <br />
                    </div>
               
              <asp:HiddenField ID="hdfID" runat="server" />
                                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

    </div>
               
             <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
<ProgressTemplate>
<div class="overlay">
<%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
<div style=" z-index: 1000; margin-left: -210px;margin-top:10px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />

</div>
    
</div>
</ProgressTemplate>
</asp:UpdateProgress>    
        
          
                       
  </ContentTemplate>
  </asp:UpdatePanel>                         
</div>
</asp:Content>

