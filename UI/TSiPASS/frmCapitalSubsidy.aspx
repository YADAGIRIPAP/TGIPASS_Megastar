<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCapitalSubsidy.aspx.cs"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  Inherits="UI_TSiPASS_frmCapitalSubsidy" %>


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
        
        <ContentTemplate>

            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-edit"></i>
                    </li>
                </ol>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color: #339966">
                            <table class="nav-justified" style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="LBLCS" runat="server" Visible="false" Text="APPLICATION CUM VERIFICATION FOR CLAIMING CAPITAL SUBSIDY UNDER T IDEA—TELANGANA STATE PROGRAM FOR 
                                        RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME.(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)
                                        PART - A CLAIM">
                                        </asp:Label>
                                        <asp:Label ID="LBLCS1" runat="server" Visible="false" Text="APPLICATION CUM VERIFICATION FOR CLAIMING CAPITAL SUBSIDY REIMBURSEMENT UNDER T IDEA
(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR
ADVANCEMENT) INCENTIVE SCHEME 2014">
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
                        <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                        <%--<ContentTemplate>--%>
                        <div class="panel-body" align="left">
                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                <tr>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        <table cellpadding="4" cellspacing="5" style="width: 80%">

                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">1</td>
                                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Details of Capital Subsidy Investment</td>
                                            </tr>
                                            <tr id="trschemeEligible" runat="server">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.1
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Financial Year<font color="red">*</font>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:DropDownList ID="ddlcapitalsubsidyfinyear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="tr1" runat="server">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.2
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">1st/2nd Half Year<font color="red">*</font>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:DropDownList ID="ddlfirstorsecondhalfyear_CS" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">1st</asp:ListItem>
                                                        <asp:ListItem Value="2">2nd</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trgenSC1" runat="server">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.3
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Investment for the Current Financial Year<font color="red">*</font>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:TextBox ID="txtinvestment_currentfinyear" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                        Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px" ></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    &nbsp;</td>
                                            </tr>
                                            
                                            

                                        </table>
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                </tr>
                                <tr>                                   
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;"><b>DECLARATION :</b><br /><br />1. I / We hereby confirm that the contents of the claim application are true to the best of my /our knowledge.
                                    </td>
                                </tr>
                                <tr id="trisdeclare2_1" runat="server" visible="false">
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">2. I / We abide by the provision under T-IDEA,2014,incentive scheme, State Incentives and further abide by the changes / modifications made by the State Government under 
                                        G.O.Ms.No.28 Industries and Commerce (IP) Department., dated.29/11/2014. I / We also abide by the decisions of Industries & Commerce Department.
                                    </td>
                                </tr>
                                <tr id="trisdeclare2_2" runat="server" visible="false">
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">2. I / We abide by the provision under Industrial Investment Promotion Policy Scheme 2005-2010. State Incentives and further abide by the changes / modifications made by the State Government under 
                                        G.O.Ms.No.29, Industries & Commerce (IP&INF) Dept. dated 29.06.2010. I / We also abide by the decisions of Industries & Commerce Department.
                                    </td>
                                </tr>
                                <tr id="trisdeclare2_3" runat="server" visible="false">
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">2. I / We abide by the provision under Industrial Investment Promotion Policy Scheme 2010-2015. State Incentives and further abide by the changes / modifications made by the State Government under 
                                        G.O.Ms.No.61 Industries and Commerce (IP) Department., dated.29/06/2010. I / We also abide by the decisions of Industries & Commerce Department.
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">3. I / We shall not change the location of the whole or part of the industrial Enterprise or effect any substantial contraction or disposal of substantial part of its total capital investment within a period of six (6) years from the date of commencement of commercial production.
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">4. I / We assure that the State incentives (Capital subsidy) applied for will be used solely for the development of the Enterprise and shall produce utilisation certificate to the District Industries Centre (DIC) within one year and furnish annual progress report and certified copy of audited accounts to the DIC for a period of six (6) years.
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">5. I / We confirm that subsidy was already availed under the Government schemes mentioned at para No.2.0.
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">6. If the amount of Investment Subsidy are found to be disbursed in excess of the amount actually admissible whatsoever the reason, I/We hereby agree that I/We shall forthwith repay the amount released to me/us under the scheme.
                                    </td>
                                </tr>--%>
                                <%--<tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">7. I / We shall agree that apart from other consequences, I / We will forego the eligibility for the continuance of incentives and other financial concessions for further years if these incentives / financial concessions were obtained by misrepresentation of facts or in case of misutilisation. I / We not only agree to pay back these incentives / financial concessions but also authorise State Government to call back the same through summary proceedings under the provisions of R.R.Act 1864.
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                            TabIndex="10" Text="Submit" Width="90px" ValidationGroup="group" OnClick="BtnSave_Click" />
                                        &nbsp;&nbsp;
                                                    <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        TabIndex="10" Text="Previous" Width="90px" OnClick="BtnPrevious_Click" />
                                        &nbsp;
                                                    &nbsp;&nbsp;<asp:Button ID="BtnNext" runat="server" CssClass="btn btn-danger" Height="32px" Enabled="false"
                                                        TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" OnClick="BtnNext_Click" />

                                        &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                            Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                            Width="90px" OnClick="BtnClear_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong></strong>
                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--  </ContentTemplate>
                        </asp:UpdatePanel>--%>
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

    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet" type="text/css" />
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
