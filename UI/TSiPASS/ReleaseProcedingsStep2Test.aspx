<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="ReleaseProcedingsStep2Test.aspx.cs" inherits="UI_TSiPASS_ReleaseProcedingsStep2Test" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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

    <link href="assets/css/basic.css" rel="stylesheet" />

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a>
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
                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading">List of cases sanctioned incentives
                                </h1>
                            </div>
                            <div class="panel-body">
                                <table style="width: 100%" id="Table1" runat="server">
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:hyperlink id="HyperLink1" cssclass="btn btn-primary" height="40px" tabindex="10" text="BACK" width="120px" runat="server" navigateurl="~/UI/TSiPASS/IncentiveProceedingsStep1.aspx?Stg=5"></asp:hyperlink>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:button id="Button1" runat="server" cssclass="btn btn-primary" height="40px"
                                                        tabindex="10" text="PRINT" width="111px" onclientclick="javascript:Panel1()" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <%--<div class="col-md-12">
                                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1">
                                                </h1>
                                            </div>--%>
                                            <div class="panel-body">
                                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td colspan="4" align="left">
                                                            <asp:checkbox id="chkIsSpecialUnit" font-size="Medium" font-bold="true" runat="server"
                                                                text="Is Special Release Units" oncheckedchanged="chkIsSpecialUnit_CheckedChanged"
                                                                autopostback="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="panel-body">
                                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                                                <tr id="tblspecialcasesSearch" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; font-weight: bold" valign="top">
                                                                        <table style="width: 100%">
                                                                            <tr>
                                                                                <td style="width: 20%">District
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                    <asp:dropdownlist id="ddlDist" runat="server" class="form-control txtbox" height="33px"
                                                                                        width="180px">
                                                                                        <asp:listitem>--Select--</asp:listitem>
                                                                                    </asp:dropdownlist>
                                                                                </td>
                                                                                <td style="width: 20%">SLC Number
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                    <asp:dropdownlist id="ddlSLCNo" runat="server" class="form-control txtbox" height="33px">
                                                                                        <asp:listitem>--Select--</asp:listitem>
                                                                                    </asp:dropdownlist>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Unit Name
                                                                                </td>
                                                                                <td>
                                                                                    <asp:textbox id="txtUnitName" runat="server" class="form-control txtbox" height="28px"
                                                                                        maxlength="350" tabindex="0" tooltip="text" validationgroup="group" width="300px">
                                                                                    </asp:textbox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" style="text-align: center">
                                                                                    <asp:button id="btnGet" runat="server" cssclass="btn btn-primary" height="32px" tabindex="10"
                                                                                        text="GET Unit Details" width="200px" validationgroup="group" onclick="btnGet_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trlblmsg" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; height: 10px; font-weight: bold">No Records Found
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr1" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; height: 10px; font-weight: bold">Please Select Special Case Units
                                                                    </td>
                                                                </tr>
                                                                <tr id="trsearchresult" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                                                        <div id="Div2" style="width: 100%" runat="server">
                                                                            <asp:gridview id="gvData2" runat="server" autogeneratecolumns="false" cellpadding="4"
                                                                                cssclass="GRD" forecolor="#333333" height="62px" pagesize="15" showfooter="True"
                                                                                width="100%" cellspacing="4" onrowdatabound="gvData2_RowDataBound" emptydatatext="No Results Found">

                                                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" verticalalign="Middle" />
                                                                                <columns>
                                                                                    <asp:templatefield headertext="Select">
                                                                                        <itemtemplate>
                                                                                            <asp:checkbox runat="server" id="chkSameUnit" text="" autopostback="true" oncheckedchanged="ChckedChanged" />
                                                                                        </itemtemplate>
                                                                                        <itemstyle horizontalalign="Left" />
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No.">
                                                                                        <itemtemplate>
                                                                                            <%# Container.DataItemIndex + 1%>
                                                                                        </itemtemplate>
                                                                                        <headerstyle horizontalalign="Center" />
                                                                                        <itemstyle width="50px" />
                                                                                    </asp:templatefield>
                                                                                    <asp:boundfield datafield="NameofUnit" headertext="Name of Unit" />
                                                                                    <asp:boundfield datafield="Address" headertext="Address" />
                                                                                    <asp:boundfield datafield="DCP" headertext="DCP" />
                                                                                    <asp:boundfield datafield="SanctionedAmount" headertext="Sanctioned Amount" />
                                                                                    <asp:boundfield datafield="SanctionedDate" headertext="Sanctioned Date" />
                                                                                    <%--<asp:BoundField DataField="AllotedAmount" HeaderText="Alloted Amount" />--%>
                                                                                    <asp:templatefield headertext="Alloted Amount">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblAllotedAmount" text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="Masterincentiveid" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblMstIncentiveId" text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="Incentiveid" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblIncentiveID" text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="SLCNumer" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblSLCNumer" text='<%#Eval("SLCNumer") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="MobileNo" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblUnitMObileNo" text='<%#Eval("UnitMObileNo") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="Applicationno" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblApplicationno" text='<%#Eval("Applicationno") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="ApplicantName" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblApplicantName" text='<%#Eval("ApplicantName") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:hyperlink id="anchortaglinkAdd" runat="server" text="ADD" font-bold="true" forecolor="Green"
                                                                                                target="_blank" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                </columns>
                                                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                                                <emptydatarowstyle horizontalalign="Center" verticalalign="Middle" />
                                                                                <headerstyle backcolor="#1d9a5b" cssclass="GRDHEADER" font-bold="True" forecolor="White" />
                                                                                <editrowstyle backcolor="#B9D684" />
                                                                                <alternatingrowstyle backcolor="White" />
                                                                            </asp:gridview>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table align="left" cellpadding="10" cellspacing="5" style="width: 100%" id="tblselectedcases"
                                                                runat="server" visible="false">
                                                                <tr id="tr2" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; height: 10px; font-weight: bold">Selected Special Case Units
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                                                        <div id="Div1" style="width: 100%" runat="server">
                                                                            <asp:gridview id="GridView1" runat="server" autogeneratecolumns="false" cellpadding="4"
                                                                                cssclass="GRD" forecolor="#333333" height="62px" pagesize="15" showfooter="false"
                                                                                width="100%" cellspacing="4" onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting">
                                                                                <footerstyle backcolor="#be8c2f" font-bold="True" forecolor="White" />
                                                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" verticalalign="Middle" />
                                                                                <columns>
                                                                                    <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No.">
                                                                                        <itemtemplate>
                                                                                            <%# Container.DataItemIndex + 1%>
                                                                                        </itemtemplate>
                                                                                        <headerstyle horizontalalign="Center" />
                                                                                        <itemstyle width="50px" />
                                                                                    </asp:templatefield>
                                                                                    <asp:boundfield datafield="NameofUnit" headertext="Name of Unit" />
                                                                                    <asp:boundfield datafield="Address" headertext="Address" />
                                                                                    <asp:boundfield datafield="DCP" headertext="DCP" />
                                                                                    <asp:boundfield datafield="SanctionedAmount" headertext="Sanctioned Amount" />
                                                                                    <asp:boundfield datafield="SanctionedDate" headertext="Sanctioned Date" />
                                                                                    <%--<asp:BoundField DataField="AllotedAmount" HeaderText="Alloted Amount" />--%>
                                                                                    <asp:templatefield headertext="Alloted Amount">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="Label1" text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="Masterincentiveid" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="Label2" text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="Incentiveid" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="Label3" text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="SLCNumer" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="Label4" text='<%#Eval("SLCNumer") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="MobileNo" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblUnitMObileNo" text='<%#Eval("UnitMObileNo") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="Applicationno" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblApplicationno" text='<%#Eval("Applicationno") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="ApplicantName" visible="false">
                                                                                        <itemtemplate>
                                                                                            <asp:label id="lblApplicantName" text='<%#Eval("ApplicantName") %>' runat="server" />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                    <asp:templatefield headertext="">
                                                                                        <itemtemplate>
                                                                                            <asp:linkbutton id="anchortaglinkDelete" runat="server" text="DELETE" font-bold="true"
                                                                                                forecolor="Green" commandname="delete" commandargument='<%#Eval("EnterperIncentiveID") %>' />
                                                                                        </itemtemplate>
                                                                                    </asp:templatefield>
                                                                                </columns>
                                                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                                                <headerstyle backcolor="#1d9a5b" cssclass="GRDHEADER" font-bold="True" forecolor="White" />
                                                                                <editrowstyle backcolor="#B9D684" />
                                                                                <alternatingrowstyle backcolor="White" />
                                                                            </asp:gridview>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trRemainingAmount2" runat="server" visible="false">
                                        <td colspan="12" style="padding: 5px; margin: 5px; font-weight: bold" align="left"
                                            class="style7">&nbsp;&nbsp;&nbsp; Remaning Amount :
                                            <asp:label id="lblremaingAmount2" runat="server"></asp:label>
                                        </td>
                                    </tr>
                                    <%--  <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>--%>
                                    <tr id="trprint" runat="server" visible="false">
                                        <td colspan="3" style="padding: 5px; margin: 5px" align="center" class="style7" id="tblselection"
                                            runat="server">
                                            <br />
                                            <asp:button id="btnNext" runat="server" visible="false" cssclass="btn btn-primary"
                                                height="32px" tabindex="10" text="NEXT" width="120px" onclick="btnNext_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%" id="tblmain"
                                    runat="server" visible="true">

                                    <tr id="trno" runat="server">
                                        <td style="padding: 5px; margin: 5px; color: blue; font-weight: bold" valign="top"
                                            colspan="12" runat="server" id="tdinvestments">List of cases sanctioned incentives
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                                            <div style="width: 100%">
                                                <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="false" cellpadding="4"
                                                    cssclass="GRD" forecolor="#333333" height="62px" pagesize="15" showfooter="false"
                                                    width="100%" cellspacing="4">
                                                    <footerstyle backcolor="#be8c2f" font-bold="True" forecolor="White" />
                                                    <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" verticalalign="Middle" />
                                                    <columns>
                                                        <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No.">
                                                            <itemtemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </itemtemplate>
                                                            <headerstyle horizontalalign="Center" />
                                                            <itemstyle width="50px" />
                                                        </asp:templatefield>
                                                        <asp:boundfield datafield="NameofUnit" headertext="Name of Unit" />
                                                        <asp:boundfield datafield="Address" headertext="Address" />
                                                        <asp:boundfield datafield="DCP" headertext="DCP" />
                                                        <asp:boundfield datafield="SanctionedAmount" itemstyle-cssclass="rowAmt" headertext="Sanctioned Amount" />
                                                        <asp:boundfield datafield="SanctionedDate" headertext="Sanctioned Date" />
                                                        <%--<asp:BoundField DataField="AllotedAmount" HeaderText="Alloted Amount" />--%>
                                                        <asp:templatefield headertext="Alloted Amount">
                                                            <itemtemplate>
                                                                <asp:label id="lblAllotedAmount" text='<%#Eval("AllotedAmount") %>' cssclass="rowAmt" runat="server" />
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <asp:templatefield headertext="Masterincentiveid" visible="false">
                                                            <itemtemplate>
                                                                <asp:label id="lblMstIncentiveId" text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <asp:templatefield headertext="Incentiveid" visible="false">
                                                            <itemtemplate>
                                                                <asp:label id="lblIncentiveID" text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <asp:templatefield headertext="SLCNumer" visible="true">
                                                            <itemtemplate>
                                                                <asp:label id="lblSLCNumer" text='<%#Eval("SLCNumer") %>' runat="server" />
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <asp:templatefield headertext="MobileNo" visible="false">
                                                            <itemtemplate>
                                                                <asp:label id="lblUnitMObileNo" text='<%#Eval("UnitMObileNo") %>' runat="server" />
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <asp:templatefield headertext="Applicationno" visible="false">
                                                            <itemtemplate>
                                                                <asp:label id="lblApplicationno" text='<%#Eval("Applicationno") %>' runat="server" />
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                        <asp:templatefield headertext="ApplicantName" visible="false">
                                                            <itemtemplate>
                                                                <asp:label id="lblApplicantName" text='<%#Eval("ApplicantName") %>' runat="server" />
                                                            </itemtemplate>
                                                        </asp:templatefield>
                                                    </columns>
                                                    <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                    <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                    <headerstyle backcolor="#1d9a5b" cssclass="GRDHEADER" font-bold="True" forecolor="White" />
                                                    <editrowstyle backcolor="#B9D684" />
                                                    <alternatingrowstyle backcolor="White" />
                                                </asp:gridview>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12" style="padding: 5px; margin: 5px; font-weight: bold" align="left"
                                            class="style7">&nbsp;&nbsp;&nbsp; Remaning Amount :
                                            <asp:label id="lblremaingAmount" runat="server"></asp:label>
                                        </td>
                                    </tr>
                                    <%--     <tr style="height: 30px" id="tradditional" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold; width: 10px">1.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">G.O No. </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td>
                                            <asp:TextBox ID="txtGoNo" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox></td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">2.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">G.O Date
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox runat="server" ID="txtGodate" class="form-control txtbox" Height="28px"
                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 30px" id="tr1" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">3.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">LOC No. </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td>
                                            <asp:TextBox ID="txtLocno" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox></td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">4.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">LOC Date
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox runat="server" ID="txtLocdate" class="form-control txtbox" Height="28px"
                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>--%>


                                    <tr style="height: 40px">
                                        <td colspan="12" style="padding-bottom: 10px;">
                                            <div style="margin-top: 10px;">
                                                <div style="float: left; margin-left: 20px; margin-right: 180px;">
                                                    <label style="font-weight: bold; float: left">Release Proceding No.<font color="red" size="3"><font color="red">*</font></font> :</label>
                                                    <asp:textbox runat="server" id="txtRelProNo" class="form-control txtbox" height="28px" style="float: left" tabindex="1" width="150px"></asp:textbox>
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtRelProNo" errormessage="Please Enter Release Proceding No " display="None" validationgroup="group">*</asp:requiredfieldvalidator>
                                                </div>
                                                <div style="float: left;">
                                                    <div>
                                                        <label style="font-weight: bold; float: left">Release Proceding Date <font color="red" size="3"><font color="red">*</font></font> :</label>
                                                        <asp:textbox runat="server" id="txtRelProDate" class="form-control txtbox" height="28px" style="float: left" placeholder="DD/MM/YYYY" tabindex="1" width="150px"></asp:textbox>
                                                        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtRelProDate" errormessage="Please Enter Release Proceding Date " display="None" validationgroup="group">*</asp:requiredfieldvalidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>

                                    <tr style="height: 30px">
                                        <td>
                                            <div style="float: left; margin-top: 5px; margin-left: 20px;">
                                                <label style="font-weight: bold">
                                                    Upload Release Proceding Copy :</label>
                                            </div>
                                            <div style="float: left">
                                                <asp:fileupload id="fucReleaseProCopy" runat="server" class="form-control txtbox" />
                                            </div>
                                            <div style="float: left">
                                                <asp:button runat="server" text="Upload" id="bntUpload" cssclass="btn btn-primary"
                                                    style="margin-left: 12px; margin-top: 1px;" onclick="bntUpload_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:hyperlink runat="server" id="lnkReleaseCopy" target="_blank" style="margin-left: 262px;"></asp:hyperlink>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12" align="center" style="padding-top: 50px;">
                                            <asp:button id="Button3" runat="server" validationgroup="group" cssclass="btn btn-primary" height="32px"
                                                tabindex="10" text="Submit" width="100px" onclick="Button3_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12">
                                            <asp:hiddenfield id="hdfID" runat="server" />
                                            <asp:validationsummary id="ValidationSummary1" runat="server" showmessagebox="True"
                                                showsummary="False" validationgroup="group" />
                                            <asp:validationsummary id="ValidationSummary2" runat="server" showmessagebox="True"
                                                showsummary="False" validationgroup="child" />
                                            <asp:hiddenfield id="hdfFlagID" runat="server" />
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
                            <asp:hiddenfield id="HDFmsgOTP" runat="server" />
                        </td>
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
</asp:content>
