<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmIndustryLoan.aspx.cs" Inherits="UI_TSiPASS_frmIndustryLoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtLoanDate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtLoanDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 1px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupTST.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>

    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 12) {
                alert("Aadhar number length must be exactly 12 characters")
            }
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <script type="text/javascript">
        var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
            [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
            [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
            [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
            [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
            [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
            [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
            [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
            [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];


        // The permutation table
        var p = [
            [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
            [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
            [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
            [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
            [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
            [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
            [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];


        // The inverse table
        var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];



        //  For a given number generates a Verhoeff digit

        //         Validates that an entered number is Verhoeff compliant.

        function validateVerhoeff() {
            //document.getElementById('txtadhar1'+'txtadhar2'+'txtadhar3').value

            var num = document.getElementById("<%=txtadhar1.ClientID %>").value + document.getElementById("<%=txtadhar2.ClientID %>").value + document.getElementById("<%=txtadhar3.ClientID %>").value;
            //alert(num);
            //alert('hi');
            var num;
            var cc;
            var c = 0;
            var myArray = StringToReversedIntArray(num);

            for (var i = 0; i < myArray.length; i++) {

                c = d[c][p[(i % 8)][myArray[i]]];

            }

            cc = c;
            if (cc == 0) {
                //alert("Valid UID");
            }
            else {

                alert("This is not Valid Aadhar Number");
                document.getElementById("<%=txtadhar1.ClientID %>").value = "";
                document.getElementById("<%=txtadhar2.ClientID %>").value = "";
                document.getElementById("<%=txtadhar3.ClientID %>").value = "";
            }
        }



        /*
         * Converts a string to a reversed integer array.
         */
        function StringToReversedIntArray(num) {

            var myArray = [num.length];

            for (var i = 0; i < num.length; i++) {

                myArray[i] = (num.substring(i, i + 1));

            }

            myArray = Reverse(myArray);


            return myArray;

        }

        /*
         * Reverses an int array
         */
        function Reverse(myArray) {

            var reversed = [myArray.length];

            for (var i = 0; i < myArray.length ; i++) {
                reversed[i] = myArray[myArray.length - (i + 1)];

            }

            return reversed;
        }

        //function ValidatePAN() {
        //    var Obj = document.getElementById("txtcontact0");
        //    if (Obj.value != "") {
        //        ObjVal = Obj.value;
        //        var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
        //        if (ObjVal.search(panPat) == -1) {
        //            alert("Invalid Pan No");
        //            Obj.focus();
        //            return false;
        //        }
        //    }
        //}
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <%--<ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx">Dashboard</a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-table"></i> Masters
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">TST Team</a>
                            </li>
                        </ol>--%>
            </div>

            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Update "Loan Applied" Details(Fresh Loan/Working Capital/Over Draft Loan/Re-Structuring Loan/LOC Loan)</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <label></label>
                                        <table align="center" id="Table1"  runat="server" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr id="cfeid" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="260px">Whether Applied for Loan to setup/Expand/Working Capital Loan</asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:RadioButtonList ID="rbtTSIPASS" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtTSIPASS_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1" Selected="True"> YES</asp:ListItem>
                                                        <asp:ListItem Value="2">NO</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table align="center" id="tbl" visible="false" runat="server" cellpadding="10" cellspacing="5" style="width: 90%">

                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;<asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Applicant Details</asp:Label></td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top" class="style6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label386" runat="server" CssClass="LBLBLACK" Width="165px">Name of the Applicant</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtEntrepreneur" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                    ControlToValidate="txtEntrepreneur" ErrorMessage="Please Enter Name of the Entrepreneur"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label385" runat="server" CssClass="LBLBLACK" Width="137px">Aadhar Number (With Consent)</asp:Label></td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                               <asp:TextBox ID="txtadhar1" autocomplete="off" TabIndex="1" onpaste="return false"
                                                                runat="server" class="textboxPge" MaxLength="4" Width="56px"></asp:TextBox>
                                                            <asp:TextBox ID="txtadhar2" autocomplete="off" TabIndex="1" onpaste="return false"
                                                                runat="server" class="textboxPge" MaxLength="4" Width="56px"></asp:TextBox>
                                                            <asp:TextBox onblur="validateVerhoeff()" autocomplete="off" TabIndex="1" ID="txtadhar3"
                                                                onpaste="return false" runat="server" class="textboxPge" MaxLength="4" Width="56px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtadhar3"
                                                                ErrorMessage="Please Enter Aadhar Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr id="trnameofunit" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="165px">Name of the Unit</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txt_Name_of_unit" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                    ControlToValidate="txt_Name_of_unit" ErrorMessage="Please Enter Name of the Unit"
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top" class="style6">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">3</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="137px">Mobile Number</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtcontact" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                    ControlToValidate="txtcontact" ErrorMessage="Please Enter Mobile Number"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                                <asp:Button ID="Button1" runat="server" CssClass="button" Height="30px" Text="Click Here to Verify Mobile No" Width="220px" OnClick="Button1_Click" ValidationGroup="group" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="width: 200px;">Please Enter OTP Recieved on your phone </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtOTPVerify" runat="server" class="form-control txtbox" Height="28px" MaxLength="6" Width="180px" AutoPostBack="true" Enabled="false" OnTextChanged="txtOTPVerify_TextChanged" ToolTip="Please enter OTP Rcvd on your phone here"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:ImageButton ID="imgid" runat="server" ImageUrl="~/images/update.png" Visible="false" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td class="style6" valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Bank Details<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td class="style6" valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="137px">Bank Name</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddl_banknames" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddl_banknames_SelectedIndexChanged" Width="180px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                                    ControlToValidate="ddltypeofloan" ErrorMessage="Please select Type of Loan"
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label444" runat="server" CssClass="LBLBLACK" Width="165px">District</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddl_disticts" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddl_disticts_SelectedIndexChanged" Width="180px">
                                                                    <asp:ListItem>--SELECT--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                                    ControlToValidate="ddl_banknames" ErrorMessage="Please select Bank Name"
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="165px">Mandal</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlmandal" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                                    <asp:ListItem>--SELECT--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                    ControlToValidate="ddl_branchnames" ErrorMessage="Please select Branch Name" InitialValue="--Select--" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="200px">Bank Brach Name<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddl_branchnames" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                    ControlToValidate="ddl_disticts" ErrorMessage="Please select District" InitialValue="--Select--" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top" class="style6">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr id="qty" runat="server" visible="true">
                                                            <td style="padding: 5px; margin: 5px">5</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="165px">Type of Loan<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddltypeofloan" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <%--<asp:ListItem Value="1">Fresh Loan</asp:ListItem>
                                                                    <asp:ListItem Value="2">Working Capital Loan</asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                    ControlToValidate="ddlmandal" ErrorMessage="Please Select Mandal" InitialValue="--Select--" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">6</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="137px">Loan Application Date</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtLoanDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="15" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                                    ControlToValidate="txtLoanDate" ErrorMessage="Please Enter Loan Application Date"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">7</td>
                                                            <td style="width: 200px;">&nbsp;Loan Amount</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtLoanAmount" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                    ControlToValidate="txtLoanAmount" ErrorMessage="Please Enter Loan Amount"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator></td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">8</td>
                                                            <td style="width: 200px;">Loan Application Number(if any)</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtloannumber" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3"
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                        Height="32px" TabIndex="10" Text="Submit"
                                                        ValidationGroup="group" Width="90px" OnClick="BtnSave1_Click" Enabled="false"/>
                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" Visible="false" />
                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3"
                                                    style="padding: 5px; margin: 5px; text-align: center;">


                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>


                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />

                                        <asp:HiddenField ID="hdfUploadFile1" runat="server" />
                                        <asp:HiddenField ID="HDFmsgOTP" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <%-- <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />--%>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>

            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />


        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

