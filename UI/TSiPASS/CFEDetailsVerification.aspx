<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="CFEDetailsVerification.aspx.cs" inherits="UI_TSiPASS_CFEDetailsVerification" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        /* .container {
            max-width: 1200px;
            margin: 20px auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }*/

        .panel-primary {
            border-color: #337ab7;
        }

        .panel-heading {
            background-color: #337ab7;
            color: white;
            font-weight: bold;
        }

        .table {
            margin: 20px 0;
        }

            .table th, .table td {
                vertical-align: middle;
                padding: 10px;
            }

        .inner-table {
            padding-top: -10px;
            margin: 20px 0;
        }

            .inner-table tr, .inner-table td {
                height: 30px;
                padding: 10px; /* Match total height (10px x 5 = 50px) */
            }

        .btn-submit {
            background-color: #28a745;
            color: white;
            border: none;
            transition: background-color 0.3s ease;
        }

            .btn-submit:hover {
                background-color: #218838;
            }

        .btn-info {
            background-color: #17a2b8;
            color: white;
            border: none;
        }

            .btn-info:hover {
                background-color: #138496;
            }
                        table#specialtabledata {
    margin: 0px 0px;
}
            table#specialtabledata .inner-table tr, .inner-table td {
    padding: 8px !important;
}
    </style>
    <asp:updatepanel id="upd1" runat="server">
        <contenttemplate>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" style="text-align: center;">
                                <h3 class="panel-title">CFE Details Verification</h3>
                            </div>

                            <div class="panel-body" align="left">
                                <%--class="table table-bordered table-striped"--%>
                                <div align="left">
                                    <asp:hyperlink font-bold="true" text="Go Back" runat="server" navigateurl="~/UI/Tsipass/CFEListToverify.aspx" font-size="20px"></asp:hyperlink>
                                </div>
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 90%; text-align: left; vertical-align: central" class="table table-bordered table-striped">
                                    <tr>
                                        <td></td>
                                        <td><b>Data Particualr</b></td>
                                        <td></td>
                                        <td><b>User Data</b></td>
                                        <td><b>Enter Verified Data</b></td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>UID No:
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblUidNo" runat="server"></asp:label>

                                            <asp:label id="lblCFEEnterpid" runat="server" visible="false"></asp:label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>NAME OF INDUSTRY</td>
                                        <td>:</td>
                                        <td>
                                            <span>
                                                <asp:label id="lblNameOfUndertaker" runat="server"></asp:label>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtUnitName" runat="server" cssclass="form-control" width="200px" placeholder="Company Name as per PAN card"></asp:textbox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: left;">3</td>
                                        <td style="text-align: left;">PAN NO</td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblpan" runat="server"></asp:label>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtPan" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">4</td>
                                        <td style="text-align: left;">GST</td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblgst" runat="server"></asp:label>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtgst" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">5</td>
                                        <td style="text-align: left;">Type of Sector</td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblSector" runat="server"></asp:label>
                                        </td>
                                        <td>
                                            <asp:radiobuttonlist id="rblSector" runat="server" repeatdirection="Horizontal" tabindex="1">
                                                <asp:listitem text="Manufacturing" value="Manufacturing" />
                                                <asp:listitem text="Service" value="Service" />
                                            </asp:radiobuttonlist>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">6</td>
                                        <td style="text-align: left;">Line of Activity</td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblLOA" runat="server"></asp:label>
                                        </td>
                                        <td>
                                            <asp:dropdownlist id="ddlLOA" runat="server" class="form-control" tabindex="1" width="200px">
                                            </asp:dropdownlist>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">7</td>
                                        <td style="text-align: left;">New & Expansion</td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblExpansion" runat="server"></asp:label>
                                        </td>
                                        <td>
                                            <asp:radiobuttonlist id="rblExpansion" runat="server" repeatdirection="Horizontal" tabindex="1" autopostback="true" onselectedindexchanged="rblExpansion_SelectedIndexChanged">
                                                <asp:listitem text="New" value="New" />
                                                <asp:listitem text="Expansion" value="Expansion" />
                                            </asp:radiobuttonlist>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: left; font-weight: bold;">8. Investment
                                    (in Lakhs)
                                        </td>
                                        <td rowspan="5" style="padding: 0px; margin: auto">
                                            <table align="left" class="inner-table  table-bordered table-striped " id="specialtabledata">
                                                <tr>
                                                    <td>
                                                        <asp:label runat="server" id="lblNew" text="For New"></asp:label>
                                                    </td>
                                                    <td>
                                                        <asp:label runat="server" id="lblExpn" text="For Expansion"></asp:label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 50px;">

                                                    <td>
                                                        <asp:label id="lblPlantN" runat="server"></asp:label>
                                                    </td>
                                                    <td>
                                                        <asp:label id="lblPlantE" runat="server"></asp:label>

                                                    </td>
                                                </tr>
                                                <tr style="height: 51px;">
                                                    <td>
                                                        <asp:label id="lblBuildN" runat="server"></asp:label>
                                                    </td>
                                                    <td>
                                                        <asp:label id="lblBuildE" runat="server"></asp:label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 51px;">
                                                    <td>
                                                        <asp:label id="lblLandCostN" runat="server"></asp:label>
                                                    </td>
                                                    <td>
                                                        <asp:label id="lblLandCostE" runat="server"></asp:label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 50px;">
                                                    <td>
                                                        <asp:label id="lblAnnualN" runat="server"></asp:label>
                                                    </td>
                                                    <td>
                                                        <asp:label id="lblAnnualE" runat="server"></asp:label>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                        <td style="text-align: left; font-weight: bold;">
                                            <asp:label runat="server" id="lblProjtype"></asp:label>
                                        </td>
                                        <td style="text-align: left; font-weight: bold;" id="tdExp" runat="server">For Expansion Project
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: left;">(i)</td>
                                        <td style="text-align: left;">Plant & Machinery</td>
                                        <td>:</td>

                                        <td>
                                            <asp:textbox id="txtNewPlantMachnryCost" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                        <td id="tdPlant" runat="server" visible="false">
                                            <asp:textbox id="txtExpPlantMachnryCost" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">(ii)</td>
                                        <td style="text-align: left;">Building</td>
                                        <td>:</td>


                                        <td>
                                            <asp:textbox id="txtNewBuildingCost" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                        <td id="tdBuilding" runat="server" visible="false">
                                            <asp:textbox id="txtExpBuildingCost" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">(iii)</td>
                                        <td style="text-align: left;">Land</td>
                                        <td>:</td>

                                        <td>
                                            <asp:textbox id="txtNewLandCost" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                        <td id="tdLand" runat="server" visible="false">
                                            <asp:textbox id="txtExpLandCost" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">(iv)</td>
                                        <td style="text-align: left;">Annual Turnover</td>
                                        <td>:</td>

                                        <td>
                                            <asp:textbox id="txtNewTurnover" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                        <td id="tdTurnover" runat="server" visible="false">
                                            <asp:textbox id="txtExpTurnover" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" style="text-align: left; font-weight: bold;">9.Employment
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">(i)</td>
                                        <td style="text-align: left;">Male</td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblMale" runat="server"></asp:label>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtNewMale" runat="server" cssclass="form-control" width="200px" onkeypress="NumberOnly()"></asp:textbox>
                                        </td>
                                        <td id="tdMaleEmp" runat="server" visible="false">
                                            <asp:textbox id="txtExpMale" runat="server" cssclass="form-control" width="200px" onkeypress="NumberOnly()"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">(ii)</td>
                                        <td style="text-align: left;">Female</td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblFemale" runat="server"></asp:label>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtNewFemale" runat="server" cssclass="form-control" width="200px" onkeypress="NumberOnly()"></asp:textbox>
                                        </td>
                                        <td id="tdFemaleEmp" runat="server" visible="false">
                                            <asp:textbox id="txtExpFemale" runat="server" cssclass="form-control" width="200px" onkeypress="NumberOnly()"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;"></td>
                                        <td style="text-align: left;">Total</td>
                                        <td>:</td>
                                        <td>
                                            <asp:label id="lblTotal" runat="server"></asp:label>
                                        </td>
                                        <td>
                                            <asp:textbox id="txtNewTotal" runat="server" cssclass="form-control" width="200px" onkeypress="NumberOnly()"></asp:textbox>
                                        </td>
                                        <td id="tdTotalEmp" runat="server" visible="false">
                                            <asp:textbox id="txtExpTotal" runat="server" cssclass="form-control" width="200px" onkeypress="NumberOnly()"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">10</td>
                                        <td style="text-align: left;">Already TSiPASS Login</td>
                                        <td>:</td>
                                        <td></td>
                                        <td>
                                            <asp:radiobuttonlist id="rblTsipass" runat="server" repeatdirection="Horizontal" tabindex="1" autopostback="true" onselectedindexchanged="rblTsipass_SelectedIndexChanged">
                                                <asp:listitem text="Yes" value="Y" />
                                                <asp:listitem text="No" value="N" />
                                            </asp:radiobuttonlist>

                                        </td>
                                        <td id="Login" runat="server" visible="false">
                                            <asp:textbox id="txtTSiPasslogins" runat="server" cssclass="form-control" width="200px"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" style="text-align: center;">
                                            <asp:button id="btnSave" text="Submit" runat="server" onclick="btnSave_Click" cssclass="btn btn-submit btn-lg" width="150px" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:updateprogress id="UpdateProgress" runat="server" associatedupdatepanelid="upd1">
                <progresstemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />

                        </div>

                    </div>
                </progresstemplate>
            </asp:updateprogress>
        </contenttemplate>
    </asp:updatepanel>
</asp:content>

