<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="SeedCap.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexure_SeedCap" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/basic.css" rel="stylesheet" />
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

        .style5 {
            color: #FF0000;
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
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8) {
                return true;
            }
            return false;
        }
    </script>
    <script type="text/javascript">
        function alpha(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
    <script type="text/javascript">
        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 6) {
                alert("Pin number length must be exactly 6 characters")
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload1" />
               <asp:PostBackTrigger ControlID="btnUpload2" />
        </Triggers>
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i></li>
                </ol>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color: #339966">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblheadTPRIDE" runat="server" Visible="false">
                                        </asp:Label>
                                        <asp:Label ID="lblheadTIDEA" runat="server" Visible="false">
                                        </asp:Label>
                                    </td>

                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnUpload1" />
                            </Triggers>
                            <ContentTemplate>
                                <div class="panel-body" align="left">
                                    <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                        <tr id="tramtclaimed" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Amount of Subsidy claimed in Rs.<font color="red">*</font>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtAmtSubClaimed" runat="server" class="form-control txtbox" onkeypress="inputOnlyNumbers(evt)"
                                                    Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAmtSubClaimed"
                                                    ErrorMessage="Please enter Amount of  Subsidy claimed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: center;">
                                                <table style="width: 80%">
                                                    <tr>
                                                        <td colspan="4" align="left" style="padding: 5px; margin: 5px; font-weight: bold"
                                                            valign="middle">Enclosures
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center">Sl.No
                                                        </td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center">Document Name
                                                        </td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center">Upload Document
                                                        </td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center">File Name
                                                        </td>
                                                    </tr>
                                                    <tr id="tr1" runat="server">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">1
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black; text-align: left;">Sanction letter of term loan and seed capital loan from Financial Institution
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:FileUpload ID="fuDocuments1" runat="server" />
                                                            <asp:Button ID="btnUpload1" runat="server" Text="Click here to Upload" OnClick="btnUpload1_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:HyperLink ID="lblUpload1" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[lblFileName]</asp:HyperLink>
                                                            <asp:Label ID="lblAttachedFileName1" runat="server" Font-Bold="true" ForeColor="Green"
                                                                Visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr2" runat="server">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">1
                                                        </td>
                                                        <td style="border: solid thin black; background: white; color: black; text-align:left" > CA Certificate as per prescribed format
                                        <asp:HyperLink ID="HyperLinkCivilEngineersFormat" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/Seed Capital CA Format.pdf">Click here for Prescribed Format</asp:HyperLink>
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:FileUpload ID="fuDocuments2" runat="server" />
                                                            <asp:Button ID="btnUpload2" runat="server" Text="Click here to Upload" OnClick="btnUpload2_Click"  />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:HyperLink ID="lblUpload2" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                            <asp:Label ID="lblAttachedFileName2" runat="server" Font-Bold="true" ForeColor="Green"
                                                                Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>DECLARATION :  </b>
                                                <br />
                                                I / We hereby confirm that to the best of our knowledge and belief, information given herein
before and other papers enclosed are true and correct in all respects. We further undertake to
substantiate the particulars about promoter(s) and other details with documentary evidence as
and when called for.<br />
                                                I/We hereby agree that I/We shall forthwith repay the amount to me/us under  &nbsp;<asp:Label ID="lblscheme" runat="server"></asp:Label>
                                &nbsp;, if the
amount of seed capital assistance are found to be disbursed in excess of the amount actually
admissible whatsoever the reason.

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    TabIndex="10" Text="Submit" Width="90px" ValidationGroup="group" OnClick="BtnSave_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-danger" Height="32px"
                                                    TabIndex="10" Text="Previous" Width="90px" OnClick="BtnPrevious_Click" />
                                                &nbsp; &nbsp;&nbsp;<asp:Button ID="BtnNext" runat="server" CssClass="btn btn-danger"
                                                    Height="32px" TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" Enabled="false"
                                                    OnClick="BtnNext_Click" />
                                                &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px"
                                                    OnClick="BtnClear_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--  </div>--%>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
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

            $("input[id$='txtRegDate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtRegDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 200px;
        }
    </style>
</asp:Content>
