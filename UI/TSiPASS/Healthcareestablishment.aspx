<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="Healthcareestablishment.aspx.cs" inherits="UI_TSiPASS_Healthcareestablishment" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    &nbsp;<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script><style
        type="text/css">
                                                                                                     .overlay {
                                                                                                         position: fixed;
                                                                                                         z-index: 999;
                                                                                                         height: 100%;
                                                                                                         width: 100%;
                                                                                                         top: 1px;
                                                                                                         background-color: Gray;
                                                                                                         filter: alpha(opacity=60);
                                                                                                         opacity: 0.9;
                                                                                                         -moz-opacity: 0.9;
                                                                                                     }
                                                                                                 </style><script type="text/javascript" language="javascript">

                                                                                                             function OpenPopup() {

                                                                                                                 window.open("Lookups/LookupTST.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

                                                                                                                 return false;
                                                                                                             }
                                                                                                 </script><script type="text/javascript">
                                                                                                              function pageLoad() {
                                                                                                                  var date = new Date();
                                                                                                                  var currentMonth = date.getMonth();
                                                                                                                  var currentDate = date.getDate();
                                                                                                                  var currentYear = date.getFullYear();

                                                                                                                  $("input[id$='txtdate']").datepicker(
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
                                                                                                                  $("input[id$='txtdate']").datepicker(
                                                                                                                      {
                                                                                                                          //dateFormat: "dd/mm/yy",
                                                                                                                          dateFormat: "dd/mm/yy",
                                                                                                                          //maxDate: new Date(currentYear, currentMonth, currentDate)
                                                                                                                      });
                                                                                                              });
                                                                                                 </script><script type="text/javascript">
                                                                                                              function pageLoad() {
                                                                                                                  var date = new Date();
                                                                                                                  var currentMonth = date.getMonth();
                                                                                                                  var currentDate = date.getDate();
                                                                                                                  var currentYear = date.getFullYear();

                                                                                                                  $("input[id$='txttodate']").datepicker(
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
                                                                                                                  $("input[id$='txttodate']").datepicker(
                                                                                                                      {
                                                                                                                          //dateFormat: "dd/mm/yy",
                                                                                                                          dateFormat: "dd/mm/yy",
                                                                                                                          //maxDate: new Date(currentYear, currentMonth, currentDate)
                                                                                                                      });
                                                                                                              });
                                                                                                 </script>

    <asp:updatepanel id="upd1" runat="server">
        <contenttemplate>
            <div align="left">
                <%--<ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx">Dashboard</a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-table"></i> Masters
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">TST Team</a>
                            </li>
                        </ol>--%>
            </div>
            <input type="hidden" id="hdnfocus" value="" runat="server" />
            <%--<div>
                <table style="width: 100%">
                    <tr>
                        <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                             <div id="Div1" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="Label1" runat="server"></asp:Label>
                            </div>
                            <div id="Div2" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>--%>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <asp:label id="lblHeading" runat="server" align="center" text="Application for Authorization under BiomedicalWasteManagement Rules 2016"></asp:label>
                                </h3>
                            </div>
                            <asp:updatepanel id="UpdatePanel1" runat="server">
                                <contenttemplate>
                                    <div class="panel-body" style="vertical-align: middle">
                                        <div runat="server" id="divbtn" visible="false" style="padding-left: 20%; padding-right: 20%; vertical-align: middle">
                                            &nbsp;
                                        </div>
                                        <div>
                                            <table id="Table1" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                style="width: 30%">
                                                <tr>
                                                    <td style="vertical-align: middle; text-align: center;" valign="middle" colspan="2"
                                                        align="center"></td>
                                                </tr>
                                                <tr runat="server" id="tblRegister">
                                                    <td style="padding: 5px; margin: 5px;" valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:label id="lblHCEname" runat="server" cssclass="LBLBLACK" width="165px">Health care establishment (HCE) name<font
                                                                        color="red">*</font></asp:label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:textbox id="txtHCEname" runat="server" class="form-control txtbox" height="28px"
                                                                        maxlength="300" tabindex="1" validationgroup="group" width="180px">
                                                                    </asp:textbox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtHCEname"
                                                                        errormessage="Enter Name" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:label id="lblHCElocation" runat="server" cssclass="LBLBLACK" width="165px">HCE location- Postal Address<font
                                                                        color="red">*</font></asp:label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:textbox id="txtHCElocation" runat="server" class="form-control txtbox"
                                                                        height="50px" maxlength="500" tabindex="1" validationgroup="group" width="550px">
                                                                    </asp:textbox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtHCElocation"
                                                                        errormessage="Please enter Location" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:label id="lblPincode" runat="server" cssclass="LBLBLACK" width="165px">Pin code<font
                                                                        color="red">*</font></asp:label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:textbox id="txtPincode" runat="server" class="form-control txtbox" height="28px"
                                                                        maxlength="6" tabindex="1" onkeypress="NumberOnly()" validationgroup="group"
                                                                        width="180px">
                                                                    </asp:textbox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="txtPincode"
                                                                        errormessage="Please enter pincode" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:label id="lblRevenuedistrict" runat="server" cssclass="LBLBLACK" width="165px">Revenue district<font
                                                                        color="red">*</font></asp:label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:dropdownlist id="ddldistrict" runat="server" class="form-control txtbox" height="30px"
                                                                        autopostback="True" onselectedindexchanged="ddldistrict_SelectedIndexChanged"
                                                                        tabindex="4" width="180px">
                                                                        <asp:listitem>--Select--</asp:listitem>
                                                                    </asp:dropdownlist>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="ddldistrict"
                                                                        errormessage="Please select district" initialvalue="--Select--" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:label id="lblMandal" runat="server" cssclass="LBLBLACK" width="165px">Mandal<font
                                                                        color="red">*</font></asp:label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:dropdownlist id="ddlmandal" runat="server" class="form-control txtbox" height="30px"
                                                                        tabindex="4" autopostback="True" onselectedindexchanged="ddlmandal_SelectedIndexChanged"
                                                                        width="180px">
                                                                        <asp:listitem>--Select--</asp:listitem>
                                                                    </asp:dropdownlist>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="ddlmandal"
                                                                        errormessage="Please select Mandal" initialvalue="--Select--" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:label id="lblVillage" runat="server" cssclass="LBLBLACK" width="165px">Village<font
                                                                        color="red">*</font></asp:label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:dropdownlist id="ddlVillage" runat="server" class="form-control txtbox" height="30px"
                                                                        tabindex="4" width="180px">
                                                                        <asp:listitem>--Select--</asp:listitem>
                                                                    </asp:dropdownlist>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="ddlVillage"
                                                                        errormessage="Please select village" initialvalue="--Select--" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:label id="lblapptype" runat="server" cssclass="LBLBLACK" width="165px">Application Type<font
                                                                        color="red">*</font></asp:label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                    <asp:dropdownlist id="ddlapptype" runat="server" class="form-control txtbox" height="30px"
                                                                        tabindex="4" width="180px">
                                                                        <asp:listitem value="0">--Select--</asp:listitem>
                                                                        <asp:listitem value="1">FRESH</asp:listitem>
                                                                        <asp:listitem value="2">RENEWAL</asp:listitem>
                                                                    </asp:dropdownlist>
                                                                </td>
                                                                <asp:hiddenfield id="hdnhcid" runat="server" />
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="ddlapptype"
                                                                        errormessage="Please select type" initialvalue="--Select--" validationgroup="group">
                                                                        *</asp:requiredfieldvalidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <asp:label runat="server" height="32px"></asp:label>
                                                        </table>
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr id="tblRegister1" runat="server">
                                                                <td>
                                                                    <asp:button id="btnsave" runat="server" validationgroup="group" cssclass="btn btn-primary"
                                                                        height="32px" tabindex="10" text="Save" width="90px" onclick="Btnsave_Click"
                                                                        visible="true" />
                                                                </td>
                                                                <td>
                                                                    <asp:button id="btnnext" runat="server" validationgroup="group" cssclass="btn btn-danger"
                                                                        height="32px" tabindex="10" text="Next" width="90px" onclick="Btnnext_Click"
                                                                        visible="true" />
                                                                </td>
                                                                <td>
                                                                    <asp:button id="BtnClear" runat="server" validationgroup="group" cssclass="btn btn-warning"
                                                                        height="32px" tabindex="10" text="ClearAll" onclick="BtnClear_Click" tooltip="To Clear  the Screen"
                                                                        width="90px" />
                                                                    <asp:hiddenfield id="hdnQueid" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="color: crimson;">
                                                                    <br />
                                                                    <img src="../../images/Dealers/1aHD.gif" height="40px" width="80px" />

                                                                    <b>If you click on Next you will be redirected to PCB Portal. After entering the PCB portal, fill in all the required details, including attachments (if necessary). While saving, select &quot;Do you want to save the application&quot; as completed and then click Save. After that, in TGIPASS pay the fee. Then your application will be submitted.</b>&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;<tr>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                                        </td>
                                                    </tr>
                                                    </td>
                                                </tr>
                                            </table>
                                            </td> </tr> </table>
                                            <tr id="tblRegister2" runat="server">
                                                <td align="center" colspan="2" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:label id="lblmsg0" runat="server"></asp:label>
                                                    </div>
                                                </td>
                                            </tr>
                                            </table>
                                        </div>
                                        <asp:hiddenfield id="hdfID" runat="server" />
                                        <asp:hiddenfield id="hdfUploadFile1" runat="server" />
                                        <asp:validationsummary id="ValidationSummary1" runat="server" showmessagebox="True"
                                            showsummary="False" validationgroup="group" />
                                        <asp:validationsummary id="ValidationSummary2" runat="server" showmessagebox="True"
                                            showsummary="False" validationgroup="group1" />
                                        <asp:hiddenfield id="hdfFlagID" runat="server" />
                                    </div>
                                </contenttemplate>
                            </asp:updatepanel>
                        </div>
                    </div>
                </div>
            </div>
            <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
        </contenttemplate>
    </asp:updatepanel>
</asp:content>
