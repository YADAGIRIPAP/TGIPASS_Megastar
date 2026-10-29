<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" EnableEventValidation="true" CodeFile="Registrationfordrillingrigshandboring.aspx.cs" Inherits="UI_TSiPASS_Registrationfordrillingrigshandboring" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>

    <script language="javascript">


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


    <div align="left">
        <div class="row" align="left">
            <div class="panel panel-primary">
                <div class="panel-heading" align="center" style="text-align: center">
                    <h3 class="panel-title" style="text-align: center">FORM – 15<br />
                        (See Rule 17)<br />
                        Application for Registration of Drilling Rigs / Hand boring sets
                    </h3>
                </div>
                <div class="panel-body">
                    <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                        <tr>
                            <td style="padding: 5px; margin: 5px" valign="top">
                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                    <asp:HiddenField ID="hf_applicantregridid" runat="server" />
                                    <tr>
                                        <td style="width: 250px;">
                                            <b>Application Type</b><font
                                                color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rd_applicationtype" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                OnSelectedIndexChanged="rd_applicationtype_SelectedIndexChanged" class="form-control txtbox" Height="33px"
                                                TabIndex="1" Width="180px">
                                                <asp:ListItem Selected="True" Value="1">New</asp:ListItem>
                                                <asp:ListItem Value="2">Renewal</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">1.Name of the Applicant<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtNameOfApplicant" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="2" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNameOfApplicant"
                                                ErrorMessage="Please Enter Name of the Applicant" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">2. Address
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;District <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlDIst" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                Height="33px" TabIndex="3" Visible="true" Width="180px" OnSelectedIndexChanged="ddlDIst_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDIst"
                                                ErrorMessage="Please select  District" Display="Dynamic" ValidationGroup="group" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mandal <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Visible="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged"
                                                TabIndex="4" Height="33px" Width="180px" AutoPostBack="True">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMandal"
                                                ErrorMessage="Please select Mandal" Display="Dynamic" ValidationGroup="group" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Village/Town <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox"
                                                Visible="true" TabIndex="5" Height="33px" Width="180px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlVillage"
                                                ErrorMessage="Please select Village" Display="Dynamic" ValidationGroup="group" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;House No<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox ID="txtHouseNO" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHouseNO"
                                                ErrorMessage="Please Enter House No" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Street<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox ID="txtStreet" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="7" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtStreet"
                                                ErrorMessage="Please Enter Street" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
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
                                        <td style="width: 200px;">3. Registration No. of the vehicle:<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtregistrationvehiclenno" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtregistrationvehiclenno"
                                                ErrorMessage="Please Enter Registration No. of the vehicle" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr runat="server" id="tr_plac" visible="false">
                                        <td style="width: 200px;">
                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="200px">4.Place of registration with RTO:<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txt_placeofrtoregistration" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="11" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_placeofrtoregistration"
                                                ErrorMessage="Please Enter Place of registration with RTO" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                            <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="165px">4.In which District RTO registration is Done:<font color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:DropDownList ID="ddl_rtodistrict" runat="server" class="form-control txtbox" Height="33px"
                                                TabIndex="12"
                                                Width="180px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDIst"
                                                ErrorMessage="Please select RTO registration District" Display="Dynamic" ValidationGroup="group" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td class="style5" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK">5. Description of the drilling rig<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox ID="txt_despofdrillingrig" TextMode="MultiLine" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="13" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ControlToValidate="txt_despofdrillingrig"
                                                ErrorMessage="Please Enter  Description of the drilling rig<font " ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">6.Capacity of Drilling
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Max Diameter Depth(In inchs)<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:TextBox ID="txt_maxdiameterdepth" runat="server" class="form-control txtbox" Height="40px"
                                                TabIndex="14" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_maxdiameterdepth"
                                                ErrorMessage="Please Enter Max Diameter Depth(In inchs)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="Regex1" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                                ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
                                                ControlToValidate="txt_maxdiameterdepth" />
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px;">7.Area of operation:<font
                                            color="red">*</font>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txt_areaofoperation" runat="server" class="form-control txtbox" Height="28px"
                                                TabIndex="15" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_areaofoperation"
                                                ErrorMessage="Please Enter Area of operation" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px"></td>
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
                                                    &nbsp; &nbsp; (*.jpg,.jpeg,.png,.pdf,.doc files only)                                

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

                        <tr id="tr_check" runat="server" visible="false">
                            <td>
                                <asp:CheckBox ID="chk_declare" runat="server" AutoPostBack="true" Height="20px" OnCheckedChanged="chk_declare_CheckedChanged" Width="20px" />
                                <b>I hereby declare that the above particulars are true to the best of my knowledge and belief.</b></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click"  OnClientClick="return confirm('RTO District Can't be Changed Once Submitted.Do you want to Submit the record ? ');" TabIndex="24" Text="Save" ValidationGroup="group" Width="90px" />
                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" Text="Clear" ToolTip="To Clear  the Screen" Width="90px" />
                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btm_Payment" runat="server" Visible="false" CausesValidation="False" CssClass="btn btn-primary" Height="32px" OnClick="btm_Payment_Click" TabIndex="25"  OnClientClick="return confirm('RTO District Can't be Changed Once Submitted.Do you want to Submit the record ? ');" Text="Payment" ToolTip="Payment" Width="90px" />
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

            </div>
        </div>
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




</asp:Content>

