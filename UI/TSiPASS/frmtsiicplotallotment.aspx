<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmtsiicplotallotment.aspx.cs" Inherits="UI_TSIPASS_frmtsiicplotallotment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
                return tr
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
    <style type="text/css">
        .blink {
            -webkit-animation-name: blink;
            -webkit-animation-iteration-count: infinite;
            -webkit-animation-timing-function: cubic-bezier(1.0,0,0,1.0);
            -webkit-animation-duration: 1s;
        }
    </style>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- BOOTSTRAP STYLES-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
   -<%--<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>--%>

   
   
    <style type="text/css">
        .nav > li > a {
            padding: 10px 6px !important;
        }

        .nav-pills.nav-wizard > li {
            position: relative;
            overflow: visible;
            border-right: 15px solid transparent;
            border-left: 15px solid transparent;
        }

            .nav-pills.nav-wizard > li + li {
                margin-left: 0;
            }

            .nav-pills.nav-wizard > li:first-child {
                border-left: 0;
            }

                .nav-pills.nav-wizard > li:first-child a {
                    border-radius: 5px 0 0 5px;
                }

            .nav-pills.nav-wizard > li:last-child {
                border-right: 0;
            }

                .nav-pills.nav-wizard > li:last-child a {
                    border-radius: 0 5px 5px 0;
                }

            .nav-pills.nav-wizard > li a {
                border-radius: 0;
                background-color: #eee;
            }

            .nav-pills.nav-wizard > li:not(:last-child) a:after {
                position: absolute;
                content: "";
                top: 0px;
                right: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: transparent transparent transparent #eee;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:not(:first-child) a:before {
                position: absolute;
                content: "";
                top: 0px;
                left: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: #eee #eee #eee transparent;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:hover:not(:last-child) a:after {
                border-color: transparent transparent transparent #aaa;
            }

            .nav-pills.nav-wizard > li:hover:not(:first-child) a:before {
                border-color: #aaa #aaa #aaa transparent;
            }

            .nav-pills.nav-wizard > li:hover a {
                background-color: #aaa;
                color: #fff;
            }

            .nav-pills.nav-wizard > li.active:not(:last-child) a:after {
                border-color: transparent transparent transparent #428bca;
            }

            .nav-pills.nav-wizard > li.active:not(:first-child) a:before {
                border-color: #428bca #428bca #428bca transparent;
            }

            .nav-pills.nav-wizard > li.active a {
                background-color: #428bca;
            }

        .body {
            font-size: 10pt !important;
        }


        .file-preview-input {
            position: relative;
            overflow: hidden;
            margin: 0px;
            color: #333;
            background-color: #fff;
            border-color: #ccc;
        }

            .file-preview-input input[type=file] {
                position: absolute;
                top: 0;
                right: 0;
                margin: 0;
                padding: 0;
                font-size: 20px;
                cursor: pointer;
                opacity: 0;
                filter: alpha(opacity=0);
            }

        .file-preview-input-title {
            margin-left: 2px;
        }

        .file {
            visibility: hidden;
            position: absolute;
        }


        .progressBar {
            width: 300px;
            height: 22px;
            /*border: 1px solid #ddd;
            border-radius: 5px;*/
            overflow: hidden;
            display: block;
            margin: 0px 10px 5px 5px;
            vertical-align: top;
        }

            .progressBar div {
                height: 100%;
                color: #fff;
                text-align: center;
                /*line-height: 22px;*/ /* same as #progressBar height if we want text middle aligned */
                width: 0;
                background-color: #0ba1b5;
                border-radius: 3px;
            }

        .statusbar {
            border-top: 1px solid #A9CCD1;
            min-height: 25px;
            /*width: 700px;*/
            padding: 10px 10px 0px 10px;
            vertical-align: top;
        }

        /*.statusbar:nth-child(odd) {
            background: #EBEFF0;
        }*/

        .filename {
            display: inline-block;
            vertical-align: top;
            width: 300px;
            overflow: hidden;
        }

        .input-group-sm input[type=date], .input-group-sm input[type=time], .input-group-sm input[type=datetime-local], .input-group-sm input[type=month], input[type=date].input-sm, input[type=time].input-sm, input[type=datetime-local].input-sm, input[type=month].input-sm {
            line-height: 30px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .col-xs-12 {
            width: 100%;
        }

        .filesize {
            display: inline-block;
            vertical-align: top;
            color: #30693D;
            width: 100px;
            margin-left: 10px;
            margin-right: 5px;
        }

        .abort {
            background-color: #A8352F;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
            display: inline-block;
            color: #fff;
            font-family: arial;
            font-size: 13px;
            font-weight: normal;
            padding: 4px 15px;
            cursor: pointer;
            vertical-align: top;
        }

        .button {
            background-color: #004A7F;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: none;
            color: #FFFFFF;
            cursor: pointer;
            display: inline-block;
            font-family: Arial;
            font-size: 15px;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
        }

        @-webkit-keyframes glowing {
            0% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -webkit-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }
        }

        @-moz-keyframes glowing {
            0% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -moz-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }
        }



        @keyframes glowing {
            0% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }
        }

        .button {
            -webkit-animation: glowing 1500ms infinite;
            -moz-animation: glowing 1500ms infinite;
            -o-animation: glowing 1500ms infinite;
            animation: glowing 1500ms infinite;
        }

        .wizard > .content {
            height: 850px;
            width: 1085px;
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

        .LBLBLACK {
            top: 0px;
            left: 0px;
        }


        /*.auto-style1 {
            width: 288px;
        }

        .auto-style2 {
            width: 277px;
        }*/
    </style>

    <script  type="text/javascript" src="../../js/UploadImage.js"></script>

    <script type="text/javascript" language="javascript">


        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script> 
        function AvoidSpace() {
            if (event.keyCode == 32) {
                event.returnValue = false;
                return false;
            }
        }
    </script> 
    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
    </script>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <Triggers>
                              <asp:PostBackTrigger ControlID="BtnSave3" />
                             <asp:PostBackTrigger ControlID="BtnSave4" />
             

</Triggers>
        <ContentTemplate>
            <div>
                <table style="width: 100%">
                    <tr>
                        <td>

                          
                            <ul class="nav nav-pills nav-wizard">
                                <li class="active" id="Tab1" runat="server"><a href="#" data-toggle="tab">1. Plot
                                Details</a></li>
                                <li id="Tab2" runat="server"><a href="#" data-toggle="tab">2. Verify Firm Details</a></li>
                                <li id="Tab3" runat="server"><a href="#" data-toggle="tab">3. Verify promoter Details</a></li>
                                <li id="Tab4" runat="server"><a href="#" data-toggle="tab">4. Enter Project Details</a></li>

                                <li id="Tab5" runat="server"><a href="#" data-toggle="tab">5. Enter Land Details</a></li>
                           

                              
                              
                            </ul>


                            
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:MultiView ID="MainView" runat="server">
                              
                           
                                    <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="background-color: #f4f4f4" align="center">
                                                <table style="width: 95%">
                                                    <tr style="height: 20px">
                                                        <td></td>
                                                    </tr>
                                                    <%--<tr style="height: 40px; padding: 5px; margin: 5px">
                                                <td align="left" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Select Plot
                                                </td>
                                            </tr>--%>
                                                    <tr style="height: 3px">
                                                        <td style="background-color: white"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table style="width: 100%; background-color: #afffc3">
                                                                <tr style="height: 15px">
                                                                    <td></td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="width: 4%"></td>
                                                                    <td style="width: 15%">District
                                                                    </td>
                                                                    <td style="width: 2%">:
                                                                    </td>
                                                                    <td style="width: 25%">
                                                                        <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox" AutoPostBack="true"
                                                                            Height="33px" Width="180px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">--District--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="width: 4%"></td>
                                                                    <td style="width: 15%">Industrial Park
                                                                    </td>
                                                                    <td style="width: 2%">:
                                                                    </td>
                                                                    <td style="width: 25%">
                                                                        <asp:DropDownList ID="ddlIndustrialParkName" runat="server" class="form-control txtbox"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 80px">
                                                                    <td align="center" colspan="12" valign="middle">
                                                                        <asp:Button Text="Go" Height="35px" Width="120px" Font-Size="Large" CssClass="btn btn-primary"
                                                                            ForeColor="White" ID="btntab1next" runat="server" OnClick="btntab1next_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%; background-color: white" colspan="12" align="center">
                                                                        <table style="width: 70%; background-color: white">
                                                                            <tr style="height: 30px">
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="width: 4%"></td>
                                                                                <td style="width: 30%" align="left">Select Plot
                                                                                </td>
                                                                                <td style="width: 2%">:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlavailableplots" runat="server" class="form-control txtbox" AutoPostBack="true"
                                                                                        Height="33px" Width="220px" OnSelectedIndexChanged="ddlavailableplots_SelectedIndexChanged">
                                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>

                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="width: 4%"></td>
                                                                                <td style="width: 30%" align="left">Area (In Sq. Mtrs)
                                                                                </td>
                                                                                <td style="width: 2%">:
                                                                                </td>
                                                                                <td id="tdAreasqrmtrs" runat="server" align="left"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="width: 4%"></td>
                                                                                <td style="width: 30%" align="left">Price(Rs. Per Sq. Mtrs)
                                                                                </td>
                                                                                <td style="width: 2%">:
                                                                                </td>
                                                                                <td id="tdrssqmtrs" runat="server" align="left"></td>
                                                                            </tr>
                                                                            <tr style="height: 30px">
                                                                                <td></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="width: 100%; background-color: white; color: red" colspan="12" align="center">Note: In Case of smaller plot area is required, please contact Zonal manager to examine the feasibility of Sub-Division
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 10px; background-color: white;">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Button ID="BtnAddSelectedplos" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                TabIndex="10" Text="Add to My Selected Plots"
                                                                Width="220px" OnClick="BtnAddSelectedplos_Click" />
                                                            &nbsp;&nbsp;&nbsp;
                                              <asp:Button ID="PlotsReset" runat="server" CssClass="btn btn-primary" Height="32px"
                                                  TabIndex="10" Text="Reset"
                                                  Width="100px" OnClick="PlotsReset_Click" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="width: 100%">
                                                                <tr style="height: 40px">
                                                                    <td colspan="4" align="left" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Selected Plot(s)
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 3px">
                                                                    <td colspan="4">
                                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                            ForeColor="#333333" Height="62px"
                                                                            Width="100%" OnRowDataBound="grdDetails_RowDataBound" OnRowCommand="grdDetails_RowCommand" OnRowDeleting="grdDetails_RowDeleting">
                                                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                                                <asp:BoundField DataField="distid" HeaderText="District" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField DataField="indparkid" HeaderText="Industrial Park" ItemStyle-HorizontalAlign="Left" />
                                                                                <asp:BoundField DataField="plotno" HeaderText="Plot No" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField DataField="sqmts" HeaderText="Area (In Sq. Mtrs)" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:BoundField DataField="price" HeaderText="Price (In Rs.)" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:BoundField DataField="emd" HeaderText="EMD (In Rs.)" ItemStyle-HorizontalAlign="Right" />
                                                                                <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImageButton1" ImageUrl="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/delete.png" CommandName="Delete" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>

                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td colspan="4"></td>
                                                                </tr>
                                                                <%--  <tr>
                                                            <td style="width: 400px" valign="top" align="left">If your Requirement is for portion of a plot and not complete plot, please explain the requirement </td>
                                                            <td style="width: 3%" valign="top">:</td>
                                                            <td>
                                                                <asp:TextBox ID="txttsiixplotexpl" runat="server" class="form-control txtbox" Height="100px"
                                                                    Width="300px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>--%>
                                                                <tr style="height: 40px">
                                                                    <td colspan="4"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" colspan="4">
                                                                        <asp:Button ID="btnPlotsConfirmSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                            TabIndex="10" Text="Confirm Selected Plot(s)"
                                                                            Width="220px" OnClick="btnPlotsConfirmSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 20px">
                                                                    <td colspan="4"></td>
                                                                </tr>
                                                                <tr style="height: 20px">
                                                                    <td colspan="4" align="left">* Actual Price of the plot may vary depending on the position and direction of the plot.Contact your nearest Zonal office to get exact pricing.<br />

                                                                        **For SC & ST applicants there will not be any EMD (only Process fee)<br />

                                                                        ***Pending applications doesnot mean non-availability of the plot

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
               
              
                                <asp:View ID="View2" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="background-color: #f4f4f4" align="center" colspan="6">
                                                <table style="width: 95%">
                                                    <tr>
                                                        <td align="left" colspan="10">
                                                            <table style="width: 100%">
                                                                <tr style="height: 40px">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 300px">Name Of the Firm/Applicant <font color="red">*</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="TxtNameOftheFirmApplicant" runat="server" class="form-control txtbox" Height="28px"
                                                                            ToolTip="text" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 25px">
                                                                    <td colspan="4"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Address of the Registered Office
                                                        </td>
                                                    </tr>

                                                    <tr style="background-color: white">
                                                        <td valign="top" align="left" style="width: 50%">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%" align="left">
                                                                <tr style="height: 20px">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">Door No<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Street 1<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtstreetName" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Street 2
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtstreetName2" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">State<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlstate" runat="server" class="form-control txtbox" Height="33px" AutoPostBack="true"
                                                                            Width="180px" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"
                                                                            TabIndex="1">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="dist" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">District<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtDistrict" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="mandal" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Mandal<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtMandal" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="Vill" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Village<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtVillage" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="dist1" visible="false" runat="server">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">District<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox"
                                                                            Height="33px" TabIndex="1" AutoPostBack="true"
                                                                            Width="180px" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="mandal1" visible="false" runat="server">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Mandal<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                                                            Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="vill1" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Village/Town<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlvillage" runat="server" class="form-control txtbox" TabIndex="1"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 200px">Pincode<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtPincode" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="6" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength(this)"
                                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                            </table>
                                                        </td>

                                                        <td valign="top" align="left">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                <tr style="height: 20px">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">Telephono No
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtmobileNo1" runat="server" Height="28px"
                                                                            MaxLength="5" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                            Width="50px"></asp:TextBox>
                                                                        &nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtmobileNo" runat="server" Height="28px"
                                                                MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 200px;">Fax No
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtAltmobileno1" runat="server" Height="28px"
                                                                            MaxLength="5" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                            Width="50px"></asp:TextBox>
                                                                        &nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtAltmobileno" runat="server" Height="28px"
                                                                MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr runat="server" id="tr1">
                                                                    <td valign="middle"></td>
                                                                    <td style="width: 200px;" valign="middle">Category<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:ListBox ID="lstboxCategory" Width="180px" Height="120px" runat="server" SelectionMode="Multiple">
                                                                            <asp:ListItem Value="SC" Text="SC"></asp:ListItem>
                                                                            <asp:ListItem Value="ST" Text="ST"></asp:ListItem>
                                                                            <asp:ListItem Value="Technocrat" Text="Technocrat"></asp:ListItem>
                                                                            <asp:ListItem Value="Ex-Service" Text="Ex-Service"></asp:ListItem>
                                                                            <asp:ListItem Value="Women" Text="Women"></asp:ListItem>
                                                                            <asp:ListItem Value="General" Text="General"></asp:ListItem>
                                                                            <asp:ListItem Value="Resigned from service of PSU" Text="Resigned from service of PSU"></asp:ListItem>
                                                                        </asp:ListBox>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="10" align="left" style="font-weight: bold">If you choose more than one option then press Ctrl button and select your options.
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server" id="trUserid">
                                                                    <td valign="middle"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 200px;" valign="middle">Type of Organization<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlConst_of_unit" runat="server" class="form-control txtbox" TabIndex="1"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>

                                                                <tr runat="server" id="tr2">
                                                                    <td valign="middle"></td>
                                                                    <td style="width: 200px; padding: 5px; margin: 5px; text-align: left;" valign="middle">If the Type Oraganisation is Govt. Dept<font
                                                                        color="red"></font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtOraganisationgovt" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4" align="left">
                                                            <asp:RadioButtonList ID="rbtaddress" runat="server" align="left" RepeatDirection="Horizontal" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="rbtaddress_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <b>Is Communication Addres same as Registration Address?</b>
                                                            <%--<asp:CheckBox ID="chkaddressdiff" runat="server" Font-Bold="true" Text="Is There a Different Communication Addres?" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Communication Address
                                                        </td>
                                                    </tr>

                                                    <tr style="background-color: white">
                                                        <td valign="top" align="left" style="width: 50%">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%" align="left">
                                                                <tr style="height: 20px">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 150px;">Door No<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtDoorNoComm" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Street 1<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtstreetNameComm" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Street 2<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtstreetName2Comm" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">State<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlstateComm" runat="server" class="form-control txtbox" Height="33px" AutoPostBack="true"
                                                                            Width="180px"
                                                                            TabIndex="1" OnSelectedIndexChanged="ddlstateComm_SelectedIndexChanged">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="distcomm" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">District<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtDistrictComm" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="mandalComm" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Mandal<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtMandalComm" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="Villcomm" runat="server" visible="false">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Village<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtVillageComm" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="dist1comm" visible="false" runat="server">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">District<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddldistrictComm" runat="server" class="form-control txtbox" AutoPostBack="true"
                                                                            Height="33px" TabIndex="1"
                                                                            Width="180px" OnSelectedIndexChanged="ddldistrictComm_SelectedIndexChanged">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="mandal1comm" visible="false" runat="server">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Mandal<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlMandalComm" runat="server" class="form-control txtbox" Height="33px"
                                                                            Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlMandalComm_SelectedIndexChanged">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="vill1comm" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Village/Town<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlvillageComm" runat="server" class="form-control txtbox" TabIndex="1"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 200px;">Pincode<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtPincodeComm" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="6" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength(this)"
                                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                            </table>
                                                        </td>

                                                        <td valign="top" align="left">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                <tr style="height: 20px">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 150px;">Telephono No
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtmobileNo1Comm" runat="server" Height="28px"
                                                                            MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                            Width="50px"></asp:TextBox>
                                                                        &nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtmobileNoComm" runat="server" Height="28px"
                                                                MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 200px;">Fax No
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtAltmobileno1Comm" runat="server" Height="28px"
                                                                            MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                            Width="50px"></asp:TextBox>
                                                                        &nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtAltmobilenoComm" runat="server" Height="28px"
                                                                MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Firm registration Details
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td valign="top" align="left" colspan="2">
                                                            <table style="width: 100%" align="left">
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Year of Establishment
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:DropDownList ID="ddlYearofEstablishment" runat="server" class="form-control txtbox"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Year of Commencement
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:DropDownList ID="ddlYearofCommencement" runat="server" class="form-control txtbox"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Registration No
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtfirmregno" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Registering Authority
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtRegAuthority" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Previous Allotment Details
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td valign="top" align="left" colspan="2">
                                                            <table style="width: 100%" align="left">
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Plot No
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtPrvplotNo" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Shed Name
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtshed" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">House
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtHouse" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Other Details
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtprvother" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="width: 4%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Shop
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtshop" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>

                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Status Allotted/ Lease Name </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtstatusprv" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="4">

                                                            <asp:Button ID="btntab2previous" runat="server" CssClass="btn btn-primary"
                                                                ForeColor="White" Height="32px" OnClick="btntab2previous_Click" TabIndex="3"
                                                                Text="Previous" Width="220px" />

                                                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                TabIndex="10" Text="Save & Continue"
                                                                Width="220px" OnClick="Button3_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="background-color: #f4f4f4" align="center" colspan="6">
                                                <table style="width: 95%">
                                                    <tr>
                                                        <td align="left" colspan="10"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Contact Information
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td valign="top" align="left" style="width: 55%">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%" align="left">
                                                                <tr style="height: 20px">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 2%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 280px;">Surname <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtsurname" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Door No<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtDoorNoContact" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Street 1<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtstreetNameContact" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Street 2
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtstreetName2Contact" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">State<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlstateContact" runat="server" class="form-control txtbox" Height="33px" AutoPostBack="true"
                                                                            Width="180px"
                                                                            TabIndex="1" OnSelectedIndexChanged="ddlstateContact_SelectedIndexChanged">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="distContact" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">District<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtDistrictContact" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="mandalContact" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Mandal<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtMandalContact" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="VillContact" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Village<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtVillageContact" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr id="dist1Contact" visible="false" runat="server">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">District<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddldistrictContact" runat="server" class="form-control txtbox" AutoPostBack="true"
                                                                            Height="33px" TabIndex="1"
                                                                            Width="180px" OnSelectedIndexChanged="ddldistrictContact_SelectedIndexChanged">
                                                                            <asp:ListItem >--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="mandal1Contact" visible="false" runat="server">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Mandal<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlMandalContact" runat="server" class="form-control txtbox" Height="33px"
                                                                            Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlMandalContact_SelectedIndexChanged">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr id="vill1Contact" runat="server" visible="false">
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Village/Town<font
                                                                        color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlvillageContact" runat="server" class="form-control txtbox" TabIndex="1"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>

                                                            </table>
                                                        </td>

                                                        <td valign="top" align="left">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                <tr style="height: 20px">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 150px;">First Name <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtFirstName" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 200px;">Pincode<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtPincodeContact" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="6" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 200px;">Mobile No<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtmobileNoContactnew" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="width: 150px;">Telephono No
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtmobileNo1Contact" runat="server" Height="28px"
                                                                            MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                            Width="50px"></asp:TextBox>
                                                                        &nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtmobileNoContact" runat="server" Height="28px"
                                                                MaxLength="10" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" onblur="checkLength1(this)"
                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="width: 200px;">Fax No
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtfaxone" runat="server" Height="28px"
                                                                            MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength1(this)"
                                                                            Width="50px"></asp:TextBox>
                                                                        &nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtfaxonenew" runat="server" Height="28px"
                                                                MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength1(this)"
                                                                ValidationGroup="group" Width="120px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Email
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="return AvoidSpace()"></asp:TextBox>

                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="10"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Financial Information
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td valign="top" align="left" colspan="2">
                                                            <table style="width: 100%" align="left">
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Functional Responsibilities in Proposed Project
                                                                <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtfunctionalProposed" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" onkeypress="return character(event)" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Assets(Rs. in Lakhs)
                                                                <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtassetsrs" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Liabilities(Rs. in Lakhs)
                                                                <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtfunctionalliabilites" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Other Assets(Rs. in Lakhs)
                                                                <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtotherassets" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Details of Immovable Assets, Land and Building etc.
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtassetsland" runat="server" class="form-control txtbox" Height="100px"
                                                                            TabIndex="1" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Any other Information
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtfinancialotherinfo" runat="server" class="form-control txtbox" Height="100px"
                                                                            TabIndex="1" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Pan Number   <font color="red"></font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtpannofinancial" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>

                                                                   <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">GST Number  
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtGst" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>


                                                    <tr>
                                                        <td align="left" colspan="10"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Additional Promotor(s)
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td valign="top" align="left" colspan="2">
                                                            <table style="width: 100%" align="left">
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Name
                                                                <font color="red"></font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtnames" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>

                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Address
                                                                <font color="red"></font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Contact No
                                                                <font color="red"></font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:TextBox ID="txtcontact" runat="server" class="form-control txtbox" Height="28px" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="10" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Qualification
                                                                <font color="red"></font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtqualification" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>

                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Experience(years)
                                                                <font color="red"></font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtexperience" runat="server" class="form-control txtbox" Height="28px" 
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Net worth(RS.in Crores)
                                                                <font color="red"></font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtnetworth" runat="server" class="form-control txtbox" Height="28px" onkeypress="DecimalOnly()" 
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>

                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Button ID="Button5" runat="server" Text="Add" OnClick="Button5_Click" />
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td colspan="16">
                                                                        <asp:GridView ID="Addlpromotordetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                            ForeColor="#333333" Height="62px" OnRowCommand="Addlpromotordetails_RowCommand" OnRowDeleting="Addlpromotordetails_RowDeleting"
                                                                            Width="100%">
                                                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                                <asp:BoundField DataField="Address" HeaderText="Address " />
                                                                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                                                                <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                                                                                <asp:BoundField DataField="Experience" HeaderText="Experience" />
                                                                                <asp:BoundField DataField="Networth" HeaderText="Networth(Rs.in crores)" />


                                                                                    <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImageButton1" ImageUrl="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/delete.png" CommandName="Delete" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>



                                                                            </Columns>

                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>





                                                            </table>


                                                        </td>
                                                    </tr>

                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="4">

                                                            <asp:Button ID="btntab3previous" runat="server" CssClass="btn btn-primary"
                                                                ForeColor="White" Height="32px" OnClick="btntab3previous_Click" TabIndex="3"
                                                                Text="Previous" Width="220px" />
                                                            <asp:Button ID="btnview3save" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                TabIndex="10" Text="Save & Continue"
                                                                Width="220px" OnClick="btnview3save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                   <%-- <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View4" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="background-color: #f4f4f4" align="center" colspan="6">
                                                <table style="width: 95%">
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="10"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                       
                                                        <td align="left" colspan="6" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">General Information
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td valign="top" align="left" colspan="2">
                                                            <table style="width: 100%" align="left">
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Type of Venture  <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                        <asp:DropDownList ID="ddlSector_Ent" runat="server" class="form-control txtbox" Height="33px"
                                                                            Width="180px" AutoPostBack="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Project Status <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 30%">
                                                                        <asp:DropDownList ID="ddlproposal" runat="server" class="form-control txtbox" TabIndex="1"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="1">New</asp:ListItem>
                                                                            <asp:ListItem Value="2">Expansion</asp:ListItem>
                                                                            <asp:ListItem Value="3">Diversification</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Project Category <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlprojectcategory" runat="server" class="form-control txtbox" TabIndex="1" OnSelectedIndexChanged="ddmanu_SelectedIndexChanged"
                                                                            Height="33px" Width="180px" AutoPostBack="true">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="1">Chemical</asp:ListItem>
                                                                            <asp:ListItem Value="2">Ceramic</asp:ListItem>
                                                                            <asp:ListItem Value="3">Electronic</asp:ListItem>
                                                                            <asp:ListItem Value="4">Engineering</asp:ListItem>
                                                                            <asp:ListItem Value="5">Food</asp:ListItem>
                                                                            <asp:ListItem Value="6">IT/ITES</asp:ListItem>
                                                                            <asp:ListItem Value="7">Leather</asp:ListItem>
                                                                            <asp:ListItem Value="8">Pharma/Biotech</asp:ListItem>
                                                                            <asp:ListItem Value="9">Plastic</asp:ListItem>
                                                                            <asp:ListItem Value="10">Textile</asp:ListItem>
                                                                            <asp:ListItem Value="11">Other</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td></td>

                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                                                        <asp:DropDownList ID="ddlprojectcategory1" runat="server" class="form-control txtbox" TabIndex="1"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                                          
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtProjectcategorytext" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Line of Activity <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtProjectNameDescription" runat="server" class="form-control txtbox" Height="100px"
                                                                            TabIndex="1" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                    
                                                                </tr>
                                                              

                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    </table>
                                                   
                                                 <table style="width: 95%">

                                                     <tr style="height: 25px">
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style=" margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Proposed Project<font color="red">*</font> </td>
                                                                            </tr>
                                                                            <tr style="background-color: white">
                                                                                <td align="left" valign="top">
                                                                                    <table align="left" style="width: 100%">
                                                                                        <tr style="height: 20px">
                                                                                            <td colspan="2"></td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Product</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Product Code(ITC (HS) / NIC (HS)) </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Unit of Measurement </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"> Installed Capacity</td>
                                                                                            <%--<td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">  <font color="red"></font>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                            Phase3 
                                                                        </td>--%>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">
                                                                                                <asp:TextBox ID="txtproduct" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">&nbsp;</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtproductcode" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td></td>
                                                                                         
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtunitmasurement" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtinstalledcapacity" onpaste="return false" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>


                                                                                              <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Button ID="Button7" runat="server" Text="Add" OnClick="Button7_Click" />
                                                                    </td>
                                                                                        </tr>
                                                                                        
                                                                                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Height="62px" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" Width="100%">
                                                            <HeaderStyle BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" ForeColor="#FFFFFF" Height="40px" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" Height="40px" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle BackColor="#009688" CssClass="GridviewScrollC1Footer" ForeColor="#FFFFFF" Height="40px" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" Height="40px" />
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
                                                                <asp:BoundField DataField="product" HeaderText="Product" />
                                                                <asp:BoundField DataField="Itemcode" HeaderText="Product Code
ITC (HS) / NIC (HS)" />
                                                                <asp:BoundField DataField="Unitmeasurement" HeaderText="Unit of
Measurement" />
                                                                <asp:BoundField DataField="Installedcapacity" HeaderText="Installed Capacity" />
                                                                <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/delete.png" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                        
                                                     </table>

                                                      <table style="width: 95%">
                                                     <tr style="background-color: white">
                                                         <td align="left" valign="top">
                                                             <table align="left" style="width: 100%">
                                                                 <tr style="height: 20px">
                                                                     <td colspan="2"></td>
                                                                 </tr>
                                                                 <tr style="height: 40px;margin: 5px; background-color: #a0ff93; font-size: 13pt:colspan="5" ;">
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1<font color="red">*</font> </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2 </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase3 </td>
                                                                 </tr>
                                                                 <tr style="height: 40px">
                                                                     <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left;">Expected date of commencement of commercial operations <font color="red"></font> </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                         <asp:TextBox ID="txtdatecommercialoperations" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                         <asp:TextBox ID="txtdatecommercialoperationsphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                         <asp:TextBox ID="txtdatecommercialoperationsphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                 </tr>
                                                                 <tr style="height: 40px">
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Expected date of trial operations </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                         <asp:TextBox ID="txtdatetrialoperations" runat="server" class="form-control txtbox" Height="28px"
                                                                              MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                         <asp:TextBox ID="txtdatetrialoperationsphase2" runat="server" class="form-control txtbox" 
                                                                             Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                         <asp:TextBox ID="txtdatetrialoperationsphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                 </tr>
                                                                 <tr style="height: 40px">
                                                                     <td style="width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Expected date of commencement of construction </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                         <asp:TextBox ID="txtdatecommencementconstruction" runat="server" class="form-control txtbox" Height="28px"
                                                                              MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                         <asp:TextBox ID="txtdatecommencementconstructionphase2" runat="server" class="form-control txtbox" 
                                                                             Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                     <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                         <asp:TextBox ID="txtdatecommencementconstructionphase3" runat="server" class="form-control txtbox" 
                                                                             Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                     </td>
                                                                 </tr>
                                                             </table>
                                                         </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="8"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Estimated Project Cost (Rs. in Lakhs) </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1 <font color="red">*</font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2 </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase3 </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Land <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtland" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtland_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Land <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtlandphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtlandphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Land <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtlandphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtlandphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Buildings <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtbuilding" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtbuilding_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Buildings <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtbuildingphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtbuildingphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Buildings <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtbuildingphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtbuildingphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 4%"></td>
                                                                                <td colspan="12" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Machinery </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Imported <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtmachinaryimp" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtmachinaryimp_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Imported <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtmachinaryimpphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtmachinaryimpphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Imported <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtmachinaryimpphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtmachinaryimpphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Indigenous <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtmachinaryindenous" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtmachinaryindenous_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Indigenous <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtmachinaryindenousphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtmachinaryindenousphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Indigenous <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtmachinaryindenousphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtmachinaryindenousphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Auxiliary Equipment <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtmachinaryauxequ" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtmachinaryauxequ_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Auxiliary Equipment <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtauxilaryequipphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtauxilaryequipphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Auxiliary Equipment <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtauxilaryequipphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtauxilaryequipphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 10px">
                                                                                <td colspan="10" style="width: 4%"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Misc. Fixed Assets <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtfixedassets" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtfixedassets_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Misc. Fixed Assets <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtfixedassetsphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtfixedassetsphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Misc. Fixed Assets <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtfixedassetsphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtfixedassetsphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Contingencies <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtContinencies" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtContinencies_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Contingencies <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtContinenciesphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtContinenciesphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Contingencies <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtContinenciesphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtContinenciesphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Preliminary and Pre-operative Expenses <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtpreliminaryexp" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtpreliminaryexp_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Preliminary and Pre-operative Expenses <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtpreliminaryexpphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtpreliminaryexpphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Preliminary and Pre-operative Expenses <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtpreliminaryexpphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtpreliminaryexpphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Work Capital Margin <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtworkcapital" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtworkcapital_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Work Capital Margin <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtworkcapitalphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtworkcapitalphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Work Capital Margin <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtworkcapitalphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" OnTextChanged="txtworkcapitalphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Total <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txttotalprojcost" runat="server" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Total <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txttotalprojcostphase2" runat="server" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Total <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txttotalprojcostphase3" runat="server" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                            <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                   

                                                      
                                                                                    <table align="left" style="width: 100%">
                                                                                      
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                                                <asp:Label ID="Label2" runat="server" Text="Label">working sheets on project cost breakup<font color="red">*</font> </asp:Label>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px">: </td>
                                                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                                                                <asp:FileUpload ID="fileprojectupload" runat="server" Height="33px" Width="300px" />
                                                                                            
                                                                                                <asp:Label ID="lblprojectupload" runat="server" Visible="false" ></asp:Label>

                                                                                                    <asp:HyperLink ID="hyprojectupload" Visible="true" runat="server" CssClass="LBLBLACK"   Target="_blank"> </asp:HyperLink>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                                                                <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" onclick="BtnSave4_Click" Text="Upload" Width="72px" />
                                                                                            </td>
                                                                                        </tr>

                                                                                        </table>
                                                                                        



                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Equity and Debt Information (Rs. in Lakhs)<font color="red">*</font> </td>
                                                    </tr>
                                                    <tr style="background-color: white">
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="height: 20px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Equity</td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Domestic <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtdomestic" runat="server" class="form-control txtbox"  AutoPostBack="True"  Height="28px" OnTextChanged="txtdomestic_TextChanged" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Foreign <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtforeigns" runat="server" class="form-control txtbox" Height="28px"  AutoPostBack="True"  OnTextChanged="txtforeigns_TextChanged" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Total Equity <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtequity" runat="server" class="form-control txtbox" Enabled= "false"  OnTextChanged="txtequity_TextChanged" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Debit</td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Name </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Amount </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Others (Please specify) </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtname" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">&nbsp;</td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtamount" runat="server" class="form-control txtbox" Height="28px" OnTextChanged="txtamount_TextChanged" AutoPostBack="true"  MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 6%"><font color="red"></font></td>
                                                                                <td style="width: 1%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Total Equity + Debt </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%"><font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txteuitdebit" runat="server" class="form-control txtbox" Height="28px" Enabled= "false"  MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                </table>

                                                             <table style="width: 95%">
                                                                   <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Approval (Please fill the applicable)</td>
                                                    </tr>
                                                                
                                                                <tr style="background-color: white">
                                                                    <td align="left" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Foreign Investment Promotion Committee / Reserve Bank of India <font color="red"></font> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtforeign" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtforeigndate" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">IEM </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtIEM" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtIEMdate" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Letter of Intent (LOI) No. </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtloi" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtloidate" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">EOU No. </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txteou" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 15%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txteoudate" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    </tr>
                                                                

                                                             <table style="width: 95%">
                                                                <tr>
                                                                    <td align="left" colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 25px">
                                                                    <td colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 40px">
                                                                    <td align="left" colspan="2" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Direct Employment </td>
                                                                </tr>
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr style="background-color: white">
                                                                                <td align="left" valign="top">
                                                                                    <table align="left" style="width: 100%">
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1<font color="red">*</font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2 </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase3 </td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Unskilled <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtUnskilledemp" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtUnskilledemp_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">UnSkilled <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtunskilledphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtunskilledphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">UnSkilled <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtunskilledphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtunskilledphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Skilled <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtSkilledemp" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtSkilledemp_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Skilled <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtskilledphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtskilledphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Skilled <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtskilledphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtskilledphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Supervisory <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtSupervisoryemp" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtSupervisoryemp_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Supervisory <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtsupervisoryphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtsupervisoryphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">Supervisory <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtsupervisoryphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtsupervisoryphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Managerial <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtManagerialemp" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtManagerialemp_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Managerial <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtmanagerialphase2" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtmanagerialphase2_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Managerial <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtmanagerialphase3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtmanagerialphase3_TextChanged" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 6%">Total <font color="red"></font> </td>
                                                                                            <td style="width: 1%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txttotalempdirect" runat="server" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 6%">Total <font color="red"></font> </td>
                                                                                            <td style="width: 1%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txttotalempdirectphase2" runat="server" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 6%">Total <font color="red"></font> </td>
                                                                                            <td style="width: 1%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txttotalempdirectphase3" runat="server" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td align="left" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Indirect Employment </td>
                                                                            </tr>
                                                                            <tr style="background-color: white">
                                                                                <td align="left" valign="top">
                                                                                    <table align="left" style="width: 100%">
                                                                                        <tr style="height: 20px">
                                                                                            <td colspan="2"></td>
                                                                                        </tr>
                                                                                        <tr style="background-color: white">
                                                                                            <td align="left" colspan="2" valign="top">
                                                                                                <table align="left" style="width: 100%">
                                                                                                    <tr style="height: 40px">
                                                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 2px"></td>
                                                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 600px">Maximum no. of workers proposed to be employed in the factory <font color="red">*</font> </td>
                                                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 40%">
                                                                                                            <asp:TextBox ID="txtMaximumempfactory" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr style="height: 20px">
                                                                                                        <td colspan="2"></td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td align="left" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Gender Details </td>
                                                                            </tr>
                                                                            <tr style="background-color: white">
                                                                                <td align="left" valign="top">
                                                                                    <table align="left" style="width: 100%">
                                                                                        <tr style="height: 20px">
                                                                                            <td colspan="2"></td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1<font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2 </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase3 </td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Male <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtmalephase1" runat="server" AutoPostBack="True" class="form-control txtbox"  OnTextChanged="txtmalephase1_TextChanged" Height="28px" MaxLength="30" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Male <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtmalephase2" runat="server"  AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30"  OnTextChanged="txtmalephase2_TextChanged" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Male <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtmalephase3" runat="server"  AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="30"  OnTextChanged="txtmalephase3_TextChanged" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Female <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtfemalephase1" runat="server" class="form-control txtbox" AutoPostBack="True" Height="28px" MaxLength="30"  OnTextChanged="txtfemalephase1_TextChanged" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Female <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtfemalephase2" runat="server" class="form-control txtbox" AutoPostBack="True" Height="28px" MaxLength="30"  OnTextChanged="txtfemalephase2_TextChanged" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Female <font color="red"></font> </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtfemalephase3" runat="server" class="form-control txtbox" AutoPostBack="True" Height="28px" MaxLength="30" OnTextChanged="txtfemalephase3_TextChanged" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            </table>
                                                                         <table style="width: 95%">
                                                                            <tr style="height: 25px">
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style=" margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Raw Material Consumption<font color="red">*</font> </td>
                                                                            </tr>
                                                                            <tr style="background-color: white">
                                                                                <td align="left" valign="top">
                                                                                    <table align="left" style="width: 100%">
                                                                                        <tr style="height: 20px">
                                                                                            <td colspan="2"></td>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Description of Item </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Item Code ITC (HS) / NIC(HS) </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Daily Consumption at Full Capacity</td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Unit of Measurement </td>
                                                                                            <%--<td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">  <font color="red"></font>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                            Phase3 
                                                                        </td>--%>
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">
                                                                                                <asp:TextBox ID="txtdesitem" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtitemcode" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td></td>
                                                                                       <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtdailyconsum" runat="server" onpaste="return false" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtunitfont" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>

                                                                                                 <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Button ID="Button6" runat="server" Text="Add" OnClick="Button6_Click" />
                                                                    </td>
                                                                                        </tr>
                                                                                      
                                                                                        <asp:GridView ID="rawmaterialconsumption" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Height="62px"
                                                                                             OnRowCommand="rawmaterialconsumption_RowCommand" OnRowDeleting="rawmaterialconsumption_RowDeleting" Width="102%">
                                                                                            <HeaderStyle BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" ForeColor="#FFFFFF" Height="40px" />
                                                                                            <RowStyle CssClass="GridviewScrollC1Item" Height="40px" />
                                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                                            <FooterStyle BackColor="#009688" CssClass="GridviewScrollC1Footer" ForeColor="#FFFFFF" Height="40px" />
                                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" Height="40px" />
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
                                                                                                <asp:BoundField DataField="Descriptionitem" HeaderText="Description of Item" />
                                                                                                <asp:BoundField DataField="Itemcode" HeaderText="	Item Code ITC
(HS) / NIC(HS)" />
                                                                                                <asp:BoundField DataField="DailyConsumption" HeaderText="Daily Consumption
at Full Capacity" />
                                                                                                <asp:BoundField DataField="unitmeasurement" HeaderText="Unit of


Measurement	" />
                                                                                                <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Center">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/delete.png" />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                             </table>
                                                                         <table style="width: 95%">
                                                                            <tr>
                                                                                <td align="left"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style=" margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Manufacturing Process </td>
                                                                            </tr>
                                                                          </table>

                                                                         <div style="height:40px">
                                                                                    <table align="left" style="width: 100%">
                                                                                      
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                                                <asp:Label ID="Label1" runat="server" Text="Label">Please give a brief description of process technology used along with a flow chart ( to be enclosed )</asp:Label>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px">: </td>
                                                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                                                                <asp:FileUpload ID="fupResAttachment" runat="server" Height="33px" Width="300px" />
                                                                                            
                                                                                                <asp:Label ID="Label444" runat="server" Visible="false" ></asp:Label>

                                                                                                    <asp:HyperLink ID="HyperLink1" Visible="true" runat="server" CssClass="LBLBLACK"   Target="_blank"> </asp:HyperLink>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                                                                <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" OnClick="BtnSave3_Click" Text="Upload" Width="72px" />
                                                                                            </td>
                                                                                        </tr>

                                                                                        </table>
                                                                                        </div>





                                                                                   
                                                                                              <table align="left" style="width: 100%">
                                                                                        <tr>
                                                                                            <td align="center">
                                                                                                <asp:TextBox ID="txtuidno" runat="server" class="form-control txtbox" Height="150px" TabIndex="1" MaxLength="500" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left">Do you have any technical collaboration? </td>
                                                                                            <td style="padding: 5px; margin: 5px">
                                                                                                <asp:RadioButtonList ID="rdIaLa_Lst" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                            </td>
                                                                                            <tr style="height: 20px">
                                                                                                <td></td>
                                                                                            </tr>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left">If Yes provide details </td>
                                                                                        </tr>
                                                                                        <tr style="height: 20px">
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center">
                                                                                                <asp:TextBox ID="txtprovidedetails" runat="server" class="form-control txtbox" Height="150px" MaxLength="500" TabIndex="1" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 20px">
                                                                                            <td></td>
                                                                                        </tr>
                                                                                   
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left">If the Process technology involves usage of steam, the details of steam generator i.e, Boiler - furnish details of capacity and fuel to be used. </td>
                                                                            </tr>
                                                                            <tr style="height: 20px">
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:TextBox ID="txtprocesstechnology" runat="server" class="form-control txtbox" Height="150px" TabIndex="1" MaxLength="500"   TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                                                </td>
                                                                          </table>
                                                                              
                                                             <table style="width: 95%">
                                                                      <tr style="height: 25px">
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style=" margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">List of Plant and Machinery with the Capacity in KWA required <font color="red">*</font> </td>
                                                                            </tr>
                                                                            <tr style="background-color: white">
                                                                                <td align="left" valign="top">
                                                                                    <table align="left" style="width: 100%">
                                                                                        <tr style="height: 20px">
                                                                                            <td colspan="2"></td>
                                                                                        </tr>
                                                               
                                                                                        <tr style="height: 40px">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Description of Plant & Machinery </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Capacity in Kilo Watt </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                               
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Quantity </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                             <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Cost(Rs.in Lakhs) </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                          
                                                                                     
                                                                                        </tr>
                                                                                        <tr style="height: 40px">
                                                                                            <td style="width: 4%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 15%">
                                                                                                <asp:TextBox ID="txtmachinaryplant" runat="server" class="form-control txtbox" Height="100px" TextMode="MultiLine" TabIndex="1" Width="200px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtcapacitykw" runat="server" onpaste="return false" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                              <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtquantity" runat="server" onpaste="return false" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>
                                                                                             <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                                <asp:TextBox ID="txtcost" runat="server" onpaste="return false" class="form-control txtbox" Height="28px"  MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                            </td>

                                                                                                                                                     <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:Button ID="Button4" runat="server" Text="Add" OnClick="Button4_Click" />



                                                                    </td>
                                                                                            </tr>
                                                                                            
                                                                         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Height="62px" Width="102%"
                                                                                              OnRowCommand="GridView2_RowCommand" OnRowDeleting="GridView2_RowDeleting">
                                                                                            <HeaderStyle BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" ForeColor="#FFFFFF" Height="40px" />
                                                                                            <RowStyle CssClass="GridviewScrollC1Item" Height="40px" />
                                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                                            <FooterStyle BackColor="#009688" CssClass="GridviewScrollC1Footer" ForeColor="#FFFFFF" Height="40px" />
                                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" Height="40px" />
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
                                                                                                <asp:BoundField DataField="descplantmachinery" HeaderText="Description of Plant & Machinery" />

                                                                                                <asp:BoundField DataField="capacitykw" HeaderText="Capacity in Kilo Watt" />

                                                                                                  <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

                                                                                                <asp:BoundField DataField="cost" HeaderText="Cost(RS in Lakhs)" />


                                                                                                <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Center">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/delete.png" />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                            
                                                                                
                                                                                           
                                        
                                                                                        </tr>
                                                                    
                                                                                      
                                                                                        
                                                                                    </table>
                                                                               
                                                 <table style="width: 95%">

                                                                                     <tr style="height:40px">
                                                                                            <td style="padding: 5px; margin: 5px;">Whether factory / unit will be having any high pressure reaction vessels?
                                                                                               
                                                                                            </td>
                                                                                            <td style="height:40px">

                                                                                                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                                    <asp:ListItem Selected="True" Value="N">Not Applicable</asp:ListItem>
                                                                                                </asp:RadioButtonList>

                                                                                              </td>
                                                                                          
                                                                                        </tr>
                                                                                        <tr style=" height:40px;">
                                                                                            <td style="padding: 5px; margin: 5px; text-align: left">If yes, number of such vessels may be indicated <br />

                                                                                                

                                                                                            <td style="padding: 5px; margin: 5px; text-align: right">
                                                                                                                      <asp:TextBox ID="TextBox13" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true"  MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>

                                                                                            </td>
                                                                                           
                                                                                          

                                                                                            <td style="text-align:center" > &nbsp;</td>
                                                                                        </tr>
                                                                                       
                                                                                        
                                                                                            
                                                                              
                                                            </table>
                                                     
                                               
                                                   
                                                  
                                             </td>
                                                                </tr>

                                                                 </table>
                                               
                 
                                                         

                                   
                                      
                                    <div style="text-align:right">

                                        
                                                            <asp:Button ID="btntab4" runat="server" CssClass="btn btn-primary" ForeColor="White" Height="32px" OnClick="btntab4previous_Click" TabIndex="3" Text="Previous" Width="220px" />
                                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="Button1_Click" TabIndex="10" Text="Save &amp; Continue" Width="220px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                    
                                    </div>
                                     </tr>
                                                                        </table>

                </td>
                                            </tr>
                                        </table>
                                  
                                        
                                            
                                </asp:View>
                                <asp:View ID="View5" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="background-color: #f4f4f4" align="center" colspan="6">
                                                <table style="width: 95%">
                                                    <tr>
                                                        <td align="left" colspan="10"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="10">
                                                            <table style="width: 100%">
                                                                <tr style="height: 20px">
                                                                    <td colspan="10"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 500px">Requirement of Industrial Shed(Plinth area in Sq.Mtrs)
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="TextBox49" runat="server"  Enabled="false"   class="form-control txtbox" Height="28px"
                                                                            ToolTip="text" TabIndex="0" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 25px">
                                                                    <td colspan="4"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Area of Land Required for your Proposed Project
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>

                                                                            <tr style="height: 40px">




                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1<font color="red">*</font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase3 
                                                                                </td>


                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Plant and Factory Buildings  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtPlantFactoryBuildings" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtPlantFactoryBuildings_TextChanged"></asp:TextBox>
                                                                                </td>

                                                                                <td style="width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Plant and Factory Buildings  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtPlantFactoryBuildingsphase2" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtPlantFactoryBuildingsphase2_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Plant and Factory Buildings  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtPlantFactoryBuildingsphase3" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtPlantFactoryBuildingsphase3_TextChanged"></asp:TextBox>
                                                                                </td>


                                                                            </tr>

                                                                            <tr style="height: 40px">

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Administration Buildings <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtAdministrationBuildings" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtAdministrationBuildings_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Administration Buildings <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtAdministrationBuildingsphase2" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtAdministrationBuildingsphase2_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Administration Buildings <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtAdministrationBuildingsphase3" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtAdministrationBuildingsphase3_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Storage and Warehousing <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtStorageWarehousing" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtStorageWarehousing_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Storage and Warehousing <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtStorageWarehousingphase2" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtStorageWarehousingphase2_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Storage and Warehousing <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtStorageWarehousingphase3" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtStorageWarehousingphase3_TextChanged"></asp:TextBox>
                                                                                </td>

                                                                            </tr>

                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Roads,Water storage, sub-station etc. <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtRoadsWaterstorage" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtRoadsWaterstorage_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Roads,Water storage, sub-station etc. <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtRoadsWaterstoragephase2" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtRoadsWaterstoragephase2_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Roads,Water storage, sub-station etc. <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtRoadsWaterstoragephase3" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtRoadsWaterstoragephase3_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Open Areas, Green Belt etc. <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtOpenAreasGreenBelt" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtOpenAreasGreenBelt_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Open Areas, Green Belt etc. <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtOpenAreasGreenBeltphase2" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtOpenAreasGreenBeltphase2_TextChanged"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Open Areas, Green Belt etc. <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtOpenAreasGreenBeltphase3" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" OnTextChanged="txtOpenAreasGreenBeltphase3_TextChanged"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Total  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txttotalAreaLandRequired" runat="server" Enabled="false"  class="form-control txtbox"  AutoPostBack="true"   Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Total  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txttotalAreaLandRequiredphase2" runat="server" Enabled="false" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Total  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txttotalAreaLandRequiredphase3" runat="server" Enabled="false" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                     <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Energy consumption in KVA ( Power required for the project )
                                                        </td>
                                                    </tr>

                                                      <tr>
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>


                                                                              <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="blue">Energy Source</td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                 
                                                                                </td>

                                                                               </tr>
                                                         
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">TSTransco Supply<font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                               </tr>

                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Own Generation<font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                                </tr>

                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">DG Set <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>


                                                                            </tr>
                                                        
                                                                           
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Energy Requirement
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>
                                                                            <tr style="height: 40px">




                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1<font color="red">*</font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase3 
                                                                                </td>


                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Power requirements from TSTRANSCO (in KVA) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtPowerrequirements" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Power requirements from TSTRANSCO (in KVA) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtPowerrequirementsphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Power requirements from TSTRANSCO (in KVA) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtPowerrequirementsphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>


                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Contracted maximum demand (in KVA) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtContractedmaximumdemand" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Contracted maximum demand (in KVA) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtContractedmaximumdemandphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Contracted maximum demand (in KVA) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtContractedmaximumdemandphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Required power supply line (KV) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtRequiredpowersupplyline" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Required power supply line (KV) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtRequiredpowersupplylinephase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Required power supply line (KV) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtRequiredpowersupplylinephase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>




                                                                            </tr>
                                                                            <tr style="height: 40px;">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Voltage rating at which HT supplies required <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtVoltagerating" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Voltage rating at which HT supplies required <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtVoltageratingphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Voltage rating at which HT supplies required <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtVoltageratingphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>


                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Connected load (KW) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtConnectedload" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Connected load (KW) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtConnectedloadphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Connected load (KW) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtConnectedloadphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Load factor <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtLoadfactor" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Load factor <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtLoadfactorphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Load factor <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtLoadfactorphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Probable date of requirement of power supply
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>

                                                                            <tr style="height: 40px">




                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1<font color="red">*</font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase3 
                                                                                </td>


                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Construction phase date  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtConstructionphasedate" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Construction phase date  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtConstructionphasedatephase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Construction phase date  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtConstructionphasedatephase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>


                                                                            </tr>

                                                                            <tr style="height: 40px">

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Commercial production date  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtCommercialproductiondate" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Commercial production date  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtCommercialproductiondatephase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Commercial production date  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtCommercialproductiondatephase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Peak Water Requirement (K. L. per day)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td colspan="12" style="font-weight: bold">Temporary (during construction)
                                                                                </td>
                                                                            </tr>

                                                                            <tr style="height: 40px">




                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1<font color="red">*</font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase3 
                                                                                </td>


                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Domestic   <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtDomesticTemporary" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Domestic  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtdomesticphase2temp" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Domestic  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtdomesticphase3temp" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr style="height: 40px;">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 20%">Industrial  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtIndustrialTemporary" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Industrial  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtindustrialphase2temp" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Industrial  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtindustrialphasetemp3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td colspan="12" style="font-weight: bold">Permanent (commercial production phase)
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Domestic  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtDomesticPermanent" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Domestic  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtdomesticpermphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Domestic  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtdomesticpermphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Industrial  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtIndustrialPermanent" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Industrial <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtIndustrialPermanentphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Industrial  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtIndustrialPermanentphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>


                                                     <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;">Details of Effluents
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>
                                                                       

                                                                            <tr style="height: 40px">




                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase1
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                         <%--       <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font></td>--%>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Phase2</td>

                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 4%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"><font color="red"></font>
                                                                                </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">Phase3</td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                </td>


                                                                            </tr>
                                                                            <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Effluents Quantity (m3/day)  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txteffluentqtyphase1" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                              <%--  <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">  <font color="red">*d</font></td>--%>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txteffluentqtyphase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                             
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <%--<td style="padding: 5px; margin: 5px; text-align: left; width: 25%"></td>--%>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txteffluentqtyphase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                            <tr style="height: 40px;">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Solid Waste (kg/day) <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtsolidwastephase1" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                               
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                              <%--  <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"> <font color="red">*</font></td>--%>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"> </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtsolidwastephase2" runat="server" class="form-control txtbox" Height="28px" MaxLength="30"
                                                                                         TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                              
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                              <%--  <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"> <font color="red"></font></td>--%>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtsolidwastephase3" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                           
                                                                            <tr style="height: 40px">

                                                                              
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                                <td style="padding: 15px; margin: 15px;">Brief description on types of effluents 
generated, treatment proposed and 
Disposal System Description  <font color="red"></font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:TextBox ID="txtdesceffluents" runat="server" class="form-control txtbox" MaxLength="500"   Height="200px"  TabIndex="1" Width="400px"></asp:TextBox>
                                                                                </td>
                                                                              
                                                                            </tr>
                                                                         
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>

                                                       <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td align="left" colspan="5" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt; font-weight: bold;"> Bank Details 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" valign="top">
                                                            <table align="left" style="width: 100%">
                                                                <tr style="background-color: white">
                                                                    <td align="left" colspan="2" valign="top">
                                                                        <table align="left" style="width: 100%">
                                                                            <tr style="height: 20px">
                                                                                <td colspan="2"></td>
                                                                            </tr>
                                                                         <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Bank Name   <font color="red">*</font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtBankName" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"> Branch Name <font color="red">*</font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtBankBranchName" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%"> Accout No  <font color="red">*</font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtBanAccNO" runat="server" class="form-control txtbox" Height="28px"  onkeypress="DecimalOnly()" MaxLength="30" TabIndex="1" Width="180px" oncopy="return false" onpaste="return false" oncut="return false"  AutoPostBack="true" OnTextChanged="txtBanAccNO_TextChanged"></asp:TextBox>
                                                                                </td>

                                                                            </tr>

                                                                              <tr style="height: 40px">
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">  IFSC Code    <font color="red">*</font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtIfsccode" runat="server" class="form-control txtbox" Height="28px" MinLength="11" MaxLength="11" TabIndex="1" Width="180px" oncopy="return false" onpaste="return false" oncut="return false"  AutoPostBack="true" OnTextChanged="txtIfsccode_TextChanged"></asp:TextBox>
                                                                                </td>

                                                                                    <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Type of Account  <font color="red">*</font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtTypeAccount" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%"></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Account Holder Name  <font color="red">*</font></td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 2%">: </td>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                    <asp:TextBox ID="txtAccountHolderName" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" Width="180px" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                                                </td>
                                                                             

                                                                            </tr>

                                                                      
                                                                         
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>







                                                    <tr>
                                                        <td align="right" colspan="4">

                                                            <asp:Button ID="btntab5" runat="server" CssClass="btn btn-primary"
                                                                ForeColor="White" Height="32px" OnClick="btntab5previous_Click" TabIndex="3"
                                                                Text="Previous" Width="220px" />

                                                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                TabIndex="10" Text="Save & Continue"
                                                                Width="220px" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 25px">
                                                        <td colspan="4"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="height: 25px">
                                            <td colspan="4"></td>
                                        </tr>
                                    </table>
                                </asp:View>
                               
           </asp:MultiView>
                        </td>
                    </tr>
                    
                    </table>

                   
    </div>

  </ContentTemplate>

  

      
    </asp:UpdatePanel>

    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    
    
 


    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
        }

        select {
            color: Black !important;
        }
    </style>

    <script type="text/javascript">




        function character(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122)) {
                alert("Enter only characters from A to Z");
                return false;
            }
            return true;
        }


        $(document).ready(function () {





            $('.browse').click(function () {



                var file = $(this).parent().parent().parent().find('.file');


                file.trigger('click');





            });




            function validate() {

                if ($('.filesi')[0].files.length === 0) {

                    $('.filesi').focus();

                    return false;
                }
            }


        });





        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 10);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtdatecommercialoperations']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtdatecommencementconstruction']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtdatetrialoperations']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtConstructionphasedate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            // Will run at every postback/AsyncPostback

            $("input[id$='txtdatecommencementconstructionphase2']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtCommercialproductiondate]").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });




            $("input[id$='txtCommercialproductiondate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });



            $("input[id$='txtCommercialproductiondatephase2']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtdatecommencementconstructionphase3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtdatecommencementconstructionphase2']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtdatecommercialoperationsphase2']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtdatecommercialoperationsphase3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtdatetrialoperationsphase2']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtdatetrialoperationsphase3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtCommercialproductiondatephase2']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtConstructionphasedatephase3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });



            $("input[id$='txtConstructionphasedatephase2']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtCommercialproductiondatephase3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });


            $("input[id$='txtforeigndate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });



            $("input[id$='txtIEMdate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtloidate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txteoudate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 10);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();



            $("input[id$='txtdatecommercialoperations']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtdatecommencementconstruction']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback



            $("input[id$='txtdatetrialoperations']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtConstructionphasedate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            // Will run at every postback/AsyncPostback


            $("input[id$='txtdatetrialoperationsphase2']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            // Will run at every postback/AsyncPostback


            $("input[id$='txtdatetrialoperationsphase3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback




        });














    </script>
</asp:Content>

