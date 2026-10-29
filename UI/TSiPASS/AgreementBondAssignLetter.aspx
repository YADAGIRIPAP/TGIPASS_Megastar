<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="AgreementBondAssignLetter.aspx.cs"
    inherits="UI_TSiPASS_AgreementBondAssignLetter" %>

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

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>


    <link href="assets/css/basic.css" rel="stylesheet" />

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
                                <h1 class="page-head-line" align="left" style="font-size: x-large">Application Details</h1>
                            </div>
                            <asp:updatepanel id="UpdatePanel1" runat="server">
                                <contenttemplate>
                                    <div class="panel-body">
                                        <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-size: 13pt" valign="top" class="style8"></td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <div style="width: 100%">
                                                        <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="false" cellpadding="4"
                                                            cssclass="GRD" forecolor="#333333" height="62px" pagesize="15" showfooter="false"
                                                            width="100%" cellspacing="4" onrowdatabound="grdDetails_RowDataBound">
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
                                                                <asp:boundfield datafield="applicationno" itemstyle-horizontalalign="Center"
                                                                    headertext="Application No">
                                                                    <itemstyle horizontalalign="Center"></itemstyle>
                                                                </asp:boundfield>
                                                                <asp:boundfield datafield="ApplicationFiledDate" itemstyle-horizontalalign="Center" headertext="Application Date">
                                                                    <itemstyle horizontalalign="Center"></itemstyle>
                                                                </asp:boundfield>
                                                                <asp:boundfield datafield="Incentive" itemstyle-horizontalalign="Center" headertext="Incentive Name">
                                                                    <itemstyle horizontalalign="Center"></itemstyle>
                                                                </asp:boundfield>
                                                                <%--  <asp:BoundField DataField="nameofStage" ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>--%>
                                                                <asp:templatefield headertext="Incentiveid" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblEnterperIncentiveID" text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="Incentiveid" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblIncentiveID" text='<%#Eval("MstIncentiveid") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="intstageid" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblintstageid" text='<%#Eval("intstageid") %>' runat="server" />
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <asp:templatefield headerstyle-horizontalalign="Left" headertext="Intimation Letter">
                                                                    <itemtemplate>
                                                                        <asp:hyperlink id="anchortagAgreementBond" target="_blank" runat="server" text="Latest Details Updation"></asp:hyperlink>
                                                                    </itemtemplate>
                                                                    <headerstyle horizontalalign="Left" />
                                                                </asp:templatefield>
                                                                <asp:templatefield headertext="intstageid" visible="false">
                                                                    <itemtemplate>
                                                                        <asp:label id="lblUnitDtlsUpdated" text='<%#Eval("UnitDtlsUpdated") %>' runat="server" />
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
                                                <td style="padding: 5px; margin: 5px" align="center" class="style7">&nbsp;
                                                </td>
                                            </tr>

                                        </table>

                                    </div>
                                </contenttemplate>
                            </asp:updatepanel>
                            <%--   </div>--%>
                        </td>
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
    <asp:updateprogress id="UpdateProgress" runat="server" associatedupdatepanelid="UpdatePanel1">
        <progresstemplate>
            <div class="update">
            </div>
        </progresstemplate>
    </asp:updateprogress>
</asp:content>


