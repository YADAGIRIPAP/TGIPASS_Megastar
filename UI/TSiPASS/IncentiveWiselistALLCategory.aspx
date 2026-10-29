<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" codefile="IncentiveWiselistALLCategory.aspx.cs" inherits="UI_TSiPASS_IncentiveWiselistALLCategory"  %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />

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
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
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
    <style>
        /* ===================== TOP BACK BUTTON ===================== */
        a.btn-link {
            float: right;
            font-weight: 600;
            font-size: 14px;
            color: #2563eb;
            padding: 6px 12px;
        }

            a.btn-link::before {
                content: "← ";
            }

            a.btn-link:hover {
                text-decoration: underline;
            }

        /* ===================== FILTER CONTROLS CARD LOOK ===================== */
        .input-group {
            background: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 18px rgba(0,0,0,0.08);
            overflow: hidden;
        }

        /* Label section */
        .input-group-addon,
        .input-group-text {
            background: #f1f5f9;
            font-weight: 600;
            font-size: 13px;
            color: #1e293b;
            border: none;
            padding: 8px 14px;
        }

            /* Icons */
            .input-group-addon i,
            .input-group-text i {
                color: #2563eb;
            }

        /* Inputs */
        .txtbox,
        .form-control,
        select.form-control {
            height: 40px !important;
            border-radius: 8px;
            border: 1px solid #d1d5db;
            font-size: 14px;
            transition: all 0.2s ease;
        }

            .txtbox:focus,
            .form-control:focus {
                border-color: #2563eb;
                box-shadow: 0 0 0 3px rgba(37,99,235,0.15);
            }

        /* ===================== GET LIST / CLEAR BUTTONS ===================== */
        .btn-primary {
            background: linear-gradient(135deg, #2563eb, #1e40af);
            border: none;
            border-radius: 14px;
            padding: 8px 30px;
            font-weight: 600;
            transition: all 0.2s ease;
        }

            .btn-primary:hover {
                transform: translateY(-1px);
                box-shadow: 0 8px 22px rgba(37,99,235,0.35);
            }

        /* ===================== GRID VIEW MODERNIZATION ===================== */
        .GRD {
            width: 100% !important;
            border-radius: 16px;
            border: none;
            box-shadow: 0 10px 28px rgba(0,0,0,0.08);
            overflow: hidden;
        }

        /* Header */
        .GRDHEADER {
            background: linear-gradient(135deg, #16a34a, #15803d) !important;
            color: #ffffff !important;
            font-size: 13px;
            font-weight: 700;
            padding: 12px;
            border: none !important;
        }

        /* Rows */
        .GRDITEM {
            font-size: 13px;
            padding: 10px;
            border-bottom: 1px solid #e5e7eb;
        }

        /* Zebra */
        .GRD tr:nth-child(even) td {
            background-color: #f8fafc;
        }

        /* Hover */
        .GRD tr:hover td {
            background-color: #e0f2fe;
        }

        /* ===================== GRID VIEW BUTTON ===================== */
        .GRD .btn {
            background: linear-gradient(135deg, #2563eb, #1e40af);
            border-radius: 20px;
            padding: 4px 18px;
            font-size: 12px;
        }

        /* ===================== PRINT BUTTON ===================== */
        .btn-warning {
            background: linear-gradient(135deg, #f59e0b, #d97706);
            border: none;
            border-radius: 20px;
            color: #ffffff;
            padding: 6px 24px;
        }

        /* ===================== LAYOUT VISUAL FIX (NO HTML CHANGE) ===================== */
        table > tbody > tr:first-child td {
            padding-bottom: 10px;
        }

        /* Space between filters and buttons */
        table > tbody > tr:nth-child(2) td {
            padding-top: 15px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>


    <link href="assets/css/basic.css" rel="stylesheet" />
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
                <%--<div class="panel panel-primary">
                        <div class="panel-heading" align="center">
                            <h3 class="panel-title">Departments</h3>
                        </div>--%>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large"><asp:Label ID="lblHeading" runat="server">List of cases sanctioned incentives </asp:Label></h1>
                            </div>

                            <div class="panel-body">
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;" colspan="2">
                                            <table width="100%">
                                                <tr>

                                                    <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">
                                                                <span class="input-group-text">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>From Date
                                                            </div>

                                                            <asp:textbox id="txtFromDate" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group"
                                                                width="125px">
                                                            </asp:textbox>

                                                            <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
         </cc1:CalendarExtender>--%>
                                                        </div>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">
                                                                <span class="input-group-text">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>To Date
                                                            </div>
                                                            <asp:textbox id="txtTodate" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group"
                                                                width="125px">
                                                            </asp:textbox>
                                                            <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
         </cc1:CalendarExtender>--%>
                                                        </div>
                                                    </td>
                                                    <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">
                                                                Type of Enterprise
                                                            </div>
                                                            <asp:dropdownlist id="ddlEnterPriseType" runat="server" class="form-control txtbox" onselectedindexchanged="ddlEnterPriseType_SelectedIndexChanged" autopostback="true"
                                                                width="180px">
                                                                <asp:listitem value="0">--Select--</asp:listitem>

                                                                <asp:listitem value="1">Micro</asp:listitem>
                                                                <asp:listitem value="2">Small</asp:listitem>
                                                                <asp:listitem value="3">Medium</asp:listitem>
                                                                <asp:listitem value="4">Large</asp:listitem>
                                                                <asp:listitem value="5">Mega</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </div>
                                                    </td>
                                                    <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                        <asp:hyperlink cssclass="btn btn-link" id="HyperLink1" runat="server" navigateurl="~/UI/TSiPASS/SPLCSDASHBOARD.aspx"
                                                            text="Back">
                                                        </asp:hyperlink>
                                                    </td>
                                                    <td><a id="A1" href="#" onserverclick="BtnSave2_Click" runat="server">
    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
        alt="Excel" /></a></td>
                                                     <tr>
     <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
          <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
     </td>
 </tr>
                                                </tr>
                                                <tr>

                                                    <td style="padding: 15px; margin: 5px; width: 50px;" colspan="1" align="right">
                                                        <asp:button id="Button2" cssclass="btn btn-primary" onclick="Button2_Click" runat="server"
                                                            text="Get List" width="150px" />
                                                    </td>
                                                    <td style="padding: 15px; margin: 5px; width: 50px;" colspan="1" align="right">
                                                        <asp:button id="Button3" cssclass="btn btn-primary" runat="server"
                                                            text="Clear" width="150px" onclick="Button3_Click" />
                                                    </td>


                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                        <%--<td style="padding: 15px; margin: 5px;"></td>--%>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top"  id="divPrint1" runat="server">
                                            <div id="divprint" runat="server">

                                                <div style="width: 100%">
                                                    <asp:Panel ID="pnlExport" runat="server">
                                                    <asp:gridview id="grdDetailsPavallavaddiSC" runat="server" autogeneratecolumns="False" cellpadding="4"
                                                        cssclass="GRD" forecolor="#333333" height="62px"
                                                        pagesize="15" showfooter="false" width="95%" cellspacing="4" onrowdatabound="grdDetailsPavallavaddiSC_RowDataBound">
                                                        <footerstyle backcolor="#be8c2f" font-bold="True" forecolor="White" />
                                                        <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" verticalalign="Middle" height="35px" />
                                                        <columns>
                                                            <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                <itemtemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                    <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                    <asp:hiddenfield id="HdfDeptid" runat="server" />
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle width="50px" />
                                                            </asp:templatefield>
                                                            <asp:templatefield headerstyle-horizontalalign="Left" headertext="Category">
                                                                <itemtemplate>
                                                                    <asp:label id="lblCategory" runat="server" text='<%#Eval("Category") %>'></asp:label>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" width="80px" />
                                                            </asp:templatefield>

                                                            <asp:templatefield headerstyle-horizontalalign="Left" headertext="Incentive Name">
                                                                <itemtemplate>
                                                                    <asp:label id="lblince" runat="server" text='<%#Eval("IncentiveName") %>'></asp:label>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" width="400px" />
                                                            </asp:templatefield>
                                                            <asp:templatefield headerstyle-horizontalalign="Left" headertext="Count">
                                                                <itemtemplate>
                                                                    <asp:label id="hSLCNumber" runat="server" text='<%#Eval("Noincentives") %>'></asp:label>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" />
                                                            </asp:templatefield>
                                                            <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sactionned Amount">
                                                                <ItemTemplate>
                                                                    <asp:label ID="Label1" runat="server" Text='<%#Eval("valueamount") %>'></asp:label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>--%>
                                                            <asp:templatefield headerstyle-horizontalalign="Left" headertext="Sanctioned Amount">
                                                                <itemtemplate>
                                                                    <asp:label id="txtsanctionedamount" text='<%#Eval("PendingAmount") %>' runat="server"></asp:label>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" />
                                                            </asp:templatefield>
                                                            <asp:templatefield headertext="View">
                                                                <itemtemplate>
                                                                    <asp:button id="Button1" height="25px" cssclass="btn btn-primary" onclick="Button1_Click" runat="server" text="View" width="100px" />
                                                                </itemtemplate>
                                                            </asp:templatefield>
                                                            <asp:templatefield headerstyle-horizontalalign="Left" headertext="masterid" visible="false">
                                                                <itemtemplate>
                                                                    <asp:label id="Label3" runat="server" text='<%#Eval("IncentiveTypID") %>'></asp:label>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" />
                                                            </asp:templatefield>
                                                            <asp:templatefield headerstyle-horizontalalign="Left" headertext="Category1" visible="false">
                                                                <itemtemplate>
                                                                    <asp:label id="lblCategory1" runat="server" text='<%#Eval("Category1") %>'></asp:label>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" />
                                                            </asp:templatefield>
                                                            <asp:templatefield headerstyle-horizontalalign="Left" visible="false">
                                                                <itemtemplate>
                                                                    <asp:label id="lblSubIncType" runat="server" text='<%#Eval("IncSubTypeId") %>'></asp:label>
                                                                </itemtemplate>
                                                                <headerstyle horizontalalign="Left" />
                                                            </asp:templatefield>
                                                        </columns>
                                                        <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                        <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                        <headerstyle backcolor="#1d9a5b" cssclass="GRDHEADER" font-bold="True" forecolor="White" />
                                                        <editrowstyle backcolor="#B9D684" />
                                                        <alternatingrowstyle backcolor="White" />
                                                    </asp:gridview>
                                                        </asp:Panel>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </div>

                            <%--   </div>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;</td>
                    </tr>

                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
                    </tr>

                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:label id="lblmsg0" runat="server"></asp:label>
                            </div>
                        </td>
                    </tr>

                </table>
            </div>

        </div>
    </div>


    <div style="text-align: center" id="divbtnprint" runat="server">
        <asp:button id="btnprint" runat="server" height="32px" causesvalidation="False" width="90px"
            cssclass="btn btn-warning" usesubmitbehavior="False" text="Print " onclientclick="javascript:CallPrint('divprint');return false;" />
        <br />
        <br />
    </div>

    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
</asp:content>

