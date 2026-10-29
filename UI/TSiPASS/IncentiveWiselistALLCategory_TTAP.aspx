<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  CodeFile="IncentiveWiselistALLCategory_TTAP.aspx.cs" Inherits="UI_TSiPASS_IncentiveWiselistALLCategory_TTAP" %>

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

    <%-- <script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>--%>
    <link href="assets/css/basic.css" rel="stylesheet" />
      <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
  <style type="text/css">
      .ui-datepicker
      {
          font-size: 8pt !important;
          padding: 0.2em 0.2em 0;
          width: 250px;
          color: Black;
          z-index: 9999 !important;
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
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
    <ContentTemplate>--%>
    <%--<div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a> </li>
        </ol>
    </div>--%>
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
                                <h1 class="page-head-line" align="left" style="font-size: large">List of cases sanctioned incentives </h1>
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
                                                                From Date
                                                            </div>
                                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                Width="125px"></asp:TextBox>
                                                            <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
         </cc1:CalendarExtender>--%>
                                                        </div>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">
                                                                To Date
                                                            </div>
                                                            <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                Width="125px"></asp:TextBox>
                                                            <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
         </cc1:CalendarExtender>--%>
                                                        </div>
                                                    </td>
                                                     <td class="col-xs-3" style="padding: 5px; margin: 5px">
     <asp:hyperlink cssclass="btn btn-link" id="HyperLink1" runat="server" navigateurl="~/UI/TSiPASS/SPLCSDASHBOARD.aspx"
         text="Back">
     </asp:hyperlink>
 </td>
                                                  
                                                </tr>
                                                <tr >

                                                    <td style="padding: 15px; margin: 5px;" colspan="1" align="center">
                                                        <asp:Button ID="Button2" CssClass="btn btn-primary" OnClick="Button2_Click" runat="server"
                                                            Text="Get List" Width="150px" />
                                                    </td>
                                                    <td style="padding: 15px; margin: 5px;" colspan="1" align="center">
                                                        <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server"
                                                            Text="Clear" Width="150px" OnClick="Button3_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div id="divprint">

                                                <div style="width: 100%">
                                                    <asp:GridView ID="grdDetailsPavallavaddiSC" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px"
                                                        PageSize="15" ShowFooter="false" Width="95%" CellSpacing="4" OnRowDataBound="grdDetailsPavallavaddiSC_RowDataBound">
                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" Height="35px" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblince" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Count">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sactionned Amount">
                                                                <ItemTemplate>
                                                                    <asp:label ID="Label1" runat="server" Text='<%#Eval("valueamount") %>'></asp:label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtsanctionedamount" Text='<%#Eval("PendingAmount") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="Button1" Height="25px" CssClass="btn btn-primary" OnClick="Button1_Click" runat="server" Text="View" Width="100px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category1" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory1" runat="server" Text='<%#Eval("CategoryId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                           
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
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


    <div style="text-align: center" id="divbtnprint" runat="server">
        <asp:Button ID="btnprint" runat="server" Height="32px" CausesValidation="False" Width="90px"
            CssClass="btn btn-warning" UseSubmitBehavior="False" Text="Print " OnClientClick="javascript:CallPrint('divprint');return false;" />
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
</asp:Content>
