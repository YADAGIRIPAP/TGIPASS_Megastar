<%@ page language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="frmDashBoardSLC.aspx.cs" inherits="UI_TSIPASS_frmDashBoardSLC" %>

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

        .page-head-linenew {
            font-size: 2px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 2px;
            border-bottom: 4px solid #00CA79;
            margin-bottom: 35px;
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
    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Joint Director&#39;s Dashboard</h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px">
                                    <div class="panel panel-default">
                                        <div class="panel-body" align="center">
                                            <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="width: 395px" valign="top"></td>
                                                    <td style="width: 30px">&nbsp;
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                                    <td valign="top" style="width: 395px">
                                                        <div class="list-group">                                                          
                                                            <a href="IncentiveWiseSLClist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                                                <asp:Label ID="Label12" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar"></i>Approved by SLC </a>
                                                        </div>
                                                     

                                                    </td>
                                                    <td style="width: 30px"></td>
                                                    <td valign="top" style="width: 395px">
                                                        <div class="list-group">                                                           
                                                            <a href="DIPCApprovedlist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                                                <asp:Label ID="lblDIPCReleasePendings" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar"></i>Approved by DIPC </a>
                                                        </div>
                                                      
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td valign="top" style="width: 395px">
                                                        <div class="list-group">
                                                            <%-- <a href="ListofSCLS.aspx?Stg=4" class="list-group-item">--%>
                                                            <a href="IncentiveWiseSLClist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                                                <asp:label id="Label12" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Approved by SLC </a>
                                                        </div>
                                                        <div class="list-group">
                                                            <%-- <a href="ListofSCLS.aspx?Stg=5" class="list-group-item">--%>
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Releases</b></a>
                                                            <a href="ReleaseProcedingsStep2CompletedListPrint.aspx?Stg=5" class="list-group-item">
                                                                <span class="badge">
                                                                    <asp:label id="lblReleaseProceedingsCmpltdList" runat="server"></asp:label>
                                                                </span>
                                                                <i class="fa fa-fw fa-calendar"></i>Print SLC Release Proceedings Completed List
                                                            </a>
                                                        </div>
                                                        <div class="list-group">
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>UC List</b></a> <a
                                                                href="frmCheckDetailsprintReprint.aspx?Stg=5&Status=UC" class="list-group-item">
                                                                <span class="badge">
                                                                    <asp:label id="Label16" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Print-UC Updated List </a><a href="frmCheckDetailsprintReprint.aspx?Stg=6&Status=NUC"
                                                                    class="list-group-item"><span class="badge">
                                                                        <asp:label id="Label24" runat="server"></asp:label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Print-UC Not Updated List </a>

                                                        </div>
                                                        <div class="list-group">
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Cheque Preparation List</b></a>
                                                            <a href="frmCheckDetailsprint.aspx?Stg=5&Status=Pending" class="list-group-item"><span
                                                                class="badge">
                                                                <asp:label id="Label13" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Generate Cheque Preparation List</a> <a href="frmCheckDetailsprintGenerated.aspx?Stg=5&Status=Generated"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label25" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Generated Cheque Preparation List </a>
                                                            <a href="frmCheckDetailsprint_ROLLBACKEDCASES.aspx?Stg=5&Status=Pending" class="list-group-item"><span
                                                                class="badge">
                                                                <asp:label id="lblrollbackslc" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Generate Cheque Preparation List-Rollbacked Cases</a>
                                                        </div>
                                                        <div class="list-group">
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Update Cheque Details
                                                                New</b></a> <a href="UpdateCheckListALL.aspx?Stg=50" class="list-group-item"><span
                                                                    class="badge">
                                                                    <asp:label id="Label36" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Cheque Details Not Uploaded</a><a href="UpdateCheckNumberListALL.aspx?Stg=51"
                                                                    class="list-group-item"><span class="badge">
                                                                        <asp:label id="Label37" runat="server"></asp:label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Cheque Details Cheque Number</a><a href="UpdateUTRNumberListALL.aspx?Stg=52"
                                                                        class="list-group-item"><span class="badge">
                                                                            <asp:label id="Label38" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Cheque Details with UTR Number</a>
                                                            <a href="frmlapsedchequesrollback.aspx"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label1" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Rollback cheque details based on cheque number </a>
                                                            <a href="Frmpagetorollbackworkingstatusupdatedonly_stageid36.aspx"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label2" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>SLC Rollback to update the Working Status  </a>
                                                            <a href="frmrollbacktoupdatechequedetails_slc.aspx"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label4" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>SLC Rollback to Section to update the cheque details again  </a>
                                                            <a href="frmRollbacktoReleasependingstage32_SLC.aspx"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label6" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>SLC Rollback to Release Pending Stage  </a>
                                                        </div>
                                                    </td>
                                                    <td style="width: 30px"></td>
                                                    <td valign="top" style="width: 395px">
                                                        <div class="list-group">
                                                            <%-- <a href="ListofSCLS.aspx?Stg=4" class="list-group-item">--%>
                                                            <%-- <a href="IncentiveWiseDIPClist.aspx?Stg=4" class="list-group-item"><span class="badge">--%>
                                                            <a href="DIPCApprovedlist.aspx?Stg=4" class="list-group-item"><span class="badge">
                                                                <asp:label id="lblDIPCReleasePendings" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Approved by DIPC </a>
                                                        </div>
                                                        <%--<div class="list-group">
                                                            <a href="IncentiveWiseDIPClist.aspx?Stg=2&offlineflag=Y" class="list-group-item"><span
                                                                class="badge">
                                                                <asp:Label ID="Label33" runat="server"></asp:Label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Approved by DLC (Legacy Data) </a>
                                                        </div>--%>
                                                        <div class="list-group">
                                                            <%-- <a href="ListofSCLS.aspx?Stg=5" class="list-group-item">--%>
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Releases</b></a>
                                                            <a href="ReleaseProcedingsStep2CompletedListPrintDIPC.aspx?stg=5" class="list-group-item">
                                                                <span class="badge">
                                                                    <asp:label id="Label17" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Print DIPC Release Proceedings Completed List </a>
                                                        </div>
                                                        <div class="list-group">
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>UC List</b></a> <a
                                                                href="frmCheckDetailsprintReprint.aspx?Stg=5&Status=UC&DIPCFlag=Y" class="list-group-item">
                                                                <span class="badge">
                                                                    <asp:label id="Label26" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Print-UC Updated List </a><a href="frmCheckDetailsprintReprint.aspx?Stg=6&Status=NUC&DIPCFlag=Y"
                                                                    class="list-group-item"><span class="badge">
                                                                        <asp:label id="Label27" runat="server"></asp:label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Print-UC Not Updated List </a>

                                                        </div>
                                                        <div class="list-group">
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Cheque Preparation List</b></a>
                                                            <a href="frmCheckDetailsprint.aspx?Stg=5&DIPCFlag=Y" class="list-group-item"><span
                                                                class="badge">
                                                                <asp:label id="lblGenCHeckListforDIPC" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Generate Cheque Preparation List for DIPC </a><a href="frmCheckDetailsprintGenerated.aspx?Stg=5&DIPCFlag=Y"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label18" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Generated Cheque Preparation List </a>
                                                            <a href="frmCheckDetailsprint_ROLLBACKEDCASES.aspx?Stg=5&DIPCFlag=Y" class="list-group-item"><span
                                                                class="badge">
                                                                <asp:label id="lblrollbackDIPC" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Generate Cheque Preparation List for DIPC-Rollbacked Cases </a>
                                                        </div>
                                                        <div class="list-group">
                                                            <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Update Cheque Details
                                                                New</b></a> <a href="UpdateCheckClearenceNew.aspx?Stg=53" class="list-group-item"><span
                                                                    class="badge">
                                                                    <asp:label id="Label33" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Enter UTR Details with Cheque No</a><a href="ChequeStatusNew.aspx?Stg=54" class="list-group-item"><span
                                                                    class="badge">
                                                                    <asp:label id="Label34" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>Cheque Status </a>
                                                            <a href="Frmpagetorollbackworkingstatusupdatedonly_stageid36DIPC.aspx"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label3" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>DIPC Rollback to update the Working Status  </a>
                                                            <a href="frmrollbacktoupdatechequedetails_DIPC.aspx"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label5" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>DIPC Rollback to Section to update the cheque details again  </a>
                                                            <a href="frmRollbacktoReleasependingstage32_DIPC.aspx"
                                                                class="list-group-item"><span class="badge">
                                                                    <asp:label id="Label7" runat="server"></asp:label>
                                                                </span><i class="fa fa-fw fa-calendar"></i>DIPC Rollback to Release Pending Stage  </a>
                                                            <%--<a href="UpdateUTRNumberListALL.aspx?Stg=52"
                                                                                class="list-group-item"><span class="badge">
                                                                                    <asp:Label ID="Label35" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                    </i>Cheque Details with UTR Number</a>--%>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <table cellpadding="2" style="width: 100%">
                                        <tr>
                                            <td style="width: 417px">
                                                <a href="IPO Login.doc" target="_blank">User Manual of IPO/DD/AD</a>
                                            </td>
                                </td>
                            </tr>--%>
                        </table>
                        </td> </tr> </table>
                        <asp:hiddenfield id="hdfID" runat="server" />
                        <asp:hiddenfield id="hdfFlagID" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:content>
