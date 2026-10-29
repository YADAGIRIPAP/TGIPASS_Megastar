<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/ReformsMaster.master" CodeFile="frmDistrictReformsForm.aspx.cs" Inherits="UI_TSiPASS_frmDistrictReformsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="Styles/GridViewStyles.css" rel="stylesheet" />
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <link href="Styles/ui.jqgrid-bootstrap-ui.css" rel="stylesheet" />
    <link href="Styles/ui.jqgrid-bootstrap.css" rel="stylesheet" />
    <link href="Styles/ui.jqgrid.css" rel="stylesheet" />

    <style>
        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 10001; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.7); /* Black w/ opacity */
        }

        .page-head-linenew {
            font-size: 2px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 2px;
            border-bottom: 4px solid #00CA79;
            margin-bottom: 35px;
        }
        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
            min-height: 450px;
        }

        /* The Close Button */
        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }
    </style>

    <style>
        .Grid {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
        }

            .Grid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
            }

            .Grid th {
                padding: 4px 2px;
                color: #fff;
                background: #363670 url(Images/grid-header.png) repeat-x top;
                border-left: solid 1px #525252;
                font-size: 0.9em;
            }

            .Grid .alt {
                background: #fcfcfc url(Images/grid-alt.png) repeat-x top;
            }

            .Grid .pgr {
                background: #363670 url(Images/grid-pgr.png) repeat-x top;
            }

                .Grid .pgr table {
                    margin: 3px 0;
                }

                .Grid .pgr td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .Grid .pgr a {
                    color: Gray;
                    text-decoration: none;
                }

                    .Grid .pgr a:hover {
                        color: #000;
                        text-decoration: none;
                    }
    </style>
    <style type="text/css">
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

        .tital {
            font-size: 14px;
            font-weight: 500;
        }

        .bot-border {
            border-bottom: 1px #f8f8f8 solid;
            margin: 5px 0 5px 0;
        }

        .table-user-information > tbody > tr {
            border-top: 1px solid rgb(221, 221, 221);
        }

            .table-user-information > tbody > tr:first-child {
                border-top: 0;
            }


            .table-user-information > tbody > tr > td {
                border-top: 0;
            }
    </style>
    <script type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%-- <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave3" />
            <asp:PostBackTrigger ControlID="btncfeactionclick" />
        </Triggers>--%>
        <ContentTemplate>

            <%--  <table style="width: 100%; margin: auto; text-align: center">
                <tr>
                    <td>
                        <h3>HELP DESK SOLUTION</h3>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>--%>

            <div class="container-fluid">
                <div class="row" style="margin-top: 25px; margin-bottom: 0px;">
                    <div class="col-md-offset-4">
                        <div class="form-group form-inline">
                            <label for="selType">
                                <h5>Departments:</h5>
                            </label>
                            <asp:DropDownList ID="ddldepartments" Width="210px" class="form-control" OnSelectedIndexChanged="ddldepartments_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="row" id="divcfefailedwebservices" runat="server">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:GridView ID="gvcfefaileddata" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%"
                                ShowFooter="false" OnRowDataBound="gvcfefaileddata_RowDataBound">
                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkcheckapps" runat="server" Checked="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="Dept_Name" HeaderText="Department Name"></asp:BoundField>
                                    <asp:BoundField DataField="approvalName" HeaderText="Approval/Services"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Approvalid" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApprovalid" Text='<%#Eval("Approvalid") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <%--<asp:HyperLinkField FooterStyle-CssClass="text-center" DataTextField="Approvalid" Visible="false"
                                                    ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black" HeaderText="Total Employment">
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>--%>
                                    <asp:TemplateField HeaderText="DeptId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptId" Text='<%#Eval("Dept_Id") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <%--<asp:HyperLinkField FooterStyle-CssClass="text-center" DataTextField="Dept_Id" Visible="false"
                                                    ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black" HeaderText="Apply Here">
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>--%>

                                    <asp:TemplateField HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Download" Target="_blank" runat="server"
                                                
                                                Text='Download Form'>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Instructions">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Instructions" runat="server"
                                                
                                                Text='Click Here'>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="ApplyHere" runat="server"
                                                Text='Apply and Upload'>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                   

                                </Columns>


                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row" runat="server" visible="false" id="divbtnupdatecfe">
                        <div class="col-md-12">
                            <div class="form-group" style="padding-left: 50%">
                                <%--<input type="button" value="Process" id="btnAction" class="btn btn-success" />--%>
                                <asp:Button ID="btnupdate" runat="server" Text="Process" class="btn btn-success" />
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>

    <script type="text/javascript">

        var GactionType = 0;


        function hideElements() {
            $('#divselIncTypes,#divselrollbacklevel,#divselrbtype,#divselroleamt,#divselcaste,#divtxtAmt,#btnAction').addClass('hidden');
            $('#selIncTypes,#selrollbacklevel,#selrbtype,#selroleamt,#selcaste').val('0');
            $('#txtAmt').val('');
            $('#selrbtype option').prop('disabled', false);
        }

        function disableValuesSelect(ids) {
            $('#selrbtype option').prop('disabled', false)
            var id = ids.split(',');
            if (id.length > 0) {
                for (var i = 0; i < id.length; i++) {
                    $('#selrbtype option').filter(function () {
                        return $(this).val() == id[i];
                    }).prop('disabled', true);
                }
            }
        }


        $(function () {

            $('#selType').change(function () {
                var d = $(this).val();

                if (d == 1) {
                    $('#DivInc').removeClass('hidden');
                    $('#DivCfe').addClass('hidden');
                    $('#DivCfo').addClass('hidden');
                    $('#inputIncId').val('');
                    $('#inputUnit').val('');
                    $('#ctl00_ContentPlaceHolder1_selDist').val('0');

                } else
                    if (d == 2) {
                        $('#DivInc').addClass('hidden');
                        $('#DivCfe').removeClass('hidden');
                        $('#DivCfo').addClass('hidden');
                    } else
                        if (d == 3) {
                            $('#DivInc').addClass('hidden');
                            $('#DivCfe').addClass('hidden');
                            $('#DivCfo').removeClass('hidden');
                        } else {
                            $('#DivInc').addClass('hidden');
                            $('#DivCfe').addClass('hidden');
                            $('#DivCfo').addClass('hidden');
                        }
            });

            $('#btnSearch').click(function () {
                var id, unit, dist, valid;

                id = $.trim($('#inputIncId').val());
                unit = $.trim($('#inputUnit').val());
                dist = $('#ctl00_ContentPlaceHolder1_selDist').val();
                valid = 0;
                if (id == "" && unit == "" && dist == 0) {
                    valid = 0;
                } else {
                    valid = 1;
                }

                if (valid != 0) {

                    var strData = JSON.stringify({ 'Id': id, 'Unitname': unit, 'Dist': dist });

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "Solution.aspx/IncentivesList",
                        data: strData,
                        success: function (response) {
                            console.log(response);
                            var data = JSON.parse(response.d);
                            console.log(data);
                            if (data != '' && data.length > 0) {
                                $('#datatable').removeClass('hidden');
                                $("#datatable tbody").remove();
                                var tbody = $("<tbody/>");
                                $.each(data, function (rowIndex, t) {
                                    var row = $("<tr/>");
                                    row.append($("<td/>").text(t.IncentveID));
                                    row.append($("<td/>").text(t.UnitName));
                                    row.append($("<td/>").text(t.District_Name));
                                    row.append($("<td/>").text((t.ApplicationFiledDate == null) ? "" : t.ApplicationFiledDate));
                                    row.append($("<td/>").html("<input type='button' id='btnIncinfo' class='btn btn-info' onclick='showStatus(" + t.IncentveID + ");' value='Status' />  "));
                                    row.append($("<td/>").html("<input type='button' id='btnIncDetails' class='btn btn-success' onclick='showDetails(" + t.IncentveID + ");' value='Process' /> "));
                                    tbody.append(row);
                                });
                                $('#datatable').append(tbody);
                            }
                            else {
                                $('#datatable').addClass('hidden');
                                $("#datatable tbody").empty();
                                alert('No results found.');
                            }


                        },
                        error: function (e, a, t) {
                            console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                        }
                    });
                }
                else {
                    alert('Please Enter Fields to Search Incentives');
                }
            });

            $('#ModalBody').on("click", "#btnRollback", function (e) {
                GactionType = 1;
                hideElements();
                $('#divselIncTypes,#divselrollbacklevel,#divselrbtype,#btnAction').removeClass('hidden');
                e.preventDefault();
            });

            $('#ModalBody').on("click", "#btnAmount", function (e) {
                GactionType = 2;
                hideElements();
                $('#divselIncTypes,#divselroleamt,#divtxtAmt,#btnAction').removeClass('hidden');
                e.preventDefault();
            });

            $('#ModalBody').on("click", "#btnCaste", function (e) {
                GactionType = 3;
                hideElements();
                $('#divselcaste,#btnAction').removeClass('hidden');
                e.preventDefault();
            });

            $('#ModalBody').on("change", "#selrollbacklevel", function (e) {
                var d = $(this).val();
                $('#selrbtype').val('0');

                if (d != 0) {
                    var ids;
                    if (d == 1) { ids = "1,4"; }
                    if (d == 2) { ids = "2,3,4"; }
                    if (d == 3) { ids = "2,3,4"; }
                    if (d == 4) { ids = "1,3"; }
                    if (d == 5) { ids = "2,3,4"; }
                    if (d == 6) { ids = "1,3,4"; }
                    if (d == 7) { ids = "1,4"; }
                    if (d == 8) { ids = "2,3,4"; }
                    if (d == 9) { ids = "2,3,4"; }
                    disableValuesSelect(ids);
                    $('#selrbtype').prop('disabled', false);
                } else {
                    $('#selrbtype option').prop('disabled', false);
                    $('#selrbtype').prop('disabled', true);
                }
                e.preventDefault();
            });


            $('#myModal').on("click", "#btnModelClose", function (e) {
                modal.style.display = "none";
                e.preventDefault();
            });


            $('#myModal').on("click", "#btnAction", function (e) {
                if (GactionType == 1) {
                    debugger;
                    var strData = JSON.stringify({ 'EntrpId': $('#lblIncId').html(), 'MstIncid': $('#selIncTypes').val(), 'Rblevel': $('#selrollbacklevel').val(), 'Type': $('#selrbtype').val() });
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "Solution.aspx/ApplicationRollback",
                        data: strData,
                        success: function (response) {
                            var data = JSON.parse(response.d);
                            if (data == 1) {
                                alert('success');
                            } else {
                                alert('Rool back not Updated due to internal server problem.');
                            }
                        },
                        error: function (e, a, t) {
                            alert('Rool back not Updated due to internal server problem.');
                            console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                        }
                    });

                }
                if (GactionType == 2) {
                    var strData = JSON.stringify({ 'EnrpId': $('#lblIncId').html(), 'MstincId': $('#selIncTypes').val(), 'Role': $('#selroleamt').val(), 'Amount': $('#txtAmt').val() });
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "Solution.aspx/UpdateIncentiveAmount",
                        data: strData,
                        success: function (response) {
                            var data = JSON.parse(response.d);
                            if (data == 1) {
                                alert('Amount Updated Successfully.');
                                $('#selroleamt').val('0');
                                $('#txtAmt').val('');
                                $('#selIncTypes').val('0');
                            } else {
                                alert('Amount not Updated due to internal server problem.');
                            }
                        },
                        error: function (e, a, t) {
                            alert('Amount not Updated due to internal server problem.');
                            console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                        }
                    });

                }
                if (GactionType == 3) {
                    var strData = JSON.stringify({ 'EnrpId': $('#lblIncId').html(), 'Caste': $('#selcaste').val() });

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "Solution.aspx/UpdateCaste",
                        data: strData,
                        success: function (response) {
                            var data = JSON.parse(response.d);
                            if (data == 1) {
                                alert('Caste Updated Successfully.');
                                $('#selcaste').val('0');
                            } else {
                                alert('Caste not Updated due to internal server problem.');
                            }
                        },
                        error: function (e, a, t) {
                            alert('Caste not Updated due to internal server problem.');
                            console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                        }
                    });
                }

                e.preventDefault();
            });

        });


        function showStatus(id) {

            var strData = JSON.stringify({ 'Id': id });

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "Solution.aspx/IncentiveStatus",
                data: strData,
                success: function (response) {
                    var data = JSON.parse(response.d);
                    console.log(data);
                    if (data.Table != '' && data.Table.length > 0) {
                        console.log(data.Table[0]);
                        var incentives = '';

                        if (data.Table1.length > 0) {
                            debugger;
                            var table = '<h4>Applied Incentives List</h4><table class="table"><thead><th>Incentive Name</th><th>Time peroid</th><th>Present status</th></thead><tbody>';
                            $.each(data.Table1, function (rowIndex, t) {
                                table = table + "<tr><td>" + t.IncentiveName + "</td><td>" + formatDate(t.FromDate, 1) + " -- " + formatDate(t.ToDate, 1) + "</td><td>" + t.nameofStage + "</td></tr>";
                            });
                            incentives = table + '</tbody></table>'
                        }
                        else {
                            incentives = '<h4>Incentives not applied</h4>';
                        }

                        $('#ModalBody').html('<div class="container-fluid"> <div class="row"> <div class="col-md-10"> <table class="table"> <tr> <td>Application Date :</td> <td>' + formatDate(data.Table[0].ApplicationFiledDate) + '</td> <td>Application No :</td> <td>' + data.Table[0].applicationno + '</td> </tr> <tr> <td>Unit Name :</td> <td>' + data.Table[0].UnitName + '</td> <td>Applicant Name :</td> <td>' + data.Table[0].ApplciantName + '</td> </tr> <tr> <td>Sector :</td> <td>' + data.Table[0].SectorNew + '</td> <td>Social Status :</td> <td>' + data.Table[0].SocialStatus + '</td> </tr> <tr> <td>Category :</td> <td>' + data.Table[0].Category + '</td> <td>DCP :</td> <td>' + formatDate(data.Table[0].DCP) + '</td> </tr> <tr> <td>District :</td> <td>' + data.Table[0].UnitDistName + '</td> <td>Mandal :</td> <td>' + data.Table[0].UNITMANDAL + '</td> </tr> <tr> <td>Village:</td> <td>' + data.Table[0].UNITVILLAGE + '</td> <td>Mobile :</td> <td>' + data.Table[0].UnitMObileNo + '</td> </tr> <tr> <td>Email :</td> <td>' + data.Table[0].UnitEmail + '</td> <td></td> <td></td> </tr> <tr> <td></td> <td></td> <td></td> <td></td> </tr> </table> </div> </div><div class="row"><div class="col-md-12">' + incentives + '</div></div></div>');

                        modal.style.display = "block";

                    }
                    else {
                    }
                },
                error: function (e, a, t) {
                    console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                }
            });

        }


        function showDetails(id) {
            debugger;
            GactionType = 0;

            modal.style.display = "block";
            $('#ModalBody').html($('#divProcess').html());
            hideElements();

            var strData = JSON.stringify({ 'Id': id });

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "Solution.aspx/GetIncentivesList",
                data: strData,
                success: function (response) {
                    var data = JSON.parse(response.d);
                    console.log(data);
                    if (data.Table != '' && data.Table.length > 0) {
                        console.log('Incentives list');
                        console.log(data.Table[0]);
                        var d = data.Table[0];

                        $('#selIncTypes').empty().append('<option value="0"> Select </option>');
                        $.each(data.Table, function (index, value) {
                            $('#selIncTypes').append('<option value="' + value.MstIncentiveid + '">' + value.IncentiveName + '</option>');
                        });

                        $('#lblUnitname').html('').html(d.UnitName);
                        $('#lblIncId').html('').html(id);
                    }
                    else {
                    }
                },
                error: function (e, a, t) {
                    console.log('jqXHR:'), console.log(e), console.log('textStatus:'), console.log(a), console.log('errorThrown:'), console.log(t)
                }
            });

        }

        var modal = document.getElementById('myModal');

        //var btn = document.getElementById("myBtn");

        var span = document.getElementsByClassName("close")[0];

        //btn.onclick = function () {
        //    modal.style.display = "block";
        //}

        span.onclick = function () {
            modal.style.display = "none";
        }


        window.onclick = function (event) {
            if (event.target == modal) {
                if ($('#ModalBody #divProc').length == 0) {
                    modal.style.display = "none";
                }
                else {
                    modal.style.display = "block";
                }
            }
        }





        ///  date functions


        function ConvertJsonDate(d) {
            if (d != null) {
                var dt = eval(d.replace(/\/Date\((.*?)\)\//gi, "new Date($1)"));
                var month = dt.getMonth() + 1;
                var monthString = month > 9 ? month : '0' + month;
                var day = dt.getDate();
                var dayString = day > 9 ? day : '0' + day;
                var year = dt.getFullYear();
                return dayString + '/' + monthString + '/' + year;
            }
            else { return ""; }
        }

        function formatDate(date, type) {
            if (date != null) {
                var month_names_short = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                var d = new Date(date),
                    month = '' + (d.getMonth() + 1),
                    day = '' + d.getDate(),
                    year = d.getFullYear();

                if (month.length < 2) month = '0' + month;
                if (day.length < 2) day = '0' + day;

                if (type != undefined) {
                    return month_names_short[d.getMonth()] + " " + year
                } else {
                    return [day, month, year].join('/');
                }
            } else { return ""; }
        }


        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }
    </script>
</asp:Content>
