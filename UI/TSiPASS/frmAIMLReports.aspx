<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/EmptyMaster.master" autoeventwireup="true" codefile="frmAIMLReports.aspx.cs" inherits="UI_TSiPASS_frmAIMLReports" %>

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

        .style21 {
            height: 35px;
        }

        .style26 {
            height: 21px;
        }

        .style27 {
            height: 21px;
        }

        .style34 {
            height: 21px;
            width: 261px;
        }

        .style35 {
            height: 35px;
            width: 261px;
        }

        .style36 {
            width: 261px;
        }

        .style41 {
            height: 29px;
        }

        .style42 {
            width: 261px;
            height: 29px;
        }

        .style46 {
            height: 44px;
        }

        .style47 {
            height: 44px;
            width: 261px;
        }

        .style48 {
            width: 10px;
            height: 44px;
        }

        .style49 {
            width: 206px;
            height: 44px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script language="javascript" type="text/javascript">
        function confirmMAUD() {
            if (confirm("Are you sure you want to send the record to MA & UD"))
                return true;
            return false;
        }
    </script>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                                    <li><i></i><a href="Home.aspx">Home</a></li>
            &nbsp; /
                                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
            <i></i><a href="MisreportDashboard.aspx">EoDB Reports </a>&nbsp;/
                                    <li class="active"><i></i>AI/ML dashboard</li>
        </ol>
    </div>
    <div class="panel-body">
        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
            <tr>
                <td style="height: 30px">
                    <asp:label id="Label437" runat="server" cssclass="LBLBLACK" font-bold="True" font-names="Verdana"
                        width="210px">AI/ML dashboard</asp:label>
                </td>
                <td style="height: 30px"></td>
                <td style="height: 30px"></td>
            </tr>
            <tr>
                <td align="center" style="text-align: center">
                    <asp:button id="btnPDFExtraction" runat="server" cssclass="btn btn-primary" height="91px"
                        onclick="btnPDFExtraction_Click" tabindex="10" text="PDF Extraction" validationgroup="group"
                        width="268px" font-bold="True" font-names="Verdana" font-size="18px" />
                </td>
                <td align="center" style="text-align: center">
                    <asp:button id="btnDiscrepancy" runat="server" cssclass="btn btn-danger" height="91px"
                        onclick="btnDiscrepancy_Click" tabindex="10" text="Discrepancy Report" font-bold="True"
                        width="268px" validationgroup="group" font-names="Verdana" font-size="18px" />
                </td>
                <td align="center" style="text-align: center">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="text-align: center">&nbsp;
                </td>
                <td align="center" style="text-align: center">&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="text-align: center">
                    <asp:button id="btnquery" runat="server" cssclass="btn btn-warning" height="91px"
                        tabindex="10" text="Query Report Generator" validationgroup="group" width="268px" font-bold="True"
                        font-names="Verdana" font-size="18px" onclick="btnquery_Click" />
                </td>
                <td align="center" style="text-align: center"></td>
                <td>&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:content>

