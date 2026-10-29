<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="UpdateCheckDeatailFinal.aspx.cs" Inherits="UI_TSiPASS_UpdateCheckDeatailFinal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body style="width: 100%;text-align: center;">');
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
    <style type="text/css">
        .overlay
        {
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
        
        .CS
        {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }
        
        .update
        {
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
        
        .style7
        {
            color: #FF3300;
        }
        
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
        
        .GRD
        {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }
        
        .GRDHEADER
        {
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
        
        .GRDITEM
        {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }
        
        .LBLBLACK
        {
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
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table style="width: 100%" id="divPrint" runat="server">
                    <tr>
                        <td>

                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading">
                                </h1>
                            </div>
                             <div class="panel-heading" style="text-align: center">
                                <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">
                                    Government of Telangana</h3>
                                <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server">Pending Upload Check Details for SLC </asp:Label>
                                    <a id="Button2" href="#" onclick="javascript:return Panel1();" runat="server">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="A1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                    alt="Excel" /></a></h2>
                            </div>
                            <div class="panel-body">
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr id="trno" runat="server">
                                        <td style="padding: 5px; margin: 5px; color: blue; font-weight: bold" valign="top"
                                            colspan="12" runat="server" id="tdinvestments">
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                            <table width="50%">
                                                <tr>
                                                    <td style="vertical-align: middle; font-weight: bold; width: 200px">
                                                        1) Cheque List Date :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left; font-weight: bold">
                                                        <asp:Label runat="server" ID="txtsvcdate" Height="28px" maxlength="80" TabIndex="1"
                                                            Width="150px"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                                            <div id="Div1" style="width: 100%" runat="server">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="false" OnRowCreated="grdDetails_RowCreated"
                                                    Width="100%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkRow" runat="server" onclick="Check_Click(this)" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="120px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NameofUnitAddress" ItemStyle-HorizontalAlign="Center"
                                                            HeaderText="Name of Unit & Address">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DateofReceipt" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Receipt">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RecommendedAmount" ItemStyle-HorizontalAlign="Center"
                                                            HeaderText="Recommended Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AllotedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SanctionedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCNumer" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Numer">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="SLCDate">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="SLCDate">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEnterperIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SLCNumer" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSLCNumernor" Text='<%#Eval("SLCNumer") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Working Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" Text='<%#Eval("WorkingStatus") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAccno" Text='<%#Eval("NewAccNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBnkAccName" Text='<%#Eval("BankAccountName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAccType" Text='<%#Eval("NewAccountType") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBankName" Text='<%#Eval("NewBankName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Branch Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBranchName" Text='<%#Eval("NewBranchName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IFSC Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIFSCCode" Text='<%#Eval("NewIFSCCode") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Remarks">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl" Text='<%#Eval("BankAccountRemarks") %>' runat="server" />
                                                            </ItemTemplate>
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
                                        <td>
                                            <div id="dvSUnits" style="margin-top:15px;margin-bottom:20px;">

                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 30px">
                                        <td>
                                            <table style="width: 80%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" id="tdslcno" runat="server">
                                                        Cheque No
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtcheckNO" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" id="tdslcndate" runat="server">
                                                        Cheque Date
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox runat="server" ID="txtCheckdate" placeholder="DD/MM/YYYY" class="form-control txtbox" Height="28px"
                                                            MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" id="td1" runat="server">
                                                        Cheque Amount
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtamount" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12" style="padding: 5px; margin: 5px" align="center" class="style7"
                                            id="tblselection" runat="server">
                                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Update Check Details"
                                                OnClick="Button1_Click" OnClientClick="return checkValidation()" />
                                            <%-- <asp:button id="Button6" cssclass="btn btn-primary" runat="server" text="Download PDF" onclick="Button6_Click" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                    &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                    Warning!</strong>
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
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();


            $("input[id$='txtCheckdate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtCheckdate']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            });
        });
    </script>
    <script type="text/javascript">
        function checkValidation() {
            // return confirm('Everything ok?');

           <%-- var counter = 0;
            $("#<%=grdDetails.ClientID%> input[id*='chkRow']:checkbox").each(function (index) {
                if ($(this).is(':checked'))
                    counter++;
            });
            alert(counter);--%>
            debugger;
            var chqno = $('#ctl00_ContentPlaceHolder1_txtcheckNO').val();
            var chqdate = $('#ctl00_ContentPlaceHolder1_txtCheckdate').val();
            var chqamt = $('#ctl00_ContentPlaceHolder1_txtamount').val();
            var msg = "";
            var a = "Please Enter Cheque No \n";
            var b = "Please Enter Cheque Date \n";
            var c = "Please Enter Cheque Amount\n";

            var allcount = 0, rowcount = 0;

            $("#<%=grdDetails.ClientID%> input[id*='chkAll']:checkbox").each(function (index) {
                if ($(this).is(':checked')) allcount++;
            });
            $("#<%=grdDetails.ClientID%> input[id*='chkRow']:checkbox").each(function (index) {
                if ($(this).is(':checked')) rowcount++;
            });

            if (allcount == 0)
            {
                if (rowcount == 0) {
                    alert('Please Select Units for update check details.');
                    return false;
                }
                debugger;
                

                if (chqno == "" || chqno == undefined) { msg = a; }
                if (chqdate == "" || chqdate == undefined) { msg = b; }
                if (chqamt == "" || chqamt == undefined) { msg = c; }
                if ((chqno == "" || chqno == undefined) && (chqdate == "" || chqdate == undefined)) { msg = a + b; }
                if ((chqno == "" || chqno == undefined) && (chqamt == "" || chqamt == undefined)) { msg = a + c; }
                if ((chqamt == "" || chqamt == undefined) && (chqdate == "" || chqdate == undefined)) { msg = b + c }
                if ((chqno == "" || chqno == undefined) && (chqdate == "" || chqdate == undefined) && (chqamt == "" || chqamt == undefined)) { msg = a + b + c; }
                console.log('checking')
                console.log(chqno);
                console.log(chqamt);
                console.log(chqdate);
                console.log(msg);

                if (msg != "") {
                    alert(msg);
                    return false;
                }






                return true;
            }
            
        }


        function Check_Click(objRef) {
            var row = objRef.parentNode.parentNode;
            var trrow = $(objRef).parent().closest('tr');
            if (objRef.checked) {
                var dd = $.trim($('#dvSUnits').html()) == "" ? true : false; 
                if (dd) 
                {
                    $('#dvSUnits').html($('<div style="font-size: 16px;font-weight:bold;">Selected Units</div><table style="text-align:left" id="tblUnits" cellspacing="4" cellpadding="4" border="1" ></table>'));
                    $('#tblUnits').append('<tr><th style="padding:5px;text-align:center;">Name of Unit & Address</th><th>Sanctioned Amount</th></tr>')
                }
                var id = trrow.find('td:eq(1)').text();
                var name = trrow.find('td:eq(2)').text();
                var amt = trrow.find('td:eq(6)').text();

                $('#tblUnits').append('<tr data-for="' + $.trim(id) + '"><td style="padding-left:10px;padding-right:10px;">' + name + '</td><td style="text-align:right;">' + NumberToIndianRupees(amt) + '</td></tr>'); 
            }
            else {
                var id = trrow.find('td:eq(1)').text();
                $('#tblUnits tr[data-for="'+ $.trim(id)+ '"]').remove();
            }
            var len = $('#tblUnits tr').length;
            if (len <= 1) {
                $('#dvSUnits').html('');
            }
            var GridView = row.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                var headerCheckBox = inputList[0];
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }




        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                debugger;
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                        var row = $(GridView).find('tr').eq(i);

                        var dd = $.trim($('#dvSUnits').html()) == "" ? true : false;
                        if (dd) {
                            $('#dvSUnits').html($('<div style="font-size: 16px;font-weight:bold;">Selected Units</div><table style="text-align:left" id="tblUnits" cellspacing="4" cellpadding="4" border="1" ></table>'));
                            $('#tblUnits').append('<tr><th style="padding:5px;text-align:center;">Name of Unit & Address</th><th>Sanctioned Amount</th></tr>')
                        }
                        var id = row.find('td:eq(1)').text();
                        var name = row.find('td:eq(2)').text();
                        var amt = row.find('td:eq(6)').text();

                        $('#tblUnits').append('<tr data-for="' + $.trim(id) + '"><td style="padding-left:10px;padding-right:10px;">' + name + '</td><td style="text-align:right;">' + NumberToIndianRupees(amt) + '</td></tr>'); 
                        console.log($(GridView).find('tr').eq(i))
                    }
                    else {
                        inputList[i].checked = false;
                        $('#dvSUnits').html('');
                    }
                }
            }

            

        }

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
        .ui-datepicker
        {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }
    </style>
</asp:Content>
