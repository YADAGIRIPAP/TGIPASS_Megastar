<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmIncentivewisesReleasepending.aspx.cs" Inherits="UI_TSIPASS_frmIncentivewisesReleasepending"  MasterPageFile="~/UI/TSIPASS/CCMaster.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            document.getElementById('<%=pdfPrint.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=grdDetailsPavallavaddiSC.ClientID %>");
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
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= grdDetailsPavallavaddiSC.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();
            var prtWindow = window.open(windowName, 'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style=”background:none !important”>');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
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

    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a> </li>
        </ol>
    </div>
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
                                  <%--  <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">1.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; text-align: left; font-weight: bold; font-size: 14pt">SC Category
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">A). Pavalla vaddi
                                        </td>
                                    </tr>--%>
                                     <tr>
                                        <td style="padding: 15px; margin: 5px;" colspan="2">
                                            <table width="100%">
                                                <tr>
                                                    <td style="vertical-align: middle; width: 200px" align="right">
                                                        <%--   Date :--%>
                                                     Financial Year :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 250px">
                                                        <asp:DropDownList runat="server" ID="ddlFinyear" class="form-control txtbox"
                                                            Height="30px" Width="240px" TabIndex="1">
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="vertical-align: middle; width: 200px" align="left" runat="server" id="tdworkstatus">
                                                        <%--   Date :--%>
                                                     SLC/DIPC :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 250px">
                                                        <asp:DropDownList runat="server" ID="ddlworkingstatus" class="form-control txtbox"
                                                            Height="30px" Width="220px" TabIndex="1">
                                                            
                                                            <asp:ListItem Value="0"  Text="SLC"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="DIPC"></asp:ListItem>
                                                           
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                 
                                                <tr>

                                                    <td style="padding: 15px; margin: 5px;" colspan="2" align="right">
                                                        <asp:Button ID="Button2" CssClass="btn btn-primary"  runat="server"
                                                            Text="Get List" Width="150px" OnClick="Button2_Click" />
                                                    </td>
                                                    <td  style="padding: 5px; text-align: right; margin: 5px" colspan="2">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                                    <td style="padding: 15px; margin: 5px;" colspan="2" align="left">
                                                             <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server"/></a>
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" />
                                <a id="pdfPrint" href="#" onclick="javascript:return printGrid();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                                </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="grdDetailsPavallavaddiSC" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="95%" CellSpacing="4"  >
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" Height="35px" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                              
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("category") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblincentiveName" runat="server" Text='<%#Eval("incentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No of Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfinYearClaims" runat="server" Text='<%#Eval("finYearClaims") %>'></asp:Label>
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
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("finYearAmtSanc") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                       
                                                       <%--     <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Total Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txttotalClaims" Text='<%#Eval("totalClaims") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>--%>
                                                       <%--  <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Total Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txttotalAmount" Text='<%#Eval("totalAmount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>--%>
                                                        
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="grdAllFinyear" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                      ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="95%" CellSpacing="4" OnRowCreated="grdAllFinyear_RowCreated">
                                                     <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                              
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("category") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblincentiveName" runat="server" Text='<%#Eval("incentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No of Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfinYearClaims" runat="server" Text='<%#Eval("finYearClaims1516") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField> 
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("finYearAmtSanc1516") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No of Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfinYearClaims" runat="server" Text='<%#Eval("finYearClaims1617") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField> 
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("finYearAmtSanc1617") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No of Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfinYearClaims" runat="server" Text='<%#Eval("finYearClaims1718") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField> 
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("finYearAmtSanc1718") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No of Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfinYearClaims" runat="server" Text='<%#Eval("finYearClaims1819") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField> 
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("finYearAmtSanc1819") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                                 <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No of Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfinYearClaims" runat="server" Text='<%#Eval("finYearClaims1920") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField> 
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("finYearAmtSanc1920") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                                       <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No of Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfinYearClaims" runat="server" Text='<%#Eval("finYearClaims2021") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField> 
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("finYearAmtSanc2021") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Total No of Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfinYearClaims" runat="server" Text='<%#Eval("totalClaims") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField> 
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Total Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("totalAmount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                       
                                                       <%--     <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Total Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txttotalClaims" Text='<%#Eval("totalClaims") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>--%>
                                                       <%--  <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Total Claims">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txttotalAmount" Text='<%#Eval("totalAmount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>--%>
                                                        
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                   
                                   <%--  <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">B). Investment Subsidy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="2">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvInvestmentSubsidySC" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                      
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button2" CssClass="btn btn-primary" OnClick="Button2_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">C). General
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvGeneralSC" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                      
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button3" CssClass="btn btn-primary" OnClick="Button3_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="2" align="center">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">2.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; text-align: left; font-weight: bold; font-size: 14pt">ST Category
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">A). Pavalla vaddi
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvPavallavaddiST" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                     
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button4" CssClass="btn btn-primary" OnClick="Button4_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">B). Investment Subsidy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvInvestmentSubsidyST" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                     
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button5" CssClass="btn btn-primary" OnClick="Button5_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">C). General
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvGeneralST" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                      
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button6" CssClass="btn btn-primary" OnClick="Button6_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">3.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; text-align: left; font-weight: bold; font-size: 14pt">General Category
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">A). Pavalla vaddi
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvPavallavaddiGeneral" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                    
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button7" CssClass="btn btn-primary" OnClick="Button7_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">B). Investment Subsidy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvInvestmentSubsidyGeneral" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                      
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button8" CssClass="btn btn-primary" OnClick="Button8_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 900px; font-weight: bold;">C). General
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                            <div style="width: 100%">
                                                <asp:GridView ID="gvGeneralGeneral" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="80%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                     
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtsanctionedamount" Text='<%#Eval("valueamount") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button9" CssClass="btn btn-primary" OnClick="Button9_Click" runat="server" Text="View" Width="150px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="masterid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("IncentiveTypID") %>'></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:HiddenField ID="hdfID" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="group" />
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="child" />
                                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        </td>
                                    </tr>--%>
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
    <%--<asp:updateprogress id="UpdateProgress" runat="server" associatedupdatepanelid="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:updateprogress>--%>
</asp:Content>


