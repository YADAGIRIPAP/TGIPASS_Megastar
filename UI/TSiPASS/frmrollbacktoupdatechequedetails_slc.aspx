<%@ Page Language="C#"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  AutoEventWireup="true" CodeFile="frmrollbacktoupdatechequedetails_slc.aspx.cs" Inherits="UI_TSiPASS_frmrollbacktoupdatechequedetails_slc" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

        .style8 {
            height: 30px;
        }

        .style9 {
            width: 27px;
            height: 30px;
        }
        .auto-style1 {
            height: 16px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <script type="text/javascript">
        function RejectValidate() {
            return confirm('Do you want to reject the record ?');
        }

        function RejectValidate1() {
            return alert('Please enter the Remarks');
        }
        function RejectValidate2() {
            return alert('Record Deleted Sucessfully');
        }
    </script>
     <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>

    <style>
        .algnCenter {
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
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">View Applications</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                          <tr >
                                                                    <td style="padding: 5px; margin: 5px; font-weight: bold" valign="top">
                                                                        <table style="width: 100%">
                                                                            <tr>
                                                                                <td style="width: 20%">Release From Date
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                  <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>

                                                                                </td>
                                                                                <td style="width: 20%">Release To Date
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style1">&nbsp;
                                                                                </td>
                                                                                <td class="auto-style1">&nbsp;
                                                                                </td>
                                                                                <td class="auto-style1">&nbsp;
                                                                                </td>
                                                                                <td class="auto-style1">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Caste
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlcaste" runat="server" Height="33px" Width="180px">
                                                                                         <asp:ListItem>--Select--</asp:ListItem>
                                                                                         <asp:ListItem>General</asp:ListItem>
                                                                                         <asp:ListItem>SC</asp:ListItem>
                                                                                         <asp:ListItem>ST</asp:ListItem>
                                                                                         <asp:ListItem>PHC</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 20%">Incentive Name 
                                                                                </td>
                                                                                <td style="width: 100%">
                                                                                    <asp:DropDownList ID="ddlincentivename" runat="server" Height="33px" Width="180px">
                                                                                         <asp:ListItem>--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
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
                                                                                <td colspan="4" style="text-align: center">
                                                                                    <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                                                                        Text="GET Unit Details" Width="200px" ValidationGroup="group" OnClick="btnGet_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        ForeColor="#333333" Height="62px" ShowFooter="True"
                                                        Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            
                                                            <asp:BoundField DataField="NameofUnit" HeaderText="Unit Name" />
                                                            <asp:BoundField DataField="Address" HeaderText="Address" Visible="false" />
                                                            <asp:BoundField DataField="DCP" HeaderText="DCP Date" />
                                                            <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" />
                                                            <asp:BoundField DataField="SanctionedAmount" HeaderText="Sanctioned Amount" />
                                                            <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" />
                                                            <asp:BoundField DataField="MstIncentiveId" HeaderText="Sub Incentive ID" />
                                                            <asp:BoundField DataField="EnterperIncentiveID" HeaderText="Incentive ID" />
                                                            <asp:BoundField DataField="SLCNumer" HeaderText="SLC Number" />
                                                            <asp:BoundField DataField="Applicationno" HeaderText="Application Number" />
                                                           
                                                            <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                                                            <asp:BoundField DataField="District" HeaderText="District" />
                                                             <asp:BoundField DataField="Release Proceeding Number" HeaderText="Release Proceeding Number" />
                                                            <asp:BoundField DataField="ONLINE OR OFFLINE" HeaderText="ONLINE OR OFFLINE" />
                                                            <asp:BoundField DataField="WORKINGSTATUS" HeaderText="Working Status" />
                                                            <asp:BoundField DataField="WorkStatusUptDate" HeaderText="Working Status Updated Date" />
                                                            <asp:BoundField DataField="BankAccountRemarks" HeaderText="Bank Account Remarks" />

                                                            <asp:BoundField DataField="CHEQUE PRINTED DATE" HeaderText="CHEQUE PRINTED DATE" />
                                                            <asp:BoundField DataField="ACTUAL PRINTED DATE" HeaderText="ACTUAL PRINTED DATE" />
                                                            <asp:BoundField DataField="CheckNO" HeaderText="CHEQUE NUMBER" />
                                                            <asp:BoundField DataField="CHEQUE DATE" HeaderText="CHEQUE DATE" />
                                                            <asp:BoundField DataField="CheckAmount" HeaderText="CHEQUE AMOUNT"  Visible="false" />
                                                            <asp:BoundField DataField="UTR_NUMBER" HeaderText="UTR NUMBER" Visible="false"  />
                                                            <asp:BoundField DataField="UTR NUMBER ENTERED DATE" HeaderText="UTR NUMBER ENTERED DATE"  Visible="false" />
                                                            <asp:BoundField DataField="CHEQUE CLEARED DATE" HeaderText="CHEQUE CLEARED DATE"  Visible="false"  />                                                      

                                                            <asp:TemplateField HeaderText="Process">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnrollback" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                        Height="32px" OnClick="btnrollback_Click" OnClientClick="return confirm('Do you want to Rollback the record to update the cheque details again ? ');"
                                                                        TabIndex="10" Text="Rollback" ValidationGroup="group" Width="100px" />                                                                
                                                                    </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="STAGEID DISBURSEMENT TABLE" HeaderText="STAGEID DISBURSEMENT TABLE" Visible="false" />
                                                            <asp:BoundField DataField="STAGEID RELEASE TABLE" HeaderText="STAGEID RELEASE TABLE" Visible="false" />
                                                            <asp:BoundField DataField="STAGEID SANCTION TABLE" HeaderText="STAGEID SANCTION TABLE" Visible="false" />
                                                            <asp:BoundField DataField="OFFLINE DISBURSEMENT TABLE" HeaderText="OFFLINE DISBURSEMENT TABLE" Visible="false" />
                                                            <asp:BoundField DataField="OFFLINE RELEASE TABLE" HeaderText="OFFLINE RELEASE TABLE" Visible="false" />
                                                            <asp:BoundField DataField="OFFLINE SANCTION TABLE" HeaderText="OFFLINE SANCTION TABLE" Visible="false" />
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">&nbsp;<tr>
                                                    <td align="center" style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

