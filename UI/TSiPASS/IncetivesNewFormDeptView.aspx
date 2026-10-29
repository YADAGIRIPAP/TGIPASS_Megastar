<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncetivesNewFormDeptView.aspx.cs" Inherits="UI_TSiPASS_IncetivesNewFormDeptView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {

            var f = $('#ctl00_ContentPlaceHolder1_hdnfocus').val();
            if (f != "") {
                $('#' + f).focus();
            }
        }
        function ConfirmSave() {
            var x = confirm("Please Confirm whether the Entered Details are Correct");
            if (x)
                return true;
            else
                return false;
        }
    </script>
    <script type="text/javascript">
        var newWindow = null;
        function PopupCenter(url, title, w, h) {
            if (newWindow == null) {
                // Fixes dual-screen position                         Most browsers      Firefox  
                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                newWindow = window.open(url, title, 'scrollbars=yes,status=no,toolbar=no,menubar=no,location=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                // Puts focus on the newWindow  
                if (window.focus) {
                    newWindow.focus();
                }
                freezeParentPage();
            }
        }
        function freezeParentPage() {
            var divRef = document.getElementById('ModalBackgroundDiv');

            if (divRef != null) {
                divRef.style.display = 'block';

                if (document.body.clientHeight > document.body.scrollHeight) {
                    divRef.style.height = document.body.clientHeight + 'px';
                }
                else {
                    divRef.style.height = document.body.scrollHeight + 'px';
                }
                divRef.style.width = '100%';
            }
        }

    </script>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!--WIZARD STYLES-->
    <link href="assets/css/wizard/normalize.css" rel="stylesheet" />
    <link href="assets/css/wizard/wizardMain.css" rel="stylesheet" />
    <link href="assets/css/wizard/jquery.steps.css" rel="stylesheet" />

    <!--CUSTOM BASIC STYLES-->
    <%-- <link href="assets/css/basic.css" rel="stylesheet" />--%>
    <!--CUSTOM MAIN STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">

    <style type="text/css">
        .wizard > .content {
            height: 650px;
        }

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

        .lblinv {
            font-weight: bolder;
            color: Red;
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

        .textboxPge {
            border: 1px solid #c4c4c4;
            height: 30px;
            width: 140px;
            font-size: 13px;
            padding: 4px 4px 4px 4px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            box-shadow: 0px 0px 8px #d9d9d9;
            -moz-box-shadow: 0px 0px 8px #d9d9d9;
            -webkit-box-shadow: 0px 0px 8px #d9d9d9;
        }

            .textboxPge:focus {
                outline: none;
                border: 1px solid #7bc1f7;
                box-shadow: 0px 0px 8px #7bc1f7;
                -moz-box-shadow: 0px 0px 8px #7bc1f7;
                -webkit-box-shadow: 0px 0px 8px #7bc1f7;
            }
    </style>
    <style type="text/css">
        .tooltipDemo {
            position: relative;
            display: inline;
            text-decoration: none;
            left: 0px;
            top: 0px;
        }

            .tooltipDemo:hover:before {
                border: solid;
                border-color: transparent rgb(111, 13, 53);
                border-width: 6px 6px 6px 0px;
                bottom: 21px;
                content: "";
                left: 35px;
                top: 5px;
                position: absolute;
                z-index: 95;
            }

            .tooltipDemo:hover:after {
                /*background: rgb(111, 13, 53);*/
                background: #2184be;
                border-radius: 5px;
                color: #fff;
                width: 300px;
                left: 40px;
                top: -5px;
                content: attr(alt);
                position: absolute;
                padding: 5px 15px;
                z-index: 95;
            }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <input type="hidden" id="hdnfocus" value="" runat="server" />
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#"></a></li>
        </ol>
    </div>
    <div>
        <table style="width: 100%">
            <tr>
                <td align="center" colspan="8" style="padding: 5px; margin: 5px">
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
    <!-- /. ROW font-weight: bold; -->
    <div class="row">
    </div>
    <div>
        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; background-color: #d9d9d9">
            <tr>
                <td>
                    <table style="width: 100%; background-color: #d9d9d9">
                        <tr>
                            <td>
                                <table style="width: 100%">
                                    <tr>
                                        <td colspan="9" style="height: 50px; font-weight: bold">Details of the Enterprise</td>
                                    </tr>
                                    <tr id="trr" runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px; text-align: left;">1
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Type of Sector : 
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddltypeofsector" runat="server"></asp:Label>
                                        </td>

                                        <td style="padding: 5px; margin: 5px; vertical-align: middle;">2
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">EM / Udyog Aadhar No  : 
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtudyogAadharNo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">1
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Unit Name : 
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                        </td>

                                        <td style="padding: 5px; margin: 5px; vertical-align: middle;">2
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Applicant Name : 
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">3
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">TIN Number 
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                        </td>

                                        <td style="padding: 5px; margin: 5px; vertical-align: middle;">4
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">PAN Number
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left">
                                            <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;" colspan="8"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" colspan="4">Unit Address
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" colspan="4">Office Address
                                        </td>
                                    </tr>
                                    <tr id="rem" runat="server">
                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">5
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">District
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddldistrictunit" runat="server">                                            
                                            </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">6
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">District&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddldistrictoffc" runat="server">                                                        
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="Tr13" runat="server">
                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mandal</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddlUnitMandal" runat="server">                                                      
                                            </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mandal</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddloffcmandal" runat="server">                                                      
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="Tr14" runat="server">
                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Village</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddlVillageunit" runat="server">                                                      
                                            </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Village</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddlvilloffc" runat="server">                                                       
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="Tr15" runat="server">
                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">House No.</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtunitaddhno" runat="server">                                                                                
                                            </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">House No.</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtoffaddhnno" runat="server">                                                                    
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="Tr16" runat="server">
                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Street</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtstreetunit" runat="server">                                                                                
                                            </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Street</td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtstreetoffice" runat="server">                                                                    
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" align="center">7
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">Mobile Number
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" align="center">8</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">Mobile Number
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" align="center">9
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">Email Id
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtunitemailid" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" align="center">10</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">Email Id
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" colspan="9">Status</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px;">7
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Category&nbsp; 
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddlCategory" runat="server">                                                        
                                            </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">8</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Type of Organization
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddltypeofOrg" runat="server">                                                       
                                            </asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="padding: 5px; margin: 5px;">9
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Industry Status 
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddlindustryStatus" runat="server">                                                      
                                            </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">10</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Social Status
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="lblSocialStatus" runat="server">                                                        
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <table style="width: 100%">
                                    <tr id="trNewIndustry" runat="server" visible="false">
                                        <td colspan="9" align="left">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; height: 50px" valign="middle">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True">NEW ENTERPRISES</asp:Label>
                                                    </td>
                                                    <td style="width: 57px">&nbsp;</td>
                                                    <td valign="top">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                        <asp:GridView ID="gvInstalledCap" runat="server" AutoGenerateColumns="false"
                                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                            CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                            Width="100%">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>
                                                                <asp:BoundField DataField="LineofActivity" HeaderText="Line Of Activity" />
                                                                <asp:BoundField DataField="NameofUnit" HeaderText="Unit" />
                                                                <asp:BoundField DataField="InstalledCapacity" HeaderText="Installed Capacity" />
                                                                <asp:BoundField DataField="Value" HeaderText="Value" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#013161" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%--   <tr id="trexpansion" runat="server" visible="false">
                                                <td colspan="9">
                                                    <table>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                <asp:Label ID="Label424" runat="server">EXPANSION/DIVERSIFICATION PROJECT<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="width: 27px">&nbsp;</td>
                                                            <td valign="top">&nbsp;</td>
                                                        </tr>
                                                
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                                <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                                    CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                                    Width="100%"
                                                                    DataKeyNames="intLineofActivityMid" OnRowDataBound="gvCertificate_RowDataBound" >
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                        <asp:BoundField DataField="Column1" HeaderText="Enterprise Type" />
                                                                        <asp:BoundField DataField="Column2" HeaderText="Line Of Activity" />
                                                                        <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                        <asp:BoundField DataField="Column4" HeaderText="% of increase under Expansion/Diversification" />
                                                                    </Columns>
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#013161" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trFixedcap" runat="server" visible="true">
                                                <td colspan="9">
                                                    <table>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                <asp:Label ID="Label6" runat="server" >FIXED CAPITAL INVESTMENT(IN RS)</asp:Label>
                                                            </td>
                                                            <td style="width: 27px">&nbsp;</td>
                                                            <td valign="top">&nbsp;</td>
                                                        </tr>                                                        
                                 <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                                    CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                                    Width="100%"
                                                                    DataKeyNames="intLineofActivityMid" OnRowDataBound="GridView2_RowDataBound" >
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                        <asp:BoundField DataField="Column1" HeaderText="Nature of Assets" />
                                                                        <asp:BoundField DataField="Column2" HeaderText="Existing Enterprise" />
                                                                        <asp:BoundField DataField="Column3" HeaderText="Capacity" />
                                                                        <asp:BoundField DataField="Column4" HeaderText="% of increase under Expansion/Diversification" />
                                                                    </Columns>
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />                                                                   
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                    <tr id="trexpansion" runat="server" visible="false">
                                        <td colspan="9">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" colspan="9"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; height: 50px" valign="middle" colspan="9">
                                                        <asp:Label ID="Label424" runat="server" Font-Bold="True">EXPANSION/DIVERSIFICATION PROJECT</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin white; background: #013161; color: white" align="center"></td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Line Of Activity</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Installed Capacity</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">% of increase under
                                                        <br />
                                                        Expansion/Diversification</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin black; background: white; color: black">Existing Enterprise</td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="EEloa" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="eeInstalledCap" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="eePercentage" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin black; background: white; color: black">Expansion/Diversification
                                            <br />
                                                        Project</td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="EDPloa" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="edpInstalledCapacity" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="edpPercentage" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trFixedcap" runat="server" visible="true">
                                        <td colspan="9">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" colspan="9"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; height: 50px" valign="middle" colspan="9">
                                                        <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Font-Bold="True">FIXED CAPITAL INVESTMENT(IN Rs.)</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin white; background: #013161; color: white" align="center">Nature of Assets</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Existing Enterprise</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Capacity</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">% of increase under
                                            <br />
                                                        Expansion/Diversification</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin black; background: white; color: black">Land</td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="LandEE" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="LandExpansionDiversification" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="landPercentage" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin black; background: white; color: black">Building</td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="BuildingEE" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="BuildingLandExpansionDiversification" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="BuildigPercentage" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin black; background: white; color: black">Plant & Machinery</td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="PlantMachineryEE" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="PlantMachLandExpansionDiversification" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="center" style="border: solid thin black">
                                                        <asp:Label ID="PlantMachpercentage" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" colspan="9"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%">
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td colspan="9" align="left">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; font-weight: bold; height: 50px" valign="middle" colspan="8">
                                            <asp:Label ID="Label12" runat="server">Details of the Director(s)/ Partner(s)</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="8">
                                            <asp:GridView ID="gvDirectorDetails" runat="server" AutoGenerateColumns="False"
                                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                Width="100%">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="Community" HeaderText="Community" />
                                                    <asp:BoundField DataField="Share" HeaderText="Share" />
                                                    <asp:BoundField DataField="Percentage" HeaderText="%" />
                                                </Columns>
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;"><strong>Power :
                                            <asp:Label ID="ddlPowerStatus" runat="server"></asp:Label></strong></td>
                                    </tr>
                                    <tr id="trpower1" runat="server" visible="false">
                                        <td>
                                            <table>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">1
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Power Released Date : 
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtpowerReleasedate" runat="server"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;">2
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Contracted load : 
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtcontractedload" runat="server"></asp:Label>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">3
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Connected load 
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtconnectedload" runat="server"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">4
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Service Connection Number
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtServiceConnectionNumber" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trpower2" runat="server" visible="false">
                                        <td>
                                            <table style="width: 100%; font-weight: bold;">
                                                <tr>
                                                    <td colspan="8" style="border: solid thin white; background: #013161; color: white; height: 40px" align="left">
                                                        <asp:Label ID="lblexistingpower" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">1
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Power Released Date
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtExistingPowerReleaseDate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;">3
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Contracted load (In HP)
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtExistingContractedLoad" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">2&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Connected load (In HP)
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtExistingConnectedLoad" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">4
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Service Connection Number
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtExistingServiceConnectionNO" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="8" style="border: solid thin white; background: #013161; color: white; height: 40px" align="left">
                                                        <asp:Label ID="lblexpandiverpower" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">1
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Power Released Date
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtExpanDiverPowerReleaseDate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;">3
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Contracted load (In HP)
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtExpanDiverContractedLoad" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">2&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Connected load (In HP)
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtExpanDiverConnectedLoad" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">4
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Service Connection Number
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtExpanDiverServiceConnectionNO" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" align="center" colspan="9">Employment
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: solid thin white; background: #013161; color: white; border: solid thin black" align="center"></td>
                                        <td style="border: solid thin white; background: #013161; color: white; border: solid thin black" align="center"></td>
                                        <td style="border: solid thin white; background: #013161; color: white; border: solid thin black" align="center">Male(Nos)
                                        </td>
                                        <td style="border: solid thin white; background: #013161; color: white; border: solid thin black" align="center">Female(Nos)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">1
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">Management & Staff 
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                            <asp:Label ID="txtstaffMale" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                            <asp:Label ID="txtStaffFemale" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">2
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">Supervisory 
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                            <asp:Label ID="txtSuprMale" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">&nbsp;<asp:Label ID="txtSuperFemale" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">3
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">Skilled workers
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                            <asp:Label ID="txtSkilledWorkersMale" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                            <asp:Label ID="txtSkilledWorkersFemale" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">4
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">Semi-skilled workers
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                            <asp:Label ID="txtSemiSkilledWorkersMale" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                            <asp:Label ID="txtSemiSkilledWorkersFemale" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" colspan="9">Implementation Steps Taken 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">1
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Project Finance
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtprjfinance" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px; vertical-align: middle;">2
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Date of application for Term Loan
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtTermloan" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Name of the Institution
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtnmofinstitution" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px; vertical-align: middle;">4
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Term Loan Sanctioned reference No.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtsactionedloan" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; vertical-align: middle;">5
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Term Loan Sanctioned Date
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="txtInstallDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; vertical-align: middle;"></td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Have you availed subsidy earlier
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="ddlsubsidy" runat="server">  
                                            </asp:Label>
                                        </td>
                                    </tr>

                                    <%--<tr id="trsubidy" runat="server" visible="true">
                            <td colspan="9">
                                <table style="width: 100%">                                   
                                    <tr>
                                        <td colspan="9" style="padding: 5px; margin: 5px; text-align: left; height: 50px; font-weight:bold;">Total Amount of subsidy already availed</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Scheme
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:label id="txtSubsidyScheme" runat="server"></asp:label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 1px"></td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Amount
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 1px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:label id="txtSubsidyAmount" runat="server"></asp:label>
                                        </td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>--%>
                                    <tr>
                                        <td style="height: 30px"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <%--kkkk--%>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="border: solid thin white; background: #013161; color: white" align="center">Second hand machinery
                                                                                                    <br />
                                                        value in Rs</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">New machinery value in Rs</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Total value in Rs<br />
                                                        (1+2)</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">% of second hand machinery
                                                                                        <br />
                                                        value in total machinery value</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Value of the machinery
                                                                                        <br />
                                                        purchaced from APIDC<br />
                                                        (Telangana unit)/APSFC
                                                                                        <br />
                                                        (Telangana unit)/Bank in Rs</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Total value in Rs
                                                                                        <br />
                                                        (2+5)</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">1</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">2</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">3</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">4</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">5</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">6</td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txt2ndMachVal" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtNewMachVal" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtNewand2ndlMachVal" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txt2ndMachPercValue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtPurchasedMachValbyBank" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtTotalMachVal" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white; height: 1px" colspan="6"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr id="tr1" runat="server" visible="true">
                            <td align="left">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; height: 50px" valign="middle" colspan="10">
                                            <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Font-Bold="True">Approved/Estimated projected cost, term loan sanctioned and released, assets acquired etc</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Name of Asset&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Approved Project Cost                                                                                                    
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Loan Sanctioned</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Equity from the promoters
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Loan Amount Released
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Value of assets  
                                                        <br />
                                                        (as certified by financial<br />
                                                        institution)
                                                    </td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">Value of assets 
                                                        <br />
                                                        certified by Chartered Accoutant                                                                                         
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">1</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">2&nbsp;</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">3</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">4</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">5</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">6</td>
                                                    <td align="center" style="border: solid thin white; background: #013161; color: white">7</td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">Land</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtLand2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtLand3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtLand4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtLand5" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtLand6" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtLand7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">Buildings</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtBuilding2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtBuilding3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtBuilding4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtBuilding5" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtBuilding6" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="txtBuilding7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">Plant & Machinery</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="PM2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="PM3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="PM4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="PM5" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="PM6" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="PM7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">Machinery Contingencies</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="MCont2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="MCont3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black; margin-left: 160px;">
                                                        <asp:Label ID="MCont4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="MCont5" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="MCont6" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="MCont7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">Erection</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Erec2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Erec3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Erec4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Erec5" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Erec6" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Erec7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">Technical know-how,<br />
                                                        feasibility study</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="TFS2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="TFS3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="TFS4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="TFS5" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="TFS6" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="TFS7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; background: white; color: black">Working Capital</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="WC2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="WC3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="WC4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="WC5" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="WC6" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="WC7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td style="border: solid thin black; background: white; color: black">Total</td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Tot2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Tot3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Tot4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Tot5" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Tot6" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="border: solid thin black; background: white; color: black">
                                                        <asp:Label ID="Tot7" runat="server"></asp:Label>
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 100%">Note : The data on the above should be prior to date of filing of claim or within 6 months of Commencement of Production,
                                                                                whichever is earlier in case of aided Enterprise/Industry. If it is self financed Enterprise/Industry, the data on the above
                                                                                <br />
                                                        should be prior to date of commencement of Commercial Production.
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                </table>
                                <table style="width: 100%">
                                    <tr id="tris3" runat="server" visible="false">
                                        <td></td>
                                    </tr>
                                    <%--<tr id="tris4" runat="server" visible="false">
                                                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left;">Incentives applied for (In Rs.) on fixed capital investments</td>
                                                                        </tr>--%>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                            <span style="font-weight: bold;">Bank Details</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">1
                                                    </td>
                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">Name of Bank
                                                    </td>
                                                    <td class="style21" style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="ddlBank" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">2
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Branch Name<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtBranchName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <%--<td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                    </td>--%>
                                                    <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">3
                                                    </td>
                                                    <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                    <td class="style21" style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtAccNumber" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">4
                                                    </td>
                                                    <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">IFSC Code<%--<span style="font-weight: bold; color: Red;">*</span>--%>

                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="txtIfscCode" runat="server"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">&nbsp;</td>
                                                    <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Whether you have Power Connection Incentive</td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="ddlPower" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3">&nbsp;</td>
                                                </tr>
                                                <tr runat="server" id="powertr" visible="false">
                                                    <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">&nbsp;</td>
                                                    <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Request to Department</td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="TxtRequesttoDepartment" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 50px"></td>
                                    </tr>
                                    <tr>
                                        <td align="center">

                                            <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-danger" Height="32px"
                                                TabIndex="10" Text="Previous" Width="90px" OnClick="BtnPrevious_Click" Visible="false" />
                                            &nbsp;
                                                    &nbsp;&nbsp;<asp:Button ID="BtnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" OnClick="BtnNext_Click" />

                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%--<table>
                        <tr>
                            <td>
                                <table style="width: 100%">
                                    <tr>
                                        <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight:bold;height:50px; vertical-align:middle">
                                            Incentives applied for (In Rs.) on fixed capital investments</td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">1 </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Investment Subsidy </td>
                                                    <td style="padding: 5px; margin: 5px">: </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Rs.
                                                        <asp:label id="txtInvestSubsidy" runat="server"></asp:label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;">2 </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">An additional insvestment subsidy for <br /> women enterpreneurs </td>
                                                    <td style="padding: 5px; margin: 5px">: </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Rs.
                                                        <asp:label id="txtInvestSubsidyWomen" runat="server"></asp:label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">An additional investment subsidy for SC/ST enterpreneurs </td>
                                                    <td style="padding: 5px; margin: 5px">: </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Rs.
                                                        <asp:label id="txtInvestSubsidySCST" runat="server"></asp:label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp; </td>
                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;">4 </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">An additional insvestment subsidy for women <br /> enterpreneurs setup in sheduled areas </td>
                                                    <td style="padding: 5px; margin: 5px">: </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Rs.
                                                        <asp:label id="txtInvestSubsidyScheduledAreas" runat="server"></asp:label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;"></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;"><strong>Total</strong></td>
                                                    <td style="padding: 5px; margin: 5px">: </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Rs.
                                                    <asp:label id="txtTotalInvestApplied" runat="server"></asp:label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>--%>
                </td>
            </tr>
        </table>
    </div>
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
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- WIZARD SCRIPTS -->
    <script src="assets/js/wizard/modernizr-2.6.2.min.js"></script>
    <script src="assets/js/wizard/jquery.cookie-1.3.1.js"></script>
    <script src="assets/js/wizard/jquery.steps.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>


    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>

    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>

    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>

    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>

    <%--<script src="../../Resource/js/bootstrap.min.js"></script>   
    <script src="../../Resource/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris-data.js"></script>--%>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />

</asp:Content>
