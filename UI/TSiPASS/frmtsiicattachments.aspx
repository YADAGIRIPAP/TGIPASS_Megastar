<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmtsiicattachments.aspx.cs" Inherits="UI_TSIPASS_frmtsiicattachments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <script src="../../js/jquery.js" type="text/javascript"></script>

    <script src="../../js/jquery.min.js" type="text/javascript"></script>
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

    <script type="text/javascript" src="../../js/UploadImage.js"></script>

    <script type="text/javascript" language="javascript">


        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <div class="panel-body">
        <div class="col-md-12">
            <label class="col-md-12" style="padding: 5px; margin: 5px; background-color: #a0ff93; font-size: 13pt;">Upload Attachments</label>

        </div>
        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
            <tr id="trplan" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="350px"> 1.Detailed project report (DPR) <span style="font-weight: bold; color: red;">*</span> :</asp:Label>
                </td>


                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" Height="48px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="Please select File" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"
                        ValidationGroup="1"></asp:RequiredFieldValidator>

                    <asp:HyperLink ID="HyperLink1" Visible="true" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"> </asp:HyperLink>
                    <br />
                    <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>


                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="BtnLandRqrmnt" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnLandRqrmnt_Click" TabIndex="10" Text="Upload"
                        Width="72px" />
                </td>
            </tr>
            <tr id="trlistofdirector" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="350px">2.Udyog aadhar acknowledgement based on self certification<span style="font-weight: bold; color: red;">*</span>:</asp:Label>
                </td>


                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload2" runat="server" class="form-control txtbox" Height="48px" />



                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload2"
                        ErrorMessage="Please select File" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"
                        ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label16" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="BtnAdhrAck" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnAdhrAck_Click" TabIndex="10" Text="Upload"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr3" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="350px">3.Copy of partnership deed/ articles of memorandum and association of the company/society registration as applicable :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload3" runat="server" class="form-control txtbox" Height="48px" />



                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnPtnrshpDeed_Click" TabIndex="10" Text="Upload"
                        Width="72px" />
                </td>
            </tr>

            <tr id="tr1" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="350px">4.Present Share holder Details(Certified by CA/CS) :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload13" runat="server" class="form-control txtbox" Height="48px" />
                    <asp:HyperLink ID="HyperLink13" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label26" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Btnshareholder" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="Btnshareholder_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr4" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="350px">5.Plant/ Machinery details with details of greenary/ lawn to be maintained as per the TSPCB normss if any<span style="font-weight: bold; color: red;">*</span> :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload4" runat="server" class="form-control txtbox" Height="48px" />

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload4"
                        ErrorMessage="Please select File" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"
                        ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button8" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnMchnryDtls_Click" TabIndex="10" Text="Upload"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr5" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="350px">6.Latest certificate copy of community/ caste certificate if any(issued by Revenue Department of Telangana) :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload5" runat="server" class="form-control txtbox" Height="48px" />


                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label7" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button9" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnCasteCertfct_Click" TabIndex="10" Text="Upload"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr6" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="350px">7.Certifficate copy of address proof<span style="font-weight: bold; color: red;">*</span> :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload6" runat="server" class="form-control txtbox" Height="48px" />

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FileUpload6"
                        ErrorMessage="Please select File" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"
                        ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label9" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button10" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnAddrsPrf_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                        Width="72px" /></td>
            </tr>
            <tr id="tr7" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="350px">8.Copy of PAN card for identity proof <span style="font-weight: bold; color: red;">*</span>:</asp:Label>
                </td>


                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload7" runat="server" class="form-control txtbox" Height="48px" />

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload7"
                        ErrorMessage="Please select File" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"
                        ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label11" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button11" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnPanIdnty_Click" TabIndex="10" Text="Upload"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr8" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="350px">9.Photograpf of the applicant(s)<span style="font-weight: bold; color: red;">*</span> :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload8" runat="server" class="form-control txtbox" Height="48px" />


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload8"
                        ErrorMessage="Please select File" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"
                        ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label15" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button12" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnphtogrpyApplcnt_Click" TabIndex="10" Text="Upload"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr9" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="350px"> 10.Mean of Finance - Banker Commitment Letter/Net worth certificate by CA/Financial closure<span style="font-weight: bold; color: red;">*</span> :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload9" runat="server" class="form-control txtbox" Height="48px" />

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload9"
                        ErrorMessage="Please select File" Display="Dynamic" ForeColor="#CC0000" SetFocusOnError="True"
                        ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label18" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button13" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnBnkrLtr_Click" TabIndex="10" Text="Upload"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr10" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="350px">11.Online Payment receipt off the applicant (Mandatory for NEFT/RTGS applicants) :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload10" runat="server" class="form-control txtbox" Height="48px" />
                    <asp:HyperLink ID="HyperLink10" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label20" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button14" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnPmntRcpt_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr11" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="350px">12.GST registration certificate(Mandatory for GST registered applicants) :</asp:Label>
                </td>

                <td style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload11" runat="server" class="form-control txtbox" Height="48px" />
                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label23" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button15" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnGSTCrtfct_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                        Width="72px" />
                </td>
            </tr>
            <tr id="tr12" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="350px">13.Any other Relevant documents :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="FileUpload12" runat="server" class="form-control txtbox" Height="48px" />
                    <asp:HyperLink ID="HyperLink12" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="Label25" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="Button16" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="BtnRlvntdoc_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                        Width="72px" />
                </td>
            </tr>
            <tr id="trcancelledcheque" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">

                    <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="350px">14.Cancelled Cheque :</asp:Label>
                </td>

                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                    <asp:FileUpload ID="fupcancelledcheque" runat="server" class="form-control txtbox" Height="48px" />
                    <asp:HyperLink ID="hypcancelledcheque" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                    <br />
                    <asp:Label ID="lblcancelledcheque" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px; width: 10px;">
                    <asp:Button ID="btncancelledcheque" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                        OnClick="btncancelledcheque_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                        Width="72px" />
                </td>
            </tr>

        </table>

        <div class="col-md-12" style="text-align: right">

            <asp:Button ID="btntab6" runat="server" OnClick="Button5_Click" CssClass="btn btn-primary"
                ForeColor="White" Height="32px" TabIndex="3"
                Text="Previous" Width="220px" />
            <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Height="32px"
                TabIndex="10" Text="Save & Continue"
                Width="220px" OnClick="Button4_Click" />
        </div>
    </div>




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



</script>
    <%--<script type="text/javascript">

        $(document).ready(function () {

          
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "frmtsiicattachments.aspx/bindatas",
                data: {},
                dataType: "json",
                success: function (data) {


                    input[type = "hidden"].val(data.d.Processflowchart);
                 
                


                
                    
                },
                error: function () {
                    alert("Error while Showing update data");
                }
            });
        


   
           

        });


         $(document).ready(function() {
            
            

           

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

        </script>--%>
</asp:Content>

