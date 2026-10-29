<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="IncentiveStatusInspectionUploadbyCoiClerk.aspx.cs" inherits="UI_TSiPASS_IncentiveStatusInspectionUploadbyCoiClerk" %>

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

        .style10 {
            width: 9px;
            height: 28px;
        }

        .style11 {
            width: 210px;
            height: 28px;
        }

        .style12 {
            width: 212px;
            height: 28px;
        }

        .style13 {
            width: 210px;
            height: 21px;
        }

        .style14 {
            width: 9px;
            height: 21px;
        }

        .style15 {
            height: 21px;
        }

        .style16 {
            width: 212px;
            height: 21px;
        }

        .style17 {
            height: 28px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function sumPropBulk() {
            var txtFirstNumberValue = document.getElementById('txtProsPetorlClassA').value;
            var txtSecondNumberValue = document.getElementById('txtPropPetolClassB').value;
            var txtThirdNumberValue = document.getElementById('txtPropPetolClassB').value;
            var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue) + parseInt(txtThirdNumberValue);
            if (!isNaN(result)) {
                document.getElementById('txtPropPetrolTotal').value = result;
            }
        }
    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Incentive Status Upload</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Incentive Applications
                            <%--<a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                alt="Excel" /></a>--%>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr id="tr12" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="style11">
                                                            <asp:label id="Label438" runat="server" cssclass="LBLBLACK" width="108px">Status</asp:label>
                                                        </td>
                                                        <td class="style10" style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:dropdownlist id="ddlstatus" runat="server" class="form-control txtbox" height="33px"
                                                                width="180px" autopostback="True" tabindex="1">
                                                                <asp:listitem>All</asp:listitem>
                                                                <asp:listitem>Pending</asp:listitem>
                                                                <asp:listitem>Reject</asp:listitem>
                                                                <asp:listitem>Forwarded</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17"></td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:label id="Label437" runat="server" cssclass="LBLBLACK" width="108px">Industry Name</asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">:
                                                        </td>
                                                        <td class="style12" style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="TxtIndname" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="80" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="style13">
                                                            <asp:label id="Label439" runat="server" cssclass="LBLBLACK" width="108px">District</asp:label>
                                                        </td>
                                                        <td class="style14" style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                            <asp:dropdownlist id="ddlDistrict" runat="server" class="form-control txtbox" height="33px"
                                                                width="180px" autopostback="True" tabindex="1">
                                                                <asp:listitem>--Select--</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td class="style15" style="padding: 5px; margin: 5px"></td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                            <asp:label id="Label440" runat="server" cssclass="LBLBLACK"
                                                                width="108px">Incentive Name</asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">:</td>
                                                        <td class="style16" style="padding: 5px; margin: 5px">
                                                            <asp:dropdownlist id="ddlIncentiveName" runat="server"
                                                                class="form-control txtbox" height="33px" tabindex="1"
                                                                width="180px">
                                                                <asp:listitem>--Select--</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                            </td>
                                            <td style="width: 27px">&nbsp;
                                            </td>
                                            <td valign="top">&nbsp;
                                            </td>
                                        </tr>--%>
                                        <tr>

                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3" align="center">
                                                <asp:label id="lblMsg" runat="server" font-bold="True" font-names="verdana" font-size="13px"
                                                    forecolor="#006600"></asp:label>
                                                <tr id="trNEW1" runat="server" visible="false">
                                                    <td align="center" style="padding: 5px; margin: 5px" valign="top">
                                                        <div style="text-align: left; font-size: 16px; margin-left: 50px; font-weight: 500;">Search</div>
                                                        <div style="margin-bottom: 17px; text-align: left; margin-left: 50px;">

                                                            <input type="text" id="search" class="form-control input-sm" style="width: 230px; font-size: 14px; height: 35px; float: left; margin-right: 10px;" placeholder="Unit Name" />

                                                            <select class="form-control" id="SelCatgy" style="float: left; margin-right: 10px; width: 148px; height: 35px;">
                                                                <option value="0">Select Category</option>
                                                                <option value="SC">SC</option>
                                                                <option value="ST">ST</option>
                                                                <option value="PHC">PHC</option>
                                                                <option value="GENERAL">GENERAL</option>
                                                            </select>

                                                            <asp:dropdownlist id="DrpDist" runat="server" style="float: left; margin-right: 10px;" class="form-control txtbox" height="33px"
                                                                width="142px" tabindex="1">
                                                                <asp:listitem value="0">Select District</asp:listitem>
                                                            </asp:dropdownlist>

                                                            <input type="button" class="btn btn-default" style="float: left" value="Clear" id="clear" />
                                                            <div class="clear"></div>
                                                        </div>
                                                        <asp:gridview id="gvdetailsnew" cssclass="floatingTable" runat="server" allowpaging="false"
                                                            autogeneratecolumns="False" cellpadding="4" height="62px" pagesize="20" width="90%"
                                                            font-names="Verdana" font-size="12px" gridlines="Both" onrowdatabound="gvdetailsnew_RowDataBound">
                                                            <headerstyle verticalalign="Middle" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                                            <rowstyle cssclass="GridviewScrollC1Item" />
                                                            <pagerstyle cssclass="GridviewScrollC1Pager" />
                                                            <footerstyle backcolor="#013161" height="40px" cssclass="GridviewScrollC1Header" />
                                                            <alternatingrowstyle cssclass="GridviewScrollC1Item2" />
                                                            <columns>
                                                                <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                    <itemtemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                        <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                        <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                        <asp:label id="lblDistID" cssclass="GrdDistrict" runat="server" text='<%#Eval("District") %>'
                                                                            style="display: none;" />
                                                                    </itemtemplate>
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle width="50px" />
                                                                </asp:templatefield>
                                                                <asp:boundfield datafield="UnitName" itemstyle-cssclass="GrdUnitname" itemstyle-horizontalalign="Center"
                                                                    headertext="Unit Name" />
                                                                <asp:boundfield datafield="Category" itemstyle-cssclass="GrdCategory" itemstyle-horizontalalign="Center"
                                                                    headertext="Category" />
                                                                <asp:boundfield datafield="ApplicationFiledDate" itemstyle-width="150px" itemstyle-horizontalalign="Center"
                                                                    headertext="Date of Filing" />
                                                                <asp:boundfield datafield="InspectionAssignDate" itemstyle-horizontalalign="Center"
                                                                    headertext="G.M Recommended Date" />
                                                                <asp:boundfield datafield="NoofIncentives" itemstyle-horizontalalign="Center" headertext="No. Incentives" />
                                                                <asp:templatefield headertext="Incentiveid" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblIncentiveID" text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="IncentiveidS" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblIncentiveIDS" text='<%#Eval("IncentiveIds") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="Incentive Types">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblIncentivetypes" text='<%#Eval("INCENTIVESNAME") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:boundfield datafield="districtName" itemstyle-horizontalalign="Center" headertext="District" />
                                                                <asp:templatefield headertext="Process Application" itemstyle-horizontalalign="Center">
                                                                    <itemtemplate>
                                                                        <%--  <a id="View" target="_blank" href="ApplicantIncentiveDtls.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">View</a>--%>
                                                                        <%--<asp:HyperLink ID="anchortaglink" runat="server" Text="View" Font-Bold="true" ForeColor="Green" Target="_blank" />--%>
                                                                        <asp:button id="Button1" runat="server" text="Process" cssclass="btn btn-primary"
                                                                            onclick="anchortaglink_Click"></asp:button>
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="Incentiveid" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblEnterperIncentiveID" text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                   <asp:templatefield headertext="sector_GM" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblsector_GM" text='<%#Eval("sector_GM") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                            </columns>
                                                        </asp:gridview>
                                                    </td>
                                                </tr>
                                                <tr id="trNEW2" runat="server" visible="false">
                                                    <td align="center" style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                                        <div style="text-align: left; font-size: 16px; margin-left: 50px; font-weight: 500;">Search</div>
                                                        <div style="margin-bottom: 17px; text-align: left; margin-left: 50px;">

                                                            <input type="text" id="Text1" class="form-control input-sm" style="width: 230px; font-size: 14px; height: 35px; float: left; margin-right: 10px;" placeholder="Unit Name" />

                                                            <select class="form-control" id="Select1" style="float: left; margin-right: 10px; width: 148px; height: 35px;">
                                                                <option value="0">Select Category</option>
                                                                <option value="SC">SC</option>
                                                                <option value="ST">ST</option>
                                                                <option value="PHC">PHC</option>
                                                                <option value="GENERAL">GENERAL</option>
                                                            </select>

                                                            <asp:dropdownlist id="DropDownList1" runat="server" style="float: left; margin-right: 10px;" class="form-control txtbox" height="33px"
                                                                width="142px" tabindex="1">
                                                                <asp:listitem value="0">Select District</asp:listitem>
                                                            </asp:dropdownlist>

                                                            <input type="button" class="btn btn-default" style="float: left" value="Clear" id="Button2" />
                                                            <div class="clear"></div>
                                                        </div>
                                                        <asp:gridview id="GridView1" runat="server" cssclass="floatingTable1" allowpaging="false"
                                                            autogeneratecolumns="False" cellpadding="4" height="62px" pagesize="20" width="90%"
                                                            font-names="Verdana" font-size="12px" gridlines="Both" onrowdatabound="GridView1_RowDataBound">
                                                            <headerstyle verticalalign="Middle" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                                            <rowstyle cssclass="GridviewScrollC1Item" />
                                                            <pagerstyle cssclass="GridviewScrollC1Pager" />
                                                            <footerstyle backcolor="#013161" height="40px" cssclass="GridviewScrollC1Header" />
                                                            <alternatingrowstyle cssclass="GridviewScrollC1Item2" />
                                                            <columns>
                                                                <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No">
                                                                    <itemtemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                        <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                        <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                        <asp:label id="lblDistID" cssclass="GrdDistrict" runat="server" text='<%#Eval("District") %>'
                                                                            style="display: none;" />
                                                                    </itemtemplate>
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle width="50px" />
                                                                </asp:templatefield>
                                                                <asp:boundfield datafield="UnitName" itemstyle-cssclass="GrdUnitname" itemstyle-horizontalalign="Center"
                                                                    headertext="Unit Name" />
                                                                <asp:boundfield datafield="Category" itemstyle-cssclass="GrdCategory" itemstyle-horizontalalign="Center"
                                                                    headertext="Category" />
                                                                <asp:boundfield datafield="ApplicationFiledDate" itemstyle-horizontalalign="Center"
                                                                    headertext="Date of Filing" />
                                                                <asp:boundfield datafield="InspectionAssignDate" itemstyle-horizontalalign="Center"
                                                                    headertext="G.M Recommended Date" />
                                                                <asp:boundfield datafield="CreatedDate" itemstyle-horizontalalign="Center" headertext="Query Raised Date" />
                                                                <asp:boundfield datafield="NoofIncentives" itemstyle-horizontalalign="Center" headertext="No. Incentives" />
                                                                <asp:templatefield headertext="Incentiveid" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblIncentiveID" text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="IncentiveidS" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblIncentiveIDS" text='<%#Eval("IncentiveIds") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="Incentive Types">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblIncentivetypes" text='<%#Eval("INCENTIVESNAME") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:boundfield datafield="districtName" itemstyle-horizontalalign="Center" headertext="District" />
                                                                <asp:templatefield headertext="Process Application" itemstyle-horizontalalign="Center">
                                                                    <itemtemplate>
                                                                        <asp:button id="Button1" runat="server" text="Process" cssclass="btn btn-primary"
                                                                            onclick="anchortaglink_Click"></asp:button>
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                   <asp:templatefield headertext="sector_GM" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblsector_GM" text='<%#Eval("sector_GM") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                            </columns>
                                                        </asp:gridview>

                                                    </td>

                                                </tr>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $('#search').val('');

            if ($('table.floatingTable1').not('thead')) {
                var len = $('table.floatingTable1 tr').has('th').length;
                $('table.floatingTable1').prepend('<thead></thead>')
                for (i = 0; i < len; i += 1) {
                    $('table.floatingTable1').find('thead').append($('table.floatingTable1').find("tr:eq(" + i + ")"));
                }
            }

            var $table = $('table.floatingTable1');
            $table.floatThead();
            $table.floatThead({ position: 'fixed' });
            $table.floatThead({ autoReflow: 'true' });


        });

        $('#search').keyup(function () {

            SearchGrid(1);
        });

        $('#SelCatgy').change(function () {
            debugger;
            SearchGrid(1);
        });

        $('#ctl00_ContentPlaceHolder1_DrpDist').change(function () {

            SearchGrid(1);
        });

        $('#Text1').keyup(function () {
            SearchGrid(2);
        });

        $('#Select1').change(function () {
            SearchGrid(2);
        });

        $('#ctl00_ContentPlaceHolder1_DropDownList1').change(function () {
            SearchGrid(2);
        });




        function SearchGrid(id) {
            debugger;
            var unitname = '';
            var category = '0';
            var distrit = '0'
            if (id == 1) {
                unitname = $('#search').val();
                category = $('#SelCatgy').val();
                distrit = $('#ctl00_ContentPlaceHolder1_DrpDist').val();
            }
            if (id == 2) {
                unitname = $('#Text1').val();
                category = $('#Select1').val();
                distrit = $('#ctl00_ContentPlaceHolder1_DropDownList1').val();
            }


            if (unitname != '' && category != '0' && distrit != '0') {

                if (id == 1) {
                    $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                        var patt = new RegExp(unitname, "i");
                        var patt1 = new RegExp(category, "i");
                        var patt2 = new RegExp(distrit, "i");
                        if (!($(this).find('td').find('.GrdDistrict').text().search(patt2) >= 0 && $(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td').find('.GrdDistrict').text().search(patt2) >= 0 && $(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                            $(this).show();
                        }
                    });
                }

                if (id == 2) {
                    $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                        var patt = new RegExp(unitname, "i");
                        var patt1 = new RegExp(category, "i");
                        var patt2 = new RegExp(distrit, "i");
                        if (!($(this).find('td').find('.GrdDistrict').text().search(patt2) >= 0 && $(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td').find('.GrdDistrict').text().search(patt2) >= 0 && $(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                            $(this).show();
                        }
                    });
                }



            } else if (unitname != '' && distrit != '0') {

                if (id == 1) {
                    {
                        $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                            var patt = new RegExp(unitname, "i");
                            var patt1 = new RegExp(distrit, "i");

                            if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                                $(this).not('thead').hide();
                            }
                            if (($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                                $(this).show();
                            }
                        });
                    }
                    if (id == 2) {
                        $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                            var patt = new RegExp(unitname, "i");
                            var patt1 = new RegExp(distrit, "i");

                            if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                                $(this).not('thead').hide();
                            }
                            if (($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                                $(this).show();
                            }
                        });
                    }
                }

            } else if (category != '0' && distrit != '0') {

                if (id == 1) {
                    $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                        var patt = new RegExp(category, "i");
                        var patt1 = new RegExp(distrit, "i");

                        if (!($(this).find('td.GrdCategory').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td.GrdCategory').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                            $(this).show();
                        }
                    });
                }
                if (id == 2) {
                    $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                        var patt = new RegExp(category, "i");
                        var patt1 = new RegExp(distrit, "i");

                        if (!($(this).find('td.GrdCategory').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td.GrdCategory').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                            $(this).show();
                        }
                    });
                }


            } else if (unitname != '' && category != '0') {

                if (id == 1) {
                    $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                        var patt = new RegExp(unitname, "i");
                        var patt1 = new RegExp(category, "i");

                        if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                            $(this).show();
                        }
                    });
                }


                if (id == 2) {
                    $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                        var patt = new RegExp(unitname, "i");
                        var patt1 = new RegExp(category, "i");

                        if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                            $(this).show();
                        }
                    });
                }


            } else if (unitname != '') {
                if (id == 1) {
                    $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                        var patt = new RegExp(unitname, "i");
                        if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td.GrdUnitname').text().search(patt) >= 0)) {
                            $(this).show();
                        }
                    });
                }

                if (id == 2) {
                    $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                        var patt = new RegExp(unitname, "i");
                        if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td.GrdUnitname').text().search(patt) >= 0)) {
                            $(this).show();
                        }
                    });
                }
            }
            else if (category != '0') {
                if (id == 1) {
                    $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                        var patt = new RegExp(category, "i");
                        if (!($(this).find('td.GrdCategory').text().search(patt) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td.GrdCategory').text().search(patt) >= 0)) {
                            $(this).show();
                        }
                    });
                }

                if (id == 2) {
                    $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                        var patt = new RegExp(category, "i");
                        if (!($(this).find('td.GrdCategory').text().search(patt) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td.GrdCategory').text().search(patt) >= 0)) {
                            $(this).show();
                        }
                    });
                }

            }
            else if (distrit != '0') {
                if (id == 1) {
                    $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                        var patt = new RegExp(distrit, "i");
                        if (!($(this).find('td').find('.GrdDistrict').text().search(patt) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td').find('.GrdDistrict').text().search(patt) >= 0)) {
                            $(this).show();
                        }
                    });
                }

                if (id == 2) {
                    $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                        var patt = new RegExp(distrit, "i");
                        if (!($(this).find('td').find('.GrdDistrict').text().search(patt) >= 0)) {
                            $(this).not('thead').hide();
                        }
                        if (($(this).find('td').find('.GrdDistrict').text().search(patt) >= 0)) {
                            $(this).show();
                        }
                    });
                }

            } else {
                if (id == 1)
                    $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody tr').show();
                if (id == 2)
                    $('#ctl00_ContentPlaceHolder1_GridView1 tbody tr').show();

            }
        }




        $('#clear').click(function () {
            debugger;

            $('#search').val('');
            $('#SelCatgy').val('0');
            $('#ctl00_ContentPlaceHolder1_DrpDist').val('0');
            $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody tr').show();

        });



        $('#Button2').click(function () {
            debugger;

            $('#Text1').val('');
            $('#Select1').val('0');
            $('#ctl00_ContentPlaceHolder1_DropDownList1').val('0');
            $('#ctl00_ContentPlaceHolder1_GridView1 tbody tr').show();


        });



    </script>
</asp:content>

