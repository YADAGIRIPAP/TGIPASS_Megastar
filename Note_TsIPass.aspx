<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Note_TsIPass.aspx.cs" Inherits="Note_TsIPass" %>


&nbsp;<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script><style type="text/css">
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
                                                                                             </script><%-- <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }--%><%--     }
    </script>--%><%--  <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 12) {
                alert("Aadhar number length must be exactly 12 characters")
            }
        }
    </script>--%><%--    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%><%--<asp:UpdatePanel ID="upd1" runat="server">

        <contenttemplate>
            <scriptmanager>
            </scriptmanager>
            <div align="left">--%>

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
<style>
    p {
        background-image: url('img_girl.jpg');
    }
</style>
<link href='https://fonts.googleapis.com/css?family=Times New Roman' rel='stylesheet'>
<style>
    body {
        font-family: 'Times New Roman';
        font-size: 22px;
    }
</style>
<!DOCTYPE html>
<html>


<body>
    <form runat="server">
        <div id="main">
            <div id="slider">
                <div id="layerslider_2" class="ls-wp-container" style="width: 100%; height: 400px; margin: 0 auto; margin-bottom: 0px;"
                    runat="server">

                    <div align="center" style="background-color: transparent; background-image: url('img_girl.jpg');">


                        <table class="ls-l caption-1" style="top: 230px; left: 7px; font-size: 25px; padding: 15px 30px 15px 25px; white-space: nowrap;"
                            data-ls="offsetxin:-80;delayin:1000;skewxin:-80;">
                        </table>



                        <div align="center">
                            <div class="row" align="center">
                                <div class="col-lg-11">
                                    <div class="panel panel-primary">
                                        <div class="col-md-12">
                                            <h1 class="page-head-line" align="center" style="font-size: x-large"><font color="red">IMPORTANT NOTE</font></h1>
                                        </div>
                                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>--%>
                                        <div class="panel-body" style="vertical-align: middle">
                                            <div runat="server" id="divbtn" visible="false" style="padding-left: 20%; padding-right: 20%; vertical-align: middle">
                                                &nbsp;
                                            </div>
                                            <div>
                                                <table id="Table1" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="lbl1" runat="server" CssClass="LBLBLACK" Width="900px"> 1.	If the industry is already registered with <font color="green"> TG-iPASS</font> please do not create duplicate login.</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table2" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="900px">  2.	If duplicate login is created your application will not be processed and fee paid will not be refunded or transferred to old login.</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table3" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="900px">3.	If the required approvals are not shown in old login, please raise help desk from old login to provide option to apply for required approvals.</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table4" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="900px">4.	If you forgot username/password of old login, click on <font color="blue">“FORGOT PASSWORD” </font>if you know <font color="blue">USERNAME </font>, if you forgot both please click on <font color="blue">“PROVIDE USERNAME AND PASSWORD” </font> and enter the details required, Username and Password will be sent to the mobile number and email registered with the old login.</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table5" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="900px">5.	For expansion of existing industry please take new login</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table6" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="900px">6.	Please select the correct options while answering questionnaire as the approvals required will be shown as per the options selected.<font 
                                                                        color="red"></font></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table7" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="900px">7.	Please upload correct documents for <font color="blue"> “COMMON ATTACHMENTS”</font><font 
                                                                        color="red"></font></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table8" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="900px">8.	Before proceeding to file Common Application Form, while choosing the approvals if you select approvals as <font color="blue"> “ALREADY OBTAINED”</font>, please upload the correct document if irrelevant documents are uploaded the application will not be processed.<font
                                                                        color="red"></font></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table9" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="900px">9.	For amendments to the approvals which are already obtained please contact the concerned department.<font 
                                                                        color="red"></font></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table10" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="900px"><font style="font-family: Sofia">10.	For any assistance, please contact  <font style="font-family: Sofia" color="red"> CUSTOMER CARE NUMBER </font>– <font color="blue">040 23441636 </font>
                                                                      </font> <font color="red"> </font></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table11" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <asp:CheckBox id="chktick" AutoPostBack="true" runat="server" OnCheckedChanged="chktick_CheckedChanged"></asp:CheckBox>
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="700px"><b>I have read all the above conditions and I am not violating the procedure.</b><font 
                                                                        color="red">*</font></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                                <table id="Table13" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center"></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divhplnk" runat="server" visible="false">
                                                <table id="Table12" runat="server" align="center" cellpadding="10" cellspacing="5"
                                                    style="width: 70%">
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: left;"
                                                            valign="middle" colspan="2" align="center">
                                                            <a href="tsHome.aspx">Please Go To Home Page</a>
                                                        </td>
                                                        <td style="vertical-align: middle; text-align: right;"
                                                            valign="middle" colspan="2" align="center">
                                                            <label id="lblhyp" runat="server" cssclass="LBLBLACK" backcolor="green">
                                                                <a href="UI/TSiPASS/AddnewuserRegistration.aspx">Continue With New Registration</a>
                                                            </label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>


                                            <%-- </table>
                                            </td>
                                            </tr>
                                            
                                            
                                            </table>--%>
                                            <table>
                                                <tr id="tblRegister2" runat="server">
                                                    <td align="center" colspan="2" style="padding: 5px; margin: 5px; text-align: center;">
                                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:HiddenField ID="hdfUploadFile1" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group1" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>

                                </div>
                            </div>
                        </div>
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
        <%--  </contenttemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
