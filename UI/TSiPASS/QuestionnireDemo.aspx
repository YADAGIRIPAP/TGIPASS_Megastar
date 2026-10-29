<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="QuestionnireDemo.aspx.cs" Inherits="UI_TSiPASS_QuestionnireDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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

        .LBLBLACK {
        }

        .auto-style1 {
            width: 288px;
        }

        .auto-style2 {
            width: 277px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
        <meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge"> 
		<meta name="viewport" content="width=device-width, initial-scale=1"> 
		<title>Tab Styles Inspiration</title>
		<meta name="description" content="Tab Styles Inspiration: A small collection of styles for tabs" />
		<meta name="keywords" content="tabs, inspiration, web design, css, modern, effects, svg" />
		<meta name="author" content="Codrops" />
		<link rel="shortcut icon" href="../favicon.ico">
		<link rel="stylesheet" type="text/css" href="../../Masterfiles/css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="../../Masterfiles/css/demo.css" />
        
		<link rel="stylesheet" type="text/css" href="../../Masterfiles/css/tabs.css" />
		<link rel="stylesheet" type="text/css" href="../../Masterfiles/css/tabstyles.css" />
  		<script src="js/modernizr.custom.js"></script>

    <input type="hidden" id="hdnfocus" value="" runat="server" />
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Questionnaire - Consent for
                        Establishment</a> </li>
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
    <div class="container">
        <section>
				<div class="tabs tabs-style-shape">
					<nav>
						<ul>
							<li>
								<a href="#section-shape-1">
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<span>Home</span>
								</a>
							</li>
							<li>
								<a href="#section-shape-2">
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<span>Design</span>
								</a>
							</li>
							<li>
								<a href="#section-shape-3">
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<span>Work</span>
								</a>
							</li>
							
							
						</ul>
					</nav>
					<div class="content-wrap">
						<section id="section-shape-1"><p>1</p></section>
						<section id="section-shape-2"><p>2</p></section>
						<section id="section-shape-3"><p>3</p></section>
						<section id="section-shape-4"><p>4</p></section>
						<section id="section-shape-5"><p>5</p></section>
					</div><!-- /content -->
				</div><!-- /tabs -->
			</section>
    </div>
    <!-- /. ROW  -->
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Questionnaire - Consent for Establishment
                </div>
                <div class="panel-body">
                    
                    <div id="wizard" style="background-color: white">
                        <h2>Project Details</h2>
                        <section> <asp:UpdatePanel ID="upd1" runat="server">
                                  <ContentTemplate>
                            <table style="width:100%">
                              <tr>
                                <td style="padding: 5px; margin: 5px"> 
                                    <asp:Label ID="Label10" runat="server" data-balloon-length="large" data-balloon="Name of Unit" data-balloon-pos="down"  Width="180px">1. Name of Unit<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="TxtnameofUnit" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                        MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                   
                                </td>
                                <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtnameofUnit"
                                        ErrorMessage="Please Enter Name of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label377" runat="server" data-balloon-length="large" data-balloon="Please Eneter Constitution of the unit" data-balloon-pos="down">2. Constitution of the unit<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddlConst_of_unit" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlConst_of_unit"
                                        ErrorMessage="Please Select Constitition of Unit" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                 <tr>
                                      <td style="padding: 5px; margin: 5px"> 
                                    <asp:Label ID="Label13" runat="server" data-balloon-length="large" data-balloon="Is Land purchased from IALA" data-balloon-pos="down" Width="260px" > 3. Is Land purchased from IALA<font color="red">*</font></asp:Label>
                                </td>
                               
                               <td style="padding: 5px; margin: 5px"> :</td>
                                    <td style="padding: 5px; margin: 5px">
                                       
                                        <asp:RadioButtonList ID="rdIaLa_Lst"  runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N" >No</asp:ListItem>
                                        </asp:RadioButtonList>
                                       
                                    </td>
                                   <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                    <td style="height:38px; padding: 5px; margin: 5px" >
                                                </td>
                                   <td></td>
                                   <td>                                   
                                </td>
                            </tr>
                               <tr>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label352" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location" data-balloon-pos="down" CssClass="LBLBLACK" >4. Proposed Location<font 
                                color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                        <asp:ListItem>--District--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProp_intDistrictid"
                                        ErrorMessage="Please Select Proposed Location (District)" InitialValue="--District--"
                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                
                                    <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please Eneter Total Extent of Land" data-balloon-pos="down"  Width="180px">5. Total Extent of Land<font color="red">*</font></asp:Label>
                                            </td>
                                   <td style="padding: 5px; margin: 5px">:
                                </td>
                                    <td style="height:38px; padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddllandmesurements" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddllandmesurements_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                   <td></td>

                            </tr>
                                <tr runat="server" id="trIndustries" visible="false">
                                <td style="padding: 5px; margin: 5px"><asp:Label runat="server" ID="lblIndusText" Text="Name of the Industrial Park"></asp:Label></td>
                                <td style="padding: 5px; margin: 5px">:</td>
                                <td style="padding: 5px; margin: 5px">
                                     <asp:DropDownList ID="ddlIndustrialParkName" runat="server" AutoPostBack="true" class="form-control txtbox"
                                        Height="33px" Width="180px" OnSelectedIndexChanged="ddlIndustrialParkName_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;</td>
                                
                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                <td style="height:38px; padding: 5px; margin: 5px">
                                    &nbsp;</td>
                                 <td style="padding: 5px; margin: 5px">
                                     &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddlProp_intMandalid" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intMandalid_SelectedIndexChanged">
                                        <asp:ListItem>--Mandal--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProp_intMandalid"
                                        ErrorMessage="Please Select Proposed Location (Mandal)" InitialValue="--Mandal--"
                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                
                                <td  colspan="4">
                                <table style="width:100%">
                                    <tr>
                                         <td style="padding: 5px; margin: 5px; " class="auto-style2" align="right" id="tdTxtTot_ExtentNew" runat="server">Acres&nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="height:38px; padding: 5px; margin: 5px">
                                <asp:TextBox ID="TxtTot_ExtentNew" runat="server" class="form-control txtbox" Height="30px" placeholder="Acre"
                                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                    Width="180px" AutoPostBack="True" OnTextChanged="TxtTot_ExtentNew_TextChanged"></asp:TextBox>
                                    
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtTot_ExtentNew"
                                        ErrorMessage="Please Enter Total Extent of Land (In Sq mtrs)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                    </tr>
                                    <tr ID="trtxtgunthas" runat="server">
                                        <td style="padding: 5px; margin: 5px" class="auto-style2" align="right">Gunthas&nbsp;&nbsp;&nbsp;
                                </td>
                                      <td style="padding: 5px; margin: 5px">:
                                </td>
                                
                                        <td style="padding: 5px; margin: 5px">  <asp:TextBox ID="txtgunthas" runat="server" Text="0" class="form-control txtbox" Height="30px" placeholder="gunthas"
                                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                    Width="180px" AutoPostBack="True" OnTextChanged="txtgunthas_TextChanged"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                                    </tr>

                                </table>
                                </td>
                               
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddlProp_intVillageid" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlProp_intVillageid_SelectedIndexChanged">
                                        <asp:ListItem>--Village--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlProp_intVillageid"
                                        ErrorMessage="Please Select Proposed Location (Village)" InitialValue="--Village--"
                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                
                                 <td class="LBLBLACK" style="padding: 5px; margin: 5px" align="right">In Square Meters &nbsp;&nbsp;</td>
                                <td style="padding: 5px; margin: 5px">:
                                  <td style="height:38px; padding: 5px; margin: 5px">
                                                <asp:TextBox ID="TxtTot_Extent" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox></td>
                                     <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>
                                 <tr>
                                <td style="padding: 5px; margin: 5px">Under Limits</td>
                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblLimits" runat="server" ></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;</td>
                                
                                 <td class="LBLBLACK" style="padding: 5px; margin: 5px" align="right">&nbsp;</td>
                                <td style="padding: 5px; margin: 5px">&nbsp;<td style="height:38px; padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                     <td style="padding: 5px; margin: 5px">&nbsp;</td>
                            </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label350" runat="server" data-balloon-length="large" data-balloon="Please select Location of the unit" data-balloon-pos="down" CssClass="LBLBLACK" >6. Location of the unit<font 
                                color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddlLoc_of_unit" runat="server" class="form-control txtbox"
                                        Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlLoc_of_unit_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlLoc_of_unit"
                                        ErrorMessage="Please Select Location of Unit" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                  <td style="padding: 5px; margin: 5px">
                                        <asp:Label ID="Label4" runat="server" data-balloon-length="large" data-balloon="Please Enter Built up Area" data-balloon-pos="down" CssClass="LBLBLACK">7. Built up Area (Including Parking Cellars)<font 
                                    color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:TextBox ID="TxtBuilt_up_Area" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="6" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        Square Meters
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtBuilt_up_Area"
                                            ErrorMessage="Please Enter Built up Area (Including Parking Cellars)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>



                                
                            </tr>
                             <tr runat="server" id="trApplType" visible="false">
                                
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label397" runat="server" data-balloon-length="large" data-balloon="Please Select Application Type" data-balloon-pos="down" CssClass="LBLBLACK" >6.a. Application Type<font 
                                color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddlAppl_Type" runat="server" class="form-control txtbox" Height="33px"
                                        Width="180px">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlAppl_Type"
                                        ErrorMessage="Please Select Application Type" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                 
                            </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label395" runat="server" data-balloon-length="large" data-balloon="Please Select Line of Activity" data-balloon-pos="down" CssClass="LBLBLACK" Width="165px">8. Line of Activity<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; height:38px" colspan="1" >
                                    <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="form-control txtbox"
                                        Height="33px" AutoPostBack="True" OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged"
                                        Width="300px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlintLineofActivity"
                                        ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                 <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please Select Sector of Enterprise" data-balloon-pos="down" >9. Sector of Enterprise<font 
                                       color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                    <asp:DropDownList ID="ddlSector_Ent" runat="server" class="form-control txtbox" Height="33px"
                                        Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlSector_Ent_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSector_Ent"
                                        ErrorMessage="Please Select Sector of Enterprise" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label8" runat="server" data-balloon-length="large" data-balloon="Pollution Category of Enterprise" data-balloon-pos="down"  CssClass="LBLBLACK">10. Pollution Category of Enterprise<font 
                                color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px" runat="server" id="trPOPCategory">
                                    <asp:Label ID="LblPol_Category" runat="server" CssClass="LBLBLACK" Width="200px"
                                        Font-Bold="True" Font-Size="18px"></asp:Label>
                                    <asp:HiddenField ID="HdfLblPol_Category" runat="server" />
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                                
                                   
                                                        
                            </tr>
                             <tr runat="server" id="trFallinPolution">
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="180px" data-balloon-length="large" data-balloon="Please Select Yes if your unit fall under the list of Industries" data-balloon-pos="down">Does your unit fall under the list of <font 
                                color="red">*</font></asp:Label>
                                    <a style="color: Black" target="_blank" href="LIST OF POLLUTING INDUSTRIES IN SMALL SCALE SECTOR.pdf">
                                        <%--66 polluting industries--%></a>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RadioButtonList ID="RdPol_Indus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>
                            <tr style="height:50px">
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                            <td colspan="3" style="padding: 5px; margin: 5px" valign="bottom">
                             <%--   <a href="DisplayDocs/HMDAListofVillagesexcel.pdf" target="_blank"><b>Click here for HMDA Villages List</b></a>--%></td>
                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                          </tr>
                           </table>
                      </ContentTemplate>
    </asp:UpdatePanel>   </section>

                        <h2>Project Financials</h2>
                        <section> <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                  <ContentTemplate>
                        <table style="width:100%">
                            

                            <tr>
                                <td colspan="6" style="width:65%"><table style="width:100%">
                                    <tr><td style="padding: 5px; margin: 5px;">11.</td>
                                 <td>
                                        <asp:Label ID="Label388" runat="server" data-balloon-length="large" data-balloon="Please Enter Proposed Employment" data-balloon-pos="down" CssClass="LBLBLACK">Proposed Employment<font color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width:2px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" >
                                        <asp:TextBox ID="TxtProp_Emp" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="6" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px"
                                            AutoPostBack="True" OnTextChanged="TxtProp_Emp_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtProp_Emp"
                                            ErrorMessage="Please Enter Proposed Employment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                            
                            </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; width:2px">12</td>
                                               <td style="padding: 5px; margin: 5px" >
                                        Proposal For<span class="style5">*</span>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        :
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:DropDownList ID="ddlproposal" runat="server" class="form-control txtbox" TabIndex="1"
                                            Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlproposal_SelectedIndexChanged">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">New</asp:ListItem>
                                            <asp:ListItem Value="2">Expansion</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlproposal"
                                            ErrorMessage="Please enter Proposed For" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                          </tr>
                                     <tr>
                            <td colspan="2" style="padding: 5px; margin: 5px">
                                <asp:Label ID="Label389" runat="server" data-balloon-length="large" data-balloon="Please Enter Project Cost" data-balloon-pos="down"  CssClass="LBLBLACK" Font-Bold="True">12. Project Cost</asp:Label>
                            </td>
                             <td style="padding: 5px; margin: 5px" Font-Bold="True">:
                                 </td>
                             <td style="padding: 5px; margin: 5px">
                                <asp:DropDownList ID="ddlcurrencytype" runat="server" class="form-control txtbox" Height="33px"
                                    Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlcurrencytype_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="padding: 5px; margin: 5px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlcurrencytype"
                                    ErrorMessage="Please Choose the amount in" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                            </td>
                          
                        </tr>
                                    <tr>
                                        <td colspan="6" style="padding: 5px; margin: 5px; font-weight:bold" align="center" valign="top" id="tdprojectcostname" runat="server">
                                            New/Existing Enterprice
                                </td>
                                    </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">a)
                                </td>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label390" runat="server" CssClass="LBLBLACK">Value of Land(Mention Zero in case of leased premises)<font 
                                color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="TxtVal_Land_Actual" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Land_Actual_TextChanged"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtVal_Land_Actual"
                                        ErrorMessage="Please Enter Value of Land" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px" align="right">
                                    In Rs. Lakhs
                                </td>
                                 <td style="padding: 5px; margin: 5px">:
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                     <asp:TextBox ID="TxtVal_Land" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                        MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Land_TextChanged"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                </td>
                            </tr>
                             <tr>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblLand" CssClass="lblinv" runat="server"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                </td>
                            </tr>
                            <tr>
                             <td style="padding: 5px; margin: 5px" valign="top">b)
                                </td>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label391" runat="server" CssClass="LBLBLACK">Value of Building(Mention Zero in case of leased premises)<font 
                                color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="TxtVal_Build_Actual" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Build_Actual_TextChanged"></asp:TextBox>
                                   
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtVal_Build_Actual"
                                        ErrorMessage="Please Enter Value of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                </tr>
                            <tr>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px"  align="right">
                                     In Rs. Lakhs
                                </td>
                                 <td style="padding: 5px; margin: 5px">:
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                     <asp:TextBox ID="TxtVal_Build" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group" Enabled="false"
                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Build_TextChanged"></asp:TextBox>
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                </tr>
                             <tr>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                      <asp:Label ID="lblBuild" CssClass="lblinv" runat="server"></asp:Label>
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                               </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px">c)
                                </td>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label392" runat="server" CssClass="LBLBLACK">Value of Plant &amp; Machinery or Service Equipment<font 
                                color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="TxtVal_Plant_Actual" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Plant_Actual_TextChanged"></asp:TextBox>
                                    
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtVal_Plant_Actual"
                                        ErrorMessage="Please Enter Value of Plant &amp; Machinery Or Service Equipment"
                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                              </tr>
                             <tr>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px"  align="right">
                                     In Rs. Lakhs 
                                </td>
                                 <td style="padding: 5px; margin: 5px">:
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                     <asp:TextBox ID="TxtVal_Plant" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group" Enabled="false"
                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Plant_TextChanged"></asp:TextBox>
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 </tr>
                             <tr>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                     <asp:Label ID="lblPlant" CssClass="lblinv" runat="server"></asp:Label>
                                </td>
                                 <td style="padding: 5px; margin: 5px">
                                </td>
                                 </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label393" runat="server" CssClass="LBLBLACK">Total Project Cost(in Lakhs) <font 
                                color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="TxtTot_PrjCost" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label394" runat="server" CssClass="LBLBLACK">Your enterprise is</asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:Label ID="LblEnt_is" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True"
                                        Font-Size="18px"></asp:Label>
                                    <asp:HiddenField ID="HdfLblEnt_is" runat="server" />
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>

                                    </table></td>

                                 <td valign="top">
                                      <table style="width: 65%" id="tblexpansion" runat="server" visible="false">
        <tr>
          
            <td style="padding: 5px; margin: 5px; width: 2px">
            </td>
          <td style="padding: 5px; margin: 5px; height:50px;">
                                                             
            </td>
            <td style="padding: 5px; margin: 5px"></td>

        </tr>
                                          
        <tr>
            <td style="padding: 5px; margin: 5px">
            </td>
            <td style="padding: 5px; margin: 5px; height:42px;">
                                                             
            </td>
            <td style="padding: 5px; margin: 5px">
               
            </td>

        </tr>
        <tr>
        <td style="padding: 5px; margin: 5px">
        </td>
        <td style="padding: 5px; margin: 5px; height:40px;">
                                                             
        </td>
        <td style="padding: 5px; margin: 5px">
               
        </td>

        </tr>
        <tr>
            <td  style="padding: 5px; margin: 5px; " colspan="6" align="center">
                <span style="font-weight:bold"> &nbsp;<u> Expansion </u> </span>
            </td>
        </tr>
        <tr>
            
            <td style="padding: 5px; margin: 5px">:
            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:TextBox ID="TxtVal_Land_ActualExpansion" runat="server" class="form-control txtbox" Height="28px"
                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                    Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Land_ActualExpansion_TextChanged" ></asp:TextBox>
            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="TxtVal_Land_ActualExpansion"
                    ErrorMessage="Please Enter Value of Expansion Land" ValidationGroup="group">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            
            <td style="padding: 5px; margin: 5px">:
            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:TextBox ID="TxtVal_LandExpansion" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                    Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_LandExpansion_TextChanged"></asp:TextBox>
            </td>
            <td style="padding: 5px; margin: 5px"></td>
        </tr>
        <tr>
            <td style="padding: 5px; margin: 5px"></td>
            <td style="padding: 5px; margin: 5px">
                </td>
            <td style="padding: 5px; margin: 5px"></td>
        </tr>
        <tr>
            <td style="padding: 5px; margin: 5px">:
            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:TextBox ID="TxtVal_Build_ActualExpn" runat="server" class="form-control txtbox" Height="28px"
                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                    Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Build_ActualExpn_TextChanged"></asp:TextBox>

            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="TxtVal_Build_ActualExpn"
                    ErrorMessage="Please Enter Value of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
           
            <td style="padding: 5px; margin: 5px">:
            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:TextBox ID="TxtVal_BuildExpanstion" runat="server" class="form-control txtbox" Height="28px"
                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group" Enabled="false"
                    Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_BuildExpanstion_TextChanged"></asp:TextBox>
            </td>
            <td style="padding: 5px; margin: 5px"></td>
        </tr>
        <tr>
           
            <td style="padding: 5px; margin: 5px"></td>
            <td style="padding: 5px; margin: 5px">
                </td>
            <td style="padding: 5px; margin: 5px"></td>
        </tr>
        <tr>
            <td style="padding: 5px; margin: 5px">:
            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:TextBox ID="TxtVal_Plant_ActualExpansion" runat="server" class="form-control txtbox" Height="28px"
                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                    Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Plant_ActualExpansion_TextChanged"></asp:TextBox>

            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="TxtVal_Plant_ActualExpansion"
                    ErrorMessage="Please Enter Value of Plant &amp; Machinery Or Service Equipment"
                    ValidationGroup="group">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
           
            <td style="padding: 5px; margin: 5px">:
            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:TextBox ID="TxtVal_PlantExpanstion" runat="server" class="form-control txtbox" Height="28px"
                    MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group" Enabled="false"
                    Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_PlantExpanstion_TextChanged"></asp:TextBox>
            </td>
            <td style="padding: 5px; margin: 5px"></td>
        </tr>
        <tr>
          
            <td style="padding: 5px; margin: 5px"></td>
            <td style="padding: 5px; margin: 5px">
                </td>
            <td style="padding: 5px; margin: 5px"></td>
        </tr>
        <tr>
           
            <td style="padding: 5px; margin: 5px">:
            </td>
            <td style="padding: 5px; margin: 5px">
                <asp:Label ID="txtlbltotalprojectcostexpanstion" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                    Width="180px"></asp:Label>
            </td>
            <td style="padding: 5px; margin: 5px">&nbsp;
            </td>
        </tr>
            </table>
                                 </td>
                            </tr>

                           
                            </table>
                         </ContentTemplate>
    </asp:UpdatePanel>  </section>

                        <h2>Project Requirements</h2>
                        <section><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                  <ContentTemplate>
                             <table style="width:95%">
                                   <tr>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        <asp:Label ID="Label358" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please Enter Power requirement in HP" data-balloon-pos="down"  Width="200px">13. Power requirement in HP<font 
                                    color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px" valign="top">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        <asp:DropDownList ID="ddlPower_Req" runat="server" class="form-control txtbox" Height="33px"
                                            Width="180px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlPower_Req"
                                            ErrorMessage="Please Select Power requirement in HP" InitialValue="--Select--"
                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="250px" data-balloon-length="large" data-balloon="Please Select Water required from" data-balloon-pos="down" >14. Water required from <font color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px" valign="top">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" >
                                        <asp:CheckBoxList ID="ChkWater_reg_from" runat="server" Height="60px" Width="180px">
                                            <asp:ListItem>New Bore well</asp:ListItem>
                                            <asp:ListItem>HMWS &amp; SB</asp:ListItem>
                                            <asp:ListItem>Rivers/Canals</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:Label ID="Label370" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please Enter Water Required per day( in KLD)" data-balloon-pos="down"  Width="280px">15. Water Required per day( in KLD)<font color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" class="LBLBLACK">
                                        <asp:TextBox ID="TxtWater_req_Perday" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="8" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                            Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtWater_req_Perday"
                                            ErrorMessage="Please Enter Water Required per day (In KLD)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                               
                                   <td style="padding: 5px; margin: 5px">
                                        <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please Select store Rectified Spirit/Kerosene/Naptha" data-balloon-pos="down" >16. Do you store Rectified Spirit/Kerosene/Naptha<font 
                                    color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" class="auto-style1">
                                        <asp:RadioButtonList ID="RdDo_Store_Kerosine" runat="server" RepeatDirection="Horizontal" Height="16px" Width="210px">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                    </td>
                                </tr>
                                <tr runat="server" id="trUserid">
                                    
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please Select Generator Requirement" data-balloon-pos="down" >17. Generator Requirement<font color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RadioButtonList ID="RdGen_Reqired" runat="server" RepeatDirection="Horizontal" Height="16px" Width="180px">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                    </td>
                                      <td style="padding: 5px; margin: 5px">
                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please Eneter Height of the building(in Meters)" data-balloon-pos="down" >18. Height of the building(in Meters)<font color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" class="auto-style1">
                                        <asp:TextBox ID="TxtHight_Build" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="2" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TxtHight_Build"
                                            ErrorMessage="Please Enter Height of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                   
                                </tr>
                               
                                <tr runat="server" id="trNoExepted">
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Is there any need to Fell trees in Proposed Site" data-balloon-pos="down" >19. Is there any need to Fell trees in Proposed Site<font color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" class="auto-style1">
                                        <asp:RadioButtonList ID="RdProp_Site" runat="server" RepeatDirection="Horizontal"
                                            AutoPostBack="True" OnSelectedIndexChanged="RdProp_Site_SelectedIndexChanged" Height="16px" Width="210px">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">&nbsp;
                                    </td>
                                     <td style="padding: 5px; margin: 5px">
                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Does your location fall under muncipal limit" data-balloon-pos="down" >20. Does your location fall under muncipal limit<font 
                                    color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" class="auto-style1">
                                        <asp:RadioButtonList ID="RdFall_in_Municipal"  runat="server" RepeatDirection="Horizontal" Height="16px" Width="210px">
                                            <asp:ListItem Value="M">Yes</asp:ListItem>
                                            <asp:ListItem Value="R" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                    </td>
                                </tr>
                                <tr runat="server" id="trtrees" visible="false">
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="" data-balloon-pos="down" >Number of trees to be felled(Girth of tree > 30 centimeters)<font color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" class="auto-style1">
                                        <asp:TextBox ID="Txt_NoofTrees" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                            Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="Txt_NoofTrees"
                                            ErrorMessage="Please Enter Number of trees to e felled" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="Txt_NoofTrees"
                                            ErrorMessage="Please Enter Number of trees to e felled" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr4" visible="false">
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" >Are there any trees in Non-Exempted(Other than trees in this <a target="_blank" href="../../docs/Exempted_Trees.pdf">List</a>)<font color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" class="auto-style1">
                                        <asp:RadioButtonList ID="RdbExecpted" runat="server" RepeatDirection="Horizontal" Height="17px" Width="210px">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top"></td>
                                </tr>
                                 <tr style="height:15px">
                                     <td></td>
                                 </tr>
                                 <tr>
                                     
                                     <td style="padding: 5px; margin: 5px" valign="top">
                                         <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please select Application Type" data-balloon-pos="down" >21. Labour Application Type<font color="red">*</font></asp:Label>
                                    </td>
                                      <td style="padding: 5px; margin: 5px" valign="top">:
                                    </td>
                                      <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                        <asp:CheckBoxList ID="ChkLabour_Application" runat="server" RepeatDirection="Vertical"  Width="600px" CellSpacing="5" CellPadding="5" AutoPostBack="True" OnSelectedIndexChanged="ChkLabour_Application_SelectedIndexChanged">
                                        </asp:CheckBoxList>
                                    </td>
                                 </tr>
                                 <tr id="tract4" runat="server" visible="false">
                                     
                                     <td style="padding: 5px; margin: 5px" valign="top">
                                         <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" data-balloon-length="large" data-balloon="Please select Application Type" data-balloon-pos="down" >21 a. Whether your establishment has employed or had employed on any day of the preceding 12 months, 10 or more building workers in any “Building & Other Construction Works”.<font color="red">*</font></asp:Label>
                                    </td>
                                      <td style="padding: 5px; margin: 5px" valign="top">:
                                    </td>
                                      <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                        <asp:RadioButtonList ID="rdbact2"  runat="server" RepeatDirection="Horizontal" Height="16px" Width="210px">
                                            <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="N" >No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                 </tr>
                            </table>
                          </ContentTemplate>
    </asp:UpdatePanel>  </section>


                    </div>
                    <div>

                        <table style="width: 50%">
                            <tr>
                                <td style="Width: 200px">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn-primary" Height="32px" OnClick="BtnSave_Click"
                                        TabIndex="10" Text="Show Approvals Required" Width="185px" ValidationGroup="group" /></td>
                                <td>
                                    <asp:Button ID="BtnSave" runat="server" CausesValidation="False" CssClass="btn-success"
                                        Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Submit Questionnaire" ValidationGroup="group"
                                        Width="180px" OnClientClick="ConfirmSave()" /></td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnShowEnclosers" runat="server" CausesValidation="False" CssClass="btn-success"
                                                Height="32px" TabIndex="10" Text="Show Enclousers List"
                                                Width="180px" OnClick="btnShowEnclosers_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>

                                <td>
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                        Width="80px" />

                                </td>
                            </tr>

                        </table>

                    </div>
                    <div>
                        <h1 class="page-subhead-line"></h1>
                    </div>
                    <div class="panel panel-default" id="dvfeedetails" runat="server" visible="false">
                        <div class="panel-heading">
                            Fee Details(in Rs.)
                        </div>
                        <div class="panel-body">
                            <table style="width: 90%">
                                <tr>
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" Width="100%" OnRowDataBound="grdDetails_RowDataBound"
                                            ShowFooter="True">
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required ">
                                                    <ItemStyle Width="450px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Dept_Full_name" HeaderText="Department">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fees" FooterStyle-HorizontalAlign="Right" HeaderText="Fees (Rs.)"
                                                    DataFormatString="{0:0}">
                                                    <FooterStyle CssClass="GRDITEM2" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle CssClass="GRDITEM2" Width="150px" HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#B9D684" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div class="row">
                    </div>
                </div>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="child" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />
            </div>
        </div>
    </div>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
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

    <%--</div>
       </td>
        </tr>
    </table>--%>



    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>

    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>

    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>

    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>

  
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />

    		<script src="../../js/cbpFWTabs.js"></script>
		<script>
		    (function () {

		        [].slice.call(document.querySelectorAll('.tabs')).forEach(function (el) {
		            new CBPFWTabs(el);
		        });

		    })();
		</script>

</asp:Content>

