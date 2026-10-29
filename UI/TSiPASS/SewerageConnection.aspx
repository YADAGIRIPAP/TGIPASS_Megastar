<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="SewerageConnection.aspx.cs" Inherits="UI_TSiPASS_SewerageConnection" %>

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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }

        .GRDHEADER {
            border: 1px solid #1d9a5b;
            color: #1d9a5b;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .LBLBLACK {
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
        function Panel1() {


            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');
            printWindow.document.write('<h3 style="width: 100%;text-align: center;">Commissionerate of Industries :: Hyderabad</h3>');
            printWindow.document.write('<center> <img src="telanganalogo.png" width="75px" height="75px" /> </center>');
            printWindow.document.write('<h4 align="left" style="font-size: Large" id="h1heading"><u><b>List of cases sanctioned incentives :</b></u></h4>');
            printWindow.document.write('</head><body style="width: 100%;text-align: center;">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
            setTimeout(function () {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;
        }
    </script>
    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Sewerage Connection</a>
            </li>
        </ol>
    </div>
    <div align="left" id="divPrint" runat="server">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading">APPLY FOR SEWERAGE CONNECTION
                                </h1>
                            </div>
                            <div class="panel-body">
                                <table style="width: 100%" id="Table1" runat="server">
                                    <tr>
                                        <%--  <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-primary" Height="40px" TabIndex="10" Text="BACK" Width="120px" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveProceedingsStep1.aspx?Stg=5"></asp:HyperLink>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="40px"
                                                        TabIndex="10" Text="PRINT" Width="111px" OnClientClick="javascript:Panel1()" />
                                        </td>--%>
                                    </tr>


                                    <tr id="trprint" runat="server" visible="false">
                                        <td colspan="3" style="padding: 5px; margin: 5px" align="center" class="style7" id="tblselection"
                                            runat="server">
                                            <br />
                                            <asp:Button ID="btnNext" runat="server" Visible="false" CssClass="btn btn-primary"
                                                Height="32px" TabIndex="10" Text="NEXT" Width="120px" />
                                        </td>
                                    </tr>
                                </table>
                                <table align="left" cellpadding="5" cellspacing="5" style="width: 100%" id="tblmain"
                                    runat="server" visible="true">


                                    <tr>
                                        <td style="width: 10%">Enter PTIN Number:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtPTINno" runat="server" class="form-control txtbox" Height="28px" OnTextChanged="txtPTINno_TextChanged" AutoPostBack="true"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>

                                        <td style="width: 10%" id="Dist" runat="server" visible="false">District:</td>
                                        <td style="width: 20%" id="Dist1" runat="server" visible="false">
                                            <asp:TextBox ID="txtPtinDistrict" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>

                                        <td style="width: 10%" id="Muncipal" runat="server" visible="false">Municipality:</td>
                                        <td style="width: 20%" id="Muncipal1" runat="server" visible="false">
                                            <asp:TextBox ID="txtPtinMuncipality" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>


                                    </tr>

                                    <tr id="PTIN" runat="server" visible="false">
                                        <td style="width: 10%">PTIN Name:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtPTINName" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%">Category:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtPtinCategory" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%">Mobile Number:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtPtinMobileno" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="10" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px" TextMode="Phone"></asp:TextBox>
                                        </td>


                                    </tr>

                                    <tr>
                                        <td style="width: 10%" id="CAN" runat="server" visible="false">Enter CAN (Water) Number: </td>
                                        <td style="width: 20%" id="CAN1" runat="server" visible="false">
                                            <asp:TextBox ID="txtCANNO" runat="server" class="form-control txtbox" Height="28px" OnTextChanged="txtCANNO_TextChanged" AutoPostBack="true"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%" id="Category2" runat="server" visible="false">CAN Owner Name:</td>
                                        <td style="width: 20%" id="Category3" runat="server" visible="false">
                                            <asp:TextBox ID="txtCanName" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%" id="Mobile2" runat="server" visible="false">Category:</td>
                                        <td style="width: 20%" id="Mobile3" runat="server" visible="false">
                                            <asp:TextBox ID="txtCanCategory" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>


                                    </tr>
                                    <tr id="NOMObile" runat="server" visible="false">
                                        <td style="width: 10%">Mobile Number: </td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanMobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="10" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px" TextMode="Phone"></asp:TextBox>
                                        </td>
                                        <%--   <td style="width: 30%">A hyperlink to be provided with the rates</td>
                                        <td style="width: 10%">
                                            <asp:HyperLink ID="hypRate" runat="server" Text="View"></asp:HyperLink>
                                        </td>--%>
                                    </tr>
                                    <br />

                                    <tr id="States" runat="server" visible="false">
                                        <td style="width: 10%">State:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanstate" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%">District:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanDistrict" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%">Mandal:  </td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanMandal" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>


                                    </tr>
                                    <br />
                                    <tr id="Post" runat="server" visible="false">
                                        <td style="width: 10%">Village/Post</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanVillage" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>

                                        <td style="width: 10%">Locality:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanLocality" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>


                                        <td style="width: 10%">Street/Ropad:  </td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanStreet" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr id="Address" runat="server" visible="false">
                                        <td style="width: 10%">Address for Correspondence:  </td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanAddress" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%">H.No:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanHNO" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%">Landmark:</td>
                                        <td style="width: 20%">
                                            <asp:TextBox ID="txtCanLandmark" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <%--  <tr>
                                        <td>
                                            <div>
                                                <asp:HyperLink runat="server" ID="lnkReleaseCopy" Target="_blank" Style="margin-left: 262px;"></asp:HyperLink>
                                            </div>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="4" align="center" style="padding-top: 50px;">
                                            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="group" CssClass="btn btn-primary" Height="32px" OnClick="btnSubmit_Click"
                                                TabIndex="10" Text="Submit" Width="100px" />
                                        </td>
                                        <td colspan="4" align="left" style="padding-top: 50px;">
                                            <asp:Button ID="btnNextPage" runat="server" ValidationGroup="group" CssClass="btn btn-warning" Height="32px" OnClick="btnNextPage_Click"
                                                TabIndex="10" Text="Next" Width="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12">
                                            <asp:HiddenField ID="hdfSWGQID" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="group" />
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="child" />
                                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7">
                            <asp:HiddenField ID="HDFmsgOTP" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <style>
        .totalCol {
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtGodate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtLocdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 
            $("input[id$='txtRelProDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {

            var totals = [0, 0];
            $("#ctl00_ContentPlaceHolder1_grdDetails").append('<tr class="totalColumn" align="left" valign="middle"><td style="width:50px;"></td><td colspan="3" style="font-weight:bold;text-align:center;">Total</td><td class="totalCol"></td><td ></td><td class="totalCol"></td><td></td></tr>')

            var $dataRows = $("#ctl00_ContentPlaceHolder1_grdDetails tr:not('.totalColumn')");

            $dataRows.each(function () {
                $(this).find('.rowAmt').each(function (i) {
                    if ($(this).html() != '') {
                        totals[i] += parseInt(parseFloat($(this).html()) * 100, 10) / 100;
                    }
                });
            });
            $("#ctl00_ContentPlaceHolder1_grdDetails td.totalCol").each(function (i) {
                // $(this).html(totals[i].toFixed(2).replace(/\d(?=(?:\d{2})+\.)/g, '$&,'));
                $(this).html(NumberToIndianRupees(totals[i].toFixed(2)));
            });



            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtGodate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtLocdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });

        function NumberToIndianRupees(x) {
            x = x.toString();
            var afterPoint = '';
            if (x.indexOf('.') > 0)
                afterPoint = x.substring(x.indexOf('.'), x.length);
            x = Math.floor(x);
            x = x.toString();
            var lastThree = x.substring(x.length - 3);
            var otherNumbers = x.substring(0, x.length - 3);
            if (otherNumbers != '')
                lastThree = ',' + lastThree;
            var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree + afterPoint;
            return res;
        }

    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }
    </style>
</asp:Content>

