<%@ Page Language="C#" AutoEventWireup="true" CodeFile="waltaform2.aspx.cs" MasterPageFile="~/UI/TSiPASS/CCMaster.master" EnableEventValidation="false"
    Inherits="UI_TSiPASS_waltaform2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>


    <style type="text/css">
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

        div#card {
            padding: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
            margin: 10px 0px 0px 0px;
            border: 1px solid #000;
        }

        .container {
            max-width: 1245px !important;
        }
    </style>
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 31%;
            width: 67%;
            top: -112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
            left: 386px;
        }

        .style5 {
            width: 300px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupTSiPASSReport4.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

        }
        function getChildControl() {
            if (win != null && !win.closed) {

                var form1 = win.document.getElementsbyId("ctl00_ContentPlaceHolder1_hdfID").value;
                alert(form1);
            }
        }

        function Load_hdfID(val) {
            win.close();
            $get("ctl00_ContentPlaceHolder1_hdfID").value = val;
            __doPostBack("LOOKUP", val);
            alert(val);
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
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function inputOnlyDecimals(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 46 || charCode > 57) || charCode == 47)
                return false;
            return true;
        }
    </script>
     <script type="text/javascript">
         function inputOnlyNumbers(evt) {
             var charCode = (evt.which) ? evt.which : evt.keyCode;
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }
         function inputOnlyDecimals(evt) {
             var charCode = (evt.which) ? evt.which : evt.keyCode;
             if (charCode > 31 && (charCode < 46 || charCode > 57) || charCode == 47)
                 return false;
             return true;
         }
    </script>
    
    <script language="text/javascript">


        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
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
        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets,  and Characters  Only");
            }
        }

    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <div class="row" align="left">
                    <div class="panel panel-primary">
                        <div class="panel-heading" align="center">
                            <h3 class="panel-title"></h3>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="panel-body">
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr runat="server" visible="true">
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top"
                                                colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <asp:HiddenField ID="hf_applicantregridid" runat="server" />
                                                        <td style="width: 250px;">
                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="250px"><b>Application for digging a new well</b><font 
                                                            color="red"></font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlApplicationForDigging" runat="server" class="form-control txtbox" Height="33px"
                                                             AutoPostBack="true" OnSelectedIndexChanged="ddlApplicationForDigging_SelectedIndexChanged"
                                                                TabIndex="1" Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;">
                                                            <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">1. Name of the Applicant:<font 
                                                            color="red"></font></asp:Label>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtNameOfApplicant" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="40" TabIndex="2" onKeyPress="Names" ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;">2. Address of the proposed location
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;District <span style="font-weight: bold; color: Red;">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlDIst" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" TabIndex="3" Width="180px" OnSelectedIndexChanged="ddlDIst_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mandal <span style="font-weight: bold; color: Red;">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Visible="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged"
                                                                TabIndex="4" Height="33px" Width="180px" AutoPostBack="True">
                                                                <%--   <asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Village <span style="font-weight: bold; color: Red;">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox"
                                                                Visible="true" TabIndex="5" Height="33px" Width="180px">
                                                                <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;House No<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtHouseNO" runat="server" class="form-control txtbox" Height="40px"
                                                                MaxLength="40" TabIndex="6" ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="210px"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Street<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtStreet" runat="server" class="form-control txtbox" Height="40px"
                                                                MaxLength="40" TabIndex="7" ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Contact Details<font
                                                            color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mobile No<font
                                                            color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txt_contactmobileno" runat="server" class="form-control txtbox" Height="40px"
                                                                TabIndex="8" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_contactmobileno"
                                                                ErrorMessage="Please Enter Contact Mobile No" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" Display="Dynamic" runat="server" ControlToValidate="txt_contactmobileno"
                                                                ErrorMessage="Numbers must be between 10 to 11 " ForeColor="Red" ValidationExpression="^\d{10,11}$"> 
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email ID<font
                                                            color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txt_contactemailid" runat="server" class="form-control txtbox" Height="40px"
                                                                TabIndex="9" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_contactemailid"
                                                                ErrorMessage="Please Enter Contact EmailID" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic"
                                                                runat="server" ErrorMessage="Please Enter Valid Email ID"
                                                                ControlToValidate="txt_contactemailid"
                                                                ForeColor="Red"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;">
                                                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="200px">3. Location of proposed well(Survey No):<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtlocation" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="40" TabIndex="10" ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                            <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="165px">4.Type of well to be dug:<span style="font-weight: bold; color: Red;"></span></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:DropDownList ID="ddltypeofwell" runat="server" class="form-control txtbox" Height="33px"
                                                                TabIndex="11"
                                                                Width="180px">
                                                               
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="200px">5. Mode of drawing water:</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:DropDownList ID="ddlmode" runat="server" class="form-control txtbox" Height="33px"
                                                                TabIndex="12"
                                                                Width="180px">
                                                                
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                            <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">6. Speification of Pump(HP)</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtSpecification" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="40" TabIndex="13" ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style5" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK">7. Distance from existing functional well(in meters)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtdistance" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="40" TabIndex="14" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                    </tr>

                                                </table>
                                            </td>

                                        </tr>

                                        <tr runat="server" id="tr_gridview" visible="false">
                                            <td>
                                                <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="true" data-add-display-all-btn="true" data-add-focus-btn="true" style="overflow-x: auto;">
                                                    <asp:GridView ID="grid_data" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false" OnRowDataBound="grid_data_RowDataBound" OnRowCommand="grid_data_RowCommand"
                                                        AllowPaging="true" ShowHeaderWhenEmpty="true" ShowFooter="false" EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;" PageSize="50" OnPageIndexChanging="grid_data_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Sr.#
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Document Name
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_grddocname" runat="server" Text='<%# Eval("FileDescription") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Upload Certificate
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hfgrd_filetype" Value='<%# Eval("FileType") %>' runat="server" />
                                                                    <asp:HiddenField ID="hfgrd_filename" Value='<%# Eval("FileName") %>' runat="server" />
                                                                    <asp:HiddenField runat="server" ID="hfform" Value='<%# Eval("FilePath") %>' />
                                                                    <asp:FileUpload ID="File_formcontent" runat="server" CommandName="Uploadfile" Enabled="true"
                                                                        CommandArgument='<%#Eval("FileDescription")%>' />
                                                                    &nbsp; &nbsp; (*.pdf files only)                                

                                        <asp:Label ID="lbl_Upload" runat="server" Visible="false"></asp:Label>
                                                                    <asp:RequiredFieldValidator ID="rfvFileupload" ValidationGroup="validate" runat="server"
                                                                        ControlToValidate="File_formcontent" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnupdate" runat="server" Text="Upload" CausesValidation="false" CssClass="btn btn-info btn-sm mx-2" CommandName="Save" CommandArgument='<%#Eval("FileDescription")+";"+((GridViewRow) Container).RowIndex %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    View
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hyplink_grdview" Target="_blank" Visible="false" NavigateUrl='<%#Eval("FilePath")%>' Text="view" runat="server"></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <PagerStyle CssClass="gridview"></PagerStyle>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>


                                        <tr runat="server" id="tr_check" visible="false">
                                            <td>
                                                <asp:CheckBox ID="chk_declare" runat="server" AutoPostBack="true" Height="20px" TabIndex="16"  OnCheckedChanged="chk_declare_CheckedChanged" Width="20px" />
                                                <b>I hereby declare that the above particulars are true to the best of my knowledge and belief.</b></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="17" Text="Save" ValidationGroup="group"  Width="90px" />
                                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen" Width="90px" />
                                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btm_Payment" runat="server" Visible="false" CausesValidation="False" CssClass="btn btn-primary" Height="32px" OnClick="btm_Payment_Click" TabIndex="10" Text="Payment" ToolTip="Payment" Width="90px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" class="alert alert-success" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group1" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="child" />
                                </div>
                            </ContentTemplate>
                            <Triggers>

                               <%-- <asp:PostBackTrigger ControlID="btn_landPassbook" />
                                <asp:PostBackTrigger ControlID="btn_registercertificate" />
                                <asp:PostBackTrigger ControlID="btn_identityproof" />--%>
                                <asp:PostBackTrigger ControlID="BtnClear" />
                                <asp:PostBackTrigger ControlID="BtnSave" />
                                <asp:PostBackTrigger ControlID="ddlMandal" />
                                <asp:PostBackTrigger ControlID="ddlDIst" />
                                <asp:PostBackTrigger ControlID="grid_data" />

                                <%--  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />
                                  <asp:PostBackTrigger ControlID="ddlDIst" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -110px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
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

</asp:Content>

