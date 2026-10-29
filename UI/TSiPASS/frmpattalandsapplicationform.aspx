<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmpattalandsapplicationform.aspx.cs" Inherits="UI_TSiPASS_frmpattalandsapplicationform" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <%--<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>--%>
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

        .auto-style1 {
            height: 45px;
        }

        .auto-style2 {
            position: relative;
            min-height: 1px;
            top: 0px;
            left: 0px;
            float: left;
            width: 98.66666667%;
            height: 62px;
            padding-left: 94px;
            padding-right: 15px;
        }

        </style>
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != null && el.value.length != 0 && el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
        }
    </script>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
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
    <a href="SBISFTPFILES/">SBISFTPFILES/</a>
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
        var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
        [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
        [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
        [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
        [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
        [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
        [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
        [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
        [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
        [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];


        // The permutation table
        var p = [
            [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
            [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
            [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
            [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
            [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
            [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
            [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];


        // The inverse table
        var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];



        //  For a given number generates a Verhoeff digit

        //         Validates that an entered number is Verhoeff compliant.

      <%--  function validateVerhoeff() {
            //document.getElementById('txtadhar1'+'txtadhar2'+'txtadhar3').value

            var num = document.getElementById("<%=txtadhar1.ClientID %>").value + document.getElementById("<%=txtadhar2.ClientID %>").value + document.getElementById("<%=txtadhar3.ClientID %>").value;
            //alert(num);
            //alert('hi');
            var num;
            var cc;
            var c = 0;
            var myArray = StringToReversedIntArray(num);

            for (var i = 0; i < myArray.length; i++) {

                c = d[c][p[(i % 8)][myArray[i]]];

            }

            cc = c;
            if (cc == 0) {
                //alert("Valid UID");
            }
            else {

                alert("This is not Valid Aadhar Number");
                document.getElementById("<%=txtadhar1.ClientID %>").value = "";
                document.getElementById("<%=txtadhar2.ClientID %>").value = "";
                document.getElementById("<%=txtadhar3.ClientID %>").value = "";
            }
        }--%>



        /*
        * Converts a string to a reversed integer array.
        */
        function StringToReversedIntArray(num) {

            var myArray = [num.length];

            for (var i = 0; i < num.length; i++) {

                myArray[i] = (num.substring(i, i + 1));

            }

            myArray = Reverse(myArray);


            return myArray;

        }

        /*
        * Reverses an int array
        */
        function Reverse(myArray) {

            var reversed = [myArray.length];

            for (var i = 0; i < myArray.length; i++) {
                reversed[i] = myArray[myArray.length - (i + 1)];

            }

            return reversed;
        }

        function ValidatePAN() {
            var Obj = document.getElementById("txtcontact0");
            if (Obj.value != "") {
                ObjVal = Obj.value;
                var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
                if (ObjVal.search(panPat) == -1) {
                    alert("Invalid Pan No");
                    Obj.focus();
                    return false;
                }
            }
        }
    </script>
    
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Details</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="auto-style2">
                        <%--<div class="panel panel-primary">
                           <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Entrepreneur Details</h3>
                            </div>--%>
                        <div class="col-md-12">
                            <h1 class="page-head-line" align="center" style="font-size: x-large">Application for Patta Lands</h1>
                        </div>
                       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <div class="panel-body" align="left">
                                    <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 70%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Pattadar Name<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtpattadarname" onkeypress="Names()" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Pattadar Pass Book Number<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtdharaninumber"  runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server" Width="288px">Mineral Name for which NOC is required<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                             <asp:DropDownList ID="ddlMineral" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlMineral_SelectedIndexChanged">
                                                               <%-- <asp:ListItem>--Select--</asp:ListItem>--%>
                                                               </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                            <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                                                TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <%--<asp:ListItem Value="31">31</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">5.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlmandal" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlmandal_SelectedIndexChanged"
                                                                TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <%--<asp:listitem value="311">311</asp:listitem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    &nbsp;</td>
                                <td style="width: 27px">
                                    <asp:Label ID="Label399" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="338px">Select Village, Enter Survey No's and Extent</asp:Label>
                                                        </td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">6.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlvillage" runat="server" class="form-control txtbox" TabIndex="1"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <%-- <asp:ListItem Value="7546">7546</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">7.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="343px">Survey No(Multiple Survey Numbers may be present)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="TxtSurveyNo" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">8.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="210px">Extent (in Hectare) for above Survey No.<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="TxtPartExtent" onkeypress="DecimalOnly()" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                                                        </td>
                                                        <asp:HiddenField ID="HDNAPPLICATIONID" runat="server" />
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr id="tr2" runat="server">

                                <td style="padding: 5px; margin: 5px" colspan="5" align="center">
                                    <asp:Button ID="BtnVlgAdd" runat="server" CssClass="btn btn-xs btn-warning"
                                        Height="28px" TabIndex="10" Text="Add" ValidationGroup="group1"
                                        Width="72px" OnClick="BtnVlgAdd_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear0" runat="server" CausesValidation="False" Visible="false"
                                        CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel"
                                        ToolTip="To Clear  the Screen" Width="73px" />
                                    <asp:HiddenField ID="HdfldTotalExtent" runat="server" />
                                                        </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                            </tr>
                                                    <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="5">
                                    <asp:GridView ID="gvVillageAdd" runat="server" AutoGenerateColumns="False"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                        CssClass="GRD" ForeColor="#333333" GridLines="Both"
                                        OnRowDataBound="gvVillageAdd_RowDataBound"
                                        OnRowDeleting="gvVillageAdd_RowDeleting" ShowFooter="True" Width="100%">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:BoundField DataField="Village" HeaderText="Village Name" />
                                            <asp:BoundField DataField="SurveyNo" HeaderText="Survey No" />
                                            <asp:BoundField DataField="Extent" HeaderText="Extent (in Hectors)" />
                                           
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVillageid" runat="server" Text='<%# Bind("VillageID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                        <tr>
                                            <td>
                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                    Width="90px" />&nbsp;
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    OnClick="BtnSave1_Click" TabIndex="10" Text="Submit" Width="90px"  />&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>                                   
                                        <tr id="trDoc" runat="server" visible="false">
            <td style="padding: 5px; margin: 5px" valign="top">
                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Documents to be upload<font 
                                                            color="red">*</font></asp:Label>
            </td>
        </tr>
                                        <tr>
            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                <table cellpadding="4" cellspacing="5" style="width: 100%; text-align: left;">
                    
                    <tr id="trAtchment" Visible="false" runat="server">
                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">1. </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;">
                         <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" data-balloon="Self Certification Form" data-balloon-length="large" data-balloon-pos="down" Width="210px">DGPS Map.<font 
                                                            color="red">*</font></asp:Label>   
                        </td>
                        <td style="padding: 5px; margin: 5px">: </td>
                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                            <asp:FileUpload ID="FUPDGPSMAP" runat="server" class="form-control txtbox" Height="33px" Width="300px" />
                            <asp:HyperLink ID="HYPDGPSMAP" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                            <br />
                            <asp:Label ID="LBLDGPSMAP" runat="server" Visible="False"></asp:Label>
                            <asp:HiddenField ID="HDFDGPSMAP" runat="server" />
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            <asp:Button ID="BTNDGPSMAP" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" OnClick="BTNDGPSMAP_Click" TabIndex="10" Text="Upload" Width="72px" />
                        
                        </td>
                    </tr>
                    <tr id="tratchmentsave" runat="server" visible="false">
                        <td class="auto-style1"></td>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Height="32px"
                                OnClick="btnsave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px"
                                Visible="true" />
                            &nbsp;&nbsp;<asp:Button ID="Button4" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                Height="32px" OnClick="btnclear_Click" TabIndex="10" Text="Clear" Width="90px" />
                        </td>
                    </tr>
                    <tr id="trsuccess" runat="server" visible="false">
                        <td class="auto-style1"></td>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="AtchSuccess" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">×</a> <strong>Success!</strong><asp:Label ID="Label13" runat="server"></asp:Label>
                            </div>
                            <div id="AtchFailure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="Label14" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
   
                                    </table>
                                </div>
                            <%--</ContentTemplate>
                            <Triggers>
                <asp:PostBackTrigger ControlID="BTNDGPSMAP" />
            </Triggers>
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
            
        </ContentTemplate>
         <Triggers>
            
                <asp:PostBackTrigger ControlID="BTNDGPSMAP" />
              <%--<asp:AsyncPostBackTrigger ControlID="BTNDGPSMAP"/>--%>
            </Triggers>
    </asp:UpdatePanel>
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
</asp:Content>
